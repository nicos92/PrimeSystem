using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Contrato.Repositorios;

namespace PrimeSystem.Servicio.Implementaciones
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuariosRepository _repo;

        public UsuariosService(IUsuariosRepository repo)
        {
            _repo = repo;
        }

        public Result<List<Usuarios>> GetAll() => _repo.GetAll();
        public Result<Usuarios> GetById(int id) => _repo.GetById(id);
        public Result<Usuarios> Add(Usuarios usuario) => _repo.Add(usuario);
        public Result<Usuarios> Update(Usuarios usuario) => _repo.Update(usuario);
        public Result<bool> Delete(int id) => _repo.Delete(id);
    }
}
