using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Contrato.Repositorios;

namespace PrimeSystem.Servicio.Implementaciones
{
    public class HMovimientosService : IHMovimientosService
    {
        private readonly IHMovimientosRepository _repo;

        public HMovimientosService(IHMovimientosRepository repo)
        {
            _repo = repo;
        }

        public Result<List<HMovimientos>> GetAll() => _repo.GetAll();
        public Result<HMovimientos> GetById(int id) => _repo.GetById(id);
        public Result<HMovimientos> Add(HMovimientos movimiento) => _repo.Add(movimiento);
        public Result<HMovimientos> Update(HMovimientos movimiento) => _repo.Update(movimiento);
        public Result<bool> Delete(int id) => _repo.Delete(id);
    }
}
