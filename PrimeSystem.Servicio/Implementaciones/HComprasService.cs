using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Contrato.Repositorios;

namespace PrimeSystem.Servicio.Implementaciones
{
    public class HComprasService : IHComprasService
    {
        private readonly IHComprasRepository _repo;

        public HComprasService(IHComprasRepository repo)
        {
            _repo = repo;
        }

        public Result<List<HCompras>> GetAll() => _repo.GetAll();
        public Result<HCompras> GetById(int id) => _repo.GetById(id);
        public Result<HCompras> Add(HCompras compra) => _repo.Add(compra);
        public Result<HCompras> Update(HCompras compra) => _repo.Update(compra);
        public Result<bool> Delete(int id) => _repo.Delete(id);
    }
}
