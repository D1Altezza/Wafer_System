using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using ACS.SPiiPlusNET;      // ACS .NET Library
using System.Runtime.InteropServices;
//using  System.Net.WebRequestMethods;
using System.Configuration;
using Wafer_System;
using System.Windows;
using MessageBox = System.Windows.Forms.MessageBox;
using Application = System.Windows.Forms.Application;
using System.Net;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Windows.Markup;
using CL3_IF_DllSample;
using Wafer_System.Log_Fun;
using System.Threading.Tasks;

namespace ACS_DotNET_Library_Advanced_Demo
{
    public partial class ACS_Motion : Form
    {

        //public const int WM_NCLBUTTONDOWN = 0xA1;
        //public const int HT_CAPTION = 0x2;

        //[DllImportAttribute("user32.dll")]
        //public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        //[DllImportAttribute("user32.dll")]
        //public static extern bool ReleaseCapture();

        //private void Move_Win(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        ReleaseCapture();
        //        SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        //    }
        //}      
        public Api _ACS;

        private const int MAX_AXIS_COUNT = 32;
        private const int MAX_BUFFER_CNT = 64;

        private const int MAX_UI_LIMIT_CNT = 8;
        private const int MAX_UI_IO_CNT = 8;

        private int m_nTotalAxis = 0;
        private int m_nTotalBuffer = 0;
        private Axis[] m_arrAxisList = null;

        private bool m_bConnected = false;

        // For update values
        private MotorStates m_nMotorState;
        private MotorStates m_nMotor_X_State;
        private MotorStates m_nMotor_Y_State;
        private MotorStates m_nMotor_A_State;

        private ProgramStates m_nProgramState;
        private object m_objReadVar = null;
        private Array m_arrReadVector = null;
        private double m_lfRPos, m_lfFPos, m_lfPE, m_lfFVEL;
        public double m_X_lfRPos, m_X_lfFPos, m_X_lfPE, m_X_lfFVEL;
        public double m_Y_lfRPos, m_Y_lfFPos, m_Y_lfPE, m_Y_lfFVEL;
        public double m_A_lfRPos, m_A_lfFPos, m_A_lfPE, m_A_lfFVEL;

        private int m_nValues, m_nOutputState, m_nValues_mps, m_nOutputState_mps;


        private Label[] m_lblLeftLimit;
        private Label[] m_lblRightLimit;
        private Label[] m_lblInput;
        private Label[] m_lblOutput;
        private Button[] m_btnOutput;
        private Label[] m_lblInput_mps;
        private Label[] m_lblOutput_mps;
        private Button[] m_btnOutput_mps;

        public Axis axis0 = (Axis)0, axis1 = (Axis)1, axis2 = (Axis)2;
        public Axis[] _AxisList = { Axis.ACSC_AXIS_0, Axis.ACSC_AXIS_1, Axis.ACSC_NONE };
        public bool x_En, y_En, a_En, x_Inp, y_Inp, a_Inp, x_moving, y_moving, a_moving = false;

        public Thread prog_run_thread;
        LogRW logRW;
        public ACS_Motion(LogRW logRW)
        {
            InitializeComponent();
            this.logRW = logRW;
            //panel_Header.MouseDown += new MouseEventHandler(Move_Win);
            //panel1.MouseDown += new MouseEventHandler(Move_Win);
            _ACS = new Api();
            // Register Event
            _ACS.PHYSICALMOTIONEND += _ACS_PHYSICALMOTIONEND;
            //_ACS.PROGRAMEND += _ACS_PROGRAMEND;
            //_ACS.PROGRAMEND += _ACS_Buffer_PROGRAMEND;


        }







        #region Initialize
        private void Form1_Load(object sender, EventArgs e)
        {
            rdoTCP.Checked = true;
            btnOpen.Enabled = true;
            btnClose.Enabled = false;

            m_lblLeftLimit = new Label[MAX_UI_LIMIT_CNT];
            m_lblLeftLimit[0] = lblLL0;
            m_lblLeftLimit[1] = lblLL1;
            m_lblLeftLimit[2] = lblLL2;
            m_lblLeftLimit[3] = lblLL3;
            m_lblLeftLimit[4] = lblLL4;
            m_lblLeftLimit[5] = lblLL5;
            m_lblLeftLimit[6] = lblLL6;
            m_lblLeftLimit[7] = lblLL7;

            m_lblRightLimit = new Label[MAX_UI_LIMIT_CNT];
            m_lblRightLimit[0] = lblRL0;
            m_lblRightLimit[1] = lblRL1;
            m_lblRightLimit[2] = lblRL2;
            m_lblRightLimit[3] = lblRL3;
            m_lblRightLimit[4] = lblRL4;
            m_lblRightLimit[5] = lblRL5;
            m_lblRightLimit[6] = lblRL6;
            m_lblRightLimit[7] = lblRL7;

            m_lblInput = new Label[MAX_UI_IO_CNT];
            m_lblInput[0] = lblIN0;
            m_lblInput[1] = lblIN1;
            m_lblInput[2] = lblIN2;
            m_lblInput[3] = lblIN3;
            m_lblInput[4] = lblIN4;
            m_lblInput[5] = lblIN5;
            m_lblInput[6] = lblIN6;
            m_lblInput[7] = lblIN7;

            m_lblOutput = new Label[MAX_UI_IO_CNT];
            m_lblOutput[0] = lblOUT0;
            m_lblOutput[1] = lblOUT1;
            m_lblOutput[2] = lblOUT2;
            m_lblOutput[3] = lblOUT3;
            m_lblOutput[4] = lblOUT4;
            m_lblOutput[5] = lblOUT5;
            m_lblOutput[6] = lblOUT6;
            m_lblOutput[7] = lblOUT7;

            m_btnOutput = new Button[MAX_UI_IO_CNT];
            m_btnOutput[0] = btnSW0;
            m_btnOutput[1] = btnSW1;
            m_btnOutput[2] = btnSW2;
            m_btnOutput[3] = btnSW3;
            m_btnOutput[4] = btnSW4;
            m_btnOutput[5] = btnSW5;
            m_btnOutput[6] = btnSW6;
            m_btnOutput[7] = btnSW7;


            m_lblInput_mps = new Label[MAX_UI_IO_CNT];
            m_lblInput_mps[0] = lblIN0_mps;
            m_lblInput_mps[1] = lblIN1_mps;
            m_lblInput_mps[2] = lblIN2_mps;
            m_lblInput_mps[3] = lblIN3_mps;
            m_lblInput_mps[4] = lblIN4_mps;
            m_lblInput_mps[5] = lblIN5_mps;
            m_lblInput_mps[6] = lblIN6_mps;
            m_lblInput_mps[7] = lblIN7_mps;
            //m_lblInput_mps[8] = lblIN8_mps;

            m_lblOutput_mps = new Label[MAX_UI_IO_CNT];
            m_lblOutput_mps[0] = lblOUT0_mps;
            m_lblOutput_mps[1] = lblOUT1_mps;
            m_lblOutput_mps[2] = lblOUT2_mps;
            m_lblOutput_mps[3] = lblOUT3_mps;
            m_lblOutput_mps[4] = lblOUT4_mps;
            m_lblOutput_mps[5] = lblOUT5_mps;
            m_lblOutput_mps[6] = lblOUT6_mps;
            m_lblOutput_mps[7] = lblOUT7_mps;

            m_btnOutput_mps = new Button[MAX_UI_IO_CNT];
            m_btnOutput_mps[0] = btnSW0_mps;
            m_btnOutput_mps[1] = btnSW1_mps;
            m_btnOutput_mps[2] = btnSW2_mps;
            m_btnOutput_mps[3] = btnSW3_mps;
            m_btnOutput_mps[4] = btnSW4_mps;
            m_btnOutput_mps[5] = btnSW5_mps;
            m_btnOutput_mps[6] = btnSW6_mps;
            m_btnOutput_mps[7] = btnSW7_mps;

            //m_nFault = new int[MAX_AXIS_COUNT];
            //Array.Clear(m_nFault, 0, MAX_AXIS_COUNT);
            m_nOutputState = 0;
            m_nOutputState_mps = 0;

            // Clear connection list from SPiiPlus UserMode-Driver (UMD)
            TernminateUMD_Connection();
        }

        private void rdoTCP_CheckedChanged(object sender, EventArgs e)
        {
            txtIP.Enabled = true;
            txtPort.Enabled = true;
        }

        private void rdoSimu_CheckedChanged(object sender, EventArgs e)
        {
            txtIP.Enabled = false;
            txtPort.Enabled = false;
        }
        #endregion

        #region Communication - Open / Close
        private void btnOpen_Click(object sender, EventArgs e)
        {
            controller_Connection(txtIP.Text, true);
            _ACS.EnableEvent(Interrupts.ACSC_INTR_PHYSICAL_MOTION_END);
        }
        Task t_Monitor;
        private CancellationTokenSource m_cts;
        public void controller_Connection(string _Address, bool TCP)
        {
            string strTemp;
            int i;
            //double lfTemp = 0.0f;

            try
            {
                if (TCP)
                {
                    // TCP/IP (Ethernet) 
                    _ACS.OpenCommEthernetTCP(
                       _Address,                             // IP Address (Default : 192.168.1.200)
                        Convert.ToInt32(txtPort.Text.Trim())    // TCP/IP Port nubmer (default : 701)
                        );
                    logRW.WriteLog("ACS connected", "System");

                }

                m_bConnected = true;

                // Get Total number of axes
                // Using Transaction function : return string text from controller, we need to convert to integer value
                strTemp = _ACS.Transaction("?SYSINFO(13)");
                m_nTotalAxis = Convert.ToInt32(strTemp.Trim());

                // Using Sysinfo function
                //_ACS.GetSysInfo(_ACS.ACSC_SYS_NAXES_KEY, out lfTemp);

                // When we are using multi axes command (ex) ToPointM, HaltM, ...), we need to allocate the array size more 1.
                // Because of the last delimeter (-1)
                m_arrAxisList = new Axis[m_nTotalAxis + 1];
                for (i = 0; i < m_nTotalAxis; i++)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        cboAxisNo.Items.Add(i.ToString());
                    }));

                    m_arrAxisList[i] = (Axis)i;
                }
                this.BeginInvoke(new Action(() =>
                {
                    // Insert '-1' at the last
                    m_arrAxisList[m_nTotalAxis] = Axis.ACSC_NONE;
                    cboAxisNo.SelectedIndex = 0;

                    // Update current motion paramter to UI.
                    UpdateProfile();

                    strTemp = _ACS.Transaction("?SYSINFO(10)");
                    m_nTotalBuffer = Convert.ToInt32(strTemp.Trim());


                    for (i = 0; i < m_nTotalBuffer; i++) { cboBufferNo.Items.Add(i.ToString()); }
                    cboBufferNo.SelectedIndex = 0;

                    btnOpen.Enabled = false;
                    btnClose.Enabled = true;
                }));





                //User define
                _ACS.EnableEvent(Interrupts.ACSC_INTR_PROGRAM_END);
                _ACS.Enable(axis0);
                _ACS.Enable(axis1);
                _ACS.Enable(axis2);

                // Set updating timer
                //tmrMonitor.Interval = 50;
                //tmrMonitor.Start();
                start_monitor = true;
                if (m_cts != null)
                {
                    m_cts.Dispose();
                }
                m_cts = new CancellationTokenSource();
                t_Monitor = Task.Run(() => { Monitor(); }, m_cts.Token);
                t_Monitor.ContinueWith(x => { Reset_status(); });

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                System.Diagnostics.Debug.WriteLine(ex.Message);
                logRW.WriteLog(ex.Message, "System");
            }
            //catch (COMException comex)
            //{
            //    MessageBox.Show("Connection fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    System.Diagnostics.Debug.WriteLine("Connection fail" + comex.Message);

            //    m_bConnected = false;
            //    return;
            //}
        }

        public void peg_setup()
        {
            int engToEncBitCode = 0x0;
            int gpOutsBitCode = 0x0b11;
            _ACS.AssignPegNT(Axis.ACSC_AXIS_1, engToEncBitCode, gpOutsBitCode);
            int outputBitCode = 0x0b0;
            int outputIndex = 0;
            _ACS.AssignPegOutputsNT(Axis.ACSC_AXIS_1, outputIndex, outputBitCode);
            //_ACS.AssignFastInputsNT(Axis.ACSC_AXIS_1, 1, 7);
            _ACS.PegIncNT(MotionFlags.ACSC_NONE, Axis.ACSC_AXIS_1, 0.5, 0, 200, 10000, Api.ACSC_NONE, Api.ACSC_NONE);
            int timeout = 2000;
            _ACS.WaitPegReadyNT(Axis.ACSC_AXIS_1, timeout);
            _ACS.StartPegNT(Axis.ACSC_AXIS_1);
        }

        private void Reset_status()
        {
            this.BeginInvoke(new Action(() =>
            {
                lb_X_En.Image = Wafer_System.Properties.Resources.Off;
                lb_Y_En.Image = Wafer_System.Properties.Resources.Off;

                lb_A_En.Image = Wafer_System.Properties.Resources.Off;
                lb_X_Inp.Image = Wafer_System.Properties.Resources.Off;
                lb_Y_Inp.Image = Wafer_System.Properties.Resources.Off;

                lb_A_Inp.Image = Wafer_System.Properties.Resources.Off;
                btnOpen.Enabled = true;
                btnClose.Enabled = false;
            }));

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            controller_Disconnect();
        }

        public void controller_Disconnect()
        {
            start_monitor = false;
            while (t_Monitor != null && !t_Monitor.IsCompleted)
            {
                Thread.Sleep(100);
                Application.DoEvents();
            }

            if (m_bConnected) _ACS.CloseComm();


            btnOpen.Enabled = true;
            btnClose.Enabled = false;
            logRW.WriteLog("ACS disconnected", "System");
        }


        /// <summary>
        /// Terminate connections from SPiiPlus User Mode Driver
        ///  - Maximum connections up to 10 in UMD
        /// </summary>
        private void TernminateUMD_Connection()
        {
            try
            {
                string terminateExceptionConnName = "ACS.Framework.exe";

                ACSC_CONNECTION_DESC[] connectionList = _ACS.GetConnectionsList();
                for (int index = 0; index < connectionList.Length; index++)
                {

                    if (terminateExceptionConnName.CompareTo((string)connectionList[index].Application) != 0)
                        _ACS.TerminateConnection(connectionList[index]);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
        #endregion

        #region Update UI data from Controller
        /// <summary>
        /// Update Motion Profile from Controller
        /// </summary>
        private void UpdateProfile()
        {
            if (m_bConnected)
            {
                txt_X_Vel.Text = _ACS.GetVelocity((Axis)cboAxisNo.SelectedIndex).ToString();
                txt_X_Acc.Text = _ACS.GetAcceleration((Axis)cboAxisNo.SelectedIndex).ToString();
                txt_X_Dec.Text = _ACS.GetDeceleration((Axis)cboAxisNo.SelectedIndex).ToString();
                //txtKdec.Text = _ACS.GetKillDeceleration((Axis)cboAxisNo.SelectedIndex).ToString();
                //txtJerk.Text = _ACS.GetJerk((Axis)cboAxisNo.SelectedIndex).ToString();
            }
        }

        private void cboAxisNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProfile();
        }


        public bool start_monitor = false;
        public void Monitor()
        {
            while (start_monitor)
            {
                if (this.m_cts.Token.IsCancellationRequested)
                {
                    break;
                }
                this.BeginInvoke(new Action(() =>
                {
                    // Get selected axis number
                    int iAxisNo = cboAxisNo.SelectedIndex;
                    // Get selected buffer number
                    int iBufferNo = cboBufferNo.SelectedIndex;

                    if (m_bConnected)
                    {
                        try
                        {
                            //Get User Setting
                            txt_X_Vel.Text = ReadSettings("ManualVelX");
                            txt_X_JogVel.Text = ReadSettings("ManualVelX");
                            txt_X_Acc.Text = ReadSettings("ManualAccDecX");
                            txt_X_Dec.Text = ReadSettings("ManualAccDecX");

                            txt_Y_Vel.Text = ReadSettings("ManualVelY");
                            txt_Y_JogVel.Text = ReadSettings("ManualVelY");
                            txt_Y_Acc.Text = ReadSettings("ManualAccDecY");
                            txt_Y_Dec.Text = ReadSettings("ManualAccDecY");



                            txt_A_Vel.Text = ReadSettings("ManualVelY");
                            txt_A_JogVel.Text = ReadSettings("ManualVelZ");
                            txt_A_Acc.Text = ReadSettings("ManualAccDecZ");
                            txt_A_Dec.Text = ReadSettings("ManualAccDecZ");

                            m_nMotor_X_State = _ACS.GetMotorState(axis0);
                            m_nMotor_Y_State = _ACS.GetMotorState(axis1);
                            m_nMotor_A_State = _ACS.GetMotorState(axis2);

                            if ((m_nMotor_X_State & MotorStates.ACSC_MST_MOVE) != 0) { lb_X_Moving.Image = Wafer_System.Properties.Resources.On; x_moving = true; } else { lb_X_Moving.Image = Wafer_System.Properties.Resources.Off; x_moving = false; }
                            if ((m_nMotor_X_State & MotorStates.ACSC_MST_INPOS) != 0) { lb_X_Inp.Image = Wafer_System.Properties.Resources.On; x_Inp = true; } else { lb_X_Inp.Image = Wafer_System.Properties.Resources.Off; x_Inp = false; }
                            if ((m_nMotor_X_State & MotorStates.ACSC_MST_ENABLE) != 0) { lb_X_En.Image = Wafer_System.Properties.Resources.On; x_En = true; } else { lb_X_En.Image = Wafer_System.Properties.Resources.Off; x_En = false; }

                            if ((m_nMotor_Y_State & MotorStates.ACSC_MST_MOVE) != 0) { lb_Y_Moving.Image = Wafer_System.Properties.Resources.On; y_moving = true; } else { lb_Y_Moving.Image = Wafer_System.Properties.Resources.Off; y_moving = false; }
                            if ((m_nMotor_Y_State & MotorStates.ACSC_MST_INPOS) != 0) { lb_Y_Inp.Image = Wafer_System.Properties.Resources.On; y_Inp = true; } else { lb_Y_Inp.Image = Wafer_System.Properties.Resources.Off; y_Inp = false; }
                            if ((m_nMotor_Y_State & MotorStates.ACSC_MST_ENABLE) != 0) { lb_Y_En.Image = Wafer_System.Properties.Resources.On; y_En = true; } else { lb_Y_En.Image = Wafer_System.Properties.Resources.Off; y_En = false; }

                            if ((m_nMotor_A_State & MotorStates.ACSC_MST_MOVE) != 0) { lb_A_Moving.Image = Wafer_System.Properties.Resources.On; a_moving = true; } else { lb_A_Moving.Image = Wafer_System.Properties.Resources.Off; a_moving = false; }
                            if ((m_nMotor_A_State & MotorStates.ACSC_MST_INPOS) != 0) { lb_A_Inp.Image = Wafer_System.Properties.Resources.On; a_Inp = true; } else { lb_A_Inp.Image = Wafer_System.Properties.Resources.Off; a_Inp = false; }
                            if ((m_nMotor_A_State & MotorStates.ACSC_MST_ENABLE) != 0) { lb_A_En.Image = Wafer_System.Properties.Resources.On; a_En = true; } else { lb_A_En.Image = Wafer_System.Properties.Resources.Off; y_En = false; }


                            m_X_lfRPos = _ACS.GetRPosition(axis0);
                            m_Y_lfRPos = _ACS.GetRPosition(axis1);
                            m_A_lfRPos = _ACS.GetRPosition(axis2);

                            m_X_lfFPos = _ACS.GetFPosition(axis0);
                            m_Y_lfFPos = _ACS.GetFPosition(axis1);
                            m_A_lfFPos = _ACS.GetFPosition(axis2);

                            //m_lfPE = (double)_ACS.ReadVariable("PE", ProgramBuffer.ACSC_NONE, iAxisNo, iAxisNo);
                            m_X_lfFVEL = (double)_ACS.ReadVariable("FVEL", ProgramBuffer.ACSC_NONE, 0, 0);
                            m_Y_lfFVEL = (double)_ACS.ReadVariable("FVEL", ProgramBuffer.ACSC_NONE, 1, 1);
                            m_A_lfFVEL = (double)_ACS.ReadVariable("FVEL", ProgramBuffer.ACSC_NONE, 2, 2);


                            txt_X_Rpos.Text = String.Format("{0:0.0000}", m_X_lfRPos);
                            txt_X_Fpos.Text = String.Format("{0:0.0000}", m_X_lfFPos);
                            txt_X_FVel.Text = String.Format("{0:0.0000}", m_X_lfFVEL);

                            txt_Y_Rpos.Text = String.Format("{0:0.0000}", m_Y_lfRPos);
                            txt_Y_Fpos.Text = String.Format("{0:0.0000}", m_Y_lfFPos);
                            txt_Y_FVel.Text = String.Format("{0:0.0000}", m_Y_lfFVEL);

                            txt_A_Rpos.Text = String.Format("{0:0.0000}", m_A_lfRPos);
                            txt_A_Fpos.Text = String.Format("{0:0.0000}", m_A_lfFPos);
                            txt_A_FVel.Text = String.Format("{0:0.0000}", m_A_lfFVEL);





                            m_nProgramState = _ACS.GetProgramState((ProgramBuffer)iBufferNo);
                            if ((m_nProgramState & ProgramStates.ACSC_PST_RUN) != 0)
                            {
                                lblPRG_Status_LED.Image = Wafer_System.Properties.Resources.On;
                                lblPRG_Status.Text = "Running";
                            }
                            else
                            {
                                lblPRG_Status_LED.Image = Wafer_System.Properties.Resources.Off;
                                lblPRG_Status.Text = "Stop";
                            }


                            m_objReadVar = _ACS.ReadVariableAsVector("FAULT", ProgramBuffer.ACSC_NONE, 0, m_nTotalAxis - 1, -1, -1);
                            if (m_objReadVar != null)
                            {
                                m_arrReadVector = m_objReadVar as Array;
                                if (m_arrReadVector != null)
                                {
                                    for (int i = 0; i < m_nTotalAxis; i++)
                                    {
                                        UpdateLimitState(i, (int)m_arrReadVector.GetValue(i));
                                    }
                                }
                            }
                            m_nValues = _ACS.GetInputPort(0);           // _ACS.ReadVariableAsVector("IN", -1, 0, 0, -1, -1);
                            UpdateIOState(m_nValues, true);

                            m_nOutputState = _ACS.GetOutputPort(0);     // _ACS.ReadVariableAsVector("OUT", -1, 0, 0, -1, -1);
                            UpdateIOState(m_nOutputState, false);

                            m_nValues_mps = _ACS.GetInputPort(1);           // _ACS.ReadVariableAsVector("IN", -1, 0, 0, -1, -1);
                            UpdateIOState_mps(m_nValues_mps, true);

                            m_nOutputState_mps = _ACS.GetOutputPort(1);     // _ACS.ReadVariableAsVector("OUT", -1, 0, 0, -1, -1);
                            UpdateIOState_mps(m_nOutputState_mps, false);
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.m_cts.Cancel();
                            System.Diagnostics.Debug.WriteLine(ex.Message);
                            start_monitor = false;
                        }
                    }


                }));
                Thread.Sleep(100);
            }
        }








        // Update limit state
        private void UpdateLimitState(int axisNo, int fault)
        {
            if (axisNo < MAX_UI_LIMIT_CNT)
            {
                if ((fault & (int)SafetyControlMasks.ACSC_SAFETY_LL) != 0) m_lblLeftLimit[axisNo].Image = Wafer_System.Properties.Resources.Error; else m_lblLeftLimit[axisNo].Image = Wafer_System.Properties.Resources.Off;
                if ((fault & (int)SafetyControlMasks.ACSC_SAFETY_RL) != 0) m_lblRightLimit[axisNo].Image = Wafer_System.Properties.Resources.Error; else m_lblRightLimit[axisNo].Image = Wafer_System.Properties.Resources.Off;

                lb_X_LL.Image = m_lblLeftLimit[(int)axis0].Image;
                lb_X_RL.Image = m_lblLeftLimit[(int)axis0].Image;
                lb_Y_LL.Image = m_lblLeftLimit[(int)axis1].Image;
                lb_Y_RL.Image = m_lblLeftLimit[(int)axis1].Image;
                lb_A_LL.Image = m_lblLeftLimit[(int)axis2].Image;
                lb_A_RL.Image = m_lblLeftLimit[(int)axis2].Image;
            }
        }

        // Update general I/O stae
        private void UpdateIOState(int value, bool isInput)
        {
            int bitUpCnt = 0x01;

            for (int i = 0; i < MAX_UI_IO_CNT; i++)
            {
                if (isInput)
                {
                    // Input state
                    if ((value & bitUpCnt) != 0) m_lblInput[i].Image = Wafer_System.Properties.Resources.On;
                    else m_lblInput[i].Image = Wafer_System.Properties.Resources.Off;
                }
                else
                {
                    // Output state
                    if ((value & bitUpCnt) != 0)
                    {
                        m_btnOutput[i].Text = "OFF";
                        m_lblOutput[i].Image = Wafer_System.Properties.Resources.On;
                    }
                    else
                    {
                        m_btnOutput[i].Text = "ON";
                        m_lblOutput[i].Image = Wafer_System.Properties.Resources.Off;
                    }
                }

                // 0x01 => 0x02 => 0x04 => 0x08 ... increase bit number
                bitUpCnt = (0x01) << (i + 1);
            }
        }
        private void UpdateIOState_mps(int value, bool isInput)
        {
            int bitUpCnt = 0x01;

            for (int i = 0; i < MAX_UI_IO_CNT; i++)
            {
                if (isInput)
                {
                    // Input state
                    if ((value & bitUpCnt) != 0) m_lblInput_mps[i].Image = Wafer_System.Properties.Resources.On;
                    else m_lblInput_mps[i].Image = Wafer_System.Properties.Resources.Off;
                }
                else
                {
                    // Output state
                    if ((value & bitUpCnt) != 0)
                    {
                        m_btnOutput_mps[i].Text = "OFF";
                        m_lblOutput_mps[i].Image = Wafer_System.Properties.Resources.On;
                    }
                    else
                    {
                        m_btnOutput_mps[i].Text = "ON";
                        m_lblOutput_mps[i].Image = Wafer_System.Properties.Resources.Off;
                    }
                }

                // 0x01 => 0x02 => 0x04 => 0x08 ... increase bit number
                bitUpCnt = (0x01) << (i + 1);
            }
        }
        #endregion

        #region Motor Enable / Disable
        private void btnEnable_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            // Enable selected axis
            switch (button.Name)
            {
                case "Btn_X_En":
                    _ACS.Enable((Axis)0);
                    break;
                case "Btn_Y_En":
                    _ACS.Enable((Axis)1);
                    break;
                case "Btn_A_En":
                    _ACS.Enable((Axis)2);
                    break;
            }
            //_ACS.Enable((Axis)cboAxisNo.SelectedIndex);

            // If you want to enable several axes, 
            // 
            // Ex) Eanble three axes (0, 1, 6)
            //
            // int[] AxisList = new int[] { 0, 1, 6, -1 };      !!!! Important !! Must insert '-1' at the last
            // _ACS.EnableM(AxisList);
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            // Disable selected axis
            switch (button.Name)
            {
                case "Btn_X_Disable":
                    _ACS.Disable((Axis)0);
                    break;
                case "Btn_Y_Disable":
                    _ACS.Disable((Axis)1);
                    break;
                case "Btn_A_Disable":
                    _ACS.Disable((Axis)2);
                    break;
            }
            //_ACS.Disable((Axis)cboAxisNo.SelectedIndex);
            // Disable multi axes : DisableM(int[] axisList)
        }

        private void btnDisableAll_Click(object sender, EventArgs e)
        {
            // Disable all of axes
            _ACS.DisableAll();
        }
        #endregion

        private void btnSetZero_Click(object sender, EventArgs e)
        {
            // Change current poisition as you want
            // SetFPosition(Axis number, new position)
            _ACS.SetFPosition((Axis)cboAxisNo.SelectedIndex, 0);
        }

        #region Move to absolute position
        private void btnPTP_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            double lfTargetPos = 0.0f;
            try
            {
                switch (b.Name)
                {
                    case "btn_X_PTP":
                        if (txt_X_PTP_Pos.Text.Length > 0)
                        {
                            lfTargetPos = Convert.ToDouble(txt_X_PTP_Pos.Text);
                            _ACS.ToPoint(
                                0,                          // '0' - Absolute position
                                axis0,  // Axis number
                                lfTargetPos                 // Target position
                                );
                        }
                        break;
                    case "btn_Y_PTP":
                        if (txt_Y_PTP_Pos.Text.Length > 0)
                        {
                            lfTargetPos = Convert.ToDouble(txt_Y_PTP_Pos.Text);
                            _ACS.ToPoint(
                                0,                          // '0' - Absolute position
                                axis1,  // Axis number
                                lfTargetPos                 // Target position
                                );
                        }
                        break;

                    case "btn_A_PTP":
                        if (txt_A_PTP_Pos.Text.Length > 0)
                        {
                            lfTargetPos = Convert.ToDouble(txt_A_PTP_Pos.Text);
                            _ACS.ToPoint(
                                0,                          // '0' - Absolute position
                                axis2,  // Axis number
                                lfTargetPos                 // Target position
                                );
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _ACS.Command("#1X");
        }
        #endregion

        #region Move to relative position (from current position)
        private void btnPTP_R_Neg_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            double lfTargetPos = 0.0f;


            try
            {

                switch (b.Name)
                {
                    case "btn_X_PTP_R_Neg":
                        if (txt_X_PTP_Pos.Text.Length > 0)
                        {
                            lfTargetPos = Convert.ToDouble(txt_X_PTP_Pos.Text);
                            if (lfTargetPos > 0) lfTargetPos = lfTargetPos * (-1);      // Target position (from current position, step move)

                            _ACS.ToPoint(
                                MotionFlags.ACSC_AMF_RELATIVE,      // Flat
                                axis0,      // Axis number
                                lfTargetPos                         // Move distance
                                );
                        }
                        break;
                    case "btn_Y_PTP_R_Neg":
                        if (txt_X_PTP_Pos.Text.Length > 0)
                        {
                            lfTargetPos = Convert.ToDouble(txt_Y_PTP_Pos.Text);
                            if (lfTargetPos > 0) lfTargetPos = lfTargetPos * (-1);      // Target position (from current position, step move)

                            _ACS.ToPoint(
                                MotionFlags.ACSC_AMF_RELATIVE,      // Flat
                                axis1,      // Axis number
                                lfTargetPos                         // Move distance
                                );
                        }
                        break;

                    case "btn_A_PTP_R_Neg":
                        if (txt_A_PTP_Pos.Text.Length > 0)
                        {
                            lfTargetPos = Convert.ToDouble(txt_A_PTP_Pos.Text);
                            if (lfTargetPos > 0) lfTargetPos = lfTargetPos * (-1);      // Target position (from current position, step move)

                            _ACS.ToPoint(
                                MotionFlags.ACSC_AMF_RELATIVE,      // Flat
                                axis2,      // Axis number
                                lfTargetPos                         // Move distance
                                );
                        }
                        break;
                }





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void btnPTP_R_Pos_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            double lfTargetPos = 0.0f;
            try
            {
                switch (b.Name)
                {
                    case "btn_X_PTP_R_Pos":
                        if (txt_X_PTP_Pos.Text.Length > 0)
                        {
                            lfTargetPos = Convert.ToDouble(txt_X_PTP_Pos.Text);
                            if (lfTargetPos < 0) lfTargetPos = lfTargetPos * (-1);      // Target position (from current position, step move)

                            _ACS.ToPoint(
                                MotionFlags.ACSC_AMF_RELATIVE,      // Flat
                                axis0,      // Axis number
                                lfTargetPos                         // Move distance
                                );
                        }
                        break;
                    case "btn_Y_PTP_R_Pos":
                        if (txt_X_PTP_Pos.Text.Length > 0)
                        {
                            lfTargetPos = Convert.ToDouble(txt_Y_PTP_Pos.Text);
                            if (lfTargetPos < 0) lfTargetPos = lfTargetPos * (-1);      // Target position (from current position, step move)

                            _ACS.ToPoint(
                                MotionFlags.ACSC_AMF_RELATIVE,      // Flat
                                axis1,      // Axis number
                                lfTargetPos                         // Move distance
                                );
                        }
                        break;

                    case "btn_A_PTP_R_Pos":
                        if (txt_A_PTP_Pos.Text.Length > 0)
                        {
                            lfTargetPos = Convert.ToDouble(txt_A_PTP_Pos.Text);
                            if (lfTargetPos < 0) lfTargetPos = lfTargetPos * (-1);      // Target position (from current position, step move)

                            _ACS.ToPoint(
                                MotionFlags.ACSC_AMF_RELATIVE,      // Flat
                                axis2,      // Axis number
                                lfTargetPos                         // Move distance
                                );
                        }
                        break;
                }









            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Stop motion using deceleration (halt command)
        private void btnHalt_Click(object sender, EventArgs e)
        {
            try
            {
                _ACS.Halt((Axis)cboAxisNo.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void btnHallAll_Click(object sender, EventArgs e)
        {
            try
            {
                // There is no halt all command, so you need to user HaltM function
                // 
                // ex) You want to stop 0, 2, 5 axis
                //     int[] m_arrAxisList = new int[] { 0, 2, 5, -1 };
                // 
                if (m_arrAxisList != null) _ACS.HaltM(m_arrAxisList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        #region JOG Command
        // Move negative direction
        private void btnJogNeg_MouseDown(object sender, MouseEventArgs e)
        {
            double lfVelocity = 0.0f;

            try
            {
                Button b = (Button)sender;

                switch (b.Name)
                {
                    case "btn_X_Jog_Neg":

                        if (chk_X_UseVel.Checked)
                        {
                            lfVelocity = Convert.ToDouble(txt_X_JogVel.Text.Trim());
                            if (lfVelocity > 0) lfVelocity = lfVelocity * (-1);

                            _ACS.Jog(MotionFlags.ACSC_AMF_VELOCITY, axis0, lfVelocity);
                        }
                        else
                        {
                            _ACS.Jog(0, axis0, (double)GlobalDirection.ACSC_NEGATIVE_DIRECTION);
                        }
                        break;
                    case "btn_Y_Jog_Neg":

                        if (chk_Y_UseVel.Checked)
                        {
                            lfVelocity = Convert.ToDouble(txt_Y_JogVel.Text.Trim());
                            if (lfVelocity > 0) lfVelocity = lfVelocity * (-1);

                            _ACS.Jog(MotionFlags.ACSC_AMF_VELOCITY, axis1, lfVelocity);
                        }
                        else
                        {
                            _ACS.Jog(0, axis1, (double)GlobalDirection.ACSC_NEGATIVE_DIRECTION);
                        }
                        break;
                    case "btn_Z_Jog_Neg":

                        if (chk_Z_UseVel.Checked)
                        {
                            lfVelocity = Convert.ToDouble(txt_X_JogVel.Text.Trim());
                            if (lfVelocity > 0) lfVelocity = lfVelocity * (-1);

                            _ACS.Jog(MotionFlags.ACSC_AMF_VELOCITY, axis2, lfVelocity);
                        }
                        else
                        {
                            _ACS.Jog(0, axis2, (double)GlobalDirection.ACSC_NEGATIVE_DIRECTION);
                        }
                        break;
                    case "btn_A_Jog_Neg":

                        if (chk_A_UseVel.Checked)
                        {
                            lfVelocity = Convert.ToDouble(txt_A_JogVel.Text.Trim());
                            if (lfVelocity > 0) lfVelocity = lfVelocity * (-1);

                            _ACS.Jog(MotionFlags.ACSC_AMF_VELOCITY, axis2, lfVelocity);
                        }
                        else
                        {
                            _ACS.Jog(0, axis2, (double)GlobalDirection.ACSC_NEGATIVE_DIRECTION);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        // 정방향 이동 동작
        private void btnJogPos_MouseDown(object sender, MouseEventArgs e)
        {
            double lfVelocity = 0.0f;
            Button b = (Button)sender;
            try
            {
                switch (b.Name)
                {
                    case "btn_X_Jog_Pos":

                        if (chk_X_UseVel.Checked)
                        {
                            lfVelocity = Convert.ToDouble(txt_X_JogVel.Text.Trim());
                            if (lfVelocity < 0) lfVelocity = lfVelocity * (-1);

                            _ACS.Jog(MotionFlags.ACSC_AMF_VELOCITY, axis0, lfVelocity);
                        }
                        else
                        {
                            _ACS.Jog(0, axis0, (double)GlobalDirection.ACSC_POSITIVE_DIRECTION);
                        }
                        break;
                    case "btn_Y_Jog_Pos":

                        if (chk_Y_UseVel.Checked)
                        {
                            lfVelocity = Convert.ToDouble(txt_Y_JogVel.Text.Trim());
                            if (lfVelocity < 0) lfVelocity = lfVelocity * (-1);

                            _ACS.Jog(MotionFlags.ACSC_AMF_VELOCITY, axis1, lfVelocity);
                        }
                        else
                        {
                            _ACS.Jog(0, axis1, (double)GlobalDirection.ACSC_POSITIVE_DIRECTION);
                        }
                        break;
                    case "btn_Z_Jog_Pos":

                        if (chk_Z_UseVel.Checked)
                        {
                            lfVelocity = Convert.ToDouble(txt_X_JogVel.Text.Trim());
                            if (lfVelocity < 0) lfVelocity = lfVelocity * (-1);

                            _ACS.Jog(MotionFlags.ACSC_AMF_VELOCITY, axis2, lfVelocity);
                        }
                        else
                        {
                            _ACS.Jog(0, axis2, (double)GlobalDirection.ACSC_POSITIVE_DIRECTION);
                        }
                        break;

                    case "btn_A_Jog_Pos":

                        if (chk_A_UseVel.Checked)
                        {
                            lfVelocity = Convert.ToDouble(txt_A_JogVel.Text.Trim());
                            if (lfVelocity < 0) lfVelocity = lfVelocity * (-1);

                            _ACS.Jog(MotionFlags.ACSC_AMF_VELOCITY, axis2, lfVelocity);
                        }
                        else
                        {
                            _ACS.Jog(0, axis2, (double)GlobalDirection.ACSC_POSITIVE_DIRECTION);
                        }
                        break;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        // Stop JOG motion
        private void btnJog_MouseUp(object sender, MouseEventArgs e)
        {
            //_ACS.Halt((Axis)cboAxisNo.SelectedIndex);
            _ACS.Halt(axis0);
            _ACS.Halt(axis1);
            _ACS.Halt(axis2);
        }


        #endregion

        #region Run/Stop Buffer Program
        private void btnRunBuffer_Click(object sender, EventArgs e)
        {
            string temp;

            try
            {
                if (txtLabelName.Text.Length > 0)
                {
                    temp = txtLabelName.Text.ToUpper();
                    // Allow _ (Under bar) or A ~ Z characters
                    if (temp[0] != 0x5F && (temp[0] < 0x41 || temp[0] > 0x5A))
                    {
                        MessageBox.Show("Wrong 'Label' name inputed.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Run buffer program from label position
                    _ACS.RunBuffer((ProgramBuffer)cboBufferNo.SelectedIndex, txtLabelName.Text.Trim());
                }
                else
                {
                    // Run buffer program from first line
                    _ACS.RunBuffer((ProgramBuffer)cboBufferNo.SelectedIndex, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void btnStopBuffer_Click(object sender, EventArgs e)
        {
            // Stop program
            _ACS.StopBuffer((ProgramBuffer)cboBufferNo.SelectedIndex);
        }
        #endregion

        #region Change motion profile
        private void TextBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                double lfTemp = 0.0f;
                TextBox textBox = sender as TextBox;
                if (textBox != null)
                {
                    // Allow numbers (0 ~ 9), . (DOT), Backspace
                    if ((e.KeyChar >= 0x30 && e.KeyChar <= 0x39) || e.KeyChar == 0x2E || e.KeyChar == 0x08 || e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Enter)
                    {
                        if ((e.KeyChar == 0x2E) && (textBox.Text.Contains(Convert.ToString(0x2E)))) e.KeyChar = (char)0x00;
                        if (e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Enter)
                        {
                            e.Handled = true;

                            lfTemp = Convert.ToDouble(textBox.Text.Trim());
                            switch (textBox.TabIndex)
                            {
                                // Immediately change value (On the fly) : SetVelocityImm() 
                                // Affect next motion	: SetVelocity()	

                                case 0: _ACS.SetVelocityImm((Axis)cboAxisNo.SelectedIndex, lfTemp); break;
                                case 1: _ACS.SetAccelerationImm((Axis)cboAxisNo.SelectedIndex, lfTemp); break;
                                case 2: _ACS.SetDecelerationImm((Axis)cboAxisNo.SelectedIndex, lfTemp); break;
                                case 3: _ACS.SetKillDecelerationImm((Axis)cboAxisNo.SelectedIndex, lfTemp); break;
                                case 4: _ACS.SetJerkImm((Axis)cboAxisNo.SelectedIndex, lfTemp); break;
                            }

                            textBox.SelectAll();
                        }
                    }
                    else e.KeyChar = (char)0x00;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("TextBoxes_KeyPress() Error\n" + ex.ToString());
            }
        }

        private void TextBoxes_Enter(object sender, EventArgs e)
        {
            try
            {
                TextBox textBox = sender as TextBox;
                if (textBox != null) textBox.SelectAll();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("TextBoxes_Enter() Error\n" + ex.ToString());
            }
        }

        private void TextBoxes_Leave(object sender, EventArgs e)
        {
            try
            {
                double lfTemp = 0.0f;

                TextBox textBox = sender as TextBox;
                if (textBox == null) return;

                lfTemp = Convert.ToDouble(textBox.Text.Trim());
                switch (textBox.TabIndex)
                {
                    case 0: _ACS.SetVelocityImm((Axis)cboAxisNo.SelectedIndex, lfTemp); break;
                    case 1: _ACS.SetAccelerationImm((Axis)cboAxisNo.SelectedIndex, lfTemp); break;
                    case 2: _ACS.SetDecelerationImm((Axis)cboAxisNo.SelectedIndex, lfTemp); break;
                    case 3: _ACS.SetKillDecelerationImm((Axis)cboAxisNo.SelectedIndex, lfTemp); break;
                    case 4: _ACS.SetJerkImm((Axis)cboAxisNo.SelectedIndex, lfTemp); break;
                }

                textBox.SelectAll();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("TextBoxes_Leave() Error\n" + ex.ToString());
            }
        }
        #endregion

        #region On and Off General Output
        private void btnSW_Click(object sender, EventArgs e)
        {
            int nBitNo = 0x01;

            try
            {
                Button btn = sender as Button;
                if (btn == null) return;

                nBitNo = btn.TabIndex;
                nBitNo = (0x01) << nBitNo;

                if ((m_nOutputState & nBitNo) != 0)
                {
                    // Set only 1 bit
                    _ACS.SetOutput(
                        0,              // Port number
                        btn.TabIndex,   // Bit number
                        0               // 0 = OFF, 1 = ON
                        );

                    // If your I/O device is EtherCAT type, you cannot use this function
                    // You can use WriteVariable function and Command function   
                    // 
                    // Ex) If EtherCAT mapped variable is 'EC_DOUT'
                    //     Want to ON bit '3'
                    //     _ACS.Command("EC_DOUT.3=1");
                }
                else
                {
                    _ACS.SetOutput(0, btn.TabIndex, 1);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("btnSW_Click() Error\n" + ex.ToString());
            }
        }
        private void btnSWmps_Click(object sender, EventArgs e)
        {
            int nBitNo = 0x01;

            try
            {
                Button btn = sender as Button;
                if (btn == null) return;

                nBitNo = btn.TabIndex;
                nBitNo = (0x01) << nBitNo;

                if ((m_nOutputState_mps & nBitNo) != 0)
                {
                    // Set only 1 bit
                    _ACS.SetOutput(
                        1,              // Port number
                        btn.TabIndex,   // Bit number
                        0               // 0 = OFF, 1 = ON
                        );

                    // If your I/O device is EtherCAT type, you cannot use this function
                    // You can use WriteVariable function and Command function   
                    // 
                    // Ex) If EtherCAT mapped variable is 'EC_DOUT'
                    //     Want to ON bit '3'
                    //     _ACS.Command("EC_DOUT.3=1");
                }
                else
                {
                    _ACS.SetOutput(1, btn.TabIndex, 1);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("btnSW_Click() Error\n" + ex.ToString());
            }
        }
        #endregion

        #region Event 
        private void btnEventMotionEnd_Click(object sender, EventArgs e)
        {
            //_ACS.PHYSICALMOTIONEND +=_ACS_PHYSICALMOTIONEND;
            _ACS.EnableEvent(Interrupts.ACSC_INTR_PHYSICAL_MOTION_END);
            lstLog.Items.Add("PHYSICAL_MOTION_END event enabled");
        }

        void _ACS_PHYSICALMOTIONEND(AxisMasks axis)
        {
            int bit = 0x01;
            int axisNo = 0;
            // Param value is bit number 
            // Bit Number = Axis Number
            for (int i = 0; i < 64; i++)
            {
                if ((int)axis == bit)
                {
                    axisNo = i;
                    break;
                }
                bit = bit << 1;
            }

            // Add log to ListBox
            this.Invoke((MethodInvoker)delegate
            {
                lstLog.Items.Add(String.Format(" - Axis {0}, Stoppped", axisNo));
                lstLog.SelectedIndex = lstLog.Items.Count - 1;

            });

        }

        private void btnEventProgramEnd_Click(object sender, EventArgs e)
        {
            //_ACS.PROGRAMEND += _ACS_PROGRAMEND;
            _ACS.EnableEvent(Interrupts.ACSC_INTR_PROGRAM_END);

            lstLog.Items.Add("PROGRAM_END event enabled");
        }

        //void _ACS_Buffer_PROGRAMEND(BufferMasks buffer)
        //{
        //    int bit = 0x01;
        //    int bufferNo = 0;
        //    // Param value is bit number 
        //    // Bit Number = Axis Number
        //    for (int i = 0; i < 32; i++)
        //    {
        //        if ((int)buffer == bit)
        //        {
        //            bufferNo = i;
        //            break;
        //        }
        //        bit = bit << 1;
        //    }

        //    // Add log to ListBox
        //    this.Invoke((MethodInvoker)delegate
        //    {
        //        lstLog.Items.Add(String.Format(" - Buffer {0}, Stoppped", bufferNo));
        //        lstLog.SelectedIndex = lstLog.Items.Count - 1;
        //    });
        //}

        //void _ACS_Buffer_PROGRAMEND(BufferMasks buffer)
        //{
        //    int bit = 0x01;
        //    int bufferNo = 0;
        //    // Param value is bit number 
        //    // Bit Number = Axis Number
        //    for (int i = 0; i < 32; i++)
        //    {
        //        if ((int)buffer == bit)
        //        {
        //            bufferNo = i;
        //            program_End = true;
        //            break;
        //        }
        //        bit = bit << 1;
        //    }
        //    //program_End = false;

        //    //Add log to ListBox
        //    this.Invoke((MethodInvoker)delegate
        //    {
        //        lstLog.Items.Add(String.Format(" - Buffer {0}, Stoppped", bufferNo));
        //        lstLog.SelectedIndex = lstLog.Items.Count - 1;
        //        program_Runing = false;
        //    });
        //}




        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        #region Communication Termial - Using Transaction function
        private void txtCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnSend.PerformClick();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string temp = string.Empty;
            if (m_bConnected)
            {
                try
                {
                    AppendTextToTextBox("> " + txtCommand.Text.Trim());
                    temp = _ACS.Transaction(txtCommand.Text.Trim());
                }
                catch (ACS.SPiiPlusNET.ACSException ex)
                {
                    temp = String.Format("?{0}", ex.ErrorCode);
                }
                finally
                {
                    if (temp == null)
                    {
                        AppendTextToTextBox(":");
                    }
                    else if (temp.Length > 0)
                    {
                        AppendTextToTextBox(temp);
                        AppendTextToTextBox(":");
                    }
                }

                txtCommand.Focus();
                txtCommand.SelectAll();
            }
        }

        private void AppendTextToTextBox(string text)
        {
            rtxtTerminal.AppendText(text);
            rtxtTerminal.AppendText(Environment.NewLine);
            rtxtTerminal.ScrollToCaret();
        }
        #endregion


        private string ReadSettings(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not found";
                return result;
            }
            catch (Exception e)
            {
                return "";
            }
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

        public void ACSClose()
        {
            //while (Monitor_Thread != null && Monitor_Thread.IsAlive)
            //{
            //    Thread.Sleep(100);
            //    Application.DoEvents();
            //}
            controller_Disconnect();
        }
        #endregion


    }
}

