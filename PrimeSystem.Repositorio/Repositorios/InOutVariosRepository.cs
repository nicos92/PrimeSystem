using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrimeSystem.Contrato.Repositorios;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Repositorio.Repositorios
{
    public class InOutVariosRepository : IInOutVariosRepository
    {
        public Result<InOutVarios> Add(InOutVarios entity)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("INSERT INTO InOutVarios (" +
                    "Cod_Usuario, Tipo, Detalle, Monto, Fecha) " +
                    "VALUES (@Cod_Usuario, @Tipo, @Detalle, @Monto, @Fecha)", conn);
                cmd.Parameters.AddWithValue("@Cod_Usuario", entity.Cod_Usuario);
                cmd.Parameters.AddWithValue("@Tipo", entity.Tipo);
                cmd.Parameters.AddWithValue("@Detalle", entity.Detalle);
                cmd.Parameters.AddWithValue("@Monto", entity.Monto);
                cmd.Parameters.AddWithValue("@Fecha", entity.Fecha);
                conn.Open();
                int inserts = cmd.ExecuteNonQuery();
                if (inserts > 0)
                {
                    return Result<InOutVarios>.Success(entity);
                }
                else
                {
                    return Result<InOutVarios>.Failure("No se pudo agregar el movimiento.");
                }
            }
            catch (OleDbException ex)
            {
                return Result<InOutVarios>.Failure($"Error al agregar el movimiento: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                return Result<InOutVarios>.Failure($"Error inesperado al agregar el movimiento: {ex.Message}");
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("DELETE FROM InOutVarios WHERE Id_Movimiento = @Id_Movimiento", conn);
                cmd.Parameters.AddWithValue("@Id_Movimiento", id);
                conn.Open();
                int deletes = cmd.ExecuteNonQuery();
                if (deletes > 0)
                {
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure("No se pudo eliminar el movimiento.");
                }
            }
            catch (OleDbException ex)
            {
                return Result<bool>.Failure($"Error al eliminar el movimiento: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                return Result<bool>.Failure($"Error inesperado al eliminar el movimiento: {ex.Message}");
            }
        }

        public Task<Result<List<InOutVarios>>> GetAll()
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("SELECT * FROM InOutVarios", conn);
                conn.Open();
                using OleDbDataReader reader = cmd.ExecuteReader();
                List<InOutVarios> movimientos = new List<InOutVarios>();
                while (reader.Read())
                {
                    InOutVarios movimiento = new InOutVarios
                    {
                        Id_Movimiento = reader.GetInt32(0),
                        Cod_Usuario = reader.GetInt32(1),
                        Tipo = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Detalle = reader.IsDBNull(3) ? null : reader.GetString(3),
                        Monto = reader.GetDecimal(4),
                        Fecha = reader.GetDateTime(5)
                    };
                    movimientos.Add(movimiento);
                }
                return Task.FromResult(Result<List<InOutVarios>>.Success(movimientos));
            }
            catch (OleDbException ex)
            {
                return Task.FromResult(Result<List<InOutVarios>>.Failure($"Error al obtener los movimientos: {ex.Message}"));
            }
            catch (System.Exception ex)
            {
                return Task.FromResult(Result<List<InOutVarios>>.Failure($"Error inesperado al obtener los movimientos: {ex.Message}"));
            }
        }

        public Result<InOutVarios> GetById(int id)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("SELECT * FROM InOutVarios WHERE Id_Movimiento = @Id_Movimiento", conn);
                cmd.Parameters.AddWithValue("@Id_Movimiento", id);
                conn.Open();
                using OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    InOutVarios movimiento = new InOutVarios
                    {
                        Id_Movimiento = reader.GetInt32(0),
                        Cod_Usuario = reader.GetInt32(1),
                        Tipo = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Detalle = reader.IsDBNull(3) ? null : reader.GetString(3),
                        Monto = reader.GetDecimal(4),
                        Fecha = reader.GetDateTime(5)
                    };
                    return Result<InOutVarios>.Success(movimiento);
                }
                else
                {
                    return Result<InOutVarios>.Failure("Movimiento no encontrado.");
                }
            }
            catch (OleDbException ex)
            {
                return Result<InOutVarios>.Failure($"Error al obtener el movimiento: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                return Result<InOutVarios>.Failure($"Error inesperado al obtener el movimiento: {ex.Message}");
            }
        }
        
        public Result<InOutVarios> Update(InOutVarios entity)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("UPDATE InOutVarios SET " +
                    "Cod_Usuario = @Cod_Usuario, " +
                    "Tipo = @Tipo, " +
                    "Detalle = @Detalle, " +
                    "Monto = @Monto, " +
                    "Fecha = @Fecha " +
                    "WHERE Id_Movimiento = @Id_Movimiento", conn);
                cmd.Parameters.AddWithValue("@Cod_Usuario", entity.Cod_Usuario);
                cmd.Parameters.AddWithValue("@Tipo", entity.Tipo);
                cmd.Parameters.AddWithValue("@Detalle", entity.Detalle);
                cmd.Parameters.AddWithValue("@Monto", entity.Monto);
                cmd.Parameters.AddWithValue("@Fecha", entity.Fecha);
                cmd.Parameters.AddWithValue("@Id_Movimiento", entity.Id_Movimiento);
                conn.Open();
                int updates = cmd.ExecuteNonQuery();
                if (updates > 0)
                {
                    return Result<InOutVarios>.Success(entity);
                }
                else
                {
                    return Result<InOutVarios>.Failure("No se pudo actualizar el movimiento.");
                }
            }
            catch (OleDbException ex)
            {
                return Result<InOutVarios>.Failure($"Error al actualizar el movimiento: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                return Result<InOutVarios>.Failure($"Error inesperado al actualizar el movimiento: {ex.Message}");
            }
        }
    }
}