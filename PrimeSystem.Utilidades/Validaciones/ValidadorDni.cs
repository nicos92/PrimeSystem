
using System.Runtime.Versioning;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PrimeSystem.Utilidades.Validaciones
{
    [SupportedOSPlatform("windows")]
    public partial class ValidadorDni : ValidadorTextBox
    {

        public ValidadorDni(TextBox textBox, ErrorProvider errorProvider)
            : base(textBox, errorProvider)
        {
            MensajeError = "El DNI debe tener el formato 12345678.";
        }
        public override bool Validar()
        {
            return DniRegex().IsMatch(_textBox.Text);
        }

        protected override void ValidarKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

        }

        [GeneratedRegex(@"^(0|\d{8})$", RegexOptions.Compiled)]
        private static partial Regex DniRegex();
    }
}
