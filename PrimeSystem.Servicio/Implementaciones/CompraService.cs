using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeSystem.Modelo;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Contrato.Repositorios;

namespace PrimeSystem.Servicio.Implementaciones
{
    public class CompraService : ICompraService
    {
        private readonly IHComprasService _comprasService;
        private readonly IHComprasDetalleService _comprasDetalleService;

        public CompraService(IHComprasService comprasService, IHComprasDetalleService comprasDetalleService)
        {
            _comprasService = comprasService;
            _comprasDetalleService = comprasDetalleService;
        }

        public async Task<Result<bool>> Add(HCompras hCompras, List<ProductoResumen> productoResumen)
        {
            try
            {
                // Use the new service method that handles both the main purchase and details in a transaction
                var compraResult = await Task.Run(() => _comprasService.AddWithDetails(hCompras, productoResumen));
                
                if (!compraResult.IsSuccess)
                {
                    return Result<bool>.Failure($"Error al agregar la compra con detalles: {compraResult.Error}");
                }

                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Error al procesar la compra: {ex.Message}");
            }
        }

        public async Task<Result<(List<HCompras> compras, List<HComprasDetalle> detalles)>> GetAll()
        {
            try
            {
                // Get all purchases
                var comprasResult = _comprasService.GetAll();
                
                if (!comprasResult.IsSuccess)
                {
                    return Result<(List<HCompras> compras, List<HComprasDetalle> detalles)>.Failure($"Error al obtener compras: {comprasResult.Error}");
                }

                var compras = comprasResult.Value;
                
                // Get all purchase details
                var detallesResult = _comprasDetalleService.GetAll();
                
                if (!detallesResult.IsSuccess)
                {
                    return Result<(List<HCompras> compras, List<HComprasDetalle> detalles)>.Failure($"Error al obtener detalles de compras: {detallesResult.Error}");
                }

                var detalles = detallesResult.Value;

                return Result<(List<HCompras> compras, List<HComprasDetalle> detalles)>.Success((compras, detalles));
            }
            catch (Exception ex)
            {
                return Result<(List<HCompras> compras, List<HComprasDetalle> detalles)>.Failure($"Error al obtener todas las compras: {ex.Message}");
            }
        }
    }
}