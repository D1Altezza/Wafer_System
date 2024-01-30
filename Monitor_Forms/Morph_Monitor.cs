using ACS.SPiiPlusNET;
using ACS_DotNET_Library_Advanced_Demo;
using CL3_IF_DllSample;
using Cool_Muscle_CML_Example;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wafer_System.Log_Fun;
using Wafer_System.Param_Settin_Forms;

namespace Wafer_System
{
    public partial class Morph_Monitor : Form
    {
        private LogRW logRW;
        private System_Setting_Form system_Setting_Form;
        private ACS_Motion aCS_Motion;
        private EFEM eFEM;
        private CML cML;
        private Keyence keyence;

        public Morph_Monitor(LogRW logRW, System_Setting_Form system_Setting_Form, ACS_Motion aCS_Motion, EFEM eFEM, CML cML, Keyence keyence)
        {
            this.logRW = logRW;
            this.system_Setting_Form = system_Setting_Form;
            this.aCS_Motion = aCS_Motion;
            this.eFEM = eFEM;
            this.cML = cML;
            this.keyence = keyence;
            InitializeComponent();
        }
        #region Form close

        public void Morph_Monitor_Close()
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
       
        private void button1_Click(object sender, EventArgs e)
        {
            var t = system_Setting_Form.Path_8Inch;
            int timeout = 5000;
            Axis[] axes = { Axis.ACSC_AXIS_0, Axis.ACSC_AXIS_1,Axis.ACSC_NONE };
            double[] points = { 0, 0 };
            aCS_Motion._ACS.EnableM(axes); // Enable axis 0 and 1
                                           // Wait axis 0 enabled during 5 sec
            aCS_Motion._ACS.WaitMotorEnabled(Axis.ACSC_AXIS_0, 1, timeout);
            // Wait axis 1 enabled during 5 sec
            aCS_Motion._ACS.WaitMotorEnabled(Axis.ACSC_AXIS_1, 1, timeout);           
            // Create multi-point motion of axis 0 and 1 with default
            // velocity without
            // dwell in the points
            aCS_Motion._ACS.MultiPointM(MotionFlags.ACSC_AMF_WAIT, axes, 0);
            
            // Add some points
            for (int index = 0; index < t.Count; index++)
            {
                points[0] = t[index].X;
                points[1] = t[index].Y;
                aCS_Motion._ACS.AddPointM(axes, points);
            }
            // Finish the motion
            // End of the multi-point
            aCS_Motion._ACS.EndSequenceM(axes);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Axis[] axes = { Axis.ACSC_AXIS_0, Axis.ACSC_AXIS_1, Axis.ACSC_NONE };
            aCS_Motion._ACS.GoM(axes);
         




        }

        private void button3_Click(object sender, EventArgs e)
        {
            aCS_Motion.peg_setup();
        }
    }
}
