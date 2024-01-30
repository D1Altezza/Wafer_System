namespace CL3_IF_DllSample.SettingRWForms
{
    partial class MeasurementPeaksForm
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
            this._labelPeaks = new System.Windows.Forms.Label();
            this._comboBoxPeaks = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(94, 50);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 3;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _buttonOk
            // 
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Location = new System.Drawing.Point(12, 50);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(75, 23);
            this._buttonOk.TabIndex = 2;
            this._buttonOk.Text = "OK";
            this._buttonOk.UseVisualStyleBackColor = true;
            // 
            // _labelPeaks
            // 
            this._labelPeaks.AutoSize = true;
            this._labelPeaks.Location = new System.Drawing.Point(12, 13);
            this._labelPeaks.Name = "_labelPeaks";
            this._labelPeaks.Size = new System.Drawing.Size(35, 12);
            this._labelPeaks.TabIndex = 0;
            this._labelPeaks.Text = "peaks";
            // 
            // _comboBoxPeaks
            // 
            this._comboBoxPeaks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxPeaks.FormattingEnabled = true;
            this._comboBoxPeaks.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this._comboBoxPeaks.Location = new System.Drawing.Point(73, 10);
            this._comboBoxPeaks.Name = "_comboBoxPeaks";
            this._comboBoxPeaks.Size = new System.Drawing.Size(76, 20);
            this._comboBoxPeaks.TabIndex = 1;
            // 
            // MeasurementPeaksForm
            // 
            this.AcceptButton = this._buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(183, 81);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.Controls.Add(this._labelPeaks);
            this.Controls.Add(this._comboBoxPeaks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MeasurementPeaksForm";
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
        private System.Windows.Forms.Label _labelPeaks;
        private System.Windows.Forms.ComboBox _comboBoxPeaks;
    }
}