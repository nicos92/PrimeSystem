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

namespace PrimeSystem.UI.Clientes
{
    public partial class FormClientes : Form
    {
        private Button _btnActual;
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FormClientes"/>.
        /// </summary>
        /// <param name="serviceProvider">El proveedor de servicios.</param>
        public FormClientes(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();

            _btnActual = BtnOpcionIngresar; // Inicializar con el botón de Ingresar
        }

        /// <summary>
        /// Maneja el evento Click del control BtnOpcionIngresar.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
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
        /// Configura los botones.
        /// </summary>
        private void ConFigBtns()
        {
            BtnOpcionIngresar.Tag = typeof(UCIgresoCliente);
            BtnOpcionEditar.Tag = typeof(UCConsultaClientes);
        }

        /// <summary>
        /// Selecciona el control de usuario.
        /// </summary>
        /// <param name="tipoForm">El tipo de formulario.</param>
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
        /// Maneja el evento Load del control FormClientes.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
        private void FormClientes_Load(object sender, EventArgs e)
        {
            ConFigBtns();
        }

        /// <summary>
        /// Maneja el evento Activated del control FormClientes.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="EventArgs"/> que contiene los datos del evento.</param>
        private void FormClientes_Activated(object sender, EventArgs e)
        {
            SeleccionarUC(typeof(UCIgresoCliente));
        }

        
    }
}