using Microsoft.Extensions.DependencyInjection;
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


        ApplicationConfiguration.Initialize();

        var services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();

        var mainForm = ServiceProvider.GetRequiredService<FormArranque>();
        Application.Run(mainForm);
    }

    private static void ConfigureServices(ServiceCollection services)
    {
        // Registrar formularios
        services.AddTransient<FormArranque>();      // Este Form estaría en PrimeSystem.Arranque

        services.AddTransient<FormPrincipal>();     // Este Form estaría en PrimeSystem.UI

        services.AddTransient<FormArticulos>();     // Este Form estatñia en PrimeSystem.UI
        services.AddTransient<UCIngresoArticulos>();    // Este UC se encuentra en PrimeSystem.UI
        services.AddTransient<UCConsultaArticulos>();   // este UC se encuentra en PrimeSystem.UI

        services.AddTransient<FormVentas>();        // Este Form estaría en PrimeSystem.UI.Ventas

        services.AddTransient<FormCompras>();       // Este Form estaría en PrimeSystem.UI.Compras

        services.AddTransient<FormClientes>();      // Este Form estaría en PrimeSystem.UI.Clientes
        services.AddTransient<UCIgresoCliente>(); // Este UserControl estaría en PrimeSystem.UI.Clientes
        services.AddTransient<UCConsultaClientes>(); // Este UserControl estaría en PrimeSystem.UI.Clientes

        services.AddTransient<FormUsuarios>();      // Este Form estaría en PrimeSystem.UI.Usuarios
        services.AddTransient<USConsultaUsuario>(); // Este UserControl estaría en PrimeSystem.UI.Usuarios
        services.AddTransient<UCIngresoUsuarios>(); // Este UserControl estaría en PrimeSystem.UI.Usuarios

        services.AddTransient<FormProveedores>();  // Este Form estaría en PrimeSystem.UI.Proveedores
        services.AddTransient<UCIngresoProveedores>(); // Este UserControl estaría en PrimeSystem.UI.Proveedores
        services.AddTransient<UCConsultaProveedor>();   // Este UserControl estaría en PrimeSystem.UI.Proveedores

        services.AddTransient<FormEstadoContable>(); // Este Form estaría en PrimeSystem.UI.EstadoContable

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



    }
}