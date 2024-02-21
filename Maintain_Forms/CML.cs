using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using Wafer_System.Log_Fun;
using System.Threading;
using Wafer_System.Config_Fun;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace Cool_Muscle_CML_Example
{
    public partial class CML : Form
    {
        private LogRW logRW;
        private ConfigWR configWR;
        delegate void setPointCallBack(string sReceived); // handle thread 
        public SerialPort serialPort;
        public string recData;
        public CML(LogRW logRW, ConfigWR configWR)
        {
            InitializeComponent();
            this.logRW = logRW;
            this.configWR = configWR;

        }

        private void button_OpenComm_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            /* Run the motor using the dynamic move structure
             * Set P0, S0, A0 and M0. Then start the motor with the ^ command
             * We assume a single motor in this example so use the .1 ID
             * P, S, A and M are separated with a comma (,)
             * All instructions must be appended with a carriage return
             */

            String sSend;

            sSend = "P0.1=" + textBox_Position.Text +
                    ",S0.1=" + textBox_Speed.Text +
                    ",A0.1=" + textBox_Acceleration.Text +
                    ",M0.1=" + textBox_Torque.Text +
                    "\r";

            //write the registers data
            serialPort.Write(sSend);

            //start the motor
            serialPort.Write("^.1\r");

        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            /* Stop the motor with the ] command. 
             * We assume a single motor in this example so use the .1 ID
             * All commands must be appended with a carriage return
             */

            serialPort.Write("].1\r");
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            //clear the received textbox
            textBox_Received.Text = "";
        }

        public void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var sp = serialPort.ReadExisting().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (sp.Count()>1)
            {
                recData = sp[1];
                
            }
           

            //Handle cross threads
            if (textBox_Received.InvokeRequired)
            {
                setPointCallBack d = new setPointCallBack(DisplayData);
                this.BeginInvoke(d, new object[] { recData });
                //this.Invoke(d, new object[] { recData });
            }
            else textBox_Received.Text += recData + "\r\n";
        }

        private void DisplayData(string sReceived)
        {
            textBox_Received.Text += sReceived;
        }
        private void btn_Fun_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            switch (b.Name)
            {
                case "btn_Up":
                    pin_Up();
                    break;
                case "btn_Down":
                    pin_Down();
                    break;
                case "btn_Origin":
                    Origin();
                    break;
                case "btn_Reset":
                    Reset();
                    break;
                case "btn_Enable":
                    MotorEnable();
                    break;
                case "btn_Disable":
                    MotorDisable();
                    break;
                case "btn_Emg":
                    Emg();
                    break;
                case "btn_GetPos":
                    Query("?96");
                    break;
            }
        }
        #region Fun
        public bool Connect()
        {
            try
            {
                if (serialPort != null)
                {
                    serialPort.Dispose();
                }
                serialPort = new SerialPort();
                serialPort.DataReceived += serialPort_DataReceived;
                serialPort.PortName = configWR.ReadSettings("CML_COM");
                serialPort.BaudRate = Convert.ToInt32(configWR.ReadSettings("CML_BaudRate"));
                serialPort.Parity = Parity.None;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;
                serialPort.RtsEnable = true;
                serialPort.Open();
                if (serialPort.IsOpen)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                //MessageBox.Show("Communication port did not open. Please check settings.");
                return false;
            }
        }
        public void pin_Up()
        {
            serialPort.Write("[1.1\r\n");
        }
        public void pin_Down()
        {
            serialPort.Write("[2.1\r\n");
        }
        public void Origin()
        {
            serialPort.Write("|.0\r\n");
        }
        /// <summary>
        /// ?99 motor status----->
        /// 0:Motor running
        /// 1:Position error overflow
        /// 2:Over regen voltage limit
        /// 4:Over load/current
        /// 8:Inposition Signal
        /// 16: Disabled
        /// 32: pushmode torque limit reached (K60)
        /// 128:over termperature limit (K71)
        /// 256:pushmode timout not reached (K61)
        /// 512:emergency stop (*)-----       
        /// ?96 :Current Position
        /// </summary>
        /// <param name="query"></param>
        ///
        public void Query(string query)
        {
            serialPort.Write(query + "\r\n");
        }
        public void Reset()
        {
            try
            {
                serialPort.Write("*1\r\n");
            }
            catch (Exception)
            {

            }
        }
        public void MotorEnable()
        {
            serialPort.Write("(.1\r\n");
        }
        public void MotorDisable()
        {
            serialPort.Write(").1\r\n");
        }
        public void Emg()
        {
            serialPort.Write("*\r\n");
        }
        #endregion

        #region Close
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown
                || e.CloseReason == CloseReason.ApplicationExitCall
                || e.CloseReason == CloseReason.TaskManagerClosing)
            {
                return;
            }
            e.Cancel = true;
            this.Hide();
        }

        public void CMLClose()
        {
            serialPort.Close();
        }
        #endregion


    }
}
