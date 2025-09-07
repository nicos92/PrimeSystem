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
    public partial class USConsultaUsuario : UserControl
    {
        private readonly IUsuariosService _usuariosService;
        private readonly IUsuariosTipoService _usuariosTipoService;

        private Modelo.Entidades.Usuarios _usuarioSeleccionado;
        private int indiceSeleccionado;
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
        /// Inicializa una nueva instancia de la clase <see cref="USConsultaUsuario בו"/>.
        /// </summary>
        /// <param name="usuariosService">El servicio de usuarios.</param>
        /// <param name="usuariosTipoService">El servicio de tipos de usuario.</param>
        public USConsultaUsuario(IUsuariosService usuariosService, IUsuariosTipoService usuariosTipoService)
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
        /// Maneja el evento Load del control USConsultaUsuario.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
        private async void USConsultaUsuario_Load(object sender, EventArgs e)
        {
            TxtDni.Focus();

            await Task.WhenAll(
                CargarTiposUsuarios(),
                CargarUsuarios()
            );
            ConfigBtns();

            Util.BloquearBtns(ListBUsuarios, TLPFormUsuario);
            Util.CalcularDGVVacio(ListBUsuarios, LblLista, "Usuarios");
            CargarPermisos();
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
        /// Maneja el evento TextChanged del control TxtDni.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
        private void TxtDni_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple([BtnGuardar], _vTxtDni, _vTxtApellido, _vTxtNombre, _vTxtTel, _vTxtEmail);
        }

        /// <summary>
        /// Crea un usuario a partir de los datos del formulario.
        /// </summary>
        private void CrearUsuario()
        {
            if (CMBTipoUsuario.SelectedValue is not int tipoUsuario)
            {
                MessageBox.Show("El tipo de usuario seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _usuarioSeleccionado ??= new Modelo.Entidades.Usuarios();

            _usuarioSeleccionado.DNI = TxtDni.Text;
            _usuarioSeleccionado.Apellido = TxtApellido.Text;
            _usuarioSeleccionado.Nombre = TxtNombre.Text;
            _usuarioSeleccionado.Tel = TxtTel.Text;
            _usuarioSeleccionado.Mail = TxtEmail.Text;
            _usuarioSeleccionado.Id_Tipo = tipoUsuario;


        }

        /// <summary>
        /// Maneja el evento Click del control BtnGuardar.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea guardar los cambios?", "Confirmación de guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return; // Salir si el usuario no confirma
            }
            CrearUsuario();
            await GuardarUsuario();
        }

        /// <summary>
        /// Guarda el usuario.
        /// </summary>
        private async Task GuardarUsuario()
        {
            if (_usuarioSeleccionado != null && !string.IsNullOrEmpty(_usuarioSeleccionado.DNI))
            {



                Result<Modelo.Entidades.Usuarios> resultado = _usuariosService.Update(_usuarioSeleccionado);

                if (resultado.IsSuccess)
                {
                    MessageBox.Show("Proveedor actualizado correctamente.\n" + resultado.Value.ToString(), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string valor = _usuarioSeleccionado.DNI;
                    await CargarUsuarios();
                    Util.CalcularDGVVacio(ListBUsuarios, LblLista, "Usuarios");

                    Util.SeleccionarFilaDGV(ListBUsuarios, valor, ListBUsuarios.Columns[0].HeaderText, ref indiceSeleccionado);
                    CargarFormularioEdicion();


                }
                else
                {
                    MessageBox.Show(resultado.Error, "Error al actualizar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Carga los usuarios en el DataGridView.
        /// </summary>
        private async Task CargarUsuarios()
        {
            var datos = await _usuariosService.GetAll();

            if (datos.IsSuccess)
            {

                ListBUsuarios.AutoGenerateColumns = false; // Desactivar la generación automática de columnas
                ListBUsuarios.DataSource = datos.Value.OrderBy(u => u.Apellido).ToList();

            }
            else
            {
                MessageBox.Show(datos.Error, "Error en UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Carga los permisos para el usuario actual.
        /// </summary>
        private void CargarPermisos()
        {

            string rolUsuario = "admin"; // Aquí deberías obtener el rol del usuario actual
            switch (rolUsuario)
            {
                case "admin":
                    CargarAdmin();
                    break;
                case "compras":
                    break;
                case "ventas":
                    break;
                case "visitante":
                    CargarVisitante();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Carga los permisos de visitante.
        /// </summary>
        private void CargarVisitante()
        {
            BtnEliminar.Visible = false;
            BtnGuardar.Visible = false;
        }

        /// <summary>
        /// Carga los permisos de administrador.
        /// </summary>
        private void CargarAdmin()
        {
            BtnEliminar.Visible = true;
            BtnGuardar.Visible = true;
        }





        /// <summary>
        /// Maneja el evento Click del control BtnEliminar.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este proveedor?", "Confirmación de eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return; // Salir si el usuario no confirma
            }
            CrearUsuario();
            await EliminarUsuario();
        }

        /// <summary>
        /// Elimina el usuario.
        /// </summary>
        private async Task EliminarUsuario()
        {

            var resultado = _usuariosService.Delete(_usuarioSeleccionado.Id_Usuario);
            if (resultado.IsSuccess)
            {
                MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await CargarUsuarios();

                if (Util.CalcularDGVVacio(ListBUsuarios, LblLista, "Usuarios"))
                {
                    Util.LimpiarForm(TLPFormUsuario, TxtDni);

                    Util.BloquearBtns(ListBUsuarios, TLPFormUsuario);

                }


            }
            else
            {
                MessageBox.Show(resultado.Error, "Error al eliminar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /// <summary>
        /// Maneja el evento SelectionChanged del control ListBUsuarios.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
        private void ListBUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            indiceSeleccionado = ListBUsuarios.CurrentRow?.Index ?? -1; // Obtener el índice de la fila seleccionada o -1 si no hay selección
            CargarFormularioEdicion();
        }

        /// <summary>
        /// Carga el formulario de edición.
        /// </summary>
        private void CargarFormularioEdicion()
        {

            if (ListBUsuarios.Rows[indiceSeleccionado].DataBoundItem is Modelo.Entidades.Usuarios usuario)
            {
                _usuarioSeleccionado = usuario;

                TxtDni.Text = _usuarioSeleccionado.DNI ?? string.Empty;
                TxtApellido.Text = _usuarioSeleccionado.Apellido ?? string.Empty;
                TxtNombre.Text = _usuarioSeleccionado.Nombre ?? string.Empty;
                TxtTel.Text = _usuarioSeleccionado.Tel ?? string.Empty;
                TxtEmail.Text = _usuarioSeleccionado.Mail ?? string.Empty;
                CMBTipoUsuario.SelectedValue = _usuarioSeleccionado.Id_Tipo;

            }
            else
            {
                TxtDni.Clear();
                TxtApellido.Clear();
                TxtNombre.Clear();
                TxtTel.Clear();
                TxtEmail.Clear();
            }
        }

        /// <summary>
        /// Maneja el evento EnabledChanged del control BtnGuardar.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
        private void BtnGuardar_EnabledChanged(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Color color) btn.BackColor = btn.Enabled ? color : AppColorsBlue.Secondary;


        }
        /// <summary>
        /// Configura los botones.
        /// </summary>
        private void ConfigBtns()
        {
            BtnGuardar.Tag = AppColorsBlue.Tertiary;
            BtnEliminar.Tag = AppColorsBlue.Error;
        }
    }


}