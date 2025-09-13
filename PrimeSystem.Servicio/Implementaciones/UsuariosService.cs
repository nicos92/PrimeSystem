using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Contrato.Repositorios;

namespace PrimeSystem.Servicio.Implementaciones
{
    public class UsuariosService(IUsuariosRepository repo) : IUsuariosService
    {
        private readonly IUsuariosRepository _repo = repo;

        public async Task<Result<List<Usuarios>>> GetAll() => await _repo.GetAll();
        public async Task<Result<Usuarios>> GetById(int id) => await _repo.GetById(id);
        public Result<Usuarios> Add(Usuarios usuario) => _repo.Add(usuario);
        public Result<Usuarios> Update(Usuarios usuario) => _repo.Update(usuario);
        public Result<bool> Delete(int id) => _repo.Delete(id);
    }
}
