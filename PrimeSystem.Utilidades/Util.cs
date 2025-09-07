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
        /// <summary>
        /// Limpia los controles TextBox de un TableLayoutPanel y establece el foco en un TextBox específico.
        /// </summary>
        /// <param name="tbp">El TableLayoutPanel que contiene los controles a limpiar.</param>
        /// <param name="textBox">El TextBox que recibirá el foco después de la limpieza.</param>
        public static void LimpiarForm(TableLayoutPanel tbp, TextBox textBox)
        {
            tbp.Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear());
            textBox.Focus();
        }

        /// <summary>
        /// Cambia el color de los botones de un control de usuario.
        /// </summary>
        /// <param name="btnActual">El botón actualmente seleccionado.</param>
        /// <param name="btnNuevo">El nuevo botón a seleccionar.</param>
        public static void CambioColorBtnsUC(Button btnActual, Button btnNuevo)
        {
            btnNuevo.BackColor = AppColorsBlue.Primary;
            btnNuevo.ForeColor = AppColorsBlue.OnPrimary;
            btnNuevo.FlatAppearance.BorderColor = AppColorsBlue.PrimaryContainer;
            btnActual.BackColor = AppColorsBlue.Secondary;
            btnActual.ForeColor = AppColorsBlue.OnSecondary;
            btnActual.FlatAppearance.BorderColor = AppColorsBlue.OnSecondaryContainer;
        }

        /// <summary>
        /// Ajusta el ancho de un control ListBox para que se ajuste a su contenido.
        /// </summary>
        /// <param name="listBox">El control ListBox a ajustar.</param>
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

        /// <summary>
        /// Calcula si un ListBox está vacío y actualiza una etiqueta en consecuencia.
        /// </summary>
        /// <param name="listbox">El ListBox a comprobar.</param>
        /// <param name="label">La etiqueta a actualizar.</param>
        /// <param name="modulo">El nombre del módulo a mostrar en la etiqueta.</param>
        public static void CalcularListBoxVacio(ListBox listbox, Label label, string modulo)
        {
            if (listbox.Items.Count <= 0)
            {
                label.Text = $"Lista de {modulo} Vacia";
                return;
            }
            label.Text = $"Lista de {modulo}";

        }

        /// <summary>
        /// Cambia el texto de la etiqueta que indica si la lista está vacía.
        /// </summary>
        /// <param name="DGV">DataGridView para calcular si está vacío.</param>
        /// <param name="label">Etiqueta que cambia con respecto al DataGridView vacío o no.</param>
        /// <param name="modulo">Módulo donde se encuentra el DataGridView.</param>
        public static bool CalcularDGVVacio(DataGridView DGV, Label label, string modulo)
        {
            if (DGV.RowCount <= 0)
            {
                label.Text = $"Lista de {modulo} Vacia";
                return true;
            }
            label.Text = $"Lista de {modulo}";
            return false;
        }


        /// <summary>
        /// Selecciona una fila en un DataGridView que coincide con un valor de búsqueda en una columna específica.
        /// </summary>
        /// <param name="dataGridView1">El DataGridView en el que se buscará.</param>
        /// <param name="valorBuscado">El valor a buscar en la columna especificada.</param>
        /// <param name="nombreColumna">El nombre de la columna en la que se buscará.</param>
        /// <param name="indice">La variable para almacenar el índice de la fila seleccionada.</param>
        public static void SeleccionarFilaDGV(DataGridView dataGridView1, string valorBuscado, string nombreColumna, ref int indice)
        {


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[nombreColumna].Value?.ToString() == valorBuscado)
                {
                    dataGridView1.ClearSelection();
                    row.Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                    indice = row.Index; // Guardar el índice de la fila seleccionada    
                    break;
                }
            }

        }

        /// <summary>
        /// Habilita o deshabilita un TableLayoutPanel en función de si un DataGridView tiene filas.
        /// </summary>
        /// <param name="list">El DataGridView que se utilizará para determinar si se deben bloquear los botones.</param>
        /// <param name="tlp">El TableLayoutPanel que se habilitará o deshabilitará.</param>
        public static void BloquearBtns(DataGridView list, TableLayoutPanel tlp)
        {

            if (list.Rows.Count <= 0)
            {



                tlp.Enabled = false;


            }
            else
            {

                tlp.Enabled = true;

            }

        }

        /// <summary>
        /// Actualiza un objeto en una lista.
        /// </summary>
        /// <typeparam name="T">El tipo de los objetos de la lista.</typeparam>
        /// <param name="lista">La lista en la que se actualizará el objeto.</param>
        /// <param name="objetoActualizado">El objeto con los datos actualizados.</param>
        public static void ActualizarEnLista<T>(IList<T> lista, T objetoActualizado)
           where T : class
        {
            // Intenta encontrar el objeto existente en la lista
            var objetoExistente = lista.FirstOrDefault(item =>
                item.GetType().GetProperty("Id_Articulo")?.GetValue(item)?.Equals(
                    objetoActualizado.GetType().GetProperty("Id_Articulo")?.GetValue(objetoActualizado)) ?? false);

            if (objetoExistente != null)
            {
                // Obtiene el índice del objeto existente
                var index = lista.IndexOf(objetoExistente);

                // Lo reemplaza con el nuevo objeto actualizado
                lista[index] = objetoActualizado;
            }
        }

        /// <summary>
        /// Elimina un objeto de una lista.
        /// </summary>
        /// <typeparam name="T">El tipo de los objetos de la lista.</typeparam>
        /// <param name="lista">La lista de la que se eliminará el objeto.</param>
        /// <param name="objetoAEliminar">El objeto a eliminar.</param>
        public static void EliminarDeLista<T>(IList<T> lista, T objetoAEliminar)
        {
            lista.Remove(objetoAEliminar);
        }
    }
}