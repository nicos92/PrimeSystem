using PrimeSystem.Contrato.Repositorios;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;

namespace PrimeSystem.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class ProveedoresRepository : BaseRepositorio, IProveedoresRepository 
    {
        public Result<Proveedores> Add(Proveedores Proveedor){

            try
            {
                using var conn = Conexion();
                using var cmd = new OleDbCommand("INSERT INTO Proveedores (CUIT, Proveedor, Nombre, Tel, Email) VALUES (@CUIT, @Proveedor, @Nombre, @Telefono, @Email)", conn);

                cmd.Parameters.AddWithValue("@CUIT", Proveedor.CUIT);
                cmd.Parameters.AddWithValue("@Proveedor", Proveedor.Proveedor);
                cmd.Parameters.AddWithValue("@Nombre", Proveedor.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", Proveedor.Tel);
                cmd.Parameters.AddWithValue("@Email", Proveedor.Email);
                conn.Open();
                int inserts = cmd.ExecuteNonQuery();

                if (inserts > 0)
                {
                    return Result<Proveedores>.Success(Proveedor);
                }
                else
                {
                    return Result<Proveedores>.Failure("No se pudo agregar el proveedor.");
                }
            }
            catch (OleDbException ex)
            {
                return Result<Proveedores>.Failure($"Error al agregar el proveedor: {ex.Message}");
            }catch (Exception ex)
            {
                return Result<Proveedores>.Failure($"Error inesperado: {ex.Message}");
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new OleDbCommand("DELETE FROM Proveedores WHERE Id_Proveedor = @Id_Proveedor", conn);
                cmd.Parameters.AddWithValue("@Id_Proveedor", id);
                conn.Open();
                int deletes = cmd.ExecuteNonQuery();
                if (deletes > 0)
                {
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure("No se pudo eliminar el proveedor.");
                }
            }
            catch (OleDbException ex)
            {
                return Result<bool>.Failure($"Error al eliminar el proveedor: {ex.Message}");
            }catch (Exception ex)
            {
                return Result<bool>.Failure($"Error inesperado: {ex.Message}");
            }
        }

        public async Task<Result<List<Proveedores>>> GetAll(){
            try{
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("SELECT Id_Proveedor, CUIT, Proveedor, Nombre, Tel, Email FROM Proveedores", conn);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<Proveedores> proveedores = [];
                while (await reader.ReadAsync())
                {
                    Proveedores proveedor = new()
                    {
                        Id_Proveedor = reader.GetInt32(0),
                        CUIT = reader.IsDBNull(1) ? null : reader.GetString(1),
                        Proveedor = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Nombre = reader.IsDBNull(3) ? null : reader.GetString(3),
                        Tel = reader.IsDBNull(4) ? null : reader.GetString(4),
                        Email = reader.IsDBNull(5) ? null : reader.GetString(5)
                    };
                    proveedores.Add(proveedor);
                }
                foreach (var item in proveedores)
                {
                Console.WriteLine(item.ToString());
                    
                }
                return Result<List<Proveedores>>.Success(proveedores);

            }catch (OleDbException ex)
            {
                return Result<List<Proveedores>>.Failure($"Error al obtener los proveedores: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<List<Proveedores>>.Failure($"Error inesperado: {ex.Message}");
            }
        }

        public Result<Proveedores> Update(Proveedores proveedor)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new OleDbCommand("UPDATE Proveedores SET CUIT = @CUIT, Proveedor = @Proveedor, Nombre = @Nombre, Tel = @Telefono, Email = @Email WHERE Id_Proveedor = @Id_Proveedor", conn);
                cmd.Parameters.AddWithValue("@CUIT", proveedor.CUIT);
                cmd.Parameters.AddWithValue("@Proveedor", proveedor.Proveedor);
                cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", proveedor.Tel);
                cmd.Parameters.AddWithValue("@Email", proveedor.Email);
                cmd.Parameters.AddWithValue("@Id_Proveedor", proveedor.Id_Proveedor);
                conn.Open();
                int updates = cmd.ExecuteNonQuery();

                if (updates > 0)
                {
                    return Result<Proveedores>.Success(proveedor);
                }
                else
                {
                    return Result<Proveedores>.Failure("No se pudo actualizar el proveedor.");
                }
            }
            catch (OleDbException ex)
            {
                return Result<Proveedores>.Failure($"Error al actualizar el proveedor: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<Proveedores>.Failure($"Error inesperado: {ex.Message}");
            }
        }

        public Result<Proveedores> GetById(int id)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new OleDbCommand("SELECT Id_Proveedor, CUIT, Proveedor, Nombre, Telefono, Email FROM Proveedores WHERE Id_Proveedor = @Id_Proveedor", conn);
                cmd.Parameters.AddWithValue("@Id_Proveedor", id);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Proveedores proveedor = new()
                    {
                        Id_Proveedor = reader.GetInt32(0),
                        CUIT = reader.IsDBNull(1) ? null : reader.GetString(1),
                        Proveedor = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Nombre = reader.IsDBNull(3) ? null : reader.GetString(3),
                        Tel = reader.IsDBNull(4) ? null : reader.GetString(4),
                        Email = reader.IsDBNull(5) ? null : reader.GetString(5)
                    };
                    return Result<Proveedores>.Success(proveedor);
                }
                return Result<Proveedores>.Failure("No se pudo obtener el proveedor.");
            }
            catch (OleDbException ex)
            {
                return Result<Proveedores>.Failure($"Error al obtener el proveedor: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<Proveedores>.Failure($"Error inesperado: {ex.Message}");
            }
        }
    }
}