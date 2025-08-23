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
    public partial class UCIgresoCliente : UserControl
    {
        private readonly IClientesService _clienteService;
        private Modelo.Entidades.Clientes _clienteSeleccionado;

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
        public UCIgresoCliente(IClientesService clientesService)
        {
            _clienteService = clientesService;
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

        private void TxtCuit_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple([BtnIngresar], _vTxtCuit, _vTxtEntidad, _vTxtNombre, _vTxtTel, _vTxtEmail);
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea ingresar el cliente?", "Confirmación de ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return; // Salir si el usuario no confirma
            }

            CrearCliente();
            Result<Modelo.Entidades.Clientes> resultado = _clienteService.Add(_clienteSeleccionado);

            if (resultado.IsSuccess)
            {
                MessageBox.Show("Cliente ingresado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Util.LimpiarForm(TLPForm, TxtCuit);
            }
            else
            {
                MessageBox.Show($"{resultado.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearCliente()
        {
            _clienteSeleccionado = new Modelo.Entidades.Clientes
            {
                Entidad = TxtEntidad.Text,
                CUIT = TxtCuit.Text,
                Nombre = TxtNombre.Text,
                Tel = TxtTel.Text,
                Mail = TxtEmail.Text
            };
        }

        private void UCIgresoCliente_Load(object sender, EventArgs e)
        {
            TxtCuit.Focus();
        }
    }
}
