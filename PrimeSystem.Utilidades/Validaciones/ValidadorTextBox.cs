using System.Runtime.Versioning;
using System.Windows.Forms;

namespace PrimeSystem.Utilidades.Validaciones
{
    [SupportedOSPlatform("windows")]
    public abstract class ValidadorTextBox
    {
        protected TextBox _textBox;
        protected ErrorProvider _errorProvider;

        public string? MensajeError { get; set; }

        public ValidadorTextBox(TextBox textBox, ErrorProvider errorProvider)
        {
            _textBox = textBox;
            _errorProvider = errorProvider;
            _textBox.TextChanged += TextBox_TextChanged;
            _textBox.KeyPress += TextBox_KeyPress;
        }

        // abstracto que las clases derivadas deben implementar
        public abstract bool Validar();

        // Método abstracto para validar cada tecla presionada
        protected abstract void ValidarKeyPress(object sender, KeyPressEventArgs e);

        // Evento que se dispara cada vez que el texto del TextBox cambia
        private void TextBox_TextChanged(object sender, System.EventArgs e)
        {
            if (Validar())
            {
                _errorProvider.SetError(_textBox, ""); // Borra el error si es válido
            }
            else
            {
                _errorProvider.SetError(_textBox, MensajeError); // Muestra el error
            }
        }

        // Manejador del evento KeyPress
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarKeyPress(sender, e);
        }
    }
}