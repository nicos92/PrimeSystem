using PrimeSystem.Contrato.Servicios;
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

namespace PrimeSystem.UI.Clientes
{
    public partial class UCConsultaClientes : UserControl
    {
        private readonly IClientesService _clienteService;
        private Modelo.Entidades.Clientes _clienteSeleccionado;

        private int indiceSeleccionado;


        private readonly ValidadorTextBox _vTxtCuit;
        private readonly ValidadorTextBox _vTxtEntidad;
        private readonly ValidadorTextBox _vTxtNombre;
        private readonly ValidadorTextBox _vTxtTel;
        private readonly ValidadorTextBox _vTxtEmail;
        private readonly ErrorProvider _epCuit;
        private readonly ErrorProvider _epEntidad;
        private readonly ErrorProvider _epNombre;
        private readonly ErrorProvider _epTel;
        private readonly ErrorProvider _epEmail;
        public UCConsultaClientes(IClientesService clientesService)
        {
            _clienteService = clientesService;
            indiceSeleccionado = 0;
            InitializeComponent();
            _clienteSeleccionado = new Modelo.Entidades.Clientes();

            _epCuit = new ErrorProvider();
            _vTxtCuit = new ValidadorCUIT(TxtCuit, _epCuit)
            {
                MensajeError = "El CUIT ingresado no es válido.\nIngrese 11 digitos ###########.\nSino tiene CUIT ingrese cero (0)"
            };

            _epEntidad = new ErrorProvider();
            _vTxtEntidad = new ValidadorDireccion(TxtEntidad, _epEntidad)
            {
                MensajeError = "La entidad no puede estar vacío."
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

        private async Task CargarClientes()
        {
            var datos = await _clienteService.GetAll();

            if (datos.IsSuccess)
            {

                ListBClientes.AutoGenerateColumns = false;
                ListBClientes.DataSource = datos.Value.OrderBy(c => c.Entidad).ToList();

            }
            else
            {
                MessageBox.Show(datos.Error, "Error en UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void UCConsultaClientes_Load(object sender, EventArgs e)
        {
            await CargarClientes();
            ConfigBtns();
            Util.BloquearBtns(ListBClientes, TLPForm);


            Util.CalcularDGVVacio(ListBClientes, LblLista, "Clientes");
            TxtCuit.Focus();
        }



        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea guardar los cambios?", "Confirmación de guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return; // Salir si el usuario no confirma
            }
            CrearCliente();
            await GuardarCliente();
        }

        private void CrearCliente()
        {


            _clienteSeleccionado.CUIT = TxtCuit.Text;
            _clienteSeleccionado.Entidad = TxtEntidad.Text;
            _clienteSeleccionado.Nombre = TxtNombre.Text;
            _clienteSeleccionado.Tel = TxtTel.Text;
            _clienteSeleccionado.Mail = TxtEmail.Text;

        }



        private async Task GuardarCliente()
        {
            if (_clienteSeleccionado != null && !string.IsNullOrEmpty(_clienteSeleccionado.CUIT))
            {



                Result<Modelo.Entidades.Clientes> resultado = _clienteService.Update(_clienteSeleccionado);

                if (resultado.IsSuccess)
                {
                    MessageBox.Show("Proveedor actualizado correctamente.\n" + resultado.Value.ToString(), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string valor = _clienteSeleccionado.CUIT;
                    await CargarClientes();
                    Util.CalcularDGVVacio(ListBClientes, LblLista, "Clientes");
                    Util.SeleccionarFilaDGV(ListBClientes, valor, ListBClientes.Columns[0].HeaderText, ref indiceSeleccionado);
                    CargarSeleccionado();


                }
                else
                {
                    MessageBox.Show(resultado.Error, "Error al actualizar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TxtCuit_TextChanged(object sender, EventArgs e)
        {

            ValidadorMultiple.ValidacionMultiple([BtnGuardar], _vTxtCuit, _vTxtEntidad, _vTxtNombre, _vTxtTel, _vTxtEmail);

        }



        private void CargarSeleccionado()
        {
            if (ListBClientes.Rows[indiceSeleccionado].DataBoundItem is Modelo.Entidades.Clientes cliente)
            {
                _clienteSeleccionado = cliente;
                TxtCuit.Text = _clienteSeleccionado.CUIT ?? string.Empty;
                TxtEntidad.Text = _clienteSeleccionado.Entidad ?? string.Empty;
                TxtNombre.Text = _clienteSeleccionado.Nombre ?? string.Empty;
                TxtTel.Text = _clienteSeleccionado.Tel ?? string.Empty;
                TxtEmail.Text = _clienteSeleccionado.Mail ?? string.Empty;
            }
            else
            {
                TxtCuit.Clear();
                TxtEntidad.Clear();
                TxtNombre.Clear();
                TxtTel.Clear();
                TxtEmail.Clear();
            }
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este cliente?", "Confirmación de eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return; // Salir si el usuario no confirma
            }
            CrearCliente();
            await EliminarCliente();
        }

        private async Task EliminarCliente()
        {

            var resultado = _clienteService.Delete(_clienteSeleccionado.Id_Cliente);
            if (resultado.IsSuccess)
            {
                MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await CargarClientes();
                if (Util.CalcularDGVVacio(ListBClientes, LblLista, "Clientes"))
                {
                    Util.LimpiarForm(TLPForm, TxtCuit);
                    Util.BloquearBtns(ListBClientes, TLPForm);

                }

            }
            else
            {
                MessageBox.Show(resultado.Error, "Error al eliminar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void ListBClientes_SelectionChanged(object sender, EventArgs e)
        {
            indiceSeleccionado = ListBClientes.CurrentRow?.Index ?? -1;
            CargarSeleccionado();
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
    }
}
