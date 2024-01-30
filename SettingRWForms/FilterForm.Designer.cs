namespace CL3_IF_DllSample.SettingRWForms
{
    partial class FilterForm
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
            this._labelFilterMode = new System.Windows.Forms.Label();
            this._comboBoxFilterMode = new System.Windows.Forms.ComboBox();
            this._labelFilterParam = new System.Windows.Forms.Label();
            this._comboBoxFilterParam = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(128, 75);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 5;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _buttonOk
            // 
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Location = new System.Drawing.Point(18, 75);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(75, 23);
            this._buttonOk.TabIndex = 4;
            this._buttonOk.Text = "OK";
            this._buttonOk.UseVisualStyleBackColor = true;
            // 
            // _labelFilterMode
            // 
            this._labelFilterMode.AutoSize = true;
            this._labelFilterMode.Location = new System.Drawing.Point(12, 18);
            this._labelFilterMode.Name = "_labelFilterMode";
            this._labelFilterMode.Size = new System.Drawing.Size(56, 12);
            this._labelFilterMode.TabIndex = 0;
            this._labelFilterMode.Text = "filterMode";
            // 
            // _comboBoxFilterMode
            // 
            this._comboBoxFilterMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxFilterMode.FormattingEnabled = true;
            this._comboBoxFilterMode.Items.AddRange(new object[] {
            "MovingAverage",
            "Lowpass",
            "Highpass"});
            this._comboBoxFilterMode.Location = new System.Drawing.Point(102, 15);
            this._comboBoxFilterMode.Name = "_comboBoxFilterMode";
            this._comboBoxFilterMode.Size = new System.Drawing.Size(111, 20);
            this._comboBoxFilterMode.TabIndex = 1;
            this._comboBoxFilterMode.SelectedIndexChanged += new System.EventHandler(this._comboBoxMode_SelectedIndexChanged);
            // 
            // _labelFilterParam
            // 
            this._labelFilterParam.AutoSize = true;
            this._labelFilterParam.Location = new System.Drawing.Point(12, 44);
            this._labelFilterParam.Name = "_labelFilterParam";
            this._labelFilterParam.Size = new System.Drawing.Size(61, 12);
            this._labelFilterParam.TabIndex = 2;
            this._labelFilterParam.Text = "filterParam";
            // 
            // _comboBoxFilterParam
            // 
            this._comboBoxFilterParam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxFilterParam.FormattingEnabled = true;
            this._comboBoxFilterParam.Items.AddRange(new object[] {
            "1 times",
            "2 times",
            "4 times",
            "8 times",
            "16 times",
            "32 times",
            "64 times",
            "256 times",
            "1024 times",
            "4096 times",
            "16384 times",
            "65536 times",
            "262144 times"});
            this._comboBoxFilterParam.Location = new System.Drawing.Point(102, 41);
            this._comboBoxFilterParam.Name = "_comboBoxFilterParam";
            this._comboBoxFilterParam.Size = new System.Drawing.Size(111, 20);
            this._comboBoxFilterParam.TabIndex = 3;
            // 
            // FilterForm
            // 
            this.AcceptButton = this._buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(233, 110);
            this.Controls.Add(this._labelFilterParam);
            this.Controls.Add(this._comboBoxFilterParam);
            this.Controls.Add(this._labelFilterMode);
            this.Controls.Add(this._comboBoxFilterMode);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterForm";
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
        private System.Windows.Forms.Label _labelFilterMode;
        private System.Windows.Forms.ComboBox _comboBoxFilterMode;
        private System.Windows.Forms.Label _labelFilterParam;
        private System.Windows.Forms.ComboBox _comboBoxFilterParam;
    }
}