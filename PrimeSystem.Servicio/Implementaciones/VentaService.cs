using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeSystem.Contrato.Repositorios;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Servicio.Implementaciones
{
    public class VentaService(IVentaRepository _repo) : IVentaService
    {
        public async Task<Result<bool>> Add(HVentas hVentas, List<ProductoResumen> productoResumen)
        {
            return await _repo.Add(hVentas, productoResumen);
        }

        public async Task<Result<(List<HVentas> ventas, List<HVentasDetalle> detalles)>> GetAll()
        {
            return await _repo.GetAll();
        }
    }
}
