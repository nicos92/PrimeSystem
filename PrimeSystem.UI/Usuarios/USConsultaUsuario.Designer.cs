using PrimeSystem.Utilidades;

namespace PrimeSystem.UI.Usuarios
{
    partial class USConsultaUsuario
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            PanelMedio = new Panel();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            TxtEmail = new TextBox();
            label1 = new Label();
            label3 = new Label();
            LblCuit = new Label();
            TxtTel = new TextBox();
            TxtApellido = new TextBox();
            TxtNombre = new TextBox();
            TxtDni = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            BtnGuardar = new Button();
            BtnEliminar = new Button();
            label4 = new Label();
            label2 = new Label();
            label5 = new Label();
            CMBTipoUsuario = new ComboBox();
            PanelLista = new Panel();
            ListBUsuarios = new ListBox();
            LblLista = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            PanelMedio.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            PanelLista.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // PanelMedio
            // 
            PanelMedio.Controls.Add(tableLayoutPanel4);
            PanelMedio.Dock = DockStyle.Fill;
            PanelMedio.Location = new Point(292, 3);
            PanelMedio.Name = "PanelMedio";
            PanelMedio.Size = new Size(429, 491);
            PanelMedio.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.FromArgb(218, 218, 220);
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(tableLayoutPanel1, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(429, 491);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.None;
            tableLayoutPanel1.BackColor = Color.FromArgb(249, 249, 251);
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.83105F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.84018F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5570774F));
            tableLayoutPanel1.Controls.Add(TxtEmail, 1, 5);
            tableLayoutPanel1.Controls.Add(label1, 0, 5);
            tableLayoutPanel1.Controls.Add(label3, 0, 4);
            tableLayoutPanel1.Controls.Add(LblCuit, 0, 1);
            tableLayoutPanel1.Controls.Add(TxtTel, 1, 4);
            tableLayoutPanel1.Controls.Add(TxtApellido, 1, 3);
            tableLayoutPanel1.Controls.Add(TxtNombre, 1, 2);
            tableLayoutPanel1.Controls.Add(TxtDni, 1, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 7);
            tableLayoutPanel1.Controls.Add(label4, 0, 2);
            tableLayoutPanel1.Controls.Add(label2, 0, 3);
            tableLayoutPanel1.Controls.Add(label5, 0, 6);
            tableLayoutPanel1.Controls.Add(CMBTipoUsuario, 1, 6);
            tableLayoutPanel1.ForeColor = Color.FromArgb(26, 28, 30);
            tableLayoutPanel1.Location = new Point(3, 55);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5.40540552F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5135136F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5135136F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5135136F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5135136F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5135136F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5135136F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5135136F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(423, 381);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // TxtEmail
            // 
            TxtEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtEmail.BackColor = Color.FromArgb(238, 237, 240);
            TxtEmail.Font = new Font("Segoe UI", 12F);
            TxtEmail.ForeColor = Color.FromArgb(26, 28, 30);
            TxtEmail.Location = new Point(99, 235);
            TxtEmail.MaxLength = 11;
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(267, 29);
            TxtEmail.TabIndex = 9;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(42, 239);
            label1.Name = "label1";
            label1.Size = new Size(51, 21);
            label1.TabIndex = 1;
            label1.Text = "Email:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(59, 188);
            label3.Name = "label3";
            label3.Size = new Size(34, 21);
            label3.TabIndex = 3;
            label3.Text = "Tel.:";
            // 
            // LblCuit
            // 
            LblCuit.Anchor = AnchorStyles.Right;
            LblCuit.AutoSize = true;
            LblCuit.Font = new Font("Segoe UI", 12F);
            LblCuit.Location = new Point(53, 35);
            LblCuit.Name = "LblCuit";
            LblCuit.Size = new Size(40, 21);
            LblCuit.TabIndex = 0;
            LblCuit.Text = "DNI:";
            // 
            // TxtTel
            // 
            TxtTel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtTel.BackColor = Color.FromArgb(238, 237, 240);
            TxtTel.Font = new Font("Segoe UI", 12F);
            TxtTel.ForeColor = Color.FromArgb(26, 28, 30);
            TxtTel.Location = new Point(99, 184);
            TxtTel.MaxLength = 11;
            TxtTel.Name = "TxtTel";
            TxtTel.Size = new Size(267, 29);
            TxtTel.TabIndex = 8;
            // 
            // TxtApellido
            // 
            TxtApellido.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtApellido.BackColor = Color.FromArgb(238, 237, 240);
            TxtApellido.Font = new Font("Segoe UI", 12F);
            TxtApellido.ForeColor = Color.FromArgb(26, 28, 30);
            TxtApellido.Location = new Point(99, 133);
            TxtApellido.MaxLength = 11;
            TxtApellido.Name = "TxtApellido";
            TxtApellido.Size = new Size(267, 29);
            TxtApellido.TabIndex = 7;
            // 
            // TxtNombre
            // 
            TxtNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtNombre.BackColor = Color.FromArgb(238, 237, 240);
            TxtNombre.Font = new Font("Segoe UI", 12F);
            TxtNombre.ForeColor = Color.FromArgb(26, 28, 30);
            TxtNombre.Location = new Point(99, 82);
            TxtNombre.MaxLength = 11;
            TxtNombre.Name = "TxtNombre";
            TxtNombre.Size = new Size(267, 29);
            TxtNombre.TabIndex = 6;
            // 
            // TxtDni
            // 
            TxtDni.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtDni.BackColor = Color.FromArgb(238, 237, 240);
            TxtDni.Font = new Font("Segoe UI", 12F);
            TxtDni.ForeColor = Color.FromArgb(26, 28, 30);
            TxtDni.Location = new Point(99, 31);
            TxtDni.MaxLength = 11;
            TxtDni.Name = "TxtDni";
            TxtDni.Size = new Size(267, 29);
            TxtDni.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(BtnGuardar, 0, 0);
            tableLayoutPanel2.Controls.Add(BtnEliminar, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(99, 329);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(267, 49);
            tableLayoutPanel2.TabIndex = 11;
            // 
            // BtnGuardar
            // 
            BtnGuardar.Anchor = AnchorStyles.None;
            BtnGuardar.BackColor = Color.FromArgb(101, 89, 119);
            BtnGuardar.FlatAppearance.BorderColor = Color.FromArgb(203, 230, 255);
            BtnGuardar.FlatStyle = FlatStyle.Flat;
            BtnGuardar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnGuardar.ForeColor = Color.FromArgb(255, 255, 255);
            BtnGuardar.Location = new Point(8, 0);
            BtnGuardar.Margin = new Padding(0);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(117, 48);
            BtnGuardar.TabIndex = 10;
            BtnGuardar.Text = "Guardar";
            BtnGuardar.UseVisualStyleBackColor = false;
            // 
            // BtnEliminar
            // 
            BtnEliminar.Anchor = AnchorStyles.None;
            BtnEliminar.BackColor = Color.FromArgb(186, 26, 26);
            BtnEliminar.FlatAppearance.BorderColor = Color.FromArgb(203, 230, 255);
            BtnEliminar.FlatStyle = FlatStyle.Flat;
            BtnEliminar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnEliminar.ForeColor = Color.FromArgb(255, 255, 255);
            BtnEliminar.Location = new Point(176, 0);
            BtnEliminar.Margin = new Padding(0);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(48, 48);
            BtnEliminar.TabIndex = 1;
            BtnEliminar.Text = "E";
            BtnEliminar.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(22, 86);
            label4.Name = "label4";
            label4.Size = new Size(71, 21);
            label4.TabIndex = 4;
            label4.Text = "Nombre:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(23, 137);
            label2.Name = "label2";
            label2.Size = new Size(70, 21);
            label2.TabIndex = 2;
            label2.Text = "Apellido:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(50, 290);
            label5.Name = "label5";
            label5.Size = new Size(43, 21);
            label5.TabIndex = 12;
            label5.Text = "Tipo:";
            // 
            // CMBTipoUsuario
            // 
            CMBTipoUsuario.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CMBTipoUsuario.BackColor = Color.FromArgb(238, 237, 240);
            CMBTipoUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBTipoUsuario.ForeColor = Color.FromArgb(26, 28, 30);
            CMBTipoUsuario.FormattingEnabled = true;
            CMBTipoUsuario.Location = new Point(99, 289);
            CMBTipoUsuario.Name = "CMBTipoUsuario";
            CMBTipoUsuario.Size = new Size(267, 29);
            CMBTipoUsuario.TabIndex = 13;
            // 
            // PanelLista
            // 
            PanelLista.BackColor = Color.FromArgb(218, 218, 220);
            PanelLista.Controls.Add(ListBUsuarios);
            PanelLista.Controls.Add(LblLista);
            PanelLista.Dock = DockStyle.Fill;
            PanelLista.Location = new Point(3, 3);
            PanelLista.Name = "PanelLista";
            PanelLista.Padding = new Padding(0, 16, 0, 16);
            PanelLista.Size = new Size(283, 491);
            PanelLista.TabIndex = 3;
            // 
            // ListBUsuarios
            // 
            ListBUsuarios.BackColor = Color.FromArgb(249, 249, 251);
            ListBUsuarios.Dock = DockStyle.Fill;
            ListBUsuarios.FormattingEnabled = true;
            ListBUsuarios.Location = new Point(0, 37);
            ListBUsuarios.Name = "ListBUsuarios";
            ListBUsuarios.Size = new Size(283, 438);
            ListBUsuarios.TabIndex = 0;
            // 
            // LblLista
            // 
            LblLista.Dock = DockStyle.Top;
            LblLista.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblLista.Location = new Point(0, 16);
            LblLista.Name = "LblLista";
            LblLista.Size = new Size(283, 21);
            LblLista.TabIndex = 1;
            LblLista.Text = "Lista de Usuarios";
            LblLista.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.FromArgb(218, 218, 220);
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel3.Controls.Add(PanelLista, 0, 0);
            tableLayoutPanel3.Controls.Add(PanelMedio, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(724, 497);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // USConsultaUsuario
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(249, 249, 251);
            Controls.Add(tableLayoutPanel3);
            Font = new Font("Segoe UI", 12F);
            ForeColor = Color.FromArgb(26, 28, 30);
            Margin = new Padding(4);
            Name = "USConsultaUsuario";
            Size = new Size(724, 497);
            PanelMedio.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            PanelLista.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelMedio;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox TxtEmail;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label LblCuit;
        private TextBox TxtTel;
        private TextBox TxtApellido;
        private TextBox TxtNombre;
        private TextBox TxtDni;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BtnGuardar;
        private Button BtnEliminar;
        private Panel PanelLista;
        private ListBox ListBUsuarios;
        private Label LblLista;
        private Label label5;
        private ComboBox CMBTipoUsuario;
        private TableLayoutPanel tableLayoutPanel3;
    }
}
