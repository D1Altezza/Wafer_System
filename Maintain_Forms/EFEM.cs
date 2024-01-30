using CL3_IF_DllSample;
using SuperSimpleTcp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wafer_System.Config_Fun;
using Wafer_System.Log_Fun;

namespace Wafer_System
{
    public partial class EFEM : Form
    {

        public SimpleTcpClient client;
        public string EFEM_Cmd = "";
        string StartChar = "#", EndChar = "$";
        LogRW logRW;
        private ConfigWR configWR;
        public EFEM_Paser _Paser;

        public EFEM(LogRW logRW, ConfigWR configWR)
        {
            InitializeComponent();
            this.logRW = logRW;
            this.configWR = configWR;
        }

        private void EFEM_Load(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(configWR.ReadSettings("EFEM_IP")) && !string.IsNullOrEmpty(configWR.ReadSettings("EFEM_Port")))
            //{
            //    client = new SimpleTcpClient(configWR.ReadSettings("EFEM_IP") + ":" + configWR.ReadSettings("EFEM_Port"));
            //    client.Events.Connected += Events_Connected;
            //    client.Events.DataReceived += Events_DataReceived;
            //    client.Events.Disconnected += Events_Disconnected;

            //}
            //else
            //{
            //    logRW.WriteLog("EFEM " + "Disconnected", "System");
            //    //MessageBox.Show("Disconnected");
            //}
            _Paser = new EFEM_Paser();
        }
        public bool Connect()
        {
            try
            {
                if (client != null)
                {
                    client.Dispose();
                }
                client = new SimpleTcpClient(configWR.ReadSettings("EFEM_IP") + ":" + configWR.ReadSettings("EFEM_Port"));
                client.Events.Connected += Events_Connected;
                client.Events.DataReceived += Events_DataReceived;
                client.Events.Disconnected += Events_Disconnected;
                client.Connect();
                if (client.IsConnected)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                logRW.WriteLog("EFEM " + ex.Message, "System");
                return false;
            }
        }
        private void Events_Disconnected(object sender, ConnectionEventArgs e)
        {

            this.BeginInvoke(new Action(() =>
            {
                btn_Connect.Enabled = true;
                btn_Disconnect.Enabled = false;
                btn_Send.Enabled = false;
                if (client != null)
                {
                    client.Dispose();
                }
                txt_Info.Text += "Server disconnected \r\n";
                txt_Info.SelectionStart = txt_Info.TextLength;
                txt_Info.ScrollToCaret();
                logRW.WriteLog("Server disconnected", "EFEM");
            }));

        }




        public event EventHandler receive_update;

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            var str = System.Text.Encoding.UTF8.GetString(e.Data.ToArray());
           
            _Paser._Paser(str);
            logRW.WriteLog("Return Code: " + System.Text.Encoding.UTF8.GetString(e.Data.ToArray()), "EFEM");
            receive_update(this, e);
            this.BeginInvoke(new Action(() =>
            {
                txt_Info.Text += System.Text.Encoding.UTF8.GetString(e.Data.ToArray()) + "\r\n";
                txt_Info.SelectionStart = txt_Info.TextLength;
                txt_Info.ScrollToCaret();
            }));
        }

        private void Events_Connected(object sender, ConnectionEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                btn_Send.Enabled = true;
                btn_Connect.Enabled = false;
                btn_Disconnect.Enabled = true;
                txt_Info.Text += "Server connected \r\n";
                txt_Info.SelectionStart = txt_Info.TextLength;
                txt_Info.ScrollToCaret();
                logRW.WriteLog("Server connected", "EFEM");
            }));
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                try
                {
                    client.Connect();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logRW.WriteLog(ex.Message, "EFEM");
                }
            }
            else if (!string.IsNullOrEmpty(configWR.ReadSettings("EFEM_IP")) && !string.IsNullOrEmpty(configWR.ReadSettings("EFEM_Port")))
            {
                client = new SimpleTcpClient(configWR.ReadSettings("EFEM_IP") + ":" + configWR.ReadSettings("EFEM_Port"));
                client.Events.Connected += Events_Connected;
                client.Events.DataReceived += Events_DataReceived;
                client.Events.Disconnected += Events_Disconnected;
                try
                {
                    client.Connect();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logRW.WriteLog(ex.Message, "EFEM");
                }
            }
            else
            {
                MessageBox.Show("Disconnected");
            }

        }
        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                try
                {
                    client.Disconnect();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logRW.WriteLog(ex.Message, "EFEM");
                }
            }

        }
        private void btn_Send_Click(object sender, EventArgs e)
        {
            EFEM_Cmd = txt_Message.Text;

            EFEM_Send();
        }
        public void EFEM_Send()
        {
            if (client != null && client.IsConnected)
            {
                if (!string.IsNullOrEmpty(txt_Message.Text) || EFEM_Cmd != string.Empty)
                {
                    client.Send(String.Format("{0}{1}{2}", StartChar, EFEM_Cmd, EndChar));
                    this.BeginInvoke(new Action(() =>
                    {
                        txt_Info.Text += txt_Message.Text + "\r\n";
                        txt_Info.SelectionStart = txt_Info.TextLength;
                        txt_Info.ScrollToCaret();
                        logRW.WriteLog("Send Cmd: " + EFEM_Cmd, "EFEM");
                    }));
                }
            }
        }


        private void txt_IP_TextChanged(object sender, EventArgs e)
        {

        }

        #region Form close     
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
        #endregion
    }
}
