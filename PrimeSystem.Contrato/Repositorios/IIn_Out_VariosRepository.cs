using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Repositorios
{
    public interface IInOutVariosRepository
    {
        Result<List<InOutVarios>> GetAll();
        Result<InOutVarios> GetById(int id);
        Result<InOutVarios> Add(InOutVarios item);
        Result<InOutVarios> Update(InOutVarios item);
        Result<bool> Delete(int id);
    }
}
