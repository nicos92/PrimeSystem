// Define una clase para representar los productos/items del ticket
public class ProductoVenta
{
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
    public decimal Subtotal { get; set; }
    public decimal IVA { get; set; }
    public decimal Descuento { get; set; }
    public decimal Total { get; set; }
}
