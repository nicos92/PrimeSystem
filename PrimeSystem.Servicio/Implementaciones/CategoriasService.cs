using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Contrato.Repositorios;

namespace PrimeSystem.Servicio.Implementaciones
{
    public class CategoriasService : ICategoriasService
    {
        private readonly ICategoriasRepository _repo;

        public CategoriasService(ICategoriasRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result<List<Categorias>>> GetAll() => await _repo.GetAll();
        public Result<Categorias> GetById(int id) => _repo.GetById(id);
        public Result<Categorias> Add(Categorias categoria) => _repo.Add(categoria);
        public Result<Categorias> Update(Categorias categoria) => _repo.Update(categoria);
        public Result<bool> Delete(int id) => _repo.Delete(id);
    }
}
