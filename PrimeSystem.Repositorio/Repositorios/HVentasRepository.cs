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
    public class HVentasRepository : BaseRepositorio, IHVentasRepository
    {
        public Result<HVentas> Add(HVentas venta)
        {
            try
            {
                using OleDbConnection conexion = Conexion();
                using OleDbCommand cmd = new OleDbCommand("INSERT INTO HVentas (Cod_Usuario, Fecha_Hora, Id_Cliente, Subtotal, Descu, Total) VALUES (@Cod_Usuario, @Fecha_Hora, @Id_Cliente, @Subtotal, @Descu, @Total)", conexion);
                cmd.Parameters.AddWithValue("@Cod_Usuario", venta.Cod_Usuario);
                cmd.Parameters.AddWithValue("@Fecha_Hora", venta.Fecha_Hora);
                cmd.Parameters.AddWithValue("@Id_Cliente", venta.Id_Cliente);
                cmd.Parameters.AddWithValue("@Subtotal", venta.Subtotal);
                cmd.Parameters.AddWithValue("@Descu", venta.Descu);
                cmd.Parameters.AddWithValue("@Total", venta.Total);
                conexion.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado > 0)
                {
                    return Result<HVentas>.Success(venta);
                }
                else
                {
                    return Result<HVentas>.Failure("No se pudo agregar la venta.");
                }
            }catch (OleDbException ex)
            {
                return Result<HVentas>.Failure($"Error al agregar la venta: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                return Result<HVentas>.Failure($"Error inesperado al agregar la venta: {ex.Message}");
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using OleDbConnection conexion = Conexion();
                using OleDbCommand cmd = new OleDbCommand("DELETE FROM HVentas WHERE Id_Remito = @Id_Remito", conexion);
                cmd.Parameters.AddWithValue("@Id_Remito", id);
                conexion.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado > 0)
                {
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure("No se pudo eliminar la venta.");
                }
            }catch (OleDbException ex)
            {
                return Result<bool>.Failure($"Error al eliminar la venta: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                return Result<bool>.Failure($"Error inesperado al eliminar la venta: {ex.Message}");
            }
        }

        public Result<List<HVentas>> GetAll()
        {
            try
            {
                var ventas = new List<HVentas>();
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using (var cmd = new OleDbCommand("SELECT Id_Remito,Cod_Usuario,Fecha_Hora,Id_Cliente,Subtotal,Total FROM HVentas", conexion))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ventas.Add(new HVentas
                            {
                                Id_Remito = reader.GetInt32(0),
                                Cod_Usuario = reader.GetInt32(1),
                                Fecha_Hora = reader.GetDateTime(2),
                                Id_Cliente = reader.GetInt32(3),
                                Subtotal = reader.GetDouble(4),
                                Descu = reader.GetDouble(5),
                                Total = reader.GetDouble(6)
                            });
                        }
                    }
                }
                return Result<List<HVentas>>.Success(ventas);
            }
            catch (OleDbException ex)
            {
                return Result<List<HVentas>>.Failure($"Error al obtener ventas: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                return Result<bool>.Failure($"Error inesperado al eliminar la venta: {ex.Message}");
            }
        }

        public Result<HVentas> GetById(int id)
        {
            try
            {
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using (var cmd = new OleDbCommand("SELECT Id_Remito,Cod_Usuario,Fecha_Hora,Id_Cliente,Subtotal,Total FROM HVentas WHERE Id_Remito = @id", conexion))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var venta = new HVentas
                                {
                                    Id_Remito = reader.GetInt32(0),
                                    Cod_Usuario = reader.GetInt32(1),
                                    Fecha_Hora = reader.GetDateTime(2),
                                    Id_Cliente = reader.GetInt32(3),
                                    Subtotal = reader.GetDouble(4),
                                    Descu = reader.GetDouble(5),
                                    Total = reader.GetDouble(6)
                                };
                                return Result<HVentas>.Success(venta);
                            }
                        }
                    }
                }
                return Result<HVentas>.Failure("Venta no encontrada");
            }
            catch (OleDbException ex)
            {
                return Result<HVentas>.Failure($"Error al obtener venta");
            }
            catch (System.Exception ex)
            {
                return Result<bool>.Failure($"Error inesperado al eliminar la venta: {ex.Message}");
            }
        }

        public Result<HVentas> Update(HVentas venta)
        {
            try
            {
                using OleDbConnection conexion = Conexion();
                using OleDbCommand cmd = new OleDbCommand("UPDATE HVentas SET Cod_Usuario = @Cod_Usuario, Fecha_Hora = @Fecha_Hora, Id_Cliente = @Id_Cliente, Subtotal = @Subtotal, Descu = @Descu, Total = @Total WHERE Id_Remito = @Id_Remito", conexion);
                cmd.Parameters.AddWithValue("@Cod_Usuario", venta.Cod_Usuario);
                cmd.Parameters.AddWithValue("@Fecha_Hora", venta.Fecha_Hora);
                cmd.Parameters.AddWithValue("@Id_Cliente", venta.Id_Cliente);
                cmd.Parameters.AddWithValue("@Subtotal", venta.Subtotal);
                cmd.Parameters.AddWithValue("@Descu", venta.Descu);
                cmd.Parameters.AddWithValue("@Total", venta.Total);
                cmd.Parameters.AddWithValue("@Id_Remito", venta.Id_Remito);
                conexion.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado > 0)
                {
                    return Result<HVentas>.Success(venta);
                }
                else
                {
                    return Result<HVentas>.Failure("No se pudo actualizar la venta.");
                }
            }catch (OleDbException ex)
            {
                return Result<HVentas>.Failure($"Error al actualizar la venta: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                return Result<HVentas>.Failure($"Error inesperado al actualizar la venta: {ex.Message}");
            }
        }
    }
}
