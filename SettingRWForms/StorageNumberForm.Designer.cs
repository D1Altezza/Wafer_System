namespace CL3_IF_DllSample.SettingRWForms
{
    partial class StorageNumberForm
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
            this._labelOverwrite = new System.Windows.Forms.Label();
            this._comboBoxOverwrite = new System.Windows.Forms.ComboBox();
            this._buttonCancel = new System.Windows.Forms.Button();
            this._buttonOk = new System.Windows.Forms.Button();
            this._textBoxStorageNumber = new System.Windows.Forms.TextBox();
            this._labelStorageNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _labelOverwrite
            // 
            this._labelOverwrite.AutoSize = true;
            this._labelOverwrite.Location = new System.Drawing.Point(12, 22);
            this._labelOverwrite.Name = "_labelOverwrite";
            this._labelOverwrite.Size = new System.Drawing.Size(52, 12);
            this._labelOverwrite.TabIndex = 0;
            this._labelOverwrite.Text = "overwrite";
            // 
            // _comboBoxOverwrite
            // 
            this._comboBoxOverwrite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxOverwrite.FormattingEnabled = true;
            this._comboBoxOverwrite.Items.AddRange(new object[] {
            "None",
            "Overwrite"});
            this._comboBoxOverwrite.Location = new System.Drawing.Point(102, 19);
            this._comboBoxOverwrite.Name = "_comboBoxOverwrite";
            this._comboBoxOverwrite.Size = new System.Drawing.Size(81, 20);
            this._comboBoxOverwrite.TabIndex = 1;
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(102, 85);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 5;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _buttonOk
            // 
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Location = new System.Drawing.Point(20, 85);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(75, 23);
            this._buttonOk.TabIndex = 4;
            this._buttonOk.Text = "OK";
            this._buttonOk.UseVisualStyleBackColor = true;
            // 
            // _textBoxStorageNumber
            // 
            this._textBoxStorageNumber.Location = new System.Drawing.Point(102, 52);
            this._textBoxStorageNumber.MaxLength = 7;
            this._textBoxStorageNumber.Name = "_textBoxStorageNumber";
            this._textBoxStorageNumber.Size = new System.Drawing.Size(69, 19);
            this._textBoxStorageNumber.TabIndex = 3;
            this._textBoxStorageNumber.Text = "100000";
            // 
            // _labelStorageNumber
            // 
            this._labelStorageNumber.AutoSize = true;
            this._labelStorageNumber.Location = new System.Drawing.Point(12, 55);
            this._labelStorageNumber.Name = "_labelStorageNumber";
            this._labelStorageNumber.Size = new System.Drawing.Size(82, 12);
            this._labelStorageNumber.TabIndex = 2;
            this._labelStorageNumber.Text = "storageNumber";
            // 
            // StorageNumberForm
            // 
            this.AcceptButton = this._buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(195, 120);
            this.Controls.Add(this._textBoxStorageNumber);
            this.Controls.Add(this._labelStorageNumber);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOk);
            this.Controls.Add(this._labelOverwrite);
            this.Controls.Add(this._comboBoxOverwrite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StorageNumberForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _labelOverwrite;
        private System.Windows.Forms.ComboBox _comboBoxOverwrite;
        private System.Windows.Forms.Button _buttonCancel;
        private System.Windows.Forms.Button _buttonOk;
        private System.Windows.Forms.TextBox _textBoxStorageNumber;
        private System.Windows.Forms.Label _labelStorageNumber;
    }
}