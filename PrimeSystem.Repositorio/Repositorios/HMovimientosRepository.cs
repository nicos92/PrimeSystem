using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using PrimeSystem.Contrato.Repositorios;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class HMovimientosRepository : BaseRepositorio, IHMovimientosRepository
    {
        public Result<HMovimientos> Add(HMovimientos movimiento)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("INSERT INTO HMovimientos (Id_Usuario, Tipo_Movimiento, Reg_Antes, Reg_Despues, Fecha_Hora) VALUES (@Id_Usuario, @Tipo_Movimiento, @Reg_Antes, @Reg_Despues, @Fecha_Hora)", conn);
                cmd.Parameters.AddWithValue("@Id_Usuario", movimiento.Id_Usuario);
                cmd.Parameters.AddWithValue("@Tipo_Movimiento", movimiento.Tipo_Movimiento);
                cmd.Parameters.AddWithValue("@Reg_Antes", movimiento.Reg_Antes);
                cmd.Parameters.AddWithValue("@Reg_Despues", movimiento.Reg_Despues);
                cmd.Parameters.AddWithValue("@Fecha_Hora", movimiento.Fecha_Hora);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    return Result<HMovimientos>.Success(movimiento);
                }
                else
                {
                    return Result<HMovimientos>.Failure("No se pudo insertar el movimiento.");
                }
            }catch (OleDbException ex)
            {
                return Result<HMovimientos>.Failure($"Error al insertar el movimiento: {ex.Message}");
            }
            catch (Exception ex)
            {

                return Result<HMovimientos>.Failure($"Error inesperado al insertar el movimiento. {ex.Message}");
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using OleDbConnection connection = Conexion();
                using OleDbCommand command = new("DELETE FROM HMovimientos WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<bool>.Success(true);
                }
                return Result<bool>.Failure("No se encontró el movimiento para eliminar.");
            }
            catch (OleDbException ex)
            {
                return Result<bool>.Failure($"Error al eliminar el movimiento: {ex.Message}");
            }
            catch (Exception ex)
            {

                return Result<bool>.Failure($"Error inesperado al eliminar el movimiento: {ex.Message}");
            }
        }

        public Result<List<HMovimientos>> GetAll()
        {
            try
            {
                using OleDbConnection con = Conexion();
                using OleDbCommand cmd = new OleDbCommand("SELECT Id, Id_Usuario, Tipo_Movimiento, Reg_Antes, Reg_Despues, Fecha_Hora FROM HMovimientos", con);
                con.Open();
                using OleDbDataReader reader = cmd.ExecuteReader();
                List<HMovimientos> movimientos = new List<HMovimientos>();
                while (reader.Read())
                {
                    HMovimientos movimiento = new HMovimientos
                    {
                        Id_Historico = reader.GetInt32(0),
                        Id_Usuario = reader.GetInt32(1),
                        Tipo_Movimiento = reader.GetInt32(2),
                        Reg_Antes = reader.GetDecimal(3),
                        Reg_Despues = reader.GetDecimal(4),
                        Fecha_Hora = reader.GetDateTime(5)
                    };
                    movimientos.Add(movimiento);
                }
                return Result<List<HMovimientos>>.Success(movimientos);
            }catch (OleDbException ex)
            {
                return Result<List<HMovimientos>>.Failure($"Error al obtener los movimientos: {ex.Message}");
            }
            catch (Exception ex)
            {

                return Result<List<HMovimientos>>.Failure($"Error inesperado al obtener los movimientos: {ex.Message}");
            }
        }

        public Result<HMovimientos> GetById(int id)
        {
            try
            {
                using OleDbConnection con = Conexion();
                using OleDbCommand cmd = new OleDbCommand("SELECT Id_Historico, Id_Usuario, Tipo_Movimiento, Reg_Antes, Reg_Despues, Fecha_Hora FROM HMovimientos WHERE Id_Historico = @Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                using OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    HMovimientos movimiento = new HMovimientos
                    {
                        Id_Historico = reader.GetInt32(0),
                        Id_Usuario = reader.GetInt32(1),
                        Tipo_Movimiento = reader.GetInt32(2),
                        Reg_Antes = reader.GetDecimal(3),
                        Reg_Despues = reader.GetDecimal(4),
                        Fecha_Hora = reader.GetDateTime(5)
                    };
                    return Result<HMovimientos>.Success(movimiento);
                }
                return Result<HMovimientos>.Failure("No se encontro el movimiento");
            }catch (OleDbException ex)
            {
                return Result<HMovimientos>.Failure($"Error al obtener el movimiento por ID: {ex.Message}");
            }
            catch (Exception ex)
            {
                        
                return Result<HMovimientos>.Failure($"Error inesperado al obtener el movimiento por ID: {ex.Message}");
            }
        }

        public Result<HMovimientos> Update(HMovimientos movimiento)
        {
            try
            {
                using OleDbConnection con = Conexion();
                using OleDbCommand cmd = new OleDbCommand("UPDATE HMovimientos SET Id_Usuario = @Id_Usuario, Tipo_Movimiento = @Tipo_Movimiento, Reg_Antes = @Reg_Antes, Reg_Despues = @Reg_Despues, Fecha_Hora = @Fecha_Hora WHERE Id_Historico = @Id_Historico", con);
                cmd.Parameters.AddWithValue("@Id_Usuario", movimiento.Id_Usuario);
                cmd.Parameters.AddWithValue("@Tipo_Movimiento", movimiento.Tipo_Movimiento);
                cmd.Parameters.AddWithValue("@Reg_Antes", movimiento.Reg_Antes);
                cmd.Parameters.AddWithValue("@Reg_Despues", movimiento.Reg_Despues);
                cmd.Parameters.AddWithValue("@Fecha_Hora", movimiento.Fecha_Hora);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result >0)
                {
                    return Result<HMovimientos>.Success(movimiento);
                }
                return Result<HMovimientos>.Failure("No se encontro el movimiento");
            }catch(OleDbException ex)
            {
                return Result<HMovimientos>.Failure($"Error al actualizar el movimiento: {ex.Message}");
            }
            catch (Exception ex)
            {

                return Result<HMovimientos>.Failure($"Error inesperado al actualizar el movimiento. {ex.Message}");
            }
        }
    }
}
