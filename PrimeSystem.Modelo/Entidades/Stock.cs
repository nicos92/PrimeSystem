using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSystem.Modelo.Entidades
{
    public class Stock
    {
        public int Cod_Articulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Ganancia { get; set; }
        public Stock()
        {
            
        }

        public override string ToString()
        {
            return $"Codigo: {Cod_Articulo}, Cantidad: {Cantidad}, Costo: {Costo}, Ganancia: {Ganancia}.";
        }

    }
}
