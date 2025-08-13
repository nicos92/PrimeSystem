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
        PanelPrincipal.SuspendLayout();
        SuspendLayout();
        // 
        // LblBienvenido
        // 
        LblBienvenido.Anchor = AnchorStyles.None;
        LblBienvenido.AutoSize = true;
        LblBienvenido.Font = new Font("Segoe UI", 72F, FontStyle.Bold, GraphicsUnit.Point, 0);
        LblBienvenido.Location = new Point(23, 46);
        LblBienvenido.Name = "LblBienvenido";
        LblBienvenido.Size = new Size(739, 256);
        LblBienvenido.TabIndex = 0;
        LblBienvenido.Text = "Bienvenido a\r\nPRIME SYSTEM";
        LblBienvenido.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // PanelPrincipal
        // 
        PanelPrincipal.Controls.Add(ProgressBar);
        PanelPrincipal.Controls.Add(LblCargando);
        PanelPrincipal.Controls.Add(LblBienvenido);
        PanelPrincipal.Dock = DockStyle.Fill;
        PanelPrincipal.Location = new Point(0, 0);
        PanelPrincipal.Name = "PanelPrincipal";
        PanelPrincipal.Size = new Size(800, 500);
        PanelPrincipal.TabIndex = 1;
        // 
        // ProgressBar
        // 
        ProgressBar.Dock = DockStyle.Top;
        ProgressBar.Location = new Point(0, 0);
        ProgressBar.Name = "ProgressBar";
        ProgressBar.Size = new Size(800, 23);
        ProgressBar.TabIndex = 2;
        // 
        // LblCargando
        // 
        LblCargando.Anchor = AnchorStyles.None;
        LblCargando.AutoSize = true;
        LblCargando.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
        LblCargando.ForeColor = Color.FromArgb(55, 55, 55);
        LblCargando.Location = new Point(109, 409);
        LblCargando.Name = "LblCargando";
        LblCargando.Size = new Size(166, 45);
        LblCargando.TabIndex = 1;
        LblCargando.Text = "Cargando";
        LblCargando.TextAlign = ContentAlignment.TopCenter;
        // 
        // FormArranque
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.FromArgb(242, 242, 242);
        ClientSize = new Size(800, 500);
        Controls.Add(PanelPrincipal);
        Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        ForeColor = Color.FromArgb(33, 33, 33);
        FormBorderStyle = FormBorderStyle.None;
        Name = "FormArranque";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Bienvenido";
        Load += Form1_Load;
        PanelPrincipal.ResumeLayout(false);
        PanelPrincipal.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Label LblBienvenido;
    private Panel PanelPrincipal;
    private Label LblCargando;
    private ProgressBar ProgressBar;
}
