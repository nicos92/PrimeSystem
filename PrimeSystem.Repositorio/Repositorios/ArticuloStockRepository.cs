using PrimeSystem.Contrato.Repositorios;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSystem.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class ArticuloStockRepository : BaseRepositorio, IArticuloStockRepository
    {
        public async Task<Result<bool>> Add(Articulos articulo, Stock stock)
        {

            OleDbTransaction? transaction = null;
            try
            {
                OleDbConnection conn = Conexion();
                await conn.OpenAsync();
              
                 transaction = conn.BeginTransaction();

         
                string sqlArticulos = "INSERT INTO Articulos (Cod_Articulo, Art_Desc, Cod_Categoria, Cod_Subcat, Id_Proveedor) VALUES (?, ?, ?, ?, ?)";
                using (OleDbCommand cmdArticulos = new OleDbCommand(sqlArticulos, conn, transaction))
                {
                  
                    cmdArticulos.Parameters.AddWithValue("?", articulo.Cod_Articulo);
                    cmdArticulos.Parameters.AddWithValue("?", articulo.Art_Desc);
                    cmdArticulos.Parameters.AddWithValue("?", articulo.Cod_Categoria);
                    cmdArticulos.Parameters.AddWithValue("?", articulo.Cod_Subcat);
                    cmdArticulos.Parameters.AddWithValue("?", articulo.Id_Proveedor);
                    await cmdArticulos.ExecuteNonQueryAsync();
                }

             
                string sqlStock = "INSERT INTO Stock (Cod_Articulo, Cantidad, Costo, Ganancia) VALUES (?, ?, ?, ?)";
                using (OleDbCommand cmdStock = new OleDbCommand(sqlStock, conn, transaction))
                {
                   
                    cmdStock.Parameters.AddWithValue("?", stock.Cod_Articulo);
                    cmdStock.Parameters.AddWithValue("?", stock.Cantidad);
                    cmdStock.Parameters.AddWithValue("?", stock.Costo);
                    cmdStock.Parameters.AddWithValue("?", stock.Ganancia);
                    await cmdStock.ExecuteNonQueryAsync();
                }

                transaction.Commit();
                return Result<bool>.Success(true); 
            }catch(OleDbException ex)
            {
                transaction?.Rollback();
                return Result<bool>.Failure($"Error OleDb al insertar los articulos y los stocks: {ex.Message}");
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                return Result<bool>.Failure($"Error inesperado al insertar los articulos y los stocks: {ex.Message}"); 
            }
        }

        public Task<Result<bool>> Delete(Articulos articulo, Stock stock)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<(List<Articulos> articulos, List<Stock> stock)>> GetAll()
        {
            var listaArticulos = new List<Articulos>();
            var listaStock = new List<Stock>();

            using (OleDbConnection conn = Conexion())
            {
                try
                {
                    await conn.OpenAsync();

                    // 1. Obtener datos de la tabla Articulos
                    string sqlArticulos = "SELECT Id_Articulo, Cod_Articulo, Art_Desc, Cod_Categoria, Cod_Subcat, Id_Proveedor FROM Articulos";
                    using (OleDbCommand cmdArticulos = new OleDbCommand(sqlArticulos, conn))
                    {
                        using (DbDataReader reader = await cmdArticulos.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var articulo = new Articulos
                                {
                                    Id_Articulo = reader.GetInt32(0),
                                    Cod_Articulo = reader.GetString(1),
                                    Art_Desc = reader.GetString(2),
                                    Cod_Categoria = reader.GetInt32(3),
                                    Cod_Subcat = reader.GetInt32(4),
                                    Id_Proveedor = reader.GetInt32(5)
                                };
                                listaArticulos.Add(articulo);
                            }
                        }
                    }

                    // 2. Obtener datos de la tabla Stock
                    string sqlStock = "SELECT Cod_Articulo, Cantidad, Costo, Ganancia FROM Stock";
                    using OleDbCommand cmdStock = new OleDbCommand(sqlStock, conn);
                    using (DbDataReader reader = await cmdStock.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var stock = new Stock
                            {
                                Cod_Articulo = reader.GetString(0),
                                Cantidad = reader.GetDouble(1),
                                Costo = reader.GetDouble(2),
                                Ganancia = reader.GetDouble(3)
                            };
                            listaStock.Add(stock);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado al obtener datos: {ex.Message}");
                   
                    return Result<(List<Articulos> articulos, List<Stock> stock)>.Failure("No se pudieron obtener las listas");
                }
            }

           
            return Result<(List<Articulos> articulos, List<Stock> stock)>.Success((listaArticulos, listaStock));
        }

        public Task<Result<bool>> Update(Articulos articulos, Stock stock)
        {
            throw new NotImplementedException();
        }
    }
}
