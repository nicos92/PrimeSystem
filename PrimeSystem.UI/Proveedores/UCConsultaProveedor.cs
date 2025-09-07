using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Utilidades;
using PrimeSystem.Modelo.Entidades;
using PrimeSystem.Utilidades.Validaciones;


namespace PrimeSystem.UI.Proveedores
{
    public partial class UCConsultaProveedor : UserControl
    {

        private readonly IProveedoresService _proveedoresService;
        private Modelo.Entidades.Proveedores _proveedorSeleccionado;
        private int indiceSeleccionado;

        private readonly ValidadorTextBox _vTxtCuit;
        private readonly ValidadorTextBox _vTxtProveedor;
        private readonly ValidadorTextBox _vTxtNombre;
        private readonly ValidadorTextBox _vTxtTel;
        private readonly ValidadorTextBox _vTxtEmail;
        private readonly ErrorProvider _epCuit;
        private readonly ErrorProvider _epProveedor;
        private readonly ErrorProvider _epNombre;
        private readonly ErrorProvider _epTel;
        private readonly ErrorProvider _epEmail;
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UCConsultaProveedor"/>.
        /// </summary>
        /// <param name="proveedoresService">El servicio de proveedores.</param>
        public UCConsultaProveedor(IProveedoresService proveedoresService)
        {
            _proveedoresService = proveedoresService;
            indiceSeleccionado = 0;
            _proveedorSeleccionado = new Modelo.Entidades.Proveedores();
            InitializeComponent();
            _epCuit = new ErrorProvider();
            _vTxtCuit = new ValidadorCUIT(TxtCuit, _epCuit)
            {
                MensajeError = "El CUIT ingresado no es válido.\nIngrese 11 digitos (12345678901).\nSino tiene CUIT ingrese cero (0)"
            };

            _epProveedor = new ErrorProvider();
            _vTxtProveedor = new ValidadorDireccion(TxtProveedor, _epProveedor)
            {
                MensajeError = "El nombre del proveedor no puede estar vacío."
            };

            _epNombre = new ErrorProvider();
            _vTxtNombre = new ValidadorNombre(TxtNombre, _epNombre)
            {
                MensajeError = "El nombre no puede estar vacío."
            };

            _epTel = new ErrorProvider();
            _vTxtTel = new ValidadorEntero(TxtTel, _epTel)
            {
                MensajeError = "El teléfono ingresado no es válido.\nSino tiene telefono ingrese cero (0)"
            };

            _epEmail = new ErrorProvider();
            _vTxtEmail = new ValidadorEmail(TxtEmail, _epEmail)
            {
                MensajeError = "El email ingresado no es válido."
            };
        }



        /// <summary>
        /// Maneja el evento de carga del control de usuario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private async void UCConsultaProveedor_Load(object sender, EventArgs e)
        {
            await CargarProveedores();
            ConfigBtns();
            Util.BloquearBtns(ListBProveedores, TLPForm);
            Util.CalcularDGVVacio(ListBProveedores, LblLista, "Proveedores");


            TxtCuit.Focus();

        }

        /// <summary>
        /// Carga la lista de proveedores en el DataGridView.
        /// </summary>
        private async Task CargarProveedores()
        {
            var datos = await _proveedoresService.GetAll();

            if (datos.IsSuccess)
            {
                ListBProveedores.AutoGenerateColumns = false;
                ListBProveedores.DataSource = datos.Value.OrderBy(p => p.Proveedor).ToList();

            }
            else
            {
                MessageBox.Show(datos.Error, "Error en UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }





        /// <summary>
        /// Maneja el evento de clic en el botón Guardar.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea guardar los cambios?", "Confirmación de guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return; // Salir si el usuario no confirma
            }
            CrearProveedor();
            await GuardarProveedor();

        }

        /// <summary>
        /// Guarda los cambios del proveedor seleccionado.
        /// </summary>
        private async Task GuardarProveedor()
        {
            if (_proveedorSeleccionado != null && !string.IsNullOrEmpty(_proveedorSeleccionado.CUIT))
            {



                Result<Modelo.Entidades.Proveedores> resultado = _proveedoresService.Update(_proveedorSeleccionado);

                if (resultado.IsSuccess)
                {
                    MessageBox.Show("Proveedor actualizado correctamente.\n" + resultado.Value.ToString(), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string valor = _proveedorSeleccionado.CUIT;
                    await CargarProveedores();

                    Util.CalcularDGVVacio(ListBProveedores, LblLista, "Proveedores");
                    Util.SeleccionarFilaDGV(ListBProveedores, valor, ListBProveedores.Columns[0].HeaderText, ref indiceSeleccionado);
                    CargarSeleccionado();



                }
                else
                {
                    MessageBox.Show(resultado.Error, "Error al actualizar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Carga los datos del proveedor seleccionado en los controles del formulario.
        /// </summary>
        private void CargarSeleccionado()
        {
            if (ListBProveedores.Rows[indiceSeleccionado].DataBoundItem is Modelo.Entidades.Proveedores proveedor)
            {
                _proveedorSeleccionado = proveedor;
                TxtCuit.Text = _proveedorSeleccionado.CUIT ?? string.Empty;
                TxtProveedor.Text = _proveedorSeleccionado.Proveedor ?? string.Empty;
                TxtNombre.Text = _proveedorSeleccionado.Nombre ?? string.Empty;
                TxtTel.Text = _proveedorSeleccionado.Tel ?? string.Empty;
                TxtEmail.Text = _proveedorSeleccionado.Email ?? string.Empty;
            }
            else
            {
                TxtCuit.Clear();
                TxtProveedor.Clear();
                TxtNombre.Clear();
                TxtTel.Clear();
                TxtEmail.Clear();
            }
        }

        /// <summary>
        /// Crea un objeto de proveedor a partir de los datos del formulario.
        /// </summary>
        private void CrearProveedor()
        {


            _proveedorSeleccionado.CUIT = TxtCuit.Text;
            _proveedorSeleccionado.Proveedor = TxtProveedor.Text;
            _proveedorSeleccionado.Nombre = TxtNombre.Text;
            _proveedorSeleccionado.Tel = TxtTel.Text;
            _proveedorSeleccionado.Email = TxtEmail.Text;

        }



        /// <summary>
        /// Maneja el evento de clic en el botón Eliminar.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este proveedor?", "Confirmación de eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return; // Salir si el usuario no confirma
            }
            CrearProveedor();
            await EliminarProveedor();
        }

        /// <summary>
        /// Elimina el proveedor seleccionado.
        /// </summary>
        private async Task EliminarProveedor()
        {

            var resultado = _proveedoresService.Delete(_proveedorSeleccionado.Id_Proveedor);
            if (resultado.IsSuccess)
            {
                MessageBox.Show("Proveedor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await CargarProveedores();
                if (Util.CalcularDGVVacio(ListBProveedores, LblLista, "Proveedores"))
                {
                    Util.LimpiarForm(TLPForm, TxtCuit);
                    Util.BloquearBtns(ListBProveedores, TLPForm);
                }



            }
            else
            {
                MessageBox.Show(resultado.Error, "Error al eliminar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Maneja el evento de cambio de texto en el cuadro de texto de CUIT.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void TxtCuit_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple([BtnGuardar], _vTxtCuit, _vTxtProveedor, _vTxtNombre, _vTxtTel, _vTxtEmail);
        }

        /// <summary>
        /// Maneja el evento de cambio de selección en la lista de proveedores.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void ListBProveedores_SelectionChanged(object sender, EventArgs e)
        {
            indiceSeleccionado = ListBProveedores.CurrentRow?.Index ?? -1;
            CargarSeleccionado();
        }

        /// <summary>
        /// Maneja el evento de cambio de estado de habilitación del botón Guardar.
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

        /// <summary>
        /// Configura los botones del formulario.
        /// </summary>
        private void ConfigBtns()
        {
            BtnGuardar.Tag = AppColorsBlue.Tertiary;
            BtnEliminar.Tag = AppColorsBlue.Error;
        }
    }
}
