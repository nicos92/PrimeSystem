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
            ListBProveedores = new ListBox();
            LblLista = new Label();
            panel1 = new Panel();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
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
            PanelLista.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // PanelLista
            // 
            PanelLista.BackColor = Color.FromArgb(218, 218, 220);
            PanelLista.Controls.Add(ListBProveedores);
            PanelLista.Controls.Add(LblLista);
            PanelLista.Dock = DockStyle.Left;
            PanelLista.Location = new Point(0, 0);
            PanelLista.Name = "PanelLista";
            PanelLista.Padding = new Padding(0, 16, 0, 16);
            PanelLista.Size = new Size(200, 463);
            PanelLista.TabIndex = 0;
            // 
            // ListBProveedores
            // 
            ListBProveedores.BackColor = Color.FromArgb(249, 249, 251);
            ListBProveedores.Dock = DockStyle.Fill;
            ListBProveedores.FormattingEnabled = true;
            ListBProveedores.Location = new Point(0, 37);
            ListBProveedores.Name = "ListBProveedores";
            ListBProveedores.Size = new Size(200, 410);
            ListBProveedores.TabIndex = 0;
            // 
            // LblLista
            // 
            LblLista.Dock = DockStyle.Top;
            LblLista.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblLista.Location = new Point(0, 16);
            LblLista.Name = "LblLista";
            LblLista.Size = new Size(200, 21);
            LblLista.TabIndex = 1;
            LblLista.Text = "Lista de Proveedores";
            LblLista.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel4);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(200, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(444, 463);
            panel1.TabIndex = 1;
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
            tableLayoutPanel4.Size = new Size(444, 463);
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
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(LblCuit, 0, 1);
            tableLayoutPanel1.Controls.Add(TxtTel, 1, 4);
            tableLayoutPanel1.Controls.Add(TxtNombre, 1, 3);
            tableLayoutPanel1.Controls.Add(TxtProveedor, 1, 2);
            tableLayoutPanel1.Controls.Add(TxtCuit, 1, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 6);
            tableLayoutPanel1.ForeColor = Color.FromArgb(26, 28, 30);
            tableLayoutPanel1.Location = new Point(3, 41);
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
            tableLayoutPanel1.Size = new Size(438, 381);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // TxtEmail
            // 
            TxtEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtEmail.BackColor = Color.FromArgb(238, 237, 240);
            TxtEmail.Font = new Font("Segoe UI", 12F);
            TxtEmail.ForeColor = Color.FromArgb(26, 28, 30);
            TxtEmail.Location = new Point(102, 235);
            TxtEmail.MaxLength = 11;
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(277, 29);
            TxtEmail.TabIndex = 9;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(45, 239);
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
            label3.Location = new Point(62, 188);
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
            label4.Location = new Point(25, 137);
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
            label2.Location = new Point(11, 86);
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
            LblCuit.Location = new Point(50, 35);
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
            TxtTel.Location = new Point(102, 184);
            TxtTel.MaxLength = 11;
            TxtTel.Name = "TxtTel";
            TxtTel.Size = new Size(277, 29);
            TxtTel.TabIndex = 8;
            // 
            // TxtNombre
            // 
            TxtNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtNombre.BackColor = Color.FromArgb(238, 237, 240);
            TxtNombre.Font = new Font("Segoe UI", 12F);
            TxtNombre.ForeColor = Color.FromArgb(26, 28, 30);
            TxtNombre.Location = new Point(102, 133);
            TxtNombre.MaxLength = 11;
            TxtNombre.Name = "TxtNombre";
            TxtNombre.Size = new Size(277, 29);
            TxtNombre.TabIndex = 7;
            // 
            // TxtProveedor
            // 
            TxtProveedor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtProveedor.BackColor = Color.FromArgb(238, 237, 240);
            TxtProveedor.Font = new Font("Segoe UI", 12F);
            TxtProveedor.ForeColor = Color.FromArgb(26, 28, 30);
            TxtProveedor.Location = new Point(102, 82);
            TxtProveedor.MaxLength = 11;
            TxtProveedor.Name = "TxtProveedor";
            TxtProveedor.Size = new Size(277, 29);
            TxtProveedor.TabIndex = 6;
            // 
            // TxtCuit
            // 
            TxtCuit.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtCuit.BackColor = Color.FromArgb(238, 237, 240);
            TxtCuit.Font = new Font("Segoe UI", 12F);
            TxtCuit.ForeColor = Color.FromArgb(26, 28, 30);
            TxtCuit.Location = new Point(102, 31);
            TxtCuit.MaxLength = 11;
            TxtCuit.Name = "TxtCuit";
            TxtCuit.Size = new Size(277, 29);
            TxtCuit.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(BtnGuardar, 0, 0);
            tableLayoutPanel2.Controls.Add(BtnEliminar, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(102, 278);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel1.SetRowSpan(tableLayoutPanel2, 2);
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(277, 100);
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
            BtnGuardar.Location = new Point(10, 26);
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
            BtnEliminar.Location = new Point(183, 26);
            BtnEliminar.Margin = new Padding(0);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(48, 48);
            BtnEliminar.TabIndex = 1;
            BtnEliminar.Text = "E";
            BtnEliminar.UseVisualStyleBackColor = false;
            // 
            // UCConsultaProveedor
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(249, 249, 251);
            Controls.Add(panel1);
            Controls.Add(PanelLista);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(26, 28, 30);
            Margin = new Padding(5);
            Name = "UCConsultaProveedor";
            Size = new Size(644, 463);
            Load += UCConsultaProveedor_Load;
            PanelLista.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelLista;
        private ListBox ListBProveedores;
        private Label LblLista;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel1;
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
    }
}
