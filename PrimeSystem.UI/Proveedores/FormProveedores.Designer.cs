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
            PanelOpcion = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            BtnOpcionConsultar = new Button();
            BtnOpcionIngresar = new Button();
            PanelMedio = new Panel();
            PanelOpcion.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // PanelOpcion
            // 
            PanelOpcion.Controls.Add(tableLayoutPanel2);
            PanelOpcion.Dock = DockStyle.Top;
            PanelOpcion.Location = new Point(0, 0);
            PanelOpcion.Name = "PanelOpcion";
            PanelOpcion.Size = new Size(644, 64);
            PanelOpcion.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(BtnOpcionConsultar, 1, 0);
            tableLayoutPanel2.Controls.Add(BtnOpcionIngresar, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(644, 64);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // BtnOpcionConsultar
            // 
            BtnOpcionConsultar.BackColor = Color.FromArgb(78, 66, 86);
            BtnOpcionConsultar.Dock = DockStyle.Fill;
            BtnOpcionConsultar.FlatAppearance.BorderColor = Color.FromArgb(96, 125, 139);
            BtnOpcionConsultar.FlatStyle = FlatStyle.Flat;
            BtnOpcionConsultar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnOpcionConsultar.ForeColor = Color.FromArgb(238, 221, 245);
            BtnOpcionConsultar.Location = new Point(322, 0);
            BtnOpcionConsultar.Margin = new Padding(0);
            BtnOpcionConsultar.Name = "BtnOpcionConsultar";
            BtnOpcionConsultar.Size = new Size(322, 64);
            BtnOpcionConsultar.TabIndex = 1;
            BtnOpcionConsultar.Text = "Consultar";
            BtnOpcionConsultar.UseVisualStyleBackColor = false;
            BtnOpcionConsultar.Click += BtnOpcionIngresar_Click;
            // 
            // BtnOpcionIngresar
            // 
            BtnOpcionIngresar.BackColor = Color.FromArgb(88, 58, 111);
            BtnOpcionIngresar.Dock = DockStyle.Fill;
            BtnOpcionIngresar.FlatAppearance.BorderColor = Color.FromArgb(242, 218, 255);
            BtnOpcionIngresar.FlatStyle = FlatStyle.Flat;
            BtnOpcionIngresar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnOpcionIngresar.ForeColor = Color.FromArgb(242, 218, 255);
            BtnOpcionIngresar.Location = new Point(0, 0);
            BtnOpcionIngresar.Margin = new Padding(0);
            BtnOpcionIngresar.Name = "BtnOpcionIngresar";
            BtnOpcionIngresar.Size = new Size(322, 64);
            BtnOpcionIngresar.TabIndex = 0;
            BtnOpcionIngresar.Text = "Ingresar";
            BtnOpcionIngresar.UseVisualStyleBackColor = false;
            BtnOpcionIngresar.Click += BtnOpcionIngresar_Click;
            // 
            // PanelMedio
            // 
            PanelMedio.BackColor = Color.FromArgb(22, 18, 23);
            PanelMedio.Dock = DockStyle.Fill;
            PanelMedio.Location = new Point(0, 64);
            PanelMedio.Name = "PanelMedio";
            PanelMedio.Size = new Size(644, 447);
            PanelMedio.TabIndex = 6;
            // 
            // FormProveedores
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(55, 71, 79);
            ClientSize = new Size(644, 511);
            Controls.Add(PanelMedio);
            Controls.Add(PanelOpcion);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(236, 239, 241);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormProveedores";
            Text = "FormProveedores";
            Load += FormProveedores_Load;
            PanelOpcion.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel PanelOpcion;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BtnOpcionConsultar;
        private Button BtnOpcionIngresar;
        private Panel PanelMedio;
    }
}