using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;
using PrimeSystem.Utilidades.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace PrimeSystem.UI.Articulos
{
    public partial class UCIngresoArticulos : UserControl
    {
        private IArticulosService _articulosService;
        private ICategoriasService _categoriasService;
        private ISubcategoriaService _subcategoriasService;
        private IProveedoresService _proveedoresService;

        private Modelo.Entidades.Articulos _articuloSeleccionado;

        private readonly ValidadorTextBox _vTxtDescripcion;
        private readonly ValidadorTextBox _vTxtCantidad;
        private readonly ValidadorTextBox _vTxtCosto;
        private readonly ValidadorTextBox _vTxtGanancia;

        private readonly ErrorProvider _epTxtDescipcion;
        private readonly ErrorProvider _epTxtCantidad;
        private readonly ErrorProvider _epTxtCosto;
        private readonly ErrorProvider _epTxtGanancia;
        public UCIngresoArticulos(IArticulosService articulosService, ICategoriasService categoriasService, ISubcategoriaService subcategoriaService, IProveedoresService proveedoresService)
        {
            _articulosService = articulosService;
            _categoriasService = categoriasService;
            _subcategoriasService = subcategoriaService;
            _proveedoresService = proveedoresService;
            _articuloSeleccionado = new Modelo.Entidades.Articulos();
            InitializeComponent();

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
            _proveedoresService = proveedoresService;
        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple([BtnIngresar], _vTxtDescripcion, _vTxtCantidad, _vTxtCosto, _vTxtGanancia);
        }

        private void CrearArticulo()
        {
            if (CMBCategoria.SelectedItem is not Modelo.Entidades.Categorias categoria)
            {
                MessageBox.Show("El tipo de Categoria seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CMBCategoria.SelectedItem is not Modelo.Entidades.Subcategoria subcategoria)
            {
                MessageBox.Show("El tipo de Categoria seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CMBCategoria.SelectedItem is not Modelo.Entidades.Proveedores proveedor)
            {
                MessageBox.Show("El tipo de Categoria seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            _articuloSeleccionado.Art_Desc = TxtDescripcion.Text;
            _articuloSeleccionado.Cod_Categoria = categoria.Id_categoria;
            _articuloSeleccionado.Cod_Subcat = subcategoria.Id_Subcategoria;
            _articuloSeleccionado.Id_Proveedor = proveedor.Id_Proveedor;

            /* TODO: 
             * obtener el ultimo codigo de articulo.
             * usar el codigo para ingresar el articulo.
             * ingresar el articulo.
             * ingresar el stock
             */

        }

        private async void UCIngresoArticulos_Load(object sender, EventArgs e)
        {
            await Task.WhenAll(


                CargarCategorias(),
                CargarProveedores()
             );
        }

        private async Task CargarProveedores()
        {
            var datos = await _proveedoresService.GetAll();

            if (datos.IsSuccess)
            {
                List<Modelo.Entidades.Proveedores> proveedores = datos.Value;
                CMBProveedor.DataSource = proveedores;
                CMBProveedor.DisplayMember = "Proveedor";
                CMBProveedor.ValueMember = "Id_Proveedor";

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
                List<Categorias> categorias = datos.Value;
                CMBCategoria.DataSource = categorias;
                CMBCategoria.DisplayMember = "Categoria";
                CMBCategoria.ValueMember = "Id_Categoria";

            }
            else
            {
                MessageBox.Show(datos.Error, "Error en UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CMBProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void CMBCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMBCategoria.SelectedItem is Categorias categoria)
            {
            int id = categoria.Id_categoria;
            await CargarSubCategorias(id);
            }
        }
    }
}
