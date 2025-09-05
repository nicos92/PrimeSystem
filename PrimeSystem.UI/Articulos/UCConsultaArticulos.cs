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


            TareasLargas tarea = new(PanelMedio, ProgressBar, GuardarArticuloStock, () => { ModificarDatoLista(); ListBArticulos.Refresh(); });
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
            if (string.IsNullOrEmpty(TxtCantidad.Text) || string.IsNullOrEmpty(TxtCosto.Text) || string.IsNullOrEmpty(TxtGanancia.Text))
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


            CMBProveedor.DataSource = ListaProveedores ?? [];
            CMBProveedor.DisplayMember = "Proveedor";
            CMBProveedor.ValueMember = "Id_Proveedor";
            CMBCategoria.DataSource = ListaCategorias ?? [];
            CMBCategoria.DisplayMember = "Categoria";
            CMBCategoria.ValueMember = "Id_Categoria";
            CargarArticulosDGV();



        }


        private void CargarArticulosDGV()
        {
            try
            {
                // Suspender la actualización para evitar flickering
                ListBArticulos.SuspendLayout();

                // Guardar la posición actual del scroll
                int firstDisplayedScrollingRowIndex = ListBArticulos.FirstDisplayedScrollingRowIndex;

                ListBArticulos.AutoGenerateColumns = false;
                ListBArticulos.DataSource = null;
                ListBArticulos.DataSource = ListaArticulos ?? [];

                // Restaurar la posición del scroll si es posible
                if (firstDisplayedScrollingRowIndex >= 0 && firstDisplayedScrollingRowIndex < ListBArticulos.Rows.Count)
                {
                    ListBArticulos.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar DataGridView: {ex.Message}");
            }
            finally
            {
                ListBArticulos.ResumeLayout();
            }

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

            // Actualizar el DataGridView después de modificar
            CargarArticulosDGV();
        }








        private void ListBArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {


            // Verificar que hay filas y que hay una selección válida
            if (ListBArticulos.Rows.Count == 0 || ListBArticulos.SelectedRows.Count == 0)
            {
                LimpiarFormulario();
                return;
            }

            // Obtener el índice de forma segura
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

        private void LimpiarFormulario()
        {
            TxtDescripcion.Clear();
            TxtCantidad.Clear();
            TxtCosto.Clear();
            TxtGanancia.Clear();
            _articuloSeleccionado = new Modelo.Entidades.Articulos();
            _stockSeleccionado = new Modelo.Entidades.Stock();
        }

        private void CargarFormularioEdicion()
        {
            if (ListBArticulos.Rows.Count == 0 || _indiceSeleccionado < 0 || _indiceSeleccionado >= ListBArticulos.Rows.Count)
            {
                LimpiarFormulario();
                return;
            }

            var row = ListBArticulos.Rows[_indiceSeleccionado];

           

                if (row.DataBoundItem is Modelo.Entidades.Articulos articulo) // aca sale el error System.IndexOutOfRangeException: 'El índice 0 no tiene un valor.'
                {
                    _articuloSeleccionado = articulo;
                    string? codigo = _articuloSeleccionado.Cod_Articulo;

                    _stockSeleccionado = ListaStock.FirstOrDefault(s => s.Cod_Articulo == codigo) ?? new Modelo.Entidades.Stock();

                    // Cargar datos en los controles
                    TxtDescripcion.Text = _articuloSeleccionado.Art_Desc ?? string.Empty;
                    TxtCantidad.Text = _stockSeleccionado.Cantidad.ToString();
                    TxtCosto.Text = _stockSeleccionado.Costo.ToString();
                    TxtGanancia.Text = _stockSeleccionado.Ganancia.ToString();

                    // Cargar combos de forma segura
                    CargarCombosSeleccion();
                }
                else
                {
                    LimpiarFormulario();
                }
            
        }

        private void CargarCombosSeleccion()
        {
            // Cargar selecciones de forma segura
            if (CMBCategoria.Items.Count > 0)
                CMBCategoria.SelectedValue = _articuloSeleccionado.Cod_Categoria;

            if (CMBProveedor.Items.Count > 0)
                CMBProveedor.SelectedValue = _articuloSeleccionado.Id_Proveedor;

            if (CMBSubcategoria.Items.Count > 0)
                CMBSubcategoria.SelectedValue = _articuloSeleccionado.Cod_Subcat;
        }

        private void BloquearBtns()
        {

            // Verificar si hay filas seleccionadas y si la lista no está vacía
            bool haySeleccion = ListBArticulos.SelectedRows.Count > 0 && ListaArticulos.Count > 0;

            BtnEliminar.Enabled = haySeleccion;
            BtnGuardar.Enabled = haySeleccion;

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



            // La tarea ahora llama a un nuevo método para volver a enlazar y suscribir el evento.
            TareasLargas tarea = new(PanelMedio, ProgressBar, EliminarArticuloStock, ()=>
            {
                // Limpiar el formulario después de eliminar
                LimpiarFormulario(); ActualizarDataGridView();
            });
            tarea.Iniciar();
        }

        private void ActualizarDataGridView()
        {
            // Forzar la actualización completa del DataGridView
            CargarArticulosDGV();

            // Limpiar selección
            ListBArticulos.ClearSelection();

            // Actualizar estado de botones
            //BloquearBtns();
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
            if (sender is Button btn && btn.Tag is Color color)
            {

                btn.BackColor = btn.Enabled ? color : AppColorsBlue.Secondary;

            }
        }
        private void ConfigBtns()
        {
            BtnGuardar.Tag = AppColorsBlue.Tertiary;
            BtnEliminar.Tag = AppColorsBlue.Error;
        }

        private void ListBArticulos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Evitar que se muestre el diálogo de error por defecto
            e.ThrowException = false;

            // Opcional: registrar el error o mostrar un mensaje personalizado
            Console.WriteLine($"Error en DataGridView: {e.Exception.Message }");
        }
    }
}
