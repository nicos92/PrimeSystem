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
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TareasLargas"/> para ejecutar una función que devuelve un resultado.
        /// </summary>
        /// <param name="panelADesactivar">El panel a desactivar durante la tarea.</param>
        /// <param name="barraDeProgreso">La barra de progreso a mostrar.</param>
        public TareasLargas(Panel panelADesactivar, ProgressBar barraDeProgreso)
        {
            _panelADesactivar = panelADesactivar;
            _barraDeProgreso = barraDeProgreso;

            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;

            DoWork += HacerTrabajo;
            ProgressChanged += ProgresoCambiado;
            RunWorkerCompleted += TrabajoCompletado;
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
        /// Inicia la tarea de larga duración con una función específica.
        /// </summary>
        /// <typeparam name="T">El tipo de resultado devuelto por la función.</typeparam>
        /// <param name="funcion">La función a ejecutar.</param>
        /// <param name="mensaje">Mensaje descriptivo de la operación (opcional).</param>
        /// <returns>El resultado de la función ejecutada.</returns>
        public static async Task<T> EjecutarAsync<T>(Func<T> funcion, string mensaje = "")
        {
            // Para operaciones simples que no requieren UI blocking
            return await Task.Run(funcion);
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
                if (_tareaDeLargaDuracion != null)
                {
                    await _tareaDeLargaDuracion();
                }
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
                _tareaCompletada?.Invoke();
            }
        }
    }
}