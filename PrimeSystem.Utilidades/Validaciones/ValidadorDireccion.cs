using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeSystem.Utilidades.Validaciones
{
    [SupportedOSPlatform("windows")]
    public partial class ValidadorDireccion : ValidadorTextBox
    {
        public ValidadorDireccion(TextBox textBox, ErrorProvider errorProvider): base(textBox, errorProvider) {
            MensajeError = "Ingresa al menos una direccion";
        }
        public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(_textBox.Text))
            {
                return false;
            }

            return DireccionRegex().IsMatch(_textBox.Text);
        }

        protected override void ValidarKeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        [GeneratedRegex(@"^[a-zA-Z0-9áéíóúÁÉÍÓÚÀÈÌÒÙàèìòùñÑ\s.,#-]+$", RegexOptions.Compiled)]
        private static partial Regex DireccionRegex();
    }
}
