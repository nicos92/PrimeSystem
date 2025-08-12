using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Servicios
{
    public interface IHComprasDetalleService
    {
        Result<List<H_Compras_Detalle>> GetAll();
        Result<H_Compras_Detalle> GetById(int id);
        Result<H_Compras_Detalle> Add(H_Compras_Detalle detalle);
        Result<H_Compras_Detalle> Update(H_Compras_Detalle detalle);
        Result<bool> Delete(int id);
    }
}
