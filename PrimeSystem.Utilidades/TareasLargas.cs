using System;
using System.ComponentModel;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeSystem.Utilidades
{
    [SupportedOSPlatform("windows")]
    public class TareasLargas : BackgroundWorker
    {
        private readonly Panel _panelADesactivar;
        private readonly ProgressBar _barraDeProgreso;
        private readonly Func<Task> _tareaDeLargaDuracion;
        private readonly Action _tareaCompletada;


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TareasLargas"/>.
        /// </summary>
        /// <param name="panelADesactivar">El panel a desactivar durante la tarea.</param>
        /// <param name="barraDeProgreso">La barra de progreso a mostrar.</param>
        /// <param name="tareaDeLargaDuracion">La tarea de larga duración a ejecutar.</param>
        /// <param name="tareaCompletada">La acción a ejecutar cuando la tarea se complete.</param>
        public TareasLargas(Panel panelADesactivar, ProgressBar barraDeProgreso, Func<Task> tareaDeLargaDuracion, Action tareaCompletada)
        {
            _panelADesactivar = panelADesactivar;
            _barraDeProgreso = barraDeProgreso;
            _tareaDeLargaDuracion = tareaDeLargaDuracion;
            _tareaCompletada = tareaCompletada;

            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;

            DoWork += HacerTrabajo;
            ProgressChanged += ProgresoCambiado;
            RunWorkerCompleted += TrabajoCompletado;
            _tareaCompletada = tareaCompletada;
        }

        /// <summary>
        /// Inicia la tarea de larga duración.
        /// </summary>
        public void Iniciar()
        {
            _panelADesactivar.Enabled = false;
            _barraDeProgreso.Visible = true;
            _barraDeProgreso.Style = ProgressBarStyle.Marquee;
            RunWorkerAsync();
        }

        /// <summary>
        /// Realiza el trabajo de la tarea de larga duración.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="DoWorkEventArgs"/> que contiene los datos del evento.</param>
        private async void HacerTrabajo(object sender, DoWorkEventArgs e)
        {
            try
            {
                await _tareaDeLargaDuracion();
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        /// <summary>
        /// Maneja el evento de cambio de progreso.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="ProgressChangedEventArgs"/> que contiene los datos del evento.</param>
        private void ProgresoCambiado(object sender, ProgressChangedEventArgs e)
        {
            _barraDeProgreso.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Maneja el evento de finalización del trabajo.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">La instancia de <see cref="RunWorkerCompletedEventArgs"/> que contiene los datos del evento.</param>
        private void TrabajoCompletado(object sender, RunWorkerCompletedEventArgs e)
        {
            _panelADesactivar.Enabled = true;
            _barraDeProgreso.Visible = false;

            if (e.Error != null)
            {
                MessageBox.Show($"Error: {e.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.Result is Exception ex)
            {
                MessageBox.Show($"Error during task: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Ejecuta la tarea de completado si no hubo errores
                _tareaCompletada();
            }
        }
    }
}