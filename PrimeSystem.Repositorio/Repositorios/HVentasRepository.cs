using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Runtime.Versioning;
using System.Text;
using PrimeSystem.Contrato.Repositorios;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class HVentasRepository : BaseRepositorio, IHVentasRepository
    {
        public Result<HVentas> Add(HVentas venta)
        {
            throw new NotImplementedException();
        }

        public Result<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Result<List<HVentas>> GetAll()
        {
            try
            {
                var ventas = new List<HVentas>();
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using var cmd = new OleDbCommand("SELECT Id_Remito,Cod_Usuario,Id_Cliente,Subtotal,Descu,Total, fecha_hora FROM H_Ventas", conexion);
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ventas.Add(new HVentas
                        {
                            Id_Remito = reader.GetInt32(0),
                            Cod_Usuario = reader.GetInt32(1),
                            Id_Cliente = reader.GetInt32(2),
                            Subtotal = reader.GetDecimal(3),
                            Descu = reader.GetDecimal(4),
                            Total = reader.GetDecimal(5),
                            Fecha_Hora = reader.GetDateTime(6)
                        });
                    }
                }
                return Result<List<HVentas>>.Success(ventas);
            }
            catch (OleDbException ex)
            {
                return Result<List<HVentas>>.Failure($"Error al obtener ventas: {ex.Message}");
            }
        }

        public Result<HVentas> GetById(int id)
        {
            try
            {
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using var cmd = new OleDbCommand("SELECT Id_Remito,Cod_Usuario,Fecha_Hora,Id_Cliente,Subtotal,Descu,Total FROM H_Ventas WHERE Id_Remito = @id", conexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    using var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        var venta = new HVentas
                        {
                            Id_Remito = reader.GetInt32(0),
                            Cod_Usuario = reader.GetInt32(1),
                            Fecha_Hora = reader.GetDateTime(2),
                            Id_Cliente = reader.GetInt32(3),
                            Subtotal = reader.GetDecimal(4),
                            Descu = reader.GetDecimal(5),
                            Total = reader.GetDecimal(6)
                        };
                        return Result<HVentas>.Success(venta);
                    }
                }
                return Result<HVentas>.Failure("Venta no encontrada");
            }
            catch (OleDbException ex)
            {
                return Result<HVentas>.Failure($"Error al obtener venta {ex.Message}");
			}
        }

        public Result<HVentas> Update(HVentas venta)
        {
            throw new NotImplementedException();
        }

        public Result<List<HVentas>> GetFiltered(DateTime fechaDesde, DateTime fechaHasta, string cliente, int? idRemito)
        {
            try
            {
                var ventas = new List<HVentas>();
                var query = new StringBuilder("SELECT v.Id_Remito, v.Cod_Usuario, v.Fecha_Hora, v.Id_Cliente, v.Subtotal, v.Descu, v.Total FROM H_Ventas v");
                var whereClause = new List<string>();
                var parameters = new List<OleDbParameter>();

                // Filtro por rango de fechas - formato correcto para Access
                whereClause.Add("v.Fecha_Hora BETWEEN ? AND ?");
                parameters.Add(new OleDbParameter("@fechaDesde", OleDbType.Date) { Value = fechaDesde });
                parameters.Add(new OleDbParameter("@fechaHasta", OleDbType.Date) { Value = fechaHasta });

                // Filtro por ID de remito si se proporciona
                if (idRemito.HasValue)
                {
                    whereClause.Add("v.Id_Remito = ?");
                    parameters.Add(new OleDbParameter("@idRemito", OleDbType.Integer) { Value = idRemito.Value });
                }

                // Filtro por nombre de cliente si se proporciona
                if (!string.IsNullOrEmpty(cliente))
                {
                    query.Append(" INNER JOIN Clientes c ON v.Id_Cliente = c.Id_Cliente");
                    whereClause.Add("c.Nombre LIKE ?");
                    parameters.Add(new OleDbParameter("@cliente", OleDbType.VarChar) { Value = $"%{cliente}%" });
                }

                // Agregar cláusula WHERE si hay filtros
                if (whereClause.Count > 0)
                {
                    query.Append(" WHERE ");
                    query.Append(string.Join(" AND ", whereClause));
                }

                // Ordenar por fecha descendente
                query.Append(" ORDER BY v.Fecha_Hora DESC");

                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using var cmd = new OleDbCommand(query.ToString(), conexion);
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }

                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ventas.Add(new HVentas
                        {
                            Id_Remito = reader.GetInt32(0),
                            Cod_Usuario = reader.GetInt32(1),
                            Fecha_Hora = reader.GetDateTime(2),
                            Id_Cliente = reader.GetInt32(3),
                            Subtotal = reader.GetDecimal(4),
                            Descu = reader.GetDecimal(5),
                            Total = reader.GetDecimal(6)
                        });
                    }
                }

                return Result<List<HVentas>>.Success(ventas);
            }
            catch (OleDbException ex)
            {
                return Result<List<HVentas>>.Failure($"Error al filtrar ventas: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<List<HVentas>>.Failure($"Error inesperado al filtrar ventas: {ex.Message}");
            }
        }
    }
}
