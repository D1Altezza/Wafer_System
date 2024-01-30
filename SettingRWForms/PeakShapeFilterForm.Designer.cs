namespace CL3_IF_DllSample.SettingRWForms
{
    partial class PeakShapeFilterForm
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
            this._labelValue = new System.Windows.Forms.Label();
            this._comboBoxOnOff = new System.Windows.Forms.ComboBox();
            this._labelIntensity = new System.Windows.Forms.Label();
            this._comboBoxIntensity = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(94, 95);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 5;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _buttonOk
            // 
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Location = new System.Drawing.Point(12, 95);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(75, 23);
            this._buttonOk.TabIndex = 4;
            this._buttonOk.Text = "OK";
            this._buttonOk.UseVisualStyleBackColor = true;
            // 
            // _labelValue
            // 
            this._labelValue.AutoSize = true;
            this._labelValue.Location = new System.Drawing.Point(12, 15);
            this._labelValue.Name = "_labelValue";
            this._labelValue.Size = new System.Drawing.Size(33, 12);
            this._labelValue.TabIndex = 0;
            this._labelValue.Text = "onOff";
            // 
            // _comboBoxOnOff
            // 
            this._comboBoxOnOff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxOnOff.FormattingEnabled = true;
            this._comboBoxOnOff.Items.AddRange(new object[] {
            "ON",
            "OFF"});
            this._comboBoxOnOff.Location = new System.Drawing.Point(80, 12);
            this._comboBoxOnOff.Name = "_comboBoxOnOff";
            this._comboBoxOnOff.Size = new System.Drawing.Size(60, 20);
            this._comboBoxOnOff.TabIndex = 1;
            // 
            // _labelIntensity
            // 
            this._labelIntensity.AutoSize = true;
            this._labelIntensity.Location = new System.Drawing.Point(12, 53);
            this._labelIntensity.Name = "_labelIntensity";
            this._labelIntensity.Size = new System.Drawing.Size(49, 12);
            this._labelIntensity.TabIndex = 2;
            this._labelIntensity.Text = "intensity";
            // 
            // _comboBoxIntensity
            // 
            this._comboBoxIntensity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxIntensity.FormattingEnabled = true;
            this._comboBoxIntensity.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this._comboBoxIntensity.Location = new System.Drawing.Point(80, 50);
            this._comboBoxIntensity.Name = "_comboBoxIntensity";
            this._comboBoxIntensity.Size = new System.Drawing.Size(60, 20);
            this._comboBoxIntensity.TabIndex = 3;
            // 
            // PeakShapeFilterForm
            // 
            this.AcceptButton = this._buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(181, 129);
            this.Controls.Add(this._comboBoxIntensity);
            this.Controls.Add(this._labelIntensity);
            this.Controls.Add(this._labelValue);
            this.Controls.Add(this._comboBoxOnOff);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PeakShapeFilterForm";
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
        private System.Windows.Forms.Label _labelValue;
        private System.Windows.Forms.ComboBox _comboBoxOnOff;
        private System.Windows.Forms.Label _labelIntensity;
        private System.Windows.Forms.ComboBox _comboBoxIntensity;
    }
}