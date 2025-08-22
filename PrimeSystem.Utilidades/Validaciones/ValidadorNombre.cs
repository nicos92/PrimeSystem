using System.Runtime.Versioning;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PrimeSystem.Utilidades.Validaciones
{
    [SupportedOSPlatform("windows")]
    public partial class ValidadorNombre : ValidadorTextBox
    {
     

        public ValidadorNombre(TextBox textBox, ErrorProvider errorProvider)
            : base(textBox, errorProvider)
        {
            MensajeError = "Ingresa al menos un nombre y un apellido (solo letras).";
        }

        public override bool Validar()
        {
            // Primero, valida el patrón general
            if (!Nombreregex().IsMatch(_textBox.Text))
            {
                return false;
            }

            return true;
        }

        // Nuevo: Bloquea cualquier tecla que no sea una letra, un espacio o la tecla de retroceso
        protected override void ValidarKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        [GeneratedRegex(@"^[a-zA-ZáéíóúÁÉÍÓÚÀÈÌÒÙàèìòùñÑ\s]+$", RegexOptions.Compiled)]
        private static partial Regex Nombreregex();
    }
}