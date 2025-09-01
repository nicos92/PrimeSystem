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

        public void Iniciar()
        {
            _panelADesactivar.Enabled = false;
            _barraDeProgreso.Visible = true;
            _barraDeProgreso.Style = ProgressBarStyle.Marquee;
            RunWorkerAsync();
        }

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

        private void ProgresoCambiado(object sender, ProgressChangedEventArgs e)
        {
            _barraDeProgreso.Value = e.ProgressPercentage;
        }

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

