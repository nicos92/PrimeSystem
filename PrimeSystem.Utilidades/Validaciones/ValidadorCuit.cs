using System.Runtime.Versioning;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PrimeSystem.Utilidades.Validaciones
{
    [SupportedOSPlatform("windows")]
    public partial class ValidadorCUIT : ValidadorTextBox
    {
        

        public ValidadorCUIT(TextBox textBox, ErrorProvider errorProvider)
            : base(textBox, errorProvider)
        {
            MensajeError = "El CUIT debe tener el formato 12345678901.";
        }

        public override bool Validar()
        {
            return CuitRegex().IsMatch(_textBox.Text);
        }

        // Nuevo: Solo permite números y guiones, y evita guiones en posiciones incorrectas
        protected override void ValidarKeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite dígitos, guiones y la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }



          
        }

        [GeneratedRegex(@"^(0|\d{11})$", RegexOptions.Compiled)]
        private static partial Regex CuitRegex();
    }
}