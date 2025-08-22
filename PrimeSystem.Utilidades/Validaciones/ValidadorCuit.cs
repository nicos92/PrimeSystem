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
            MensajeError = "El CUIT debe tener el formato ##-########-#.";
        }

        public override bool Validar()
        {
            return CuitRegex().IsMatch(_textBox.Text);
        }

        // Nuevo: Solo permite números y guiones, y evita guiones en posiciones incorrectas
        protected override void ValidarKeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite dígitos, guiones y la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }



            // Asegura que no se inserten guiones en lugares incorrectos
            //if (e.KeyChar == '-')
            //{
            //    if (_textBox.Text.Length > 0 && _textBox.Text[_textBox.SelectionStart - 1] == '-')
            //    {
            //        e.Handled = true; // Evita dos guiones seguidos
            //    }

            //    // Verifica si el guion está en la posición 2 o 11 (índice 1 o 10)
            //    if (_textBox.SelectionStart != 2 && _textBox.SelectionStart != 11)
            //    {
            //        e.Handled = true; // Evita guiones en otras posiciones
            //    }
            //}
        }

        [GeneratedRegex(@"^\d{2}-\d{8}-\d{1}$", RegexOptions.Compiled)]
        private static partial Regex CuitRegex();
    }
}