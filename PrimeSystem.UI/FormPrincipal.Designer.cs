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
        label1 = new Label();
        dataGridView1 = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Dock = DockStyle.Top;
        label1.Font = new Font("Segoe UI", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label1.Location = new Point(0, 0);
        label1.Name = "label1";
        label1.Size = new Size(780, 128);
        label1.TabIndex = 0;
        label1.Text = "INICIO";
        label1.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Dock = DockStyle.Fill;
        dataGridView1.Location = new Point(0, 128);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridView1.Size = new Size(780, 329);
        dataGridView1.TabIndex = 1;
        // 
        // FormPrincipal
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.FromArgb(242, 242, 242);
        ClientSize = new Size(780, 457);
        Controls.Add(dataGridView1);
        Controls.Add(label1);
        Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        ForeColor = Color.FromArgb(33, 33, 33);
        FormBorderStyle = FormBorderStyle.Fixed3D;
        Name = "FormPrincipal";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Form1";
        Load += FormPrincipal_Load;
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Label label1;
    private DataGridView dataGridView1;
}
