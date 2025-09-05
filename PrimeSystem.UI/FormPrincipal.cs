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
    private readonly IArticulosService _articulosService;
    private Button _btnActivo;
    public FormPrincipal(IServiceProvider serviceProvider,IArticulosService articulosService)
    {
        _serviceProvider = serviceProvider;
        _articulosService = articulosService;
        InitializeComponent();
       
        _btnActivo = BtnModVentas;
    }

    private void FormPrincipal_Load(object sender, EventArgs e)
    {
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
        //    MessageBox.Show($"Error al cargar artículos: {ex.Message}", "Error UI",
        //        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
        //catch (Exception ex)
        //{
        //    MessageBox.Show($"Error al cargar artículos: {ex.Message}", "Error UI",
        //        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}

    }

    private void CargarPermisos()
    {
        
        string rolUsuario = "admin"; // Aquí deberías obtener el rol del usuario actual
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

    private void CargarAdmin()
    {
        BtnModClientes.Visible = true;
        BtnModUsuarios.Visible = true;
        BtnModProveedores.Visible = true;
        BtnModEstadoContable.Visible = true;
        BtnModVentas.Visible = true;
        BtnModCompras.Visible = true;
    }

    private void CargarVentas()
    {
        BtnModClientes.Visible = true;
        BtnModUsuarios.Visible = false;
        BtnModProveedores.Visible = false;
        BtnModEstadoContable.Visible = false;
        BtnModVentas.Visible = true;
        BtnModCompras.Visible = false;
    }

    private void CargarCompras()
    {
        BtnModClientes.Visible = false;
        BtnModUsuarios.Visible = false;
        BtnModProveedores.Visible = true;
        BtnModEstadoContable.Visible = false;
        BtnModVentas.Visible = false;
        BtnModCompras.Visible = true;
    }
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

    private void SeleccionarForm(Type tipoForm)
    { 
        // Cerrar el formulario actual si existe
        foreach (Form f in this.MdiChildren)
        {
            f.Close();
        }

        // Crear el formulario usando el tipo proporcionado en el Tag del botón
        if (tipoForm != null && typeof(Form).IsAssignableFrom(tipoForm))
        {
            Form form = (Form)_serviceProvider.GetRequiredService(tipoForm);
            form.MdiParent = this;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Show();
        }
    }

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

            // Obtener el tipo del formulario desde el Tag del botón
            if (btn.Tag is Type tipoForm)
            {
                SeleccionarForm(tipoForm);
                this.Text = "Prime System - " + _btnActivo.Text;
            }
        }
    }
}