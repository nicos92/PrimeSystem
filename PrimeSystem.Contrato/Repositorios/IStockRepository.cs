using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Repositorios
{
    public interface IStockRepository
    {
        Task<Result<List<Stock>>> GetAll();
        Result<Stock> GetById(int id);
        Result<Stock> Add(Stock stock);
        Result<Stock> Update(Stock stock);
        Result<bool> Delete(int id);
    }
}
