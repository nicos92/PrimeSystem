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

        protected ValidadorTextBox(TextBox textBox, ErrorProvider errorProvider)
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

        // Cambia la firma del método TextBox_TextChanged para aceptar sender como nullable
        private void TextBox_TextChanged(object? sender, System.EventArgs e)
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
        private void TextBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (sender is not TextBox)
            {
                return; // Asegura que sender sea un TextBox
            }
            ValidarKeyPress(sender, e);
        }

        
       
    }
}