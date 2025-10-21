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
        public static void Imprimir(List<ProductoVenta> productos, string numeroOperacion, string motivo, string montoTotal)
        {
            // ... (Pasos para generar htmlFinal se mantienen) ...
            string rutaPlantilla = Path.Combine(Application.StartupPath, "Impresion", "Impresion.html");
            var generador = new GeneradorTickets(rutaPlantilla);
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

            // 1. Crea un WebBrowser control dinámicamente y configura un tamaño.
            // Aunque no es visible, definir un tamaño ayuda a estabilizar el control.
            WebBrowser webBrowserParaImprimir = new WebBrowser
            {
                Width = 800, // Tamaño representativo de una hoja
                Height = 600
            };

            // Bandera para controlar la ejecución de la impresión
            bool impresionIniciada = false;

            // 2. Manejador del evento DocumentCompleted
            webBrowserParaImprimir.DocumentCompleted += (sender, e) =>
            {
                // Solo actúa si la impresión no ha sido iniciada.
                // También aseguramos que la URL actual sea el HTML cargado (normalmente about:blank para DocumentText).
                if (!impresionIniciada)
                {
                    // Manda a imprimir el documento.
                    webBrowserParaImprimir.Print();

                    // Establecemos la bandera en true para salir del bucle.
                    impresionIniciada = true;
                }
            };

            // 3. Carga el HTML.
            // Al usar DocumentText, la carga ocurre de inmediato en el bucle de mensajes.
            webBrowserParaImprimir.DocumentText = htmlFinal;

            // 4. 🔑 Bucle de espera crítica (con Timeout)
            int timeout = 5000; // Máximo 5 segundos de espera
            DateTime inicio = DateTime.Now;

            // El bucle de espera bloquea el hilo de la UI hasta que la impresión se inicia
            while (!impresionIniciada && (DateTime.Now - inicio).TotalMilliseconds < timeout)
            {
                // NECESARIO: Procesa todos los mensajes de la UI, lo que permite que el WebBrowser 
                // procese DocumentText y dispare DocumentCompleted.
                Application.DoEvents();

                // Pausa ligera para evitar el consumo de CPU.
                System.Threading.Thread.Sleep(5); // Reducido a 5ms
            }

            // 5. Verificación de TimeOut
            if (!impresionIniciada)
            {
                MessageBox.Show("Error al iniciar la impresión. Tiempo de espera agotado.", "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // 6. Liberar recursos.
            webBrowserParaImprimir.Dispose();
        }
    }
}