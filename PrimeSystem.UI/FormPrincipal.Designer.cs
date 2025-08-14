namespace PrimeSystem.UI;

partial class FormPrincipal
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        PanelMenu = new Panel();
        button7 = new Button();
        button6 = new Button();
        button5 = new Button();
        BtnModClientes = new Button();
        BtnModCompras = new Button();
        BtnModVentas = new Button();
        panel1 = new Panel();
        panel2 = new Panel();
        label1 = new Label();
        PanelFondoMenu = new Panel();
        PanelMenu.SuspendLayout();
        panel1.SuspendLayout();
        panel2.SuspendLayout();
        PanelFondoMenu.SuspendLayout();
        SuspendLayout();
        // 
        // PanelMenu
        // 
        PanelMenu.BackColor = Color.FromArgb(38, 50, 56);
        PanelMenu.Controls.Add(button7);
        PanelMenu.Controls.Add(button6);
        PanelMenu.Controls.Add(button5);
        PanelMenu.Controls.Add(BtnModClientes);
        PanelMenu.Controls.Add(BtnModCompras);
        PanelMenu.Controls.Add(BtnModVentas);
        PanelMenu.Controls.Add(panel1);
        PanelMenu.Dock = DockStyle.Fill;
        PanelMenu.Location = new Point(0, 0);
        PanelMenu.Name = "PanelMenu";
        PanelMenu.Size = new Size(216, 461);
        PanelMenu.TabIndex = 0;
        // 
        // button7
        // 
        button7.Dock = DockStyle.Top;
        button7.FlatAppearance.BorderSize = 0;
        button7.FlatStyle = FlatStyle.Flat;
        button7.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        button7.ForeColor = Color.FromArgb(207, 216, 220);
        button7.Location = new Point(0, 384);
        button7.Name = "button7";
        button7.Size = new Size(216, 64);
        button7.TabIndex = 6;
        button7.Text = "Estado Contable";
        button7.TextAlign = ContentAlignment.MiddleLeft;
        button7.UseVisualStyleBackColor = true;
        button7.Click += ElejirModulo;
        // 
        // button6
        // 
        button6.Dock = DockStyle.Top;
        button6.FlatAppearance.BorderSize = 0;
        button6.FlatStyle = FlatStyle.Flat;
        button6.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        button6.ForeColor = Color.FromArgb(207, 216, 220);
        button6.Location = new Point(0, 320);
        button6.Name = "button6";
        button6.Size = new Size(216, 64);
        button6.TabIndex = 5;
        button6.Text = "Proveedores";
        button6.TextAlign = ContentAlignment.MiddleLeft;
        button6.UseVisualStyleBackColor = true;
        button6.Click += ElejirModulo;
        // 
        // button5
        // 
        button5.Dock = DockStyle.Top;
        button5.FlatAppearance.BorderSize = 0;
        button5.FlatStyle = FlatStyle.Flat;
        button5.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        button5.ForeColor = Color.FromArgb(207, 216, 220);
        button5.Location = new Point(0, 256);
        button5.Name = "button5";
        button5.Size = new Size(216, 64);
        button5.TabIndex = 4;
        button5.Text = "Usuarios";
        button5.TextAlign = ContentAlignment.MiddleLeft;
        button5.UseVisualStyleBackColor = true;
        button5.Click += ElejirModulo;
        // 
        // BtnModClientes
        // 
        BtnModClientes.Dock = DockStyle.Top;
        BtnModClientes.FlatAppearance.BorderSize = 0;
        BtnModClientes.FlatStyle = FlatStyle.Flat;
        BtnModClientes.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        BtnModClientes.ForeColor = Color.FromArgb(207, 216, 220);
        BtnModClientes.Location = new Point(0, 192);
        BtnModClientes.Name = "BtnModClientes";
        BtnModClientes.Size = new Size(216, 64);
        BtnModClientes.TabIndex = 3;
        BtnModClientes.Text = "Clientes";
        BtnModClientes.TextAlign = ContentAlignment.MiddleLeft;
        BtnModClientes.UseVisualStyleBackColor = true;
        BtnModClientes.Click += ElejirModulo;
        // 
        // BtnModCompras
        // 
        BtnModCompras.Dock = DockStyle.Top;
        BtnModCompras.FlatAppearance.BorderSize = 0;
        BtnModCompras.FlatStyle = FlatStyle.Flat;
        BtnModCompras.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        BtnModCompras.ForeColor = Color.FromArgb(207, 216, 220);
        BtnModCompras.Location = new Point(0, 128);
        BtnModCompras.Name = "BtnModCompras";
        BtnModCompras.Size = new Size(216, 64);
        BtnModCompras.TabIndex = 2;
        BtnModCompras.Text = "Compras";
        BtnModCompras.TextAlign = ContentAlignment.MiddleLeft;
        BtnModCompras.UseVisualStyleBackColor = true;
        BtnModCompras.Click += ElejirModulo;
        // 
        // BtnModVentas
        // 
        BtnModVentas.BackColor = Color.FromArgb(55, 71, 79);
        BtnModVentas.Dock = DockStyle.Top;
        BtnModVentas.FlatAppearance.BorderSize = 0;
        BtnModVentas.FlatStyle = FlatStyle.Flat;
        BtnModVentas.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        BtnModVentas.ForeColor = Color.FromArgb(236, 239, 241);
        BtnModVentas.Location = new Point(0, 64);
        BtnModVentas.Name = "BtnModVentas";
        BtnModVentas.Size = new Size(216, 64);
        BtnModVentas.TabIndex = 1;
        BtnModVentas.Text = "Ventas";
        BtnModVentas.TextAlign = ContentAlignment.MiddleLeft;
        BtnModVentas.UseVisualStyleBackColor = false;
        BtnModVentas.Click += ElejirModulo;
        // 
        // panel1
        // 
        panel1.BackColor = Color.FromArgb(84, 110, 122);
        panel1.Controls.Add(panel2);
        panel1.Dock = DockStyle.Top;
        panel1.Location = new Point(0, 0);
        panel1.Name = "panel1";
        panel1.Padding = new Padding(0, 0, 0, 4);
        panel1.Size = new Size(216, 64);
        panel1.TabIndex = 7;
        // 
        // panel2
        // 
        panel2.BackColor = Color.FromArgb(38, 50, 56);
        panel2.Controls.Add(label1);
        panel2.Dock = DockStyle.Fill;
        panel2.Location = new Point(0, 0);
        panel2.Name = "panel2";
        panel2.Size = new Size(216, 60);
        panel2.TabIndex = 1;
        // 
        // label1
        // 
        label1.BackColor = Color.Transparent;
        label1.Dock = DockStyle.Fill;
        label1.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label1.ForeColor = Color.FromArgb(236, 239, 241);
        label1.Location = new Point(0, 0);
        label1.Name = "label1";
        label1.Size = new Size(216, 60);
        label1.TabIndex = 0;
        label1.Text = "PRIME SYSTEM";
        label1.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // PanelFondoMenu
        // 
        PanelFondoMenu.BackColor = Color.FromArgb(55, 71, 79);
        PanelFondoMenu.Controls.Add(PanelMenu);
        PanelFondoMenu.Dock = DockStyle.Left;
        PanelFondoMenu.Location = new Point(0, 0);
        PanelFondoMenu.Name = "PanelFondoMenu";
        PanelFondoMenu.Padding = new Padding(0, 0, 4, 0);
        PanelFondoMenu.Size = new Size(220, 461);
        PanelFondoMenu.TabIndex = 1;
        // 
        // FormPrincipal
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.FromArgb(242, 242, 242);
        ClientSize = new Size(784, 461);
        Controls.Add(PanelFondoMenu);
        Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        ForeColor = Color.FromArgb(33, 33, 33);
        IsMdiContainer = true;
        MinimumSize = new Size(800, 500);
        Name = "FormPrincipal";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Prime System";
        TransparencyKey = Color.DimGray;
        Load += FormPrincipal_Load;
        PanelMenu.ResumeLayout(false);
        panel1.ResumeLayout(false);
        panel2.ResumeLayout(false);
        PanelFondoMenu.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel PanelMenu;
    private Panel PanelFondoMenu;
    private Button button7;
    private Button button6;
    private Button button5;
    private Button BtnModClientes;
    private Button BtnModCompras;
    private Button BtnModVentas;
    private Panel panel1;
    private Label label1;
    private Panel panel2;
}
