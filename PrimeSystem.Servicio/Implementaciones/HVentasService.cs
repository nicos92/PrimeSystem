using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Contrato.Repositorios;

namespace PrimeSystem.Servicio.Implementaciones
{
    public class HVentasService : IHVentasService
    {
        private readonly IHVentasRepository _repo;

        public HVentasService(IHVentasRepository repo)
        {
            _repo = repo;
        }

        public Result<List<HVentas>> GetAll() => _repo.GetAll();
        public Result<HVentas> GetById(int id) => _repo.GetById(id);
        public Result<HVentas> Add(HVentas venta) => _repo.Add(venta);
        public Result<HVentas> Update(HVentas venta) => _repo.Update(venta);
        public Result<bool> Delete(int id) => _repo.Delete(id);
    }
}
