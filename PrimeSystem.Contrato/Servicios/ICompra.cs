using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeSystem.Modelo;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Servicios
{
    public interface ICompraService
    {
        Task<Result<bool>> Add(HCompras hCompras, List<ProductoResumen> productoResumen);
        Task<Result<(List<HCompras> compras, List<HComprasDetalle> detalles)>> GetAll();
    }
}