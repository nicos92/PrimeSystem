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
    public class StockRepository : BaseRepositorio, IStockRepository
    {
        public Result<Stock> Add(Stock stock)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("INSERT INTO Stock (Cod_Articulo, Cantidad, Costo, Ganancia) VALUES (@Cod_Articulo, @Cantidad, @Costo, @Ganancia)", conn);
                cmd.Parameters.AddWithValue("@Cod_Articulo", stock.Cod_Articulo);
                cmd.Parameters.AddWithValue("@Cantidad", stock.Cantidad);
                cmd.Parameters.AddWithValue("@Costo", stock.Costo);
                cmd.Parameters.AddWithValue("@Ganancia", stock.Ganancia);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<Stock>.Success(stock);
                }
                else
                {
                    return Result<Stock>.Failure("No se pudo agregar el stock.");
                }
            }
            catch (OleDbException ex)
            {
                return Result<Stock>.Failure($"Error de base de datos al hacer el ingreso: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<Stock>.Failure($"Error inesperado: {ex.Message}");
            }

        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("DELETE FROM Stock WHERE Cod_Articulo = @Cod_Articulo", conn);
                cmd.Parameters.AddWithValue("@Cod_Articulo", id);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure("No se encontró el stock para eliminar.");
                }
            }
            catch (OleDbException ex)
            {
                return Result<bool>.Failure($"Error de base de datos al eliminar: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Error inesperado: {ex.Message}");
            }
        }

        public async Task<Result<List<Stock>>> GetAll()
        {
            try
            {
                List<Stock> stocks = [];
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("SELECT Cod_Articulo, Cantidad, Costo, Ganancia FROM Stock", conn);
                await conn.OpenAsync();
                using  DbDataReader reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    Stock stock = new()
                    {
                        Cod_Articulo = reader.GetString(0),
                        Cantidad = reader.GetDouble(1),
                        Costo = reader.GetDouble(2),
                        Ganancia = reader.GetDouble(3)

                    };
                    stocks.Add(stock);
                }
                return Result<List<Stock>>.Success(stocks);
            }
            catch (OleDbException ex)
            {
                return Result<List<Stock>>.Failure($"Error de base de datos al obtener los stocks: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<List<Stock>>.Failure($"Error inesperado: {ex.Message}");
            }
        }

        public Result<Stock> GetById(int id)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("SELECT Cod_Articulo, Cantidad, Costo, Ganancia FROM Stock WHERE Cod_Articulo = @Cod_Articulo", conn);
                cmd.Parameters.AddWithValue("@Cod_Articulo", id);
                conn.Open();
                using OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Stock stock = new()
                    {
                        Cod_Articulo = reader.GetString(0),
                        Cantidad = reader.GetDouble(1),
                        Costo = reader.GetDouble(2),
                        Ganancia = reader.GetDouble(3)
                    };
                    return Result<Stock>.Success(stock);
                }
                else
                {
                    return Result<Stock>.Failure("No se encontró el stock.");
                }
            }
            catch (OleDbException ex)
            {
                return Result<Stock>.Failure($"Error de base de datos al obtener el stock: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<Stock>.Failure($"Error inesperado: {ex.Message}");
            }
        }
        
        public Result<Stock> Update(Stock stock)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("UPDATE Stock SET Cantidad = @Cantidad, Costo = @Costo, Ganancia = @Ganancia WHERE Cod_Articulo = @Cod_Articulo", conn);
                cmd.Parameters.AddWithValue("@Cantidad", stock.Cantidad);
                cmd.Parameters.AddWithValue("@Costo", stock.Costo);
                cmd.Parameters.AddWithValue("@Ganancia", stock.Ganancia);
                cmd.Parameters.AddWithValue("@Cod_Articulo", stock.Cod_Articulo);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<Stock>.Success(stock);
                }
                else
                {
                    return Result<Stock>.Failure("No se encontró el stock para actualizar.");
                }
            }
            catch (OleDbException ex)
            {
                return Result<Stock>.Failure($"Error de base de datos al actualizar: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<Stock>.Failure($"Error inesperado: {ex.Message}");
            }
        }
    }
}