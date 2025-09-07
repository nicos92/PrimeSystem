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

namespace PrimeSystem.UI.Usuarios
{
    public partial class UCIngresoUsuarios : UserControl
    {
        private readonly IUsuariosService _usuariosService;
        private readonly IUsuariosTipoService _usuariosTipoService;

        private Modelo.Entidades.Usuarios _usuarioSeleccionado;

        private readonly ValidadorTextBox _vTxtDni;
        private readonly ValidadorTextBox _vTxtApellido;
        private readonly ValidadorTextBox _vTxtNombre;
        private readonly ValidadorTextBox _vTxtTel;
        private readonly ValidadorTextBox _vTxtEmail;
        private readonly ErrorProvider _epDni;
        private readonly ErrorProvider _epApellido;
        private readonly ErrorProvider _epNombre;
        private readonly ErrorProvider _epTel;
        private readonly ErrorProvider _epEmail;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UCIngresoUsuarios"/>.
        /// </summary>
        /// <param name="usuariosService">El servicio de usuarios.</param>
        /// <param name="usuariosTipoService">El servicio de tipos de usuario.</param>
        public UCIngresoUsuarios(IUsuariosService usuariosService, IUsuariosTipoService usuariosTipoService)
        {
            _usuariosService = usuariosService;
            _usuariosTipoService = usuariosTipoService;
            InitializeComponent();
            _usuarioSeleccionado = new Modelo.Entidades.Usuarios();

            _epDni = new ErrorProvider();
            _vTxtDni = new ValidadorDni(TxtDni, _epDni)
            {
                MensajeError = "El DNI ingresado no es válido.\nIngrese 8 digitos 12345678.\nSino tiene DNI ingrese cero (0)"
            };

            _epApellido = new ErrorProvider();
            _vTxtApellido = new ValidadorNombre(TxtApellido, _epApellido)
            {
                MensajeError = "El apelido del proveedor no puede estar vacío."
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
        private async void UCIngresoUsuarios_Load(object sender, EventArgs e)
        {
            TxtDni.Focus();
            ConfigBtns();
            await CargarTiposUsuarios();
        }

        /// <summary>
        /// Carga los tipos de usuario en el ComboBox.
        /// </summary>
        private async Task CargarTiposUsuarios()
        {
            CMBTipoUsuario.Items.Clear();
            var tiposUsuarios = await _usuariosTipoService.GetAll();

            if (tiposUsuarios.IsSuccess && tiposUsuarios.Value != null)
            {
                CMBTipoUsuario.DataSource = tiposUsuarios.Value;
                CMBTipoUsuario.DisplayMember = "Descripcion";
                CMBTipoUsuario.ValueMember = "Tipo";

            }
            else
            {
                MessageBox.Show("Error al cargar los tipos de usuarios: " + tiposUsuarios.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de cambio de texto en el cuadro de texto de DNI.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void TxtDni_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple([BtnIngresar], _vTxtDni, _vTxtApellido, _vTxtNombre, _vTxtTel, _vTxtEmail);
        }

        /// <summary>
        /// Crea un objeto de usuario a partir de los datos del formulario.
        /// </summary>
        private void CrearUsuario()
        {
            if (CMBTipoUsuario.SelectedValue is not int tipoUsuario)
            {
                MessageBox.Show("El tipo de usuario seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _usuarioSeleccionado = new Modelo.Entidades.Usuarios
            {
                Apellido = TxtApellido.Text,
                DNI = TxtDni.Text,
                Nombre = TxtNombre.Text,
                Tel = TxtTel.Text,
                Mail = TxtEmail.Text,
                Id_Tipo = tipoUsuario
            };
        }

        /// <summary>
        /// Maneja el evento de clic en el botón Ingresar.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea ingresar el usuario?", "Confirmación de ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return; // Salir si el usuario no confirma
            }
            CrearUsuario();
            Result<Modelo.Entidades.Usuarios> resultado = _usuariosService.Add(_usuarioSeleccionado);

            if (resultado.IsSuccess)
            {
                MessageBox.Show("Usuario ingresado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Util.LimpiarForm(TLPForm, TxtDni);
            }
            else
            {
                MessageBox.Show($"{resultado.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Configura los botones del formulario.
        /// </summary>
        private void ConfigBtns()
        {
            BtnIngresar.Tag = AppColorsBlue.Primary;
        }

        /// <summary>
        /// Maneja el evento de cambio de estado de habilitación del botón Ingresar.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
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
