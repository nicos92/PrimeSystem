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


        private List<Modelo.Entidades.Categorias> ListaCategorias;
        private List<Modelo.Entidades.Proveedores> ListaProveedores;
        public UCIngresoArticulos(IArticulosService articulosService, ICategoriasService categoriasService, ISubcategoriaService subcategoriaService, IProveedoresService proveedoresService, IArticuloStockService articuloStockService)
        {
            _articulosService = articulosService;
            _categoriasService = categoriasService;
            _subcategoriasService = subcategoriaService;
            _proveedoresService = proveedoresService;
            _articuloStockService = articuloStockService;
            _articuloSeleccionado = new Modelo.Entidades.Articulos();

            ListaCategorias = [];
            ListaProveedores = [];
            InitializeComponent();


            _stockSeleccionado = new Modelo.Entidades.Stock();

            _epTxtDescipcion = new ErrorProvider();
            _vTxtDescripcion = new ValidadorDireccion(TxtDescripcion, _epTxtDescipcion)
            {
                MensajeError = "La Descripción no puede esta vacia"
            };

            _epTxtCantidad = new ErrorProvider();
            _vTxtCantidad = new ValidadorEntero(TxtCantidad, _epTxtCantidad)
            {
                MensajeError = "Número ingreso no valido"
            };

            _epTxtCosto = new ErrorProvider();
            _vTxtCosto = new ValidadorNumeroDecimal(TxtCosto, _epTxtCosto)
            {
                MensajeError = "Número ingresasdo no valido"
            };

            _epTxtGanancia = new ErrorProvider();
            _vTxtGanancia = new ValidadorNumeroDecimal(TxtGanancia, _epTxtGanancia)
            {
                MensajeError = "Número ingresado no valido"
            };
            _articuloStockService = articuloStockService;
        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple([BtnIngresar], _vTxtDescripcion, _vTxtCantidad, _vTxtCosto, _vTxtGanancia);
        }

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

        private void CrearStock()
        {
            // TODO: comprobar los tipos de datos entre la base de datos y windows forms
            _stockSeleccionado.Cantidad = Convert.ToDouble(TxtCantidad.Text);
            _stockSeleccionado.Costo = Convert.ToDouble(TxtCosto.Text, CultureInfo.InvariantCulture);
            _stockSeleccionado.Ganancia = Convert.ToDouble(TxtGanancia.Text, CultureInfo.InvariantCulture);


        }

        private void UCIngresoArticulos_Load(object sender, EventArgs e)
        {



            var taskHelper = new TareasLargas(PanelMedio, ProgressBar, CargaInicial, CargarCMB);
            taskHelper.Iniciar();
        }

        private async Task CargaInicial()
        {
            await Task.WhenAll(


                CargarCategorias(),
                CargarProveedores()
             );
        }

        private void CargarCMB()
        {


            CMBProveedor.DataSource = ListaProveedores;
            CMBProveedor.DisplayMember = "Proveedor";
            CMBProveedor.ValueMember = "Id_Proveedor";
            CMBCategoria.DataSource = ListaCategorias;
            CMBCategoria.DisplayMember = "Categoria";
            CMBCategoria.ValueMember = "Id_Categoria";


        }
        private async Task CargarProveedores()
        {
            var datos = await _proveedoresService.GetAll();


            if (datos.IsSuccess)
            {
                ListaProveedores = datos.Value;


            }
            else
            {
                MessageBox.Show(datos.Error, "Error en UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





        }

        private async Task CargarSubCategorias(int id)
        {
            var datos = await _subcategoriasService.GetAllxCategoria(id);

            if (datos.IsSuccess)
            {
                List<Subcategoria> subcategorias = datos.Value;
                CMBSubcategoria.DataSource = subcategorias;
                CMBSubcategoria.DisplayMember = "Sub_categoria";
                CMBSubcategoria.ValueMember = "Id_Subcategoria";

            }
            else
            {
                MessageBox.Show(datos.Error, "Error en UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarCategorias()
        {
            var datos = await _categoriasService.GetAll();


            if (datos.IsSuccess)
            {
                ListaCategorias = datos.Value;

            }
            else
            {
                MessageBox.Show(datos.Error, "Error en UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private async void CMBCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMBCategoria.SelectedItem is Categorias categoria)
            {
                int id = categoria.Id_categoria;
                await CargarSubCategorias(id);
            }
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (!CrearArticulo())
            {
                MessageBox.Show("Articulo no creado", "articulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CrearStock();

            TareasLargas tarea = new(PanelMedio, ProgressBar, InsertarArticuloStock, () => { Util.LimpiarForm(TLPForm, TxtDescripcion); });
            tarea.Iniciar();
        }

        public async Task InsertarArticuloStock()
        {

            // Obtener el último código de artículo de forma segura
            var ultimoCodigoResult = await _articulosService.GetMaxCodArt();

           
            int codigo = ultimoCodigoResult.IsSuccess ? ultimoCodigoResult.Value : 100000;

            // Asignar el nuevo código a los objetos
            string nuevoCodigo = (codigo + 1).ToString();
            _articuloSeleccionado.Cod_Articulo = nuevoCodigo;
            _stockSeleccionado.Cod_Articulo = nuevoCodigo;

            // Intentar la inserción en el servicio
            var insercionResult = await _articuloStockService.Add(_articuloSeleccionado, _stockSeleccionado);

            // Validar si la inserción fue exitosa
            if (insercionResult.IsSuccess)
            {
                MessageBox.Show("Ingreso correcto", "Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // En caso de error en la inserción, mostrar el mensaje de error
                MessageBox.Show(insercionResult.Error, "Error en la inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
