using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Repositorios
{
    public interface IHVentasDetalleRepository
    {
        Result<List<H_Ventas_Detalle>> GetAll();
        Result<H_Ventas_Detalle> GetById(int id);
        Result<H_Ventas_Detalle> Add(H_Ventas_Detalle detalle);
        Result<H_Ventas_Detalle> Update(H_Ventas_Detalle detalle);
        Result<bool> Delete(int id);
    }
}
