using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeSystem.Utilidades.Validaciones
{
    [SupportedOSPlatform("windows")]
    public static class ValidadorMultiple
    {
        public static void ValidacionMultiple(Button[] btn, params ValidadorTextBox[] validaciones )
        {

            btn.ToList().ForEach(b => b.Enabled = validaciones.All(a => a.Validar()));
            
        }
    }
}
