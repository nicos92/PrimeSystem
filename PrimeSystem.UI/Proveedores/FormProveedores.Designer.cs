namespace PrimeSystem.UI.Proveedores
{
    partial class FormProveedores
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
            PanelModulo = new Panel();
            TableLayoutPanelModulo = new TableLayoutPanel();
            LblModulo = new Label();
            PanelOpcion = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            BtnConsultar = new Button();
            BtnOpcionIngresar = new Button();
            PanelMedio = new Panel();
            PanelModulo.SuspendLayout();
            TableLayoutPanelModulo.SuspendLayout();
            PanelOpcion.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // PanelModulo
            // 
            PanelModulo.Controls.Add(TableLayoutPanelModulo);
            PanelModulo.Dock = DockStyle.Top;
            PanelModulo.Location = new Point(0, 0);
            PanelModulo.Name = "PanelModulo";
            PanelModulo.Size = new Size(560, 64);
            PanelModulo.TabIndex = 1;
            // 
            // TableLayoutPanelModulo
            // 
            TableLayoutPanelModulo.BackColor = Color.FromArgb(38, 50, 56);
            TableLayoutPanelModulo.ColumnCount = 1;
            TableLayoutPanelModulo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TableLayoutPanelModulo.Controls.Add(LblModulo, 0, 0);
            TableLayoutPanelModulo.Dock = DockStyle.Fill;
            TableLayoutPanelModulo.Location = new Point(0, 0);
            TableLayoutPanelModulo.Name = "TableLayoutPanelModulo";
            TableLayoutPanelModulo.RowCount = 1;
            TableLayoutPanelModulo.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TableLayoutPanelModulo.Size = new Size(560, 64);
            TableLayoutPanelModulo.TabIndex = 1;
            // 
            // LblModulo
            // 
            LblModulo.Anchor = AnchorStyles.None;
            LblModulo.AutoSize = true;
            LblModulo.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblModulo.ForeColor = Color.FromArgb(207, 216, 220);
            LblModulo.Location = new Point(187, 16);
            LblModulo.Name = "LblModulo";
            LblModulo.Size = new Size(186, 32);
            LblModulo.TabIndex = 0;
            LblModulo.Text = "PROVEEDORES";
            // 
            // PanelOpcion
            // 
            PanelOpcion.Controls.Add(tableLayoutPanel2);
            PanelOpcion.Dock = DockStyle.Top;
            PanelOpcion.Location = new Point(0, 64);
            PanelOpcion.Name = "PanelOpcion";
            PanelOpcion.Size = new Size(560, 64);
            PanelOpcion.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(BtnConsultar, 1, 0);
            tableLayoutPanel2.Controls.Add(BtnOpcionIngresar, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(560, 64);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // BtnConsultar
            // 
            BtnConsultar.Dock = DockStyle.Fill;
            BtnConsultar.FlatAppearance.BorderColor = Color.FromArgb(96, 125, 139);
            BtnConsultar.FlatStyle = FlatStyle.Flat;
            BtnConsultar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnConsultar.ForeColor = Color.FromArgb(207, 216, 220);
            BtnConsultar.Location = new Point(280, 0);
            BtnConsultar.Margin = new Padding(0);
            BtnConsultar.Name = "BtnConsultar";
            BtnConsultar.Size = new Size(280, 64);
            BtnConsultar.TabIndex = 1;
            BtnConsultar.Text = "Consultar";
            BtnConsultar.UseVisualStyleBackColor = true;
            // 
            // BtnOpcionIngresar
            // 
            BtnOpcionIngresar.BackColor = Color.FromArgb(38, 50, 56);
            BtnOpcionIngresar.Dock = DockStyle.Fill;
            BtnOpcionIngresar.FlatAppearance.BorderColor = Color.FromArgb(236, 239, 241);
            BtnOpcionIngresar.FlatStyle = FlatStyle.Flat;
            BtnOpcionIngresar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnOpcionIngresar.Location = new Point(0, 0);
            BtnOpcionIngresar.Margin = new Padding(0);
            BtnOpcionIngresar.Name = "BtnOpcionIngresar";
            BtnOpcionIngresar.Size = new Size(280, 64);
            BtnOpcionIngresar.TabIndex = 0;
            BtnOpcionIngresar.Text = "Ingresar";
            BtnOpcionIngresar.UseVisualStyleBackColor = false;
            // 
            // PanelMedio
            // 
            PanelMedio.Dock = DockStyle.Fill;
            PanelMedio.Location = new Point(0, 128);
            PanelMedio.Name = "PanelMedio";
            PanelMedio.Size = new Size(560, 329);
            PanelMedio.TabIndex = 6;
            // 
            // FormProveedores
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(55, 71, 79);
            ClientSize = new Size(560, 457);
            Controls.Add(PanelMedio);
            Controls.Add(PanelOpcion);
            Controls.Add(PanelModulo);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(236, 239, 241);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormProveedores";
            Text = "FormProveedores";
            Load += FormProveedores_Load;
            PanelModulo.ResumeLayout(false);
            TableLayoutPanelModulo.ResumeLayout(false);
            TableLayoutPanelModulo.PerformLayout();
            PanelOpcion.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelModulo;
        private TableLayoutPanel TableLayoutPanelModulo;
        private Label LblModulo;
        private Panel PanelOpcion;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BtnConsultar;
        private Button BtnOpcionIngresar;
        private Panel PanelMedio;
    }
}