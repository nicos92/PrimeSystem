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
    public class ClientesRepository : BaseRepositorio, IClientesRepository
    {
        public async Task<Result<List<Clientes>>> GetAll()
        {
            try
            {
                var clientes = new List<Clientes>();
                using (var conexion = Conexion())
                {
                    await conexion.OpenAsync();
                    using var cmd = new OleDbCommand("SELECT id_cliente, CUIT, nombre, entidad, tel, mail FROM Clientes", conexion);
                    using var reader = await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        clientes.Add(new Clientes
                        {
                            Id_Cliente = reader.GetInt32(0),
                            CUIT = reader.GetString(1),
                            Nombre = reader.GetString(2),
                            Entidad = reader.GetString(3),
                            Tel = reader.GetString(4),
                            Mail = reader.GetString(5)
                        });
                    }
                }
                return Result<List<Clientes>>.Success(clientes);
            }
            catch (Exception ex)
            {
                return Result<List<Clientes>>.Failure($"Error al obtener clientes: {ex.Message}");
            }
        }

        public Result<Clientes> GetById(int id)
        {
            try
            {
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using var cmd = new OleDbCommand("SELECT id_cliente, CUIT, nombre, entidad, tel, mail FROM Clientes WHERE Id_Cliente = ?", conexion);
                    cmd.Parameters.AddWithValue("?", id);
                    using var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        var cliente = new Clientes
                        {
                            Id_Cliente = reader.GetInt32(0),
                            CUIT = reader.GetString(1),
                            Nombre = reader.GetString(2),
                            Entidad = reader.GetString(3),
                            Tel = reader.GetString(4),
                            Mail = reader.GetString(5)
                        };
                        return Result<Clientes>.Success(cliente);
                    }
                }
                return Result<Clientes>.Failure("Cliente no encontrado");
            }
            catch (Exception ex)
            {
                return Result<Clientes>.Failure($"Error al obtener cliente: {ex.Message}");
            }
        }

        public Result<Clientes> Add(Clientes cliente)
        {
            try
            {
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using var cmd = new OleDbCommand(
                        "INSERT INTO Clientes (CUIT, Nombre, Entidad, Tel, Mail) " +
                        "VALUES (@cuit, @nombre, @entidad, @tel, @mail)", conexion);
                    cmd.Parameters.AddWithValue("@cuit", cliente.CUIT);
                    cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@entidad", cliente.Entidad);
                    cmd.Parameters.AddWithValue("@tel", cliente.Tel);
                    cmd.Parameters.AddWithValue("@mail", cliente.Mail);

                    cmd.ExecuteNonQuery();

                    // Obtener el ID del cliente insertado
                    using var cmdId = new OleDbCommand("SELECT @@IDENTITY", conexion);
                    var newId = Convert.ToInt32(cmdId.ExecuteScalar());
                    cliente.Id_Cliente = newId;
                }
                return Result<Clientes>.Success(cliente);
            }
            catch (Exception ex)
            {
                return Result<Clientes>.Failure($"Error al agregar cliente: {ex.Message}");
            }
        }

        public Result<Clientes> Update(Clientes cliente)
        {
            try
            {
                using var conexion = Conexion();
                conexion.Open();
                using var cmd = new OleDbCommand(
                    "UPDATE Clientes SET CUIT = @cuit, Nombre = @nombre, Entidad = @entidad , Tel = @tel, Mail = @mail " +
                    "WHERE Id_Cliente = @id", conexion);
                cmd.Parameters.AddWithValue("@cuit", cliente.CUIT);
                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@entidad", cliente.Entidad);
                cmd.Parameters.AddWithValue("@tel", cliente.Tel);
                cmd.Parameters.AddWithValue("@mail", cliente.Mail);
                cmd.Parameters.AddWithValue("@id", cliente.Id_Cliente);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<Clientes>.Success(cliente);
                }
                else
                {
                    return Result<Clientes>.Failure("No se encontró el cliente a actualizar");
                }
            }
            catch (Exception ex)
            {
                return Result<Clientes>.Failure($"Error al actualizar cliente: {ex.Message}");
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using var conexion = Conexion();
                conexion.Open();
                using var cmd = new OleDbCommand("DELETE FROM Clientes WHERE Id_Cliente = @id", conexion);
                cmd.Parameters.AddWithValue("@id", id);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure("No se encontró el cliente a eliminar");
                }
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Error al eliminar cliente: {ex.Message}");
            }
        }
    }
}
