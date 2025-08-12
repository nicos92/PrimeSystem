using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Repositorios
{
    public interface IHComprasRepository
    {
        Result<List<H_Compras>> GetAll();
        Result<H_Compras> GetById(int id);
        Result<H_Compras> Add(H_Compras compra);
        Result<H_Compras> Update(H_Compras compra);
        Result<bool> Delete(int id);
    }
}
