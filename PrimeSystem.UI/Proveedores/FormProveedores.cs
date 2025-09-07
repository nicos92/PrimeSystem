using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using PrimeSystem.Utilidades;

namespace PrimeSystem.UI.Proveedores
{
    public partial class FormProveedores : Form
    {
        private Button _btnActual;
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FormProveedores"/>.
        /// </summary>
        /// <param name="serviceProvider">El proveedor de servicios para la inyección de dependencias.</param>
        public FormProveedores(IServiceProvider serviceProvider)
        {

            _serviceProvider = serviceProvider;
            InitializeComponent();
            _btnActual = BtnOpcionIngresar; // Inicializar con el botón de Ingresar
        }

        /// <summary>
        /// Maneja el evento de carga del formulario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FormProveedores_Load(object sender, EventArgs e)
        {
            ConFigBtns();

        }

        /// <summary>
        /// Selecciona y muestra un control de usuario en el panel principal.
        /// </summary>
        /// <param name="tipoForm">El tipo de control de usuario a mostrar.</param>
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

        /// <summary>
        /// Configura los tags de los botones de opción.
        /// </summary>
        private void ConFigBtns()
        {
            BtnOpcionIngresar.Tag = typeof(UCIngresoProveedores);
            BtnOpcionEditar.Tag = typeof(UCConsultaProveedor);
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de opción de ingresar.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void BtnOpcionIngresar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (_btnActual.Tag == btn.Tag)
            {
                return;
            }
            Util.CambioColorBtnsUC(_btnActual, btn);

            // Solución: Verificar que btn.Tag no sea nulo antes de llamar a SeleccionarUC
            if (btn.Tag is Type tipoForm)
            {
                SeleccionarUC(tipoForm);
            }
            _btnActual = btn;
        }

        

        /// <summary>
        /// Maneja el evento de activación del formulario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FormProveedores_Activated(object sender, EventArgs e)
        {
            SeleccionarUC(typeof(UCIngresoProveedores));

        }
    }
}
