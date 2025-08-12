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
    public class ArticulosRepository : BaseRepositorio, IArticulosRepository
    {
        public Result<Articulos> Add(Articulos articulo)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new OleDbCommand("INSERT INTO Articulos (Cod_Articulo, Art_Desc, Cod_Categoria, Cod_Subcat, Id_Proveedor) VALUES (@Cod_Articulo, @Art_Desc, @Cod_Categoria, @Cod_Subcat, @Id_Proveedor)", conn);

                cmd.Parameters.AddWithValue("@Cod_Articulo", articulo.Cod_Articulo);
                cmd.Parameters.AddWithValue("@Art_Desc", articulo.Art_Desc);
                cmd.Parameters.AddWithValue("@Cod_Categoria", articulo.Cod_Categoria);
                cmd.Parameters.AddWithValue("@Cod_Subcat", articulo.Cod_Subcat);
                cmd.Parameters.AddWithValue("@Id_Proveedor", articulo.Id_Proveedor);
                conn.Open();
                int inserts = cmd.ExecuteNonQuery();

                if (inserts > 0)
                {
                    return Result<Articulos>.Success(articulo);
                }
                else
                {
                    return Result<Articulos>.Failure("No se pudo agregar el artículo.");
                }
            }
            catch (OleDbException ex)
            {

                return Result<Articulos>.Failure($"Error al agregar el artículo: {ex.Message}");
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new OleDbCommand("DELETE FROM Articulos WHERE Id_Articulo = @Id_Articulo", conn);
                cmd.Parameters.AddWithValue("@Id_Articulo", id);
                conn.Open();
                int deletes = cmd.ExecuteNonQuery();
                if (deletes > 0)
                {
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure("No se pudo eliminar el artículo.");
                }
            }
            catch (OleDbException ex)
            {

                return Result<bool>.Failure($"Error al eliminar el araticulo: \n {ex.Message}");
            }
        }

        public Result<List<Articulos>> GetAll()
        {
            try
            {
                List<Articulos> articulos = new List<Articulos>();
                using var conn = Conexion();
                using var cmd = new OleDbCommand("SELECT Id_Articulo, Cod_Articulo, Art_Desc, Cod_Categoria, Cod_Subcat, Id_Proveedor FROM Articulos", conn);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Articulos articulo = new Articulos
                    {
                        Id_Articulo = reader.GetInt32(0),
                        Cod_Articulo = reader.GetInt32(1),
                        Art_Desc = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Cod_Categoria = reader.GetInt32(3),
                        Cod_Subcat = reader.GetInt32(4),
                        Id_Proveedor = reader.GetInt32(5)
                    };
                    articulos.Add(articulo);
                }
                return Result<List<Articulos>>.Success(articulos);
            }
            catch (OleDbException ex)
            {

                return Result<List<Articulos>>.Failure($"Error al obtener los artículos: {ex.Message}");
            }
        }

        public Result<Articulos> GetById(int id)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new OleDbCommand("SELECT Id_Articulo, Cod_Articulo, Art_Desc, Cod_Categoria, Cod_Subcat, Id_Proveedor FROM Articulos WHERE Id_Articulo = @Id_Articulo", conn);
                cmd.Parameters.AddWithValue("@Id_Articulo", id);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Articulos articulo = new Articulos
                    {
                        Id_Articulo = (int)reader.GetInt32(0),
                        Cod_Articulo = reader.GetInt32(1),
                        Art_Desc = reader.GetString(2),
                        Cod_Categoria = reader.GetInt32(3),
                        Cod_Subcat = reader.GetInt32(4),
                        Id_Proveedor = reader.GetInt32(5)

                    };
                    return Result<Articulos>.Success(articulo);
                }
                return Result<Articulos>.Failure($"No se pude obtener el articulo");
            }
            catch (OleDbException ex)
            {

                return Result<Articulos>.Failure($"Error al obtener articulo: {ex.Message}");
            }
        }

        public Result<Articulos> Update(Articulos articulo)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new OleDbCommand("UPDATE articulos set Cod_Articulo=@Cod_Articulo, Art_Desc=@Art_Desc, Cod_Categoria=@Cod_Categoria, Cod_Subcat=@Cod_Sucat, Id_Proveedor = @Id_Proveedor WHERE Id_Articulo = @Id_Articulo", conn);
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return Result<Articulos>.Success(articulo);
                }
                return Result<Articulos>.Failure($"No se actualizo el articulo");
            }
            catch (OleDbException ex)
            {

                return Result<Articulos>.Failure($"Error al actualizar el articulo: \n {ex.Message}");
            }
        }
    }
}
