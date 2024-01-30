namespace CL3_IF_DllSample.SettingRWForms
{
    partial class AmbientLightFilterForm
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
            this._comboBoxOnOff = new System.Windows.Forms.ComboBox();
            this._labelOnOff = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(94, 67);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 3;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _buttonOk
            // 
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Location = new System.Drawing.Point(12, 67);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(75, 23);
            this._buttonOk.TabIndex = 2;
            this._buttonOk.Text = "OK";
            this._buttonOk.UseVisualStyleBackColor = true;
            // 
            // _comboBoxOnOff
            // 
            this._comboBoxOnOff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxOnOff.FormattingEnabled = true;
            this._comboBoxOnOff.Items.AddRange(new object[] {
            "ON",
            "OFF"});
            this._comboBoxOnOff.Location = new System.Drawing.Point(59, 12);
            this._comboBoxOnOff.Name = "_comboBoxOnOff";
            this._comboBoxOnOff.Size = new System.Drawing.Size(60, 20);
            this._comboBoxOnOff.TabIndex = 1;
            // 
            // _labelOnOff
            // 
            this._labelOnOff.AutoSize = true;
            this._labelOnOff.Location = new System.Drawing.Point(17, 15);
            this._labelOnOff.Name = "_labelOnOff";
            this._labelOnOff.Size = new System.Drawing.Size(33, 12);
            this._labelOnOff.TabIndex = 0;
            this._labelOnOff.Text = "onOff";
            // 
            // AmbientLightFilterForm
            // 
            this.AcceptButton = this._buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(182, 100);
            this.Controls.Add(this._labelOnOff);
            this.Controls.Add(this._comboBoxOnOff);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AmbientLightFilterForm";
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
        private System.Windows.Forms.ComboBox _comboBoxOnOff;
        private System.Windows.Forms.Label _labelOnOff;
    }
}