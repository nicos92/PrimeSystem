using System.Runtime.Versioning;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PrimeSystem.Utilidades.Validaciones
{
    [SupportedOSPlatform("windows")]
    public partial class ValidadorNumeroDecimal : ValidadorTextBox
    {
        public ValidadorNumeroDecimal(TextBox textBox, ErrorProvider errorProvider)
            : base(textBox, errorProvider)
        {
            MensajeError = "Ingresa un número con dos decimales exactos.";
        }

        public override bool Validar()
        {
            // Usa `double.TryParse` para verificar si es un número válido.
            if (!double.TryParse(s: _textBox.Text, result: out _))
            {
                return false;
            }

            // Convierte el número a string y verifica el número de decimales
            return DecimalRegex().IsMatch(_textBox.Text);
        }

        // Nuevo: Bloquea cualquier tecla que no sea un dígito o la tecla de retroceso (Backspace)
        protected override void ValidarKeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true; // Ignora la entrada de la tecla
            }
            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains('.'))
            {
                e.Handled = true; // Ignora la entrada de la tecla

            }
        }

        [GeneratedRegex(@"^\d+(.\d{1,3})?$", RegexOptions.Compiled)]
        private static partial Regex DecimalRegex();
    }
}