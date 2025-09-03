namespace PrimeSystem.UI.Articulos
{
    partial class UCIngresoArticulos
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
            TLPMedio = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            TLPForm = new TableLayoutPanel();
            label3 = new Label();
            LblCuit = new Label();
            TxtGanancia = new TextBox();
            TxtCosto = new TextBox();
            TxtCantidad = new TextBox();
            TxtDescripcion = new TextBox();
            label4 = new Label();
            label2 = new Label();
            BtnIngresar = new Button();
            CMBProveedor = new ComboBox();
            CMBSubcategoria = new ComboBox();
            CMBCategoria = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label1 = new Label();
            ProgressBar = new ProgressBar();
            PanelMedio.SuspendLayout();
            TLPMedio.SuspendLayout();
            groupBox1.SuspendLayout();
            TLPForm.SuspendLayout();
            SuspendLayout();
            // 
            // PanelMedio
            // 
            PanelMedio.Controls.Add(TLPMedio);
            PanelMedio.Dock = DockStyle.Fill;
            PanelMedio.Location = new Point(0, 0);
            PanelMedio.Name = "PanelMedio";
            PanelMedio.Size = new Size(804, 561);
            PanelMedio.TabIndex = 4;
            // 
            // TLPMedio
            // 
            TLPMedio.BackColor = Color.FromArgb(218, 218, 220);
            TLPMedio.ColumnCount = 1;
            TLPMedio.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TLPMedio.Controls.Add(groupBox1, 0, 1);
            TLPMedio.Controls.Add(ProgressBar, 0, 0);
            TLPMedio.Dock = DockStyle.Fill;
            TLPMedio.Location = new Point(0, 0);
            TLPMedio.Name = "TLPMedio";
            TLPMedio.RowCount = 2;
            TLPMedio.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
            TLPMedio.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TLPMedio.Size = new Size(804, 561);
            TLPMedio.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.Controls.Add(TLPForm);
            groupBox1.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(7, 100, 147);
            groupBox1.Location = new Point(85, 80);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(633, 417);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Formulario de Ingreso de Articulos";
            // 
            // TLPForm
            // 
            TLPForm.BackColor = Color.FromArgb(249, 249, 251);
            TLPForm.ColumnCount = 3;
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.5759983F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.7474747F));
            TLPForm.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.6765184F));
            TLPForm.Controls.Add(label3, 0, 4);
            TLPForm.Controls.Add(LblCuit, 0, 1);
            TLPForm.Controls.Add(TxtGanancia, 1, 4);
            TLPForm.Controls.Add(TxtCosto, 1, 3);
            TLPForm.Controls.Add(TxtCantidad, 1, 2);
            TLPForm.Controls.Add(TxtDescripcion, 1, 1);
            TLPForm.Controls.Add(label4, 0, 2);
            TLPForm.Controls.Add(label2, 0, 3);
            TLPForm.Controls.Add(BtnIngresar, 1, 8);
            TLPForm.Controls.Add(CMBProveedor, 1, 5);
            TLPForm.Controls.Add(CMBSubcategoria, 1, 7);
            TLPForm.Controls.Add(CMBCategoria, 1, 6);
            TLPForm.Controls.Add(label6, 0, 5);
            TLPForm.Controls.Add(label5, 0, 7);
            TLPForm.Controls.Add(label1, 0, 6);
            TLPForm.Dock = DockStyle.Fill;
            TLPForm.ForeColor = Color.FromArgb(26, 28, 30);
            TLPForm.Location = new Point(3, 29);
            TLPForm.Name = "TLPForm";
            TLPForm.RowCount = 10;
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 2.323359F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 11.6167955F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 11.6167955F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 11.6167955F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 11.6167955F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 11.6167955F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 11.6167955F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 11.6167955F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 14.0357161F));
            TLPForm.RowStyles.Add(new RowStyle(SizeType.Percent, 2.323359F));
            TLPForm.Size = new Size(627, 385);
            TLPForm.TabIndex = 0;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(13, 151);
            label3.Name = "label3";
            label3.Size = new Size(94, 21);
            label3.TabIndex = 3;
            label3.Text = "Ganancia: %";
            // 
            // LblCuit
            // 
            LblCuit.Anchor = AnchorStyles.Right;
            LblCuit.AutoSize = true;
            LblCuit.Font = new Font("Segoe UI", 12F);
            LblCuit.Location = new Point(13, 19);
            LblCuit.Name = "LblCuit";
            LblCuit.Size = new Size(94, 21);
            LblCuit.TabIndex = 0;
            LblCuit.Text = "Descripción:";
            // 
            // TxtGanancia
            // 
            TxtGanancia.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtGanancia.BackColor = Color.FromArgb(238, 237, 240);
            TxtGanancia.Font = new Font("Segoe UI", 12F);
            TxtGanancia.ForeColor = Color.FromArgb(26, 28, 30);
            TxtGanancia.Location = new Point(113, 147);
            TxtGanancia.MaxLength = 12;
            TxtGanancia.Name = "TxtGanancia";
            TxtGanancia.Size = new Size(418, 29);
            TxtGanancia.TabIndex = 8;
            TxtGanancia.TextChanged += TxtDescripcion_TextChanged;
            // 
            // TxtCosto
            // 
            TxtCosto.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtCosto.BackColor = Color.FromArgb(238, 237, 240);
            TxtCosto.Font = new Font("Segoe UI", 12F);
            TxtCosto.ForeColor = Color.FromArgb(26, 28, 30);
            TxtCosto.Location = new Point(113, 103);
            TxtCosto.MaxLength = 12;
            TxtCosto.Name = "TxtCosto";
            TxtCosto.Size = new Size(418, 29);
            TxtCosto.TabIndex = 7;
            TxtCosto.TextChanged += TxtDescripcion_TextChanged;
            // 
            // TxtCantidad
            // 
            TxtCantidad.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtCantidad.BackColor = Color.FromArgb(238, 237, 240);
            TxtCantidad.Font = new Font("Segoe UI", 12F);
            TxtCantidad.ForeColor = Color.FromArgb(26, 28, 30);
            TxtCantidad.Location = new Point(113, 59);
            TxtCantidad.MaxLength = 12;
            TxtCantidad.Name = "TxtCantidad";
            TxtCantidad.Size = new Size(418, 29);
            TxtCantidad.TabIndex = 6;
            TxtCantidad.TextChanged += TxtDescripcion_TextChanged;
            // 
            // TxtDescripcion
            // 
            TxtDescripcion.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtDescripcion.BackColor = Color.FromArgb(238, 237, 240);
            TxtDescripcion.Font = new Font("Segoe UI", 12F);
            TxtDescripcion.ForeColor = Color.FromArgb(26, 28, 30);
            TxtDescripcion.Location = new Point(113, 15);
            TxtDescripcion.MaxLength = 50;
            TxtDescripcion.Name = "TxtDescripcion";
            TxtDescripcion.Size = new Size(418, 29);
            TxtDescripcion.TabIndex = 5;
            TxtDescripcion.TextChanged += TxtDescripcion_TextChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(32, 63);
            label4.Name = "label4";
            label4.Size = new Size(75, 21);
            label4.TabIndex = 4;
            label4.Text = "Cantidad:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(41, 107);
            label2.Name = "label2";
            label2.Size = new Size(66, 21);
            label2.TabIndex = 2;
            label2.Text = "Costo: $";
            // 
            // BtnIngresar
            // 
            BtnIngresar.Anchor = AnchorStyles.None;
            BtnIngresar.BackColor = Color.FromArgb(7, 100, 147);
            BtnIngresar.Enabled = false;
            BtnIngresar.FlatAppearance.BorderColor = Color.FromArgb(203, 230, 255);
            BtnIngresar.FlatStyle = FlatStyle.Flat;
            BtnIngresar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnIngresar.ForeColor = Color.FromArgb(255, 255, 255);
            BtnIngresar.Image = Properties.Resources.ingresar;
            BtnIngresar.Location = new Point(226, 319);
            BtnIngresar.Margin = new Padding(0);
            BtnIngresar.Name = "BtnIngresar";
            BtnIngresar.Size = new Size(192, 48);
            BtnIngresar.TabIndex = 14;
            BtnIngresar.Text = "INGRESAR";
            BtnIngresar.TextImageRelation = TextImageRelation.TextBeforeImage;
            BtnIngresar.UseVisualStyleBackColor = false;
            BtnIngresar.Click += BtnIngresar_Click;
            // 
            // CMBProveedor
            // 
            CMBProveedor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CMBProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBProveedor.Font = new Font("Segoe UI", 12F);
            CMBProveedor.FormattingEnabled = true;
            CMBProveedor.Location = new Point(113, 191);
            CMBProveedor.Name = "CMBProveedor";
            CMBProveedor.Size = new Size(418, 29);
            CMBProveedor.TabIndex = 13;
            // 
            // CMBSubcategoria
            // 
            CMBSubcategoria.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CMBSubcategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBSubcategoria.Font = new Font("Segoe UI", 12F);
            CMBSubcategoria.FormattingEnabled = true;
            CMBSubcategoria.Location = new Point(113, 279);
            CMBSubcategoria.Name = "CMBSubcategoria";
            CMBSubcategoria.Size = new Size(418, 29);
            CMBSubcategoria.TabIndex = 15;
            // 
            // CMBCategoria
            // 
            CMBCategoria.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CMBCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            CMBCategoria.Font = new Font("Segoe UI", 12F);
            CMBCategoria.FormattingEnabled = true;
            CMBCategoria.Location = new Point(113, 235);
            CMBCategoria.Name = "CMBCategoria";
            CMBCategoria.Size = new Size(418, 29);
            CMBCategoria.TabIndex = 16;
            CMBCategoria.SelectedIndexChanged += CMBCategoria_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(22, 195);
            label6.Name = "label6";
            label6.Size = new Size(85, 21);
            label6.TabIndex = 17;
            label6.Text = "Proveedor:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(3, 283);
            label5.Name = "label5";
            label5.Size = new Size(104, 21);
            label5.TabIndex = 12;
            label5.Text = "Subcategoria:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(27, 239);
            label1.Name = "label1";
            label1.Size = new Size(80, 21);
            label1.TabIndex = 1;
            label1.Text = "Categoria:";
            // 
            // ProgressBar
            // 
            ProgressBar.Dock = DockStyle.Fill;
            ProgressBar.Location = new Point(0, 0);
            ProgressBar.Margin = new Padding(0);
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(804, 16);
            ProgressBar.TabIndex = 16;
            // 
            // UCIngresoArticulos
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(249, 249, 251);
            Controls.Add(PanelMedio);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(26, 28, 30);
            Margin = new Padding(4);
            Name = "UCIngresoArticulos";
            Size = new Size(804, 561);
            Load += UCIngresoArticulos_Load;
            PanelMedio.ResumeLayout(false);
            TLPMedio.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            TLPForm.ResumeLayout(false);
            TLPForm.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelMedio;
        private TableLayoutPanel TLPMedio;
        private GroupBox groupBox1;
        private TableLayoutPanel TLPForm;
        private Label label1;
        private Label label3;
        private Label LblCuit;
        private TextBox TxtGanancia;
        private TextBox TxtCosto;
        private TextBox TxtCantidad;
        private TextBox TxtDescripcion;
        private Label label4;
        private Label label2;
        private Label label5;
        private ComboBox CMBProveedor;
        private Button BtnIngresar;
        private ComboBox CMBSubcategoria;
        private ComboBox CMBCategoria;
        private Label label6;
        private ProgressBar ProgressBar;
    }
}
