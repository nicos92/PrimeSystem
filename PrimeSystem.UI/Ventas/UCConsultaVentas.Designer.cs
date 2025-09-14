namespace PrimeSystem.UI.Ventas
{
    partial class UCConsultaVentas
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
            splitContainer1 = new SplitContainer();
            GBLista = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            DgvVentas = new DataGridView();
            PbProgreso = new ProgressBar();
            GBForm = new GroupBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel6 = new TableLayoutPanel();
            label14 = new Label();
            LblTotal = new Label();
            tableLayoutPanel5 = new TableLayoutPanel();
            label12 = new Label();
            LblDescuento = new Label();
            label10 = new Label();
            LblSubtotal = new Label();
            groupBox1 = new GroupBox();
            DgvDetalles = new DataGridView();
            tableLayoutPanel7 = new TableLayoutPanel();
            label1 = new Label();
            DtpFechaDesde = new DateTimePicker();
            label3 = new Label();
            TxtCliente = new TextBox();
            label5 = new Label();
            TxtIdRemito = new TextBox();
            BtnBuscar = new Button();
            DtpFechaHasta = new DateTimePicker();
            label2 = new Label();
            tableLayoutPanel8 = new TableLayoutPanel();
            label7 = new Label();
            LblIdRemito = new Label();
            tableLayoutPanel9 = new TableLayoutPanel();
            label4 = new Label();
            LblFecha = new Label();
            tableLayoutPanel10 = new TableLayoutPanel();
            label6 = new Label();
            LblCliente = new Label();
            tableLayoutPanel11 = new TableLayoutPanel();
            label8 = new Label();
            LblUsuario = new Label();
            BtnEliminar = new Button();
            BtnActualizar = new Button();
            tableLayoutPanel4 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            GBLista.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvVentas).BeginInit();
            GBForm.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvDetalles).BeginInit();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            tableLayoutPanel10.SuspendLayout();
            tableLayoutPanel11.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = Color.FromArgb(218, 218, 220);
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(16, 16);
            splitContainer1.Margin = new Padding(4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(GBLista);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(GBForm);
            splitContainer1.Size = new Size(772, 529);
            splitContainer1.SplitterDistance = 299;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // GBLista
            // 
            GBLista.Controls.Add(tableLayoutPanel1);
            GBLista.Dock = DockStyle.Fill;
            GBLista.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GBLista.ForeColor = Color.FromArgb(7, 100, 147);
            GBLista.Location = new Point(0, 0);
            GBLista.Margin = new Padding(4);
            GBLista.Name = "GBLista";
            GBLista.Padding = new Padding(4);
            GBLista.Size = new Size(299, 529);
            GBLista.TabIndex = 0;
            GBLista.TabStop = false;
            GBLista.Text = "Lista de Ventas";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(249, 249, 251);
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(DgvVentas, 0, 1);
            tableLayoutPanel1.Controls.Add(PbProgreso, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(4, 30);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(291, 495);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // DgvVentas
            // 
            DgvVentas.AllowUserToAddRows = false;
            DgvVentas.AllowUserToDeleteRows = false;
            DgvVentas.AllowUserToResizeColumns = false;
            DgvVentas.AllowUserToResizeRows = false;
            DgvVentas.BackgroundColor = Color.FromArgb(249, 249, 251);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(232, 232, 234);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(69, 71, 73);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(203, 230, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(0, 75, 113);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DgvVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(7, 100, 147);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DgvVentas.DefaultCellStyle = dataGridViewCellStyle2;
            DgvVentas.Dock = DockStyle.Fill;
            DgvVentas.GridColor = Color.FromArgb(190, 201, 209);
            DgvVentas.Location = new Point(3, 29);
            DgvVentas.Name = "DgvVentas";
            DgvVentas.ReadOnly = true;
            DgvVentas.RowHeadersVisible = false;
            DgvVentas.Size = new Size(285, 463);
            DgvVentas.TabIndex = 4;
            DgvVentas.SelectionChanged += DgvVentas_SelectionChanged;
            // 
            // PbProgreso
            // 
            PbProgreso.Dock = DockStyle.Fill;
            PbProgreso.Location = new Point(3, 3);
            PbProgreso.Name = "PbProgreso";
            PbProgreso.Size = new Size(285, 20);
            PbProgreso.TabIndex = 6;
            PbProgreso.Visible = false;
            // 
            // GBForm
            // 
            GBForm.Controls.Add(tableLayoutPanel3);
            GBForm.Dock = DockStyle.Fill;
            GBForm.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GBForm.ForeColor = Color.FromArgb(7, 100, 147);
            GBForm.Location = new Point(0, 0);
            GBForm.Margin = new Padding(4);
            GBForm.Name = "GBForm";
            GBForm.Padding = new Padding(4);
            GBForm.Size = new Size(468, 529);
            GBForm.TabIndex = 0;
            GBForm.TabStop = false;
            GBForm.Text = "Formulario de Consulta de Ventas";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.FromArgb(249, 249, 251);
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel6, 0, 6);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel5, 0, 5);
            tableLayoutPanel3.Controls.Add(groupBox1, 0, 7);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel7, 0, 0);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel8, 0, 1);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel9, 0, 2);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel10, 0, 3);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel11, 0, 4);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(4, 30);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 8;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(460, 495);
            tableLayoutPanel3.TabIndex = 14;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Controls.Add(label14, 0, 0);
            tableLayoutPanel6.Controls.Add(LblTotal, 1, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(3, 279);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Size = new Size(454, 26);
            tableLayoutPanel6.TabIndex = 24;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.FromArgb(26, 28, 30);
            label14.Location = new Point(115, 2);
            label14.Name = "label14";
            label14.Size = new Size(109, 21);
            label14.TabIndex = 16;
            label14.Text = "TOTAL VENTA";
            // 
            // LblTotal
            // 
            LblTotal.Anchor = AnchorStyles.Left;
            LblTotal.AutoSize = true;
            LblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblTotal.ForeColor = Color.FromArgb(26, 28, 30);
            LblTotal.Location = new Point(230, 2);
            LblTotal.Name = "LblTotal";
            LblTotal.Size = new Size(19, 21);
            LblTotal.TabIndex = 17;
            LblTotal.Text = "0";
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 4;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.Controls.Add(label12, 2, 0);
            tableLayoutPanel5.Controls.Add(LblDescuento, 3, 0);
            tableLayoutPanel5.Controls.Add(label10, 0, 0);
            tableLayoutPanel5.Controls.Add(LblSubtotal, 1, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 249);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(454, 24);
            tableLayoutPanel5.TabIndex = 23;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.FromArgb(26, 28, 30);
            label12.Location = new Point(237, 1);
            label12.Name = "label12";
            label12.Size = new Size(99, 21);
            label12.TabIndex = 14;
            label12.Text = "DESCUENTO";
            // 
            // LblDescuento
            // 
            LblDescuento.Anchor = AnchorStyles.Left;
            LblDescuento.AutoSize = true;
            LblDescuento.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblDescuento.ForeColor = Color.FromArgb(26, 28, 30);
            LblDescuento.Location = new Point(342, 1);
            LblDescuento.Name = "LblDescuento";
            LblDescuento.Size = new Size(19, 21);
            LblDescuento.TabIndex = 15;
            LblDescuento.Text = "0";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.FromArgb(26, 28, 30);
            label10.Location = new Point(25, 1);
            label10.Name = "label10";
            label10.Size = new Size(85, 21);
            label10.TabIndex = 12;
            label10.Text = "SUBTOTAL";
            // 
            // LblSubtotal
            // 
            LblSubtotal.Anchor = AnchorStyles.Left;
            LblSubtotal.AutoSize = true;
            LblSubtotal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblSubtotal.ForeColor = Color.FromArgb(26, 28, 30);
            LblSubtotal.Location = new Point(116, 1);
            LblSubtotal.Name = "LblSubtotal";
            LblSubtotal.Size = new Size(19, 21);
            LblSubtotal.TabIndex = 13;
            LblSubtotal.Text = "0";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(DgvDetalles);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(7, 100, 147);
            groupBox1.Location = new Point(3, 311);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(454, 213);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Detalles de la Venta";
            // 
            // DgvDetalles
            // 
            DgvDetalles.AllowUserToAddRows = false;
            DgvDetalles.AllowUserToDeleteRows = false;
            DgvDetalles.BackgroundColor = Color.FromArgb(249, 249, 251);
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(232, 232, 234);
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(69, 71, 73);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(203, 230, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(0, 75, 113);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            DgvDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            DgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(7, 100, 147);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            DgvDetalles.DefaultCellStyle = dataGridViewCellStyle4;
            DgvDetalles.Dock = DockStyle.Fill;
            DgvDetalles.GridColor = Color.FromArgb(190, 201, 209);
            DgvDetalles.Location = new Point(3, 25);
            DgvDetalles.Name = "DgvDetalles";
            DgvDetalles.ReadOnly = true;
            DgvDetalles.RowHeadersVisible = false;
            DgvDetalles.Size = new Size(448, 185);
            DgvDetalles.TabIndex = 0;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 6;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel7.Controls.Add(label1, 0, 0);
            tableLayoutPanel7.Controls.Add(DtpFechaDesde, 1, 0);
            tableLayoutPanel7.Controls.Add(label3, 0, 1);
            tableLayoutPanel7.Controls.Add(TxtCliente, 1, 1);
            tableLayoutPanel7.Controls.Add(label5, 2, 1);
            tableLayoutPanel7.Controls.Add(TxtIdRemito, 3, 1);
            tableLayoutPanel7.Controls.Add(BtnBuscar, 4, 1);
            tableLayoutPanel7.Controls.Add(DtpFechaHasta, 4, 0);
            tableLayoutPanel7.Controls.Add(label2, 3, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(3, 3);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 2;
            tableLayoutPanel7.RowStyles.Add(new RowStyle());
            tableLayoutPanel7.RowStyles.Add(new RowStyle());
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel7.Size = new Size(454, 120);
            tableLayoutPanel7.TabIndex = 25;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(26, 28, 30);
            label1.Location = new Point(16, 7);
            label1.Name = "label1";
            label1.Size = new Size(57, 21);
            label1.TabIndex = 0;
            label1.Text = "DESDE";
            // 
            // DtpFechaDesde
            // 
            DtpFechaDesde.Anchor = AnchorStyles.Left;
            DtpFechaDesde.CalendarForeColor = Color.FromArgb(26, 28, 30);
            DtpFechaDesde.CalendarMonthBackground = Color.FromArgb(238, 237, 240);
            tableLayoutPanel7.SetColumnSpan(DtpFechaDesde, 2);
            DtpFechaDesde.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DtpFechaDesde.Format = DateTimePickerFormat.Short;
            DtpFechaDesde.Location = new Point(79, 3);
            DtpFechaDesde.Name = "DtpFechaDesde";
            DtpFechaDesde.Size = new Size(144, 29);
            DtpFechaDesde.TabIndex = 1;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(26, 28, 30);
            label3.Location = new Point(3, 67);
            label3.Name = "label3";
            label3.Size = new Size(70, 21);
            label3.TabIndex = 4;
            label3.Text = "CLIENTE";
            // 
            // TxtCliente
            // 
            TxtCliente.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtCliente.BackColor = Color.FromArgb(238, 237, 240);
            TxtCliente.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtCliente.ForeColor = Color.FromArgb(26, 28, 30);
            TxtCliente.Location = new Point(79, 63);
            TxtCliente.Name = "TxtCliente";
            TxtCliente.Size = new Size(64, 29);
            TxtCliente.TabIndex = 5;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(26, 28, 30);
            label5.Location = new Point(149, 67);
            label5.Name = "label5";
            label5.Size = new Size(114, 21);
            label5.TabIndex = 6;
            label5.Text = "Nº DE REMITO";
            // 
            // TxtIdRemito
            // 
            TxtIdRemito.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TxtIdRemito.BackColor = Color.FromArgb(238, 237, 240);
            TxtIdRemito.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtIdRemito.ForeColor = Color.FromArgb(26, 28, 30);
            TxtIdRemito.Location = new Point(269, 63);
            TxtIdRemito.Name = "TxtIdRemito";
            TxtIdRemito.Size = new Size(64, 29);
            TxtIdRemito.TabIndex = 7;
            // 
            // BtnBuscar
            // 
            BtnBuscar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            BtnBuscar.BackColor = Color.FromArgb(7, 100, 147);
            BtnBuscar.FlatAppearance.BorderColor = Color.FromArgb(203, 230, 255);
            BtnBuscar.FlatStyle = FlatStyle.Flat;
            BtnBuscar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            BtnBuscar.ForeColor = Color.White;
            BtnBuscar.Location = new Point(339, 62);
            BtnBuscar.Name = "BtnBuscar";
            BtnBuscar.Size = new Size(42, 31);
            BtnBuscar.TabIndex = 8;
            BtnBuscar.Text = "🔍";
            BtnBuscar.UseVisualStyleBackColor = false;
            BtnBuscar.Click += BtnBuscar_Click;
            // 
            // DtpFechaHasta
            // 
            DtpFechaHasta.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            DtpFechaHasta.CalendarForeColor = Color.FromArgb(26, 28, 30);
            DtpFechaHasta.CalendarMonthBackground = Color.FromArgb(238, 237, 240);
            tableLayoutPanel7.SetColumnSpan(DtpFechaHasta, 2);
            DtpFechaHasta.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DtpFechaHasta.Format = DateTimePickerFormat.Short;
            DtpFechaHasta.Location = new Point(339, 3);
            DtpFechaHasta.Name = "DtpFechaHasta";
            DtpFechaHasta.Size = new Size(112, 29);
            DtpFechaHasta.TabIndex = 3;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(26, 28, 30);
            label2.Location = new Point(272, 7);
            label2.Name = "label2";
            label2.Size = new Size(61, 21);
            label2.TabIndex = 2;
            label2.Text = "HASTA";
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 2;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.8498936F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 73.15011F));
            tableLayoutPanel8.Controls.Add(label7, 0, 0);
            tableLayoutPanel8.Controls.Add(LblIdRemito, 1, 0);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(3, 129);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel8.Size = new Size(454, 23);
            tableLayoutPanel8.TabIndex = 10;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(26, 28, 30);
            label7.Location = new Point(4, 1);
            label7.Name = "label7";
            label7.Size = new Size(114, 21);
            label7.TabIndex = 16;
            label7.Text = "Nº DE REMITO";
            // 
            // LblIdRemito
            // 
            LblIdRemito.Anchor = AnchorStyles.Left;
            LblIdRemito.AutoSize = true;
            LblIdRemito.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblIdRemito.ForeColor = Color.FromArgb(26, 28, 30);
            LblIdRemito.Location = new Point(124, 1);
            LblIdRemito.Name = "LblIdRemito";
            LblIdRemito.Size = new Size(19, 21);
            LblIdRemito.TabIndex = 15;
            LblIdRemito.Text = "0";
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.ColumnCount = 2;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.8498936F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 73.15011F));
            tableLayoutPanel9.Controls.Add(label4, 0, 0);
            tableLayoutPanel9.Controls.Add(LblFecha, 1, 0);
            tableLayoutPanel9.Dock = DockStyle.Fill;
            tableLayoutPanel9.Location = new Point(3, 158);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 1;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.Size = new Size(454, 25);
            tableLayoutPanel9.TabIndex = 10;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(26, 28, 30);
            label4.Location = new Point(59, 2);
            label4.Name = "label4";
            label4.Size = new Size(59, 21);
            label4.TabIndex = 18;
            label4.Text = "FECHA";
            // 
            // LblFecha
            // 
            LblFecha.Anchor = AnchorStyles.Left;
            LblFecha.AutoSize = true;
            LblFecha.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblFecha.ForeColor = Color.FromArgb(26, 28, 30);
            LblFecha.Location = new Point(124, 2);
            LblFecha.Name = "LblFecha";
            LblFecha.Size = new Size(19, 21);
            LblFecha.TabIndex = 17;
            LblFecha.Text = "0";
            // 
            // tableLayoutPanel10
            // 
            tableLayoutPanel10.ColumnCount = 2;
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.8498936F));
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 73.15011F));
            tableLayoutPanel10.Controls.Add(label6, 0, 0);
            tableLayoutPanel10.Controls.Add(LblCliente, 1, 0);
            tableLayoutPanel10.Dock = DockStyle.Fill;
            tableLayoutPanel10.Location = new Point(3, 189);
            tableLayoutPanel10.Name = "tableLayoutPanel10";
            tableLayoutPanel10.RowCount = 1;
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel10.Size = new Size(454, 25);
            tableLayoutPanel10.TabIndex = 10;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(26, 28, 30);
            label6.Location = new Point(48, 2);
            label6.Name = "label6";
            label6.Size = new Size(70, 21);
            label6.TabIndex = 20;
            label6.Text = "CLIENTE";
            // 
            // LblCliente
            // 
            LblCliente.Anchor = AnchorStyles.Left;
            LblCliente.AutoSize = true;
            LblCliente.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblCliente.ForeColor = Color.FromArgb(26, 28, 30);
            LblCliente.Location = new Point(124, 2);
            LblCliente.Name = "LblCliente";
            LblCliente.Size = new Size(19, 21);
            LblCliente.TabIndex = 19;
            LblCliente.Text = "0";
            // 
            // tableLayoutPanel11
            // 
            tableLayoutPanel11.ColumnCount = 2;
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.0613117F));
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72.93869F));
            tableLayoutPanel11.Controls.Add(label8, 0, 0);
            tableLayoutPanel11.Controls.Add(LblUsuario, 1, 0);
            tableLayoutPanel11.Dock = DockStyle.Fill;
            tableLayoutPanel11.Location = new Point(3, 220);
            tableLayoutPanel11.Name = "tableLayoutPanel11";
            tableLayoutPanel11.RowCount = 1;
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel11.Size = new Size(454, 23);
            tableLayoutPanel11.TabIndex = 10;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(26, 28, 30);
            label8.Location = new Point(40, 1);
            label8.Name = "label8";
            label8.Size = new Size(79, 21);
            label8.TabIndex = 22;
            label8.Text = "USUARIO";
            // 
            // LblUsuario
            // 
            LblUsuario.Anchor = AnchorStyles.Left;
            LblUsuario.AutoSize = true;
            LblUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblUsuario.ForeColor = Color.FromArgb(26, 28, 30);
            LblUsuario.Location = new Point(125, 1);
            LblUsuario.Name = "LblUsuario";
            LblUsuario.Size = new Size(19, 21);
            LblUsuario.TabIndex = 21;
            LblUsuario.Text = "0";
            // 
            // BtnEliminar
            // 
            BtnEliminar.BackColor = Color.FromArgb(186, 26, 26);
            BtnEliminar.Dock = DockStyle.Fill;
            BtnEliminar.FlatAppearance.BorderColor = Color.FromArgb(245, 212, 212);
            BtnEliminar.FlatStyle = FlatStyle.Flat;
            BtnEliminar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            BtnEliminar.ForeColor = Color.White;
            BtnEliminar.Location = new Point(4, 4);
            BtnEliminar.Margin = new Padding(4);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(92, 92);
            BtnEliminar.TabIndex = 1;
            BtnEliminar.Text = "ELIMINAR";
            BtnEliminar.UseVisualStyleBackColor = false;
            BtnEliminar.Click += BtnEliminar_Click;
            // 
            // BtnActualizar
            // 
            BtnActualizar.BackColor = Color.FromArgb(101, 89, 119);
            BtnActualizar.Dock = DockStyle.Fill;
            BtnActualizar.FlatAppearance.BorderColor = Color.FromArgb(235, 220, 255);
            BtnActualizar.FlatStyle = FlatStyle.Flat;
            BtnActualizar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            BtnActualizar.ForeColor = Color.White;
            BtnActualizar.Location = new Point(104, 4);
            BtnActualizar.Margin = new Padding(4);
            BtnActualizar.Name = "BtnActualizar";
            BtnActualizar.Size = new Size(92, 92);
            BtnActualizar.TabIndex = 2;
            BtnActualizar.Text = "ACTUALIZAR";
            BtnActualizar.UseVisualStyleBackColor = false;
            BtnActualizar.Click += BtnActualizar_Click;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(BtnEliminar, 0, 0);
            tableLayoutPanel4.Controls.Add(BtnActualizar, 1, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(200, 100);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // UCConsultaVentas
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(218, 218, 220);
            Controls.Add(splitContainer1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "UCConsultaVentas";
            Padding = new Padding(16);
            Size = new Size(804, 561);
            Load += UCConsultaVentas_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            GBLista.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvVentas).EndInit();
            GBForm.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvDetalles).EndInit();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            tableLayoutPanel10.ResumeLayout(false);
            tableLayoutPanel10.PerformLayout();
            tableLayoutPanel11.ResumeLayout(false);
            tableLayoutPanel11.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private GroupBox GBLista;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel4;
        private Button BtnEliminar;
        private Button BtnActualizar;
        private DataGridView DgvVentas;
        private ProgressBar PbProgreso;
        private GroupBox GBForm;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel6;
        private Label label14;
        private Label LblTotal;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label12;
        private Label LblDescuento;
        private Label label10;
        private Label LblSubtotal;
        private Label label8;
        private Label LblUsuario;
        private Label label6;
        private Label LblCliente;
        private Label label4;
        private Label LblFecha;
        private Label label7;
        private Label LblIdRemito;
        private GroupBox groupBox1;
        private DataGridView DgvDetalles;
        private TableLayoutPanel tableLayoutPanel7;
        private Label label1;
        private DateTimePicker DtpFechaDesde;
        private Label label2;
        private DateTimePicker DtpFechaHasta;
        private Label label3;
        private TextBox TxtCliente;
        private Label label5;
        private TextBox TxtIdRemito;
        private Button BtnBuscar;
        private TableLayoutPanel tableLayoutPanel8;
        private TableLayoutPanel tableLayoutPanel9;
        private TableLayoutPanel tableLayoutPanel10;
        private TableLayoutPanel tableLayoutPanel11;
    }
}