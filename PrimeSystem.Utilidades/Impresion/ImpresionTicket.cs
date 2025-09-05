using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace PrimeSystem.Utilidades.Impresion
{
    [SupportedOSPlatform("windows")]
    public static class ImpresionTicket
    {
        // Este método debe ser llamado desde el hilo de la UI (por ejemplo, desde el evento click de un botón).
        public static void Imprimir(List<ProductoVenta> productos, string numeroOperacion, string motivo, string montoTotal)
        {
            // 1. Define la ruta a tu plantilla.
            string rutaPlantilla = Path.Combine(Application.StartupPath, "Impresion", "Impresion.html");

            // 2. Crea una instancia del generador de tickets
            var generador = new GeneradorTickets(rutaPlantilla);

            // 3. Genera el HTML final con los datos
            string htmlFinal = generador.GenerarHtmlTicket(
                montoTotal: montoTotal,
                motivo: motivo,
                numeroOperacion: numeroOperacion,
                productos: productos
            );

            if (htmlFinal.StartsWith("Error:"))
            {
                MessageBox.Show(htmlFinal, "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Crea un WebBrowser control dinámicamente para imprimir
            WebBrowser webBrowserParaImprimir = new WebBrowser();

            // Agregamos un manejador de eventos para cuando el documento esté listo
            webBrowserParaImprimir.DocumentCompleted += (sender, e) =>
            {
                // Una vez cargado el HTML, se manda a imprimir
                webBrowserParaImprimir.Print();

                // Es importante liberar los recursos del control después de usarlo
                webBrowserParaImprimir.Dispose();
            };

            // 5. Carga el HTML en el control
            webBrowserParaImprimir.DocumentText = htmlFinal;
        }
    }
}