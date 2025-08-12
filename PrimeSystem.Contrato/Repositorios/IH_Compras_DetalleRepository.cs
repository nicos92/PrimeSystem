using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Repositorios
{
    public interface IHComprasDetalleRepository
    {
        Result<List<HComprasDetalle>> GetAll();
        Result<HComprasDetalle> GetById(int id);
        Result<HComprasDetalle> Add(HComprasDetalle detalle);
        Result<HComprasDetalle> Update(HComprasDetalle detalle);
        Result<bool> Delete(int id);
    }
}
