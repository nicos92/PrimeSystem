namespace PrimeSystem.Arranque;

partial class FormArranque
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
        LblBienvenido = new Label();
        PanelPrincipal = new Panel();
        ProgressBar = new ProgressBar();
        LblCargando = new Label();
        panel1 = new Panel();
        PanelPrincipal.SuspendLayout();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // LblBienvenido
        // 
        LblBienvenido.Anchor = AnchorStyles.None;
        LblBienvenido.AutoSize = true;
        LblBienvenido.Font = new Font("Segoe UI", 72F, FontStyle.Bold, GraphicsUnit.Point, 0);
        LblBienvenido.ForeColor = Color.FromArgb(236, 239, 241);
        LblBienvenido.Location = new Point(21, 44);
        LblBienvenido.Name = "LblBienvenido";
        LblBienvenido.Size = new Size(739, 256);
        LblBienvenido.TabIndex = 0;
        LblBienvenido.Text = "Bienvenido a\r\nPRIME SYSTEM";
        LblBienvenido.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // PanelPrincipal
        // 
        PanelPrincipal.BackColor = Color.FromArgb(38, 50, 56);
        PanelPrincipal.Controls.Add(ProgressBar);
        PanelPrincipal.Controls.Add(LblCargando);
        PanelPrincipal.Controls.Add(LblBienvenido);
        PanelPrincipal.Dock = DockStyle.Fill;
        PanelPrincipal.Location = new Point(2, 2);
        PanelPrincipal.Name = "PanelPrincipal";
        PanelPrincipal.Size = new Size(796, 496);
        PanelPrincipal.TabIndex = 1;
        // 
        // ProgressBar
        // 
        ProgressBar.Dock = DockStyle.Top;
        ProgressBar.Location = new Point(0, 0);
        ProgressBar.Name = "ProgressBar";
        ProgressBar.Size = new Size(796, 23);
        ProgressBar.TabIndex = 2;
        // 
        // LblCargando
        // 
        LblCargando.Anchor = AnchorStyles.None;
        LblCargando.AutoSize = true;
        LblCargando.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
        LblCargando.ForeColor = Color.FromArgb(207, 216, 220);
        LblCargando.Location = new Point(107, 407);
        LblCargando.Name = "LblCargando";
        LblCargando.Size = new Size(166, 45);
        LblCargando.TabIndex = 1;
        LblCargando.Text = "Cargando";
        LblCargando.TextAlign = ContentAlignment.TopCenter;
        // 
        // panel1
        // 
        panel1.Controls.Add(PanelPrincipal);
        panel1.Dock = DockStyle.Fill;
        panel1.Location = new Point(0, 0);
        panel1.Name = "panel1";
        panel1.Padding = new Padding(2);
        panel1.Size = new Size(800, 500);
        panel1.TabIndex = 3;
        // 
        // FormArranque
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.FromArgb(242, 242, 242);
        ClientSize = new Size(800, 500);
        Controls.Add(panel1);
        Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        ForeColor = Color.FromArgb(33, 33, 33);
        FormBorderStyle = FormBorderStyle.None;
        Name = "FormArranque";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Bienvenido";
        Load += Form1_Load;
        PanelPrincipal.ResumeLayout(false);
        PanelPrincipal.PerformLayout();
        panel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Label LblBienvenido;
    private Panel PanelPrincipal;
    private Label LblCargando;
    private ProgressBar ProgressBar;
    private Panel panel1;
}
