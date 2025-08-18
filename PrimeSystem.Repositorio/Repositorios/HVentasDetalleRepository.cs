using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrimeSystem.Contrato.Repositorios;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Repositorio.Repositorios
{
    public class HVentasDetalleRepository : IHVentasDetalleRepository
    {
        public Result<HVentasDetalle> Add(HVentasDetalle hVentasDetalle)
        {
            try
            {
                using OleDbConnection conexion = Conexion();
                using OleDbCommand cmd = new OleDbCommand("INSERT INTO HVentas_Detalle (Id_Remito, Cod_Art, Descr, P_Unit, Cant, P_X_Cant) VALUES (@Id_Remito, @Cod_Art, @Descr, @P_Unit, @Cant, @P_X_Cant)", conexion);
                cmd.Parameters.AddWithValue("@Id_Remito", hVentasDetalle.Id_Remito);
                cmd.Parameters.AddWithValue("@Cod_Art", hVentasDetalle.Cod_Art);
                cmd.Parameters.AddWithValue("@Descr", hVentasDetalle.Descr);
                cmd.Parameters.AddWithValue("@P_Unit", hVentasDetalle.P_Unit);
                cmd.Parameters.AddWithValue("@Cant", hVentasDetalle.Cant);
                cmd.Parameters.AddWithValue("@P_X_Cant", hVentasDetalle.P_X_Cant);
                conexion.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado > 0)
                {
                    return Result<HVentasDetalle>.Success(hVentasDetalle);
                }
                else
                {
                    return Result<HVentasDetalle>.Failure("No se pudo agregar el detalle de la venta.");
                }
            }
            catch (OleDbException ex)
            {
                return Result<HVentasDetalle>.Failure($"Error al agregar el detalle de la venta: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                return Result<HVentasDetalle>.Failure($"Error inesperado al agregar el detalle de la venta: {ex.Message}");
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using OleDbConnection conexion = Conexion();
                using OleDbCommand cmd = new OleDbCommand("DELETE FROM HVentas_Detalle WHERE Id_Det_Remito = @Id_Det_Remito", conexion);
                cmd.Parameters.AddWithValue("@Id_Det_Remito", id);
                conexion.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado > 0)
                {
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure("No se pudo eliminar el detalle de la venta.");
                }
            }
            catch (OleDbException ex)
            {
                return Result<bool>.Failure($"Error al eliminar el detalle de la venta: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                return Result<bool>.Failure($"Error inesperado al eliminar el detalle de la venta: {ex.Message}");
            }
        }

        public async Task<Result<List<HVentasDetalle>>> GetAll()
        {
            try
            {
                using OleDbConnection conexion = Conexion();
                using OleDbCommand cmd = new OleDbCommand("SELECT * FROM HVentas_Detalle", conexion);
                conexion.Open();
                using OleDbDataReader reader = await cmd.ExecuteReaderAsync();
                List<HVentasDetalle> detalles = new List<HVentasDetalle>();
                while (await reader.ReadAsync())
                {
                    HVentasDetalle detalle = new HVentasDetalle
                    {
                        Id_Det_Remito = reader.GetInt32(0),
                        Id_Remito = reader.GetInt32(1),
                        Cod_Art = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Descr = reader.IsDBNull(3) ? null : reader.GetString(3),
                        P_Unit = reader.GetDouble(4),
                        Cant = reader.GetInt32(5),
                        P_X_Cant = reader.GetDouble(6)
                    };
                    detalles.Add(detalle);
                }
                return Result<List<HVentasDetalle>>.Success(detalles);
            }
            catch (OleDbException ex)
            {
                return Result<List<HVentasDetalle>>.Failure($"Error al obtener los detalles de la venta: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                return Result<List<HVentasDetalle>>.Failure($"Error inesperado al obtener los detalles de la venta: {ex.Message}");
            }
        }

        public Result<HVentasDetalle> GetById(int id)
        {
            try
            {
                using OleDbConnection conexion = Conexion();
                using OleDbCommand cmd = new OleDbCommand("SELECT * FROM HVentas_Detalle WHERE Id_Det_Remito = @Id_Det_Remito", conexion);
                cmd.Parameters.AddWithValue("@Id_Det_Remito", id);
                conexion.Open();
                using OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    HVentasDetalle detalle = new HVentasDetalle
                    {
                        Id_Det_Remito = reader.GetInt32(0),
                        Id_Remito = reader.GetInt32(1),
                        Cod_Art = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Descr = reader.IsDBNull(3) ? null : reader.GetString(3),
                        P_Unit = reader.GetDouble(4),
                        Cant = reader.GetInt32(5),
                        P_X_Cant = reader.GetDouble(6)
                    };
                    return Result<HVentasDetalle>.Success(detalle);
                }
                else
                {
                    return Result<HVentasDetalle>.Failure("Detalle de venta no encontrado.");
                }
            }
            catch (OleDbException ex)
            {
                return Result<HVentasDetalle>.Failure($"Error al obtener el detalle de la venta: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                return Result<HVentasDetalle>.Failure($"Error inesperado al obtener el detalle de la venta: {ex.Message}");
            }
        }

        public Result<bool> Update(HVentasDetalle hVentasDetalle)
        {
            try
            {
                using OleDbConnection conexion = Conexion();
                using OleDbCommand cmd = new OleDbCommand("UPDATE HVentas_Detalle SET Id_Remito = @Id_Remito, Cod_Art = @Cod_Art, Descr = @Descr, P_Unit = @P_Unit, Cant = @Cant, P_X_Cant = @P_X_Cant WHERE Id_Det_Remito = @Id_Det_Remito", conexion);
                cmd.Parameters.AddWithValue("@Id_Det_Remito", hVentasDetalle.Id_Det_Remito);
                cmd.Parameters.AddWithValue("@Id_Remito", hVentasDetalle.Id_Remito);
                cmd.Parameters.AddWithValue("@Cod_Art", hVentasDetalle.Cod_Art);
                cmd.Parameters.AddWithValue("@Descr", hVentasDetalle.Descr);
                cmd.Parameters.AddWithValue("@P_Unit", hVentasDetalle.P_Unit);
                cmd.Parameters.AddWithValue("@Cant", hVentasDetalle.Cant);
                cmd.Parameters.AddWithValue("@P_X_Cant", hVentasDetalle.P_X_Cant);
                conexion.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado > 0)
                {
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure("No se pudo actualizar el detalle de la venta.");
                }
            }
            catch (OleDbException ex)
            {
                return Result<bool>.Failure($"Error al actualizar el detalle de la venta: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                return Result<bool>.Failure($"Error inesperado al actualizar el detalle de la venta: {ex.Message}");
            }
        }
    }
}