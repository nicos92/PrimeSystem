using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSystem.Modelo.Entidades
{
    public class Stock
    {
        public string? Cod_Articulo { get; set; }
        public int Cantidad { get; set; }
        public double Costo { get; set; }
        public double Ganancia { get; set; }
        public Stock()
        {
            
        }

        public override string ToString()
        {
            return $"Codigo: {Cod_Articulo}, Cantidad: {Cantidad}, Costo: {Costo}, Ganancia: {Ganancia}.";
        }

    }
}
