using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSystem.Modelo.Entidades
{
    public class InOutVarios
    {
        public int Id_Movimiento { get; set; }
        public int Cod_Usuario { get; set; }
        public string? Tipo { get; set; }
        public string? Detalle { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public InOutVarios()
        {

        }
    }
}
