using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeSystem.UI.Proveedores
{
    public partial class FormProveedores : Form
    {
        public FormProveedores()
        {
            InitializeComponent();
        }

        private void FormProveedores_Load(object sender, EventArgs e)
        {
            UCIngresoProveedores ip = new UCIngresoProveedores();
            ip.Dock = DockStyle.Fill;
            PanelMedio.Controls.Add(ip);

        }
    }
}
