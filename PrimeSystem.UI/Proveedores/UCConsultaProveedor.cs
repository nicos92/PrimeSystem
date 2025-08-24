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
        private Modelo.Entidades.Proveedores? _proveedorSeleccionado;
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
        public UCConsultaProveedor(IProveedoresService proveedoresService)
        {
            _proveedoresService = proveedoresService;
            indiceSeleccionado = 0;
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



        private async void UCConsultaProveedor_Load(object sender, EventArgs e)
        {
            await CargarProveedores();
            BloquearBtns();
            SeleccionarProveedor();
            Util.AjustarAnchoListBox(ListBProveedores);
            Util.ValcularListBoxVacio(ListBProveedores, LblLista, "Proveedores");


            TxtCuit.Focus();

        }

        private async Task CargarProveedores()
        {
            var datos = await _proveedoresService.GetAll();

            if (datos.IsSuccess)
            {
                List<Modelo.Entidades.Proveedores> proveedores = datos.Value;
                ListBProveedores.DataSource = proveedores;

            }
            else
            {
                MessageBox.Show(datos.Error, "Error en UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ListBProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            _proveedorSeleccionado = ListBProveedores.SelectedItem as Modelo.Entidades.Proveedores;

            if (_proveedorSeleccionado != null)
            {
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

        private void SeleccionarProveedor()
        {
            if (ListBProveedores.SelectedItem != null)
            {
                ListBProveedores.SelectedIndex = indiceSeleccionado;
            }
        }

        private void BloquearBtns()
        {

            if (ListBProveedores.SelectedItem == null)
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

        private async Task GuardarProveedor()
        {
            if (_proveedorSeleccionado != null && !string.IsNullOrEmpty(_proveedorSeleccionado.CUIT))
            {



                Result<Modelo.Entidades.Proveedores> resultado = _proveedoresService.Update(_proveedorSeleccionado);

                if (resultado.IsSuccess)
                {
                    MessageBox.Show("Proveedor actualizado correctamente.\n" + resultado.Value.ToString(), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    indiceSeleccionado = ListBProveedores.SelectedIndex;
                    await CargarProveedores();
                    SeleccionarProveedor();
                    Util.AjustarAnchoListBox(ListBProveedores);
                    Util.ValcularListBoxVacio(ListBProveedores, LblLista, "Proveedores");



                }
                else
                {
                    MessageBox.Show(resultado.Error, "Error al actualizar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CrearProveedor()
        {
            _proveedorSeleccionado ??= new Modelo.Entidades.Proveedores();

            _proveedorSeleccionado.CUIT = TxtCuit.Text;
            _proveedorSeleccionado.Proveedor = TxtProveedor.Text;
            _proveedorSeleccionado.Nombre = TxtNombre.Text;
            _proveedorSeleccionado.Tel = TxtTel.Text;
            _proveedorSeleccionado.Email = TxtEmail.Text;

        }



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

        private async Task EliminarProveedor()
        {

            var resultado = _proveedoresService.Delete(_proveedorSeleccionado.Id_Proveedor);
            if (resultado.IsSuccess)
            {
                MessageBox.Show("Proveedor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Util.LimpiarForm(TLPForm, TxtCuit);

                await CargarProveedores();
                Util.AjustarAnchoListBox(ListBProveedores);
                Util.ValcularListBoxVacio(ListBProveedores, LblLista, "Proveedores");


            }
            else
            {
                MessageBox.Show(resultado.Error, "Error al eliminar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TxtCuit_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple([BtnGuardar], _vTxtCuit, _vTxtProveedor, _vTxtNombre, _vTxtTel, _vTxtEmail);
        }
    }
}
