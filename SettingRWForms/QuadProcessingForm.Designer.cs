namespace CL3_IF_DllSample.SettingRWForms
{
    partial class QuadProcessingForm
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
            this._labelValidPoints = new System.Windows.Forms.Label();
            this._comboBoxValidPoints = new System.Windows.Forms.ComboBox();
            this._labelProcessing = new System.Windows.Forms.Label();
            this._comboBoxProcessing = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(122, 103);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 5;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _buttonOk
            // 
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Location = new System.Drawing.Point(25, 103);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(75, 23);
            this._buttonOk.TabIndex = 4;
            this._buttonOk.Text = "OK";
            this._buttonOk.UseVisualStyleBackColor = true;
            // 
            // _labelValidPoints
            // 
            this._labelValidPoints.AutoSize = true;
            this._labelValidPoints.Location = new System.Drawing.Point(12, 59);
            this._labelValidPoints.Name = "_labelValidPoints";
            this._labelValidPoints.Size = new System.Drawing.Size(81, 12);
            this._labelValidPoints.TabIndex = 2;
            this._labelValidPoints.Text = "quadValidPoint";
            // 
            // _comboBoxValidPoints
            // 
            this._comboBoxValidPoints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxValidPoints.FormattingEnabled = true;
            this._comboBoxValidPoints.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this._comboBoxValidPoints.Location = new System.Drawing.Point(110, 56);
            this._comboBoxValidPoints.Name = "_comboBoxValidPoints";
            this._comboBoxValidPoints.Size = new System.Drawing.Size(107, 20);
            this._comboBoxValidPoints.TabIndex = 3;
            // 
            // _labelProcessing
            // 
            this._labelProcessing.AutoSize = true;
            this._labelProcessing.Location = new System.Drawing.Point(12, 24);
            this._labelProcessing.Name = "_labelProcessing";
            this._labelProcessing.Size = new System.Drawing.Size(60, 12);
            this._labelProcessing.TabIndex = 0;
            this._labelProcessing.Text = "processing";
            // 
            // _comboBoxProcessing
            // 
            this._comboBoxProcessing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxProcessing.FormattingEnabled = true;
            this._comboBoxProcessing.Items.AddRange(new object[] {
            "Average",
            "Multiple"});
            this._comboBoxProcessing.Location = new System.Drawing.Point(110, 21);
            this._comboBoxProcessing.Name = "_comboBoxProcessing";
            this._comboBoxProcessing.Size = new System.Drawing.Size(107, 20);
            this._comboBoxProcessing.TabIndex = 1;
            // 
            // QuadProcessingForm
            // 
            this.AcceptButton = this._buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(229, 138);
            this.Controls.Add(this._labelValidPoints);
            this.Controls.Add(this._comboBoxValidPoints);
            this.Controls.Add(this._labelProcessing);
            this.Controls.Add(this._comboBoxProcessing);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuadProcessingForm";
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
        private System.Windows.Forms.Label _labelValidPoints;
        private System.Windows.Forms.ComboBox _comboBoxValidPoints;
        private System.Windows.Forms.Label _labelProcessing;
        private System.Windows.Forms.ComboBox _comboBoxProcessing;
    }
}