using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Runtime.Versioning;
using PrimeSystem.Contrato.Repositorios;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class HComprasRepository : BaseRepositorio, IHComprasRepository
    {
        public Result<List<HCompras>> GetAll()
        {
            try
            {
                var compras = new List<HCompras>();
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using (var cmd = new OleDbCommand("SELECT Id_Remito,Cod_Usuario,Fecha_Hora,Id_Proveedor,Subtotal,Descuento,Total FROM H_Compras", conexion))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            compras.Add(new HCompras
                            {
                                Id_Remito = reader.GetInt32(0),
                                Cod_Usuario = reader.GetInt32(1),
                                Fecha_Hora = reader.GetDateTime(2),
                                Id_Proveedor = reader.GetInt32(3),
                                Subtotal = reader.GetDecimal(4),
                                Descuento = reader.GetDecimal(5),
                                Total = reader.GetDecimal(6)
                            });
                        }
                    }
                }
                return Result<List<HCompras>>.Success(compras);
            }
            catch (OleDbException ex)
            {
                return Result<List<HCompras>>.Failure($"Error al obtener compras: {ex.Message}");
            }
        }

        public Result<HCompras> GetById(int id)
        {
            try
            {
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using (var cmd = new OleDbCommand("SELECT Id_Remito,Cod_Usuario,Fecha_Hora,Id_Proveedor,Subtotal,Descuento,Total FROM H_Compras WHERE Id_Remito = @id_remito", conexion))
                    {
                        cmd.Parameters.AddWithValue("@id_remito", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var compra = new HCompras
                                {
                                    Id_Remito = reader.GetInt32(0),
                                    Cod_Usuario = reader.GetInt32(1),
                                    Fecha_Hora = reader.GetDateTime(2),
                                    Id_Proveedor = reader.GetInt32(3),
                                    Subtotal = reader.GetDecimal(4),
                                    Descuento = reader.GetDecimal(5),
                                    Total = reader.GetDecimal(6)
                                };
                                return Result<HCompras>.Success(compra);
                            }
                        }
                    }
                }
                return Result<HCompras>.Failure("Compra no encontrada");
            }
            catch (OleDbException ex)
            {
                return Result<HCompras>.Failure($"Error al obtener compra: {ex.Message}");
            }
        }

        public Result<HCompras> Add(HCompras compra)
        {
            try
            {
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using (var cmd = new OleDbCommand(
                        "INSERT INTO H_Compras (Cod_Usuario, Fecha_Hora, Id_Proveedor, Subtotal, Descu, Total) " +
                        "VALUES (@Cod_Usuario, @Fecha_Hora, @Id_Proveedor, @Subtotal, @Descuento, @Total)", conexion))
                    {
                        cmd.Parameters.AddWithValue("@Cod_Usuario", compra.Cod_Usuario);
                        cmd.Parameters.AddWithValue("@Fecha_Hora", compra.Fecha_Hora);
                        cmd.Parameters.AddWithValue("@Id_Proveedor", compra.Id_Proveedor);
                        cmd.Parameters.AddWithValue("@Subtotal", compra.Subtotal);
                        cmd.Parameters.AddWithValue("@Descuento", compra.Descuento);
                        cmd.Parameters.AddWithValue("@Total", compra.Total);
                        
                        cmd.ExecuteNonQuery();
                        
                        // Obtener el ID de la compra insertada
                        using (var cmdId = new OleDbCommand("SELECT @@IDENTITY", conexion))
                        {
                            var newId = Convert.ToInt32(cmdId.ExecuteScalar());
                            compra.Id_Remito = newId;
                        }
                    }
                }
                return Result<HCompras>.Success(compra);
            }
            catch (OleDbException ex)
            {
                return Result<HCompras>.Failure($"Error al agregar compra: {ex.Message}");
            }
        }

        public Result<HCompras> AddWithDetails(HCompras compra, List<PrimeSystem.Modelo.ProductoResumen> productosResumen)
        {
            try
            {
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using (var transaction = conexion.BeginTransaction())
                    {
                        try
                        {
                            // Insertar la compra principal
                            int newId;
                            using (var cmd = new OleDbCommand(
                                "INSERT INTO H_Compras (Cod_Usuario, Fecha_Hora, Id_Proveedor, Subtotal, Descu, Total) " +
                                "VALUES (@Cod_Usuario, @Fecha_Hora, @Id_Proveedor, @Subtotal, @Descuento, @Total)", conexion, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Cod_Usuario", compra.Cod_Usuario);
                                cmd.Parameters.AddWithValue("@Fecha_Hora", compra.Fecha_Hora);
                                cmd.Parameters.AddWithValue("@Id_Proveedor", compra.Id_Proveedor);
                                cmd.Parameters.AddWithValue("@Subtotal", compra.Subtotal);
                                cmd.Parameters.AddWithValue("@Descuento", compra.Descuento);
                                cmd.Parameters.AddWithValue("@Total", compra.Total);
                                
                                cmd.ExecuteNonQuery();
                                
                                // Obtener el ID de la compra insertada
                                using (var cmdId = new OleDbCommand("SELECT @@IDENTITY", conexion, transaction))
                                {
                                    newId = Convert.ToInt32(cmdId.ExecuteScalar());
                                    compra.Id_Remito = newId;
                                }
                            }
                            
                            // Insertar los detalles de la compra
                            foreach (var producto in productosResumen)
                            {
                                using (var cmd = new OleDbCommand(
                                    "INSERT INTO H_Compras_Detalle (Id_Remito, Cod_Art, Descr, P_Unit, Cant, P_X_Cant) " +
                                    "VALUES (@Id_Remito, @Cod_Art, @Descr, @P_Unit, @Cant, @P_X_Cant)", conexion, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@Id_Remito", newId);
                                    cmd.Parameters.AddWithValue("@Cod_Art", producto.Cod_Articulo);
                                    cmd.Parameters.AddWithValue("@Descr", producto.Producto_Nombre);
                                    cmd.Parameters.AddWithValue("@P_Unit", producto.Producto_Precio);
                                    cmd.Parameters.AddWithValue("@Cant", producto.Producto_Cantidad);
                                    cmd.Parameters.AddWithValue("@P_X_Cant", producto.Producto_PrecioxCantidad);
                                    
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            
                            // Si llegamos aquí, todo salió bien, hacemos commit
                            transaction.Commit();
                            return Result<HCompras>.Success(compra);
                        }
                        catch (Exception)
                        {
                            // Si algo falla, hacemos rollback
                            transaction.Rollback();
                            throw; // Relanzamos la excepción para que sea manejada por el catch exterior
                        }
                    }
                }
            }
            catch (OleDbException ex)
            {
                return Result<HCompras>.Failure($"Error al agregar compra con detalles: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<HCompras>.Failure($"Error inesperado al agregar compra con detalles: {ex.Message}");
            }
        }

        public Result<HCompras> Update(HCompras compra)
        {
            try
            {
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using (var cmd = new OleDbCommand(
                        "UPDATE H_Compras SET Cod_Usuario = @Cod_Usuario, Fecha_Hora = @Fecha_Hora, Id_Proveedor = @Id_Proveedor, Subtotal = @Subtotal, Descuento = @Descuento, Total = @Total " +
                        "WHERE Id_Remito = @id_remito", conexion))
                    {
                        cmd.Parameters.AddWithValue("@Cod_Usuario", compra.Cod_Usuario);
                        cmd.Parameters.AddWithValue("@Fecha_Hora", compra.Fecha_Hora);
                        cmd.Parameters.AddWithValue("@Id_Proveedor", compra.Id_Proveedor);
                        cmd.Parameters.AddWithValue("@Subtotal", compra.Subtotal);
                        cmd.Parameters.AddWithValue("@Descuento", compra.Descuento);
                        cmd.Parameters.AddWithValue("@Total", compra.Total);
                        cmd.Parameters.AddWithValue("@id_remito", compra.Id_Remito);
                        
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return Result<HCompras>.Success(compra);
                        }
                        else
                        {
                            return Result<HCompras>.Failure("No se encontró la compra a actualizar");
                        }
                    }
                }
            }
            catch (OleDbException ex)
            {
                return Result<HCompras>.Failure($"Error al actualizar compra: {ex.Message}");
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using (var cmd = new OleDbCommand("DELETE FROM H_Compras WHERE Id_Remito = @id_remito", conexion))
                    {
                        cmd.Parameters.AddWithValue("@id_remito", id);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        
                        if (rowsAffected > 0)
                        {
                            return Result<bool>.Success(true);
                        }
                        else
                        {
                            return Result<bool>.Failure("No se encontró la compra a eliminar");
                        }
                    }
                }
            }
            catch (OleDbException ex)
            {
                return Result<bool>.Failure($"Error al eliminar compra: {ex.Message}");
            }
        }

        public Result<List<HCompras>> GetFiltered(DateTime fechaDesde, DateTime fechaHasta, string proveedor, int? idRemito)
        {
            try
            {
                var compras = new List<HCompras>();
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    
                    // Construir la consulta dinámicamente
                    var query = "SELECT Id_Remito, Cod_Usuario, Fecha_Hora, Id_Proveedor, Subtotal, Descuento, Total FROM H_Compras WHERE Fecha_Hora >= @fechaDesde AND Fecha_Hora <= @fechaHasta";
                    var parameters = new List<OleDbParameter>
                    {
                        new OleDbParameter("@fechaDesde", fechaDesde),
                        new OleDbParameter("@fechaHasta", fechaHasta)
                    };
                    
                    // Agregar filtros opcionales
                    if (!string.IsNullOrEmpty(proveedor))
                    {
                        query += " AND Id_Proveedor IN (SELECT Id_Proveedor FROM Proveedores WHERE Nombre LIKE ?)";
                        parameters.Add(new OleDbParameter("@proveedor", $"%{proveedor}%"));
                    }
                    
                    if (idRemito.HasValue)
                    {
                        query += " AND Id_Remito = ?";
                        parameters.Add(new OleDbParameter("@idRemito", idRemito.Value));
                    }
                    
                    query += " ORDER BY Fecha_Hora DESC";
                    
                    using (var cmd = new OleDbCommand(query, conexion))
                    {
                        // Agregar parámetros en orden
                        cmd.Parameters.Add(new OleDbParameter("@fechaDesde", fechaDesde));
                        cmd.Parameters.Add(new OleDbParameter("@fechaHasta", fechaHasta));
                        
                        if (!string.IsNullOrEmpty(proveedor))
                        {
                            cmd.Parameters.Add(new OleDbParameter("@proveedor", $"%{proveedor}%"));
                        }
                        
                        if (idRemito.HasValue)
                        {
                            cmd.Parameters.Add(new OleDbParameter("@idRemito", idRemito.Value));
                        }
                        
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                compras.Add(new HCompras
                                {
                                    Id_Remito = reader.GetInt32(0),
                                    Cod_Usuario = reader.GetInt32(1),
                                    Fecha_Hora = reader.GetDateTime(2),
                                    Id_Proveedor = reader.GetInt32(3),
                                    Subtotal = reader.GetDecimal(4),
                                    Descuento = reader.GetDecimal(5),
                                    Total = reader.GetDecimal(6)
                                });
                            }
                        }
                    }
                }
                return Result<List<HCompras>>.Success(compras);
            }
            catch (OleDbException ex)
            {
                return Result<List<HCompras>>.Failure($"Error al filtrar compras: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<List<HCompras>>.Failure($"Error inesperado: {ex.Message}");
            }
        }
    }
}
