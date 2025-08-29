using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Contrato.Repositorios;

namespace PrimeSystem.Servicio.Implementaciones
{
    public class ArticulosService : IArticulosService
    {
        private readonly IArticulosRepository _repo;

        public ArticulosService(IArticulosRepository repo)
        {
            _repo = repo;
        }
       

        public async Task<Result<List<Articulos>>> GetAll()
        {
            return await _repo.GetAll();
        }

        public Result<Articulos> GetById(int id)
        {
            return _repo.GetById(id);
        }

        public Result<Articulos> Add(Articulos articulo)
        {
            return _repo.Add(articulo);
        }

        public Result<Articulos> Update(Articulos articulo)
        {
            return _repo.Update(articulo);
        }

        public Result<bool> Delete(int id)
        {
            return _repo.Delete(id);
        }

        public async Task<Result<int>> GetMaxCodArt()
        {
            return await  _repo.GetMaxCodArt();
        }
    }
}
