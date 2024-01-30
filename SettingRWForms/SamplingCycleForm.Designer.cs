namespace CL3_IF_DllSample.SettingRWForms
{
    partial class SamplingCycleForm
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
            this._labelSamplingCycle = new System.Windows.Forms.Label();
            this._comboBoxSamplingCycle = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
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
            // _labelSamplingCycle
            // 
            this._labelSamplingCycle.AutoSize = true;
            this._labelSamplingCycle.Location = new System.Drawing.Point(12, 21);
            this._labelSamplingCycle.Name = "_labelSamplingCycle";
            this._labelSamplingCycle.Size = new System.Drawing.Size(79, 12);
            this._labelSamplingCycle.TabIndex = 0;
            this._labelSamplingCycle.Text = "samplingCycle";
            // 
            // _comboBoxSamplingCycle
            // 
            this._comboBoxSamplingCycle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxSamplingCycle.FormattingEnabled = true;
            this._comboBoxSamplingCycle.Items.AddRange(new object[] {
            "100us",
            "200us",
            "500us",
            "1000us"});
            this._comboBoxSamplingCycle.Location = new System.Drawing.Point(98, 18);
            this._comboBoxSamplingCycle.Name = "_comboBoxSamplingCycle";
            this._comboBoxSamplingCycle.Size = new System.Drawing.Size(71, 20);
            this._comboBoxSamplingCycle.TabIndex = 1;
            // 
            // SamplingCycleForm
            // 
            this.AcceptButton = this._buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(180, 98);
            this.Controls.Add(this._comboBoxSamplingCycle);
            this.Controls.Add(this._labelSamplingCycle);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SamplingCycleForm";
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
        private System.Windows.Forms.Label _labelSamplingCycle;
        private System.Windows.Forms.ComboBox _comboBoxSamplingCycle;
    }
}