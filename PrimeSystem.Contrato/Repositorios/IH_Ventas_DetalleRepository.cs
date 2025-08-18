using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Repositorios
{
    public interface IHVentasDetalleRepository
    {
        Task<Result<List<HVentasDetalle>>> GetAll();
        Result<HVentasDetalle> GetById(int id);
        Result<HVentasDetalle> Add(HVentasDetalle detalle);
        Result<HVentasDetalle> Update(HVentasDetalle detalle);
        Result<bool> Delete(int id);
    }
}
