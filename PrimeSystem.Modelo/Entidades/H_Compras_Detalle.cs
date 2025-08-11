using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSystem.Modelo.Entidades
{
    public class H_Compras_Detalle
    {
        public int Id_Det_Remito { get; set; }
        public int Id_Remito { get; set; }
        public string? Cod_Art { get; set; }
        public string? Descr { get; set; }
        public double P_Unit { get; set; }
        public int Cant { get; set; }
        public double P_X_Cant { get; set; }

        public H_Compras_Detalle() { }
    }

}
