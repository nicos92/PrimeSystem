namespace PrimeSystem.UI.Articulos
{
    partial class UCGestionCategorias
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
            GBCategorias = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            BtnActualizar = new Button();
            DgvCategorias = new DataGridView();
            GBFormCategoria = new GroupBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            label1 = new Label();
            TxtCategoria = new TextBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            BtnNuevaCategoria = new Button();
            BtnEliminarCategoria = new Button();
            BtnGuardarCategoria = new Button();
            PbProgreso = new ProgressBar();
            GBSubcategorias = new GroupBox();
            tableLayoutPanel5 = new TableLayoutPanel();
            tableLayoutPanel6 = new TableLayoutPanel();
            label3 = new Label();
            LblCategoriaSeleccionada = new Label();
            DgvSubcategorias = new DataGridView();
            GBFormSubcategoria = new GroupBox();
            tableLayoutPanel7 = new TableLayoutPanel();
            label2 = new Label();
            TxtSubcategoria = new TextBox();
            tableLayoutPanel8 = new TableLayoutPanel();
            BtnNuevaSubcategoria = new Button();
            BtnEliminarSubcategoria = new Button();
            BtnGuardarSubcategoria = new Button();
            splitContainer1 = new SplitContainer();
            GBCategorias.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvCategorias).BeginInit();
            GBFormCategoria.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            GBSubcategorias.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvSubcategorias).BeginInit();
            GBFormSubcategoria.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // GBCategorias
            // 
            GBCategorias.Controls.Add(tableLayoutPanel1);
            GBCategorias.Dock = DockStyle.Fill;
            GBCategorias.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GBCategorias.Location = new Point(0, 0);
            GBCategorias.Name = "GBCategorias";
            GBCategorias.Size = new Size(410, 493);
            GBCategorias.TabIndex = 0;
            GBCategorias.TabStop = false;
            GBCategorias.Text = "Categorías";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(BtnActualizar, 0, 0);
            tableLayoutPanel1.Controls.Add(DgvCategorias, 0, 2);
            tableLayoutPanel1.Controls.Add(GBFormCategoria, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 25);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(404, 465);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // BtnActualizar
            // 
            BtnActualizar.Anchor = AnchorStyles.None;
            BtnActualizar.BackColor = Color.FromArgb(7, 100, 147);
            BtnActualizar.FlatStyle = FlatStyle.Flat;
            BtnActualizar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnActualizar.ForeColor = Color.White;
            BtnActualizar.Location = new Point(117, 3);
            BtnActualizar.Name = "BtnActualizar";
            BtnActualizar.Size = new Size(170, 32);
            BtnActualizar.TabIndex = 4;
            BtnActualizar.Text = "Actualizar Datos";
            BtnActualizar.UseVisualStyleBackColor = false;
            // 
            // DgvCategorias
            // 
            DgvCategorias.AllowUserToAddRows = false;
            DgvCategorias.AllowUserToDeleteRows = false;
            DgvCategorias.AllowUserToResizeColumns = false;
            DgvCategorias.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 245);
            DgvCategorias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvCategorias.BackgroundColor = Color.White;
            DgvCategorias.BorderStyle = BorderStyle.Fixed3D;
            DgvCategorias.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvCategorias.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(7, 100, 147);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DgvCategorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvCategorias.Dock = DockStyle.Fill;
            DgvCategorias.EnableHeadersVisualStyles = false;
            DgvCategorias.GridColor = Color.FromArgb(220, 220, 225);
            DgvCategorias.Location = new Point(3, 209);
            DgvCategorias.Name = "DgvCategorias";
            DgvCategorias.ReadOnly = true;
            DgvCategorias.RowHeadersVisible = false;
            DgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvCategorias.Size = new Size(398, 253);
            DgvCategorias.TabIndex = 0;
            DgvCategorias.SelectionChanged += DgvCategorias_SelectionChanged;
            // 
            // GBFormCategoria
            // 
            GBFormCategoria.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            GBFormCategoria.Controls.Add(tableLayoutPanel3);
            GBFormCategoria.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GBFormCategoria.Location = new Point(3, 41);
            GBFormCategoria.Name = "GBFormCategoria";
            GBFormCategoria.Size = new Size(398, 162);
            GBFormCategoria.TabIndex = 2;
            GBFormCategoria.TabStop = false;
            GBFormCategoria.Text = "Formulario de Categoría";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(label1, 0, 0);
            tableLayoutPanel3.Controls.Add(TxtCategoria, 0, 1);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 2);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 23);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(392, 136);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(386, 30);
            label1.TabIndex = 0;
            label1.Text = "Nombre de la Categoría:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TxtCategoria
            // 
            TxtCategoria.Dock = DockStyle.Fill;
            TxtCategoria.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtCategoria.Location = new Point(3, 33);
            TxtCategoria.Name = "TxtCategoria";
            TxtCategoria.Size = new Size(386, 29);
            TxtCategoria.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel4.Controls.Add(BtnNuevaCategoria, 0, 0);
            tableLayoutPanel4.Controls.Add(BtnEliminarCategoria, 1, 0);
            tableLayoutPanel4.Controls.Add(BtnGuardarCategoria, 2, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 63);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(386, 70);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // BtnNuevaCategoria
            // 
            BtnNuevaCategoria.Anchor = AnchorStyles.None;
            BtnNuevaCategoria.BackColor = Color.FromArgb(0, 123, 255);
            BtnNuevaCategoria.FlatStyle = FlatStyle.Flat;
            BtnNuevaCategoria.ForeColor = Color.White;
            BtnNuevaCategoria.Location = new Point(6, 19);
            BtnNuevaCategoria.Name = "BtnNuevaCategoria";
            BtnNuevaCategoria.Size = new Size(115, 32);
            BtnNuevaCategoria.TabIndex = 3;
            BtnNuevaCategoria.Text = "Nueva";
            BtnNuevaCategoria.UseVisualStyleBackColor = false;
            BtnNuevaCategoria.Click += BtnNuevaCategoria_Click;
            // 
            // BtnEliminarCategoria
            // 
            BtnEliminarCategoria.Anchor = AnchorStyles.None;
            BtnEliminarCategoria.BackColor = Color.FromArgb(220, 53, 69);
            BtnEliminarCategoria.FlatStyle = FlatStyle.Flat;
            BtnEliminarCategoria.ForeColor = Color.White;
            BtnEliminarCategoria.Location = new Point(134, 19);
            BtnEliminarCategoria.Name = "BtnEliminarCategoria";
            BtnEliminarCategoria.Size = new Size(115, 32);
            BtnEliminarCategoria.TabIndex = 1;
            BtnEliminarCategoria.Text = "Eliminar";
            BtnEliminarCategoria.UseVisualStyleBackColor = false;
            BtnEliminarCategoria.Click += BtnEliminarCategoria_Click;
            // 
            // BtnGuardarCategoria
            // 
            BtnGuardarCategoria.Anchor = AnchorStyles.None;
            BtnGuardarCategoria.BackColor = Color.FromArgb(40, 167, 69);
            BtnGuardarCategoria.FlatStyle = FlatStyle.Flat;
            BtnGuardarCategoria.ForeColor = Color.White;
            BtnGuardarCategoria.Location = new Point(263, 19);
            BtnGuardarCategoria.Name = "BtnGuardarCategoria";
            BtnGuardarCategoria.Size = new Size(115, 32);
            BtnGuardarCategoria.TabIndex = 2;
            BtnGuardarCategoria.Text = "Guardar";
            BtnGuardarCategoria.UseVisualStyleBackColor = false;
            BtnGuardarCategoria.Click += BtnGuardarCategoria_Click;
            // 
            // PbProgreso
            // 
            PbProgreso.Dock = DockStyle.Top;
            PbProgreso.Location = new Point(0, 0);
            PbProgreso.Name = "PbProgreso";
            PbProgreso.Size = new Size(804, 10);
            PbProgreso.Style = ProgressBarStyle.Marquee;
            PbProgreso.TabIndex = 1;
            PbProgreso.Visible = false;
            // 
            // GBSubcategorias
            // 
            GBSubcategorias.Controls.Add(tableLayoutPanel5);
            GBSubcategorias.Dock = DockStyle.Fill;
            GBSubcategorias.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GBSubcategorias.Location = new Point(0, 0);
            GBSubcategorias.Name = "GBSubcategorias";
            GBSubcategorias.Size = new Size(390, 493);
            GBSubcategorias.TabIndex = 2;
            GBSubcategorias.TabStop = false;
            GBSubcategorias.Text = "Subcategorías";
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(tableLayoutPanel6, 0, 0);
            tableLayoutPanel5.Controls.Add(DgvSubcategorias, 0, 2);
            tableLayoutPanel5.Controls.Add(GBFormSubcategoria, 0, 1);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 25);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 3;
            tableLayoutPanel5.RowStyles.Add(new RowStyle());
            tableLayoutPanel5.RowStyles.Add(new RowStyle());
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(384, 465);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.4497337F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.55026F));
            tableLayoutPanel6.Controls.Add(label3, 0, 0);
            tableLayoutPanel6.Controls.Add(LblCategoriaSeleccionada, 1, 0);
            tableLayoutPanel6.Location = new Point(3, 3);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(378, 31);
            tableLayoutPanel6.TabIndex = 3;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 5);
            label3.Name = "label3";
            label3.Size = new Size(127, 21);
            label3.TabIndex = 2;
            label3.Text = "Categoria Actual:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCategoriaSeleccionada
            // 
            LblCategoriaSeleccionada.Anchor = AnchorStyles.Left;
            LblCategoriaSeleccionada.AutoSize = true;
            LblCategoriaSeleccionada.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblCategoriaSeleccionada.Location = new Point(136, 5);
            LblCategoriaSeleccionada.Name = "LblCategoriaSeleccionada";
            LblCategoriaSeleccionada.Size = new Size(77, 21);
            LblCategoriaSeleccionada.TabIndex = 1;
            LblCategoriaSeleccionada.Text = "Ninguna";
            LblCategoriaSeleccionada.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DgvSubcategorias
            // 
            DgvSubcategorias.AllowUserToAddRows = false;
            DgvSubcategorias.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(240, 240, 245);
            DgvSubcategorias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            DgvSubcategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvSubcategorias.BackgroundColor = Color.White;
            DgvSubcategorias.BorderStyle = BorderStyle.Fixed3D;
            DgvSubcategorias.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvSubcategorias.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(7, 100, 147);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            DgvSubcategorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            DgvSubcategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvSubcategorias.Dock = DockStyle.Fill;
            DgvSubcategorias.EnableHeadersVisualStyles = false;
            DgvSubcategorias.GridColor = Color.FromArgb(220, 220, 225);
            DgvSubcategorias.Location = new Point(3, 209);
            DgvSubcategorias.Name = "DgvSubcategorias";
            DgvSubcategorias.ReadOnly = true;
            DgvSubcategorias.RowHeadersVisible = false;
            DgvSubcategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvSubcategorias.Size = new Size(378, 253);
            DgvSubcategorias.TabIndex = 0;
            DgvSubcategorias.SelectionChanged += DgvSubcategorias_SelectionChanged;
            // 
            // GBFormSubcategoria
            // 
            GBFormSubcategoria.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            GBFormSubcategoria.Controls.Add(tableLayoutPanel7);
            GBFormSubcategoria.Location = new Point(3, 40);
            GBFormSubcategoria.Name = "GBFormSubcategoria";
            GBFormSubcategoria.Size = new Size(378, 163);
            GBFormSubcategoria.TabIndex = 2;
            GBFormSubcategoria.TabStop = false;
            GBFormSubcategoria.Text = "Formulario de Subcategoría";
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Controls.Add(label2, 0, 0);
            tableLayoutPanel7.Controls.Add(TxtSubcategoria, 0, 1);
            tableLayoutPanel7.Controls.Add(tableLayoutPanel8, 0, 2);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(3, 25);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 3;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 21.4814816F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 26.666666F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 51.8518524F));
            tableLayoutPanel7.Size = new Size(372, 135);
            tableLayoutPanel7.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(366, 29);
            label2.TabIndex = 0;
            label2.Text = "Nombre de la Subcategoría:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TxtSubcategoria
            // 
            TxtSubcategoria.Dock = DockStyle.Fill;
            TxtSubcategoria.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtSubcategoria.Location = new Point(3, 32);
            TxtSubcategoria.Name = "TxtSubcategoria";
            TxtSubcategoria.Size = new Size(366, 29);
            TxtSubcategoria.TabIndex = 1;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel8.ColumnCount = 3;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel8.Controls.Add(BtnNuevaSubcategoria, 0, 0);
            tableLayoutPanel8.Controls.Add(BtnEliminarSubcategoria, 1, 0);
            tableLayoutPanel8.Controls.Add(BtnGuardarSubcategoria, 2, 0);
            tableLayoutPanel8.Location = new Point(3, 79);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle());
            tableLayoutPanel8.Size = new Size(366, 42);
            tableLayoutPanel8.TabIndex = 2;
            // 
            // BtnNuevaSubcategoria
            // 
            BtnNuevaSubcategoria.Anchor = AnchorStyles.None;
            BtnNuevaSubcategoria.BackColor = Color.FromArgb(0, 123, 255);
            BtnNuevaSubcategoria.FlatStyle = FlatStyle.Flat;
            BtnNuevaSubcategoria.ForeColor = Color.White;
            BtnNuevaSubcategoria.Location = new Point(5, 5);
            BtnNuevaSubcategoria.Name = "BtnNuevaSubcategoria";
            BtnNuevaSubcategoria.Size = new Size(111, 32);
            BtnNuevaSubcategoria.TabIndex = 3;
            BtnNuevaSubcategoria.Text = "Nueva";
            BtnNuevaSubcategoria.UseVisualStyleBackColor = false;
            BtnNuevaSubcategoria.Click += BtnNuevaSubcategoria_Click;
            // 
            // BtnEliminarSubcategoria
            // 
            BtnEliminarSubcategoria.Anchor = AnchorStyles.None;
            BtnEliminarSubcategoria.BackColor = Color.FromArgb(220, 53, 69);
            BtnEliminarSubcategoria.FlatStyle = FlatStyle.Flat;
            BtnEliminarSubcategoria.ForeColor = Color.White;
            BtnEliminarSubcategoria.Location = new Point(127, 5);
            BtnEliminarSubcategoria.Name = "BtnEliminarSubcategoria";
            BtnEliminarSubcategoria.Size = new Size(111, 32);
            BtnEliminarSubcategoria.TabIndex = 1;
            BtnEliminarSubcategoria.Text = "Eliminar";
            BtnEliminarSubcategoria.UseVisualStyleBackColor = false;
            BtnEliminarSubcategoria.Click += BtnEliminarSubcategoria_Click;
            // 
            // BtnGuardarSubcategoria
            // 
            BtnGuardarSubcategoria.Anchor = AnchorStyles.None;
            BtnGuardarSubcategoria.BackColor = Color.FromArgb(40, 167, 69);
            BtnGuardarSubcategoria.FlatStyle = FlatStyle.Flat;
            BtnGuardarSubcategoria.ForeColor = Color.White;
            BtnGuardarSubcategoria.Location = new Point(249, 5);
            BtnGuardarSubcategoria.Name = "BtnGuardarSubcategoria";
            BtnGuardarSubcategoria.Size = new Size(111, 32);
            BtnGuardarSubcategoria.TabIndex = 2;
            BtnGuardarSubcategoria.Text = "Guardar";
            BtnGuardarSubcategoria.UseVisualStyleBackColor = false;
            BtnGuardarSubcategoria.Click += BtnGuardarSubcategoria_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(GBCategorias);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(GBSubcategorias);
            splitContainer1.Size = new Size(804, 493);
            splitContainer1.SplitterDistance = 410;
            splitContainer1.TabIndex = 1;
            // 
            // UCGestionCategorias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PbProgreso);
            Controls.Add(splitContainer1);
            Name = "UCGestionCategorias";
            Size = new Size(804, 493);
            Load += UCGestionCategorias_Load;
            GBCategorias.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvCategorias).EndInit();
            GBFormCategoria.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            GBSubcategorias.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvSubcategorias).EndInit();
            GBFormSubcategoria.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            tableLayoutPanel8.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox GBCategorias;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView DgvCategorias;
        private GroupBox GBFormCategoria;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label1;
        private TextBox TxtCategoria;
        private TableLayoutPanel tableLayoutPanel4;
        private Button BtnEliminarCategoria;
        private Button BtnGuardarCategoria;
        private ProgressBar PbProgreso;
        private GroupBox GBSubcategorias;
        private TableLayoutPanel tableLayoutPanel5;
        private DataGridView DgvSubcategorias;
        private GroupBox GBFormSubcategoria;
        private TableLayoutPanel tableLayoutPanel7;
        private Label label2;
        private TextBox TxtSubcategoria;
        private TableLayoutPanel tableLayoutPanel8;
        private Button BtnEliminarSubcategoria;
        private Button BtnGuardarSubcategoria;
        private SplitContainer splitContainer1;
        private Button BtnActualizar;
        private TableLayoutPanel tableLayoutPanel6;
        private Label label3;
        private Label LblCategoriaSeleccionada;
        private Button BtnNuevaCategoria;
        private Button BtnNuevaSubcategoria;
    }
}