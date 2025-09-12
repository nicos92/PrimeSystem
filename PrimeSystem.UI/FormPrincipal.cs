using PrimeSystem.Contrato.Servicios;
using PrimeSystem.UI.Ventas;
using PrimeSystem.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
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
    private readonly IArticulosService _articulosService;
    private readonly ILogger<FormPrincipal> _logger;
    private Button _btnActivo;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="FormPrincipal"/>.
    /// </summary>
    /// <param name="serviceProvider">El proveedor de servicios.</param>
    /// <param name="articulosService">El servicio de artículos.</param>
    /// <param name="logger">El logger para esta clase.</param>
    public FormPrincipal(IServiceProvider serviceProvider, IArticulosService articulosService, ILogger<FormPrincipal> logger)
    {
        _serviceProvider = serviceProvider;
        _articulosService = articulosService;
        _logger = logger;
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
        _logger.LogInformation("Cargando FormPrincipal y configurando menú.");
        ConfigurarBtnsMenu();
        SeleccionarForm(typeof(FormVentas));
        CargarPermisos();
        //try
        //{

        //    Task.Run(() =>
        //    {
        //        var resultado = _articulosService.GetAll();
        //        this.Invoke((MethodInvoker)delegate
        //        {
        //            if (resultado.IsSuccess)
        //            {
        //                dataGridView1.DataSource = resultado.Value;
        //            }
        //            else
        //            {
        //                MessageBox.Show(resultado.Error, "Error en UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        });
        //    });
        //}
        //catch (ArgumentNullException ex)
        //{ 
        //    MessageBox.Show($"Error al cargar artculos: {ex.Message}", "Error UI",
        //        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
        //catch (Exception ex)
        //{
        //    MessageBox.Show($"Error al cargar artculos: {ex.Message}", "Error UI",
        //        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}

    }

    /// <summary>
    /// Carga los permisos según el rol del usuario.
    /// </summary>
    private void CargarPermisos()
    {

        string rolUsuario = "admin"; // Aqu deberas obtener el rol del usuario actual
        switch (rolUsuario)
        {
            case "admin":
                CargarAdmin(); break;
            case "compras":
                CargarCompras();
                break;
            case "ventas":
                CargarVentas();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Carga los permisos para el rol de administrador.
    /// </summary>
    private void CargarAdmin()
    {
        BtnModClientes.Visible = true;
        BtnModUsuarios.Visible = true;
        BtnModProveedores.Visible = true;
        BtnModEstadoContable.Visible = true;
        BtnModVentas.Visible = true;
        BtnModCompras.Visible = true;
    }

    /// <summary>
    /// Carga los permisos para el rol de ventas.
    /// </summary>
    private void CargarVentas()
    {
        BtnModClientes.Visible = true;
        BtnModUsuarios.Visible = false;
        BtnModProveedores.Visible = false;
        BtnModEstadoContable.Visible = false;
        BtnModVentas.Visible = true;
        BtnModCompras.Visible = false;
    }

    /// <summary>
    /// Carga los permisos para el rol de compras.
    /// </summary>
    private void CargarCompras()
    {
        BtnModClientes.Visible = false;
        BtnModUsuarios.Visible = false;
        BtnModProveedores.Visible = true;
        BtnModEstadoContable.Visible = false;
        BtnModVentas.Visible = false;
        BtnModCompras.Visible = true;
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
    /// Selecciona y muestra un formulario en el contenedor MDI.
    /// </summary>
    /// <param name="tipoForm">El tipo de formulario a mostrar.</param>
    private void SeleccionarForm(Type tipoForm)
    {
        // Cerrar el formulario actual si existe
        foreach (Form f in this.MdiChildren)
        {
            f.Close();
        }
        _logger.LogInformation("Seleccionando formulario: {0}", tipoForm);
        // Crear el formulario usando el tipo proporcionado en el Tag del botn
        if (tipoForm != null && typeof(Form).IsAssignableFrom(tipoForm))
        {
            Form form = (Form)_serviceProvider.GetRequiredService(tipoForm);
            form.MdiParent = this;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Show();
        }
    }

    /// <summary>
    /// Elige el módulo a mostrar.
    /// </summary>
    /// <param name="sender">La fuente del evento.</param>
    /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
    private void ElejirModulo(object sender, EventArgs e)
    {

        if (_btnActivo.Tag == ((Button)sender).Tag)
        {
            return;
        }
        _btnActivo.BackColor = AppColorsBlue.Primary;
        _btnActivo.ForeColor = AppColorsBlue.OnPrimary;

        if (sender is Button btn)
        {
            btn.BackColor = AppColorsBlue.OnPrimaryContainer;
            btn.ForeColor = AppColorsBlue.PrimaryContainer;
            _btnActivo = btn;

            // Obtener el tipo del formulario desde el Tag del botn
            if (btn.Tag is Type tipoForm)
            {
                SeleccionarForm(tipoForm);
                this.Text = "Prime System - " + _btnActivo.Text;
            }
        }
    }
}