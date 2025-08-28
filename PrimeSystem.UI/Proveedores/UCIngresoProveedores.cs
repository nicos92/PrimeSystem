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

namespace PrimeSystem.UI.Proveedores
{
    public partial class UCIngresoProveedores : UserControl
    {
       
        private readonly IProveedoresService _proveedor;
        private Modelo.Entidades.Proveedores _proveedorSeleccionado;

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
        public UCIngresoProveedores(IProveedoresService proveedoresService)
        {
            _proveedor = proveedoresService;
            InitializeComponent();
            _proveedorSeleccionado = new Modelo.Entidades.Proveedores();

            _epCuit = new ErrorProvider();
            _vTxtCuit = new ValidadorCUIT(TxtCuit, _epCuit)
            {
                MensajeError = "El CUIT ingresado no es válido.\nIngrese 11 digitos ###########.\nSino tiene CUIT ingrese cero (0)"
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

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea ingresar el proveedor?", "Confirmación de ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return; // Salir si el usuario no confirma
            }
            CrearProveedor();
            Result<Modelo.Entidades.Proveedores> resultado = _proveedor.Add(_proveedorSeleccionado);

            if (resultado.IsSuccess)
            {
                MessageBox.Show("Proveedor ingresado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Util.LimpiarForm(TLPForm, TxtCuit);
            }
            else
            {
                MessageBox.Show($"{resultado.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearProveedor()
        {
            _proveedorSeleccionado = new Modelo.Entidades.Proveedores
            {
                Proveedor = TxtProveedor.Text,
                CUIT = TxtCuit.Text,
                Nombre = TxtNombre.Text,
                Tel = TxtTel.Text,
                Email = TxtEmail.Text
            };
        }

        private void UCIngresoProveedores_Load(object sender, EventArgs e)
        {
            ConfigBtns();
            TxtCuit.Focus();
        }

        private void TxtCuit_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple([BtnIngresar], _vTxtCuit, _vTxtProveedor, _vTxtNombre, _vTxtTel, _vTxtEmail);
        }

        private void ConfigBtns()
        {
            BtnIngresar.Tag = AppColorsBlue.Primary;
        }

        private void BtnIngresar_EnabledChanged(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.Tag is Color color)
                {
                    btn.BackColor = btn.Enabled ? color : AppColorsBlue.Secondary;
                }
            }
        }
    }
}
