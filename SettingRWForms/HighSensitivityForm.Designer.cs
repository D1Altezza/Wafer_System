namespace CL3_IF_DllSample.SettingRWForms
{
    partial class HighSensitivityForm
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
            this._labelHighSensitivityOnOff = new System.Windows.Forms.Label();
            this._comboBoxHighSensitivityOnOff = new System.Windows.Forms.ComboBox();
            this._labelHighSensitivityStrength = new System.Windows.Forms.Label();
            this._textBoxHighSensitivityStrength = new System.Windows.Forms.TextBox();
            this._textBoxThresholdValueFractionalPoint = new System.Windows.Forms.TextBox();
            this._labelThresholdValueFractionalPoint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(144, 114);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 7;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _buttonOk
            // 
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Location = new System.Drawing.Point(62, 114);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(75, 23);
            this._buttonOk.TabIndex = 6;
            this._buttonOk.Text = "OK";
            this._buttonOk.UseVisualStyleBackColor = true;
            // 
            // _labelHighSensitivityOnOff
            // 
            this._labelHighSensitivityOnOff.AutoSize = true;
            this._labelHighSensitivityOnOff.Location = new System.Drawing.Point(12, 21);
            this._labelHighSensitivityOnOff.Name = "_labelHighSensitivityOnOff";
            this._labelHighSensitivityOnOff.Size = new System.Drawing.Size(110, 12);
            this._labelHighSensitivityOnOff.TabIndex = 0;
            this._labelHighSensitivityOnOff.Text = "highSensitivityOnOff";
            // 
            // _comboBoxHighSensitivityOnOff
            // 
            this._comboBoxHighSensitivityOnOff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxHighSensitivityOnOff.FormattingEnabled = true;
            this._comboBoxHighSensitivityOnOff.Items.AddRange(new object[] {
            "ON",
            "OFF"});
            this._comboBoxHighSensitivityOnOff.Location = new System.Drawing.Point(190, 17);
            this._comboBoxHighSensitivityOnOff.Name = "_comboBoxHighSensitivityOnOff";
            this._comboBoxHighSensitivityOnOff.Size = new System.Drawing.Size(76, 20);
            this._comboBoxHighSensitivityOnOff.TabIndex = 1;
            // 
            // _labelHighSensitivityStrength
            // 
            this._labelHighSensitivityStrength.AutoSize = true;
            this._labelHighSensitivityStrength.Location = new System.Drawing.Point(12, 52);
            this._labelHighSensitivityStrength.Name = "_labelHighSensitivityStrength";
            this._labelHighSensitivityStrength.Size = new System.Drawing.Size(123, 12);
            this._labelHighSensitivityStrength.TabIndex = 2;
            this._labelHighSensitivityStrength.Text = "highSensitivityStrength";
            // 
            // _textBoxHighSensitivityStrength
            // 
            this._textBoxHighSensitivityStrength.Location = new System.Drawing.Point(190, 49);
            this._textBoxHighSensitivityStrength.MaxLength = 1;
            this._textBoxHighSensitivityStrength.Name = "_textBoxHighSensitivityStrength";
            this._textBoxHighSensitivityStrength.Size = new System.Drawing.Size(76, 19);
            this._textBoxHighSensitivityStrength.TabIndex = 3;
            this._textBoxHighSensitivityStrength.Text = "0";
            // 
            // _textBoxThresholdValueFractionalPoint
            // 
            this._textBoxThresholdValueFractionalPoint.Location = new System.Drawing.Point(190, 80);
            this._textBoxThresholdValueFractionalPoint.MaxLength = 2;
            this._textBoxThresholdValueFractionalPoint.Name = "_textBoxThresholdValueFractionalPoint";
            this._textBoxThresholdValueFractionalPoint.Size = new System.Drawing.Size(76, 19);
            this._textBoxThresholdValueFractionalPoint.TabIndex = 5;
            this._textBoxThresholdValueFractionalPoint.Text = "0";
            // 
            // _labelThresholdValueFractionalPoint
            // 
            this._labelThresholdValueFractionalPoint.AutoSize = true;
            this._labelThresholdValueFractionalPoint.Location = new System.Drawing.Point(12, 83);
            this._labelThresholdValueFractionalPoint.Name = "_labelThresholdValueFractionalPoint";
            this._labelThresholdValueFractionalPoint.Size = new System.Drawing.Size(158, 12);
            this._labelThresholdValueFractionalPoint.TabIndex = 4;
            this._labelThresholdValueFractionalPoint.Text = "thresholdValueFractionalPoint";
            // 
            // HighSensitivityForm
            // 
            this.AcceptButton = this._buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(281, 144);
            this.Controls.Add(this._textBoxThresholdValueFractionalPoint);
            this.Controls.Add(this._labelThresholdValueFractionalPoint);
            this.Controls.Add(this._textBoxHighSensitivityStrength);
            this.Controls.Add(this._labelHighSensitivityStrength);
            this.Controls.Add(this._labelHighSensitivityOnOff);
            this.Controls.Add(this._comboBoxHighSensitivityOnOff);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HighSensitivityForm";
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
        private System.Windows.Forms.Label _labelHighSensitivityOnOff;
        private System.Windows.Forms.ComboBox _comboBoxHighSensitivityOnOff;
        private System.Windows.Forms.Label _labelHighSensitivityStrength;
        private System.Windows.Forms.TextBox _textBoxHighSensitivityStrength;
        private System.Windows.Forms.TextBox _textBoxThresholdValueFractionalPoint;
        private System.Windows.Forms.Label _labelThresholdValueFractionalPoint;
    }
}