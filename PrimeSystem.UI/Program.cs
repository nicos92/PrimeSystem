
using PrimeSystem.Contrato.Repositorios;
using PrimeSystem.Contrato.Servicios;
using PrimeSystem.Repositorio.Repositorios;
using PrimeSystem.Servicio.Implementaciones;

namespace PrimeSystem.UI;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
       


        ApplicationConfiguration.Initialize();
       // Application.Run(new FormPrincipal());
    }    
}