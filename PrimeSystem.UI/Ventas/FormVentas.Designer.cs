namespace PrimeSystem.UI.Ventas
{
    partial class FormVentas
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
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 35, 87);
            label1.Location = new Point(150, 177);
            label1.Name = "label1";
            label1.Size = new Size(237, 86);
            label1.TabIndex = 0;
            label1.Text = "Ventas";
            // 
            // FormVentas
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(222, 184, 247);
            ClientSize = new Size(560, 457);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormVentas";
            Text = "FormVentas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    }
}