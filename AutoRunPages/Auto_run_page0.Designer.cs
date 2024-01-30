namespace Wafer_System
{
    partial class Auto_run_page0
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
            this.txt_IniStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_IniStatus
            // 
            this.txt_IniStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txt_IniStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_IniStatus.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txt_IniStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_IniStatus.Enabled = false;
            this.txt_IniStatus.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IniStatus.Location = new System.Drawing.Point(0, 0);
            this.txt_IniStatus.Multiline = true;
            this.txt_IniStatus.Name = "txt_IniStatus";
            this.txt_IniStatus.ReadOnly = true;
            this.txt_IniStatus.Size = new System.Drawing.Size(871, 610);
            this.txt_IniStatus.TabIndex = 2;
            this.txt_IniStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_IniStatus.TextChanged += new System.EventHandler(this.txt_IniStatus_TextChanged);
            // 
            // Auto_run_page0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 610);
            this.Controls.Add(this.txt_IniStatus);
            this.Name = "Auto_run_page0";
            this.Text = "Auto_run_page0";
            this.Load += new System.EventHandler(this.Auto_run_page0_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_IniStatus;
    }
}