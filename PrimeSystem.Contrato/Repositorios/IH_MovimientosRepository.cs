using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Repositorios
{
    public interface IHMovimientosRepository
    {
        Result<List<HMovimientos>> GetAll();
        Result<HMovimientos> GetById(int id);
        Result<HMovimientos> Add(HMovimientos movimiento);
        Result<HMovimientos> Update(HMovimientos movimiento);
        Result<bool> Delete(int id);
    }
}
