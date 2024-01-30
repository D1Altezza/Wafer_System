using CL3_IF_DllSample;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wafer_System.Log_Fun;

namespace Wafer_System
{
    public partial class EFEM_Monitor : Form
    {
        Dictionary<string, string> Dynamic_EFEM_Status_Labels = new Dictionary<string, string>() 
        {
            {"GetStatus_1","Emergency stop"},
            {"GetStatus_2","FFU PressureDifference"},
            {"GetStatus_3","EFEM PositivePressure"},
            {"GetStatus_4","EFEM NegativePressure"},
            {"GetStatus_5","Ionizer"},
            {"GetStatus_6","Light Curtain"},
            {"GetStatus_7","FFU"},
            {"GetStatus_8","OperationMode"},
            {"GetStatus_9","RobotEnable"},
            {"GetStatus_10","Door"},
        };
        private LogRW logRW;

        public EFEM_Monitor(LogRW logRW)
        {
            InitializeComponent();
            this.logRW = logRW;
        }
      
        private void EFEM_Monitor_Load(object sender, EventArgs e)
        {
            var index = 0;
            foreach (var item in Dynamic_EFEM_Status_Labels)
            {
                Label DynamicIOLabel = new Label();
                DynamicIOLabel.Name = "lb_" + item.Key;
                DynamicIOLabel.Text = item.Value;
                DynamicIOLabel.TextAlign = ContentAlignment.MiddleCenter;
                DynamicIOLabel.Margin = new Padding(5, 3, 0, 0);
                DynamicIOLabel.Font = new Font("Consolas", 12.0F, FontStyle.Regular);
                DynamicIOLabel.AutoSize = false;
                DynamicIOLabel.Size = new Size(140, 25);
                DynamicIOLabel.BackColor = Color.Gray;
                if (index <= 3)
                {
                    fLP_GetStatus.Controls.Add(DynamicIOLabel);
                }
                else if (index <= 10)
                {
                    fLP_GetStatus.Controls.Add(DynamicIOLabel);
                }
                else
                {
                    fLP_GetStatus.Controls.Add(DynamicIOLabel);
                }
                index++;
            }
        }

        #region Form close

        public void EFEM_Monitor_Close()
        {           
        }
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
