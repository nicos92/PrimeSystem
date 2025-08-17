using Microsoft.Extensions.DependencyInjection;
using PrimeSystem.UI;
using PrimeSystem.Utilidades;

namespace PrimeSystem.Arranque;

public partial class FormArranque : Form
{
    private readonly IServiceProvider _serviceProvider;
    public FormArranque(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeComponent();
    }

    private Form? _formHijo;

    private async void Form1_Load(object sender, EventArgs e)
    {

        LblBienvenido.ForeColor = PaletaGrisA.Gris100;
        LblCargando.ForeColor = PaletaGrisA.Gris150;

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
                // Aca llamo al formulario principal que esta en PrimeSystem.UI
                _formHijo = _serviceProvider.GetRequiredService<FormPrincipal>();
                _formHijo.Closed += (s, e) =>
                {
                    this.Close();
                };
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

    
}
