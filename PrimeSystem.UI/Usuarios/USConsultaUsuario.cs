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

        private async void USConsultaUsuario_Load(object sender, EventArgs e)
        {
            TxtDni.Focus();
            await CargarTiposUsuarios();
            await CargarUsuarios();
            BloquearBtns();
            Util.AjustarAnchoListBox(ListBUsuarios);
            Util.ValcularListBoxVacio(ListBUsuarios, LblLista, "Usuarios");

        }

        private async Task CargarTiposUsuarios()
        {
            CMBTipoUsuario.Items.Clear();
            var tiposUsuarios = await _usuariosTipoService.GetAll();

            if (tiposUsuarios.IsSuccess && tiposUsuarios.Value != null)
            {
                CMBTipoUsuario.DataSource = tiposUsuarios.Value;

            }
            else
            {
                MessageBox.Show("Error al cargar los tipos de usuarios: " + tiposUsuarios.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtDni_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple([BtnGuardar], _vTxtDni, _vTxtApellido, _vTxtNombre, _vTxtTel, _vTxtEmail);
        }

        private void CrearUsuario()
        {
            if (CMBTipoUsuario.SelectedItem is not Modelo.Entidades.UsuariosTipo tipoUsuario)
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
            _usuarioSeleccionado.Id_Tipo = tipoUsuario.Id_Usuario_Tipo;
        }

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

        private async Task GuardarUsuario()
        {
            if (_usuarioSeleccionado != null && !string.IsNullOrEmpty(_usuarioSeleccionado.DNI))
            {



                Result<Modelo.Entidades.Usuarios> resultado = _usuariosService.Update(_usuarioSeleccionado);

                if (resultado.IsSuccess)
                {
                    MessageBox.Show("Proveedor actualizado correctamente.\n" + resultado.Value.ToString(), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    indiceSeleccionado = ListBUsuarios.SelectedIndex;
                    await CargarUsuarios();
                    SeleccionarProveedor();
                    Util.AjustarAnchoListBox(ListBUsuarios);
                    Util.ValcularListBoxVacio(ListBUsuarios, LblLista, "Usuarios");


                }
                else
                {
                    MessageBox.Show(resultado.Error, "Error al actualizar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task CargarUsuarios()
        {
            var datos = await _usuariosService.GetAll();

            if (datos.IsSuccess)
            {
                List<Modelo.Entidades.Usuarios> proveedores = datos.Value;
                ListBUsuarios.DataSource = proveedores;

            }
            else
            {
                MessageBox.Show(datos.Error, "Error en UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarProveedor()
        {
            if (ListBUsuarios.SelectedItem != null)
            {
                ListBUsuarios.SelectedIndex = indiceSeleccionado;
            }
        }

        private void ListBUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            _usuarioSeleccionado = ListBUsuarios.SelectedItem as Modelo.Entidades.Usuarios;

            if (_usuarioSeleccionado != null)
            {
                TxtDni.Text = _usuarioSeleccionado.DNI ?? string.Empty;
                TxtApellido.Text = _usuarioSeleccionado.Apellido ?? string.Empty;
                TxtNombre.Text = _usuarioSeleccionado.Nombre ?? string.Empty;
                TxtTel.Text = _usuarioSeleccionado.Tel ?? string.Empty;
                TxtEmail.Text = _usuarioSeleccionado.Mail ?? string.Empty;
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



        private void BloquearBtns()
        {

            if (ListBUsuarios.SelectedItem == null)
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

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este proveedor?", "Confirmación de eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return; // Salir si el usuario no confirma
            }
            CrearUsuario();
            await EliminarProveedor();
        }

        private async Task EliminarProveedor()
        {

            var resultado = _usuariosService.Delete(_usuarioSeleccionado.Id_Usuario);
            if (resultado.IsSuccess)
            {
                MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Util.LimpiarForm(TLPFormUsuario, TxtDni);

                await CargarUsuarios();
                Util.AjustarAnchoListBox(ListBUsuarios);
                Util.ValcularListBoxVacio(ListBUsuarios, LblLista, "Usuarios");


            }
            else
            {
                MessageBox.Show(resultado.Error, "Error al eliminar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
