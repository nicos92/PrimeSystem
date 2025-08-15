namespace PrimeSystem.UI.Proveedores
{
    partial class UCIngresoProveedores
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
            BtnIngresar = new Button();
            PanelForm = new Panel();
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
            PanelForm.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnIngresar
            // 
            BtnIngresar.Anchor = AnchorStyles.None;
            BtnIngresar.BackColor = Color.FromArgb(26, 35, 126);
            BtnIngresar.FlatAppearance.BorderColor = Color.FromArgb(96, 125, 139);
            BtnIngresar.FlatStyle = FlatStyle.Flat;
            BtnIngresar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnIngresar.Location = new Point(171, 234);
            BtnIngresar.Margin = new Padding(0);
            BtnIngresar.Name = "BtnIngresar";
            tableLayoutPanel1.SetRowSpan(BtnIngresar, 2);
            BtnIngresar.Size = new Size(192, 48);
            BtnIngresar.TabIndex = 1;
            BtnIngresar.Text = "INGRESAR";
            BtnIngresar.UseVisualStyleBackColor = false;
            // 
            // PanelForm
            // 
            PanelForm.Controls.Add(tableLayoutPanel4);
            PanelForm.Dock = DockStyle.Fill;
            PanelForm.Location = new Point(0, 0);
            PanelForm.Name = "PanelForm";
            PanelForm.Size = new Size(560, 329);
            PanelForm.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.FromArgb(38, 50, 56);
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(tableLayoutPanel1, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(560, 329);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.None;
            tableLayoutPanel1.BackColor = Color.FromArgb(55, 71, 79);
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
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
            tableLayoutPanel1.Controls.Add(BtnIngresar, 1, 6);
            tableLayoutPanel1.Location = new Point(12, 11);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.7117119F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.7117119F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.7117119F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.7117119F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.7117119F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.7117119F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 18.0180187F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.7117119F));
            tableLayoutPanel1.Size = new Size(535, 306);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // TxtEmail
            // 
            TxtEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtEmail.BackColor = Color.FromArgb(38, 50, 56);
            TxtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtEmail.ForeColor = Color.FromArgb(236, 239, 241);
            TxtEmail.Location = new Point(110, 178);
            TxtEmail.MaxLength = 11;
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(315, 29);
            TxtEmail.TabIndex = 9;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(52, 182);
            label1.Name = "label1";
            label1.Size = new Size(52, 21);
            label1.TabIndex = 1;
            label1.Text = "Email:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(66, 147);
            label3.Name = "label3";
            label3.Size = new Size(38, 21);
            label3.TabIndex = 3;
            label3.Text = "Tel.:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(29, 112);
            label4.Name = "label4";
            label4.Size = new Size(75, 21);
            label4.TabIndex = 4;
            label4.Text = "Nombre:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 77);
            label2.Name = "label2";
            label2.Size = new Size(92, 21);
            label2.TabIndex = 2;
            label2.Text = "Proveedor:";
            // 
            // LblCuit
            // 
            LblCuit.Anchor = AnchorStyles.Right;
            LblCuit.AutoSize = true;
            LblCuit.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblCuit.Location = new Point(55, 42);
            LblCuit.Name = "LblCuit";
            LblCuit.Size = new Size(49, 21);
            LblCuit.TabIndex = 0;
            LblCuit.Text = "CUIT:";
            // 
            // TxtTel
            // 
            TxtTel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtTel.BackColor = Color.FromArgb(38, 50, 56);
            TxtTel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtTel.ForeColor = Color.FromArgb(236, 239, 241);
            TxtTel.Location = new Point(110, 143);
            TxtTel.MaxLength = 11;
            TxtTel.Name = "TxtTel";
            TxtTel.Size = new Size(315, 29);
            TxtTel.TabIndex = 8;
            // 
            // TxtNombre
            // 
            TxtNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtNombre.BackColor = Color.FromArgb(38, 50, 56);
            TxtNombre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtNombre.ForeColor = Color.FromArgb(236, 239, 241);
            TxtNombre.Location = new Point(110, 108);
            TxtNombre.MaxLength = 11;
            TxtNombre.Name = "TxtNombre";
            TxtNombre.Size = new Size(315, 29);
            TxtNombre.TabIndex = 7;
            // 
            // TxtProveedor
            // 
            TxtProveedor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtProveedor.BackColor = Color.FromArgb(38, 50, 56);
            TxtProveedor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtProveedor.ForeColor = Color.FromArgb(236, 239, 241);
            TxtProveedor.Location = new Point(110, 73);
            TxtProveedor.MaxLength = 11;
            TxtProveedor.Name = "TxtProveedor";
            TxtProveedor.Size = new Size(315, 29);
            TxtProveedor.TabIndex = 6;
            // 
            // TxtCuit
            // 
            TxtCuit.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtCuit.BackColor = Color.FromArgb(38, 50, 56);
            TxtCuit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtCuit.ForeColor = Color.FromArgb(236, 239, 241);
            TxtCuit.Location = new Point(110, 38);
            TxtCuit.MaxLength = 11;
            TxtCuit.Name = "TxtCuit";
            TxtCuit.Size = new Size(315, 29);
            TxtCuit.TabIndex = 5;
            // 
            // UCIngresoProveedores
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(55, 71, 79);
            Controls.Add(PanelForm);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(236, 239, 241);
            Name = "UCIngresoProveedores";
            Size = new Size(560, 329);
            PanelForm.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel PanelForm;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label4;
        private Label label2;
        private Label LblCuit;
        private Label label3;
        private Label label1;
        private TextBox TxtCuit;
        private TextBox TxtEmail;
        private TextBox TxtTel;
        private TextBox TxtNombre;
        private TextBox TxtProveedor;
        private Button BtnIngresar;
        private TableLayoutPanel tableLayoutPanel4;
    }
}
