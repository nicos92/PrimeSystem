using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Servicios
{
    public interface IHComprasService
    {
        Result<List<HCompras>> GetAll();
        Result<HCompras> GetById(int id);
        Result<HCompras> Add(HCompras compra);
        Result<HCompras> Update(HCompras compra);
        Result<bool> Delete(int id);
    }
}
