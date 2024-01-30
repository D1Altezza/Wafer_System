namespace CL3_IF_DllSample.SettingRWForms
{
    partial class ToleranceForm
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
            this._textBoxHysteresis = new System.Windows.Forms.TextBox();
            this._labelHysteresis = new System.Windows.Forms.Label();
            this._textBoxLowerLimit = new System.Windows.Forms.TextBox();
            this._labelLowerLimit = new System.Windows.Forms.Label();
            this._textBoxUpperLimit = new System.Windows.Forms.TextBox();
            this._labelUpperLimit = new System.Windows.Forms.Label();
            this._buttonCancel = new System.Windows.Forms.Button();
            this._buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _textBoxHysteresis
            // 
            this._textBoxHysteresis.Location = new System.Drawing.Point(90, 77);
            this._textBoxHysteresis.MaxLength = 7;
            this._textBoxHysteresis.Name = "_textBoxHysteresis";
            this._textBoxHysteresis.Size = new System.Drawing.Size(69, 19);
            this._textBoxHysteresis.TabIndex = 5;
            this._textBoxHysteresis.Text = "0";
            // 
            // _labelHysteresis
            // 
            this._labelHysteresis.AutoSize = true;
            this._labelHysteresis.Location = new System.Drawing.Point(12, 80);
            this._labelHysteresis.Name = "_labelHysteresis";
            this._labelHysteresis.Size = new System.Drawing.Size(58, 12);
            this._labelHysteresis.TabIndex = 4;
            this._labelHysteresis.Text = "hysteresis";
            // 
            // _textBoxLowerLimit
            // 
            this._textBoxLowerLimit.Location = new System.Drawing.Point(90, 47);
            this._textBoxLowerLimit.MaxLength = 7;
            this._textBoxLowerLimit.Name = "_textBoxLowerLimit";
            this._textBoxLowerLimit.Size = new System.Drawing.Size(69, 19);
            this._textBoxLowerLimit.TabIndex = 3;
            this._textBoxLowerLimit.Text = "-50000";
            // 
            // _labelLowerLimit
            // 
            this._labelLowerLimit.AutoSize = true;
            this._labelLowerLimit.Location = new System.Drawing.Point(12, 50);
            this._labelLowerLimit.Name = "_labelLowerLimit";
            this._labelLowerLimit.Size = new System.Drawing.Size(57, 12);
            this._labelLowerLimit.TabIndex = 2;
            this._labelLowerLimit.Text = "lowerLimit";
            // 
            // _textBoxUpperLimit
            // 
            this._textBoxUpperLimit.Location = new System.Drawing.Point(90, 18);
            this._textBoxUpperLimit.MaxLength = 7;
            this._textBoxUpperLimit.Name = "_textBoxUpperLimit";
            this._textBoxUpperLimit.Size = new System.Drawing.Size(69, 19);
            this._textBoxUpperLimit.TabIndex = 1;
            this._textBoxUpperLimit.Text = "50000";
            // 
            // _labelUpperLimit
            // 
            this._labelUpperLimit.AutoSize = true;
            this._labelUpperLimit.Location = new System.Drawing.Point(12, 21);
            this._labelUpperLimit.Name = "_labelUpperLimit";
            this._labelUpperLimit.Size = new System.Drawing.Size(58, 12);
            this._labelUpperLimit.TabIndex = 0;
            this._labelUpperLimit.Text = "upperLimit";
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(90, 117);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 7;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _buttonOk
            // 
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Location = new System.Drawing.Point(8, 117);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(75, 23);
            this._buttonOk.TabIndex = 6;
            this._buttonOk.Text = "OK";
            this._buttonOk.UseVisualStyleBackColor = true;
            // 
            // ToleranceForm
            // 
            this.AcceptButton = this._buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(173, 151);
            this.Controls.Add(this._textBoxHysteresis);
            this.Controls.Add(this._labelHysteresis);
            this.Controls.Add(this._textBoxLowerLimit);
            this.Controls.Add(this._labelLowerLimit);
            this.Controls.Add(this._textBoxUpperLimit);
            this.Controls.Add(this._labelUpperLimit);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ToleranceForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _textBoxHysteresis;
        private System.Windows.Forms.Label _labelHysteresis;
        private System.Windows.Forms.TextBox _textBoxLowerLimit;
        private System.Windows.Forms.Label _labelLowerLimit;
        private System.Windows.Forms.TextBox _textBoxUpperLimit;
        private System.Windows.Forms.Label _labelUpperLimit;
        private System.Windows.Forms.Button _buttonCancel;
        private System.Windows.Forms.Button _buttonOk;
    }
}