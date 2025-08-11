using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSystem.Modelo.Entidades
{
    public class Clientes
    {
        public int Id_Cliente { get; set; }
        public string? CUIT { get; set; }
        public string? Nombre { get; set; }
        public string? Entidad { get; set; }
        public string? Tel { get; set; }
        public string? Mail { get; set; }

        public Clientes() { }
    }
}
