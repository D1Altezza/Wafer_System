namespace Wafer_System
{
    partial class Auto_run_page1
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
            this.components = new System.ComponentModel.Container();
            this.btn_Go_Page2 = new System.Windows.Forms.Button();
            this.groupBox_WaferType = new System.Windows.Forms.GroupBox();
            this.radio_type_Glass = new System.Windows.Forms.RadioButton();
            this.radio_type_Si = new System.Windows.Forms.RadioButton();
            this.groupBox_WaferSize = new System.Windows.Forms.GroupBox();
            this.radio_size_12inch = new System.Windows.Forms.RadioButton();
            this.radio_size_8inch = new System.Windows.Forms.RadioButton();
            this.groupBox_WaferNotch = new System.Windows.Forms.GroupBox();
            this.radio_notch_non = new System.Windows.Forms.RadioButton();
            this.radio_notch_v = new System.Windows.Forms.RadioButton();
            this.groupBox_Classify = new System.Windows.Forms.GroupBox();
            this.combo_Classify = new System.Windows.Forms.ComboBox();
            this.groupBox_setup = new System.Windows.Forms.GroupBox();
            this.txt_cassette3_number = new System.Windows.Forms.TextBox();
            this.txt_cassette2_number = new System.Windows.Forms.TextBox();
            this.txt_cassette1_number = new System.Windows.Forms.TextBox();
            this.txt_file_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tmr_check = new System.Windows.Forms.Timer(this.components);
            this.groupBox_WaferType.SuspendLayout();
            this.groupBox_WaferSize.SuspendLayout();
            this.groupBox_WaferNotch.SuspendLayout();
            this.groupBox_Classify.SuspendLayout();
            this.groupBox_setup.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Go_Page2
            // 
            this.btn_Go_Page2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Go_Page2.Location = new System.Drawing.Point(890, 498);
            this.btn_Go_Page2.Name = "btn_Go_Page2";
            this.btn_Go_Page2.Size = new System.Drawing.Size(109, 70);
            this.btn_Go_Page2.TabIndex = 0;
            this.btn_Go_Page2.Text = "Dashboard";
            this.btn_Go_Page2.UseVisualStyleBackColor = true;
            this.btn_Go_Page2.Click += new System.EventHandler(this.btn_next_page_Click);
            // 
            // groupBox_WaferType
            // 
            this.groupBox_WaferType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox_WaferType.Controls.Add(this.radio_type_Glass);
            this.groupBox_WaferType.Controls.Add(this.radio_type_Si);
            this.groupBox_WaferType.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_WaferType.Location = new System.Drawing.Point(342, 14);
            this.groupBox_WaferType.Name = "groupBox_WaferType";
            this.groupBox_WaferType.Size = new System.Drawing.Size(318, 82);
            this.groupBox_WaferType.TabIndex = 1;
            this.groupBox_WaferType.TabStop = false;
            this.groupBox_WaferType.Text = "晶圓種類";
            // 
            // radio_type_Glass
            // 
            this.radio_type_Glass.AutoSize = true;
            this.radio_type_Glass.Location = new System.Drawing.Point(149, 34);
            this.radio_type_Glass.Name = "radio_type_Glass";
            this.radio_type_Glass.Size = new System.Drawing.Size(108, 26);
            this.radio_type_Glass.TabIndex = 0;
            this.radio_type_Glass.Text = "玻璃晶圓";
            this.radio_type_Glass.UseVisualStyleBackColor = true;
            // 
            // radio_type_Si
            // 
            this.radio_type_Si.AutoSize = true;
            this.radio_type_Si.Location = new System.Drawing.Point(6, 34);
            this.radio_type_Si.Name = "radio_type_Si";
            this.radio_type_Si.Size = new System.Drawing.Size(88, 26);
            this.radio_type_Si.TabIndex = 0;
            this.radio_type_Si.Text = "矽晶圓";
            this.radio_type_Si.UseVisualStyleBackColor = true;
            // 
            // groupBox_WaferSize
            // 
            this.groupBox_WaferSize.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox_WaferSize.Controls.Add(this.radio_size_12inch);
            this.groupBox_WaferSize.Controls.Add(this.radio_size_8inch);
            this.groupBox_WaferSize.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_WaferSize.Location = new System.Drawing.Point(342, 102);
            this.groupBox_WaferSize.Name = "groupBox_WaferSize";
            this.groupBox_WaferSize.Size = new System.Drawing.Size(318, 82);
            this.groupBox_WaferSize.TabIndex = 1;
            this.groupBox_WaferSize.TabStop = false;
            this.groupBox_WaferSize.Text = "晶圓尺寸";
            // 
            // radio_size_12inch
            // 
            this.radio_size_12inch.AutoSize = true;
            this.radio_size_12inch.Location = new System.Drawing.Point(149, 34);
            this.radio_size_12inch.Name = "radio_size_12inch";
            this.radio_size_12inch.Size = new System.Drawing.Size(68, 26);
            this.radio_size_12inch.TabIndex = 0;
            this.radio_size_12inch.Text = "12吋";
            this.radio_size_12inch.UseVisualStyleBackColor = true;
            // 
            // radio_size_8inch
            // 
            this.radio_size_8inch.AutoSize = true;
            this.radio_size_8inch.Location = new System.Drawing.Point(6, 34);
            this.radio_size_8inch.Name = "radio_size_8inch";
            this.radio_size_8inch.Size = new System.Drawing.Size(58, 26);
            this.radio_size_8inch.TabIndex = 0;
            this.radio_size_8inch.Text = "8吋";
            this.radio_size_8inch.UseVisualStyleBackColor = true;
            // 
            // groupBox_WaferNotch
            // 
            this.groupBox_WaferNotch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox_WaferNotch.Controls.Add(this.radio_notch_non);
            this.groupBox_WaferNotch.Controls.Add(this.radio_notch_v);
            this.groupBox_WaferNotch.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_WaferNotch.Location = new System.Drawing.Point(342, 190);
            this.groupBox_WaferNotch.Name = "groupBox_WaferNotch";
            this.groupBox_WaferNotch.Size = new System.Drawing.Size(318, 82);
            this.groupBox_WaferNotch.TabIndex = 1;
            this.groupBox_WaferNotch.TabStop = false;
            this.groupBox_WaferNotch.Text = "缺口形式";
            // 
            // radio_notch_non
            // 
            this.radio_notch_non.AutoSize = true;
            this.radio_notch_non.Location = new System.Drawing.Point(149, 34);
            this.radio_notch_non.Name = "radio_notch_non";
            this.radio_notch_non.Size = new System.Drawing.Size(68, 26);
            this.radio_notch_non.TabIndex = 0;
            this.radio_notch_non.Text = "平邊";
            this.radio_notch_non.UseVisualStyleBackColor = true;
            // 
            // radio_notch_v
            // 
            this.radio_notch_v.AutoSize = true;
            this.radio_notch_v.Location = new System.Drawing.Point(6, 34);
            this.radio_notch_v.Name = "radio_notch_v";
            this.radio_notch_v.Size = new System.Drawing.Size(58, 26);
            this.radio_notch_v.TabIndex = 0;
            this.radio_notch_v.Text = "V口";
            this.radio_notch_v.UseVisualStyleBackColor = true;
            // 
            // groupBox_Classify
            // 
            this.groupBox_Classify.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox_Classify.Controls.Add(this.combo_Classify);
            this.groupBox_Classify.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Classify.Location = new System.Drawing.Point(342, 278);
            this.groupBox_Classify.Name = "groupBox_Classify";
            this.groupBox_Classify.Size = new System.Drawing.Size(318, 82);
            this.groupBox_Classify.TabIndex = 1;
            this.groupBox_Classify.TabStop = false;
            this.groupBox_Classify.Text = "分級設定";
            // 
            // combo_Classify
            // 
            this.combo_Classify.FormattingEnabled = true;
            this.combo_Classify.Location = new System.Drawing.Point(10, 32);
            this.combo_Classify.Name = "combo_Classify";
            this.combo_Classify.Size = new System.Drawing.Size(282, 30);
            this.combo_Classify.TabIndex = 2;
            this.combo_Classify.DropDown += new System.EventHandler(this.combo_Classify_DropDown);
            // 
            // groupBox_setup
            // 
            this.groupBox_setup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox_setup.Controls.Add(this.txt_cassette3_number);
            this.groupBox_setup.Controls.Add(this.txt_cassette2_number);
            this.groupBox_setup.Controls.Add(this.txt_cassette1_number);
            this.groupBox_setup.Controls.Add(this.txt_file_name);
            this.groupBox_setup.Controls.Add(this.label4);
            this.groupBox_setup.Controls.Add(this.label3);
            this.groupBox_setup.Controls.Add(this.label2);
            this.groupBox_setup.Controls.Add(this.label1);
            this.groupBox_setup.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_setup.Location = new System.Drawing.Point(342, 366);
            this.groupBox_setup.Name = "groupBox_setup";
            this.groupBox_setup.Size = new System.Drawing.Size(318, 197);
            this.groupBox_setup.TabIndex = 1;
            this.groupBox_setup.TabStop = false;
            this.groupBox_setup.Text = "參數設定";
            // 
            // txt_cassette3_number
            // 
            this.txt_cassette3_number.Location = new System.Drawing.Point(114, 147);
            this.txt_cassette3_number.Name = "txt_cassette3_number";
            this.txt_cassette3_number.Size = new System.Drawing.Size(184, 30);
            this.txt_cassette3_number.TabIndex = 2;
            // 
            // txt_cassette2_number
            // 
            this.txt_cassette2_number.Location = new System.Drawing.Point(114, 108);
            this.txt_cassette2_number.Name = "txt_cassette2_number";
            this.txt_cassette2_number.Size = new System.Drawing.Size(184, 30);
            this.txt_cassette2_number.TabIndex = 2;
            // 
            // txt_cassette1_number
            // 
            this.txt_cassette1_number.Location = new System.Drawing.Point(114, 69);
            this.txt_cassette1_number.Name = "txt_cassette1_number";
            this.txt_cassette1_number.Size = new System.Drawing.Size(184, 30);
            this.txt_cassette1_number.TabIndex = 2;
            // 
            // txt_file_name
            // 
            this.txt_file_name.Location = new System.Drawing.Point(114, 30);
            this.txt_file_name.Name = "txt_file_name";
            this.txt_file_name.Size = new System.Drawing.Size(184, 30);
            this.txt_file_name.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 22);
            this.label4.TabIndex = 1;
            this.label4.Text = "卡匣3編號";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "卡匣2編號";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "卡匣1編號";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "檔名";
            // 
            // tmr_check
            // 
            this.tmr_check.Tick += new System.EventHandler(this.tmr_check_Tick);
            // 
            // Auto_run_page1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 570);
            this.Controls.Add(this.groupBox_Classify);
            this.Controls.Add(this.groupBox_setup);
            this.Controls.Add(this.groupBox_WaferNotch);
            this.Controls.Add(this.groupBox_WaferSize);
            this.Controls.Add(this.groupBox_WaferType);
            this.Controls.Add(this.btn_Go_Page2);
            this.Name = "Auto_run_page1";
            this.Text = "Auto_run_page1";
            this.VisibleChanged += new System.EventHandler(this.Auto_run_page1_VisibleChanged);
            this.groupBox_WaferType.ResumeLayout(false);
            this.groupBox_WaferType.PerformLayout();
            this.groupBox_WaferSize.ResumeLayout(false);
            this.groupBox_WaferSize.PerformLayout();
            this.groupBox_WaferNotch.ResumeLayout(false);
            this.groupBox_WaferNotch.PerformLayout();
            this.groupBox_Classify.ResumeLayout(false);
            this.groupBox_setup.ResumeLayout(false);
            this.groupBox_setup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Go_Page2;
        private System.Windows.Forms.GroupBox groupBox_WaferType;
        private System.Windows.Forms.RadioButton radio_type_Glass;
        private System.Windows.Forms.RadioButton radio_type_Si;
        private System.Windows.Forms.GroupBox groupBox_WaferSize;
        private System.Windows.Forms.RadioButton radio_size_12inch;
        private System.Windows.Forms.RadioButton radio_size_8inch;
        private System.Windows.Forms.GroupBox groupBox_WaferNotch;
        private System.Windows.Forms.RadioButton radio_notch_non;
        private System.Windows.Forms.RadioButton radio_notch_v;
        private System.Windows.Forms.GroupBox groupBox_Classify;
        private System.Windows.Forms.ComboBox combo_Classify;
        private System.Windows.Forms.GroupBox groupBox_setup;
        private System.Windows.Forms.TextBox txt_cassette3_number;
        private System.Windows.Forms.TextBox txt_cassette2_number;
        private System.Windows.Forms.TextBox txt_cassette1_number;
        private System.Windows.Forms.TextBox txt_file_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tmr_check;
    }
}