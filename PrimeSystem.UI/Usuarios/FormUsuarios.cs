using Microsoft.Extensions.DependencyInjection;
using PrimeSystem.UI.Proveedores;
using PrimeSystem.Utilidades;
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
    public partial class FormUsuarios : Form
    {
        private Button _btnActual;
        private readonly IServiceProvider _serviceProvider;
        public FormUsuarios(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            _btnActual = BtnOpcionIngresar; // Inicializar con el botón de Ingresar
        }

        private void SeleccionarUC(Type tipoForm)
        {
            // Cerrar el formulario actual si existe
            PanelMedio.Controls.Clear();

            // Crear el formulario usando el tipo proporcionado en el Tag del botón
            if (tipoForm != null && typeof(UserControl).IsAssignableFrom(tipoForm))
            {
                UserControl uc = (UserControl)_serviceProvider.GetRequiredService(tipoForm);

                uc.Dock = DockStyle.Fill;
                PanelMedio.Controls.Add(uc);
            }
        }

        private void ConFigBtns()
        {
            BtnOpcionIngresar.Tag = typeof(UCIngresoUsuarios);
            BtnOpcionEditar.Tag = typeof(USConsultaUsuario);
        }

        private void BtnOpcionIngresar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (_btnActual.Tag == btn.Tag)
            {
                return;
            }
            btn.BackColor = AppColorsBlue.Primary;
            btn.ForeColor = AppColorsBlue.OnPrimary;
            btn.FlatAppearance.BorderColor = AppColorsBlue.PrimaryContainer;

            _btnActual.BackColor = AppColorsBlue.Secondary;
            _btnActual.ForeColor = AppColorsBlue.OnSecondary;
            _btnActual.FlatAppearance.BorderColor = AppColorsBlue.OnSecondaryContainer;
            SeleccionarUC(btn.Tag as Type);
            _btnActual = btn;
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            ConFigBtns();
            SeleccionarUC((Type) _btnActual.Tag);

        }
    }
}
