using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Servicios
{
    public interface IVentaService
    {
        Task<Result<bool>> Add(HVentas hVentas, List<ProductoResumen> productoResumen);
        Task<Result<(List<HVentas> ventas, List<HVentasDetalle> detalles)>> GetAll();
    }
}
