namespace Cool_Muscle_CML_Example
{
    partial class CML
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
            this.button_OpenComm = new System.Windows.Forms.Button();
            this.textBox_PortNum = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Position = new System.Windows.Forms.TextBox();
            this.textBox_Speed = new System.Windows.Forms.TextBox();
            this.textBox_Acceleration = new System.Windows.Forms.TextBox();
            this.textBox_Torque = new System.Windows.Forms.TextBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_Clear = new System.Windows.Forms.Button();
            this.textBox_Received = new System.Windows.Forms.TextBox();
            this.btn_Up = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_Down = new System.Windows.Forms.Button();
            this.btn_Disable = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Emg = new System.Windows.Forms.Button();
            this.btn_Enable = new System.Windows.Forms.Button();
            this.btn_Origin = new System.Windows.Forms.Button();
            this.btn_GetPos = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_OpenComm
            // 
            this.button_OpenComm.Location = new System.Drawing.Point(200, 37);
            this.button_OpenComm.Name = "button_OpenComm";
            this.button_OpenComm.Size = new System.Drawing.Size(105, 44);
            this.button_OpenComm.TabIndex = 0;
            this.button_OpenComm.Text = "Open Comm";
            this.button_OpenComm.UseVisualStyleBackColor = true;
            this.button_OpenComm.Click += new System.EventHandler(this.button_OpenComm_Click);
            // 
            // textBox_PortNum
            // 
            this.textBox_PortNum.Location = new System.Drawing.Point(80, 51);
            this.textBox_PortNum.Name = "textBox_PortNum";
            this.textBox_PortNum.Size = new System.Drawing.Size(100, 22);
            this.textBox_PortNum.TabIndex = 1;
            this.textBox_PortNum.Text = "1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_PortNum);
            this.groupBox1.Controls.Add(this.button_OpenComm);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 95);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comm Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port #:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Position*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Speed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Acceleration";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "Torque (%)";
            // 
            // textBox_Position
            // 
            this.textBox_Position.Location = new System.Drawing.Point(80, 21);
            this.textBox_Position.Name = "textBox_Position";
            this.textBox_Position.Size = new System.Drawing.Size(100, 22);
            this.textBox_Position.TabIndex = 4;
            this.textBox_Position.Text = "5000";
            // 
            // textBox_Speed
            // 
            this.textBox_Speed.Location = new System.Drawing.Point(80, 58);
            this.textBox_Speed.Name = "textBox_Speed";
            this.textBox_Speed.Size = new System.Drawing.Size(100, 22);
            this.textBox_Speed.TabIndex = 4;
            this.textBox_Speed.Text = "100";
            // 
            // textBox_Acceleration
            // 
            this.textBox_Acceleration.Location = new System.Drawing.Point(80, 91);
            this.textBox_Acceleration.Name = "textBox_Acceleration";
            this.textBox_Acceleration.Size = new System.Drawing.Size(100, 22);
            this.textBox_Acceleration.TabIndex = 4;
            this.textBox_Acceleration.Text = "20";
            // 
            // textBox_Torque
            // 
            this.textBox_Torque.Location = new System.Drawing.Point(80, 132);
            this.textBox_Torque.Name = "textBox_Torque";
            this.textBox_Torque.Size = new System.Drawing.Size(100, 22);
            this.textBox_Torque.TabIndex = 4;
            this.textBox_Torque.Text = "100";
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(200, 24);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(105, 44);
            this.button_Start.TabIndex = 5;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(200, 98);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(105, 44);
            this.button_Stop.TabIndex = 5;
            this.button_Stop.Text = "Stop";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button_Stop);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.button_Start);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_Torque);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_Acceleration);
            this.groupBox2.Controls.Add(this.textBox_Position);
            this.groupBox2.Controls.Add(this.textBox_Speed);
            this.groupBox2.Location = new System.Drawing.Point(12, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(311, 181);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Send Data";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "* Please note position is absolute";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_Clear);
            this.groupBox3.Controls.Add(this.textBox_Received);
            this.groupBox3.Location = new System.Drawing.Point(601, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(194, 520);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Receive Data";
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(54, 478);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(89, 36);
            this.button_Clear.TabIndex = 1;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // textBox_Received
            // 
            this.textBox_Received.Location = new System.Drawing.Point(14, 20);
            this.textBox_Received.Multiline = true;
            this.textBox_Received.Name = "textBox_Received";
            this.textBox_Received.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Received.Size = new System.Drawing.Size(168, 439);
            this.textBox_Received.TabIndex = 0;
            // 
            // btn_Up
            // 
            this.btn_Up.Location = new System.Drawing.Point(14, 215);
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Size = new System.Drawing.Size(105, 44);
            this.btn_Up.TabIndex = 8;
            this.btn_Up.Text = "Up";
            this.btn_Up.UseVisualStyleBackColor = true;
            this.btn_Up.Click += new System.EventHandler(this.btn_Fun_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_Down);
            this.groupBox4.Controls.Add(this.btn_GetPos);
            this.groupBox4.Controls.Add(this.btn_Up);
            this.groupBox4.Controls.Add(this.btn_Disable);
            this.groupBox4.Controls.Add(this.btn_Reset);
            this.groupBox4.Controls.Add(this.btn_Emg);
            this.groupBox4.Controls.Add(this.btn_Enable);
            this.groupBox4.Controls.Add(this.btn_Origin);
            this.groupBox4.Location = new System.Drawing.Point(347, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(248, 448);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Function";
            // 
            // btn_Down
            // 
            this.btn_Down.Location = new System.Drawing.Point(125, 215);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(105, 44);
            this.btn_Down.TabIndex = 8;
            this.btn_Down.Text = "Down";
            this.btn_Down.UseVisualStyleBackColor = true;
            this.btn_Down.Click += new System.EventHandler(this.btn_Fun_Click);
            // 
            // btn_Disable
            // 
            this.btn_Disable.Location = new System.Drawing.Point(125, 30);
            this.btn_Disable.Name = "btn_Disable";
            this.btn_Disable.Size = new System.Drawing.Size(105, 44);
            this.btn_Disable.TabIndex = 8;
            this.btn_Disable.Text = "Disable";
            this.btn_Disable.UseVisualStyleBackColor = true;
            this.btn_Disable.Click += new System.EventHandler(this.btn_Fun_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(125, 80);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(105, 44);
            this.btn_Reset.TabIndex = 8;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Fun_Click);
            // 
            // btn_Emg
            // 
            this.btn_Emg.Location = new System.Drawing.Point(14, 79);
            this.btn_Emg.Name = "btn_Emg";
            this.btn_Emg.Size = new System.Drawing.Size(105, 44);
            this.btn_Emg.TabIndex = 8;
            this.btn_Emg.Text = "EMG";
            this.btn_Emg.UseVisualStyleBackColor = true;
            this.btn_Emg.Click += new System.EventHandler(this.btn_Fun_Click);
            // 
            // btn_Enable
            // 
            this.btn_Enable.Location = new System.Drawing.Point(14, 29);
            this.btn_Enable.Name = "btn_Enable";
            this.btn_Enable.Size = new System.Drawing.Size(105, 44);
            this.btn_Enable.TabIndex = 8;
            this.btn_Enable.Text = "Enable";
            this.btn_Enable.UseVisualStyleBackColor = true;
            this.btn_Enable.Click += new System.EventHandler(this.btn_Fun_Click);
            // 
            // btn_Origin
            // 
            this.btn_Origin.Location = new System.Drawing.Point(14, 141);
            this.btn_Origin.Name = "btn_Origin";
            this.btn_Origin.Size = new System.Drawing.Size(105, 44);
            this.btn_Origin.TabIndex = 8;
            this.btn_Origin.Text = "Origin";
            this.btn_Origin.UseVisualStyleBackColor = true;
            this.btn_Origin.Click += new System.EventHandler(this.btn_Fun_Click);
            // 
            // btn_GetPos
            // 
            this.btn_GetPos.Location = new System.Drawing.Point(14, 283);
            this.btn_GetPos.Name = "btn_GetPos";
            this.btn_GetPos.Size = new System.Drawing.Size(105, 44);
            this.btn_GetPos.TabIndex = 8;
            this.btn_GetPos.Text = "Get Pos";
            this.btn_GetPos.UseVisualStyleBackColor = true;
            this.btn_GetPos.Click += new System.EventHandler(this.btn_Fun_Click);
            // 
            // CML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 543);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CML";
            this.Text = "Cool Muscle CML Example";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_OpenComm;
        private System.Windows.Forms.TextBox textBox_PortNum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Position;
        private System.Windows.Forms.TextBox textBox_Speed;
        private System.Windows.Forms.TextBox textBox_Acceleration;
        private System.Windows.Forms.TextBox textBox_Torque;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.TextBox textBox_Received;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Up;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_Down;
        private System.Windows.Forms.Button btn_Origin;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Disable;
        private System.Windows.Forms.Button btn_Enable;
        private System.Windows.Forms.Button btn_Emg;
        private System.Windows.Forms.Button btn_GetPos;
    }
}

