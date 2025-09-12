using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.Map;
using PrimeSystem.Contrato.Repositorios;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Repositorio.Repositorios;
using PrimeSystem.Servicio.Implementaciones;
using PrimeSystem.UI;
using PrimeSystem.UI.Articulos;
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

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .Enrich.FromLogContext()
            .WriteTo.Debug() // Envía todos los logs a la ventana de Salida/Debug
            .WriteTo.Map(logEvent =>
            {
                // Obtener el SourceContext que ILogger<T> agrega automáticamente
                if (logEvent.Properties.TryGetValue("SourceContext", out var sourceContext))
                {
                    var namespaceStr = sourceContext.ToString().Trim('"');
                    if (namespaceStr.StartsWith("PrimeSystem.UI.Articulos")) return "Articulos";
                    if (namespaceStr.StartsWith("PrimeSystem.UI.Clientes")) return "Clientes";
                    if (namespaceStr.StartsWith("PrimeSystem.UI.Compras")) return "Compras";
                    if (namespaceStr.StartsWith("PrimeSystem.UI.Proveedores")) return "Proveedores";
                    if (namespaceStr.StartsWith("PrimeSystem.UI.Usuarios")) return "Usuarios";
                    if (namespaceStr.StartsWith("PrimeSystem.UI.Ventas")) return "Ventas";
                    if (namespaceStr.StartsWith("PrimeSystem.UI.EstadoContable")) return "EstadoContable";
                }
                // Clave por defecto para todo lo demás (servicios, repositorios, arranque, etc.)
                return "General";
            },
            (key, sinkConfiguration) =>
            {
                // Configurar un archivo de log para cada clave
                sinkConfiguration.File($"logs\\{key.ToLower()}-.txt", rollingInterval: RollingInterval.Day);
            })
            .CreateLogger();

        try
        {
            Log.Information("Iniciando la aplicación PrimeSystem.");

            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var mainForm = ServiceProvider.GetRequiredService<FormArranque>();
            Application.Run(mainForm);
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "La aplicación ha terminado de forma inesperada.");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    private static void ConfigureServices(ServiceCollection services)
    {
        // Registrar Serilog para inyección de dependencias
        services.AddLogging(builder => builder.AddSerilog(dispose: true));

        // Registrar formularios
        services.AddTransient<FormArranque>();      // Este Form estar�a en PrimeSystem.Arranque

        services.AddTransient<FormPrincipal>();     // Este Form estar�a en PrimeSystem.UI

        services.AddTransient<FormArticulos>();     // Este Form estat�ia en PrimeSystem.UI
        services.AddTransient<UCIngresoArticulos>();    // Este UC se encuentra en PrimeSystem.UI
        services.AddTransient<UCConsultaArticulos>();   // este UC se encuentra en PrimeSystem.UI

        services.AddTransient<FormVentas>();        // Este Form estar�a en PrimeSystem.UI.Ventas

        services.AddTransient<FormCompras>();       // Este Form estar�a en PrimeSystem.UI.Compras

        services.AddTransient<FormClientes>();      // Este Form estar�a en PrimeSystem.UI.Clientes
        services.AddTransient<UCIgresoCliente>(); // Este UserControl estar�a en PrimeSystem.UI.Clientes
        services.AddTransient<UCConsultaClientes>(); // Este UserControl estar�a en PrimeSystem.UI.Clientes

        services.AddTransient<FormUsuarios>();      // Este Form estar�a en PrimeSystem.UI.Usuarios
        services.AddTransient<USConsultaUsuario>(); // Este UserControl estar�a en PrimeSystem.UI.Usuarios
        services.AddTransient<UCIngresoUsuarios>(); // Este UserControl estar�a en PrimeSystem.UI.Usuarios

        services.AddTransient<FormProveedores>();  // Este Form estar�a en PrimeSystem.UI.Proveedores
        services.AddTransient<UCIngresoProveedores>(); // Este UserControl estar�a en PrimeSystem.UI.Proveedores
        services.AddTransient<UCConsultaProveedor>();   // Este UserControl estar�a en PrimeSystem.UI.Proveedores

        services.AddTransient<FormEstadoContable>(); // Este Form estar�a en PrimeSystem.UI.EstadoContable

        // Registrar servicios (ejemplo)
        services.AddScoped<IArticuloStockRepository, ArticuloStockRepository>();
        services.AddScoped<IArticuloStockService, ArticuloStockService>();

        services.AddScoped<IArticulosRepository, ArticulosRepository>();
        services.AddScoped<IArticulosService, ArticulosService>();

        services.AddScoped<ICategoriasRepository, CategoriasRepository>();
        services.AddScoped<ICategoriasService, CategoriasService>();

        services.AddScoped<IClientesRepository, ClientesRepository>();
        services.AddScoped<IClientesService, ClientesService>();

        services.AddScoped<IHComprasDetalleRepository, HComprasDetalleRepository>();
        services.AddScoped<IHComprasDetalleService, HComprasDetalleService>();

        services.AddScoped<IHComprasRepository, HComprasRepository>();
        services.AddScoped<IHComprasService, HComprasService>();

        services.AddScoped<IProveedoresRepository, ProveedoresRepository>();
        services.AddScoped<IProveedoresService, ProveedoresService>();

        services.AddScoped<IUsuariosRepository, UsuariosRepository>();
        services.AddScoped<IUsuariosService, UsuariosService>();

        services.AddScoped<IHVentasRepository, HVentasRepository>();
        services.AddScoped<IHVentasService, HVentasService>();

        services.AddScoped<IHVentasDetalleRepository, HVentasDetalleRepository>();
        services.AddScoped<IHVentasDetalleService, HVentasDetalleService>();

        services.AddScoped<IUsuariosTipoRepository, UsuariosTipoRepository>();
        services.AddScoped<IUsuariosTipoService, UsuariosTipoService>();

        services.AddScoped<ISubcategoriaRepository, SubCategoriaRepository>();
        services.AddScoped<ISubcategoriaService, SubcategoriaService>();

        services.AddScoped<IStockRepository, StockRepository>();
        services.AddScoped<IStockService, StockService>();

        services.AddScoped<IHMovimientosRepository, HMovimientosRepository>();
        services.AddScoped<IHMovimientosService, HMovimientosService>();

        services.AddScoped<IInOutVariosRepository, InOutVariosRepository>();
        services.AddScoped<IInOutVariosService, InOutVariosService>();

        services.AddScoped<IVentaRepository, VentaRepository>();
        services.AddScoped<IVentaService, VentaService>();

    }
}