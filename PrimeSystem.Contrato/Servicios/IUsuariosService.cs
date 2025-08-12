using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Servicios
{
    public interface IUsuariosService
    {
        Result<List<Usuarios>> GetAll();
        Result<Usuarios> GetById(int id);
        Result<Usuarios> Add(Usuarios usuario);
        Result<Usuarios> Update(Usuarios usuario);
        Result<bool> Delete(int id);
    }
}
