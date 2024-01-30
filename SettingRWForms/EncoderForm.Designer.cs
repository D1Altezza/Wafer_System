namespace CL3_IF_DllSample.SettingRWForms
{
    partial class EncoderForm
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
            this._buttonCancel = new System.Windows.Forms.Button();
            this._buttonOk = new System.Windows.Forms.Button();
            this._labelEncoderOnOff = new System.Windows.Forms.Label();
            this._comboBoxEncoderOnOff = new System.Windows.Forms.ComboBox();
            this._labelOperatingMode = new System.Windows.Forms.Label();
            this._comboBoxOperatingMode = new System.Windows.Forms.ComboBox();
            this._comboBoxEnterMode = new System.Windows.Forms.ComboBox();
            this._labelEnterMode = new System.Windows.Forms.Label();
            this._textBoxDecimationPoint = new System.Windows.Forms.TextBox();
            this._labelDecimationPoint = new System.Windows.Forms.Label();
            this._labelDetectionEdge = new System.Windows.Forms.Label();
            this._comboBoxDetectionEdge = new System.Windows.Forms.ComboBox();
            this._labelMinInputTime = new System.Windows.Forms.Label();
            this._comboBoxMinInputTime = new System.Windows.Forms.ComboBox();
            this._labelPulseCountOffsetDetectionLogic = new System.Windows.Forms.Label();
            this._comboBoxPulseCountOffsetDetectionLogic = new System.Windows.Forms.ComboBox();
            this._labelPresetValue = new System.Windows.Forms.Label();
            this._textBoxPresetValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(182, 282);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 17;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _buttonOk
            // 
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Location = new System.Drawing.Point(98, 282);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(75, 23);
            this._buttonOk.TabIndex = 16;
            this._buttonOk.Text = "OK";
            this._buttonOk.UseVisualStyleBackColor = true;
            // 
            // _labelEncoderOnOff
            // 
            this._labelEncoderOnOff.AutoSize = true;
            this._labelEncoderOnOff.Location = new System.Drawing.Point(18, 15);
            this._labelEncoderOnOff.Name = "_labelEncoderOnOff";
            this._labelEncoderOnOff.Size = new System.Drawing.Size(75, 12);
            this._labelEncoderOnOff.TabIndex = 0;
            this._labelEncoderOnOff.Text = "encoderOnOff";
            // 
            // _comboBoxEncoderOnOff
            // 
            this._comboBoxEncoderOnOff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxEncoderOnOff.FormattingEnabled = true;
            this._comboBoxEncoderOnOff.Items.AddRange(new object[] {
            "ON",
            "OFF"});
            this._comboBoxEncoderOnOff.Location = new System.Drawing.Point(207, 11);
            this._comboBoxEncoderOnOff.Name = "_comboBoxEncoderOnOff";
            this._comboBoxEncoderOnOff.Size = new System.Drawing.Size(131, 20);
            this._comboBoxEncoderOnOff.TabIndex = 1;
            // 
            // _labelOperatingMode
            // 
            this._labelOperatingMode.AutoSize = true;
            this._labelOperatingMode.Location = new System.Drawing.Point(18, 49);
            this._labelOperatingMode.Name = "_labelOperatingMode";
            this._labelOperatingMode.Size = new System.Drawing.Size(79, 12);
            this._labelOperatingMode.TabIndex = 2;
            this._labelOperatingMode.Text = "operatingMode";
            // 
            // _comboBoxOperatingMode
            // 
            this._comboBoxOperatingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxOperatingMode.FormattingEnabled = true;
            this._comboBoxOperatingMode.Items.AddRange(new object[] {
            "OFF",
            "TIMING",
            "TRIGGER"});
            this._comboBoxOperatingMode.Location = new System.Drawing.Point(207, 45);
            this._comboBoxOperatingMode.Name = "_comboBoxOperatingMode";
            this._comboBoxOperatingMode.Size = new System.Drawing.Size(131, 20);
            this._comboBoxOperatingMode.TabIndex = 3;
            // 
            // _comboBoxEnterMode
            // 
            this._comboBoxEnterMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxEnterMode.FormattingEnabled = true;
            this._comboBoxEnterMode.Items.AddRange(new object[] {
            "1-phase 1 multiplier",
            "2-phase 1 multiplier",
            "2-phase 2 multiplier",
            "2-phase 4 multiplier"});
            this._comboBoxEnterMode.Location = new System.Drawing.Point(207, 79);
            this._comboBoxEnterMode.Name = "_comboBoxEnterMode";
            this._comboBoxEnterMode.Size = new System.Drawing.Size(131, 20);
            this._comboBoxEnterMode.TabIndex = 5;
            // 
            // _labelEnterMode
            // 
            this._labelEnterMode.AutoSize = true;
            this._labelEnterMode.Location = new System.Drawing.Point(18, 83);
            this._labelEnterMode.Name = "_labelEnterMode";
            this._labelEnterMode.Size = new System.Drawing.Size(58, 12);
            this._labelEnterMode.TabIndex = 4;
            this._labelEnterMode.Text = "enterMode";
            // 
            // _textBoxDecimationPoint
            // 
            this._textBoxDecimationPoint.Location = new System.Drawing.Point(207, 114);
            this._textBoxDecimationPoint.MaxLength = 4;
            this._textBoxDecimationPoint.Name = "_textBoxDecimationPoint";
            this._textBoxDecimationPoint.Size = new System.Drawing.Size(131, 19);
            this._textBoxDecimationPoint.TabIndex = 7;
            this._textBoxDecimationPoint.Text = "1";
            // 
            // _labelDecimationPoint
            // 
            this._labelDecimationPoint.AutoSize = true;
            this._labelDecimationPoint.Location = new System.Drawing.Point(18, 117);
            this._labelDecimationPoint.Name = "_labelDecimationPoint";
            this._labelDecimationPoint.Size = new System.Drawing.Size(86, 12);
            this._labelDecimationPoint.TabIndex = 6;
            this._labelDecimationPoint.Text = "decimationPoint";
            // 
            // _labelDetectionEdge
            // 
            this._labelDetectionEdge.AutoSize = true;
            this._labelDetectionEdge.Location = new System.Drawing.Point(18, 151);
            this._labelDetectionEdge.Name = "_labelDetectionEdge";
            this._labelDetectionEdge.Size = new System.Drawing.Size(77, 12);
            this._labelDetectionEdge.TabIndex = 8;
            this._labelDetectionEdge.Text = "detectionEdge";
            // 
            // _comboBoxDetectionEdge
            // 
            this._comboBoxDetectionEdge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxDetectionEdge.FormattingEnabled = true;
            this._comboBoxDetectionEdge.Items.AddRange(new object[] {
            "Rising",
            "Falling",
            "Both Edge"});
            this._comboBoxDetectionEdge.Location = new System.Drawing.Point(207, 147);
            this._comboBoxDetectionEdge.Name = "_comboBoxDetectionEdge";
            this._comboBoxDetectionEdge.Size = new System.Drawing.Size(131, 20);
            this._comboBoxDetectionEdge.TabIndex = 9;
            // 
            // _labelMinInputTime
            // 
            this._labelMinInputTime.AutoSize = true;
            this._labelMinInputTime.Location = new System.Drawing.Point(18, 185);
            this._labelMinInputTime.Name = "_labelMinInputTime";
            this._labelMinInputTime.Size = new System.Drawing.Size(73, 12);
            this._labelMinInputTime.TabIndex = 10;
            this._labelMinInputTime.Text = "minInputTime";
            // 
            // _comboBoxMinInputTime
            // 
            this._comboBoxMinInputTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxMinInputTime.FormattingEnabled = true;
            this._comboBoxMinInputTime.Items.AddRange(new object[] {
            "100ns",
            "200ns",
            "500ns",
            "1us",
            "2us",
            "5us",
            "10us",
            "20us"});
            this._comboBoxMinInputTime.Location = new System.Drawing.Point(207, 181);
            this._comboBoxMinInputTime.Name = "_comboBoxMinInputTime";
            this._comboBoxMinInputTime.Size = new System.Drawing.Size(131, 20);
            this._comboBoxMinInputTime.TabIndex = 11;
            // 
            // _labelPulseCountOffsetDetectionLogic
            // 
            this._labelPulseCountOffsetDetectionLogic.AutoSize = true;
            this._labelPulseCountOffsetDetectionLogic.Location = new System.Drawing.Point(18, 219);
            this._labelPulseCountOffsetDetectionLogic.Name = "_labelPulseCountOffsetDetectionLogic";
            this._labelPulseCountOffsetDetectionLogic.Size = new System.Drawing.Size(170, 12);
            this._labelPulseCountOffsetDetectionLogic.TabIndex = 12;
            this._labelPulseCountOffsetDetectionLogic.Text = "pulseCountOffsetDetectionLogic";
            // 
            // _comboBoxPulseCountOffsetDetectionLogic
            // 
            this._comboBoxPulseCountOffsetDetectionLogic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxPulseCountOffsetDetectionLogic.FormattingEnabled = true;
            this._comboBoxPulseCountOffsetDetectionLogic.Items.AddRange(new object[] {
            "OFF",
            "Positive",
            "Negative"});
            this._comboBoxPulseCountOffsetDetectionLogic.Location = new System.Drawing.Point(207, 215);
            this._comboBoxPulseCountOffsetDetectionLogic.Name = "_comboBoxPulseCountOffsetDetectionLogic";
            this._comboBoxPulseCountOffsetDetectionLogic.Size = new System.Drawing.Size(131, 20);
            this._comboBoxPulseCountOffsetDetectionLogic.TabIndex = 13;
            // 
            // _labelPresetValue
            // 
            this._labelPresetValue.AutoSize = true;
            this._labelPresetValue.Location = new System.Drawing.Point(18, 253);
            this._labelPresetValue.Name = "_labelPresetValue";
            this._labelPresetValue.Size = new System.Drawing.Size(66, 12);
            this._labelPresetValue.TabIndex = 14;
            this._labelPresetValue.Text = "presetValue";
            // 
            // _textBoxPresetValue
            // 
            this._textBoxPresetValue.Location = new System.Drawing.Point(207, 250);
            this._textBoxPresetValue.MaxLength = 11;
            this._textBoxPresetValue.Name = "_textBoxPresetValue";
            this._textBoxPresetValue.Size = new System.Drawing.Size(131, 19);
            this._textBoxPresetValue.TabIndex = 15;
            this._textBoxPresetValue.Text = "0";
            // 
            // EncoderForm
            // 
            this.AcceptButton = this._buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(347, 312);
            this.Controls.Add(this._textBoxPresetValue);
            this.Controls.Add(this._labelPresetValue);
            this.Controls.Add(this._comboBoxPulseCountOffsetDetectionLogic);
            this.Controls.Add(this._labelPulseCountOffsetDetectionLogic);
            this.Controls.Add(this._comboBoxMinInputTime);
            this.Controls.Add(this._labelMinInputTime);
            this.Controls.Add(this._comboBoxDetectionEdge);
            this.Controls.Add(this._labelDetectionEdge);
            this.Controls.Add(this._labelDecimationPoint);
            this.Controls.Add(this._textBoxDecimationPoint);
            this.Controls.Add(this._labelEnterMode);
            this.Controls.Add(this._comboBoxEnterMode);
            this.Controls.Add(this._comboBoxOperatingMode);
            this.Controls.Add(this._labelOperatingMode);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.Controls.Add(this._labelEncoderOnOff);
            this.Controls.Add(this._comboBoxEncoderOnOff);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EncoderForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _buttonCancel;
        private System.Windows.Forms.Button _buttonOk;
        private System.Windows.Forms.Label _labelEncoderOnOff;
        private System.Windows.Forms.ComboBox _comboBoxEncoderOnOff;
        private System.Windows.Forms.Label _labelOperatingMode;
        private System.Windows.Forms.ComboBox _comboBoxOperatingMode;
        private System.Windows.Forms.ComboBox _comboBoxEnterMode;
        private System.Windows.Forms.Label _labelEnterMode;
        private System.Windows.Forms.TextBox _textBoxDecimationPoint;
        private System.Windows.Forms.Label _labelDecimationPoint;
        private System.Windows.Forms.Label _labelDetectionEdge;
        private System.Windows.Forms.ComboBox _comboBoxDetectionEdge;
        private System.Windows.Forms.Label _labelMinInputTime;
        private System.Windows.Forms.ComboBox _comboBoxMinInputTime;
        private System.Windows.Forms.Label _labelPulseCountOffsetDetectionLogic;
        private System.Windows.Forms.ComboBox _comboBoxPulseCountOffsetDetectionLogic;
        private System.Windows.Forms.Label _labelPresetValue;
        private System.Windows.Forms.TextBox _textBoxPresetValue;
    }
}