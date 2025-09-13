using Microsoft.Extensions.DependencyInjection;
using PrimeSystem.UI.Articulos;
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

namespace PrimeSystem.UI.Ventas
{
    public partial class FormVentaPrincipal : Form
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FormVentaPrincipal"/>.
        /// </summary>
        /// <param name="serviceProvider">El proveedor de servicios para la inyección de dependencias.</param>

        public FormVentaPrincipal(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            InitializeComponent();
            _btnActual = BtnOpcionIngresar; // Inicializar con el botón de Ingresar

        }

        private Button _btnActual;
        private readonly IServiceProvider _serviceProvider;



        /// <summary>
        /// Selecciona y muestra un control de usuario en el panel principal.
        /// </summary>
        /// <param name="tipoForm">El tipo de control de usuario a mostrar.</param>
        private void SeleccionarUC(Type tipoForm)
        {
            // Limpiar el panel si es un UserControl
            if (typeof(UserControl).IsAssignableFrom(tipoForm))
            {
                PanelMedio.Controls.Clear();
            }

            // Crear el UserControl si el tipo es un UserControl
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
            BtnOpcionIngresar.Tag = typeof(FormVentas);
            BtnOpcionEditar.Tag = typeof(UCConsultaArticulos);
        }

        /// <summary>
        /// Valida el tag de un botón y muestra el control de usuario correspondiente.
        /// </summary>
        /// <param name="btn">El botón a validar.</param>
        private void ValidarTag(Button btn)
        {
            if (btn.Tag is Type type)
            {

                SeleccionarUC(type);
            }
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


            ValidarTag(btn);
            _btnActual = btn;
        }

        /// <summary>
        /// Maneja el evento de carga del formulario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FormVentaPrincipal_Load(object sender, EventArgs e)
        {
            ConFigBtns();

            ValidarTag(_btnActual);
        }

        /// <summary>
        /// Maneja el evento de cierre del formulario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FormVentaPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
