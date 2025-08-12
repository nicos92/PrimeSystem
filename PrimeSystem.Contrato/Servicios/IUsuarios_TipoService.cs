using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Servicios
{
    public interface IUsuariosTipoService
    {
        Result<List<Usuarios_Tipo>> GetAll();
        Result<Usuarios_Tipo> GetById(int id);
        Result<Usuarios_Tipo> Add(Usuarios_Tipo tipo);
        Result<Usuarios_Tipo> Update(Usuarios_Tipo tipo);
        Result<bool> Delete(int id);
    }
}
