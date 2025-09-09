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
using PrimeSystem.Modelo;
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
        private bool _evitarBucleEventos = false;
        private int _indiceSeleccionado;
        private bool _procesandoSeleccion = false;
        private string? _ultimoCodigoArticuloSeleccionado;
        private int _ultimoIndiceSeleccionado = -1;
        private readonly BindingList<ProductoResumen> _productosResumen = [];

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
            _ultimoCodigoArticuloSeleccionado = "";

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

        private static double CalcularPrecioVenta(ArticuloStock articulo)
        {
            return articulo.Costo + (articulo.Costo * (articulo.Ganancia / 100));
        }

        private static (int cantidad, double total) CalcularTotales(List<ArticuloStock> productos)
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

            // Asegurar que el DataGridView puede recibir el foco y selecciones
            DgvProductosSeleccionados.TabStop = true;
            DgvProductosSeleccionados.Enabled = true;



            ConfigurarColumnasDataGridView();
        }

        private void SeleccionarFilaPorCodigoArticulo(string codigoArticulo)
        {
            for (int i = 0; i < DgvProductosSeleccionados.Rows.Count; i++)
            {
                if (DgvProductosSeleccionados.Rows[i].DataBoundItem is ProductoResumen producto &&
                    producto.Cod_Articulo == codigoArticulo)
                {
                    DgvProductosSeleccionados.ClearSelection();
                    DgvProductosSeleccionados.Rows[i].Selected = true;
                    DgvProductosSeleccionados.CurrentCell = DgvProductosSeleccionados.Rows[i].Cells[1];

                    // Actualizar el seguimiento
                    _ultimoCodigoArticuloSeleccionado = codigoArticulo;
                    _ultimoIndiceSeleccionado = i;
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
            if (_evitarBucleEventos) return;

            if (CmbProducto.SelectedItem is ArticuloStock selectedItem)
            {
                LblProducto.Text = selectedItem.Art_Desc;
                LblPrecio.Text = CalcularPrecioVenta(selectedItem).ToString("C2");

                // Seleccionar la fila correspondiente en el DataGridView
                _evitarBucleEventos = true;
                SeleccionarFilaPorCodigoArticulo(selectedItem.Cod_Articulo); // <- Quitar Convert.ToInt32
                _evitarBucleEventos = false;
            }
            else
            {
                LblProducto.Text = string.Empty;
                LblPrecio.Text = string.Empty;
                if (!_evitarBucleEventos)
                {
                    DgvProductosSeleccionados.ClearSelection();
                }
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

                _evitarBucleEventos = true;
                CargarDataGridView();

                // Después de agregar, seleccionar el producto añadido
                SeleccionarFilaPorCodigoArticulo(producto.Cod_Articulo);

                // Actualizar las variables de seguimiento
                for (int i = 0; i < DgvProductosSeleccionados.Rows.Count; i++)
                {
                    if (DgvProductosSeleccionados.Rows[i].DataBoundItem is ProductoResumen prod &&
                        prod.Cod_Articulo == producto.Cod_Articulo)
                    {
                        _ultimoCodigoArticuloSeleccionado = producto.Cod_Articulo;
                        _ultimoIndiceSeleccionado = i;
                        break;
                    }
                }

                _evitarBucleEventos = false;
            }
            else
            {
                MostrarMensajeAdvertencia("Por favor, selecciona un producto.");
            }
        }

        private static void AgregarProductosAlCarrito(ArticuloStock producto, int cantidad)
        {
            for (int i = 0; i < cantidad; i++)
            {
                SingleListas.Instance.ProductosSeleccionados.Add(producto);
            }
        }

        private void CargarDataGridView()
        {
            // Guardar la selección actual antes de recargar
            string? codigoArticuloSeleccionado = _ultimoCodigoArticuloSeleccionado;
            int indiceSeleccionado = _ultimoIndiceSeleccionado;

            ListaProductos(SingleListas.Instance.ProductosSeleccionados);

            var (cantidad, total) = CalcularTotales(SingleListas.Instance.ProductosSeleccionados);
            LblCantProductos.Text = cantidad.ToString();
            LblPrecioTotal.Text = total.ToString("C2");

            // Restaurar la selección basada en el código o índice
            bool seleccionRestaurada = false;

            if (!string.IsNullOrEmpty(codigoArticuloSeleccionado))
            {
                // Primero intentar por código de artículo
                for (int i = 0; i < DgvProductosSeleccionados.Rows.Count; i++)
                {
                    if (DgvProductosSeleccionados.Rows[i].DataBoundItem is ProductoResumen producto &&
                        producto.Cod_Articulo == codigoArticuloSeleccionado)
                    {
                        DgvProductosSeleccionados.ClearSelection();
                        DgvProductosSeleccionados.Rows[i].Selected = true;
                        DgvProductosSeleccionados.CurrentCell = DgvProductosSeleccionados.Rows[i].Cells[1];

                        SeleccionarProductoEnComboBox(codigoArticuloSeleccionado);
                        _ultimoIndiceSeleccionado = i;
                        seleccionRestaurada = true;
                        break;
                    }
                }
            }

            if (!seleccionRestaurada && indiceSeleccionado >= 0 && DgvProductosSeleccionados.Rows.Count > 0)
            {
                // Si no se encontró por código, intentar por índice
                int nuevoIndice = Math.Min(indiceSeleccionado, DgvProductosSeleccionados.Rows.Count - 1);

                DgvProductosSeleccionados.ClearSelection();
                DgvProductosSeleccionados.Rows[nuevoIndice].Selected = true;
                DgvProductosSeleccionados.CurrentCell = DgvProductosSeleccionados.Rows[nuevoIndice].Cells[1];

                if (DgvProductosSeleccionados.Rows[nuevoIndice].DataBoundItem is ProductoResumen nuevoProducto)
                {
                    SeleccionarProductoEnComboBox(nuevoProducto.Cod_Articulo);
                    _ultimoCodigoArticuloSeleccionado = nuevoProducto.Cod_Articulo;
                    _ultimoIndiceSeleccionado = nuevoIndice;
                    seleccionRestaurada = true;
                }
            }

            if (!seleccionRestaurada && DgvProductosSeleccionados.Rows.Count > 0)
            {
                // Seleccionar la primera fila como fallback
                DgvProductosSeleccionados.ClearSelection();
                DgvProductosSeleccionados.Rows[0].Selected = true;
                DgvProductosSeleccionados.CurrentCell = DgvProductosSeleccionados.Rows[0].Cells[1];

                if (DgvProductosSeleccionados.Rows[0].DataBoundItem is ProductoResumen nuevoProducto)
                {
                    SeleccionarProductoEnComboBox(nuevoProducto.Cod_Articulo);
                    _ultimoCodigoArticuloSeleccionado = nuevoProducto.Cod_Articulo;
                    _ultimoIndiceSeleccionado = 0;
                }
            }
            else if (DgvProductosSeleccionados.Rows.Count == 0)
            {
                // Limpiar si no hay productos
                LimpiarSeleccion();
                _ultimoCodigoArticuloSeleccionado = null;
                _ultimoIndiceSeleccionado = -1;
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

                var result = await _ventaService.Add(hVentas, [.. _productosResumen]);

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

            LimpiarSeleccion();
            NumericUpDown1.Value = 1;
            LblCantProductos.Text = "0";
            LblPrecioTotal.Text = 0m.ToString("C2");

            // Resetear las variables de seguimiento
            _ultimoCodigoArticuloSeleccionado = null;
            _ultimoIndiceSeleccionado = -1;
        }

        private void LimpiarSeleccion()
        {
            _evitarBucleEventos = true;

            CmbProducto.SelectedIndex = -1;
            DgvProductosSeleccionados.ClearSelection();
            LblProducto.Text = string.Empty;
            LblPrecio.Text = string.Empty;
            ActualizarTotalPrecioPorCantidad();

            _evitarBucleEventos = false;
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            QuitarUnidadSeleccionada();
        }

        private void QuitarUnidadSeleccionada()
        {
            if (DgvProductosSeleccionados.CurrentRow?.DataBoundItem is ProductoResumen articulo)
            {
                // Guardar la posición actual antes de eliminar
                int indiceActual = DgvProductosSeleccionados.CurrentRow.Index;
                string? codigoActual = articulo.Cod_Articulo; // Cambiado a string? para permitir valores nulos

                if (!string.IsNullOrEmpty(codigoActual)) // Validar que el código no sea nulo o vacío
                {
                    var articuloQuitar = SingleListas.Instance.ProductosSeleccionados
                        .FirstOrDefault(p => p.Cod_Articulo == codigoActual);

                    if (articuloQuitar != null)
                    {
                        SingleListas.Instance.ProductosSeleccionados.Remove(articuloQuitar);

                        _evitarBucleEventos = true;
                        CargarDataGridView();

                        // Después de recargar, restaurar la selección
                        if (DgvProductosSeleccionados.Rows.Count > 0)
                        {
                            // Intentar mantener la misma posición si es posible
                            int nuevoIndice = Math.Min(indiceActual, DgvProductosSeleccionados.Rows.Count - 1);

                            DgvProductosSeleccionados.ClearSelection();
                            DgvProductosSeleccionados.Rows[nuevoIndice].Selected = true;
                            DgvProductosSeleccionados.CurrentCell = DgvProductosSeleccionados.Rows[nuevoIndice].Cells[1];

                            // Actualizar el ComboBox con la nueva selección
                            if (DgvProductosSeleccionados.Rows[nuevoIndice].DataBoundItem is ProductoResumen nuevoProducto)
                            {
                                SeleccionarProductoEnComboBox(nuevoProducto.Cod_Articulo);
                                _ultimoCodigoArticuloSeleccionado = nuevoProducto.Cod_Articulo;
                                _ultimoIndiceSeleccionado = nuevoIndice;
                            }
                        }
                        else
                        {
                            // Si no hay filas, limpiar todo
                            LimpiarSeleccion();
                            _ultimoCodigoArticuloSeleccionado = null;
                            _ultimoIndiceSeleccionado = -1;
                        }

                        _evitarBucleEventos = false;
                    }
                }
            }
            else if (SingleListas.Instance.ProductosSeleccionados.Count > 0)
            {
                // Si no hay fila seleccionada pero hay productos, usar la última selección recordada
                _evitarBucleEventos = true;
                CargarDataGridView();

                if (DgvProductosSeleccionados.Rows.Count > 0)
                {
                    int indiceASeleccionar = _ultimoIndiceSeleccionado >= 0 ?
                        Math.Min(_ultimoIndiceSeleccionado, DgvProductosSeleccionados.Rows.Count - 1) : 0;

                    DgvProductosSeleccionados.ClearSelection();
                    DgvProductosSeleccionados.Rows[indiceASeleccionar].Selected = true;
                    DgvProductosSeleccionados.CurrentCell = DgvProductosSeleccionados.Rows[indiceASeleccionar].Cells[1];

                    if (DgvProductosSeleccionados.Rows[indiceASeleccionar].DataBoundItem is ProductoResumen nuevoProducto)
                    {
                        SeleccionarProductoEnComboBox(nuevoProducto.Cod_Articulo);
                        _ultimoCodigoArticuloSeleccionado = nuevoProducto.Cod_Articulo;
                        _ultimoIndiceSeleccionado = indiceASeleccionar;
                    }
                }
                _evitarBucleEventos = false;
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
                    else if (NumericUpDown1.Focused)
                    {
                        BtnAceptar.PerformClick();
                        e.Handled = true;
                    }
                    else if (DgvProductosSeleccionados.Focused)
                    {
                        // Permitir quitar también desde el DataGridView con Enter
                        QuitarUnidadSeleccionada();
                        e.Handled = true;
                    }
                    break;
                case Keys.Delete:
                    if (DgvProductosSeleccionados.Focused)
                    {
                        QuitarUnidadSeleccionada();
                        e.Handled = true;
                    }
                    break;
            }
        }

        private void DgvProductosSeleccionados_SelectionChanged(object sender, EventArgs e)
        {
            if (_procesandoSeleccion || _evitarBucleEventos) return;

            _procesandoSeleccion = true;
            try
            {
                if (DgvProductosSeleccionados.CurrentRow?.DataBoundItem is ProductoResumen productoSeleccionado)
                {
                    _indiceSeleccionado = DgvProductosSeleccionados.CurrentRow.Index;
                    _ultimoCodigoArticuloSeleccionado = productoSeleccionado.Cod_Articulo;
                    _ultimoIndiceSeleccionado = _indiceSeleccionado;

                    // Actualizar el ComboBox para que coincida con la selección del DataGridView
                    _evitarBucleEventos = true;
                    SeleccionarProductoEnComboBox(productoSeleccionado.Cod_Articulo);
                    _evitarBucleEventos = false;
                }
            }
            finally
            {
                _procesandoSeleccion = false;
            }
        }

        private void SeleccionarProductoEnComboBox(string codigoArticulo)
        {
            if (CmbProducto.Items.Count == 0 || _evitarBucleEventos) return;

            bool encontrado = false;

            // Buscar el artículo en el ComboBox
            for (int i = 0; i < CmbProducto.Items.Count; i++)
            {
                if (CmbProducto.Items[i] is ArticuloStock articulo && articulo.Cod_Articulo == codigoArticulo)
                {
                    // Desvincular temporalmente el evento para evitar el bucle
                    CmbProducto.SelectedIndexChanged -= CmbProducto_SelectedIndexChanged;
                    CmbProducto.SelectedIndex = i;
                    CmbProducto.SelectedIndexChanged += CmbProducto_SelectedIndexChanged;

                    // Actualizar los labels
                    LblProducto.Text = articulo.Art_Desc;
                    LblPrecio.Text = CalcularPrecioVenta(articulo).ToString("C2");
                    ActualizarTotalPrecioPorCantidad();

                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                // Si no encuentra el producto, deseleccionar el ComboBox
                CmbProducto.SelectedIndexChanged -= CmbProducto_SelectedIndexChanged;
                CmbProducto.SelectedIndex = -1;
                CmbProducto.SelectedIndexChanged += CmbProducto_SelectedIndexChanged;

                LblProducto.Text = string.Empty;
                LblPrecio.Text = string.Empty;
                ActualizarTotalPrecioPorCantidad();
            }
        }

        #region Métodos de utilidad para mensajes
        private static void MostrarMensajeAdvertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private static void MostrarMensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void MostrarMensajeExito(string mensaje)
        {
            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private void DgvProductosSeleccionados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Deshabilitar temporalmente los eventos
                _evitarBucleEventos = true;

                try
                {
                    var selectedRow = DgvProductosSeleccionados.Rows[e.RowIndex];
                    if (selectedRow.DataBoundItem is ProductoResumen producto)
                    {
                        // Buscar y seleccionar el item correspondiente en el ComboBox
                        for (int i = 0; i < CmbProducto.Items.Count; i++)
                        {
                            if (CmbProducto.Items[i] is ArticuloStock articulo &&
                                articulo.Cod_Articulo == producto.Cod_Articulo)
                            {
                                CmbProducto.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                finally
                {
                    _evitarBucleEventos = false;
                }
            }
        }
    }
}