﻿namespace Wafer_System
{
    partial class Auto_run_page2
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
            this.btn_Go_Page1 = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Go_Page1
            // 
            this.btn_Go_Page1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Go_Page1.Location = new System.Drawing.Point(890, 497);
            this.btn_Go_Page1.Name = "btn_Go_Page1";
            this.btn_Go_Page1.Size = new System.Drawing.Size(109, 70);
            this.btn_Go_Page1.TabIndex = 1;
            this.btn_Go_Page1.Text = "Setup";
            this.btn_Go_Page1.UseVisualStyleBackColor = true;
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(281, 389);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(118, 75);
            this.btn_Start.TabIndex = 2;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.btn_Start);
            this.panel.Controls.Add(this.btn_Go_Page1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1002, 570);
            this.panel.TabIndex = 3;
            // 
            // Auto_run_page2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 570);
            this.Controls.Add(this.panel);
            this.Name = "Auto_run_page2";
            this.Text = "Auto_run_page2";
            this.Load += new System.EventHandler(this.Auto_run_page2_Load);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Go_Page1;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Panel panel;
    }
}