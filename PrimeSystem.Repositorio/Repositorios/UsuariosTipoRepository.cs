using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrimeSystem.Contrato.Repositorios;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Repositorio.Repositorios
{
    public class UsuariosTipoRepository : BaseRepositorio, IUsuariosRepository
    {
        public Result<Usuarios_Tipo> Add(Usuarios_Tipo tipo)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("INSERT INTO Usuarios_Tipo (Tipo, Descripcion) VALUES (@Tipo, @Descripcion)", conn);
                cmd.Parameters.AddWithValue("@Tipo", tipo.Tipo);
                cmd.Parameters.AddWithValue("@Descripcion", tipo.Descripcion ?? (object)DBNull.Value);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0 ? Result<Usuarios_Tipo>.Success(tipo) : Result<Usuarios_Tipo>.Failure("Error al agregar el tipo de usuario.");
            }
            catch (OleDbException ex)
            {
                return Result<Usuarios_Tipo>.Failure($"Error de base de datos al insertar el tipo de usuario: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<Usuarios_Tipo>.Failure($"Error inesperado al insertar el tipo de usuario: {ex.Message}");
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("DELETE FROM Usuarios_Tipo WHERE Id_Usuario_Tipo = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0 ? Result<bool>.Success(true) : Result<bool>.Failure("Error al eliminar el tipo de usuario.");
            }
            catch (OleDbException ex)
            {
                return Result<bool>.Failure($"Error de base de datos al eliminar el tipo de usuario: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Error inesperado al eliminar el tipo de usuario: {ex.Message}");
            }
        }

        public async Task<Result<List<Usuarios_Tipo>>> GetAll()
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("SELECT Id_Usuario_Tipo, Tipo, Descripcion FROM Usuarios_Tipo", conn);
                await conn.OpenAsync();
                using OleDbDataReader reader = await cmd.ExecuteReaderasync();
                List<Usuarios_Tipo> tipos = new List<Usuarios_Tipo>();
                while (await reader.ReadAsync())
                {
                    tipos.Add(new Usuarios_Tipo
                    {
                        Id_Usuario_Tipo = reader.GetInt32(0),
                        Tipo = reader.GetInt32(1),
                        Descripcion = reader.IsDBNull(2) ? null : reader.GetString(2)
                    });
                }
                return Result<List<Usuarios_Tipo>>.Success(tipos);
            }
            catch (OleDbException ex)
            {
                return Result<List<Usuarios_Tipo>>.Failure($"Error de base de datos al obtener los tipos de usuario: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<List<Usuarios_Tipo>>.Failure($"Error inesperado al obtener los tipos de usuario: {ex.Message}");
            }

        }

        public Result<Usuarios_Tipo> GetById(int id)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("SELECT Id_Usuario_Tipo, Tipo, Descripcion FROM Usuarios_Tipo WHERE Id_Usuario_Tipo = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                using OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return Result<Usuarios_Tipo>.Success(new Usuarios_Tipo
                    {
                        Id_Usuario_Tipo = reader.GetInt32(0),
                        Tipo = reader.GetInt32(1),
                        Descripcion = reader.IsDBNull(2) ? null : reader.GetString(2)
                    });
                }
                return Result<Usuarios_Tipo>.Failure("Tipo de usuario no encontrado.");
            }
            catch (OleDbException ex)
            {
                return Result<Usuarios_Tipo>.Failure($"Error de base de datos al obtener el tipo de usuario: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<Usuarios_Tipo>.Failure($"Error inesperado al obtener el tipo de usuario: {ex.Message}");
            }
        }
        
        public Result<Usuarios_Tipo> Update(Usuarios_Tipo tipo)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("UPDATE Usuarios_Tipo SET Tipo = @Tipo, Descripcion = @Descripcion WHERE Id_Usuario_Tipo = @Id", conn);
                cmd.Parameters.AddWithValue("@Tipo", tipo.Tipo);
                cmd.Parameters.AddWithValue("@Descripcion", tipo.Descripcion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Id", tipo.Id_Usuario_Tipo);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0 ? Result<Usuarios_Tipo>.Success(tipo) : Result<Usuarios_Tipo>.Failure("Error al actualizar el tipo de usuario.");
            }
            catch (OleDbException ex)
            {
                return Result<Usuarios_Tipo>.Failure($"Error de base de datos al actualizar el tipo de usuario: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<Usuarios_Tipo>.Failure($"Error inesperado al actualizar el tipo de usuario: {ex.Message}");
            }
        }
    }
}