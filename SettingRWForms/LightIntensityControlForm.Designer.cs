namespace CL3_IF_DllSample.SettingRWForms
{
    partial class LightIntensityControlForm
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
            this._labelLowerLimit = new System.Windows.Forms.Label();
            this._textBoxLowerLimit = new System.Windows.Forms.TextBox();
            this._labelUpperLimit = new System.Windows.Forms.Label();
            this._textBoxUpperLimit = new System.Windows.Forms.TextBox();
            this._labelMode = new System.Windows.Forms.Label();
            this._comboBoxMode = new System.Windows.Forms.ComboBox();
            this._buttonCancel = new System.Windows.Forms.Button();
            this._buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _labelLowerLimit
            // 
            this._labelLowerLimit.AutoSize = true;
            this._labelLowerLimit.Location = new System.Drawing.Point(19, 69);
            this._labelLowerLimit.Name = "_labelLowerLimit";
            this._labelLowerLimit.Size = new System.Drawing.Size(57, 12);
            this._labelLowerLimit.TabIndex = 4;
            this._labelLowerLimit.Text = "lowerLimit";
            // 
            // _textBoxLowerLimit
            // 
            this._textBoxLowerLimit.Location = new System.Drawing.Point(92, 66);
            this._textBoxLowerLimit.MaxLength = 3;
            this._textBoxLowerLimit.Name = "_textBoxLowerLimit";
            this._textBoxLowerLimit.Size = new System.Drawing.Size(75, 19);
            this._textBoxLowerLimit.TabIndex = 5;
            this._textBoxLowerLimit.Text = "1";
            // 
            // _labelUpperLimit
            // 
            this._labelUpperLimit.AutoSize = true;
            this._labelUpperLimit.Location = new System.Drawing.Point(19, 44);
            this._labelUpperLimit.Name = "_labelUpperLimit";
            this._labelUpperLimit.Size = new System.Drawing.Size(58, 12);
            this._labelUpperLimit.TabIndex = 2;
            this._labelUpperLimit.Text = "upperLimit";
            // 
            // _textBoxUpperLimit
            // 
            this._textBoxUpperLimit.Location = new System.Drawing.Point(92, 41);
            this._textBoxUpperLimit.MaxLength = 3;
            this._textBoxUpperLimit.Name = "_textBoxUpperLimit";
            this._textBoxUpperLimit.Size = new System.Drawing.Size(75, 19);
            this._textBoxUpperLimit.TabIndex = 3;
            this._textBoxUpperLimit.Text = "99";
            // 
            // _labelMode
            // 
            this._labelMode.AutoSize = true;
            this._labelMode.Location = new System.Drawing.Point(19, 18);
            this._labelMode.Name = "_labelMode";
            this._labelMode.Size = new System.Drawing.Size(32, 12);
            this._labelMode.TabIndex = 0;
            this._labelMode.Text = "mode";
            // 
            // _comboBoxMode
            // 
            this._comboBoxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxMode.FormattingEnabled = true;
            this._comboBoxMode.Items.AddRange(new object[] {
            "AUTO",
            "MANUAL"});
            this._comboBoxMode.Location = new System.Drawing.Point(92, 15);
            this._comboBoxMode.Name = "_comboBoxMode";
            this._comboBoxMode.Size = new System.Drawing.Size(76, 20);
            this._comboBoxMode.TabIndex = 1;
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(92, 106);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 7;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _buttonOk
            // 
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Location = new System.Drawing.Point(10, 106);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(75, 23);
            this._buttonOk.TabIndex = 6;
            this._buttonOk.Text = "OK";
            this._buttonOk.UseVisualStyleBackColor = true;
            // 
            // LightIntensityControlForm
            // 
            this.AcceptButton = this._buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(180, 141);
            this.Controls.Add(this._labelLowerLimit);
            this.Controls.Add(this._textBoxLowerLimit);
            this.Controls.Add(this._labelUpperLimit);
            this.Controls.Add(this._textBoxUpperLimit);
            this.Controls.Add(this._labelMode);
            this.Controls.Add(this._comboBoxMode);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LightIntensityControlForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _labelLowerLimit;
        private System.Windows.Forms.TextBox _textBoxLowerLimit;
        private System.Windows.Forms.Label _labelUpperLimit;
        private System.Windows.Forms.TextBox _textBoxUpperLimit;
        private System.Windows.Forms.Label _labelMode;
        private System.Windows.Forms.ComboBox _comboBoxMode;
        private System.Windows.Forms.Button _buttonCancel;
        private System.Windows.Forms.Button _buttonOk;
    }
}