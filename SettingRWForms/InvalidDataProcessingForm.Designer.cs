namespace CL3_IF_DllSample.SettingRWForms
{
    partial class InvalidDataProcessingForm
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
            this._labelRecoveryNumber = new System.Windows.Forms.Label();
            this._textBoxRecoveryNumber = new System.Windows.Forms.TextBox();
            this._labelInvalidationNumber = new System.Windows.Forms.Label();
            this._textBoxInvalidationNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(109, 88);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 5;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _buttonOk
            // 
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Location = new System.Drawing.Point(27, 88);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(75, 23);
            this._buttonOk.TabIndex = 4;
            this._buttonOk.Text = "OK";
            this._buttonOk.UseVisualStyleBackColor = true;
            // 
            // _labelRecoveryNumber
            // 
            this._labelRecoveryNumber.AutoSize = true;
            this._labelRecoveryNumber.Location = new System.Drawing.Point(12, 51);
            this._labelRecoveryNumber.Name = "_labelRecoveryNumber";
            this._labelRecoveryNumber.Size = new System.Drawing.Size(88, 12);
            this._labelRecoveryNumber.TabIndex = 2;
            this._labelRecoveryNumber.Text = "recoveryNumber";
            // 
            // _textBoxRecoveryNumber
            // 
            this._textBoxRecoveryNumber.Location = new System.Drawing.Point(124, 48);
            this._textBoxRecoveryNumber.MaxLength = 4;
            this._textBoxRecoveryNumber.Name = "_textBoxRecoveryNumber";
            this._textBoxRecoveryNumber.Size = new System.Drawing.Size(75, 19);
            this._textBoxRecoveryNumber.TabIndex = 3;
            this._textBoxRecoveryNumber.Text = "0";
            // 
            // _labelInvalidationNumber
            // 
            this._labelInvalidationNumber.AutoSize = true;
            this._labelInvalidationNumber.Location = new System.Drawing.Point(12, 20);
            this._labelInvalidationNumber.Name = "_labelInvalidationNumber";
            this._labelInvalidationNumber.Size = new System.Drawing.Size(106, 12);
            this._labelInvalidationNumber.TabIndex = 0;
            this._labelInvalidationNumber.Text = "invalidationNumber ";
            // 
            // _textBoxInvalidationNumber
            // 
            this._textBoxInvalidationNumber.Location = new System.Drawing.Point(124, 17);
            this._textBoxInvalidationNumber.MaxLength = 4;
            this._textBoxInvalidationNumber.Name = "_textBoxInvalidationNumber";
            this._textBoxInvalidationNumber.Size = new System.Drawing.Size(75, 19);
            this._textBoxInvalidationNumber.TabIndex = 1;
            this._textBoxInvalidationNumber.Text = "8";
            // 
            // InvalidDataProcessingForm
            // 
            this.AcceptButton = this._buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(224, 126);
            this.Controls.Add(this._labelRecoveryNumber);
            this.Controls.Add(this._textBoxRecoveryNumber);
            this.Controls.Add(this._labelInvalidationNumber);
            this.Controls.Add(this._textBoxInvalidationNumber);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvalidDataProcessingForm";
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
        private System.Windows.Forms.Label _labelRecoveryNumber;
        private System.Windows.Forms.TextBox _textBoxRecoveryNumber;
        private System.Windows.Forms.Label _labelInvalidationNumber;
        private System.Windows.Forms.TextBox _textBoxInvalidationNumber;
    }
}