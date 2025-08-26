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

        private Modelo.Entidades.Articulos _articuloSeleccionado;

        private readonly ValidadorTextBox _vTxtDescripcion;
        private readonly ValidadorTextBox _vTxtCantidad;
        private readonly ValidadorTextBox _vTxtCosto;
        private readonly ValidadorTextBox _vTxtGanancia;

        private readonly ErrorProvider _epTxtDescipcion;
        private readonly ErrorProvider _epTxtCantidad;
        private readonly ErrorProvider _epTxtCosto;
        private readonly ErrorProvider _epTxtGanancia;
        public UCIngresoArticulos(IArticulosService articulosService, ICategoriasService categoriasService, ISubcategoriaService subcategoriaService)
        {
            _articulosService = articulosService;
            _categoriasService = categoriasService;
            _subcategoriasService = subcategoriaService;
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

            _articuloSeleccionado = new Modelo.Entidades.Articulos
            {
                Art_Desc = TxtDescripcion.Text,
                Cod_Categoria = categoria.Id_categoria,
                Cod_Subcat = subcategoria.Id_Subcategoria,
                Id_Proveedor = proveedor.Id_Proveedor
            };
            /* TODO: 
             * obtener el ultimo codigo de articulo.
             * usar el codigo para ingresar el articulo.
             * ingresar el articulo.
             * ingresar el stock
             */
            
        }
    }
}
