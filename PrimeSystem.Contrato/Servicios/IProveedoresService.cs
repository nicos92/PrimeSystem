using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Servicios
{
    public interface IProveedoresService
    {
        Result<List<Proveedores>> GetAll();
        Result<Proveedores> GetById(int id);
        Result<Proveedores> Add(Proveedores proveedor);
        Result<Proveedores> Update(Proveedores proveedor);
        Result<bool> Delete(int id);
    }
}
