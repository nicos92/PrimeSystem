using Microsoft.Extensions.DependencyInjection;
using PrimeSystem.UI.Usuarios;
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

namespace PrimeSystem.UI.Articulos
{
    public partial class FormArticulos : Form
    {
        private Button _btnActual;
        private readonly IServiceProvider _serviceProvider;
        public FormArticulos(IServiceProvider serviceProvider)
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

        private void ValidarTag(Button btn)
        {
            if (btn.Tag is Type type)
            {

                SeleccionarUC(type);
            }
        }

        private void BtnOpcionIngresar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (_btnActual.Tag == btn.Tag)
            {
                return;
            }

            Util.CambioColorBtnsUC(_btnActual, btn);


            ValidarTag(btn);
            _btnActual = btn;
        }

        private void FormArticulos_Load(object sender, EventArgs e)
        {
            ConFigBtns();

            ValidarTag(_btnActual);
        }
    }
}
