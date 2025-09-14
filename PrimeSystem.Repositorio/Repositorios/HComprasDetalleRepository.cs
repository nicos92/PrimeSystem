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
    public class HComprasDetalleRepository : BaseRepositorio, IHComprasDetalleRepository
    {
        public Result<List<HComprasDetalle>> GetAll()
        {
            try
            {
                var detalles = new List<HComprasDetalle>();
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using var cmd = new OleDbCommand("SELECT Id_Det_Remito, Id_Remito, Cod_Art, Descr, P_Unit, Cant, P_X_Cant FROM H_Compras_Detalle", conexion);
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        detalles.Add(new HComprasDetalle
                        {
                            Id_Det_Remito = reader.GetInt32(0),
                            Id_Remito = reader.GetInt32(1),
                            Cod_Art = reader.GetString(2),
                            Descr = reader.GetString(3),
                            P_Unit = reader.GetDecimal(4),
                            Cant = reader.GetInt32(5),
                            P_X_Cant = reader.GetDecimal(6)
                        });
                    }
                }
                return Result<List<HComprasDetalle>>.Success(detalles);
            }
            catch (OleDbException ex)
            {
                return Result<List<HComprasDetalle>>.Failure($"Error al obtener detalles de compras: {ex.Message}");
            }catch(Exception ex)
            {
                return Result<List<HComprasDetalle>>.Failure($"Error inesperado: {ex.Message}");
            }
        }

        public Result<HComprasDetalle> GetById(int id)
        {
            try
            {
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using var cmd = new OleDbCommand("SELECT Id_Det_Remito, Id_Remito, Cod_Art, Descr, P_Unit, Cant, P_X_Cant FROM H_Compras_Detalle WHERE Id_Det_Remito = @id", conexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    using var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        var detalle = new HComprasDetalle
                        {
                            Id_Det_Remito = reader.GetInt32(0),
                            Id_Remito = reader.GetInt32(1),
                            Cod_Art = reader.GetString(2),
                            Descr = reader.GetString(3),
                            P_Unit = reader.GetDecimal(4),
                            Cant = reader.GetInt32(5),
                            P_X_Cant = reader.GetDecimal(6)
                        };
                        return Result<HComprasDetalle>.Success(detalle);
                    }
                }
                return Result<HComprasDetalle>.Failure("Detalle de compra no encontrado");
            }
            catch (OleDbException ex)
            {
                return Result<HComprasDetalle>.Failure($"Error al obtener detalle de compra: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<HComprasDetalle>.Failure($"Error inesperado: {ex.Message}");
            }
        }

        public Result<HComprasDetalle> Add(HComprasDetalle detalle)
        {
            try
            {
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using var cmd = new OleDbCommand(
                        "INSERT INTO H_Compras_Detalle (Id_Remito, Cod_Art, Descr, P_Unit, Cant, P_X_Cant) " +
                        "VALUES (@Id_Remito, @Cod_Art, @Descr, @P_Unit, @Cant, @P_X_Cant)", conexion);
                    cmd.Parameters.AddWithValue("@Id_Remito", detalle.Id_Remito);
                    cmd.Parameters.AddWithValue("@Cod_Art", detalle.Cod_Art);
                    cmd.Parameters.AddWithValue("@Descr", detalle.Descr);
                    cmd.Parameters.AddWithValue("@P_Unit", detalle.P_Unit);
                    cmd.Parameters.AddWithValue("@Cant", detalle.Cant);
                    cmd.Parameters.AddWithValue("@P_X_Cant", detalle.P_X_Cant);

                    cmd.ExecuteNonQuery();

                    // Obtener el ID del detalle insertado
                    using var cmdId = new OleDbCommand("SELECT @@IDENTITY", conexion);
                    var newId = Convert.ToInt32(cmdId.ExecuteScalar());
                    detalle.Id_Det_Remito = newId;
                }
                return Result<HComprasDetalle>.Success(detalle);
            }
            catch (OleDbException ex)
            {
                return Result<HComprasDetalle>.Failure($"Error al agregar detalle de compra: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<HComprasDetalle>.Failure($"Error inesperado: {ex.Message}");
            }
        }

        public Result<HComprasDetalle> Update(HComprasDetalle detalle)
        {
            try
            {
                using var conexion = Conexion();
                conexion.Open();
                using var cmd = new OleDbCommand(
                    "UPDATE H_Compras_Detalle SET Id_Remito = @Id_Remito, Cod_Art = @Cod_Art, Descr = @Descr, P_Unit =  @P_Unit, Cant = @Cant, P_X_Cant = @P_X_Cant " +
                    "WHERE Id_Det_Remito = @Id_Det_Remito", conexion);
                cmd.Parameters.AddWithValue("@Id_Remito", detalle.Id_Remito);
                cmd.Parameters.AddWithValue("@Cod_Art", detalle.Cod_Art);
                cmd.Parameters.AddWithValue("@Descr", detalle.Descr);
                cmd.Parameters.AddWithValue("@P_Unit", detalle.P_Unit);
                cmd.Parameters.AddWithValue("@Cant", detalle.Cant);
                cmd.Parameters.AddWithValue("@P_X_Cant", detalle.P_X_Cant);
                cmd.Parameters.AddWithValue("@Id_Det_Remito", detalle.Id_Det_Remito);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<HComprasDetalle>.Success(detalle);
                }
                else
                {
                    return Result<HComprasDetalle>.Failure("No se encontró el detalle de compra a actualizar");
                }
            }
            catch (OleDbException ex)
            {
                return Result<HComprasDetalle>.Failure($"Error al actualizar detalle de compra: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<HComprasDetalle>.Failure($"Error inesperado: {ex.Message}");
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using var conexion = Conexion();
                conexion.Open();
                using var cmd = new OleDbCommand("DELETE FROM H_Compras_Detalle WHERE Id_Det_Remito = @Id_Det_Remito", conexion);
                cmd.Parameters.AddWithValue("@Id_Det_Remito", id);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure("No se encontró el detalle de compra a eliminar");
                }
            }
            catch (OleDbException ex)
            {
                return Result<bool>.Failure($"Error al eliminar detalle de compra: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Error inesperado: {ex.Message}");
            }
        }

        public async Task<Result<List<HComprasDetalle>>> GetByRemitoId(int idRemito)
        {
            try
            {
                var detalles = new List<HComprasDetalle>();
                using (var conexion = Conexion())
                {
                    await conexion.OpenAsync();
                    using var cmd = new OleDbCommand("SELECT Id_Det_Remito, Id_Remito, Cod_Art, Descr, P_Unit, Cant, P_X_Cant FROM H_Compras_Detalle WHERE Id_Remito = @idRemito", conexion);
                    cmd.Parameters.AddWithValue("@idRemito", idRemito);
                    using var reader = await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        detalles.Add(new HComprasDetalle
                        {
                            Id_Det_Remito = reader.GetInt32(0),
                            Id_Remito = reader.GetInt32(1),
                            Cod_Art = reader.GetString(2),
                            Descr = reader.GetString(3),
                            P_Unit = reader.GetDecimal(4),
                            Cant = reader.GetInt32(5),
                            P_X_Cant = reader.GetDecimal(6)
                        });
                    }
                }
                return Result<List<HComprasDetalle>>.Success(detalles);
            }
            catch (OleDbException ex)
            {
                return Result<List<HComprasDetalle>>.Failure($"Error al obtener detalles de compras: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<List<HComprasDetalle>>.Failure($"Error inesperado: {ex.Message}");
            }
        }
    }
}
