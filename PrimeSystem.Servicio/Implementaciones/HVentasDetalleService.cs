using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Contrato.Repositorios;

namespace PrimeSystem.Servicio.Implementaciones
{
    public class HVentasDetalleService : IHVentasDetalleService
    {
        private readonly IHVentasDetalleRepository _repo;

        public HVentasDetalleService(IHVentasDetalleRepository repo)
        {
            _repo = repo;
        }

        public Result<List<HVentasDetalle>> GetAll() => _repo.GetAll();
        public Result<HVentasDetalle> GetById(int id) => _repo.GetById(id);
        public Result<HVentasDetalle> Add(HVentasDetalle detalle) => _repo.Add(detalle);
        public Result<HVentasDetalle> Update(HVentasDetalle detalle) => _repo.Update(detalle);
        public Result<bool> Delete(int id) => _repo.Delete(id);
    }
}
