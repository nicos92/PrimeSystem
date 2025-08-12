using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Contrato.Repositorios;

namespace PrimeSystem.Servicio.Implementaciones
{
    public class HComprasDetalleService : IHComprasDetalleService
    {
        private readonly IHComprasDetalleRepository _repo;

        public HComprasDetalleService(IHComprasDetalleRepository repo)
        {
            _repo = repo;
        }

        public Result<List<HComprasDetalle>> GetAll() => _repo.GetAll();
        public Result<HComprasDetalle> GetById(int id) => _repo.GetById(id);
        public Result<HComprasDetalle> Add(HComprasDetalle detalle) => _repo.Add(detalle);
        public Result<HComprasDetalle> Update(HComprasDetalle detalle) => _repo.Update(detalle);
        public Result<bool> Delete(int id) => _repo.Delete(id);
    }
}
