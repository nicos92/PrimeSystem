using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Servicio;
using PrimeSystem.Utilidades;

namespace PrimeSystem.UI.Ventas
{
    public partial class FormVentas : Form
    {
        private readonly IArticuloStockService _articuloStockService;
        private readonly IHVentasService _hVentaService;
        private readonly IHVentasDetalleService _hVentaDetalleService;
        private readonly IVentaService _ventaService;

        private int _indiceSeleccionado;
        private bool _procesandoSeleccion = false;
        private bool _restaurarSeleccion = false;
        private readonly BindingList<ProductoResumen> _productosResumen = new BindingList<ProductoResumen>();

        public FormVentas(IArticuloStockService articuloStockService,
                         IHVentasService hVentasService,
                         IHVentasDetalleService hVentasDetalleService,
                         IVentaService ventaService)
        {
            _hVentaService = hVentasService;
            _hVentaDetalleService = hVentasDetalleService;
            _articuloStockService = articuloStockService;
            _ventaService = ventaService;
            _indiceSeleccionado = 0;

            InitializeComponent();
            KeyPreview = true;
        }

        private void ListaProductos(List<ArticuloStock> productosSeleccionados)
        {
            _productosResumen.Clear();

            var productosAgrupados = productosSeleccionados
                .GroupBy(p => p.Art_Desc)
                .Select(g => new ProductoResumen
                {
                    Cod_Articulo = g.First().Cod_Articulo,
                    Producto_Nombre = g.Key,
                    Producto_Precio = CalcularPrecioVenta(g.First()),
                    Producto_Cantidad = g.Count(),
                    Producto_PrecioxCantidad = g.Sum(p => CalcularPrecioVenta(p))
                });

            foreach (var producto in productosAgrupados)
            {
                _productosResumen.Add(producto);
            }
        }

        private double CalcularPrecioVenta(ArticuloStock articulo)
        {
            return articulo.Costo + (articulo.Costo * (articulo.Ganancia / 100));
        }

        private (int cantidad, double total) CalcularTotales(List<ArticuloStock> productos)
        {
            int cantidad = productos.Count;
            double total = productos.Sum(p => CalcularPrecioVenta(p));

            return (cantidad, total);
        }

        private void ConfigurarDGV()
        {
            DgvProductosSeleccionados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvProductosSeleccionados.AllowUserToAddRows = false;
            DgvProductosSeleccionados.AllowUserToDeleteRows = false;
            DgvProductosSeleccionados.ReadOnly = true;
            DgvProductosSeleccionados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvProductosSeleccionados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvProductosSeleccionados.MultiSelect = false;
            DgvProductosSeleccionados.RowHeadersVisible = false;
            DgvProductosSeleccionados.AllowUserToResizeRows = false;
            DgvProductosSeleccionados.AllowUserToResizeColumns = true;
            DgvProductosSeleccionados.AutoGenerateColumns = false;

           
         

            ConfigurarColumnasDataGridView();
        }

        private void SeleccionarFilaPorCodigoArticulo(string codigoArticulo)
        {
            for (int i = 0; i < DgvProductosSeleccionados.Rows.Count; i++)
            {
                if (DgvProductosSeleccionados.Rows[i].DataBoundItem is ProductoResumen producto &&
                    producto.Cod_Articulo == codigoArticulo.ToString())
                {
                    DgvProductosSeleccionados.ClearSelection();
                    DgvProductosSeleccionados.Rows[i].Selected = true;
                    DgvProductosSeleccionados.CurrentCell = DgvProductosSeleccionados.Rows[i].Cells[1]; // Selecciona la columna "Nombre"
                    break;
                }
            }
        }

        private void ConfigurarColumnasDataGridView()
        {
            DgvProductosSeleccionados.Columns.Clear();

            var columns = new[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductoId",
                    DataPropertyName = "Cod_Articulo",
                    HeaderText = "ID",
                    Visible = false
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductoNombre",
                    DataPropertyName = "Producto_Nombre",
                    HeaderText = "Nombre",
                    Width = 200
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductoCantidad",
                    DataPropertyName = "Producto_Cantidad",
                    HeaderText = "Cantidad",
                    Width = 80,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductoPrecioUnitario",
                    DataPropertyName = "Producto_Precio",
                    HeaderText = "Precio Unitario",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "C2",
                        Alignment = DataGridViewContentAlignment.MiddleRight
                    }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductoPrecioTotal",
                    DataPropertyName = "Producto_PrecioxCantidad",
                    HeaderText = "Total",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "C2",
                        Alignment = DataGridViewContentAlignment.MiddleRight
                    }
                }
            };

            foreach (var column in columns)
            {
                DgvProductosSeleccionados.Columns.Add(column);
            }
        }

        private void CmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbProducto.SelectedItem is ArticuloStock selectedItem)
            {
                LblProducto.Text = selectedItem.Art_Desc;
                LblPrecio.Text = CalcularPrecioVenta(selectedItem).ToString("C2");
            }
            else
            {
                LblProducto.Text = string.Empty;
                LblPrecio.Text = string.Empty;
            }

            ActualizarTotalPrecioPorCantidad();
            NumericUpDown1.Value = 1;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ActualizarTotalPrecioPorCantidad();
        }

        private void ActualizarTotalPrecioPorCantidad()
        {
            if (decimal.TryParse(LblPrecio.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal precio))
            {
                decimal total = precio * NumericUpDown1.Value;
                LblPrecioCant.Text = total.ToString("C2");
            }
            else
            {
                LblPrecioCant.Text = 0m.ToString("C2");
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (CmbProducto.SelectedItem is ArticuloStock producto)
            {
                int cantidad = (int)NumericUpDown1.Value;
                AgregarProductosAlCarrito(producto, cantidad);
                CargarDataGridView();

                // Seleccionar la fila del producto agregado
                SeleccionarFilaPorCodigoArticulo(producto.Cod_Articulo);
            }
            else
            {
                MostrarMensajeAdvertencia("Por favor, selecciona un producto.");
            }
        }

        private void AgregarProductosAlCarrito(ArticuloStock producto, int cantidad)
        {
            for (int i = 0; i < cantidad; i++)
            {
                SingleListas.Instance.ProductosSeleccionados.Add(producto);
            }
        }

        private void CargarDataGridView()
        {
            // Guardar la selección actual antes de recargar
            int codigoArticuloSeleccionado = -1;
            if (DgvProductosSeleccionados.CurrentRow?.DataBoundItem is ProductoResumen productoSeleccionado)
            {
                codigoArticuloSeleccionado = Convert.ToInt32(productoSeleccionado.Cod_Articulo);
            }

            ListaProductos(SingleListas.Instance.ProductosSeleccionados);

            var (cantidad, total) = CalcularTotales(SingleListas.Instance.ProductosSeleccionados);
            LblCantProductos.Text = cantidad.ToString();
            LblPrecioTotal.Text = total.ToString("C2");

            // Restaurar la selección si el artículo todavía existe
            if (codigoArticuloSeleccionado != -1 &&
                _productosResumen.Any(p => p.Cod_Articulo == codigoArticuloSeleccionado.ToString()))
            {
                SeleccionarFilaPorCodigoArticulo(codigoArticuloSeleccionado.ToString());
            }
            else if (DgvProductosSeleccionados.Rows.Count > 0)
            {
                // Seleccionar la primera fila si no hay selección previa
                DgvProductosSeleccionados.ClearSelection();
                DgvProductosSeleccionados.Rows[0].Selected = true;
                DgvProductosSeleccionados.CurrentCell = DgvProductosSeleccionados.Rows[0].Cells[1];
            }
        }

        private async void FormVentas_Load(object sender, EventArgs e)
        {
            await CargarProductosAsync();
            ConfigurarDGV();
            DgvProductosSeleccionados.DataSource = _productosResumen;
        }

        private async Task CargarProductosAsync()
        {
            try
            {
                var result = await _articuloStockService.GetAllArticuloStock();

                if (result.IsSuccess)
                {
                    CmbProducto.DataSource = result.Value;
                    CmbProducto.ValueMember = "Cod_Articulo";
                    CmbProducto.DisplayMember = "Art_Desc";
                    CmbProducto.SelectedIndex = -1;
                }
                else
                {
                    MostrarMensajeError("Error al cargar los productos.");
                    CmbProducto.DataSource = new List<ArticuloStock>();
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error: {ex.Message}");
            }
        }

        private async void BtnConfirmarVenta_Click(object sender, EventArgs e)
        {
            if (SingleListas.Instance.ProductosSeleccionados.Count == 0)
            {
                MostrarMensajeAdvertencia("No hay productos seleccionados para la venta.");
                return;
            }

            await ProcesarVentaAsync();
        }

        private async Task ProcesarVentaAsync()
        {
            try
            {
                decimal subtotal = Convert.ToDecimal(LblPrecioTotal.Text.Split('$')[1], CultureInfo.CurrentCulture);
                decimal descuento = 0;

                var hVentas = new HVentas
                {
                    Cod_Usuario = 1,
                    Id_Cliente = 1,
                    Descu = (double)descuento,
                    Subtotal = (double)subtotal,
                    Total = (double)(subtotal - descuento)
                };

                var result = await _ventaService.Add(hVentas, _productosResumen.ToList());

                if (result.IsSuccess)
                {
                    MostrarMensajeExito("Venta procesada correctamente.");
                    LimpiarFormulario();
                }
                else
                {
                    MostrarMensajeError("Error al procesar la venta.");
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error: {ex.Message}");
            }
        }

        private void LimpiarFormulario()
        {
            SingleListas.Instance.ProductosSeleccionados.Clear();
            _productosResumen.Clear();
            CmbProducto.SelectedIndex = -1;
            NumericUpDown1.Value = 1;
            LblCantProductos.Text = "0";
            LblPrecioTotal.Text = 0m.ToString("C2");
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            QuitarUnidadSeleccionada();
        }

        private void QuitarUnidadSeleccionada()
        {
            if (DgvProductosSeleccionados.CurrentRow?.DataBoundItem is ProductoResumen articulo)
            {
                var articuloQuitar = SingleListas.Instance.ProductosSeleccionados
                    .FirstOrDefault(p => p.Cod_Articulo == articulo.Cod_Articulo);

                if (articuloQuitar != null)
                {
                    SingleListas.Instance.ProductosSeleccionados.Remove(articuloQuitar);
                    CargarDataGridView();

                    // Intentar mantener la selección en el mismo artículo si todavía existe
                    if (SingleListas.Instance.ProductosSeleccionados.Any(p => p.Cod_Articulo == articulo.Cod_Articulo))
                    {
                        SeleccionarFilaPorCodigoArticulo(articulo.Cod_Articulo);
                    }
                    else if (DgvProductosSeleccionados.Rows.Count > 0)
                    {
                        // Seleccionar la primera fila si no queda el mismo artículo
                        DgvProductosSeleccionados.ClearSelection();
                        DgvProductosSeleccionados.Rows[0].Selected = true;
                        DgvProductosSeleccionados.CurrentCell = DgvProductosSeleccionados.Rows[0].Cells[1];
                    }
                }
            }
            else if (DgvProductosSeleccionados.Rows.Count > 0)
            {
                // Si no hay fila seleccionada pero hay filas, seleccionar la primera
                DgvProductosSeleccionados.ClearSelection();
                DgvProductosSeleccionados.Rows[0].Selected = true;
                DgvProductosSeleccionados.CurrentCell = DgvProductosSeleccionados.Rows[0].Cells[1];
            }
        }

        private void FormVentas_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F8:
                    QuitarUnidadSeleccionada();
                    e.Handled = true;
                    break;
                case Keys.Enter:
                    if (CmbProducto.Focused)
                    {
                        NumericUpDown1.Focus();
                        e.Handled = true;
                    }
                    break;
            }
        }

        private void DgvProductosSeleccionados_SelectionChanged(object sender, EventArgs e)
        {
            if (_procesandoSeleccion) return;

            _procesandoSeleccion = true;
            try
            {
                if (DgvProductosSeleccionados.CurrentRow != null)
                {
                    _indiceSeleccionado = DgvProductosSeleccionados.CurrentRow.Index;
                }
            }
            finally
            {
                _procesandoSeleccion = false;
            }
        }

        #region Métodos de utilidad para mensajes
        private void MostrarMensajeAdvertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void MostrarMensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MostrarMensajeExito(string mensaje)
        {
            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}