using Microsoft.Extensions.DependencyInjection;
using PrimeSystem.UI;

namespace PrimeSystem.Arranque;

public partial class FormArranque : Form
{
    public FormArranque()
    {
        InitializeComponent();
    }

    private readonly Form? _formHijo;

    private async void Form1_Load(object sender, EventArgs e)
    {



        //Thread.Sleep(1000);
        var progress = new Progress<int>(percent =>
        {
            ProgressBar.Value = percent;
            LblCargando.Text = $"Cargando datos... {percent}% completado";
        });
        await SimulacionCarga(progress);
        this.Invoke((MethodInvoker)delegate
        {

            if (_formHijo == null || _formHijo.IsDisposed)
            {
                PanelPrincipal.Visible = false;
                FormPrincipal _formHijo = Program.ServiceProvider.GetRequiredService<FormPrincipal>();
                _formHijo.Closed += (s, e) =>
                {
                    this.Close();
                };
                //_formHijo.MdiParent = this;
                _formHijo.Dock = DockStyle.Fill;
                _formHijo.Show();
                this.Hide();

            }
            else
            {
                _formHijo.BringToFront();
                this.Hide();


            }
        });



    }

    private static async Task SimulacionCarga(IProgress<int> progress)
    {


        int total = 100;

        for (int i = 0; i < total; i++)
        {
            // Procesar cada artículo (ejemplo)
            await Task.Delay(20); // Simular trabajo

            int percent = (int)((double)i / total * 100);
            progress.Report(percent);
        }
    }

    private void PanelPrincipal_Paint(object sender, PaintEventArgs e)
    {

    }
}
