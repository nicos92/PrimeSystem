using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Contrato.Repositorios;

namespace PrimeSystem.Servicio.Implementaciones
{
    public class InOutVariosService : IInOutVariosService
    {
        private readonly IInOutVariosRepository _repo;

        public InOutVariosService(IInOutVariosRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result<List<InOutVarios>>> GetAll() => await _repo.GetAll();
        public Result<InOutVarios> GetById(int id) => _repo.GetById(id);
        public Result<InOutVarios> Add(InOutVarios item) => _repo.Add(item);
        public Result<InOutVarios> Update(InOutVarios item) => _repo.Update(item);
        public Result<bool> Delete(int id) => _repo.Delete(id);
    }
}
