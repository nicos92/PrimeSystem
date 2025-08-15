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

namespace PrimeSystem.UI.Proveedores
{
    public partial class FormProveedores : Form
    {
        private IServiceProvider _serviceProvider;
        public FormProveedores(IServiceProvider serviceProvider)
        {

            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void FormProveedores_Load(object sender, EventArgs e)
        {
            UCIngresoProveedores ip = new UCIngresoProveedores();
            ip.Dock = DockStyle.Fill;
            PanelMedio.Controls.Add(ip);

        }

        private void ConFigBtns()
        {
            BtnOpcionIngresar.Tag = typeof(UCIngresoProveedores);
        }

        private void BtnOpcionIngresar_Click(object sender, EventArgs e)
        {
            UCIngresoProveedores ip = _serviceProvider.GetRequiredService<UCIngresoProveedores>();
            ip.Dock = DockStyle.Fill;
            PanelMedio.Controls.Clear();
            PanelMedio.Controls.Add(ip);
        }
    }
}
