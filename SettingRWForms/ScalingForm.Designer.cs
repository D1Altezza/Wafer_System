namespace CL3_IF_DllSample.SettingRWForms
{
    partial class ScalingForm
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
            this._textBoxOutputValue1 = new System.Windows.Forms.TextBox();
            this._labelOutputValue1 = new System.Windows.Forms.Label();
            this._textBoxInputValue1 = new System.Windows.Forms.TextBox();
            this._labelInputValue1 = new System.Windows.Forms.Label();
            this._textBoxOutputValue2 = new System.Windows.Forms.TextBox();
            this._labelOutputValue2 = new System.Windows.Forms.Label();
            this._textBoxInputValue2 = new System.Windows.Forms.TextBox();
            this._labelInputValue2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(94, 141);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 9;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _buttonOk
            // 
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Location = new System.Drawing.Point(12, 141);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(75, 23);
            this._buttonOk.TabIndex = 8;
            this._buttonOk.Text = "OK";
            this._buttonOk.UseVisualStyleBackColor = true;
            // 
            // _textBoxOutputValue1
            // 
            this._textBoxOutputValue1.Location = new System.Drawing.Point(94, 42);
            this._textBoxOutputValue1.MaxLength = 7;
            this._textBoxOutputValue1.Name = "_textBoxOutputValue1";
            this._textBoxOutputValue1.Size = new System.Drawing.Size(69, 19);
            this._textBoxOutputValue1.TabIndex = 3;
            this._textBoxOutputValue1.Text = "0";
            // 
            // _labelOutputValue1
            // 
            this._labelOutputValue1.AutoSize = true;
            this._labelOutputValue1.Location = new System.Drawing.Point(16, 45);
            this._labelOutputValue1.Name = "_labelOutputValue1";
            this._labelOutputValue1.Size = new System.Drawing.Size(72, 12);
            this._labelOutputValue1.TabIndex = 2;
            this._labelOutputValue1.Text = "outputValue1";
            // 
            // _textBoxInputValue1
            // 
            this._textBoxInputValue1.Location = new System.Drawing.Point(94, 12);
            this._textBoxInputValue1.MaxLength = 7;
            this._textBoxInputValue1.Name = "_textBoxInputValue1";
            this._textBoxInputValue1.Size = new System.Drawing.Size(69, 19);
            this._textBoxInputValue1.TabIndex = 1;
            this._textBoxInputValue1.Text = "0";
            // 
            // _labelInputValue1
            // 
            this._labelInputValue1.AutoSize = true;
            this._labelInputValue1.Location = new System.Drawing.Point(16, 15);
            this._labelInputValue1.Name = "_labelInputValue1";
            this._labelInputValue1.Size = new System.Drawing.Size(65, 12);
            this._labelInputValue1.TabIndex = 0;
            this._labelInputValue1.Text = "inputValue1";
            // 
            // _textBoxOutputValue2
            // 
            this._textBoxOutputValue2.Location = new System.Drawing.Point(94, 101);
            this._textBoxOutputValue2.MaxLength = 7;
            this._textBoxOutputValue2.Name = "_textBoxOutputValue2";
            this._textBoxOutputValue2.Size = new System.Drawing.Size(69, 19);
            this._textBoxOutputValue2.TabIndex = 7;
            this._textBoxOutputValue2.Text = "10000";
            // 
            // _labelOutputValue2
            // 
            this._labelOutputValue2.AutoSize = true;
            this._labelOutputValue2.Location = new System.Drawing.Point(16, 104);
            this._labelOutputValue2.Name = "_labelOutputValue2";
            this._labelOutputValue2.Size = new System.Drawing.Size(72, 12);
            this._labelOutputValue2.TabIndex = 6;
            this._labelOutputValue2.Text = "outputValue2";
            // 
            // _textBoxInputValue2
            // 
            this._textBoxInputValue2.Location = new System.Drawing.Point(94, 71);
            this._textBoxInputValue2.MaxLength = 7;
            this._textBoxInputValue2.Name = "_textBoxInputValue2";
            this._textBoxInputValue2.Size = new System.Drawing.Size(69, 19);
            this._textBoxInputValue2.TabIndex = 5;
            this._textBoxInputValue2.Text = "10000";
            // 
            // _labelInputValue2
            // 
            this._labelInputValue2.AutoSize = true;
            this._labelInputValue2.Location = new System.Drawing.Point(16, 74);
            this._labelInputValue2.Name = "_labelInputValue2";
            this._labelInputValue2.Size = new System.Drawing.Size(65, 12);
            this._labelInputValue2.TabIndex = 4;
            this._labelInputValue2.Text = "inputValue2";
            // 
            // ScalingForm
            // 
            this.AcceptButton = this._buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(184, 179);
            this.Controls.Add(this._textBoxOutputValue2);
            this.Controls.Add(this._labelOutputValue2);
            this.Controls.Add(this._textBoxInputValue2);
            this.Controls.Add(this._labelInputValue2);
            this.Controls.Add(this._textBoxOutputValue1);
            this.Controls.Add(this._labelOutputValue1);
            this.Controls.Add(this._textBoxInputValue1);
            this.Controls.Add(this._labelInputValue1);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScalingForm";
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
        private System.Windows.Forms.TextBox _textBoxOutputValue1;
        private System.Windows.Forms.Label _labelOutputValue1;
        private System.Windows.Forms.TextBox _textBoxInputValue1;
        private System.Windows.Forms.Label _labelInputValue1;
        private System.Windows.Forms.TextBox _textBoxOutputValue2;
        private System.Windows.Forms.Label _labelOutputValue2;
        private System.Windows.Forms.TextBox _textBoxInputValue2;
        private System.Windows.Forms.Label _labelInputValue2;
    }
}