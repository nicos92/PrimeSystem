using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Servicios
{
    public interface IClientesService
    {
        Result<List<Clientes>> GetAll();
        Result<Clientes> GetById(int id);
        Result<Clientes> Add(Clientes cliente);
        Result<Clientes> Update(Clientes cliente);
        Result<bool> Delete(int id);
    }
}
