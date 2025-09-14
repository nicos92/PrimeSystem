namespace PrimeSystem.UI.Compras
{
    partial class UCConsultaCompras
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            GBLista = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            DgvCompras = new DataGridView();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            DtpFechaDesde = new DateTimePicker();
            label2 = new Label();
            DtpFechaHasta = new DateTimePicker();
            label3 = new Label();
            TxtProveedor = new TextBox();
            label4 = new Label();
            TxtIdRemito = new TextBox();
            BtnBuscar = new Button();
            BtnActualizar = new Button();
            GBForm = new GroupBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            label5 = new Label();
            LblIdRemito = new Label();
            label7 = new Label();
            LblFecha = new Label();
            label9 = new Label();
            LblProveedor = new Label();
            label11 = new Label();
            LblUsuario = new Label();
            label13 = new Label();
            LblSubtotal = new Label();
            label15 = new Label();
            LblDescuento = new Label();
            label17 = new Label();
            LblTotal = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            DgvDetalles = new DataGridView();
            BtnEliminar = new Button();
            PbProgreso = new ProgressBar();
            GBLista.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvCompras).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            GBForm.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // GBLista
            // 
            GBLista.Controls.Add(tableLayoutPanel1);
            GBLista.Dock = DockStyle.Top;
            GBLista.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            GBLista.ForeColor = Color.FromArgb(7, 100, 147);
            GBLista.Location = new Point(0, 0);
            GBLista.Name = "GBLista";
            GBLista.Size = new Size(874, 302);
            GBLista.TabIndex = 0;
            GBLista.TabStop = false;
            GBLista.Text = "Lista de Compras";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(DgvCompras, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 25);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(868, 274);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // DgvCompras
            // 
            DgvCompras.AllowUserToAddRows = false;
            DgvCompras.AllowUserToDeleteRows = false;
            DgvCompras.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(170, 170, 172);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            DgvCompras.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvCompras.BackgroundColor = Color.FromArgb(218, 218, 220);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(170, 170, 172);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(26, 28, 30);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(170, 170, 172);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(26, 28, 30);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DgvCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DgvCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(218, 218, 220);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(7, 100, 147);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(170, 170, 172);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(26, 28, 30);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DgvCompras.DefaultCellStyle = dataGridViewCellStyle3;
            DgvCompras.Dock = DockStyle.Fill;
            DgvCompras.EnableHeadersVisualStyles = false;
            DgvCompras.GridColor = Color.FromArgb(170, 170, 172);
            DgvCompras.Location = new Point(3, 43);
            DgvCompras.Name = "DgvCompras";
            DgvCompras.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(218, 218, 220);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(26, 28, 30);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(170, 170, 172);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(26, 28, 30);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            DgvCompras.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            DgvCompras.RowHeadersVisible = false;
            DgvCompras.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(218, 218, 220);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(170, 170, 172);
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            DgvCompras.RowsDefaultCellStyle = dataGridViewCellStyle5;
            DgvCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvCompras.Size = new Size(862, 228);
            DgvCompras.TabIndex = 0;
            DgvCompras.SelectionChanged += DgvCompras_SelectionChanged;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 11;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(DtpFechaDesde, 1, 0);
            tableLayoutPanel2.Controls.Add(label2, 3, 0);
            tableLayoutPanel2.Controls.Add(DtpFechaHasta, 4, 0);
            tableLayoutPanel2.Controls.Add(label3, 6, 0);
            tableLayoutPanel2.Controls.Add(TxtProveedor, 7, 0);
            tableLayoutPanel2.Controls.Add(label4, 9, 0);
            tableLayoutPanel2.Controls.Add(TxtIdRemito, 10, 0);
            tableLayoutPanel2.Controls.Add(BtnBuscar, 11, 0);
            tableLayoutPanel2.Controls.Add(BtnActualizar, 12, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(862, 34);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F);
            label1.ForeColor = Color.FromArgb(26, 28, 30);
            label1.Location = new Point(11, 0);
            label1.Name = "label1";
            label1.Size = new Size(56, 14);
            label1.TabIndex = 0;
            label1.Text = "Desde : ";
            // 
            // DtpFechaDesde
            // 
            DtpFechaDesde.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            DtpFechaDesde.Font = new Font("Segoe UI", 9.75F);
            DtpFechaDesde.Format = DateTimePickerFormat.Short;
            DtpFechaDesde.Location = new Point(73, 3);
            DtpFechaDesde.Name = "DtpFechaDesde";
            DtpFechaDesde.Size = new Size(114, 25);
            DtpFechaDesde.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F);
            label2.ForeColor = Color.FromArgb(26, 28, 30);
            label2.Location = new Point(225, 0);
            label2.Name = "label2";
            label2.Size = new Size(52, 14);
            label2.TabIndex = 2;
            label2.Text = "Hasta : ";
            // 
            // DtpFechaHasta
            // 
            DtpFechaHasta.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            DtpFechaHasta.Font = new Font("Segoe UI", 9.75F);
            DtpFechaHasta.Format = DateTimePickerFormat.Short;
            DtpFechaHasta.Location = new Point(283, 3);
            DtpFechaHasta.Name = "DtpFechaHasta";
            DtpFechaHasta.Size = new Size(114, 25);
            DtpFechaHasta.TabIndex = 3;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F);
            label3.ForeColor = Color.FromArgb(26, 28, 30);
            label3.Location = new Point(431, 0);
            label3.Name = "label3";
            label3.Size = new Size(76, 14);
            label3.TabIndex = 4;
            label3.Text = "Proveedor :";
            // 
            // TxtProveedor
            // 
            TxtProveedor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtProveedor.Font = new Font("Segoe UI", 9.75F);
            TxtProveedor.Location = new Point(513, 3);
            TxtProveedor.Name = "TxtProveedor";
            TxtProveedor.Size = new Size(114, 25);
            TxtProveedor.TabIndex = 5;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.ForeColor = Color.FromArgb(26, 28, 30);
            label4.Location = new Point(676, 0);
            label4.Name = "label4";
            label4.Size = new Size(61, 14);
            label4.TabIndex = 6;
            label4.Text = "Nº Rem :";
            // 
            // TxtIdRemito
            // 
            TxtIdRemito.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtIdRemito.Font = new Font("Segoe UI", 9.75F);
            TxtIdRemito.Location = new Point(743, 3);
            TxtIdRemito.Name = "TxtIdRemito";
            TxtIdRemito.Size = new Size(116, 25);
            TxtIdRemito.TabIndex = 7;
            // 
            // BtnBuscar
            // 
            BtnBuscar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            BtnBuscar.BackColor = Color.FromArgb(170, 170, 172);
            BtnBuscar.FlatAppearance.BorderSize = 0;
            BtnBuscar.FlatStyle = FlatStyle.Flat;
            BtnBuscar.Font = new Font("Segoe UI", 9.75F);
            BtnBuscar.ForeColor = Color.FromArgb(26, 28, 30);
            BtnBuscar.Location = new Point(3, 17);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(64, 14);
            BtnBuscar.TabIndex = 8;
            BtnBuscar.Text = "Buscar";
            BtnBuscar.UseVisualStyleBackColor = false;
            BtnBuscar.Click += BtnBuscar_Click;
            // 
            // BtnActualizar
            // 
            BtnActualizar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            BtnActualizar.BackColor = Color.FromArgb(170, 170, 172);
            BtnActualizar.FlatAppearance.BorderSize = 0;
            BtnActualizar.FlatStyle = FlatStyle.Flat;
            BtnActualizar.Font = new Font("Segoe UI", 9.75F);
            BtnActualizar.ForeColor = Color.FromArgb(26, 28, 30);
            BtnActualizar.Location = new Point(73, 17);
            BtnActualizar.Name = "BtnActualizar";
            BtnActualizar.Size = new Size(114, 14);
            BtnActualizar.TabIndex = 9;
            BtnActualizar.Text = "Actualizar";
            BtnActualizar.UseVisualStyleBackColor = false;
            BtnActualizar.Click += BtnActualizar_Click;
            // 
            // GBForm
            // 
            GBForm.Controls.Add(tableLayoutPanel3);
            GBForm.Dock = DockStyle.Top;
            GBForm.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            GBForm.ForeColor = Color.FromArgb(7, 100, 147);
            GBForm.Location = new Point(0, 302);
            GBForm.Name = "GBForm";
            GBForm.Size = new Size(874, 182);
            GBForm.TabIndex = 1;
            GBForm.TabStop = false;
            GBForm.Text = "Detalles de la Compra";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 6;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel3.Controls.Add(label5, 0, 0);
            tableLayoutPanel3.Controls.Add(LblIdRemito, 1, 0);
            tableLayoutPanel3.Controls.Add(label7, 2, 0);
            tableLayoutPanel3.Controls.Add(LblFecha, 3, 0);
            tableLayoutPanel3.Controls.Add(label9, 4, 0);
            tableLayoutPanel3.Controls.Add(LblProveedor, 5, 0);
            tableLayoutPanel3.Controls.Add(label11, 0, 1);
            tableLayoutPanel3.Controls.Add(LblUsuario, 1, 1);
            tableLayoutPanel3.Controls.Add(label13, 2, 1);
            tableLayoutPanel3.Controls.Add(LblSubtotal, 3, 1);
            tableLayoutPanel3.Controls.Add(label15, 4, 1);
            tableLayoutPanel3.Controls.Add(LblDescuento, 5, 1);
            tableLayoutPanel3.Controls.Add(label17, 0, 2);
            tableLayoutPanel3.Controls.Add(LblTotal, 1, 2);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 25);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel3.Size = new Size(868, 154);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F);
            label5.ForeColor = Color.FromArgb(26, 28, 30);
            label5.Location = new Point(80, 17);
            label5.Name = "label5";
            label5.Size = new Size(61, 17);
            label5.TabIndex = 0;
            label5.Text = "Nº Rem :";
            // 
            // LblIdRemito
            // 
            LblIdRemito.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            LblIdRemito.AutoSize = true;
            LblIdRemito.Font = new Font("Segoe UI", 9.75F);
            LblIdRemito.ForeColor = Color.FromArgb(26, 28, 30);
            LblIdRemito.Location = new Point(147, 17);
            LblIdRemito.Name = "LblIdRemito";
            LblIdRemito.Size = new Size(138, 17);
            LblIdRemito.TabIndex = 1;
            LblIdRemito.Text = "0";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F);
            label7.ForeColor = Color.FromArgb(26, 28, 30);
            label7.Location = new Point(381, 17);
            label7.Name = "label7";
            label7.Size = new Size(48, 17);
            label7.TabIndex = 2;
            label7.Text = "Fecha :";
            // 
            // LblFecha
            // 
            LblFecha.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            LblFecha.AutoSize = true;
            LblFecha.Font = new Font("Segoe UI", 9.75F);
            LblFecha.ForeColor = Color.FromArgb(26, 28, 30);
            LblFecha.Location = new Point(435, 17);
            LblFecha.Name = "LblFecha";
            LblFecha.Size = new Size(138, 17);
            LblFecha.TabIndex = 3;
            LblFecha.Text = "0";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9.75F);
            label9.ForeColor = Color.FromArgb(26, 28, 30);
            label9.Location = new Point(641, 17);
            label9.Name = "label9";
            label9.Size = new Size(76, 17);
            label9.TabIndex = 4;
            label9.Text = "Proveedor :";
            // 
            // LblProveedor
            // 
            LblProveedor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            LblProveedor.AutoSize = true;
            LblProveedor.Font = new Font("Segoe UI", 9.75F);
            LblProveedor.ForeColor = Color.FromArgb(26, 28, 30);
            LblProveedor.Location = new Point(723, 17);
            LblProveedor.Name = "LblProveedor";
            LblProveedor.Size = new Size(142, 17);
            LblProveedor.TabIndex = 5;
            LblProveedor.Text = "0";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.75F);
            label11.ForeColor = Color.FromArgb(26, 28, 30);
            label11.Location = new Point(81, 68);
            label11.Name = "label11";
            label11.Size = new Size(60, 17);
            label11.TabIndex = 6;
            label11.Text = "Usuario :";
            // 
            // LblUsuario
            // 
            LblUsuario.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            LblUsuario.AutoSize = true;
            LblUsuario.Font = new Font("Segoe UI", 9.75F);
            LblUsuario.ForeColor = Color.FromArgb(26, 28, 30);
            LblUsuario.Location = new Point(147, 68);
            LblUsuario.Name = "LblUsuario";
            LblUsuario.Size = new Size(138, 17);
            LblUsuario.TabIndex = 7;
            LblUsuario.Text = "0";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9.75F);
            label13.ForeColor = Color.FromArgb(26, 28, 30);
            label13.Location = new Point(366, 68);
            label13.Name = "label13";
            label13.Size = new Size(63, 17);
            label13.TabIndex = 8;
            label13.Text = "Subtotal :";
            // 
            // LblSubtotal
            // 
            LblSubtotal.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            LblSubtotal.AutoSize = true;
            LblSubtotal.Font = new Font("Segoe UI", 9.75F);
            LblSubtotal.ForeColor = Color.FromArgb(26, 28, 30);
            LblSubtotal.Location = new Point(435, 68);
            LblSubtotal.Name = "LblSubtotal";
            LblSubtotal.Size = new Size(138, 17);
            LblSubtotal.TabIndex = 9;
            LblSubtotal.Text = "$0,00";
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Right;
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9.75F);
            label15.ForeColor = Color.FromArgb(26, 28, 30);
            label15.Location = new Point(641, 68);
            label15.Name = "label15";
            label15.Size = new Size(76, 17);
            label15.TabIndex = 10;
            label15.Text = "Descuento :";
            // 
            // LblDescuento
            // 
            LblDescuento.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            LblDescuento.AutoSize = true;
            LblDescuento.Font = new Font("Segoe UI", 9.75F);
            LblDescuento.ForeColor = Color.FromArgb(26, 28, 30);
            LblDescuento.Location = new Point(723, 68);
            LblDescuento.Name = "LblDescuento";
            LblDescuento.Size = new Size(142, 17);
            LblDescuento.TabIndex = 11;
            LblDescuento.Text = "$0,00";
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.Right;
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9.75F);
            label17.ForeColor = Color.FromArgb(26, 28, 30);
            label17.Location = new Point(98, 119);
            label17.Name = "label17";
            label17.Size = new Size(43, 17);
            label17.TabIndex = 12;
            label17.Text = "Total :";
            // 
            // LblTotal
            // 
            LblTotal.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            LblTotal.AutoSize = true;
            LblTotal.Font = new Font("Segoe UI", 9.75F);
            LblTotal.ForeColor = Color.FromArgb(26, 28, 30);
            LblTotal.Location = new Point(147, 119);
            LblTotal.Name = "LblTotal";
            LblTotal.Size = new Size(138, 17);
            LblTotal.TabIndex = 13;
            LblTotal.Text = "$0,00";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(DgvDetalles, 0, 0);
            tableLayoutPanel4.Controls.Add(BtnEliminar, 0, 1);
            tableLayoutPanel4.Controls.Add(PbProgreso, 0, 2);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 484);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(874, 236);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // DgvDetalles
            // 
            DgvDetalles.AllowUserToAddRows = false;
            DgvDetalles.AllowUserToDeleteRows = false;
            DgvDetalles.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(170, 170, 172);
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            DgvDetalles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            DgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvDetalles.BackgroundColor = Color.FromArgb(218, 218, 220);
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(170, 170, 172);
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(26, 28, 30);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(170, 170, 172);
            dataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(26, 28, 30);
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            DgvDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            DgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(218, 218, 220);
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(26, 28, 30);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(170, 170, 172);
            dataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(26, 28, 30);
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            DgvDetalles.DefaultCellStyle = dataGridViewCellStyle8;
            DgvDetalles.Dock = DockStyle.Fill;
            DgvDetalles.EnableHeadersVisualStyles = false;
            DgvDetalles.GridColor = Color.FromArgb(170, 170, 172);
            DgvDetalles.Location = new Point(3, 3);
            DgvDetalles.Name = "DgvDetalles";
            DgvDetalles.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(218, 218, 220);
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(26, 28, 30);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(170, 170, 172);
            dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(26, 28, 30);
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            DgvDetalles.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            DgvDetalles.RowHeadersVisible = false;
            DgvDetalles.RowHeadersWidth = 51;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(218, 218, 220);
            dataGridViewCellStyle10.ForeColor = Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(170, 170, 172);
            dataGridViewCellStyle10.SelectionForeColor = Color.Black;
            DgvDetalles.RowsDefaultCellStyle = dataGridViewCellStyle10;
            DgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvDetalles.Size = new Size(868, 170);
            DgvDetalles.TabIndex = 0;
            // 
            // BtnEliminar
            // 
            BtnEliminar.Anchor = AnchorStyles.Right;
            BtnEliminar.BackColor = Color.FromArgb(170, 170, 172);
            BtnEliminar.FlatAppearance.BorderSize = 0;
            BtnEliminar.FlatStyle = FlatStyle.Flat;
            BtnEliminar.Font = new Font("Segoe UI", 9.75F);
            BtnEliminar.ForeColor = Color.FromArgb(26, 28, 30);
            BtnEliminar.Location = new Point(796, 183);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(75, 26);
            BtnEliminar.TabIndex = 1;
            BtnEliminar.Text = "Eliminar";
            BtnEliminar.UseVisualStyleBackColor = false;
            BtnEliminar.Click += BtnEliminar_Click;
            // 
            // PbProgreso
            // 
            PbProgreso.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            PbProgreso.Location = new Point(3, 221);
            PbProgreso.Name = "PbProgreso";
            PbProgreso.Size = new Size(868, 10);
            PbProgreso.Style = ProgressBarStyle.Continuous;
            PbProgreso.TabIndex = 2;
            PbProgreso.Visible = false;
            // 
            // UCConsultaCompras
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(218, 218, 220);
            Controls.Add(tableLayoutPanel4);
            Controls.Add(GBForm);
            Controls.Add(GBLista);
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.FromArgb(26, 28, 30);
            Name = "UCConsultaCompras";
            Size = new Size(874, 720);
            Load += UCConsultaCompras_Load;
            GBLista.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvCompras).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            GBForm.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvDetalles).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox GBLista;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView DgvCompras;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private DateTimePicker DtpFechaDesde;
        private Label label2;
        private DateTimePicker DtpFechaHasta;
        private Label label3;
        private TextBox TxtProveedor;
        private Label label4;
        private TextBox TxtIdRemito;
        private Button BtnBuscar;
        private Button BtnActualizar;
        private GroupBox GBForm;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label5;
        private Label LblIdRemito;
        private Label label7;
        private Label LblFecha;
        private Label label9;
        private Label LblProveedor;
        private Label label11;
        private Label LblUsuario;
        private Label label13;
        private Label LblSubtotal;
        private Label label15;
        private Label LblDescuento;
        private Label label17;
        private Label LblTotal;
        private TableLayoutPanel tableLayoutPanel4;
        private DataGridView DgvDetalles;
        private Button BtnEliminar;
        private ProgressBar PbProgreso;
    }
}