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
        private List<ArticuloStock> _todosLosProductos = [];
        // Agregar en el inicio de la clase
        private readonly CultureInfo _cultureArgentina = new CultureInfo("es-AR");

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
            // TODO: INVESTIGAR POR QUE A VECES CARGA AL LIST VIEW Y OTRAS NO
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

        private string FormatearPesoArgentino(double valor)
        {
            return valor.ToString("C", _cultureArgentina);
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

            var stylePesos = new DataGridViewCellStyle
            {
                Format = "C",
                FormatProvider = _cultureArgentina,
                Alignment = DataGridViewContentAlignment.MiddleRight
            };

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
                    HeaderText = "Producto",
                    Width = 200,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,

                },
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductoCantidad",
                    DataPropertyName = "Producto_Cantidad",
                    HeaderText = "Cantidad",
                    Width = 80,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductoPrecioUnitario",
                    DataPropertyName = "Producto_Precio",
                    HeaderText = "Precio Unitario",
                    Width = 100,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,

                    DefaultCellStyle = stylePesos
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductoPrecioTotal",
                    DataPropertyName = "Producto_PrecioxCantidad",
                    HeaderText = "Total",
                    Width = 100,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,

                    DefaultCellStyle = stylePesos
                }
            };

            foreach (var column in columns)
            {
                DgvProductosSeleccionados.Columns.Add(column);
            }
        }

        private void LsvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_evitarBucleEventos) return;

            if (LsvProductos.SelectedItem is ArticuloStock selectedItem)
            {
                LblProducto.Text = selectedItem.Art_Desc;
                LblPrecio.Text = FormatearPesoArgentino(CalcularPrecioVenta(selectedItem));

                // Seleccionar la fila correspondiente en el DataGridView
                _evitarBucleEventos = true;
                SeleccionarFilaPorCodigoArticulo(selectedItem.Cod_Articulo);
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
            decimal precio = 0m;
            if (LsvProductos.SelectedItem is ArticuloStock selectedItem)
            {
                precio = (decimal)CalcularPrecioVenta(selectedItem);
            }

            decimal total = precio * NumericUpDown1.Value;
            LblPrecioCant.Text = FormatearPesoArgentino((double)total);
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (LsvProductos.SelectedItem is ArticuloStock producto)
            {
                int cantidad = (int)NumericUpDown1.Value;
                AgregarProductosAlCarrito(producto, cantidad);

                _evitarBucleEventos = true;
                CargarDataGridView();

                // Después de agregar, seleccionar el producto añadido
                SeleccionarFilaPorCodigoArticulo(producto.Cod_Articulo);

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
            string? codigoArticuloSeleccionado = _ultimoCodigoArticuloSeleccionado;
            int indiceSeleccionado = _ultimoIndiceSeleccionado;

            ListaProductos(SingleListas.Instance.ProductosSeleccionados);

            var (cantidad, total) = CalcularTotales(SingleListas.Instance.ProductosSeleccionados);
            LblCantProductos.Text = cantidad.ToString();
            LblPrecioTotal.Text = FormatearPesoArgentino(total);

            if (_productosResumen.Count == 0)
            {
                LimpiarSeleccionCompleta();
                _ultimoCodigoArticuloSeleccionado = null;
                _ultimoIndiceSeleccionado = -1;
                return;
            }

            int indiceParaSeleccionar = -1;

            if (!string.IsNullOrEmpty(codigoArticuloSeleccionado))
            {
                indiceParaSeleccionar = _productosResumen
                    .ToList()
                    .FindIndex(p => p.Cod_Articulo == codigoArticuloSeleccionado);

                if (indiceParaSeleccionar == -1)
                {
                    // El artículo que estaba seleccionado por código ya no existe.
                    // Seleccionar la primera fila y continuar.
                    indiceParaSeleccionar = 0;
                }
            }
            else if (indiceSeleccionado >= 0)
            {
                // No había selección por código, intentar por índice.
                indiceParaSeleccionar = Math.Min(indiceSeleccionado, _productosResumen.Count - 1);
            }
            else
            {
                // Sin selección previa, seleccionar la primera fila.
                indiceParaSeleccionar = 0;
            }

            if (indiceParaSeleccionar >= 0)
            {
                DgvProductosSeleccionados.ClearSelection();
                DgvProductosSeleccionados.Rows[indiceParaSeleccionar].Selected = true;
                DgvProductosSeleccionados.CurrentCell = DgvProductosSeleccionados.Rows[indiceParaSeleccionar].Cells[1];

                if (DgvProductosSeleccionados.Rows[indiceParaSeleccionar].DataBoundItem is ProductoResumen productoSeleccionado)
                {
                    SeleccionarProductoEnListBox(productoSeleccionado.Cod_Articulo);
                    _ultimoCodigoArticuloSeleccionado = productoSeleccionado.Cod_Articulo;
                    _ultimoIndiceSeleccionado = indiceParaSeleccionar;
                }
            }
            else
            {
                LimpiarSeleccionCompleta();
            }
        }

        private void LimpiarSeleccionCompleta()
        {
            _evitarBucleEventos = true;

            LsvProductos.SelectedIndex = -1;
            DgvProductosSeleccionados.ClearSelection();
            LblProducto.Text = string.Empty;
            LblPrecio.Text = string.Empty;
            LblPrecioCant.Text = 0m.ToString("C2");
            NumericUpDown1.Value = 1;

            _evitarBucleEventos = false;
        }


        private async void FormVentas_Load(object sender, EventArgs e)
        {
            // Configurar primero los controles
            ConfigurarDGV();
            ConfigurarListBox();
            DgvProductosSeleccionados.DataSource = _productosResumen;

            // Luego cargar productos asíncronamente
            await CargarProductosAsync();

            // Forzar un refresh visual
            this.Refresh();
        }

        private void ConfigurarListBox()
        {
            // Configuración del control ListBox que reemplaza al ListView
            LsvProductos.DisplayMember = "Art_Desc";
            LsvProductos.ValueMember = "Cod_Articulo";
            LsvProductos.SelectionMode = SelectionMode.One;
        }

        private void FiltrarYMostrarProductos()
        {
            try
            {
                string filtro = TxtBuscardor.Text.Trim().ToLowerInvariant();

                var productosFiltrados = _todosLosProductos
                    .Where(p => string.IsNullOrEmpty(filtro) || p.Art_Desc.ToLowerInvariant().Contains(filtro) || p.Cod_Articulo.StartsWith(filtro))
                    .ToList();

                LsvProductos.BeginUpdate();
                LsvProductos.Items.Clear();

                foreach (var articulo in productosFiltrados)
                {
                    LsvProductos.Items.Add(articulo);
                }

                // Seleccionar el primer item si existe
                if (LsvProductos.Items.Count > 0)
                {
                    LsvProductos.SelectedIndex = 0;
                }
                else
                {
                    LsvProductos_SelectedIndexChanged(this, EventArgs.Empty);
                }

                LsvProductos.EndUpdate();

                // Forzar redibujado
                LsvProductos.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en FiltrarYMostrarProductos: {ex.Message}");

            }
        }

        private async Task CargarProductosAsync()
        {
            try
            {
                // Mostrar indicador de carga
                LsvProductos.Visible = false;
                Cursor = Cursors.WaitCursor;

                var result = await _articuloStockService.GetAllArticuloStock();
                if (result.IsSuccess)
                {
                    _todosLosProductos = result.Value;

                    // Invoke para asegurar ejecución en el hilo de UI
                    this.Invoke((MethodInvoker)delegate
                    {
                        FiltrarYMostrarProductos();
                        LsvProductos.Visible = true;
                    });
                }
                else
                {
                    MostrarMensajeError("Error al cargar los productos.");
                    _todosLosProductos.Clear();
                    LsvProductos.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error: {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async Task ConfirmarVentaAsync()
        {
            if (SingleListas.Instance.ProductosSeleccionados.Count == 0)
            {
                MostrarMensajeAdvertencia("No hay productos seleccionados para la venta.");
                return;
            }
            DialogResult dr = MessageBox.Show("¿Estas seguro que queres finalizar la venta?", "Confirmación de venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            await ProcesarVentaAsync();
        }
        private async void BtnConfirmarVenta_Click(object sender, EventArgs e)
        {
            await ConfirmarVentaAsync();
        }

        private async Task ProcesarVentaAsync()
        {
            try
            {
                decimal subtotal = Convert.ToDecimal(LblPrecioTotal.Text.Split('$')[1], _cultureArgentina);
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
                MostrarMensajeError($"Error al procesar venta: {ex.Message}");
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

            LsvProductos.SelectedIndex = -1;
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
            if (DgvProductosSeleccionados.CurrentRow?.DataBoundItem is not ProductoResumen articulo)
            {
                return;
            }

            var articuloQuitar = SingleListas.Instance.ProductosSeleccionados
                .FirstOrDefault(p => p.Cod_Articulo == articulo.Cod_Articulo);

            if (articuloQuitar != null)
            {
                SingleListas.Instance.ProductosSeleccionados.Remove(articuloQuitar);
                CargarDataGridView();

            }
        }

        private void QuitarFilaSeleccionada()
        {
            if (DgvProductosSeleccionados.CurrentRow?.DataBoundItem is not ProductoResumen articulo)
            {
                return;
            }

            var articuloQuitar = SingleListas.Instance.ProductosSeleccionados
                .FirstOrDefault(p => p.Cod_Articulo == articulo.Cod_Articulo);

            if (articuloQuitar != null)
            {
                SingleListas.Instance.ProductosSeleccionados.RemoveAll(p => p.Cod_Articulo == articulo.Cod_Articulo);
                CargarDataGridView();

            }
        }
        private async void FormVentas_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F8:
                    QuitarUnidadSeleccionada();
                    e.Handled = true;
                    break;
                case Keys.F9:
                    QuitarFilaSeleccionada();
                    e.Handled = true;
                    break;
                case Keys.Enter:
                    if (TxtBuscardor.Focused || LsvProductos.Focused)
                    {
                        BtnAceptar.PerformClick();
                        e.Handled = true;
                    }
                    else if (NumericUpDown1.Focused)
                    {
                        BtnAceptar.PerformClick();
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
                case Keys.F12:
                    await ConfirmarVentaAsync();
                    e.Handled = true;
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
                    // Quitar _evitarBucleEventos = true; ya que estamos en SelectionChanged
                    // y queremos que el ComboBox se actualice con las flechas del teclado
                    SeleccionarProductoEnListBox(productoSeleccionado.Cod_Articulo);
                }
            }
            finally
            {
                _procesandoSeleccion = false;
            }
        }

        private void SeleccionarProductoEnListBox(string codigoArticulo)
        {
            if (DgvProductosSeleccionados.Rows.Count == 0)
            {
                LimpiarSeleccionCompleta();
                return;
            }

            if (LsvProductos.Items.Count == 0) return;

            if (_evitarBucleEventos && !_procesandoSeleccion) return;

            var itemASeleccionar = LsvProductos.Items.OfType<ArticuloStock>()
                .FirstOrDefault(a => a.Cod_Articulo == codigoArticulo);

            LsvProductos.SelectedIndexChanged -= LsvProductos_SelectedIndexChanged;

            LsvProductos.SelectedItem = itemASeleccionar;

            if (itemASeleccionar != null)
            {
                LblProducto.Text = itemASeleccionar.Art_Desc;
                LblPrecio.Text = FormatearPesoArgentino(CalcularPrecioVenta(itemASeleccionar));
                ActualizarTotalPrecioPorCantidad();
            }
            else
            {
                // Si no se encuentra el artículo (p.ej. fue quitado), limpiar los labels
                LblProducto.Text = string.Empty;
                LblPrecio.Text = string.Empty;
                ActualizarTotalPrecioPorCantidad();
            }

            LsvProductos.SelectedIndexChanged += LsvProductos_SelectedIndexChanged;
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
                        SeleccionarProductoEnListBox(producto.Cod_Articulo);
                    }
                }
                finally
                {
                    _evitarBucleEventos = false;
                }
            }
        }

        private void FormVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            SingleListas.Instance.ProductoResumen.Clear();
            SingleListas.Instance.ProductosSeleccionados.Clear();
        }

        private void TxtBuscardor_TextChanged(object sender, EventArgs e)
        {
            FiltrarYMostrarProductos();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}