using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Servicios
{
    public interface IInOutVariosService
    {
        Result<List<In_Out_Varios>> GetAll();
        Result<In_Out_Varios> GetById(int id);
        Result<In_Out_Varios> Add(In_Out_Varios item);
        Result<In_Out_Varios> Update(In_Out_Varios item);
        Result<bool> Delete(int id);
    }
}
