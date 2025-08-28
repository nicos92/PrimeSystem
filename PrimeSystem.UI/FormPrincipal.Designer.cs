using PrimeSystem.Utilidades;

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
        BtnArticulos = new Button();
        BtnModEstadoContable = new Button();
        BtnModProveedores = new Button();
        BtnModUsuarios = new Button();
        BtnModClientes = new Button();
        BtnModCompras = new Button();
        BtnModVentas = new Button();
        panel1 = new Panel();
        panel2 = new Panel();
        LblApp = new Label();
        PanelFondoMenu = new Panel();
        PanelMenu.SuspendLayout();
        panel1.SuspendLayout();
        panel2.SuspendLayout();
        PanelFondoMenu.SuspendLayout();
        SuspendLayout();
        // 
        // PanelMenu
        // 
        PanelMenu.AutoScroll = true;
        PanelMenu.BackColor = Color.FromArgb(7, 100, 147);
        PanelMenu.Controls.Add(BtnArticulos);
        PanelMenu.Controls.Add(BtnModEstadoContable);
        PanelMenu.Controls.Add(BtnModProveedores);
        PanelMenu.Controls.Add(BtnModUsuarios);
        PanelMenu.Controls.Add(BtnModClientes);
        PanelMenu.Controls.Add(BtnModCompras);
        PanelMenu.Controls.Add(BtnModVentas);
        PanelMenu.Controls.Add(panel1);
        PanelMenu.Dock = DockStyle.Fill;
        PanelMenu.ForeColor = Color.FromArgb(255, 255, 255);
        PanelMenu.Location = new Point(0, 0);
        PanelMenu.Name = "PanelMenu";
        PanelMenu.Size = new Size(219, 561);
        PanelMenu.TabIndex = 0;
        // 
        // BtnArticulos
        // 
        BtnArticulos.Dock = DockStyle.Top;
        BtnArticulos.FlatAppearance.BorderSize = 0;
        BtnArticulos.FlatStyle = FlatStyle.Flat;
        BtnArticulos.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        BtnArticulos.Image = Properties.Resources.charts;
        BtnArticulos.ImageAlign = ContentAlignment.MiddleLeft;
        BtnArticulos.Location = new Point(0, 448);
        BtnArticulos.Name = "BtnArticulos";
        BtnArticulos.Size = new Size(219, 64);
        BtnArticulos.TabIndex = 8;
        BtnArticulos.Text = "Articulos";
        BtnArticulos.TextAlign = ContentAlignment.MiddleLeft;
        BtnArticulos.TextImageRelation = TextImageRelation.ImageBeforeText;
        BtnArticulos.UseVisualStyleBackColor = true;
        BtnArticulos.Click += ElejirModulo;
        // 
        // BtnModEstadoContable
        // 
        BtnModEstadoContable.Dock = DockStyle.Top;
        BtnModEstadoContable.FlatAppearance.BorderSize = 0;
        BtnModEstadoContable.FlatStyle = FlatStyle.Flat;
        BtnModEstadoContable.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        BtnModEstadoContable.Image = Properties.Resources.charts;
        BtnModEstadoContable.ImageAlign = ContentAlignment.MiddleLeft;
        BtnModEstadoContable.Location = new Point(0, 384);
        BtnModEstadoContable.Name = "BtnModEstadoContable";
        BtnModEstadoContable.Size = new Size(219, 64);
        BtnModEstadoContable.TabIndex = 6;
        BtnModEstadoContable.Text = "Estado Contable";
        BtnModEstadoContable.TextAlign = ContentAlignment.MiddleLeft;
        BtnModEstadoContable.TextImageRelation = TextImageRelation.ImageBeforeText;
        BtnModEstadoContable.UseVisualStyleBackColor = true;
        BtnModEstadoContable.Click += ElejirModulo;
        // 
        // BtnModProveedores
        // 
        BtnModProveedores.Dock = DockStyle.Top;
        BtnModProveedores.FlatAppearance.BorderSize = 0;
        BtnModProveedores.FlatStyle = FlatStyle.Flat;
        BtnModProveedores.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        BtnModProveedores.Image = Properties.Resources.proveedores;
        BtnModProveedores.ImageAlign = ContentAlignment.MiddleLeft;
        BtnModProveedores.Location = new Point(0, 320);
        BtnModProveedores.Name = "BtnModProveedores";
        BtnModProveedores.Size = new Size(219, 64);
        BtnModProveedores.TabIndex = 5;
        BtnModProveedores.Text = "Proveedores";
        BtnModProveedores.TextAlign = ContentAlignment.MiddleLeft;
        BtnModProveedores.TextImageRelation = TextImageRelation.ImageBeforeText;
        BtnModProveedores.UseVisualStyleBackColor = true;
        BtnModProveedores.Click += ElejirModulo;
        // 
        // BtnModUsuarios
        // 
        BtnModUsuarios.Dock = DockStyle.Top;
        BtnModUsuarios.FlatAppearance.BorderSize = 0;
        BtnModUsuarios.FlatStyle = FlatStyle.Flat;
        BtnModUsuarios.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        BtnModUsuarios.Image = Properties.Resources.users2;
        BtnModUsuarios.ImageAlign = ContentAlignment.MiddleLeft;
        BtnModUsuarios.Location = new Point(0, 256);
        BtnModUsuarios.Name = "BtnModUsuarios";
        BtnModUsuarios.Size = new Size(219, 64);
        BtnModUsuarios.TabIndex = 4;
        BtnModUsuarios.Text = "Usuarios";
        BtnModUsuarios.TextAlign = ContentAlignment.MiddleLeft;
        BtnModUsuarios.TextImageRelation = TextImageRelation.ImageBeforeText;
        BtnModUsuarios.UseVisualStyleBackColor = true;
        BtnModUsuarios.Click += ElejirModulo;
        // 
        // BtnModClientes
        // 
        BtnModClientes.Dock = DockStyle.Top;
        BtnModClientes.FlatAppearance.BorderSize = 0;
        BtnModClientes.FlatStyle = FlatStyle.Flat;
        BtnModClientes.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        BtnModClientes.Image = Properties.Resources.clientes;
        BtnModClientes.ImageAlign = ContentAlignment.MiddleLeft;
        BtnModClientes.Location = new Point(0, 192);
        BtnModClientes.Name = "BtnModClientes";
        BtnModClientes.Size = new Size(219, 64);
        BtnModClientes.TabIndex = 3;
        BtnModClientes.Text = "Clientes";
        BtnModClientes.TextAlign = ContentAlignment.MiddleLeft;
        BtnModClientes.TextImageRelation = TextImageRelation.ImageBeforeText;
        BtnModClientes.UseVisualStyleBackColor = true;
        BtnModClientes.Click += ElejirModulo;
        // 
        // BtnModCompras
        // 
        BtnModCompras.Dock = DockStyle.Top;
        BtnModCompras.FlatAppearance.BorderSize = 0;
        BtnModCompras.FlatStyle = FlatStyle.Flat;
        BtnModCompras.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        BtnModCompras.Image = Properties.Resources.compra;
        BtnModCompras.ImageAlign = ContentAlignment.MiddleLeft;
        BtnModCompras.Location = new Point(0, 128);
        BtnModCompras.Name = "BtnModCompras";
        BtnModCompras.Size = new Size(219, 64);
        BtnModCompras.TabIndex = 2;
        BtnModCompras.Text = "Compras";
        BtnModCompras.TextAlign = ContentAlignment.MiddleLeft;
        BtnModCompras.TextImageRelation = TextImageRelation.ImageBeforeText;
        BtnModCompras.UseVisualStyleBackColor = true;
        BtnModCompras.Click += ElejirModulo;
        // 
        // BtnModVentas
        // 
        BtnModVentas.BackColor = Color.FromArgb(0, 75, 113);
        BtnModVentas.Dock = DockStyle.Top;
        BtnModVentas.FlatAppearance.BorderSize = 0;
        BtnModVentas.FlatStyle = FlatStyle.Flat;
        BtnModVentas.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        BtnModVentas.Image = Properties.Resources.venta;
        BtnModVentas.ImageAlign = ContentAlignment.MiddleLeft;
        BtnModVentas.Location = new Point(0, 64);
        BtnModVentas.Name = "BtnModVentas";
        BtnModVentas.Size = new Size(219, 64);
        BtnModVentas.TabIndex = 1;
        BtnModVentas.Text = "Ventas";
        BtnModVentas.TextAlign = ContentAlignment.MiddleLeft;
        BtnModVentas.TextImageRelation = TextImageRelation.ImageBeforeText;
        BtnModVentas.UseVisualStyleBackColor = false;
        BtnModVentas.Click += ElejirModulo;
        // 
        // panel1
        // 
        panel1.BackColor = Color.FromArgb(203, 230, 255);
        panel1.Controls.Add(panel2);
        panel1.Dock = DockStyle.Top;
        panel1.Location = new Point(0, 0);
        panel1.Name = "panel1";
        panel1.Padding = new Padding(0, 0, 0, 4);
        panel1.Size = new Size(219, 64);
        panel1.TabIndex = 7;
        // 
        // panel2
        // 
        panel2.BackColor = Color.FromArgb(0, 75, 113);
        panel2.Controls.Add(LblApp);
        panel2.Dock = DockStyle.Fill;
        panel2.Location = new Point(0, 0);
        panel2.Name = "panel2";
        panel2.Size = new Size(219, 60);
        panel2.TabIndex = 1;
        // 
        // LblApp
        // 
        LblApp.BackColor = Color.FromArgb(0, 75, 113);
        LblApp.Dock = DockStyle.Fill;
        LblApp.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        LblApp.ForeColor = Color.FromArgb(203, 230, 255);
        LblApp.Location = new Point(0, 0);
        LblApp.Name = "LblApp";
        LblApp.Size = new Size(219, 60);
        LblApp.TabIndex = 0;
        LblApp.Text = "PRIME SYSTEM";
        LblApp.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // PanelFondoMenu
        // 
        PanelFondoMenu.BackColor = Color.FromArgb(0, 75, 113);
        PanelFondoMenu.Controls.Add(PanelMenu);
        PanelFondoMenu.Dock = DockStyle.Left;
        PanelFondoMenu.Location = new Point(0, 0);
        PanelFondoMenu.Name = "PanelFondoMenu";
        PanelFondoMenu.Padding = new Padding(0, 0, 1, 0);
        PanelFondoMenu.Size = new Size(220, 561);
        PanelFondoMenu.TabIndex = 1;
        // 
        // FormPrincipal
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.FromArgb(249, 249, 251);
        ClientSize = new Size(1024, 561);
        Controls.Add(PanelFondoMenu);
        Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        ForeColor = Color.FromArgb(26, 28, 30);
        IsMdiContainer = true;
        MinimumSize = new Size(960, 600);
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
    private Button BtnModEstadoContable;
    private Button BtnModProveedores;
    private Button BtnModUsuarios;
    private Button BtnModClientes;
    private Button BtnModCompras;
    private Button BtnModVentas;
    private Panel panel1;
    private Label LblApp;
    private Panel panel2;
    private Button BtnArticulos;
}
