using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades;
using PrimeSystem.Utilidades.Validaciones;

namespace PrimeSystem.UI.Articulos
{
    public partial class UCConsultaArticulos : UserControl
    {
        private readonly IArticulosService _articulosService;
        private readonly ICategoriasService _categoriasService;
        private readonly ISubcategoriaService _subcategoriasService;
        private readonly IProveedoresService _proveedoresService;
        private readonly IStockService _stockService;
        private readonly IArticuloStockService _articuloStockService;
        private Modelo.Entidades.Articulos _articuloSeleccionado;
        private Modelo.Entidades.Stock _stockSeleccionado;

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
        private List<Modelo.Entidades.Articulos> ListaArticulos;
        private List<Modelo.Entidades.Stock> ListaStock;

        private int _indiceSeleccionado;
        public UCConsultaArticulos(IArticulosService articulosService, ICategoriasService categoriasService, ISubcategoriaService subcategoriaService, IProveedoresService proveedoresService, IStockService stockService, IArticuloStockService articuloStockService)
        {
            _articulosService = articulosService;
            _categoriasService = categoriasService;
            _subcategoriasService = subcategoriaService;
            _proveedoresService = proveedoresService;
            _stockService = stockService;
            _articuloStockService = articuloStockService;
            _articuloSeleccionado = new Modelo.Entidades.Articulos();

            ListaCategorias = [];
            ListaProveedores = [];
            ListaArticulos = [];
            ListaStock = [];
            _indiceSeleccionado = 0;
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



        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!CrearArticulo())
            {
                MessageBox.Show("Articulo no creado", "articulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!CrearStock()) return;

            
            TareasLargas tarea = new(PanelMedio, ProgressBar, GuardarArticuloStock, () => { ListBArticulos.Refresh(); });
            tarea.Iniciar();
        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple([BtnGuardar], _vTxtDescripcion, _vTxtCantidad, _vTxtCosto, _vTxtGanancia);
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

        private bool CrearStock()
        {
            if (string.IsNullOrEmpty(TxtCantidad.Text)|| string.IsNullOrEmpty(TxtCosto.Text)||string.IsNullOrEmpty(TxtGanancia.Text))
            {
                MessageBox.Show("Articulo Vacio no se puede eliminar", "Error Seleccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            _stockSeleccionado.Cantidad = Convert.ToInt32(TxtCantidad.Text);
            _stockSeleccionado.Costo = Convert.ToDouble(TxtCosto.Text);
            _stockSeleccionado.Ganancia = Convert.ToDouble(TxtGanancia.Text);
            return true;


        }

        private void UCConsultaArticulos_Load(object sender, EventArgs e)
        {



            var taskHelper = new TareasLargas(PanelMedio, ProgressBar, CargaInicial, CargarCMB);
            taskHelper.Iniciar();
            ConfigBtns();
        }

        private async Task CargaInicial()
        {
            await Task.WhenAll(

                CargarArticulos(),
                CargarStocks(),
                CargarCategorias(),
                CargarProveedores()
             );
        }

        private async Task CargarStocks()
        {
            var datos = await _stockService.GetAll();


            if (datos.IsSuccess)
            {
                ListaStock.Clear();
                ListaStock = datos.Value;


            }
            else
            {
                MessageBox.Show(datos.Error, "Error en UI stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarArticulos()
        {
            var datos = await _articulosService.GetAll();


            if (datos.IsSuccess)
            {
                ListaArticulos.Clear();
                ListaArticulos = datos.Value;


            }
            else
            {
                MessageBox.Show(datos.Error, "Error en UI articulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCMB()
        {


            CMBProveedor.DataSource = ListaProveedores;
            CMBProveedor.DisplayMember = "Proveedor";
            CMBProveedor.ValueMember = "Id_Proveedor";
            CMBCategoria.DataSource = ListaCategorias;
            CMBCategoria.DisplayMember = "Categoria";
            CMBCategoria.ValueMember = "Id_Categoria";
            CargarArticulosDGV();



        }


        private void CargarArticulosDGV()
        {
            ListBArticulos.AutoGenerateColumns = false;
            ListBArticulos.DataSource = null;
            ListBArticulos.DataSource = ListaArticulos;

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
                MessageBox.Show(datos.Error, "Error en UI proveedores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





        }

        private async Task CargarSubCategorias(int id)
        {
            var datos = await _subcategoriasService.GetAllxCategoria(id);

            if (datos.IsSuccess)
            {
                CMBSubcategoria.DataSource = datos.Value;
                CMBSubcategoria.DisplayMember = "Sub_categoria";
                CMBSubcategoria.ValueMember = "Id_Subcategoria";

            }
            else
            {
                MessageBox.Show(datos.Error, "Error en UI sub categorias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CargarCategorias()
        {
            var datos = await _categoriasService.GetAll();


            if (datos.IsSuccess)
            {
                ListaCategorias.Clear();
                ListaCategorias = datos.Value;

            }
            else
            {
                MessageBox.Show(datos.Error, "Error en UI categorias", MessageBoxButtons.OK, MessageBoxIcon.Error);
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



        public async Task GuardarArticuloStock()
        {
           



            var actualizacionResult = await _articuloStockService.Update(_articuloSeleccionado, _stockSeleccionado);

            if (actualizacionResult.IsSuccess)
            {
                MessageBox.Show("Actualización correcta", "Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ModificarDatoLista();
            }
            else
            {
                MessageBox.Show(actualizacionResult.Error, "Error en la actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


       

        private void ModificarDatoLista()
        {
            // Call the generic method for both lists
            Util.ActualizarEnLista(ListaArticulos, _articuloSeleccionado);
            Util.ActualizarEnLista(ListaStock, _stockSeleccionado);
        }

        






        private void ListBArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            _indiceSeleccionado = ListBArticulos.CurrentRow?.Index ?? -1; // Obtener el índice de la fila seleccionada o -1 si no hay selección
            CargarDormularioEdicion();


            
        }

        private void CargarDormularioEdicion()
        {
            if (ListBArticulos.Rows.Count == 0)
            {
                TxtDescripcion.Clear();
                TxtCantidad.Clear();
                TxtCosto.Clear();
                TxtGanancia.Clear();
                _articuloSeleccionado = new Modelo.Entidades.Articulos();
                _stockSeleccionado = new Modelo.Entidades.Stock();
                return;
            }

            if (_indiceSeleccionado >= 0 && _indiceSeleccionado < ListBArticulos.Rows.Count && ListBArticulos.Rows[_indiceSeleccionado].DataBoundItem is Modelo.Entidades.Articulos articulo)
            {
                _articuloSeleccionado = articulo;
                string? codigo = _articuloSeleccionado.Cod_Articulo;


                _stockSeleccionado = ListaStock.FirstOrDefault(s => s.Cod_Articulo == codigo);
                if (_stockSeleccionado == null)
                {
                    _stockSeleccionado = new Modelo.Entidades.Stock();
                }

                TxtDescripcion.Text = _articuloSeleccionado.Art_Desc ?? string.Empty;
                TxtCantidad.Text = _stockSeleccionado.Cantidad.ToString();
                TxtCosto.Text = _stockSeleccionado.Costo.ToString();
                TxtGanancia.Text = _stockSeleccionado.Ganancia.ToString();

                CMBCategoria.SelectedValue = _articuloSeleccionado.Cod_Categoria;
                CMBProveedor.SelectedValue = _articuloSeleccionado.Id_Proveedor;
                CMBSubcategoria.SelectedValue = _articuloSeleccionado.Cod_Subcat;
            }
            else
            {
                TxtDescripcion.Clear();
                TxtCantidad.Clear();
                TxtCosto.Clear();
                TxtGanancia.Clear();
                _articuloSeleccionado = new Modelo.Entidades.Articulos();
                _stockSeleccionado = new Modelo.Entidades.Stock();
            }
        }

        private void BloquearBtns()
        {

            if (ListBArticulos.SelectedRows == null)
            {

                BtnEliminar.Enabled = false;
                BtnGuardar.Enabled = false;
            }
            else
            {
                BtnEliminar.Enabled = true;
                BtnGuardar.Enabled = true;
            }

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Primero, verificar que haya un artículo seleccionado para eliminar.
            if (_articuloSeleccionado == null || _articuloSeleccionado.Id_Articulo == 0)
            {
                MessageBox.Show("Por favor, seleccione un artículo de la lista para eliminar.", "Ningún artículo seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este artículo?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return; // Salir si el usuario no confirma
            }

            // Desactivar el manejador de eventos para evitar que se ejecute durante la actualización.
            ListBArticulos.SelectionChanged -= ListBArticulos_SelectedIndexChanged;

            // La tarea ahora llama a un nuevo método para volver a enlazar y suscribir el evento.
            TareasLargas tarea = new(PanelMedio, ProgressBar, EliminarArticuloStock, RebindGridAndResubscribe);
            tarea.Iniciar();
        }

        private void RebindGridAndResubscribe()
        {
            CargarArticulosDGV();
            // Volver a suscribir el manejador de eventos.
            ListBArticulos.SelectionChanged += ListBArticulos_SelectedIndexChanged;

            // Actualizar manualmente el estado de la selección y el formulario.
            _indiceSeleccionado = ListBArticulos.CurrentRow?.Index ?? -1;
            CargarDormularioEdicion();
        }

        private async Task EliminarArticuloStock()
        {
            
            var resultado = await _articuloStockService.Delete(_articuloSeleccionado, _stockSeleccionado);
            if (resultado.IsSuccess)
            {
                MessageBox.Show("Articulo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


              
                

                // Call the generic method to delete from both lists
                Util.EliminarDeLista(ListaArticulos, _articuloSeleccionado);
                Util.EliminarDeLista(ListaStock, _stockSeleccionado);

               



            }
            else
            {
                MessageBox.Show(resultado.Error, "Error al eliminar Articulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

      
        private void BtnGuardar_EnabledChanged(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.Tag is Color color)
                {
                    btn.BackColor = btn.Enabled ? color : AppColorsBlue.Secondary;
                }
            }
        }
        private void ConfigBtns()
        {
            BtnGuardar.Tag = AppColorsBlue.Tertiary;
            BtnEliminar.Tag = AppColorsBlue.Error;
        }
    }
}
