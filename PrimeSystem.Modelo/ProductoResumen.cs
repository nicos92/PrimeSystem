using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSystem.Modelo;

public class ProductoResumen
{
    public string? Cod_Articulo { get; set; }
    public string? Producto_Nombre { get; set; }
    public double Producto_Precio { get; set; }
    public int Producto_Cantidad { get; set; }
    public double Producto_PrecioxCantidad { get; set; }
}