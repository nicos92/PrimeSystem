using System.Runtime.Versioning;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PrimeSystem.Utilidades.Validaciones
{
    [SupportedOSPlatform("windows")]
    public partial class ValidadorEmail : ValidadorTextBox
    {

        

        public ValidadorEmail(TextBox textBox, ErrorProvider errorProvider)
            : base(textBox, errorProvider)
        {
            MensajeError = "Por favor, ingresa un correo electrónico válido.";
        }

        public override bool Validar()
        {
            return EmailRegex().IsMatch(_textBox.Text);
        }

        protected override void ValidarKeyPress(object sender, KeyPressEventArgs e)
        {

        }

        [GeneratedRegex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", RegexOptions.Compiled)]
        private static partial Regex EmailRegex();
    }
}