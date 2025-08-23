using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PrimeSystem.Utilidades
{
    [SupportedOSPlatform("windows")]
    public static class Util
    {
        public static void LimpiarForm(TableLayoutPanel tbp, TextBox textBox)
        {
            tbp.Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
            textBox.Focus();
        }

        public static void CambioColorBtnsUC(Button btnActual, Button btnNuevo)
        {
            btnNuevo.BackColor = AppColorsBlue.Primary;
            btnNuevo.ForeColor = AppColorsBlue.OnPrimary;
            btnNuevo.FlatAppearance.BorderColor = AppColorsBlue.PrimaryContainer;
            btnActual.BackColor = AppColorsBlue.Secondary;
            btnActual.ForeColor = AppColorsBlue.OnSecondary;
            btnActual.FlatAppearance.BorderColor = AppColorsBlue.OnSecondaryContainer;
        }
    }
}
