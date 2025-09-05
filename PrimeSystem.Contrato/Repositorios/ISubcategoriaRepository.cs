using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Repositorios
{
    public interface ISubcategoriaRepository
    {
        Task<Result<List<Subcategoria>>> GetAll();
        Task<Result<List<Subcategoria>>> GetAllxCategoria(int id);
        Result<Subcategoria> GetById(int id);
        Result<Subcategoria> Add(Subcategoria subcategoria);
        Result<Subcategoria> Update(Subcategoria subcategoria);
        Result<bool> Delete(int id);
    }
}
