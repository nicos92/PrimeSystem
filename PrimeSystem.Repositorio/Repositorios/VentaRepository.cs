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
                OleDbConnection conn = Conexion();
                await conn.OpenAsync();

                transaction = conn.BeginTransaction();


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
                    transaction.Rollback();
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
                }
               

                transaction.Commit();
                return Result<bool>.Success(true);
            }
            catch (OleDbException ex)
            {
                transaction?.Rollback();
                return Result<bool>.Failure($"Error OleDb al insertar la venta y los detalles: {ex.Message}");
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                return Result<bool>.Failure($"Error inesperado al insertar la venta y los detalles: {ex.Message}");
            }
        }

        public Task<Result<(List<HVentas> ventas, List<HVentasDetalle> detalles)>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
