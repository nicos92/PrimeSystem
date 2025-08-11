using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSystem.Modelo.Entidades
{
    public class Usuarios
    {
        public int Id_Usuario { get; set; }
        public string? DNI { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Tel { get; set; }
        public string? Mail { get; set; }
        public int Id_Tipo { get; set; }

        public Usuarios() { }
    }

}
