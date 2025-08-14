using Microsoft.Extensions.DependencyInjection;
using PrimeSystem.Contrato.Repositorios;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Repositorio.Repositorios;
using PrimeSystem.Servicio.Implementaciones;
using PrimeSystem.UI;
using PrimeSystem.UI.Clientes;
using PrimeSystem.UI.Compras;
using PrimeSystem.UI.EstadoContable;
using PrimeSystem.UI.Proveedores;
using PrimeSystem.UI.Usuarios;
using PrimeSystem.UI.Ventas;

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
        services.AddTransient<FormArranque>();      // Este Form estaría en PrimeSystem.Arranque
        services.AddTransient<FormPrincipal>();     // Este Form estaría en PrimeSystem.UI
        services.AddTransient<FormVentas>();        // Este Form estaría en PrimeSystem.UI.Ventas
        services.AddTransient<FormCompras>();       // Este Form estaría en PrimeSystem.UI.Compras
        services.AddTransient<FormClientes>();      // Este Form estaría en PrimeSystem.UI.Clientes
        services.AddTransient<FormUsuarios>();      // Este Form estaría en PrimeSystem.UI.Usuarios
        services.AddTransient<FormProveedores>();  // Este Form estaría en PrimeSystem.UI.Proveedores
        services.AddTransient<FormEstadoContable>(); // Este Form estaría en PrimeSystem.UI.EstadoContable

        // Registrar servicios (ejemplo)
        // services.AddScoped<IClienteService, ClienteService>();

        services.AddScoped<IArticulosRepository, ArticulosRepository>();
        services.AddScoped<IArticulosService, ArticulosService>();
    }
}