using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accessibility;
using Microsoft.Extensions.Logging;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Modelo;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Servicio;
using PrimeSystem.Utilidades;

namespace PrimeSystem.UI.Compras
{
    public partial class UCIngresoCompra : UserControl
    {
        private readonly IArticuloStockService _articuloStockService;
        private readonly ICompraService _compraDetalleService;
        private readonly IProveedoresService _proveedorService;
        private readonly ILogger<UCIngresoCompra> _logger;
        private bool _evitarBucleEventos = false;
        private int _indiceSeleccionado;
        private bool _procesandoSeleccion = false;
        private string? _ultimoCodigoArticuloSeleccionado;
        private int _ultimoIndiceSeleccionado = -1;
        private readonly BindingList<ProductoResumen> _productosResumen = [];
        private List<ArticuloStock> _todosLosProductos = [];
        // Agregar en el inicio de la clase
        private readonly CultureInfo _cultureArgentina = new("es-AR");
        private int _idProveedorSeleccionado;
        public UCIngresoCompra(IArticuloStockService articuloStockService,
                             ICompraService compraDetalleService,
                             IProveedoresService proveedorService,
                             ILogger<UCIngresoCompra> logger)
        {
            _articuloStockService = articuloStockService;
            _compraDetalleService = compraDetalleService;
            _proveedorService = proveedorService;
            _logger = logger;
            _indiceSeleccionado = 0;
            _ultimoCodigoArticuloSeleccionado = "";
            _idProveedorSeleccionado = 0;

            InitializeComponent();

            this.Disposed += UCIngresoCompra_Disposed;
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
                    Producto_Precio = CalcularPrecioCompra(g.First()),
                    Producto_Cantidad = g.Count(),
                    Producto_PrecioxCantidad = g.Sum(p => CalcularPrecioCompra(p))
                });

            foreach (var producto in productosAgrupados)
            {
                _productosResumen.Add(producto);
            }
        }

        private static double CalcularPrecioCompra(ArticuloStock articulo)
        {
            // Para compras, usamos directamente el costo del artículo
            return articulo.Costo;
        }

        private string FormatearPesoArgentino(double valor)
        {
            return valor.ToString("C", _cultureArgentina);
        }

        private static (int cantidad, double total) CalcularTotales(List<ArticuloStock> productos)
        {
            int cantidad = productos.Count;
            double total = productos.Sum(p => CalcularPrecioCompra(p));

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
                LblPrecio.Text = FormatearPesoArgentino(CalcularPrecioCompra(selectedItem));

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
                precio = (decimal)CalcularPrecioCompra(selectedItem);
            }

            decimal total = precio * NumericUpDown1.Value;
            LblPrecioCant.Text = FormatearPesoArgentino((double)total);
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (LsvProductos.SelectedItem is ArticuloStock producto)
            {
                int cantidad = (int)NumericUpDown1.Value;
                if (SingleListas.Instance.ProductosSeleccionados.Count == 0)
                {
                    _idProveedorSeleccionado = producto.Id_Proveedor;
                    LblLista.Text = "Lista de productos de " + CmbProveedor.Text;


                    AgregarProductosAlCarrito(producto, cantidad);

                    _evitarBucleEventos = true;
                    CargarDataGridView();

                    // Después de agregar, seleccionar el producto añadido
                    SeleccionarFilaPorCodigoArticulo(producto.Cod_Articulo);

                    _evitarBucleEventos = false;
                }
                else
                {
                    if (producto.Id_Proveedor != _idProveedorSeleccionado)
                    {
                        MostrarMensajeError("No se pueden agregar productos de diferentes proveedores en la misma compra. Por favor, limpia el carrito antes de agregar productos de otro proveedor.");
                        return;
                    }
                    AgregarProductosAlCarrito(producto, cantidad);
                    _evitarBucleEventos = true;
                    CargarDataGridView();
                    // Después de agregar, seleccionar el producto añadido
                    SeleccionarFilaPorCodigoArticulo(producto.Cod_Articulo);
                    _evitarBucleEventos = false;
                }
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

        private async void UCIngresoCompra_Load(object sender, EventArgs e)
        {
            _logger.LogInformation("Cargando UCIngresoCompra.");
            // Configurar primero los controles
            ConfigurarDGV();
            ConfigurarListBox();
            DgvProductosSeleccionados.DataSource = _productosResumen;

            // Asegurar que el UserControl pueda recibir teclas
            this.Focus();
            this.Select();
            // Establecer el foco en el primer control relevante
            TxtBuscardor.Focus();

            // Cargar proveedores
            await CargarProveedoresAsync();

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
                    .Where(p => string.IsNullOrEmpty(filtro) || p.Art_Desc.Contains(filtro, StringComparison.InvariantCultureIgnoreCase) || p.Cod_Articulo.StartsWith(filtro))
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
                    int idproveedor = CmbProveedor.SelectedItem is Modelo.Entidades.Proveedores proveedor ? proveedor.Id_Proveedor : 0;
                    _todosLosProductos = [.. result.Value.Where(p => p.Id_Proveedor == idproveedor)];

                    // Invoke para asegurar ejecución en el hilo de UI
                    this.Invoke((MethodInvoker)delegate
                    {
                        FiltrarYMostrarProductos();
                        LsvProductos.Visible = true;
                    });
                }
                else
                {
                    MostrarMensajeError("Error al cargar los productos. " + result.Error);
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

        private async Task CargarProveedoresAsync()
        {
            try
            {
                CmbProveedor.Items.Clear();
                CmbProveedor.DisplayMember = "Nombre";
                CmbProveedor.ValueMember = "Id_Proveedor";

                var result = await _proveedorService.GetAll();
                if (result.IsSuccess)
                {
                    CmbProveedor.DataSource = result.Value;
                    if (CmbProveedor.Items.Count > 0)
                    {
                        CmbProveedor.SelectedIndex = 0;
                    }
                }
                else
                {
                    MostrarMensajeError("Error al cargar los proveedores. " + result.Error);
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error al cargar proveedores: {ex.Message}");
            }
        }

        private async Task ConfirmarCompraAsync()
        {
            if (SingleListas.Instance.ProductosSeleccionados.Count == 0)
            {
                MostrarMensajeAdvertencia("No hay productos seleccionados para la compra.");
                return;
            }

            if (CmbProveedor.SelectedItem == null)
            {
                MostrarMensajeAdvertencia("Por favor, seleccione un proveedor.");
                return;
            }

            DialogResult dr = MessageBox.Show("¿Estas seguro que queres finalizar la compra?", "Confirmación de compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            await ProcesarCompraAsync();
        }

        private async void BtnConfirmarCompra_Click(object sender, EventArgs e)
        {
            await ConfirmarCompraAsync();
        }

        private async Task ProcesarCompraAsync()
        {
            Result<bool>? result = null;
            try
            {
                decimal subtotal = Convert.ToDecimal(LblPrecioTotal.Text.Split('$')[1], _cultureArgentina);
                decimal descuento = 0; // En compras, por ahora no aplicamos descuento

                var hCompras = new HCompras
                {
                    Cod_Usuario = 1, // TODO: Obtener el usuario actual
                    Id_Proveedor = ((PrimeSystem.Modelo.Entidades.Proveedores)CmbProveedor.SelectedItem).Id_Proveedor,
                    Fecha_Hora = DateTime.Now,
                    Descuento = descuento,
                    Subtotal = subtotal,
                    Total = subtotal - descuento
                };

                result = await _compraDetalleService.Add(hCompras, [.. _productosResumen]);

                if (result.IsSuccess)
                {
                    MostrarMensajeExito("Compra procesada correctamente.");
                    LimpiarFormulario();
                }
                else
                {
                    MostrarMensajeError("Error al procesar la compra: " + result.Error);
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error al procesar compra UI: {ex.Message} " + result?.Error);
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

            // Resetear selección de proveedor
            if (CmbProveedor.Items.Count > 0)
            {
                CmbProveedor.SelectedIndex = 0;
            }
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
                if (SingleListas.Instance.ProductosSeleccionados.Count == 0)
                {
                    _idProveedorSeleccionado = 0;
                    LblLista.Text = "Lista de productos";
                }
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

                    if (productoSeleccionado.Cod_Articulo != null)
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
                LblPrecio.Text = FormatearPesoArgentino(CalcularPrecioCompra(itemASeleccionar));
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
                    if (selectedRow.DataBoundItem is ProductoResumen producto && producto.Cod_Articulo != null)
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

        private void UCIngresoCompra_Disposed(object sender, EventArgs e)
        {
            SingleListas.Instance.ProductoResumen.Clear();
            SingleListas.Instance.ProductosSeleccionados.Clear();
        }

        private void TxtBuscardor_TextChanged(object sender, EventArgs e)
        {
            FiltrarYMostrarProductos();
        }

        /// <summary>
        /// Procesa las teclas de función y otros comandos antes de que sean procesados por el control
        /// </summary>
        /// <param name="msg">Mensaje de ventana</param>
        /// <param name="keyData">Tecla presionada</param>
        /// <returns>True si la tecla fue procesada, false en caso contrario</returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F8:
                    QuitarUnidadSeleccionada();
                    return true;

                case Keys.F9:
                    QuitarFilaSeleccionada();
                    return true;

                case Keys.Enter:
                    if (TxtBuscardor.Focused || LsvProductos.Focused || NumericUpDown1.Focused)
                    {
                        BtnAceptar.PerformClick();
                        return true;
                    }
                    break;

                case Keys.Delete:
                    if (DgvProductosSeleccionados.Focused)
                    {
                        QuitarUnidadSeleccionada();
                        return true;
                    }
                    break;

                case Keys.F12:
                    _ = ConfirmarCompraAsync(); // Usamos el operador de descarte (_) para no esperar
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private async void CmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            await CargarProductosAsync();
        }
    }
}