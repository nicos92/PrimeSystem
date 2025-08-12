using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Contrato.Repositorios;

namespace PrimeSystem.Servicio.Implementaciones
{
    public class SubcategoriaService : ISubcategoriaService
    {
        private readonly ISubcategoriaRepository _repo;

        public SubcategoriaService(ISubcategoriaRepository repo)
        {
            _repo = repo;
        }

        public Result<List<Subcategoria>> GetAll() => _repo.GetAll();
        public Result<Subcategoria> GetById(int id) => _repo.GetById(id);
        public Result<Subcategoria> Add(Subcategoria subcategoria) => _repo.Add(subcategoria);
        public Result<Subcategoria> Update(Subcategoria subcategoria) => _repo.Update(subcategoria);
        public Result<bool> Delete(int id) => _repo.Delete(id);
    }
}
