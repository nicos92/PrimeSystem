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
    public class SubCategoriaRepository : BaseRepositorio, ISubcategoriaRepository
    {
        public async Task<Result<List<Subcategoria>>> GetAll()
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("SELECT Id_Subcategoria, Sub_categoria, Id_Categoria FROM Subcategoria", conn);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<Subcategoria> subcategorias = new List<Subcategoria>();
                while (await reader.ReadAsync())
                {
                    Subcategoria subcategoria = new Subcategoria
                    {
                        Id_Subcategoria = reader.GetInt32(0),
                        Sub_categoria = reader.IsDBNull(1) ? null : reader.GetString(1),
                        Id_Categoria = reader.GetInt32(2)
                    };
                    subcategorias.Add(subcategoria);
                }
                return Result<List<Subcategoria>>.Success(subcategorias);
            }
            catch (OleDbException ex)
            {
                // Handle database exceptions and return an appropriate Result
                return Result<List<Subcategoria>>.Failure("Error en la base de datos al obtener las subcategorías: " + ex.Message   );
            }
            catch (Exception ex)
            {
                return Result<List<Subcategoria>>.Failure("Error al obtener las subcategorías: " + ex.Message);
            }
        }

        public Result<Subcategoria> GetById(int id)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("SELECT Id_Subcategoria, Sub_categoria, Id_Categoria FROM Subcategoria WHERE Id_Subcategoria = @Id_Subcategoria", conn);
                cmd.Parameters.AddWithValue("@Id_Subcategoria", id);
                conn.Open();
                using OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Subcategoria subcategoria = new Subcategoria
                    {
                        Id_Subcategoria = reader.GetInt32(0),
                        Sub_categoria = reader.IsDBNull(1) ? null : reader.GetString(1),
                        Id_Categoria = reader.GetInt32(2)
                    };
                    return Result<Subcategoria>.Success(subcategoria);
                }
                return Result<Subcategoria>.Failure("No se pudo encontrar la subcategoría con el ID especificado.");
            }catch(OleDbException ex)
            {
                return Result<Subcategoria>.Failure("Error en la base de datos al obtener la subcategoría: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<Subcategoria>.Failure("Error inesperado al obtener la subcategoría: " + ex.Message);
            }
        }

        public Result<Subcategoria> Add(Subcategoria subcategoria)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("INSERT INTO Subcategoria (Sub_categoria, Id_Categoria) VALUES (@Sub_categoria, @Id_Categoria)", conn);
                cmd.Parameters.AddWithValue("@Sub_categoria", subcategoria.Sub_categoria);
                cmd.Parameters.AddWithValue("@Id_Categoria", subcategoria.Id_Categoria);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<Subcategoria>.Success(subcategoria);
                }
                return Result<Subcategoria>.Failure("No se pudo agregar la subcategoría.");
            }catch (OleDbException ex)
            {
                return Result<Subcategoria>.Failure("Error en la base de datos al agregar la subcategoría: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<Subcategoria>.Failure("Error inesperado al agregar la subcategoría: " + ex.Message);
            }
            
        }

        public Result<Subcategoria> Update(Subcategoria subcategoria)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("UPDATE Subcategoria SET Sub_categoria = @Sub_categoria, Id_Categoria = @Id_Categoria WHERE Id_Subcategoria = @Id_Subcategoria", conn);
                cmd.Parameters.AddWithValue("@Sub_categoria", subcategoria.Sub_categoria);
                cmd.Parameters.AddWithValue("@Id_Categoria", subcategoria.Id_Categoria);
                cmd.Parameters.AddWithValue("@Id_Subcategoria", subcategoria.Id_Subcategoria);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<Subcategoria>.Success(subcategoria);
                }
                return Result<Subcategoria>.Failure("No se pudo actualizar la subcategoría.");
            }catch (OleDbException ex)
            {
                return Result<Subcategoria>.Failure("Error en la base de datos al actualizar la subcategoría: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<Subcategoria>.Failure("Error inesperado al actualizar la subcategoría: " + ex.Message);
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("DELETE FROM Subcategoria WHERE Id_Subcategoria = @Id_Subcategoria", conn);
                cmd.Parameters.AddWithValue("@Id_Subcategoria", id);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<bool>.Success(true);
                }
                return Result<bool>.Failure("No se pudo eliminar la subcategoría.");
            }catch (OleDbException ex)
            {
                return Result<bool>.Failure("Error en la base de datos al eliminar la subcategoría: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<bool>.Failure("Error inesperado al eliminar la subcategoría: " + ex.Message);
            }
        }

        public async Task<Result<List<Subcategoria>>> GetAllxCategoria(int idcategoria)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("SELECT Id_Subcategoria, Sub_categoria, Id_Categoria FROM Subcategoria WHERE Id_Categoria = @Id_Categoria", conn);
                cmd.Parameters.AddWithValue("@Id_Categoria", idcategoria);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<Subcategoria> subcategorias = new List<Subcategoria>();
                while (await reader.ReadAsync())
                {
                    Subcategoria subcategoria = new Subcategoria
                    {
                        Id_Subcategoria = reader.GetInt32(0),
                        Sub_categoria = reader.IsDBNull(1) ? null : reader.GetString(1),
                        Id_Categoria = reader.GetInt32(2)
                    };
                    subcategorias.Add(subcategoria);
                }
                return Result<List<Subcategoria>>.Success(subcategorias);
            }
            catch (OleDbException ex)
            {
                // Handle database exceptions and return an appropriate Result
                return Result<List<Subcategoria>>.Failure("Error en la base de datos al obtener las subcategorías: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<List<Subcategoria>>.Failure("Error al obtener las subcategorías: " + ex.Message);
            }
        }
    }
    
}