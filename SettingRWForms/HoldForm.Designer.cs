namespace CL3_IF_DllSample.SettingRWForms
{
    partial class HoldForm
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
            this._labelHoldMode = new System.Windows.Forms.Label();
            this._comboBoxHoldMode = new System.Windows.Forms.ComboBox();
            this._labelUpdateCondition = new System.Windows.Forms.Label();
            this._comboBoxUpdateCondition = new System.Windows.Forms.ComboBox();
            this._labelNumberOfSamplings = new System.Windows.Forms.Label();
            this._textBoxNumberOfSamplings = new System.Windows.Forms.TextBox();
            this._buttonCancel = new System.Windows.Forms.Button();
            this._buttonOk = new System.Windows.Forms.Button();
            this._labelHysteresis = new System.Windows.Forms.Label();
            this._textBoxHysteresis = new System.Windows.Forms.TextBox();
            this._labelLevel = new System.Windows.Forms.Label();
            this._textBoxLevel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _labelHoldMode
            // 
            this._labelHoldMode.AutoSize = true;
            this._labelHoldMode.Location = new System.Drawing.Point(12, 20);
            this._labelHoldMode.Name = "_labelHoldMode";
            this._labelHoldMode.Size = new System.Drawing.Size(53, 12);
            this._labelHoldMode.TabIndex = 0;
            this._labelHoldMode.Text = "holdMode";
            // 
            // _comboBoxHoldMode
            // 
            this._comboBoxHoldMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxHoldMode.FormattingEnabled = true;
            this._comboBoxHoldMode.Items.AddRange(new object[] {
            "Normal",
            "Peak",
            "Bottom",
            "PeakToPeak",
            "Sample",
            "Average",
            "AutoPeak",
            "AutoBottom"});
            this._comboBoxHoldMode.Location = new System.Drawing.Point(102, 17);
            this._comboBoxHoldMode.Name = "_comboBoxHoldMode";
            this._comboBoxHoldMode.Size = new System.Drawing.Size(107, 20);
            this._comboBoxHoldMode.TabIndex = 1;
            // 
            // _labelUpdateCondition
            // 
            this._labelUpdateCondition.AutoSize = true;
            this._labelUpdateCondition.Location = new System.Drawing.Point(12, 55);
            this._labelUpdateCondition.Name = "_labelUpdateCondition";
            this._labelUpdateCondition.Size = new System.Drawing.Size(87, 12);
            this._labelUpdateCondition.TabIndex = 2;
            this._labelUpdateCondition.Text = "updateCondition";
            // 
            // _comboBoxUpdateCondition
            // 
            this._comboBoxUpdateCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxUpdateCondition.FormattingEnabled = true;
            this._comboBoxUpdateCondition.Items.AddRange(new object[] {
            "EXTERNAL1",
            "EXTERNAL2",
            "INTERNAL"});
            this._comboBoxUpdateCondition.Location = new System.Drawing.Point(102, 52);
            this._comboBoxUpdateCondition.Name = "_comboBoxUpdateCondition";
            this._comboBoxUpdateCondition.Size = new System.Drawing.Size(107, 20);
            this._comboBoxUpdateCondition.TabIndex = 3;
            // 
            // _labelNumberOfSamplings
            // 
            this._labelNumberOfSamplings.AutoSize = true;
            this._labelNumberOfSamplings.Location = new System.Drawing.Point(12, 96);
            this._labelNumberOfSamplings.Name = "_labelNumberOfSamplings";
            this._labelNumberOfSamplings.Size = new System.Drawing.Size(106, 12);
            this._labelNumberOfSamplings.TabIndex = 4;
            this._labelNumberOfSamplings.Text = "numberOfSamplings";
            // 
            // _textBoxNumberOfSamplings
            // 
            this._textBoxNumberOfSamplings.Location = new System.Drawing.Point(134, 93);
            this._textBoxNumberOfSamplings.MaxLength = 5;
            this._textBoxNumberOfSamplings.Name = "_textBoxNumberOfSamplings";
            this._textBoxNumberOfSamplings.Size = new System.Drawing.Size(75, 19);
            this._textBoxNumberOfSamplings.TabIndex = 5;
            this._textBoxNumberOfSamplings.Text = "100";
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(116, 189);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 11;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _buttonOk
            // 
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Location = new System.Drawing.Point(34, 189);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(75, 23);
            this._buttonOk.TabIndex = 10;
            this._buttonOk.Text = "OK";
            this._buttonOk.UseVisualStyleBackColor = true;
            // 
            // _labelHysteresis
            // 
            this._labelHysteresis.AutoSize = true;
            this._labelHysteresis.Location = new System.Drawing.Point(12, 163);
            this._labelHysteresis.Name = "_labelHysteresis";
            this._labelHysteresis.Size = new System.Drawing.Size(58, 12);
            this._labelHysteresis.TabIndex = 8;
            this._labelHysteresis.Text = "hysteresis";
            // 
            // _textBoxHysteresis
            // 
            this._textBoxHysteresis.Location = new System.Drawing.Point(134, 160);
            this._textBoxHysteresis.MaxLength = 10;
            this._textBoxHysteresis.Name = "_textBoxHysteresis";
            this._textBoxHysteresis.Size = new System.Drawing.Size(75, 19);
            this._textBoxHysteresis.TabIndex = 9;
            this._textBoxHysteresis.Text = "0";
            // 
            // _labelLevel
            // 
            this._labelLevel.AutoSize = true;
            this._labelLevel.Location = new System.Drawing.Point(12, 132);
            this._labelLevel.Name = "_labelLevel";
            this._labelLevel.Size = new System.Drawing.Size(29, 12);
            this._labelLevel.TabIndex = 6;
            this._labelLevel.Text = "level";
            // 
            // _textBoxLevel
            // 
            this._textBoxLevel.Location = new System.Drawing.Point(134, 129);
            this._textBoxLevel.MaxLength = 10;
            this._textBoxLevel.Name = "_textBoxLevel";
            this._textBoxLevel.Size = new System.Drawing.Size(75, 19);
            this._textBoxLevel.TabIndex = 7;
            this._textBoxLevel.Text = "0";
            // 
            // HoldForm
            // 
            this.AcceptButton = this._buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(221, 224);
            this.Controls.Add(this._labelHysteresis);
            this.Controls.Add(this._textBoxHysteresis);
            this.Controls.Add(this._labelLevel);
            this.Controls.Add(this._textBoxLevel);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.Controls.Add(this._labelNumberOfSamplings);
            this.Controls.Add(this._textBoxNumberOfSamplings);
            this.Controls.Add(this._labelUpdateCondition);
            this.Controls.Add(this._comboBoxUpdateCondition);
            this.Controls.Add(this._labelHoldMode);
            this.Controls.Add(this._comboBoxHoldMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HoldForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _labelHoldMode;
        private System.Windows.Forms.ComboBox _comboBoxHoldMode;
        private System.Windows.Forms.Label _labelUpdateCondition;
        private System.Windows.Forms.ComboBox _comboBoxUpdateCondition;
        private System.Windows.Forms.Label _labelNumberOfSamplings;
        private System.Windows.Forms.TextBox _textBoxNumberOfSamplings;
        private System.Windows.Forms.Button _buttonCancel;
        private System.Windows.Forms.Button _buttonOk;
        private System.Windows.Forms.Label _labelHysteresis;
        private System.Windows.Forms.TextBox _textBoxHysteresis;
        private System.Windows.Forms.Label _labelLevel;
        private System.Windows.Forms.TextBox _textBoxLevel;
    }
}