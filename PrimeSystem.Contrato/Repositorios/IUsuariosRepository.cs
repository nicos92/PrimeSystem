using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Repositorios
{
    public interface IUsuariosRepository
    {
        Result<List<Usuarios>> GetAll();
        Result<Usuarios> GetById(int id);
        Result<Usuarios> Add(Usuarios usuario);
        Result<Usuarios> Update(Usuarios usuario);
        Result<bool> Delete(int id);
    }
}
