using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Servicios
{
    public interface IHVentasService
    {
        Result<List<H_Ventas>> GetAll();
        Result<H_Ventas> GetById(int id);
        Result<H_Ventas> Add(H_Ventas venta);
        Result<H_Ventas> Update(H_Ventas venta);
        Result<bool> Delete(int id);
    }
}
