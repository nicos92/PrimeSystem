using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSystem.Modelo.Entidades
{
    public class Usuarios_Tipo
    {
        public int Id_Usuario_Tipo { get; set; }
        public int Tipo { get; set; }
        public string? Descripcion { get; set; }

        public Usuarios_Tipo() { }
    }

}
