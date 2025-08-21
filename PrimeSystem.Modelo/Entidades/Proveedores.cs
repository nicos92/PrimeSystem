using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSystem.Modelo.Entidades
{
    public class Proveedores
    {
        public int Id_Proveedor { get; set; }
        public string? CUIT { get; set; }
        public string? Proveedor { get; set; }
        public string? Nombre { get; set; }
        public string? Tel { get; set; }
        public string? Email { get; set; }
        public Proveedores()
        {
            
        }

        public override string ToString()
        {
            return $"{Id_Proveedor} - {Proveedor} - {Nombre} - {CUIT} - {Tel} - {Email}";
        }
    }
}
