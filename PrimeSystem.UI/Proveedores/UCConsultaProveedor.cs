using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrimeSystem.Contrato.Servicios;

namespace PrimeSystem.UI.Proveedores
{
    public partial class UCConsultaProveedor : UserControl
    {
        private readonly IArticulosService _articulosService;
        public UCConsultaProveedor(IArticulosService articulosService)
        {
            _articulosService = articulosService;
            InitializeComponent();
        }

        private async void UCConsultaProveedor_Load(object sender, EventArgs e)
        {

            var datos = await _articulosService.GetAll();

            if (datos.IsSuccess)
            {
                ListBProveedores.DisplayMember = "Art_Desc";
                ListBProveedores.DataSource = datos.Value.ToList();

            }
            else
            {
                MessageBox.Show(datos.Error, "Error en UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
