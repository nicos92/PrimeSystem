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


namespace PrimeSystem.UI.Proveedores
{
    public partial class UCConsultaProveedor : UserControl
    {
        // TODO : Implementar validacion del formulario.
        // TODO : verificar propiedades de los textbox.
        // TODO : Agregar Error Proovider para mostrar ayuda en los texbox.
        // TODO : Agregar cuadro de busqueda de proveedores.
        private readonly IProveedoresService _proveedoresService;
        private Modelo.Entidades.Proveedores? _proveedorSeleccionado;
        private int indiceSeleccionado;
        public UCConsultaProveedor(IProveedoresService proveedoresService)
        {
            _proveedoresService = proveedoresService;
            indiceSeleccionado = 0;
            InitializeComponent();
        }

        private async void UCConsultaProveedor_Load(object sender, EventArgs e)
        {
            await CargarProveedores();
            BloquearBtns();
            SeleccionarProveedor();

        }

        private async Task CargarProveedores()
        {
            var datos = await _proveedoresService.GetAll();

            if (datos.IsSuccess)
            {
                ListBProveedores.DisplayMember = "Proveedor";
                ListBProveedores.DataSource = datos.Value.ToList();

            }
            else
            {
                MessageBox.Show(datos.Error, "Error en UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ListBProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            BloquearBtns();
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

            CrearProveedor();
            if (_proveedorSeleccionado != null && !string.IsNullOrEmpty(_proveedorSeleccionado.CUIT))
            {



                Result<Modelo.Entidades.Proveedores> resultado = _proveedoresService.Update(_proveedorSeleccionado);

                if (resultado.IsSuccess)
                {
                    MessageBox.Show("Proveedor actualizado correctamente.\n" + resultado.Value.ToString(), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    indiceSeleccionado = ListBProveedores.SelectedIndex;
                    await CargarProveedores();
                    SeleccionarProveedor();
                    BloquearBtns();

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
            CrearProveedor();
            if (_proveedorSeleccionado != null && !string.IsNullOrEmpty(_proveedorSeleccionado.CUIT))
            {
                var resultado = _proveedoresService.Delete(_proveedorSeleccionado.Id_Proveedor);
                if (resultado.IsSuccess)
                {
                    MessageBox.Show("Proveedor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Util.LimpiarForm(TLPForm, TxtCuit);

                    await CargarProveedores();
                    BloquearBtns();
                }
                else
                {
                    MessageBox.Show(resultado.Error, "Error al eliminar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


   
    }
}
