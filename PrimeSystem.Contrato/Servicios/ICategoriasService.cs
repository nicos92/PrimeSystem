using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Servicios
{
    public interface ICategoriasService
    {
        Task<Result<List<Categorias>>> GetAll();
        Result<Categorias> GetById(int id);
        Result<Categorias> Add(Categorias categoria);
        Result<Categorias> Update(Categorias categoria);
        Result<bool> Delete(int id);
    }
}
