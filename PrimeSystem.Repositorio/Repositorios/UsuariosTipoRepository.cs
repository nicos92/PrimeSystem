using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using PrimeSystem.Contrato.Repositorios;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class UsuariosTipoRepository : BaseRepositorio, IUsuariosTipoRepository
    {
        public Result<UsuariosTipo> Add(UsuariosTipo tipo)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("INSERT INTO Usuarios_Tipo (Tipo, Descripcion) VALUES (@Tipo, @Descripcion)", conn);
                cmd.Parameters.AddWithValue("@Tipo", tipo.Tipo);
                cmd.Parameters.AddWithValue("@Descripcion", tipo.Descripcion ?? (object)DBNull.Value);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0 ? Result<UsuariosTipo>.Success(tipo) : Result<UsuariosTipo>.Failure("Error al agregar el tipo de usuario.");
            }
            catch (OleDbException ex)
            {
                return Result<UsuariosTipo>.Failure($"Error de base de datos al insertar el tipo de usuario: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<UsuariosTipo>.Failure($"Error inesperado al insertar el tipo de usuario: {ex.Message}");
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

        public async Task<Result<List<UsuariosTipo>>> GetAll()
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("SELECT Id_Usuario_Tipo, Tipo, Descripcion FROM Usuarios_Tipo", conn);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<UsuariosTipo> tipos = new List<UsuariosTipo>();
                while (await reader.ReadAsync())
                {
                    tipos.Add(new UsuariosTipo
                    {
                        Id_Usuario_Tipo = reader.GetInt32(0),
                        Tipo = reader.GetInt32(1),
                        Descripcion = reader.IsDBNull(2) ? null : reader.GetString(2)
                    });
                }
                return Result<List<UsuariosTipo>>.Success(tipos);
            }
            catch (OleDbException ex)
            {
                return Result<List<UsuariosTipo>>.Failure($"Error de base de datos al obtener los tipos de usuario: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<List<UsuariosTipo>>.Failure($"Error inesperado al obtener los tipos de usuario: {ex.Message}");
            }

        }

        public Result<UsuariosTipo> GetById(int id)
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
                    return Result<UsuariosTipo>.Success(new UsuariosTipo
                    {
                        Id_Usuario_Tipo = reader.GetInt32(0),
                        Tipo = reader.GetInt32(1),
                        Descripcion = reader.IsDBNull(2) ? null : reader.GetString(2)
                    });
                }
                return Result<UsuariosTipo>.Failure("Tipo de usuario no encontrado.");
            }
            catch (OleDbException ex)
            {
                return Result<UsuariosTipo>.Failure($"Error de base de datos al obtener el tipo de usuario: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<UsuariosTipo>.Failure($"Error inesperado al obtener el tipo de usuario: {ex.Message}");
            }
        }
        
        public Result<UsuariosTipo> Update(UsuariosTipo tipo)
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
                return result > 0 ? Result<UsuariosTipo>.Success(tipo) : Result<UsuariosTipo>.Failure("Error al actualizar el tipo de usuario.");
            }
            catch (OleDbException ex)
            {
                return Result<UsuariosTipo>.Failure($"Error de base de datos al actualizar el tipo de usuario: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<UsuariosTipo>.Failure($"Error inesperado al actualizar el tipo de usuario: {ex.Message}");
            }
        }

    
    }
}