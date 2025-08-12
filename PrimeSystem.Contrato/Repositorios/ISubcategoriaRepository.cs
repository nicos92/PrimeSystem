using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Repositorios
{
    public interface ISubcategoriaRepository
    {
        Result<List<Subcategoria>> GetAll();
        Result<Subcategoria> GetById(int id);
        Result<Subcategoria> Add(Subcategoria subcategoria);
        Result<Subcategoria> Update(Subcategoria subcategoria);
        Result<bool> Delete(int id);
    }
}
