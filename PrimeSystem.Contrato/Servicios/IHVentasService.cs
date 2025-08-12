using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Servicios
{
    public interface IHVentasService
    {
        Result<List<HVentas>> GetAll();
        Result<HVentas> GetById(int id);
        Result<HVentas> Add(HVentas venta);
        Result<HVentas> Update(HVentas venta);
        Result<bool> Delete(int id);
    }
}
