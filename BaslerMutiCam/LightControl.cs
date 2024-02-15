using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wafer_System.Config_Fun;
using Wafer_System.Log_Fun;

namespace Wafer_System.BaslerMutiCam
{
    public partial class LightControl : UserControl
    {
        private LogRW logRW;
        private ConfigWR configWR;
        delegate void setPointCallBack(string sReceived); // handle thread      
        public LightControl(LogRW logRW, ConfigWR configWR)
        {
            this.logRW = logRW;
            this.configWR = configWR;
            InitializeComponent();

        }
        public bool Connection(string Port)
        {
            try
            {
                serialPort.PortName = configWR.ReadSettings("Light_COM");
                serialPort.BaudRate = Convert.ToInt32(configWR.ReadSettings("Light_BaudRate"));
                serialPort.Parity = Parity.None;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;
                serialPort.Open();
               
                this.BeginInvoke(new Action(() => 
                {
                    LightValueLabel.Text = configWR.ReadSettings("Light_Value");
                    trackBar_Light.Value = Convert.ToInt32(configWR.ReadSettings("Light_Value"));
                }));
              
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ON()
        {
            try
            {
                serialPort.Write("CH1:" + configWR.ReadSettings("Light_Value") + "\r\n");
                trackBar_Light.Value = Convert.ToInt32(configWR.ReadSettings("Light_Value"));
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool OFF()
        {
            try
            {
                serialPort.Write("CH1:0\r\n");
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        private void trackBar_Light_Scroll(object sender, EventArgs e)
        {
            if (btn_ON.Enabled)
            {
                btn_ON.Enabled = false;
                btn_OFF.Enabled = true;
            }
            serialPort.Write("CH1:" + trackBar_Light.Value.ToString() + "\r\n");
        }
        private void trackBar_Light_ValueChanged(object sender, EventArgs e)
        {          
            LightValueLabel.Text = trackBar_Light.Value.ToString();
            configWR.WriteSettings("Light_Value", LightValueLabel.Text);
        }
        private void btn_ON_Click(object sender, EventArgs e)
        {
            ON();
            btn_OFF.Enabled = true;    
            btn_ON.Enabled = false;
        }

        private void btn_OFF_Click(object sender, EventArgs e)
        {
            OFF();
            btn_OFF.Enabled = false;
            btn_ON.Enabled = true;
        }
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //string recData;

            //recData = serialPort.ReadExisting();

            ////Handle cross threads
            //if (LightValueLabel.InvokeRequired)
            //{
            //    setPointCallBack d = new setPointCallBack(DisplayData);
            //    this.Invoke(d, new object[] { recData });
            //}
            //else LightValueLabel.Text = recData;
        }

        private void DisplayData(string sReceived)
        {
            LightValueLabel.Text += sReceived;
        }
        private void LightControl_Load(object sender, EventArgs e)
        {

        }

    
    }
}
