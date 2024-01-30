using ACS_DotNET_Library_Advanced_Demo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wafer_System.BaslerMutiCam;
using Wafer_System.Config_Fun;
using Wafer_System.Log_Fun;

namespace Wafer_System
{
    public partial class Diameter_Monitor : Form
    {
        MutiCam mutiCam;
        private LogRW logRW;
        private ConfigWR configWR;
        private ACS_Motion aCS_Motion;
        private EFEM eFEM;
        private Cognex cognex;

        public Diameter_Monitor(LogRW logRW, ConfigWR configWR, ACS_Motion aCS_Motion, EFEM eFEM, MutiCam mutiCam,Cognex cognex)
        {
            this.logRW = logRW;
            this.configWR = configWR;
            this.aCS_Motion = aCS_Motion;
            this.eFEM = eFEM;
            this.cognex = cognex;
            this.mutiCam = mutiCam;
            InitializeComponent();
            //cognex.client.Events.DataReceived += Events_DataReceived;
        }

        public void Events_DataReceived(object sender, SuperSimpleTcp.DataReceivedEventArgs e)
        {
            //throw new NotImplementedException();
            this.BeginInvoke(new Action(() =>
            {
                label1.Text = cognex.data;
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = mutiCam.Cam1_OneShot();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cognex.ReadData(1);
            
        }
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

        public void DiameterMonitorClose()
        {
         
        }
        #endregion

       
    }
}
