using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using PrimeSystem.Contrato.Repositorios;
using PrimeSystem.Modelo;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class VentaRepository : BaseRepositorio, IVentaRepository
    {
        public async Task<Result<bool>> Add(HVentas hVentas, List<ProductoResumen> productoResumen)
        {
            OleDbTransaction? transaction = null;
            try
            {
                using OleDbConnection conn = Conexion();
                await conn.OpenAsync();

                 transaction = (OleDbTransaction)  await conn.BeginTransactionAsync(); 


                string sqlArticulos = "INSERT INTO H_Ventas (Cod_Usuario, fecha_hora, id_cliente, subtotal, descu, total) VALUES (?, ?, ?, ?, ?, ?)";
                using (OleDbCommand cmdArticulos = new(sqlArticulos, conn, transaction)) 
                {

                    cmdArticulos.Parameters.AddWithValue("?", hVentas.Cod_Usuario);
                    cmdArticulos.Parameters.AddWithValue("?", DateTime.Now);
                    cmdArticulos.Parameters.AddWithValue("?", hVentas.Id_Cliente);
                    cmdArticulos.Parameters.AddWithValue("?", hVentas.Subtotal);
                    cmdArticulos.Parameters.AddWithValue("?", hVentas.Descu);
                    cmdArticulos.Parameters.AddWithValue("?", hVentas.Total);

                    await cmdArticulos.ExecuteNonQueryAsync();
                }
                string select = "SELECT MAX(id_remito) FROM H_Ventas";
                using OleDbCommand oleDbCommand = new(select, conn, transaction);
                using DbDataReader reader = await oleDbCommand.ExecuteReaderAsync();
                int id_remito = 0;
                if (await reader.ReadAsync())
                {
                    id_remito = reader.GetInt32(0);
                }

                if (id_remito == 0)
                {
                    await transaction.RollbackAsync();
                    return Result<bool>.Failure("No se pudo obtener el número de remito");
                }

                foreach (var item in productoResumen)
                {
                    string sqlStock = "INSERT INTO H_Ventas_Detalle (id_remito, cod_art, descr, p_unit, cant, p_x_cant) VALUES (?, ?, ?, ?, ?, ?)";
                    using OleDbCommand cmdStock = new(sqlStock, conn, transaction);

                    cmdStock.Parameters.AddWithValue("?", id_remito);
                    cmdStock.Parameters.AddWithValue("?", item.Cod_Articulo);
                    cmdStock.Parameters.AddWithValue("?", item.Producto_Nombre);
                    cmdStock.Parameters.AddWithValue("?", item.Producto_Precio);
                    cmdStock.Parameters.AddWithValue("?", item.Producto_Cantidad);
                    cmdStock.Parameters.AddWithValue("?", item.Producto_PrecioxCantidad);

                    await cmdStock.ExecuteNonQueryAsync();

                    string cmdARt = "UPDATE Stock SET cantidad = cantidad - ? WHERE cod_articulo = ?";
                    using OleDbCommand oleDbCommand1 = new(cmdARt, conn, transaction);
                    oleDbCommand1.Parameters.AddWithValue("?", item.Producto_Cantidad);
                    oleDbCommand1.Parameters.AddWithValue("?", item.Cod_Articulo);
                    await oleDbCommand1.ExecuteNonQueryAsync();
                }
               

                await transaction.CommitAsync();
                return Result<bool>.Success(true);
            }
            catch (OleDbException ex)
            {
                if (transaction != null)
                    await transaction.RollbackAsync(); 
                return Result<bool>.Failure($"Error OleDb al insertar la venta y los detalles: {ex.Message}");
            }
            catch (Exception ex)
            {
                if (transaction != null)
                    await transaction.RollbackAsync();
                return Result<bool>.Failure($"Error inesperado al insertar la venta y los detalles: {ex.Message}");
            }
        }

        public async Task<Result<(List<HVentas> ventas, List<HVentasDetalle> detalles)>> GetAll()
        {
            try
            {
                using OleDbConnection conn = Conexion();
                await conn.OpenAsync();

                List<HVentas> ventas = [];
                List<HVentasDetalle> detalles = [];

                // Query para obtener todas las ventas (H_Ventas)
                string sqlVentas = "SELECT id_remito, Cod_Usuario, fecha_hora, id_cliente, subtotal, descu, total FROM H_Ventas";
                using (OleDbCommand cmdVentas = new(sqlVentas, conn))
                {
                    using DbDataReader reader = await cmdVentas.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        ventas.Add(new HVentas
                        {
                            Id_Remito = reader.GetInt32(0),
                            Cod_Usuario = reader.GetInt32(1),
                            Fecha_Hora = reader.GetDateTime(2),
                            Id_Cliente = reader.GetInt32(3),
                            Subtotal = reader.GetDouble(4),
                            Descu = reader.GetDouble(5),
                            Total = reader.GetDouble(6)
                        });
                    }
                }

                // Query para obtener todos los detalles de las ventas (H_Ventas_Detalle)
                string sqlDetalles = "SELECT id_det_remito, id_remito, cod_art, descr, p_unit, cant, p_x_cant FROM H_Ventas_Detalle";
                using (OleDbCommand cmdDetalles = new(sqlDetalles, conn))
                {
                    using DbDataReader reader = await cmdDetalles.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        detalles.Add(new HVentasDetalle
                        {
                            Id_Det_Remito = reader.GetInt32(0),
                            Id_Remito = reader.GetInt32(1),
                            Cod_Art = reader.GetString(2),
                            Descr = reader.GetString(3),
                            P_Unit = reader.GetDouble(4),
                            Cant = reader.GetInt32(5),
                            P_X_Cant = reader.GetDouble(6),
                            
                        });
                    }
                }

                return Result<(List<HVentas> ventas, List<HVentasDetalle> detalles)>.Success((ventas, detalles));
            }
            catch (OleDbException ex)
            {
                return Result<(List<HVentas> ventas, List<HVentasDetalle> detalles)>.Failure($"Error OleDb al obtener las ventas: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<(List<HVentas> ventas, List<HVentasDetalle> detalles)>.Failure($"Error inesperado al obtener las ventas: {ex.Message}");
            }
        }
    }
}
