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
    public class CategoriasRepository : BaseRepositorio, ICategoriasRepository
    {
        public Result<List<Categorias>> GetAll()
        {
            try
            {
                var categorias = new List<Categorias>();
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using (var cmd = new OleDbCommand("SELECT * FROM Categorias", conexion))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categorias.Add(new Categorias
                            {
                                Id_categoria = reader.GetInt32("Id_categoria"),
                                Categoria = reader.IsDBNull("Categoria") ? null : reader.GetString("Categoria")
                            });
                        }
                    }
                }
                return Result<List<Categorias>>.Success(categorias);
            }
            catch (Exception ex)
            {
                return Result<List<Categorias>>.Failure($"Error al obtener categorías: {ex.Message}");
            }
        }

        public Result<Categorias> GetById(int id)
        {
            try
            {
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using (var cmd = new OleDbCommand("SELECT * FROM Categorias WHERE Id_categoria = ?", conexion))
                    {
                        cmd.Parameters.AddWithValue("?", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var categoria = new Categorias
                                {
                                    Id_categoria = reader.GetInt32("Id_categoria"),
                                    Categoria = reader.IsDBNull("Categoria") ? null : reader.GetString("Categoria")
                                };
                                return Result<Categorias>.Success(categoria);
                            }
                        }
                    }
                }
                return Result<Categorias>.Failure("Categoría no encontrada");
            }
            catch (Exception ex)
            {
                return Result<Categorias>.Failure($"Error al obtener categoría: {ex.Message}");
            }
        }

        public Result<Categorias> Add(Categorias categoria)
        {
            try
            {
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using (var cmd = new OleDbCommand(
                        "INSERT INTO Categorias (Categoria) VALUES (?)", conexion))
                    {
                        cmd.Parameters.AddWithValue("?", categoria.Categoria);
                        cmd.ExecuteNonQuery();
                        
                        // Obtener el ID de la categoría insertada
                        using (var cmdId = new OleDbCommand("SELECT @@IDENTITY", conexion))
                        {
                            var newId = Convert.ToInt32(cmdId.ExecuteScalar());
                            categoria.Id_categoria = newId;
                        }
                    }
                }
                return Result<Categorias>.Success(categoria);
            }
            catch (Exception ex)
            {
                return Result<Categorias>.Failure($"Error al agregar categoría: {ex.Message}");
            }
        }

        public Result<Categorias> Update(Categorias categoria)
        {
            try
            {
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using (var cmd = new OleDbCommand(
                        "UPDATE Categorias SET Categoria = ? WHERE Id_categoria = ?", conexion))
                    {
                        cmd.Parameters.AddWithValue("?", categoria.Categoria);
                        cmd.Parameters.AddWithValue("?", categoria.Id_categoria);
                        
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return Result<Categorias>.Success(categoria);
                        }
                        else
                        {
                            return Result<Categorias>.Failure("No se encontró la categoría a actualizar");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Result<Categorias>.Failure($"Error al actualizar categoría: {ex.Message}");
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using (var cmd = new OleDbCommand("DELETE FROM Categorias WHERE Id_categoria = ?", conexion))
                    {
                        cmd.Parameters.AddWithValue("?", id);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        
                        if (rowsAffected > 0)
                        {
                            return Result<bool>.Success(true);
                        }
                        else
                        {
                            return Result<bool>.Failure("No se encontró la categoría a eliminar");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Error al eliminar categoría: {ex.Message}");
            }
        }
    }
}
