using PrimeSystem.Utilidades;

namespace PrimeSystem.UI.Proveedores
{
    partial class UCConsultaProveedor
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
            PanelLista = new Panel();
            TLPLista = new TableLayoutPanel();
            ListBProveedores = new ListBox();
            LblLista = new Label();
            panel1 = new Panel();
            tableLayoutPanel4 = new TableLayoutPanel();
            GBFormProveedores = new GroupBox();
            TLPForm = new TableLayoutPanel();
            TxtEmail = new TextBox();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            LblCuit = new Label();
            TxtTel = new TextBox();
            TxtNombre = new TextBox();
            TxtProveedor = new TextBox();
            TxtCuit = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            BtnGuardar = new Button();
            BtnEliminar = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            PanelLista.SuspendLayout();
            TLPLista.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            GBFormProveedores.SuspendLayout();
            TLPForm.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // PanelLista
            // 
            PanelLista.BackColor = Color.FromArgb(218, 218, 220);
            PanelLista.Controls.Add(TLPLista);
            PanelLista.Dock = DockStyle.Fill;
            PanelLista.Location = new Point(3, 3);
            PanelLista.Name = "PanelLista";
            PanelLista.Padding = new Padding(0, 16, 0, 16);
            PanelLista.Size = new Size(315, 555);
            PanelLista.TabIndex = 0;
            // 
            // TLPLista
            // 
            TLPLista.ColumnCount = 1;
            TLPLista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TLPLista.Controls.Add(ListBProveedores, 0, 1);
            TLPLista.Controls.Add(LblLista, 0, 0);
            TLPLista.Dock = DockStyle.Fill;
            TLPLista.Location = new Point(0, 16);
            TLPLista.Name = "TLPLista";
            TLPLista.RowCount = 2;
            TLPLista.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            TLPLista.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TLPLista.Size = new Size(315, 523);
            TLPLista.TabIndex = 2;
            // 
            // ListBProveedores
            // 
            ListBProveedores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            ListBProveedores.BackColor = Color.FromArgb(238, 237, 240);
            ListBProveedores.FormattingEnabled = true;
            ListBProveedores.Location = new Point(3, 35);
            ListBProveedores.Name = "ListBProveedores";
            ListBProveedores.Size = new Size(309, 466);
            ListBProveedores.TabIndex = 0;
            ListBProveedores.SelectedIndexChanged += ListBProveedores_SelectedIndexChanged;
            // 
            // LblLista
            // 
            LblLista.Dock = DockStyle.Top;
            LblLista.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblLista.ForeColor = Color.FromArgb(7, 100, 147);
            LblLista.Location = new Point(3, 0);
            LblLista.Name = "LblLista";
            LblLista.Size = new Size(309, 21);
            LblLista.TabIndex = 1;
            LblLista.Text = "Lista de Proveedores";
            LblLista.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel4);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(324, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(477, 555);
            panel1.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.FromArgb(218, 218, 220);
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(GBFormProveedores, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(477, 555);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // GBFormProveedores
            // 
            GBFormProveedores.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            GBFormProveedores.Controls.Add(TLPForm);
            GBFormProveedores.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GBFormProveedores.ForeColor = Color.FromArgb(7, 100, 147);
            GBFormProveedores.Location = new Point(3, 54);
            GBFormProveedores.Name = "GBFormProveedores";
            GBFormProveedores.Size = new Size(471, 447);
            GBFormProveedores.TabIndex = 12;
            GBFormProveedores.TabStop = false;
            GBFormProveedores.Text = "Formulario de Edición de Proveedores";
            // 
            // TLPForm
            // 
            TLPForm.BackColor = Color.FromArgb(249, 249, 251);
            TLPForm.ColumnCount = 3;
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.83105F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.84018F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5570774F));
            TLPForm.Controls.Add(TxtEmail, 1, 5);
            TLPForm.Controls.Add(label1, 0, 5);
            TLPForm.Controls.Add(label3, 0, 4);
            TLPForm.Controls.Add(label4, 0, 3);
            TLPForm.Controls.Add(label2, 0, 2);
            TLPForm.Controls.Add(LblCuit, 0, 1);
            TLPForm.Controls.Add(TxtTel, 1, 4);
            TLPForm.Controls.Add(TxtNombre, 1, 3);
            TLPForm.Controls.Add(TxtProveedor, 1, 2);
            TLPForm.Controls.Add(TxtCuit, 1, 1);
            TLPForm.Controls.Add(tableLayoutPanel2, 1, 6);
            TLPForm.Dock = DockStyle.Fill;
            TLPForm.ForeColor = Color.FromArgb(26, 28, 30);
            TLPForm.Location = new Point(3, 25);
            TLPForm.Name = "TLPForm";
            TLPForm.RowCount = 8;
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 5.40540552F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5135136F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5135136F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5135136F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5135136F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5135136F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5135136F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 13.5135136F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TLPForm.Size = new Size(465, 419);
            TLPForm.TabIndex = 0;
            // 
            // TxtEmail
            // 
            TxtEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtEmail.BackColor = Color.FromArgb(238, 237, 240);
            TxtEmail.Font = new Font("Segoe UI", 12F);
            TxtEmail.ForeColor = Color.FromArgb(26, 28, 30);
            TxtEmail.Location = new Point(108, 259);
            TxtEmail.MaxLength = 255;
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(294, 29);
            TxtEmail.TabIndex = 9;
            TxtEmail.TextChanged += TxtCuit_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(51, 263);
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
            label3.Location = new Point(68, 207);
            label3.Name = "label3";
            label3.Size = new Size(34, 21);
            label3.TabIndex = 3;
            label3.Text = "Tel.:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(31, 151);
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
            label2.Location = new Point(17, 95);
            label2.Name = "label2";
            label2.Size = new Size(85, 21);
            label2.TabIndex = 2;
            label2.Text = "Proveedor:";
            // 
            // LblCuit
            // 
            LblCuit.Anchor = AnchorStyles.Right;
            LblCuit.AutoSize = true;
            LblCuit.Font = new Font("Segoe UI", 12F);
            LblCuit.Location = new Point(56, 39);
            LblCuit.Name = "LblCuit";
            LblCuit.Size = new Size(46, 21);
            LblCuit.TabIndex = 0;
            LblCuit.Text = "CUIT:";
            // 
            // TxtTel
            // 
            TxtTel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtTel.BackColor = Color.FromArgb(238, 237, 240);
            TxtTel.Font = new Font("Segoe UI", 12F);
            TxtTel.ForeColor = Color.FromArgb(26, 28, 30);
            TxtTel.Location = new Point(108, 203);
            TxtTel.MaxLength = 11;
            TxtTel.Name = "TxtTel";
            TxtTel.Size = new Size(294, 29);
            TxtTel.TabIndex = 8;
            TxtTel.TextChanged += TxtCuit_TextChanged;
            // 
            // TxtNombre
            // 
            TxtNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtNombre.BackColor = Color.FromArgb(238, 237, 240);
            TxtNombre.Font = new Font("Segoe UI", 12F);
            TxtNombre.ForeColor = Color.FromArgb(26, 28, 30);
            TxtNombre.Location = new Point(108, 147);
            TxtNombre.MaxLength = 50;
            TxtNombre.Name = "TxtNombre";
            TxtNombre.Size = new Size(294, 29);
            TxtNombre.TabIndex = 7;
            TxtNombre.TextChanged += TxtCuit_TextChanged;
            // 
            // TxtProveedor
            // 
            TxtProveedor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtProveedor.BackColor = Color.FromArgb(238, 237, 240);
            TxtProveedor.Font = new Font("Segoe UI", 12F);
            TxtProveedor.ForeColor = Color.FromArgb(26, 28, 30);
            TxtProveedor.Location = new Point(108, 91);
            TxtProveedor.MaxLength = 50;
            TxtProveedor.Name = "TxtProveedor";
            TxtProveedor.Size = new Size(294, 29);
            TxtProveedor.TabIndex = 6;
            TxtProveedor.TextChanged += TxtCuit_TextChanged;
            // 
            // TxtCuit
            // 
            TxtCuit.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtCuit.BackColor = Color.FromArgb(238, 237, 240);
            TxtCuit.Font = new Font("Segoe UI", 12F);
            TxtCuit.ForeColor = Color.FromArgb(26, 28, 30);
            TxtCuit.Location = new Point(108, 35);
            TxtCuit.MaxLength = 11;
            TxtCuit.Name = "TxtCuit";
            TxtCuit.Size = new Size(294, 29);
            TxtCuit.TabIndex = 5;
            TxtCuit.TextChanged += TxtCuit_TextChanged;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(BtnGuardar, 0, 0);
            tableLayoutPanel2.Controls.Add(BtnEliminar, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(108, 305);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            TLPForm.SetRowSpan(tableLayoutPanel2, 2);
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(294, 111);
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
            BtnGuardar.Image = Properties.Resources.guardar;
            BtnGuardar.ImageAlign = ContentAlignment.MiddleRight;
            BtnGuardar.Location = new Point(8, 23);
            BtnGuardar.Margin = new Padding(0);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(131, 64);
            BtnGuardar.TabIndex = 10;
            BtnGuardar.Text = "Guardar";
            BtnGuardar.TextAlign = ContentAlignment.MiddleRight;
            BtnGuardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            BtnGuardar.UseVisualStyleBackColor = false;
            BtnGuardar.Click += BtnGuardar_Click;
            // 
            // BtnEliminar
            // 
            BtnEliminar.Anchor = AnchorStyles.None;
            BtnEliminar.BackColor = Color.FromArgb(186, 26, 26);
            BtnEliminar.FlatAppearance.BorderColor = Color.FromArgb(203, 230, 255);
            BtnEliminar.FlatStyle = FlatStyle.Flat;
            BtnEliminar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnEliminar.ForeColor = Color.FromArgb(255, 255, 255);
            BtnEliminar.Image = Properties.Resources.trash;
            BtnEliminar.Location = new Point(188, 23);
            BtnEliminar.Margin = new Padding(0);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(64, 64);
            BtnEliminar.TabIndex = 11;
            BtnEliminar.UseVisualStyleBackColor = false;
            BtnEliminar.Click += BtnEliminar_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.FromArgb(218, 218, 220);
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel3.Controls.Add(PanelLista, 0, 0);
            tableLayoutPanel3.Controls.Add(panel1, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(804, 561);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // UCConsultaProveedor
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(249, 249, 251);
            Controls.Add(tableLayoutPanel3);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(26, 28, 30);
            Margin = new Padding(5);
            Name = "UCConsultaProveedor";
            Size = new Size(804, 561);
            Load += UCConsultaProveedor_Load;
            PanelLista.ResumeLayout(false);
            TLPLista.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            GBFormProveedores.ResumeLayout(false);
            TLPForm.ResumeLayout(false);
            TLPForm.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelLista;
        private ListBox ListBProveedores;
        private Label LblLista;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel TLPForm;
        private TextBox TxtEmail;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label LblCuit;
        private TextBox TxtTel;
        private TextBox TxtNombre;
        private TextBox TxtProveedor;
        private TextBox TxtCuit;
        private Button BtnEliminar;
        private Button BtnGuardar;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private GroupBox GBFormProveedores;
        private TableLayoutPanel TLPLista;
    }
}
