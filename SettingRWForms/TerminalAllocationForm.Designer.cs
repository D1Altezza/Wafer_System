namespace CL3_IF_DllSample.SettingRWForms
{
    partial class TerminalAllocationForm
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
            this._labelTimingReset = new System.Windows.Forms.Label();
            this._comboBoxTimingReset = new System.Windows.Forms.ComboBox();
            this._labelZero = new System.Windows.Forms.Label();
            this._comboBoxZero = new System.Windows.Forms.ComboBox();
            this._buttonCancel = new System.Windows.Forms.Button();
            this._buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _labelTimingReset
            // 
            this._labelTimingReset.AutoSize = true;
            this._labelTimingReset.Location = new System.Drawing.Point(12, 16);
            this._labelTimingReset.Name = "_labelTimingReset";
            this._labelTimingReset.Size = new System.Drawing.Size(66, 12);
            this._labelTimingReset.TabIndex = 0;
            this._labelTimingReset.Text = "timingReset";
            // 
            // _comboBoxTimingReset
            // 
            this._comboBoxTimingReset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxTimingReset.FormattingEnabled = true;
            this._comboBoxTimingReset.Items.AddRange(new object[] {
            "None",
            "TimingReset1",
            "TimingReset2"});
            this._comboBoxTimingReset.Location = new System.Drawing.Point(86, 13);
            this._comboBoxTimingReset.Name = "_comboBoxTimingReset";
            this._comboBoxTimingReset.Size = new System.Drawing.Size(105, 20);
            this._comboBoxTimingReset.TabIndex = 1;
            // 
            // _labelZero
            // 
            this._labelZero.AutoSize = true;
            this._labelZero.Location = new System.Drawing.Point(12, 51);
            this._labelZero.Name = "_labelZero";
            this._labelZero.Size = new System.Drawing.Size(26, 12);
            this._labelZero.TabIndex = 2;
            this._labelZero.Text = "zero";
            // 
            // _comboBoxZero
            // 
            this._comboBoxZero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxZero.FormattingEnabled = true;
            this._comboBoxZero.Items.AddRange(new object[] {
            "None",
            "Zero1",
            "Zero2"});
            this._comboBoxZero.Location = new System.Drawing.Point(86, 48);
            this._comboBoxZero.Name = "_comboBoxZero";
            this._comboBoxZero.Size = new System.Drawing.Size(60, 20);
            this._comboBoxZero.TabIndex = 3;
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(101, 84);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 5;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _buttonOk
            // 
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Location = new System.Drawing.Point(19, 84);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(75, 23);
            this._buttonOk.TabIndex = 4;
            this._buttonOk.Text = "OK";
            this._buttonOk.UseVisualStyleBackColor = true;
            // 
            // TerminalAllocationForm
            // 
            this.AcceptButton = this._buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(205, 119);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.Controls.Add(this._labelZero);
            this.Controls.Add(this._comboBoxZero);
            this.Controls.Add(this._labelTimingReset);
            this.Controls.Add(this._comboBoxTimingReset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TerminalAllocationForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _labelTimingReset;
        private System.Windows.Forms.ComboBox _comboBoxTimingReset;
        private System.Windows.Forms.Label _labelZero;
        private System.Windows.Forms.ComboBox _comboBoxZero;
        private System.Windows.Forms.Button _buttonCancel;
        private System.Windows.Forms.Button _buttonOk;
    }
}