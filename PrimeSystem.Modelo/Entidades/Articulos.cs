using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSystem.Modelo.Entidades
{
    public class Articulos
    {
        public int Id_Articulo { get; set; }
        public int Cod_Articulo { get; set; }
        public string? Art_Desc { get; set; }
        public int Cod_Categoria { get; set; }
        public int Cod_Subcat { get; set; }
        public int Id_Proveedor { get; set; }

        public Articulos() { }
    }

}
