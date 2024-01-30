namespace CL3_IF_DllSample.SettingRWForms
{
    partial class LightIntensityIntegrationForm
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
            this._labelIntegrationNumber = new System.Windows.Forms.Label();
            this._comboBoxIntegrationNumber = new System.Windows.Forms.ComboBox();
            this._buttonCancel = new System.Windows.Forms.Button();
            this._buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _labelIntegrationNumber
            // 
            this._labelIntegrationNumber.AutoSize = true;
            this._labelIntegrationNumber.Location = new System.Drawing.Point(10, 15);
            this._labelIntegrationNumber.Name = "_labelIntegrationNumber";
            this._labelIntegrationNumber.Size = new System.Drawing.Size(98, 12);
            this._labelIntegrationNumber.TabIndex = 0;
            this._labelIntegrationNumber.Text = "integrationNumber";
            // 
            // _comboBoxIntegrationNumber
            // 
            this._comboBoxIntegrationNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxIntegrationNumber.FormattingEnabled = true;
            this._comboBoxIntegrationNumber.Items.AddRange(new object[] {
            "OFF",
            "4",
            "16",
            "64",
            "256"});
            this._comboBoxIntegrationNumber.Location = new System.Drawing.Point(114, 12);
            this._comboBoxIntegrationNumber.Name = "_comboBoxIntegrationNumber";
            this._comboBoxIntegrationNumber.Size = new System.Drawing.Size(76, 20);
            this._comboBoxIntegrationNumber.TabIndex = 1;
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(115, 52);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 3;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _buttonOk
            // 
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Location = new System.Drawing.Point(12, 52);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(75, 23);
            this._buttonOk.TabIndex = 2;
            this._buttonOk.Text = "OK";
            this._buttonOk.UseVisualStyleBackColor = true;
            // 
            // LightIntensityIntegrationForm
            // 
            this.AcceptButton = this._buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(202, 88);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.Controls.Add(this._labelIntegrationNumber);
            this.Controls.Add(this._comboBoxIntegrationNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LightIntensityIntegrationForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _labelIntegrationNumber;
        private System.Windows.Forms.ComboBox _comboBoxIntegrationNumber;
        private System.Windows.Forms.Button _buttonCancel;
        private System.Windows.Forms.Button _buttonOk;
    }
}