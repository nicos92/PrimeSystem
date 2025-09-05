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
            maxWidth = maxWidth < 128 ? 128 : maxWidth; // Ancho mínimo de 100 píxeles
            listBox.Width = maxWidth + SystemInformation.VerticalScrollBarWidth + 5;
        }

        public static void ValcularListBoxVacio(ListBox listbox, Label label, string modulo)
        {
            if (listbox.Items.Count <= 0)
            {
                label.Text = $"Lista de {modulo} Vacia";
                return;
            }
            label.Text = $"Lista de {modulo}";

        }

        public static void ActualizarEnLista<T>(IList<T> lista, T objetoActualizado)
            where T : class
        {
            // Try to find the existing object in the list
            var objetoExistente = lista.FirstOrDefault(item =>
                item.GetType().GetProperty("Id_Articulo")?.GetValue(item)?.Equals(
                    objetoActualizado.GetType().GetProperty("Id_Articulo")?.GetValue(objetoActualizado)) ?? false);

            if (objetoExistente != null)
            {
                // Get the index of the existing object
                var index = lista.IndexOf(objetoExistente);

                // Replace it with the new, updated object
                lista[index] = objetoActualizado;
            }
        }

        public static void EliminarDeLista<T>(IList<T> lista, T objetoAEliminar)
        {
            lista.Remove(objetoAEliminar);
        }
    }
}
