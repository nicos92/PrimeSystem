using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSystem.Contrato.Servicios
{
    public interface IArticuloStockService
    {
        Task<Result<(List<Articulos> articulos, List<Stock> stock)>> GetAll();
        Task<Result<bool>> Add(Articulos articulo, Stock stock);

        Task<Result<bool>> Update(Articulos articulos, Stock stock);

        Task<Result<bool>> Delete(Articulos articulo, Stock stock);
    }
}
