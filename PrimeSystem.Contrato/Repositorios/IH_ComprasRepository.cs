using System;
using System.Collections.Generic;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Contrato.Repositorios
{
    public interface IHComprasRepository
    {
        Result<List<HCompras>> GetAll();
        Result<HCompras> GetById(int id);
        Result<HCompras> Add(HCompras compra);
        Result<HCompras> AddWithDetails(HCompras compra, List<PrimeSystem.Modelo.ProductoResumen> productosResumen);
        Result<HCompras> Update(HCompras compra);
        Result<bool> Delete(int id);
        Result<List<HCompras>> GetFiltered(DateTime fechaDesde, DateTime fechaHasta, string proveedor, int? idRemito);
    }
}
