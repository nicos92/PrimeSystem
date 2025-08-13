using Microsoft.Extensions.DependencyInjection;
using PrimeSystem.Contrato.Repositorios;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Repositorio.Repositorios;
using PrimeSystem.Servicio.Implementaciones;
using PrimeSystem.UI;

namespace PrimeSystem.Arranque;

static class Program
{
    public static IServiceProvider? ServiceProvider { get; private set; }
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.


        ApplicationConfiguration.Initialize();

        var services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();

        var mainForm = ServiceProvider.GetRequiredService<FormArranque>();
        Application.Run(mainForm);
        //Application.Run(new FormArranque());
    }

    private static void ConfigureServices(ServiceCollection services)
    {
        // Registrar formularios
        services.AddTransient<FormArranque>();
        services.AddTransient<FormPrincipal>();  // Este estaría en WinFormsApp.UI

        // Registrar servicios (ejemplo)
        // services.AddScoped<IClienteService, ClienteService>();

        services.AddScoped<IArticulosRepository, ArticulosRepository>();
        services.AddScoped<IArticulosService, ArticulosService>();
    }
}