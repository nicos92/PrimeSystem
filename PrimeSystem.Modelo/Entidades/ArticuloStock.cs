using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSystem.Modelo.Entidades
{
    public record ArticuloStock(
     int Id_Articulo,
     string Cod_Articulo,
     string Art_Desc,
     int Cod_Categoria,
     int Cod_Subcat,
     int Id_Proveedor,
     double Cantidad,
     double Costo,
     double Ganancia
 );
}
