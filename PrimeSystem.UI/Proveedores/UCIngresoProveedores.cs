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

namespace PrimeSystem.UI.Proveedores
{
    public partial class UCIngresoProveedores : UserControl
    {
        // TODO : implementar validacion del formulario
        // TODO : verificar propiedades de los textbox.
        // TODO : Agregar Error Proovider para mostrar ayuda en los texbox.
        // TODO : implementar activacion de boton ingreso
        private readonly IProveedoresService _proveedor;
        private Modelo.Entidades.Proveedores _proveedorSeleccionado;
        public UCIngresoProveedores(IProveedoresService proveedoresService)
        {
            _proveedor = proveedoresService; 
            InitializeComponent();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
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
    }
}
