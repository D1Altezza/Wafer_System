namespace Wafer_System
{
    partial class EFEM_Monitor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fLP_GetStatus = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fLP_GetStatus);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1002, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "EFEM Status";
            // 
            // fLP_GetStatus
            // 
            this.fLP_GetStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fLP_GetStatus.Location = new System.Drawing.Point(3, 18);
            this.fLP_GetStatus.Name = "fLP_GetStatus";
            this.fLP_GetStatus.Size = new System.Drawing.Size(996, 79);
            this.fLP_GetStatus.TabIndex = 0;
            // 
            // EFEM_Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 541);
            this.Controls.Add(this.groupBox1);
            this.Name = "EFEM_Monitor";
            this.Text = "EFEM_Monitor";
            this.Load += new System.EventHandler(this.EFEM_Monitor_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel fLP_GetStatus;
    }
}