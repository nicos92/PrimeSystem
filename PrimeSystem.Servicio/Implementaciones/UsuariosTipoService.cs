using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Contrato.Repositorios;

namespace PrimeSystem.Servicio.Implementaciones
{
    public class UsuariosTipoService : IUsuariosTipoService
    {
        private readonly IUsuariosTipoRepository _repo;

        public UsuariosTipoService(IUsuariosTipoRepository repo)
        {
            _repo = repo;
        }

        public Result<List<Usuarios_Tipo>> GetAll() => _repo.GetAll();
        public Result<Usuarios_Tipo> GetById(int id) => _repo.GetById(id);
        public Result<Usuarios_Tipo> Add(Usuarios_Tipo tipo) => _repo.Add(tipo);
        public Result<Usuarios_Tipo> Update(Usuarios_Tipo tipo) => _repo.Update(tipo);
        public Result<bool> Delete(int id) => _repo.Delete(id);
    }
}
