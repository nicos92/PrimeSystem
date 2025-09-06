using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;
using PrimeSystem.Utilidades.Validaciones;

namespace PrimeSystem.UI.Articulos
{
    [SupportedOSPlatform("windows")]
    public partial class UCConsultaArticulos : UserControl
    {
        #region Campos y Servicios

        private readonly IArticulosService _articulosService;
        private readonly ICategoriasService _categoriasService;
        private readonly ISubcategoriaService _subcategoriasService;
        private readonly IProveedoresService _proveedoresService;
        private readonly IStockService _stockService;
        private readonly IArticuloStockService _articuloStockService;

        private Modelo.Entidades.Articulos _articuloSeleccionado;
        private Stock _stockSeleccionado;

        private readonly ValidadorTextBox _validadorDescripcion;
        private readonly ValidadorTextBox _validadorCantidad;
        private readonly ValidadorTextBox _validadorCosto;
        private readonly ValidadorTextBox _validadorGanancia;

        private readonly ErrorProvider _errorProviderDescripcion;
        private readonly ErrorProvider _errorProviderCantidad;
        private readonly ErrorProvider _errorProviderCosto;
        private readonly ErrorProvider _errorProviderGanancia;

        private List<Categorias> _listaCategorias;
        private List<Modelo.Entidades.Proveedores> _listaProveedores;
        private List<Modelo.Entidades.Articulos> _listaArticulos;
        private List<Stock> _listaStock;

        private int _indiceSeleccionado;

        #endregion

        #region Constructor

        public UCConsultaArticulos(
            IArticulosService articulosService,
            ICategoriasService categoriasService,
            ISubcategoriaService subcategoriaService,
            IProveedoresService proveedoresService,
            IStockService stockService,
            IArticuloStockService articuloStockService)
        {
            InitializeComponent();

            // Inyección de dependencias
            _articulosService = articulosService ;
            _categoriasService = categoriasService ;
            _subcategoriasService = subcategoriaService ;
            _proveedoresService = proveedoresService;
            _stockService = stockService;
            _articuloStockService = articuloStockService;

            // Inicialización de campos
            _articuloSeleccionado = new Modelo.Entidades.Articulos();
            _stockSeleccionado = new Stock();

            _listaCategorias = [];
            _listaProveedores = [];
            _listaArticulos = [];
            _listaStock = [];

            _indiceSeleccionado = -1;


            // Inicialización de validadores y configuración de botones
            // Configuración de validadores con proveedores de error
            _errorProviderDescripcion = new ErrorProvider();
            _validadorDescripcion = new ValidadorDireccion(TxtDescripcion, _errorProviderDescripcion)
            {
                MensajeError = "La descripción no puede estar vacía"
            };

            _errorProviderCantidad = new ErrorProvider();
            _validadorCantidad = new ValidadorEntero(TxtCantidad, _errorProviderCantidad)
            {
                MensajeError = "Número ingresado no válido"
            };

            _errorProviderCosto = new ErrorProvider();
            _validadorCosto = new ValidadorNumeroDecimal(TxtCosto, _errorProviderCosto)
            {
                MensajeError = "Número ingresado no válido"
            };

            _errorProviderGanancia = new ErrorProvider();
            _validadorGanancia = new ValidadorNumeroDecimal(TxtGanancia, _errorProviderGanancia)
            {
                MensajeError = "Número ingresado no válido"
            };
            ConfigurarBotones();
        }

       

       

        private void ConfigurarBotones()
        {
            BtnGuardar.Tag = AppColorsBlue.Tertiary;
            BtnEliminar.Tag = AppColorsBlue.Error;
        }

        #endregion

        #region Eventos de UI

        private void UCConsultaArticulos_Load(object sender, EventArgs e)
        {
            var taskHelper = new TareasLargas(
                PanelMedio,
                ProgressBar,
                CargaInicial,
                CargarCombosYDataGrid);
            taskHelper.Iniciar();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
            {
                MostrarMensaje("Por favor, complete todos los campos requeridos correctamente",
                              "Datos incompletos",
                              MessageBoxIcon.Warning);
                return;
            }

            if (!CrearArticuloDesdeFormulario() || !CrearStockDesdeFormulario())
            {
                return;
            }

            var tarea = new TareasLargas(
                PanelMedio,
                ProgressBar,
                GuardarArticuloStock,
                () =>
                {
                    ActualizarListas();
                    ListBArticulos.Refresh();
                });
            tarea.Iniciar();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccionParaEliminar())
            {
                MostrarMensaje("Por favor, seleccione un artículo de la lista para eliminar",
                              "Ningún artículo seleccionado",
                              MessageBoxIcon.Warning);
                return;
            }

            if (!ConfirmarEliminacion()) return;

            var tarea = new TareasLargas(
                PanelMedio,
                ProgressBar,
                EliminarArticuloStock,
                () =>
                {
                    LimpiarFormulario();
                    ActualizarDataGridView();
                    if (Util.CalcularDGVVacio(ListBArticulos, LblLista, "Articulos"))
                    {
                        Util.LimpiarForm(TLPForm, TxtDescripcion);
                        Util.BloquearBtns(ListBArticulos, TLPForm);

                    }
                });
            tarea.Iniciar();
        }

        private void ListBArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!HaySeleccionValida())
            {
                LimpiarFormulario();
                return;
            }

            _indiceSeleccionado = ListBArticulos.CurrentRow?.Index ?? -1;

            if (_indiceSeleccionado >= 0 && _indiceSeleccionado < ListBArticulos.Rows.Count)
            {
                CargarFormularioEdicion();
            }
            else
            {
                LimpiarFormulario();
            }
        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple(
                [BtnGuardar],
                _validadorDescripcion,
                _validadorCantidad,
                _validadorCosto,
                _validadorGanancia);
        }

        private async void CMBCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMBCategoria.SelectedItem is Categorias categoria)
            {
                await CargarSubCategorias(categoria.Id_categoria);
            }
        }

        private void ListBArticulos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            // Solución CS8602: Comprobar si Exception es null antes de acceder a Message
            if (e.Exception != null)
            {
                Console.WriteLine($"Error en DataGridView: {e.Exception.Message}");
            }
            else
            {
                Console.WriteLine("Error en DataGridView: excepción desconocida.");
            }
        }

        private void BtnGuardar_EnabledChanged(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Color color)
            {
                btn.BackColor = btn.Enabled ? color : AppColorsBlue.Secondary;
            }
        }

        #endregion

        #region Métodos de Carga de Datos

        private async Task CargaInicial()
        {
            await Task.WhenAll(
                CargarArticulos(),
                CargarStocks(),
                CargarCategorias(),
                CargarProveedores()
            );
        }

        private void CargarCombosYDataGrid()
        {
            CMBProveedor.DataSource = _listaProveedores ?? [];
            CMBProveedor.DisplayMember = "Proveedor";
            CMBProveedor.ValueMember = "Id_Proveedor";

            CMBCategoria.DataSource = _listaCategorias ?? [];
            CMBCategoria.DisplayMember = "Categoria";
            CMBCategoria.ValueMember = "Id_Categoria";

            CargarArticulosDataGridView();
            if (Util.CalcularDGVVacio(ListBArticulos, LblLista, "Articulos"))
            {
                Util.LimpiarForm(TLPForm, TxtDescripcion);
                Util.BloquearBtns(ListBArticulos, TLPForm);

            }
        }

        private async Task CargarArticulos()
        {
            var resultado = await _articulosService.GetAll();

            if (resultado.IsSuccess)
            {
                _listaArticulos = resultado.Value;
            }
            else
            {
                MostrarMensaje(resultado.Error, "Error al cargar artículos", MessageBoxIcon.Error);
            }
        }

        private async Task CargarStocks()
        {
            var resultado = await _stockService.GetAll();

            if (resultado.IsSuccess)
            {
                _listaStock = resultado.Value;
            }
            else
            {
                MostrarMensaje(resultado.Error, "Error al cargar stocks", MessageBoxIcon.Error);
            }
        }

        private async Task CargarCategorias()
        {
            var resultado = await _categoriasService.GetAll();

            if (resultado.IsSuccess)
            {
                _listaCategorias = resultado.Value;
            }
            else
            {
                MostrarMensaje(resultado.Error, "Error al cargar categorías", MessageBoxIcon.Error);
            }
        }

        private async Task CargarProveedores()
        {
            var resultado = await _proveedoresService.GetAll();

            if (resultado.IsSuccess)
            {
                _listaProveedores = resultado.Value;
            }
            else
            {
                MostrarMensaje(resultado.Error, "Error al cargar proveedores", MessageBoxIcon.Error);
            }
        }

        private async Task CargarSubCategorias(int idCategoria)
        {
            var resultado = await _subcategoriasService.GetAllxCategoria(idCategoria);

            if (resultado.IsSuccess)
            {
                CMBSubcategoria.DataSource = resultado.Value;
                CMBSubcategoria.DisplayMember = "Sub_categoria";
                CMBSubcategoria.ValueMember = "Id_Subcategoria";
            }
            else
            {
                MostrarMensaje(resultado.Error, "Error al cargar subcategorías", MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Métodos de Formulario y Validación

        private bool ValidarFormulario()
        {
            return _validadorDescripcion.Validar() &&
                   _validadorCantidad.Validar() &&
                   _validadorCosto.Validar() &&
                   _validadorGanancia.Validar();
        }

        private bool ValidarSeleccionParaEliminar()
        {
            return _articuloSeleccionado != null && _articuloSeleccionado.Id_Articulo != 0;
        }

        private static bool ConfirmarEliminacion()
        {
            var resultado = MessageBox.Show(
                "¿Está seguro de que desea eliminar este artículo?",
                "Confirmación de eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return resultado == DialogResult.Yes;
        }

        private bool CrearArticuloDesdeFormulario()
        {
            if (CMBProveedor.SelectedItem is not Modelo.Entidades.Proveedores proveedor)
            {
                MostrarMensaje("El proveedor seleccionado no es válido", "Error", MessageBoxIcon.Error);
                return false;
            }

            if (CMBCategoria.SelectedItem is not Categorias categoria)
            {
                MostrarMensaje("La categoría seleccionada no es válida", "Error", MessageBoxIcon.Error);
                return false;
            }

            if (CMBSubcategoria.SelectedItem is not Subcategoria subcategoria)
            {
                MostrarMensaje("La subcategoría seleccionada no es válida", "Error", MessageBoxIcon.Error);
                return false;
            }

            _articuloSeleccionado.Art_Desc = TxtDescripcion.Text;
            _articuloSeleccionado.Id_Proveedor = proveedor.Id_Proveedor;
            _articuloSeleccionado.Cod_Categoria = categoria.Id_categoria;
            _articuloSeleccionado.Cod_Subcat = subcategoria.Id_Subcategoria;

            return true;
        }

        private bool CrearStockDesdeFormulario()
        {
            if (string.IsNullOrEmpty(TxtCantidad.Text) ||
                string.IsNullOrEmpty(TxtCosto.Text) ||
                string.IsNullOrEmpty(TxtGanancia.Text))
            {
                MostrarMensaje("Complete todos los campos de stock", "Datos incompletos", MessageBoxIcon.Error);
                return false;
            }

            _stockSeleccionado.Cantidad = Convert.ToInt32(TxtCantidad.Text);
            _stockSeleccionado.Costo = Convert.ToDouble(TxtCosto.Text);
            _stockSeleccionado.Ganancia = Convert.ToDouble(TxtGanancia.Text);

            return true;
        }

        private void CargarFormularioEdicion()
        {
            if (!HaySeleccionValida() ||
                _indiceSeleccionado < 0 ||
                _indiceSeleccionado >= ListBArticulos.Rows.Count)
            {
                LimpiarFormulario();
                return;
            }

            var fila = ListBArticulos.Rows[_indiceSeleccionado];

            if (fila.DataBoundItem is Modelo.Entidades.Articulos articulo)
            {
                _articuloSeleccionado = articulo;
                string? codigoArticuloNullable = _articuloSeleccionado.Cod_Articulo;
                string codigoArticulo = codigoArticuloNullable ?? string.Empty;

                _stockSeleccionado = _listaStock.FirstOrDefault(s => s.Cod_Articulo == codigoArticulo) ?? new Stock();

                // Cargar datos en los controles
                TxtDescripcion.Text = _articuloSeleccionado.Art_Desc ?? string.Empty;
                TxtCantidad.Text = _stockSeleccionado.Cantidad.ToString();
                TxtCosto.Text = _stockSeleccionado.Costo.ToString("F2");
                TxtGanancia.Text = _stockSeleccionado.Ganancia.ToString("F2");

                // Cargar combos
                CargarCombosSeleccion();
            }
            else
            {
                LimpiarFormulario();
            }
        }

        private void CargarCombosSeleccion()
        {
            if (CMBCategoria.Items.Count > 0)
                CMBCategoria.SelectedValue = _articuloSeleccionado.Cod_Categoria;

            if (CMBProveedor.Items.Count > 0)
                CMBProveedor.SelectedValue = _articuloSeleccionado.Id_Proveedor;

            if (CMBSubcategoria.Items.Count > 0)
                CMBSubcategoria.SelectedValue = _articuloSeleccionado.Cod_Subcat;
        }

        private void LimpiarFormulario()
        {
            TxtDescripcion.Clear();
            TxtCantidad.Clear();
            TxtCosto.Clear();
            TxtGanancia.Clear();

            _articuloSeleccionado = new Modelo.Entidades.Articulos();
            _stockSeleccionado = new Stock();
        }

        private bool HaySeleccionValida()
        {
            return ListBArticulos.Rows.Count > 0 && ListBArticulos.SelectedRows.Count > 0;
        }

        #endregion

        #region Métodos de Operaciones de Datos

        private async Task GuardarArticuloStock()
        {
            var resultado = await _articuloStockService.Update(_articuloSeleccionado, _stockSeleccionado);

            if (resultado.IsSuccess)
            {
                MostrarMensaje("Artículo actualizado correctamente", "Éxito", MessageBoxIcon.Information);
            }
            else
            {
                MostrarMensaje(resultado.Error, "Error en la actualización", MessageBoxIcon.Error);
            }
        }

        private async Task EliminarArticuloStock()
        {
            var resultado = await _articuloStockService.Delete(_articuloSeleccionado, _stockSeleccionado);

            if (resultado.IsSuccess)
            {
                MostrarMensaje("Artículo eliminado correctamente", "Éxito", MessageBoxIcon.Information);
                EliminarDeListas();
            }
            else
            {
                MostrarMensaje(resultado.Error, "Error al eliminar artículo", MessageBoxIcon.Error);
            }
        }

        private void ActualizarListas()
        {
            Util.ActualizarEnLista(_listaArticulos, _articuloSeleccionado);
            Util.ActualizarEnLista(_listaStock, _stockSeleccionado);
            CargarArticulosDataGridView();
        }

        private void EliminarDeListas()
        {
            Util.EliminarDeLista(_listaArticulos, _articuloSeleccionado);
            Util.EliminarDeLista(_listaStock, _stockSeleccionado);
        }

        #endregion

        #region Métodos de UI Helpers

        private void CargarArticulosDataGridView()
        {
            try
            {
                ListBArticulos.SuspendLayout();
                int primeraFilaVisible = ListBArticulos.FirstDisplayedScrollingRowIndex;

                ListBArticulos.AutoGenerateColumns = false;
                ListBArticulos.DataSource = null;
                ListBArticulos.DataSource = _listaArticulos ?? [];

                if (primeraFilaVisible >= 0 && primeraFilaVisible < ListBArticulos.Rows.Count)
                {
                    ListBArticulos.FirstDisplayedScrollingRowIndex = primeraFilaVisible;
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar DataGridView: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
            finally
            {
                ListBArticulos.ResumeLayout();
            }
        }

        private void ActualizarDataGridView()
        {
            CargarArticulosDataGridView();
            ListBArticulos.ClearSelection();
        }

        private static void MostrarMensaje(string mensaje, string titulo, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);
        }

        #endregion
    }
}