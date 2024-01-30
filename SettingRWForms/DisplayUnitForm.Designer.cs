namespace CL3_IF_DllSample.SettingRWForms
{
    partial class DisplayUnitForm
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
            this._labelDisplayUnit = new System.Windows.Forms.Label();
            this._comboBoxDisplayUnit = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(123, 53);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 3;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _buttonOk
            // 
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Location = new System.Drawing.Point(12, 53);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(75, 23);
            this._buttonOk.TabIndex = 2;
            this._buttonOk.Text = "OK";
            this._buttonOk.UseVisualStyleBackColor = true;
            // 
            // _labelDisplayUnit
            // 
            this._labelDisplayUnit.AutoSize = true;
            this._labelDisplayUnit.Location = new System.Drawing.Point(12, 18);
            this._labelDisplayUnit.Name = "_labelDisplayUnit";
            this._labelDisplayUnit.Size = new System.Drawing.Size(62, 12);
            this._labelDisplayUnit.TabIndex = 0;
            this._labelDisplayUnit.Text = "displayUnit";
            // 
            // _comboBoxDisplayUnit
            // 
            this._comboBoxDisplayUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxDisplayUnit.FormattingEnabled = true;
            this._comboBoxDisplayUnit.Items.AddRange(new object[] {
            "0.01mm",
            "0.001mm",
            "0.0001mm",
            "0.00001mm",
            "0.1um",
            "0.01um",
            "0.001um"});
            this._comboBoxDisplayUnit.Location = new System.Drawing.Point(83, 15);
            this._comboBoxDisplayUnit.Name = "_comboBoxDisplayUnit";
            this._comboBoxDisplayUnit.Size = new System.Drawing.Size(115, 20);
            this._comboBoxDisplayUnit.TabIndex = 1;
            // 
            // DisplayUnitForm
            // 
            this.AcceptButton = this._buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(210, 92);
            this.Controls.Add(this._labelDisplayUnit);
            this.Controls.Add(this._comboBoxDisplayUnit);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DisplayUnitForm";
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
        private System.Windows.Forms.Label _labelDisplayUnit;
        private System.Windows.Forms.ComboBox _comboBoxDisplayUnit;
    }
}