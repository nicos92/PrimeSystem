using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Servicios
{
    public interface IHMovimientosService
    {
        Result<List<H_Movimientos>> GetAll();
        Result<H_Movimientos> GetById(int id);
        Result<H_Movimientos> Add(H_Movimientos movimiento);
        Result<H_Movimientos> Update(H_Movimientos movimiento);
        Result<bool> Delete(int id);
    }
}
