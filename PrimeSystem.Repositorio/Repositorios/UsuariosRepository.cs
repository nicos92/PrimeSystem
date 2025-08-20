using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Repositorio.Repositorios
{
    public class UsuariosRepository : BaseRepositorio, IUsuariosRepository
    {
        public async Task<Result<List<Usuarios>>> GetAll()
        {
            try
            {
                using OleDbConnectio conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("SELECT Id_Usuario, DNI, Nombre, Apellido, Tel, Mail, Id_Tipo FROM Usuarios", conn);
                await conn.OpenAsync();
                using OleDbDataReader reader = await cmd.ExecuteReaderAsync();
                List<Usuarios> usuarios = new List<Usuarios>();
                while (await reader.ReadAsync())
                {
                    Usuarios usuario = new Usuarios
                    {
                        Id_Usuario = reader.GetInt32(0),
                        DNI = reader.IsDBNull(1) ? null : reader.GetString(1),
                        Nombre = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Apellido = reader.IsDBNull(3) ? null : reader.GetString(3),
                        Tel = reader.IsDBNull(4) ? null : reader.GetString(4),
                        Mail = reader.IsDBNull(5) ? null : reader.GetString(5),
                        Id_Tipo = reader.GetInt32(6)
                    };
                    usuarios.Add(usuario);
                }
                return new Result<List<Usuarios>>(usuarios);
            }
            catch (OleDbException ex)
            {
                return Result<List<Usuarios>>.Failure("Error en la base de datos al obtener los usuarios: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<List<Usuarios>>.Failure("Error inesperado al obtener los usuarios: " + ex.Message);
            }
        }

        public Result<Usuarios> GetById(int id)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("SELECT Id_Usuario, DNI, Nombre, Apellido, Tel, Mail, Id_Tipo FROM Usuarios WHERE Id_Usuario = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                using OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Usuarios usuario = new Usuarios
                    {
                        Id_Usuario = reader.GetInt32(0),
                        DNI = reader.IsDBNull(1) ? null : reader.GetString(1),
                        Nombre = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Apellido = reader.IsDBNull(3) ? null : reader.GetString(3),
                        Tel = reader.IsDBNull(4) ? null : reader.GetString(4),
                        Mail = reader.IsDBNull(5) ? null : reader.GetString(5),
                        Id_Tipo = reader.GetInt32(6)
                    };
                    return new Result<Usuarios>(usuario);
                }
                return Result<Usuarios>.Failure("Usuario no encontrado");
            }
            catch (OleDbException ex)
            {
                return Result<Usuarios>.Failure("Error en la base de datos al obtener el usuario: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<Usuarios>.Failure("Error inesperado al obtener el usuario: " + ex.Message);
            }
        }

        public Result<Usuarios> Add(Usuarios usuario)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("INSERT INTO Usuarios (DNI, Nombre, Apellido, Tel, Mail, Id_Tipo) VALUES (@DNI, @Nombre, @Apellido, @Tel, @Mail, @Id_Tipo)", conn);
                cmd.Parameters.AddWithValue("@DNI", usuario.DNI ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Tel", usuario.Tel ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Mail", usuario.Mail ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Id_Tipo", usuario.Id_Tipo);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return new Result<Usuarios>(usuario);
                }
                return Result<Usuarios>.Failure("No se pudo agregar el usuario");
            }
            catch (OleDbException ex)
            {
                return Result<Usuarios>.Failure("Error en la base de datos al agregar el usuario: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<Usuarios>.Failure("Error inesperado al agregar el usuario: " + ex.Message);
            }
        }

        public Result<Usuarios> Update(Usuarios usuario)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("UPDATE Usuarios SET DNI = @DNI, Nombre = @Nombre, Apellido = @Apellido, Tel = @Tel, Mail = @Mail, Id_Tipo = @Id_Tipo WHERE Id_Usuario = @Id", conn);
                cmd.Parameters.AddWithValue("@DNI", usuario.DNI ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Tel", usuario.Tel ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Mail", usuario.Mail ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Id_Tipo", usuario.Id_Tipo);
                cmd.Parameters.AddWithValue("@Id", usuario.Id_Usuario);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return new Result<Usuarios>(usuario);
                }
                return Result<Usuarios>.Failure("No se pudo actualizar el usuario");
            }
            catch (OleDbException ex)
            {
                return Result<Usuarios>.Failure("Error en la base de datos al actualizar el usuario: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<Usuarios>.Failure("Error inesperado al actualizar el usuario: " + ex.Message);
            }
        }
        
        public Result<bool> Delete(int id)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("DELETE FROM Usuarios WHERE Id_Usuario = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return new Result<bool>(true);
                }
                return Result<bool>.Failure("No se pudo eliminar el usuario");
            }
            catch (OleDbException ex)
            {
                return Result<bool>.Failure("Error en la base de datos al eliminar el usuario: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<bool>.Failure("Error inesperado al eliminar el usuario: " + ex.Message);
            }
        }
    }
}