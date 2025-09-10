namespace PrimeSystem.UI.Ventas
{
    partial class FormVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            GBForm = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label5 = new Label();
            NumericUpDown1 = new NumericUpDown();
            label1 = new Label();
            BtnQuitar = new Button();
            TxtBuscardor = new TextBox();
            BtnAceptar = new Button();
            groupBox1 = new GroupBox();
            LblPrecioCant = new Label();
            LblPPC = new Label();
            LblPrecio = new Label();
            Lbl = new Label();
            LblProducto = new Label();
            label2 = new Label();
            LsvProductos = new ListBox();
            DgvProductosSeleccionados = new DataGridView();
            panel1 = new Panel();
            BtnConfirmarVenta = new Button();
            LblPrecioTotal = new Label();
            label6 = new Label();
            LblCantProductos = new Label();
            label4 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            GBForm.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericUpDown1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvProductosSeleccionados).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = Utilidades.AppColorsBlue.SurfaceDim;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(GBForm);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(DgvProductosSeleccionados);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Size = new Size(804, 561);
            splitContainer1.SplitterDistance = 312;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // GBForm
            // 
            GBForm.Controls.Add(tableLayoutPanel1);
            GBForm.Dock = DockStyle.Fill;
            GBForm.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GBForm.ForeColor = Utilidades.AppColorsBlue.Primary;
            GBForm.Location = new Point(0, 0);
            GBForm.Margin = new Padding(4);
            GBForm.Name = "GBForm";
            GBForm.Padding = new Padding(4);
            GBForm.Size = new Size(312, 561);
            GBForm.TabIndex = 0;
            GBForm.TabStop = false;
            GBForm.Text = "Formulario Producto";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Utilidades.AppColorsBlue.Background;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 5);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(BtnQuitar, 0, 7);
            tableLayoutPanel1.Controls.Add(TxtBuscardor, 0, 1);
            tableLayoutPanel1.Controls.Add(BtnAceptar, 0, 6);
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 4);
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(LsvProductos, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(4, 30);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(304, 527);
            tableLayoutPanel1.TabIndex = 9;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(label5, 0, 0);
            tableLayoutPanel2.Controls.Add(NumericUpDown1, 1, 0);
            tableLayoutPanel2.Location = new Point(3, 390);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(298, 44);
            tableLayoutPanel2.TabIndex = 8;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Utilidades.AppColorsBlue.OnBackground;
            label5.Location = new Point(3, 11);
            label5.Name = "label5";
            label5.Size = new Size(75, 21);
            label5.TabIndex = 6;
            label5.Text = "Cantidad:";
            // 
            // NumericUpDown1
            // 
            NumericUpDown1.Anchor = AnchorStyles.None;
            NumericUpDown1.BackColor = Utilidades.AppColorsBlue.SurfaceContainer;
            NumericUpDown1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NumericUpDown1.ForeColor = Utilidades.AppColorsBlue.OnBackground;
            NumericUpDown1.Location = new Point(84, 7);
            NumericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericUpDown1.Name = "NumericUpDown1";
            NumericUpDown1.Size = new Size(211, 29);
            NumericUpDown1.TabIndex = 3;
            NumericUpDown1.TextAlign = HorizontalAlignment.Right;
            NumericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NumericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Utilidades.AppColorsBlue.OnBackground;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(162, 21);
            label1.TabIndex = 1;
            label1.Text = "BUSCAR PRODUCTO:";
            // 
            // BtnQuitar
            // 
            BtnQuitar.Anchor = AnchorStyles.None;
            BtnQuitar.BackColor = Utilidades.AppColorsBlue.Secondary;
            BtnQuitar.FlatAppearance.BorderColor = Utilidades.AppColorsBlue.SecondaryContainer;
            BtnQuitar.FlatStyle = FlatStyle.Flat;
            BtnQuitar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            BtnQuitar.ForeColor = Utilidades.AppColorsBlue.OnSecondary;
            BtnQuitar.Location = new Point(19, 486);
            BtnQuitar.Margin = new Padding(4);
            BtnQuitar.Name = "BtnQuitar";
            BtnQuitar.Size = new Size(265, 37);
            BtnQuitar.TabIndex = 5;
            BtnQuitar.Text = "QUITAR 1 UNIDAD";
            BtnQuitar.UseVisualStyleBackColor = false;
            BtnQuitar.Click += BtnQuitar_Click;
            // 
            // TxtBuscardor
            // 
            TxtBuscardor.BackColor = Utilidades.AppColorsBlue.SurfaceContainer;
            TxtBuscardor.Font = new Font("Segoe UI", 12F);
            TxtBuscardor.ForeColor = Utilidades.AppColorsBlue.OnBackground;
            TxtBuscardor.Location = new Point(3, 24);
            TxtBuscardor.Name = "TxtBuscardor";
            TxtBuscardor.Size = new Size(265, 29);
            TxtBuscardor.TabIndex = 1;
            TxtBuscardor.TextChanged += TxtBuscardor_TextChanged;
            // 
            // BtnAceptar
            // 
            BtnAceptar.Anchor = AnchorStyles.None;
            BtnAceptar.BackColor = Utilidades.AppColorsBlue.Primary;
            BtnAceptar.FlatAppearance.BorderColor = Utilidades.AppColorsBlue.PrimaryContainer;
            BtnAceptar.FlatStyle = FlatStyle.Flat;
            BtnAceptar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            BtnAceptar.ForeColor = Utilidades.AppColorsBlue.OnPrimary;
            BtnAceptar.Location = new Point(19, 441);
            BtnAceptar.Margin = new Padding(4);
            BtnAceptar.Name = "BtnAceptar";
            BtnAceptar.Size = new Size(265, 37);
            BtnAceptar.TabIndex = 4;
            BtnAceptar.Text = "AGREGAR";
            BtnAceptar.UseVisualStyleBackColor = false;
            BtnAceptar.Click += BtnAceptar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(LblPrecioCant);
            groupBox1.Controls.Add(LblPPC);
            groupBox1.Controls.Add(LblPrecio);
            groupBox1.Controls.Add(Lbl);
            groupBox1.Controls.Add(LblProducto);
            groupBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Utilidades.AppColorsBlue.Primary;
            groupBox1.Location = new Point(3, 287);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(298, 97);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "PRODUCTO";
            // 
            // LblPrecioCant
            // 
            LblPrecioCant.AutoSize = true;
            LblPrecioCant.Font = new Font("Segoe UI", 12F);
            LblPrecioCant.ForeColor = Utilidades.AppColorsBlue.OnBackground;
            LblPrecioCant.Location = new Point(197, 63);
            LblPrecioCant.Name = "LblPrecioCant";
            LblPrecioCant.Size = new Size(19, 21);
            LblPrecioCant.TabIndex = 9;
            LblPrecioCant.Text = "0";
            // 
            // LblPPC
            // 
            LblPPC.AutoSize = true;
            LblPPC.Font = new Font("Segoe UI", 12F);
            LblPPC.ForeColor = Utilidades.AppColorsBlue.OnBackground;
            LblPPC.Location = new Point(19, 63);
            LblPPC.Name = "LblPPC";
            LblPPC.Size = new Size(181, 21);
            LblPPC.TabIndex = 8;
            LblPPC.Text = "PRECIO POR CANTIDAD:";
            // 
            // LblPrecio
            // 
            LblPrecio.AutoSize = true;
            LblPrecio.Font = new Font("Segoe UI", 12F);
            LblPrecio.ForeColor = Utilidades.AppColorsBlue.OnBackground;
            LblPrecio.Location = new Point(83, 42);
            LblPrecio.Name = "LblPrecio";
            LblPrecio.Size = new Size(19, 21);
            LblPrecio.TabIndex = 7;
            LblPrecio.Text = "0";
            // 
            // Lbl
            // 
            Lbl.AutoSize = true;
            Lbl.Font = new Font("Segoe UI", 12F);
            Lbl.ForeColor = Utilidades.AppColorsBlue.OnBackground;
            Lbl.Location = new Point(19, 42);
            Lbl.Name = "Lbl";
            Lbl.Size = new Size(70, 21);
            Lbl.TabIndex = 6;
            Lbl.Text = "PRECIO: ";
            // 
            // LblProducto
            // 
            LblProducto.AutoSize = true;
            LblProducto.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblProducto.ForeColor = Utilidades.AppColorsBlue.OnBackground;
            LblProducto.Location = new Point(19, 21);
            LblProducto.Name = "LblProducto";
            LblProducto.Size = new Size(92, 21);
            LblProducto.TabIndex = 5;
            LblProducto.Text = "PRODUCTO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Utilidades.AppColorsBlue.OnBackground;
            label2.Location = new Point(3, 56);
            label2.Name = "label2";
            label2.Size = new Size(97, 21);
            label2.TabIndex = 3;
            label2.Text = "PRODUCTO:";
            // 
            // LsvProductos
            // 
            LsvProductos.BackColor = Utilidades.AppColorsBlue.SurfaceContainer;
            LsvProductos.Dock = DockStyle.Fill;
            LsvProductos.Font = new Font("Segoe UI", 12F);
            LsvProductos.ForeColor = Utilidades.AppColorsBlue.OnBackground;
            LsvProductos.Location = new Point(3, 80);
            LsvProductos.Name = "LsvProductos";
            LsvProductos.Size = new Size(298, 201);
            LsvProductos.TabIndex = 2;
            LsvProductos.SelectedIndexChanged += LsvProductos_SelectedIndexChanged;
            // 
            // DgvProductosSeleccionados
            // 
            DgvProductosSeleccionados.AllowUserToAddRows = false;
            DgvProductosSeleccionados.AllowUserToDeleteRows = false;
            DgvProductosSeleccionados.BackgroundColor = Utilidades.AppColorsBlue.Surface;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Utilidades.AppColorsBlue.SurfaceContainerHigh;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Utilidades.AppColorsBlue.OnSurfaceVariant;
            dataGridViewCellStyle1.SelectionBackColor = Utilidades.AppColorsBlue.PrimaryContainer;
            dataGridViewCellStyle1.SelectionForeColor = Utilidades.AppColorsBlue.OnPrimaryContainer;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DgvProductosSeleccionados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DgvProductosSeleccionados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Utilidades.AppColorsBlue.Surface;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Utilidades.AppColorsBlue.OnSurface;
            dataGridViewCellStyle2.SelectionBackColor = Utilidades.AppColorsBlue.PrimaryContainer;
            dataGridViewCellStyle2.SelectionForeColor = Utilidades.AppColorsBlue.OnPrimaryContainer;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DgvProductosSeleccionados.DefaultCellStyle = dataGridViewCellStyle2;
            DgvProductosSeleccionados.Dock = DockStyle.Fill;
            DgvProductosSeleccionados.GridColor = Utilidades.AppColorsBlue.OutlineVariant;
            DgvProductosSeleccionados.Location = new Point(0, 26);
            DgvProductosSeleccionados.Name = "DgvProductosSeleccionados";
            DgvProductosSeleccionados.ReadOnly = true;
            DgvProductosSeleccionados.RowHeadersVisible = false;
            DgvProductosSeleccionados.Size = new Size(487, 435);
            DgvProductosSeleccionados.TabIndex = 6;
            DgvProductosSeleccionados.CellClick += DgvProductosSeleccionados_CellClick;
            DgvProductosSeleccionados.SelectionChanged += DgvProductosSeleccionados_SelectionChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Utilidades.AppColorsBlue.SurfaceContainerHigh;
            panel1.Controls.Add(BtnConfirmarVenta);
            panel1.Controls.Add(LblPrecioTotal);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(LblCantProductos);
            panel1.Controls.Add(label4);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 461);
            panel1.Name = "panel1";
            panel1.Size = new Size(487, 100);
            panel1.TabIndex = 5;
            // 
            // BtnConfirmarVenta
            // 
            BtnConfirmarVenta.BackColor = Utilidades.AppColorsBlue.Tertiary;
            BtnConfirmarVenta.FlatAppearance.BorderColor = Utilidades.AppColorsBlue.TertiaryContainer;
            BtnConfirmarVenta.FlatStyle = FlatStyle.Flat;
            BtnConfirmarVenta.ForeColor = Utilidades.AppColorsBlue.OnTertiary;
            BtnConfirmarVenta.Location = new Point(113, 48);
            BtnConfirmarVenta.Name = "BtnConfirmarVenta";
            BtnConfirmarVenta.Size = new Size(265, 40);
            BtnConfirmarVenta.TabIndex = 7;
            BtnConfirmarVenta.Text = "CONFIRMAR VENTA";
            BtnConfirmarVenta.UseVisualStyleBackColor = false;
            BtnConfirmarVenta.Click += BtnConfirmarVenta_Click;
            // 
            // LblPrecioTotal
            // 
            LblPrecioTotal.AutoSize = true;
            LblPrecioTotal.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblPrecioTotal.ForeColor = Utilidades.AppColorsBlue.OnBackground;
            LblPrecioTotal.Location = new Point(359, 11);
            LblPrecioTotal.Name = "LblPrecioTotal";
            LblPrecioTotal.Size = new Size(23, 25);
            LblPrecioTotal.TabIndex = 5;
            LblPrecioTotal.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Utilidades.AppColorsBlue.OnBackground;
            label6.Location = new Point(253, 17);
            label6.Name = "label6";
            label6.Size = new Size(100, 17);
            label6.TabIndex = 4;
            label6.Text = "PRECIO TOTAL: ";
            label6.Click += label6_Click;
            // 
            // LblCantProductos
            // 
            LblCantProductos.AutoSize = true;
            LblCantProductos.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblCantProductos.ForeColor = Utilidades.AppColorsBlue.OnBackground;
            LblCantProductos.Location = new Point(151, 11);
            LblCantProductos.Name = "LblCantProductos";
            LblCantProductos.Size = new Size(23, 25);
            LblCantProductos.TabIndex = 3;
            LblCantProductos.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Utilidades.AppColorsBlue.OnBackground;
            label4.Location = new Point(28, 8);
            label4.Name = "label4";
            label4.Size = new Size(93, 34);
            label4.TabIndex = 2;
            label4.Text = "CANTIDAD DE\r\nPRODUCTOS:";
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Utilidades.AppColorsBlue.Primary;
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(8);
            label3.Name = "label3";
            label3.Size = new Size(487, 26);
            label3.TabIndex = 4;
            label3.Text = "LISTA DE PRODUCTOS SELECCIONADOS";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormVentas
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Utilidades.AppColorsBlue.Background;
            ClientSize = new Size(804, 561);
            Controls.Add(splitContainer1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormVentas";
            Text = "Producto";
            FormClosing += FormVentas_FormClosing;
            Load += FormVentas_Load;
            KeyDown += FormVentas_KeyDown;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            GBForm.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericUpDown1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvProductosSeleccionados).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox GBForm;
        //private System.Windows.Forms.ComboBox CmbProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DgvProductosSeleccionados;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.NumericUpDown NumericUpDown1;
        private System.Windows.Forms.TextBox TxtBuscardor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblPrecioTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblCantProductos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnConfirmarVenta;
        private System.Windows.Forms.Label LblPrecio;
        private System.Windows.Forms.Label Lbl;
        private System.Windows.Forms.Label LblProducto;
        private System.Windows.Forms.Label LblPrecioCant;
        private System.Windows.Forms.Label LblPPC;
        private Button BtnQuitar;

        private ListBox LsvProductos;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label5;
    }
}