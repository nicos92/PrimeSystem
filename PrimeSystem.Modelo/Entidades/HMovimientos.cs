using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSystem.Modelo.Entidades
{
    public class HMovimientos
    {
        public int Id_Historico { get; set; }
        public int Id_Usuario { get; set; }
        public int Tipo_Movimiento { get; set; }

        // TODO pruguntar al profesor que significa reg_antes y reg_despues
        public decimal Reg_Antes { get; set; }
        public decimal Reg_Despues { get; set; }
        public DateTime Fecha_Hora { get; set; }
        public HMovimientos()
        {

        }
    }
}
