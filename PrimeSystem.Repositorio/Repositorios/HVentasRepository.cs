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
                    using var cmd = new OleDbCommand("SELECT Id_Remito,Cod_Usuario,Fecha_Hora,Id_Cliente,Subtotal,Total FROM HVentas", conexion);
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
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
                    using var cmd = new OleDbCommand("SELECT Id_Remito,Cod_Usuario,Fecha_Hora,Id_Cliente,Subtotal,Total FROM HVentas WHERE Id_Remito = @id", conexion);
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
                            Subtotal = reader.GetDouble(4),
                            Descu = reader.GetDouble(5),
                            Total = reader.GetDouble(6)
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
    }
}
