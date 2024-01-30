namespace Wafer_System.BaslerMutiCam
{
    partial class LightControl
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

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.trackBar_Light = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanelExposureTime = new System.Windows.Forms.TableLayoutPanel();
            this.LightValueLabel = new System.Windows.Forms.Label();
            this.exposureTimeLabel = new System.Windows.Forms.Label();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.btn_ON = new System.Windows.Forms.Button();
            this.btn_OFF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Light)).BeginInit();
            this.tableLayoutPanelExposureTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBar_Light
            // 
            this.trackBar_Light.Dock = System.Windows.Forms.DockStyle.Left;
            this.trackBar_Light.Location = new System.Drawing.Point(106, 0);
            this.trackBar_Light.Maximum = 255;
            this.trackBar_Light.Name = "trackBar_Light";
            this.trackBar_Light.Size = new System.Drawing.Size(363, 34);
            this.trackBar_Light.TabIndex = 0;
            this.trackBar_Light.Scroll += new System.EventHandler(this.trackBar_Light_Scroll);
            this.trackBar_Light.ValueChanged += new System.EventHandler(this.trackBar_Light_ValueChanged);
            // 
            // tableLayoutPanelExposureTime
            // 
            this.tableLayoutPanelExposureTime.ColumnCount = 1;
            this.tableLayoutPanelExposureTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelExposureTime.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelExposureTime.Controls.Add(this.LightValueLabel, 0, 1);
            this.tableLayoutPanelExposureTime.Controls.Add(this.exposureTimeLabel, 0, 0);
            this.tableLayoutPanelExposureTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanelExposureTime.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelExposureTime.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tableLayoutPanelExposureTime.Name = "tableLayoutPanelExposureTime";
            this.tableLayoutPanelExposureTime.RowCount = 2;
            this.tableLayoutPanelExposureTime.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelExposureTime.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelExposureTime.Size = new System.Drawing.Size(106, 34);
            this.tableLayoutPanelExposureTime.TabIndex = 19;
            // 
            // LightValueLabel
            // 
            this.LightValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LightValueLabel.AutoSize = true;
            this.LightValueLabel.Location = new System.Drawing.Point(3, 19);
            this.LightValueLabel.Name = "LightValueLabel";
            this.LightValueLabel.Size = new System.Drawing.Size(11, 12);
            this.LightValueLabel.TabIndex = 15;
            this.LightValueLabel.Text = "0";
            // 
            // exposureTimeLabel
            // 
            this.exposureTimeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.exposureTimeLabel.AutoSize = true;
            this.exposureTimeLabel.Location = new System.Drawing.Point(3, 2);
            this.exposureTimeLabel.Name = "exposureTimeLabel";
            this.exposureTimeLabel.Size = new System.Drawing.Size(30, 12);
            this.exposureTimeLabel.TabIndex = 15;
            this.exposureTimeLabel.Text = "Light";
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // btn_ON
            // 
            this.btn_ON.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_ON.Location = new System.Drawing.Point(469, 0);
            this.btn_ON.Name = "btn_ON";
            this.btn_ON.Size = new System.Drawing.Size(75, 34);
            this.btn_ON.TabIndex = 20;
            this.btn_ON.Text = "ON";
            this.btn_ON.UseVisualStyleBackColor = true;
            this.btn_ON.Click += new System.EventHandler(this.btn_ON_Click);
            // 
            // btn_OFF
            // 
            this.btn_OFF.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_OFF.Enabled = false;
            this.btn_OFF.Location = new System.Drawing.Point(544, 0);
            this.btn_OFF.Name = "btn_OFF";
            this.btn_OFF.Size = new System.Drawing.Size(75, 34);
            this.btn_OFF.TabIndex = 20;
            this.btn_OFF.Text = "OFF";
            this.btn_OFF.UseVisualStyleBackColor = true;
            this.btn_OFF.Click += new System.EventHandler(this.btn_OFF_Click);
            // 
            // LightControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_OFF);
            this.Controls.Add(this.btn_ON);
            this.Controls.Add(this.trackBar_Light);
            this.Controls.Add(this.tableLayoutPanelExposureTime);
            this.Name = "LightControl";
            this.Size = new System.Drawing.Size(621, 34);
            this.Load += new System.EventHandler(this.LightControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Light)).EndInit();
            this.tableLayoutPanelExposureTime.ResumeLayout(false);
            this.tableLayoutPanelExposureTime.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar_Light;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelExposureTime;
        private System.Windows.Forms.Label LightValueLabel;
        private System.Windows.Forms.Label exposureTimeLabel;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button btn_ON;
        private System.Windows.Forms.Button btn_OFF;
    }
}
