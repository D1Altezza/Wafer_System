namespace Wafer_System
{
    partial class Main
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.監控ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EFEM_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DiameterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MorphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.報表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SystemSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.雷射ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.運動ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaintainanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aCSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cognexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eFEMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cm1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baslerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoRun_panel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.監控ToolStripMenuItem,
            this.報表ToolStripMenuItem,
            this.設定ToolStripMenuItem,
            this.MaintainanToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(921, 26);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 監控ToolStripMenuItem
            // 
            this.監控ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EFEM_ToolStripMenuItem,
            this.DiameterToolStripMenuItem,
            this.MorphToolStripMenuItem});
            this.監控ToolStripMenuItem.Name = "監控ToolStripMenuItem";
            this.監控ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.監控ToolStripMenuItem.Text = "監控(Monitor)";
            // 
            // EFEM_ToolStripMenuItem
            // 
            this.EFEM_ToolStripMenuItem.Name = "EFEM_ToolStripMenuItem";
            this.EFEM_ToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.EFEM_ToolStripMenuItem.Text = "上下料(EFEM)";
            this.EFEM_ToolStripMenuItem.Click += new System.EventHandler(this.MonitorToolStripMenuItem_Click);
            // 
            // DiameterToolStripMenuItem
            // 
            this.DiameterToolStripMenuItem.Name = "DiameterToolStripMenuItem";
            this.DiameterToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.DiameterToolStripMenuItem.Text = "外徑量測(Diameter)";
            this.DiameterToolStripMenuItem.Click += new System.EventHandler(this.MonitorToolStripMenuItem_Click);
            // 
            // MorphToolStripMenuItem
            // 
            this.MorphToolStripMenuItem.Name = "MorphToolStripMenuItem";
            this.MorphToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.MorphToolStripMenuItem.Text = "形貌量測(BOW...)";
            this.MorphToolStripMenuItem.Click += new System.EventHandler(this.MonitorToolStripMenuItem_Click);
            // 
            // 報表ToolStripMenuItem
            // 
            this.報表ToolStripMenuItem.Name = "報表ToolStripMenuItem";
            this.報表ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.報表ToolStripMenuItem.Text = "報表(Report)";
            this.報表ToolStripMenuItem.Click += new System.EventHandler(this.ReportToolStripMenuItem_Click);
            // 
            // 設定ToolStripMenuItem
            // 
            this.設定ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SystemSettingToolStripMenuItem,
            this.雷射ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.運動ToolStripMenuItem});
            this.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            this.設定ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.設定ToolStripMenuItem.Text = "設定(Setting)";
            // 
            // SystemSettingToolStripMenuItem
            // 
            this.SystemSettingToolStripMenuItem.Name = "SystemSettingToolStripMenuItem";
            this.SystemSettingToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.SystemSettingToolStripMenuItem.Text = "系統(System)";
            this.SystemSettingToolStripMenuItem.Click += new System.EventHandler(this.SettingToolStripMenuItem_Click);
            // 
            // 雷射ToolStripMenuItem
            // 
            this.雷射ToolStripMenuItem.Name = "雷射ToolStripMenuItem";
            this.雷射ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.雷射ToolStripMenuItem.Text = "雷射(Laser)";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
            this.toolStripMenuItem1.Text = "條碼(Bar Code)";
            // 
            // 運動ToolStripMenuItem
            // 
            this.運動ToolStripMenuItem.Name = "運動ToolStripMenuItem";
            this.運動ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.運動ToolStripMenuItem.Text = "運動(Motion)";
            // 
            // MaintainanToolStripMenuItem
            // 
            this.MaintainanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aCSToolStripMenuItem,
            this.keyenceToolStripMenuItem,
            this.cognexToolStripMenuItem,
            this.eFEMToolStripMenuItem,
            this.cm1ToolStripMenuItem,
            this.baslerToolStripMenuItem});
            this.MaintainanToolStripMenuItem.Name = "MaintainanToolStripMenuItem";
            this.MaintainanToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.MaintainanToolStripMenuItem.Text = "維護(Maintainan)";
            // 
            // aCSToolStripMenuItem
            // 
            this.aCSToolStripMenuItem.Name = "aCSToolStripMenuItem";
            this.aCSToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.aCSToolStripMenuItem.Text = "ACS";
            this.aCSToolStripMenuItem.Click += new System.EventHandler(this.MaintainanToolStripMenuItem_Click);
            // 
            // keyenceToolStripMenuItem
            // 
            this.keyenceToolStripMenuItem.Name = "keyenceToolStripMenuItem";
            this.keyenceToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.keyenceToolStripMenuItem.Text = "Keyence";
            this.keyenceToolStripMenuItem.Click += new System.EventHandler(this.MaintainanToolStripMenuItem_Click);
            // 
            // cognexToolStripMenuItem
            // 
            this.cognexToolStripMenuItem.Name = "cognexToolStripMenuItem";
            this.cognexToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.cognexToolStripMenuItem.Text = "Cognex";
            this.cognexToolStripMenuItem.Click += new System.EventHandler(this.MaintainanToolStripMenuItem_Click);
            // 
            // eFEMToolStripMenuItem
            // 
            this.eFEMToolStripMenuItem.Name = "eFEMToolStripMenuItem";
            this.eFEMToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.eFEMToolStripMenuItem.Text = "EFEM";
            this.eFEMToolStripMenuItem.Click += new System.EventHandler(this.MaintainanToolStripMenuItem_Click);
            // 
            // cm1ToolStripMenuItem
            // 
            this.cm1ToolStripMenuItem.Name = "cm1ToolStripMenuItem";
            this.cm1ToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.cm1ToolStripMenuItem.Text = "CM1";
            this.cm1ToolStripMenuItem.Click += new System.EventHandler(this.MaintainanToolStripMenuItem_Click);
            // 
            // baslerToolStripMenuItem
            // 
            this.baslerToolStripMenuItem.Name = "baslerToolStripMenuItem";
            this.baslerToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.baslerToolStripMenuItem.Text = "Basler";
            this.baslerToolStripMenuItem.Click += new System.EventHandler(this.MaintainanToolStripMenuItem_Click);
            // 
            // autoRun_panel
            // 
            this.autoRun_panel.AutoScroll = true;
            this.autoRun_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoRun_panel.Location = new System.Drawing.Point(0, 26);
            this.autoRun_panel.Name = "autoRun_panel";
            this.autoRun_panel.Size = new System.Drawing.Size(921, 592);
            this.autoRun_panel.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 618);
            this.Controls.Add(this.autoRun_panel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wafer System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 監控ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EFEM_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DiameterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MorphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 報表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SystemSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 雷射ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 運動ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MaintainanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aCSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cognexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eFEMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cm1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baslerToolStripMenuItem;
        private System.Windows.Forms.Panel autoRun_panel;
    }
}

