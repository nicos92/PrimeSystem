using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Contrato.Repositorios;

namespace PrimeSystem.Servicio.Implementaciones
{
    public class ClientesService : IClientesService
    {
        private readonly IClientesRepository _repo;

        public ClientesService(IClientesRepository repo)
        {
            _repo = repo;
        }

        public Result<List<Clientes>> GetAll() => _repo.GetAll();
        public Result<Clientes> GetById(int id) => _repo.GetById(id);
        public Result<Clientes> Add(Clientes cliente) => _repo.Add(cliente);
        public Result<Clientes> Update(Clientes cliente) => _repo.Update(cliente);
        public Result<bool> Delete(int id) => _repo.Delete(id);
    }
}
