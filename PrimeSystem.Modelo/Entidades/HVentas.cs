using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSystem.Modelo.Entidades
{
    public class HVentas
    {
        public int Id_Remito { get; set; }
        public int Cod_Usuario { get; set; }
        public DateTime Fecha_Hora { get; set; }
        public int Id_Cliente { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descu { get; set; }
        public decimal Total { get; set; }

        public HVentas() { }
    }

}
