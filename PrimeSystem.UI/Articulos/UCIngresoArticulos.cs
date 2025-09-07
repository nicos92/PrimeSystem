using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;
using PrimeSystem.Utilidades.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeSystem.UI.Articulos
{
    public partial class UCIngresoArticulos : UserControl
    {
        #region Atributos y Propiedades

        private readonly IArticulosService _articulosService;
        private readonly ICategoriasService _categoriasService;
        private readonly ISubcategoriaService _subcategoriasService;
        private readonly IProveedoresService _proveedoresService;
        private readonly IArticuloStockService _articuloStockService;

        private readonly Modelo.Entidades.Articulos _articuloSeleccionado;
        private readonly Modelo.Entidades.Stock _stockSeleccionado;

        private readonly ValidadorTextBox _vTxtDescripcion;
        private readonly ValidadorTextBox _vTxtCantidad;
        private readonly ValidadorTextBox _vTxtCosto;
        private readonly ValidadorTextBox _vTxtGanancia;

        private readonly ErrorProvider _epTxtDescipcion;
        private readonly ErrorProvider _epTxtCantidad;
        private readonly ErrorProvider _epTxtCosto;
        private readonly ErrorProvider _epTxtGanancia;

        private List<Modelo.Entidades.Categorias> ListaCategorias { get; set; } = [];
        private List<Modelo.Entidades.Proveedores> ListaProveedores { get; set; } = [];

        #endregion Atributos y Propiedades

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UCIngresoArticulos"/>.
        /// </summary>
        /// <param name="articulosService">El servicio de artículos.</param>
        /// <param name="categoriasService">El servicio de categorías.</param>
        /// <param name="subcategoriaService">El servicio de subcategorías.</param>
        /// <param name="proveedoresService">El servicio de proveedores.</param>
        /// <param name="articuloStockService">El servicio de stock de artículos.</param>
        public UCIngresoArticulos(IArticulosService articulosService, ICategoriasService categoriasService, ISubcategoriaService subcategoriaService, IProveedoresService proveedoresService, IArticuloStockService articuloStockService)
        {
            _articulosService = articulosService;
            _categoriasService = categoriasService;
            _subcategoriasService = subcategoriaService;
            _proveedoresService = proveedoresService;
            _articuloStockService = articuloStockService;

            InitializeComponent();

            _articuloSeleccionado = new Modelo.Entidades.Articulos();
            _stockSeleccionado = new Modelo.Entidades.Stock();

            _epTxtDescipcion = new ErrorProvider();
            _vTxtDescripcion = new ValidadorDireccion(TxtDescripcion, _epTxtDescipcion) { MensajeError = "La Descripción no puede estar vacía" };

            _epTxtCantidad = new ErrorProvider();
            _vTxtCantidad = new ValidadorEntero(TxtCantidad, _epTxtCantidad) { MensajeError = "Número ingresado no válido" };

            _epTxtCosto = new ErrorProvider();
            _vTxtCosto = new ValidadorNumeroDecimal(TxtCosto, _epTxtCosto) { MensajeError = "Número ingresado no válido" };

            _epTxtGanancia = new ErrorProvider();
            _vTxtGanancia = new ValidadorNumeroDecimal(TxtGanancia, _epTxtGanancia) { MensajeError = "Número ingresado no válido" };
        }

        #region Eventos

        /// <summary>
        /// Controla el evento TextChanged de los cuadros de texto.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">El <see cref="EventArgs"/> instancia que contiene los datos del evento.</param>
        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple([BtnIngresar], _vTxtDescripcion, _vTxtCantidad, _vTxtCosto, _vTxtGanancia);
        }

        /// <summary>
        /// Controla el evento SelectedIndexChanged del ComboBox de categorías.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">El <see cref="EventArgs"/> instancia que contiene los datos del evento.</param>
        private async void CMBCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMBCategoria.SelectedItem is Categorias categoria)
                await CargarSubCategorias(categoria.Id_categoria);
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Crea un nuevo artículo a partir de los datos introducidos por el usuario.
        /// </summary>
        /// <returns>Verdadero si el artículo se creó correctamente, falso en caso contrario.</returns>
        private bool CrearArticulo()
        {
            if (CMBProveedor.SelectedItem is not Modelo.Entidades.Proveedores proveedor)
            {
                MessageBox.Show("El tipo de Proveedor seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (CMBCategoria.SelectedItem is not Modelo.Entidades.Categorias categoria)
            {
                MessageBox.Show("El tipo de Categoria seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (CMBSubcategoria.SelectedItem is not Modelo.Entidades.Subcategoria subcategoria)
            {
                MessageBox.Show("El tipo de Sub-Categoria seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _articuloSeleccionado.Art_Desc = TxtDescripcion.Text;
            _articuloSeleccionado.Id_Proveedor = proveedor.Id_Proveedor;
            _articuloSeleccionado.Cod_Categoria = categoria.Id_categoria;
            _articuloSeleccionado.Cod_Subcat = subcategoria.Id_Subcategoria;

            return true;
        }

        /// <summary>
        /// Crea un nuevo registro de stock a partir de los datos introducidos por el usuario.
        /// </summary>
        private void CrearStock()
        {
            _stockSeleccionado.Cantidad = Convert.ToDouble(TxtCantidad.Text);
            _stockSeleccionado.Costo = Convert.ToDouble(TxtCosto.Text, CultureInfo.InvariantCulture);
            _stockSeleccionado.Ganancia = Convert.ToDouble(TxtGanancia.Text, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Maneja el evento Load del UserControl.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">El <see cref="EventArgs"/> instancia que contiene los datos del evento.</param>
        private void UCIngresoArticulos_Load(object sender, EventArgs e)
        {
            var taskHelper = new TareasLargas(PanelMedio, ProgressBar, CargaInicial, CargarCMB);
            taskHelper.Iniciar();
        }

        /// <summary>
        /// Realiza la carga inicial de datos de forma asíncrona.
        /// </summary>
        private async Task CargaInicial()
        {
            await Task.WhenAll(CargarCategorias(), CargarProveedores());
        }

        /// <summary>
        /// Carga los datos de proveedores y categorías en los ComboBox correspondientes.
        /// Se configuran las propiedades DataSource, DisplayMember y ValueMember para cada control.
        /// </summary>
        private void CargarCMB()
        {
            CMBProveedor.DataSource = ListaProveedores;
            CMBProveedor.DisplayMember = "Proveedor";
            CMBProveedor.ValueMember = "Id_Proveedor";

            CMBCategoria.DataSource = ListaCategorias;
            CMBCategoria.DisplayMember = "Categoria";
            CMBCategoria.ValueMember = "Id_Categoria";
        }

        /// <summary>
        /// Carga la lista de proveedores en el ComboBox.
        /// </summary>
        private async Task CargarProveedores()
        {
            var datos = await _proveedoresService.GetAll();
            if (!datos.IsSuccess)
                MessageBox.Show(datos.Error, "Error en UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                ListaProveedores = datos.Value;
        }

        /// <summary>
        /// Carga la lista de subcategorías en el ComboBox.
        /// </summary>
        /// <param name="id">ID de la categoría para la cual cargar las subcategorías.</param>
        private async Task CargarSubCategorias(int id)
        {
            try
            {
                var datos = await _subcategoriasService.GetAllxCategoria(id);
                if (!datos.IsSuccess)
                    MessageBox.Show(datos.Error, "Error en UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    var subcategorias = datos.Value;
                    CMBSubcategoria.DataSource = null;
                    CMBSubcategoria.DataSource = subcategorias;
                    CMBSubcategoria.DisplayMember = "Sub_categoria";
                    CMBSubcategoria.ValueMember = "Id_Subcategoria";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga la lista de categorías en el ComboBox.
        /// </summary>
        private async Task CargarCategorias()
        {
            var datos = await _categoriasService.GetAll();
            if (!datos.IsSuccess)
                MessageBox.Show(datos.Error, "Error en UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                ListaCategorias = datos.Value;
        }

        #endregion Métodos Privados

        #region Otros Metodos

        /// <summary>
        /// Controla el evento Click del botón Ingresar.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">El <see cref="EventArgs"/> instancia que contiene los datos del evento.</param>
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            // TODO: consultar si se pueden ingresar articulos sin proveedor
            if (!CrearArticulo())
            {
                MessageBox.Show("Artículo no creado", "Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CrearStock();

            var tarea = new TareasLargas(PanelMedio, ProgressBar, InsertarArticuloStock, () => Util.LimpiarForm(TLPForm, TxtDescripcion));
            tarea.Iniciar();
        }

        /// <summary>
        /// Inserta un nuevo artículo y su stock en la base de datos.
        /// </summary>
        public async Task InsertarArticuloStock()
        {
            var ultimoCodigoResult = await _articulosService.GetMaxCodArt();
            int codigo = ultimoCodigoResult.IsSuccess ? ultimoCodigoResult.Value : 100000;
            string nuevoCodigo = (codigo + 1).ToString();

            _articuloSeleccionado.Cod_Articulo = nuevoCodigo;
            _stockSeleccionado.Cod_Articulo = nuevoCodigo;

            var insercionResult = await _articuloStockService.Add(_articuloSeleccionado, _stockSeleccionado);

            if (!insercionResult.IsSuccess)
                MessageBox.Show(insercionResult.Error, "Error en la inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Ingreso correcto", "Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion Otros Metodos
    }
}
