namespace CL3_IF_DllSample.SettingRWForms
{
    partial class MedianFilterForm
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
            this._labelMedianFilter = new System.Windows.Forms.Label();
            this._comboBoxMedianFilter = new System.Windows.Forms.ComboBox();
            this._buttonCancel = new System.Windows.Forms.Button();
            this._buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _labelMedianFilter
            // 
            this._labelMedianFilter.AutoSize = true;
            this._labelMedianFilter.Location = new System.Drawing.Point(19, 12);
            this._labelMedianFilter.Name = "_labelMedianFilter";
            this._labelMedianFilter.Size = new System.Drawing.Size(68, 12);
            this._labelMedianFilter.TabIndex = 0;
            this._labelMedianFilter.Text = "medianFilter";
            // 
            // _comboBoxMedianFilter
            // 
            this._comboBoxMedianFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxMedianFilter.FormattingEnabled = true;
            this._comboBoxMedianFilter.Items.AddRange(new object[] {
            "OFF",
            "7",
            "15",
            "31"});
            this._comboBoxMedianFilter.Location = new System.Drawing.Point(94, 9);
            this._comboBoxMedianFilter.Name = "_comboBoxMedianFilter";
            this._comboBoxMedianFilter.Size = new System.Drawing.Size(60, 20);
            this._comboBoxMedianFilter.TabIndex = 1;
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(94, 64);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 3;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _buttonOk
            // 
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Location = new System.Drawing.Point(12, 64);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(75, 23);
            this._buttonOk.TabIndex = 2;
            this._buttonOk.Text = "OK";
            this._buttonOk.UseVisualStyleBackColor = true;
            // 
            // MedianFilterForm
            // 
            this.AcceptButton = this._buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(183, 99);
            this.Controls.Add(this._labelMedianFilter);
            this.Controls.Add(this._comboBoxMedianFilter);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MedianFilterForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _labelMedianFilter;
        private System.Windows.Forms.ComboBox _comboBoxMedianFilter;
        private System.Windows.Forms.Button _buttonCancel;
        private System.Windows.Forms.Button _buttonOk;
    }
}