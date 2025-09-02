using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeSystem.Utilidades
{
    [SupportedOSPlatform("windows")]
    public class BackWork : BackgroundWorker
    {
        private ProgressBar _progress;
        private Action _action;
        private Panel _panel;
        public BackWork(ProgressBar bar, Action action, Panel panel)
        {
            _progress = bar;
            _action = action;
            _panel = panel;
            this.WorkerReportsProgress = true;

        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            try
            {

                int maxProgress = 100; // O un valor pasado como argumento a RunWorkerAsync()

                for (int i = 0; i < maxProgress; i++)
                {
                    // Lógica para ejecutar la acción de forma más flexible,
                    // por ejemplo, al finalizar la tarea
                    if (i == maxProgress - 1)
                    {
                        _action();
                    }

                    // Considera usar la propiedad CancellationPending para permitir
                    // que el usuario cancele la tarea
                    if (this.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }

                    this.ReportProgress(i);
                }
            }
            catch (Exception ex)
            {

                e.Result = ex; // Almacena la excepción para OnRunWorkerCompleted
            }
        }

        protected override void OnProgressChanged(ProgressChangedEventArgs e)
        {
            base.OnProgressChanged(e);
            _progress.Value = e.ProgressPercentage;
        }
        protected override void OnRunWorkerCompleted(RunWorkerCompletedEventArgs e)
        {
            base.OnRunWorkerCompleted(e);
            // Muestra un mensaje de error si ocurrió una excepción
            if (e.Result is Exception ex)
            {
                // Podrías mostrar un MessageBox o registrar el error
                System.Windows.Forms.MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
            _progress.Visible = false;
            _panel.Enabled = true;
        }
    }
}
