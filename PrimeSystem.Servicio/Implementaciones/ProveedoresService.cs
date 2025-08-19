using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Contrato.Repositorios;

namespace PrimeSystem.Servicio.Implementaciones
{
    public class ProveedoresService : IProveedoresService
    {
        private readonly IProveedoresRepository _repo;

        public ProveedoresService(IProveedoresRepository repo)
        {
            _repo = repo;
        }

        public Task<Result<List<Proveedores>>> GetAll() => await _repo.GetAll();
        public Result<Proveedores> GetById(int id) => _repo.GetById(id);
        public Result<Proveedores> Add(Proveedores proveedor) => _repo.Add(proveedor);
        public Result<Proveedores> Update(Proveedores proveedor) => _repo.Update(proveedor);
        public Result<bool> Delete(int id) => _repo.Delete(id);
    }
}
