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
            splitContainer1 = new SplitContainer();
            GBForm = new GroupBox();
            BtnQuitar = new Button();
            groupBox1 = new GroupBox();
            LblPrecioCant = new Label();
            label8 = new Label();
            LblPrecio = new Label();
            Lbl = new Label();
            LblProducto = new Label();
            label7 = new Label();
            BtnAceptar = new Button();
            NumericUpDown1 = new NumericUpDown();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            CmbProducto = new ComboBox();
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
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DgvProductosSeleccionados).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
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
            splitContainer1.Size = new Size(784, 461);
            splitContainer1.SplitterDistance = 305;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // GBForm
            // 
            GBForm.Controls.Add(BtnQuitar);
            GBForm.Controls.Add(groupBox1);
            GBForm.Controls.Add(BtnAceptar);
            GBForm.Controls.Add(NumericUpDown1);
            GBForm.Controls.Add(textBox1);
            GBForm.Controls.Add(label2);
            GBForm.Controls.Add(label1);
            GBForm.Controls.Add(CmbProducto);
            GBForm.Dock = DockStyle.Fill;
            GBForm.Location = new Point(0, 0);
            GBForm.Margin = new Padding(4);
            GBForm.Name = "GBForm";
            GBForm.Padding = new Padding(4);
            GBForm.Size = new Size(305, 461);
            GBForm.TabIndex = 0;
            GBForm.TabStop = false;
            GBForm.Text = "Formulario Producto";
            // 
            // BtnQuitar
            // 
            BtnQuitar.Location = new Point(12, 409);
            BtnQuitar.Name = "BtnQuitar";
            BtnQuitar.Size = new Size(265, 40);
            BtnQuitar.TabIndex = 9;
            BtnQuitar.Text = "QUITAR";
            BtnQuitar.UseVisualStyleBackColor = true;
            BtnQuitar.Click += BtnQuitar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(LblPrecioCant);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(LblPrecio);
            groupBox1.Controls.Add(Lbl);
            groupBox1.Controls.Add(LblProducto);
            groupBox1.Controls.Add(label7);
            groupBox1.Location = new Point(15, 156);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(265, 138);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "PRODUCTO";
            // 
            // LblPrecioCant
            // 
            LblPrecioCant.AutoSize = true;
            LblPrecioCant.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblPrecioCant.Location = new Point(169, 106);
            LblPrecioCant.Name = "LblPrecioCant";
            LblPrecioCant.Size = new Size(15, 17);
            LblPrecioCant.TabIndex = 9;
            LblPrecioCant.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(15, 106);
            label8.Name = "label8";
            label8.Size = new Size(155, 17);
            label8.TabIndex = 8;
            label8.Text = "PRECIO POR CANTIDAD:";
            // 
            // LblPrecio
            // 
            LblPrecio.AutoSize = true;
            LblPrecio.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblPrecio.Location = new Point(77, 68);
            LblPrecio.Name = "LblPrecio";
            LblPrecio.Size = new Size(15, 17);
            LblPrecio.TabIndex = 7;
            LblPrecio.Text = "0";
            // 
            // Lbl
            // 
            Lbl.AutoSize = true;
            Lbl.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl.Location = new Point(15, 68);
            Lbl.Name = "Lbl";
            Lbl.Size = new Size(67, 17);
            Lbl.TabIndex = 6;
            Lbl.Text = "PRECIO: $";
            // 
            // LblProducto
            // 
            LblProducto.AutoSize = true;
            LblProducto.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblProducto.Location = new Point(100, 36);
            LblProducto.Name = "LblProducto";
            LblProducto.Size = new Size(11, 17);
            LblProducto.TabIndex = 5;
            LblProducto.Text = ".";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(15, 36);
            label7.Name = "label7";
            label7.Size = new Size(79, 17);
            label7.TabIndex = 4;
            label7.Text = "PRODUCTO:";
            // 
            // BtnAceptar
            // 
            BtnAceptar.Location = new Point(15, 355);
            BtnAceptar.Name = "BtnAceptar";
            BtnAceptar.Size = new Size(265, 40);
            BtnAceptar.TabIndex = 7;
            BtnAceptar.Text = "AGREGAR";
            BtnAceptar.UseVisualStyleBackColor = true;
            BtnAceptar.Click += BtnAceptar_Click;
            // 
            // NumericUpDown1
            // 
            NumericUpDown1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NumericUpDown1.Location = new Point(15, 309);
            NumericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericUpDown1.Name = "NumericUpDown1";
            NumericUpDown1.Size = new Size(265, 29);
            NumericUpDown1.TabIndex = 5;
            NumericUpDown1.TextAlign = HorizontalAlignment.Right;
            NumericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NumericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(15, 114);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(265, 25);
            textBox1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 94);
            label2.Name = "label2";
            label2.Size = new Size(79, 17);
            label2.TabIndex = 3;
            label2.Text = "PRODUCTO:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 38);
            label1.Name = "label1";
            label1.Size = new Size(79, 17);
            label1.TabIndex = 1;
            label1.Text = "PRODUCTO:";
            // 
            // CmbProducto
            // 
            CmbProducto.AutoCompleteSource = AutoCompleteSource.ListItems;
            CmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbProducto.FormattingEnabled = true;
            CmbProducto.Location = new Point(15, 58);
            CmbProducto.Name = "CmbProducto";
            CmbProducto.Size = new Size(265, 25);
            CmbProducto.TabIndex = 0;
            CmbProducto.SelectedIndexChanged += CmbProducto_SelectedIndexChanged;
            // 
            // DgvProductosSeleccionados
            // 
            DgvProductosSeleccionados.AllowUserToAddRows = false;
            DgvProductosSeleccionados.AllowUserToDeleteRows = false;
            DgvProductosSeleccionados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvProductosSeleccionados.Dock = DockStyle.Fill;
            DgvProductosSeleccionados.Location = new Point(0, 26);
            DgvProductosSeleccionados.Name = "DgvProductosSeleccionados";
            DgvProductosSeleccionados.ReadOnly = true;
            DgvProductosSeleccionados.RowHeadersVisible = false;
            DgvProductosSeleccionados.Size = new Size(474, 335);
            DgvProductosSeleccionados.TabIndex = 0;
            DgvProductosSeleccionados.CellClick += DgvProductosSeleccionados_CellClick;
            DgvProductosSeleccionados.SelectionChanged += DgvProductosSeleccionados_SelectionChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(BtnConfirmarVenta);
            panel1.Controls.Add(LblPrecioTotal);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(LblCantProductos);
            panel1.Controls.Add(label4);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 361);
            panel1.Name = "panel1";
            panel1.Size = new Size(474, 100);
            panel1.TabIndex = 5;
            // 
            // BtnConfirmarVenta
            // 
            BtnConfirmarVenta.Location = new Point(113, 48);
            BtnConfirmarVenta.Name = "BtnConfirmarVenta";
            BtnConfirmarVenta.Size = new Size(265, 40);
            BtnConfirmarVenta.TabIndex = 8;
            BtnConfirmarVenta.Text = "CONFIRMAR VENTA";
            BtnConfirmarVenta.UseVisualStyleBackColor = true;
            BtnConfirmarVenta.Click += BtnConfirmarVenta_Click;
            // 
            // LblPrecioTotal
            // 
            LblPrecioTotal.AutoSize = true;
            LblPrecioTotal.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblPrecioTotal.Location = new Point(373, 17);
            LblPrecioTotal.Name = "LblPrecioTotal";
            LblPrecioTotal.Size = new Size(15, 17);
            LblPrecioTotal.TabIndex = 5;
            LblPrecioTotal.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(271, 17);
            label6.Name = "label6";
            label6.Size = new Size(107, 17);
            label6.TabIndex = 4;
            label6.Text = "PRECIO TOTAL: $";
            // 
            // LblCantProductos
            // 
            LblCantProductos.AutoSize = true;
            LblCantProductos.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblCantProductos.Location = new Point(191, 17);
            LblCantProductos.Name = "LblCantProductos";
            LblCantProductos.Size = new Size(15, 17);
            LblCantProductos.TabIndex = 3;
            LblCantProductos.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(106, 17);
            label4.Name = "label4";
            label4.Size = new Size(86, 17);
            label4.TabIndex = 2;
            label4.Text = "PRODUCTOS:";
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(8);
            label3.Name = "label3";
            label3.Size = new Size(474, 26);
            label3.TabIndex = 4;
            label3.Text = "LISTA DE PRODUCTOS SELECCIONADOS";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormVentas
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(784, 461);
            Controls.Add(splitContainer1);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormVentas";
            Text = "Producto";
            Load += FormVentas_Load;
            KeyDown += FormVentas_KeyDown;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            GBForm.ResumeLayout(false);
            GBForm.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)DgvProductosSeleccionados).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox GBForm;
        private System.Windows.Forms.ComboBox CmbProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DgvProductosSeleccionados;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.NumericUpDown NumericUpDown1;
        private System.Windows.Forms.TextBox textBox1;
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblPrecioCant;
        private System.Windows.Forms.Label label8;
        private Button BtnQuitar;
    }
}