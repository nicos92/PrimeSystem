using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Repositorios
{
    public interface IClientesRepository
    {
        Task<Result<List<Clientes>>> GetAll();
        Result<Clientes> GetById(int id);
        Result<Clientes> Add(Clientes cliente);
        Result<Clientes> Update(Clientes cliente);
        Result<bool> Delete(int id);
    }
}
