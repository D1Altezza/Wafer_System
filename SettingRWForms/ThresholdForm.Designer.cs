namespace CL3_IF_DllSample.SettingRWForms
{
    partial class ThresholdForm
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
            this._labelMode = new System.Windows.Forms.Label();
            this._comboBoxMode = new System.Windows.Forms.ComboBox();
            this._labelValue = new System.Windows.Forms.Label();
            this._textBoxValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(94, 94);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 5;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _buttonOk
            // 
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Location = new System.Drawing.Point(12, 94);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(75, 23);
            this._buttonOk.TabIndex = 4;
            this._buttonOk.Text = "OK";
            this._buttonOk.UseVisualStyleBackColor = true;
            // 
            // _labelMode
            // 
            this._labelMode.AutoSize = true;
            this._labelMode.Location = new System.Drawing.Point(12, 20);
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
            this._comboBoxMode.Location = new System.Drawing.Point(68, 17);
            this._comboBoxMode.Name = "_comboBoxMode";
            this._comboBoxMode.Size = new System.Drawing.Size(76, 20);
            this._comboBoxMode.TabIndex = 1;
            // 
            // _labelValue
            // 
            this._labelValue.AutoSize = true;
            this._labelValue.Location = new System.Drawing.Point(12, 60);
            this._labelValue.Name = "_labelValue";
            this._labelValue.Size = new System.Drawing.Size(32, 12);
            this._labelValue.TabIndex = 2;
            this._labelValue.Text = "value";
            // 
            // _textBoxValue
            // 
            this._textBoxValue.Location = new System.Drawing.Point(68, 57);
            this._textBoxValue.MaxLength = 3;
            this._textBoxValue.Name = "_textBoxValue";
            this._textBoxValue.Size = new System.Drawing.Size(76, 19);
            this._textBoxValue.TabIndex = 3;
            this._textBoxValue.Text = "50";
            // 
            // ThresholdForm
            // 
            this.AcceptButton = this._buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(185, 134);
            this.Controls.Add(this._textBoxValue);
            this.Controls.Add(this._labelValue);
            this.Controls.Add(this._labelMode);
            this.Controls.Add(this._comboBoxMode);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThresholdForm";
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
        private System.Windows.Forms.Label _labelMode;
        private System.Windows.Forms.ComboBox _comboBoxMode;
        private System.Windows.Forms.Label _labelValue;
        private System.Windows.Forms.TextBox _textBoxValue;
    }
}