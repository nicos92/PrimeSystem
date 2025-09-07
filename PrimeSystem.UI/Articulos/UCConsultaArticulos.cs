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

       

       

        /// <summary>
        /// Configura las propiedades iniciales de los botones en el formulario.
        /// </summary>
        private void ConfigurarBotones()
        {
            BtnGuardar.Tag = AppColorsBlue.Tertiary;
            BtnEliminar.Tag = AppColorsBlue.Error;
        }

        #endregion

        #region Eventos de UI

        /// <summary>
        /// Maneja el evento de carga del control de usuario. Inicia la carga de datos iniciales.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void UCConsultaArticulos_Load(object sender, EventArgs e)
        {
            var taskHelper = new TareasLargas(
                PanelMedio,
                ProgressBar,
                CargaInicial,
                CargarCombosYDataGrid);
            taskHelper.Iniciar();
        }

        /// <summary>
        /// Maneja el evento de clic en el botón Guardar. Valida el formulario y guarda los datos del artículo y stock.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
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

        /// <summary>
        /// Maneja el evento de clic en el botón Eliminar. Elimina el artículo y stock seleccionados.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
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

        /// <summary>
        /// Maneja el evento de cambio de selección en la lista de artículos. Carga los datos del artículo seleccionado en el formulario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
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

        /// <summary>
        /// Maneja el evento de cambio de texto en el cuadro de texto de descripción. Valida el formulario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple(
                [BtnGuardar],
                _validadorDescripcion,
                _validadorCantidad,
                _validadorCosto,
                _validadorGanancia);
        }

        /// <summary>
        /// Maneja el evento de cambio de selección en el ComboBox de categorías. Carga las subcategorías correspondientes.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private async void CMBCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMBCategoria.SelectedItem is Categorias categoria)
            {
                await CargarSubCategorias(categoria.Id_categoria);
            }
        }

        /// <summary>
        /// Maneja los errores de datos en el DataGridView.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
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

        /// <summary>
        /// Maneja el evento de cambio de estado de habilitación del botón Guardar. Cambia el color de fondo del botón.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void BtnGuardar_EnabledChanged(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Color color)
            {
                btn.BackColor = btn.Enabled ? color : AppColorsBlue.Secondary;
            }
        }

        #endregion

        #region Métodos de Carga de Datos

        /// <summary>
        /// Realiza la carga inicial de datos de forma asíncrona.
        /// </summary>
        private async Task CargaInicial()
        {
            await Task.WhenAll(
                CargarArticulos(),
                CargarStocks(),
                CargarCategorias(),
                CargarProveedores()
            );
        }

        /// <summary>
        /// Carga los ComboBoxes y el DataGridView con los datos iniciales.
        /// </summary>
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

        /// <summary>
        /// Carga la lista de artículos desde el servicio de forma asíncrona.
        /// </summary>
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

        /// <summary>
        /// Carga la lista de stocks desde el servicio de forma asíncrona.
        /// </summary>
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

        /// <summary>
        /// Carga la lista de categorías desde el servicio de forma asíncrona.
        /// </summary>
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

        /// <summary>
        /// Carga la lista de proveedores desde el servicio de forma asíncrona.
        /// </summary>
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

        /// <summary>
        /// Carga las subcategorías de una categoría específica de forma asíncrona.
        /// </summary>
        /// <param name="idCategoria">El ID de la categoría.</param>
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

        /// <summary>
        /// Valida los campos del formulario.
        /// </summary>
        /// <returns>True si el formulario es válido, de lo contrario False.</returns>
        private bool ValidarFormulario()
        {
            return _validadorDescripcion.Validar() &&
                   _validadorCantidad.Validar() &&
                   _validadorCosto.Validar() &&
                   _validadorGanancia.Validar();
        }

        /// <summary>
        /// Valida si hay un artículo seleccionado para eliminar.
        /// </summary>
        /// <returns>True si hay un artículo seleccionado, de lo contrario False.</returns>
        private bool ValidarSeleccionParaEliminar()
        {
            return _articuloSeleccionado != null && _articuloSeleccionado.Id_Articulo != 0;
        }

        /// <summary>
        /// Muestra un cuadro de diálogo de confirmación de eliminación.
        /// </summary>
        /// <returns>True si el usuario confirma la eliminación, de lo contrario False.</returns>
        private static bool ConfirmarEliminacion()
        {
            var resultado = MessageBox.Show(
                "¿Está seguro de que desea eliminar este artículo?",
                "Confirmación de eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return resultado == DialogResult.Yes;
        }

        /// <summary>
        /// Crea o actualiza un objeto de artículo a partir de los datos del formulario.
        /// </summary>
        /// <returns>True si el objeto se creó o actualizó correctamente, de lo contrario False.</returns>
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

        /// <summary>
        /// Crea o actualiza un objeto de stock a partir de los datos del formulario.
        /// </summary>
        /// <returns>True si el objeto se creó o actualizó correctamente, de lo contrario False.</returns>
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

        /// <summary>
        /// Carga los datos del artículo seleccionado en el formulario para su edición.
        /// </summary>
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

        /// <summary>
        /// Carga los ComboBoxes con los valores seleccionados del artículo.
        /// </summary>
        private void CargarCombosSeleccion()
        {
            if (CMBCategoria.Items.Count > 0)
                CMBCategoria.SelectedValue = _articuloSeleccionado.Cod_Categoria;

            if (CMBProveedor.Items.Count > 0)
                CMBProveedor.SelectedValue = _articuloSeleccionado.Id_Proveedor;

            if (CMBSubcategoria.Items.Count > 0)
                CMBSubcategoria.SelectedValue = _articuloSeleccionado.Cod_Subcat;
        }

        /// <summary>
        /// Limpia los campos del formulario y restablece los objetos de artículo y stock seleccionados.
        /// </summary>
        private void LimpiarFormulario()
        {
            TxtDescripcion.Clear();
            TxtCantidad.Clear();
            TxtCosto.Clear();
            TxtGanancia.Clear();

            _articuloSeleccionado = new Modelo.Entidades.Articulos();
            _stockSeleccionado = new Stock();
        }

        /// <summary>
        /// Verifica si hay una selección válida en la lista de artículos.
        /// </summary>
        /// <returns>True si hay una selección válida, de lo contrario False.</returns>
        private bool HaySeleccionValida()
        {
            return ListBArticulos.Rows.Count > 0 && ListBArticulos.SelectedRows.Count > 0;
        }

        #endregion

        #region Métodos de Operaciones de Datos

        /// <summary>
        /// Guarda los cambios en el artículo y el stock de forma asíncrona.
        /// </summary>
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

        /// <summary>
        /// Elimina el artículo y el stock seleccionados de forma asíncrona.
        /// </summary>
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

        /// <summary>
        /// Actualiza las listas de artículos y stock.
        /// </summary>
        private void ActualizarListas()
        {
            Util.ActualizarEnLista(_listaArticulos, _articuloSeleccionado);
            Util.ActualizarEnLista(_listaStock, _stockSeleccionado);
            CargarArticulosDataGridView();
        }

        /// <summary>
        /// Elimina el artículo y el stock seleccionados de las listas.
        /// </summary>
        private void EliminarDeListas()
        {
            Util.EliminarDeLista(_listaArticulos, _articuloSeleccionado);
            Util.EliminarDeLista(_listaStock, _stockSeleccionado);
        }

        #endregion

        #region Métodos de UI Helpers

        /// <summary>
        /// Carga los datos de los artículos en el DataGridView.
        /// </summary>
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

        /// <summary>
        /// Actualiza el DataGridView y borra la selección.
        /// </summary>
        private void ActualizarDataGridView()
        {
            CargarArticulosDataGridView();
            ListBArticulos.ClearSelection();
        }

        /// <summary>
        /// Muestra un cuadro de mensaje.
        /// </summary>
        /// <param name="mensaje">El mensaje a mostrar.</param>
        /// <param name="titulo">El título del cuadro de mensaje.</param>
        /// <param name="icono">El icono a mostrar en el cuadro de mensaje.</param>
        private static void MostrarMensaje(string mensaje, string titulo, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);
        }

        #endregion
    }
}