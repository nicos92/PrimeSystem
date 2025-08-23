using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Servicios
{
    public interface IUsuariosTipoService
    {
        Task<Result<List<UsuariosTipo>>> GetAll();
        Result<UsuariosTipo> GetById(int id);
        Result<UsuariosTipo> Add(UsuariosTipo tipo);
        Result<UsuariosTipo> Update(UsuariosTipo tipo);
        Result<bool> Delete(int id);
    }
}
