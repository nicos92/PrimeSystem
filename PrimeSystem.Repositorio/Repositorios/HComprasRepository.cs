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
                    using (var cmd = new OleDbCommand("SELECT Id_Remito,Cod_Usuario,Fecha_Hora,Id_Proveedor,Subtotal,Descuento,Total FROM HCompras", conexion))
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
                    using (var cmd = new OleDbCommand("SELECT Id_Remito,Cod_Usuario,Fecha_Hora,Id_Proveedor,Subtotal,Descuento,Total FROM HCompras WHERE Id_Remito = @id_remito", conexion))
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
                        "INSERT INTO HCompras (Cod_Usuario, Fecha_Hora, Id_Proveedor, Subtotal, Descuento, Total) " +
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

        public Result<HCompras> Update(HCompras compra)
        {
            try
            {
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using (var cmd = new OleDbCommand(
                        "UPDATE HCompras SET Cod_Usuario = @Cod_Usuario, Fecha_Hora = @Fecha_Hora, Id_Proveedor = @Id_Proveedor, Subtotal = @Subtotal, Descuento = @Descuento, Total = @Total " +
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
                    using (var cmd = new OleDbCommand("DELETE FROM HCompras WHERE Id_Remito = @id_remito", conexion))
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
    }
}
