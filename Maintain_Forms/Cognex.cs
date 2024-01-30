using Microsoft.Win32;
using SuperSimpleTcp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wafer_System.Log_Fun;
using DataReceivedEventArgs = SuperSimpleTcp.DataReceivedEventArgs;
using System.Threading;
using System.Text.RegularExpressions;
using System.Reflection.Emit;
using Wafer_System.BaslerMutiCam;
using System.Runtime.Hosting;
using Wafer_System.Config_Fun;

namespace Wafer_System
{
    public partial class Cognex : Form
    {
        private LogRW logRW;
        public SimpleTcpClient client;
        public string data;
        private ConfigWR configWR;

        public Cognex(LogRW logRW, ConfigWR configWR)
        {
            this.logRW = logRW;
            this.configWR = configWR;
            var appName = Process.GetCurrentProcess().MainModule.ModuleName;
            Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", appName, 9000, RegistryValueKind.DWord);
            InitializeComponent();
        }

        public bool Connect()
        {
            if (client != null)
            {
                client.Dispose();
            }
            client = new SimpleTcpClient(configWR.ReadSettings("CognexURL"));
            client.Events.Connected += Connected;
            client.Events.Disconnected += Disconnected;
            client.Events.DataReceived += DataReceived;
            try
            {
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
            catch (SocketException ex)
            {

                logRW.WriteLog("Cognex " + ex.Message.ToString(), "System");
                return false;
            }
        }
        private void Cognex_Load(object sender, EventArgs e)
        {
            //://IPaddress/filename?isSL=username+password
            webBrowser1.AllowNavigation = true;

            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
            webBrowser1.Navigate("http://169.254.5.169/?isSL=admin+");


        }
        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                webBrowser1.Refresh();
            }));

        }

        public void ReadData(int config)
        {
            client.Send("READ(" + config + ")\r\n");
        }


        private void Connected(object sender, ConnectionEventArgs e)
        {
            logRW.WriteLog("Cognex " + $"*** Server {e.IpPort} connected", "System");
        }

        private void Disconnected(object sender, ConnectionEventArgs e)
        {
            logRW.WriteLog("Cognex " + $"*** Server {e.IpPort} disconnected", "System");
        }

        private void DataReceived(object sender, DataReceivedEventArgs e)
        {
            data = Encoding.UTF8.GetString(e.Data.Array, 0, e.Data.Count);
            logRW.WriteLog($"[{e.IpPort}] {Encoding.UTF8.GetString(e.Data.Array, 0, e.Data.Count)}", "System");
        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
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

        public void CognexClose()
        {
            if (client != null)
            {
                client.Disconnect();
                client.Dispose();
            }
        }




        #endregion




    }
}
