using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Repositorios
{
    public interface IClienteRepository
    {
        Result<List<Clientes>> GetAll();
        Result<Clientes> GetById(int id);
        Result<Clientes> GetByDni(string dni);
        Result<Clientes> Add(Clientes cliente);
        Result<bool> Delete(int id);
    }
}