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

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FormArticulos"/>.
        /// </summary>
        /// <param name="serviceProvider">El proveedor de servicios para la inyección de dependencias.</param>
        public FormArticulos(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            _btnActual = BtnOpcionIngresar; // Inicializar con el botón de Ingresar

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
            BtnOpcionIngresar.Tag = typeof(UCIngresoArticulos);
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
        private void FormArticulos_Load(object sender, EventArgs e)
        {
            ConFigBtns();

            ValidarTag(_btnActual);
        }

        /// <summary>
        /// Maneja el evento de cierre del formulario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FormArticulos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
