using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Repositorios
{
    public interface IArticulosRepository
    {
        Task<Result<List<Articulos>>> GetAll();
        Result<Articulos> GetById(int id);
        Result<Articulos> Add(Articulos articulo);
        Result<Articulos> Update(Articulos articulo);
        Result<bool> Delete(int id);
    }
}
