using System;
using System.Collections.Generic;
using System.Drawing;
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

        public static void AjustarAnchoListBox(ListBox listBox)
        {
            int maxWidth = 0;
            using (Graphics g = listBox.CreateGraphics())
            {
                foreach (var item in listBox.Items)
                {
                    int itemWidth = (int)g.MeasureString(item.ToString(), listBox.Font).Width;
                    if (itemWidth > maxWidth)
                    {
                        maxWidth = itemWidth;
                    }
                }
            }

            // Agregar un margen adicional para evitar cortes
            listBox.Width = maxWidth + SystemInformation.VerticalScrollBarWidth + 5;
        }
    }
}
