using PrimeSystem.Contrato.Servicios;
using PrimeSystem.UI.Ventas;
using PrimeSystem.Utilidades;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using PrimeSystem.UI.Compras;
using PrimeSystem.UI.Clientes;
using PrimeSystem.UI.Usuarios;
using PrimeSystem.UI.Proveedores;
using PrimeSystem.UI.EstadoContable;
using PrimeSystem.UI.Articulos;
namespace PrimeSystem.UI;

public partial class FormPrincipal : Form
{
    private readonly IServiceProvider _serviceProvider;
    private Button _btnActivo;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="FormPrincipal"/>.
    /// </summary>
    /// <param name="serviceProvider">El proveedor de servicios.</param>
    /// <param name="articulosService">El servicio de artículos.</param>
    public FormPrincipal(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeComponent();
       
        _btnActivo = BtnModVentas;
    }

    /// <summary>
    /// Maneja el evento Load del formulario principal.
    /// </summary>
    /// <param name="sender">La fuente del evento.</param>
    /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
    private void FormPrincipal_Load(object sender, EventArgs e)
    {
        ConfigurarBtnsMenu();
        SeleccionarForm(typeof(FormVentas));
        CargarPermisos();
        

    }

    /// <summary>
    /// Carga los permisos y establece la visibilidad de los botones del menú.
    /// </summary>
    private void CargarPermisos()
    {
        string rolUsuario = "admin"; // Simular rol, se obtendría de un servicio de autenticación.
        bool isAdmin = rolUsuario == "admin";
        bool isVentas = rolUsuario == "ventas";
        bool isCompras = rolUsuario == "compras";

        BtnModClientes.Visible = isAdmin || isVentas;
        BtnModUsuarios.Visible = isAdmin;
        BtnModProveedores.Visible = isAdmin || isCompras;
        BtnModEstadoContable.Visible = isAdmin;
        BtnModVentas.Visible = isAdmin || isVentas;
        BtnModCompras.Visible = isAdmin || isCompras;
    }

    /// <summary>
    /// Configura los botones del menú.
    /// </summary>
    private void ConfigurarBtnsMenu()
    {
        BtnModVentas.Tag = typeof(FormVentas);
        BtnModCompras.Tag = typeof(FormCompras);
        BtnModClientes.Tag = typeof(FormClientes);
        BtnModUsuarios.Tag = typeof(FormUsuarios);
        BtnModProveedores.Tag = typeof(FormProveedores);
        BtnModEstadoContable.Tag = typeof(FormEstadoContable);
        BtnArticulos.Tag = typeof(FormArticulos);
    }

    /// <summary>
    /// Selecciona y muestra un formulario en el contenedor principal.
    /// </summary>
    private void SeleccionarForm(Type formType)
    {
        if (formType == null || !typeof(Form).IsAssignableFrom(formType))
        {
            MessageBox.Show("Tipo de formulario no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Cierra los formularios hijos existentes.
        foreach (Form form in MdiChildren)
        {
            form.Close();
            form.Dispose();
        }

        try
        {
            // Crea una nueva instancia del formulario usando el contenedor de servicios.
            var newForm = (Form)_serviceProvider.GetRequiredService(formType);
            newForm.MdiParent = this;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            newForm.Show();
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show($"Error al crear el formulario: {ex.Message}", "Error UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Maneja el clic en un botón del menú para cambiar el módulo.
    /// </summary>
    private void ElejirModulo(object sender, EventArgs e)
    {
        if (sender is not Button clickedButton || clickedButton == _btnActivo)
        {
            return;
        }

        // Desactivar el botón anterior y activar el nuevo.
        Util.DesactivarBoton(_btnActivo);
        Util.ActivarBoton(clickedButton);
        _btnActivo = clickedButton;

        // Seleccionar el formulario si el Tag es un Type.
        if (clickedButton.Tag is Type formType)
        {
            SeleccionarForm(formType);
            this.Text = "Prime System - " + clickedButton.Text;
        }
    }


}