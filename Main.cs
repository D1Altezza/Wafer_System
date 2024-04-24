using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Wafer_System.Config_Fun;
using Wafer_System.Log_Fun;
using ACS_DotNET_Library_Advanced_Demo;
using CL3_IF_DllSample;
using Wafer_System.Param_Settin_Forms;
using Wafer_System.BaslerMutiCam;
using Cool_Muscle_CML_Example;
using System.Diagnostics;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Net.NetworkInformation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;
using Button = System.Windows.Forms.Button;
using ProgressBar = System.Windows.Forms.ProgressBar;
using static Wafer_System.Main;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;
using static Wafer_System.Auto_run_page1;
using ACS.SPiiPlusNET;
using LiteDB;

namespace Wafer_System
{
    public partial class Main : Form
    {
        public bool pass = false;
        LogRW logRW = new LogRW();
        ConfigWR configWR;
        public LiteDatabase db;

        #region Maintainan Form
        public ACS_Motion aCS_Motion;
        public Keyence keyence;
        public EFEM eFEM;
        public CML cML;
        public MutiCam mutiCam;
        public Cognex Cognex;
        public int[] calibration = new int[157];
        #endregion

        #region AutoRun Pages
        Auto_run_page0 Auto_Run_Page0;
        Auto_run_page1 Auto_Run_Page1;
        Auto_run_page2 Auto_Run_Page2;
        #endregion

        #region Monitor Form
        EFEM_Monitor EFEM_Monitor;
        Morph_Monitor Morph_Monitor;
        Diameter_Monitor Diameter_Monitor;
        Report_Form Report_Form;
        #endregion


        #region Setting Form
        System_Setting_Form System_Setting_Form;
       
        #endregion

        #region D_param
        public class D_param
        {
            public int D100, D101, D102;
            public int D110, D111, D131;
            public int D122, D123, D124, D133;
            public int D200, D201;
            public int D300;
            public int D400;
            internal int D132;
            internal int D125;
            internal int D126;
            internal int D127;
            internal int D128;
            internal int D129;
            internal int D130;
        }
        public D_param d_Param;
        #endregion

        Button btn_System_Initial = new Button();
        Button btn_Home = new Button();
        ProgressBar progresBar = new ProgressBar();
        Label lb_progress = new Label();
        Label lb_progress_Title = new Label();



        bool eFEM_Received_Update = false;
        bool cm1_Received_Update = false;
        bool PROGRAMEND_Status_Update = false;
        public int efem_timeout = 100000;
        public TimeSpan IO_timeout = TimeSpan.FromSeconds(3);
        public bool[] home_end_flag = new bool[] { false, false, false };
        public bool[] measure_end_flag = new bool[] { false, false };

        public Main()
        {
            InitializeComponent();
            d_Param = new D_param();
            configWR = new ConfigWR(logRW);

            aCS_Motion = new ACS_Motion(logRW);
            keyence = new Keyence(logRW, configWR);
            Cognex = new Cognex(logRW, configWR);
            eFEM = new EFEM(logRW, configWR);
            cML = new CML(logRW, configWR);
            EFEM_Monitor = new EFEM_Monitor(logRW);
            mutiCam = new MutiCam(logRW, configWR);
            Morph_Monitor = new Morph_Monitor(logRW, System_Setting_Form, aCS_Motion, eFEM, cML, keyence);
            Diameter_Monitor = new Diameter_Monitor(logRW, configWR, aCS_Motion, eFEM, mutiCam, Cognex);
            Auto_Run_Page0 = new Auto_run_page0();
            System_Setting_Form = new System_Setting_Form(this, logRW, configWR);
            Auto_Run_Page1 = new Auto_run_page1(System_Setting_Form.config);
            Auto_Run_Page2 = new Auto_run_page2(this, mutiCam, Cognex, Auto_Run_Page1.autorun_Prarm, configWR);
            System_Setting_Form.load_auto_Run_Page2(Auto_Run_Page2);
            Report_Form = new Report_Form(this);


        }
        private void Main_Load(object sender, EventArgs e)
        {
            #region 實例化
            aCS_Motion.SendToBack();
            aCS_Motion.Show();
            aCS_Motion.Hide();
            keyence.SendToBack();
            keyence.Show();
            keyence.Hide();
            eFEM.SendToBack();
            eFEM.Show();
            eFEM.Hide();
            Cognex.Show();
            Cognex.Hide();
            EFEM_Monitor.SendToBack();
            EFEM_Monitor.Show();
            EFEM_Monitor.Hide();
            Morph_Monitor.SendToBack();
            Morph_Monitor.Show();
            Morph_Monitor.Hide();
            System_Setting_Form.SendToBack();
            System_Setting_Form.Show();
            System_Setting_Form.Hide();
            cML.SendToBack();
            cML.Show();
            cML.Hide();
            mutiCam.SendToBack();
            mutiCam.Show();
            mutiCam.Hide();
            Diameter_Monitor.SendToBack();
            Diameter_Monitor.Show();
            Diameter_Monitor.Hide();
            #endregion

            #region AutoRun pages
            Auto_Run_Page0.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Auto_Run_Page0.TopLevel = false;
            Auto_Run_Page0.Dock = System.Windows.Forms.DockStyle.Fill;
            autoRun_panel.Controls.Add(Auto_Run_Page0);



            btn_System_Initial.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_System_Initial.Size = new Size(100, 60);
            btn_System_Initial.Visible = false;
            btn_System_Initial.Text = "System Initialize";
            btn_System_Initial.Location = new Point(autoRun_panel.Width - btn_System_Initial.Width - btn_System_Initial.Margin.Right,
                autoRun_panel.Height - btn_System_Initial.Height - btn_System_Initial.Margin.Bottom);
            btn_System_Initial.Click += Btn_System_Initial_Click;
            autoRun_panel.Controls.Add(btn_System_Initial);

            btn_Home.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_Home.Size = new Size(100, 60);
            btn_Home.Visible = false;
            btn_Home.Text = "Home";
            btn_Home.Location = new Point(btn_System_Initial.Location.X, btn_System_Initial.Location.Y - btn_Home.Height - btn_System_Initial.Margin.Bottom);
            btn_Home.Click += Btn_Home_Click;
            autoRun_panel.Controls.Add(btn_Home);
            //((Button)(Auto_Run_Page0.Controls.Find("btn_Next", true)[0])).Click += AutoRunPage_Switch_Click;

            Auto_Run_Page0.Show();
            Auto_Run_Page1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Auto_Run_Page1.TopLevel = false;
            Auto_Run_Page1.Dock = System.Windows.Forms.DockStyle.Fill;
            autoRun_panel.Controls.Add(Auto_Run_Page1);
            ((Button)(Auto_Run_Page1.Controls.Find("btn_Go_Page2", true)[0])).Click += AutoRunPage_Switch_Click;
            Auto_Run_Page1.Show();
            Auto_Run_Page1.Hide();

            Auto_Run_Page2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Auto_Run_Page2.TopLevel = false;
            Auto_Run_Page2.Dock = System.Windows.Forms.DockStyle.Fill;
            autoRun_panel.Controls.Add(Auto_Run_Page2);
            ((Button)(Auto_Run_Page2.Controls.Find("btn_Go_Page1", true)[0])).Click += AutoRunPage_Switch_Click;
            Auto_Run_Page2.Show();
            Auto_Run_Page2.Hide();
            aCS_Motion._ACS.PROGRAMEND += _ACS_PROGRAMEND;
            #endregion

            #region Splash
            progresBar.Step = 1;
            progresBar.Width = 500;
            progresBar.Location = new Point(autoRun_panel.Width / 2 - progresBar.Width / 2, autoRun_panel.Height / 2 - progresBar.Height / 2);
            progresBar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            progresBar.Maximum = 100;
            autoRun_panel.Controls.Add(progresBar);
            lb_progress.Location = new Point(progresBar.Location.X, progresBar.Location.Y + progresBar.Height);
            lb_progress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lb_progress.BackColor = System.Drawing.SystemColors.Control;
            lb_progress.Font = new Font("Consolas", 11.25F);//Consolas, 11.25pt
            lb_progress.AutoSize = true;
            //lb_progress.Width = 500;
            autoRun_panel.Controls.Add(lb_progress);
            lb_progress_Title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lb_progress_Title.BackColor = System.Drawing.SystemColors.Control;
            lb_progress_Title.Font = new Font("Consolas", 11.25F);//Consolas, 11.25pt
            lb_progress_Title.AutoSize = true;
            lb_progress_Title.Location = new Point(progresBar.Location.X, progresBar.Location.Y - lb_progress_Title.Height);
            autoRun_panel.Controls.Add(lb_progress_Title);
            lb_progress_Title.BringToFront();
            progresBar.BringToFront();
            lb_progress.BringToFront();
            lb_progress_Title.Visible = false;
            progresBar.Visible = false;
            lb_progress.Visible = false;
            #endregion
        }



        private void Progres_update(bool on_off, int max, string title)
        {
            if (on_off)
            {
                progresBar.Maximum = max;
                lb_progress_Title.Text = title;
                lb_progress_Title.Visible = true;
                progresBar.Visible = true;
                lb_progress.Visible = true;
                progresBar.BringToFront();
                lb_progress.BringToFront();
            }
        }

        private void Progres_update(bool on_off)
        {
            progresBar.Value = 0;
            lb_progress.Text = string.Empty;
            lb_progress_Title.Text = string.Empty;
            progresBar.SendToBack();
            lb_progress.SendToBack();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            var conn = false;
            var ini = false;
            var home = false;
            var step1 = Task.Run(() =>
            {
                conn = InitialAllDevice_Conn();
                //this.BeginInvoke(new Action(() => { Auto_Run_Page1.Show(); }));

            })
            .ContinueWith(task =>
            {
                if (conn)
                    ini = sys_Ini();

            }, TaskContinuationOptions.OnlyOnRanToCompletion).ContinueWith(task =>
            {

                if (ini && MessageBox.Show("GO Home?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    home = sys_Home();
                }
            }
            , TaskContinuationOptions.OnlyOnRanToCompletion).ContinueWith(task =>
            {
                if (home)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        btn_System_Initial.Hide();
                        Auto_Run_Page0.Hide();
                        Auto_Run_Page1.Show();
                    }));
                }
            });
        }

        private void Btn_System_Initial_Click(object sender, EventArgs e)
        {
            Task.Run(() => { InitialAllDevice_Conn(); });
        }

        private void Btn_Home_Click(object sender, EventArgs e)
        {
            Task.Run(() => { sys_Home(); });
        }

        private bool InitialAllDevice_Conn()
        {
            #region Device Connection & read device connection status
            if (!pass)
            {


                var c = ((TextBox)(Auto_Run_Page0.Controls.Find("txt_IniStatus", true)[0]));
                this.BeginInvoke(new Action(() => { c.Text = ""; }));
                this.BeginInvoke(new Action(() => { c.Text += "Motion Controller...\r\n"; }));

                aCS_Motion.controller_Connection(configWR.ReadSettings("AcsIP"), true); // true = TCP    
                var acs_con_ststus = aCS_Motion._ACS.GetConnectionsList().Count();

                if (acs_con_ststus > 0)
                    this.BeginInvoke(new Action(() => { c.Text += ("connection successful!\r\n"); }));
                else
                    this.BeginInvoke(new Action(() => { c.Text += ("connection failed!\r\n"); }));

                var efem_con_status = eFEM.Connect();
                this.BeginInvoke(new Action(() => { c.Text += "Equipment Front End Module...\r\n"; }));
                if (eFEM.client.IsConnected)
                {
                    this.BeginInvoke(new Action(() => { c.Text += ("connection successful!\r\n"); }));
                    eFEM.receive_update += EFEM_receive_update;
                }
                else
                    this.BeginInvoke(new Action(() => { c.Text += ("connection failed!\r\n"); }));

                cML.Connect();
                this.BeginInvoke(new Action(() => { c.Text += "Electric Cylinder...\r\n"; }));
                var cml_con_status = cML.Connect();
                cML.receive_update += CML_receive_update;
                if (cml_con_status)
                    this.BeginInvoke(new Action(() => { c.Text += ("connection successful!\r\n"); }));
                else
                    this.BeginInvoke(new Action(() => { c.Text += ("connection failed!\r\n"); }));

                //------pass
                this.BeginInvoke(new Action(() => { c.Text += "Laser Controller...\r\n"; }));
                if (!pass)
                {


                    if (configWR.ReadSettings("CL3000_IP") != string.Empty && configWR.ReadSettings("CL3000_Port") != string.Empty)
                    {
                        //this.BeginInvoke(new Action(() => { keyence._OpenEthernetCommunication(); }));
                        keyence._OpenEthernetCommunication();
                        Thread.Sleep(1000);
                    }


                    var key_con_status = keyence.Get_Connection_status();

                    if (key_con_status != "No connection")
                        this.BeginInvoke(new Action(() => { c.Text += ("connection successful!\r\n"); }));
                    else
                        this.BeginInvoke(new Action(() => { c.Text += ("connection failed!\r\n"); }));
                }



                Cognex.Connect();
                this.BeginInvoke(new Action(() => { c.Text += "Wafer ID Reader...\r\n"; }));
                if (Cognex.client.IsConnected)
                {
                    this.BeginInvoke(new Action(() => { c.Text += ("connection successful!\r\n"); }));
                    Cognex.client.Events.DataReceived += Diameter_Monitor.Events_DataReceived;
                }
                else
                    this.BeginInvoke(new Action(() => { c.Text += ("connection failed!\r\n"); }));


                RetryUntilSuccessOrTimeout(mutiCam.UpdateDeviceList, TimeSpan.FromSeconds(60));
                var cma_con_status = mutiCam.OpenAllCam();
                if (cma_con_status[2])
                    this.BeginInvoke(new Action(() => { c.Text += ("Light Controller...\r\n" + "connection successful!\r\n"); }));
                else
                    this.BeginInvoke(new Action(() => { c.Text += ("Light Controller...\r\n" + "connection failed!\r\n"); }));
                if (cma_con_status[0])
                    this.BeginInvoke(new Action(() => { c.Text += ("Cam1...\r\n" + "connection successful!\r\n"); }));
                else
                    this.BeginInvoke(new Action(() => { c.Text += ("Cam1...\r\n" + "connection failed!\r\n"); }));
                if (cma_con_status[1])
                    this.BeginInvoke(new Action(() => { c.Text += ("Cam2...\r\n" + "connection successful!\r\n"); }));
                else
                    this.BeginInvoke(new Action(() => { c.Text += ("Cam2...\r\n" + "connection failed!\r\n"); }));

                db = new LiteDatabase(@"RecData.db");

                #endregion
                //什麼條件可以進行系統初始化?
                if (acs_con_ststus >= 1 && cml_con_status == true && efem_con_status == true && cma_con_status[0] == true && cma_con_status[1] == true)//
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        btn_System_Initial.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                        btn_System_Initial.Enabled = true;
                        btn_System_Initial.Visible = true;
                        btn_System_Initial.BringToFront();
                        btn_Home.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                        btn_Home.Enabled = false;
                        btn_Home.Visible = false;
                        btn_Home.BringToFront();
                    }));
                    return true;
                }
                else
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        btn_System_Initial.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                        btn_System_Initial.Enabled = false;
                        btn_System_Initial.Visible = false;
                        btn_System_Initial.BringToFront();
                        btn_Home.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                        btn_Home.Enabled = true;
                        btn_Home.Visible = true;
                        btn_Home.BringToFront();
                    }));
                    return false;
                }
            }
            else
            {
                db = new LiteDatabase(@"RecData.db");
                return true;
            }
        }



        bool sys_Ini()
        {
            if (!pass)
            {


                var msg = "";
                this.BeginInvoke(new Action(() => { Progres_update(true, 15, "Initial HOME"); }));
                d_Param.D300 = 1;

                this.BeginInvoke(new Action(() => { lb_progress.Text = "EFEM Status"; }));
                if (!eFEM._Paser._EFEM_Status.Send_Cmd(eFEM.client))
                {
                    MessageBox.Show("E001\r\n" + "GetStatus,EFEM\r\n", "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

                //IO MPS Red Light ON out7
                this.BeginInvoke(new Action(() => { lb_progress.Text = "Stop_LG_C3"; }));
                aCS_Motion._ACS.SetOutput(1, 7, 1);
                // laser off
                aCS_Motion._ACS.SetOutput(1, 8, 1);
                aCS_Motion._ACS.SetOutput(1, 8, 1);
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

                this.BeginInvoke(new Action(() => { lb_progress.Text = "SignalTower,EFEM,ALL,OFF"; }));
                eFEM._Paser._SignalTower_Status.color = SignalTower_Color.All;
                eFEM._Paser._SignalTower_Status.state = SignalTower_State.Off;
                if (!eFEM._Paser._SignalTower_Status.Send_Cmd(eFEM.client))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

                eFEM._Paser._SignalTower_Status.color = SignalTower_Color.Green;
                eFEM._Paser._SignalTower_Status.state = SignalTower_State.Flash;
                this.BeginInvoke(new Action(() => { lb_progress.Text = "SignalTower,EFEM,Green,Flash"; }));
                if (!eFEM._Paser._SignalTower_Status.Send_Cmd(eFEM.client))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

                this.BeginInvoke(new Action(() => { lb_progress.Text = "ResetError,Loadport1"; }));
                eFEM._Paser._Reset_Error_LoadPort.portNum = LoadPortNum.Loadport1;
                if (!eFEM._Paser._Reset_Error_LoadPort.Send_Cmd(eFEM.client))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));


                this.BeginInvoke(new Action(() => { lb_progress.Text = "ResetError,Loadport2"; }));
                eFEM._Paser._Reset_Error_LoadPort.portNum = LoadPortNum.Loadport2;
                if (!eFEM._Paser._Reset_Error_LoadPort.Send_Cmd(eFEM.client))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));



                this.BeginInvoke(new Action(() => { lb_progress.Text = "ResetError,Loadport3"; }));
                eFEM._Paser._Reset_Error_LoadPort.portNum = LoadPortNum.Loadport3;
                if (!eFEM._Paser._Reset_Error_LoadPort.Send_Cmd(eFEM.client))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));



                this.BeginInvoke(new Action(() => { lb_progress.Text = "ResetError,Aligner1"; }));
                if (!eFEM._Paser._Reset_Error_Aligner.Send_Cmd(eFEM.client))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    MessageBox.Show("E014\r\n" + "ResetError,Aligner1\r\n" + eFEM._Paser._Aligner_Status.Cmd_Error +
                           "\r\n" + eFEM._Paser._Aligner_Status.Mode, "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));


                this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,EFEM"; }));

                if (!eFEM._Paser._EFEM_Status.Send_Cmd(eFEM.client))
                {

                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    MessageBox.Show(msg + "\r\nE001" + "GetStatus,EFEM", "Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (eFEM._Paser._EFEM_Status.EMG != 1 ||
                    eFEM._Paser._EFEM_Status.FFU_Pressure != 1 ||
                    eFEM._Paser._EFEM_Status.EFEM_PositivePressure != 1 ||
                    eFEM._Paser._EFEM_Status.EFEM_NegativePressure != 1 ||
                    eFEM._Paser._EFEM_Status.Ionizer != 1 ||
                    eFEM._Paser._EFEM_Status.Light_Curtain != 1 ||
                    eFEM._Paser._EFEM_Status.FFU != 1 ||
                    eFEM._Paser._EFEM_Status.OperationMode != 1 ||
                    eFEM._Paser._EFEM_Status.RobotEnable != 1 ||
                    eFEM._Paser._EFEM_Status.Door != 1)
                {
                    MessageBox.Show(msg);
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

                //IO MPS IN9 (PG2-PS)----pass
                this.BeginInvoke(new Action(() => { lb_progress.Text = "PG2-PS"; }));
                if (!pass && !Wait_IO_Check(0, 1, 9, 1, IO_timeout))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    MessageBox.Show("E007" + "PG2-PS OFF", "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));
                //IO MPS IN10 (PG3-VS)----pass
                this.BeginInvoke(new Action(() => { lb_progress.Text = "PG3-VS"; }));
                if (!pass && !Wait_IO_Check(0, 1, 10, 1, IO_timeout))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    MessageBox.Show("E008\r\n" + "PG3-VS OFF", "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

                this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,Robot"; }));
                if (!eFEM._Paser._Robot_Status.Send_Cmd(eFEM.client))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    return false;
                }
                if (eFEM._Paser._Robot_Status.UpPresence != "Absence")
                {
                    MessageBox.Show("E031\r\n" + "GetStatus,Robot,UpPresence\r\n" + eFEM._Paser._Robot_Status.UpPresence, "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (eFEM._Paser._Robot_Status.LowPresence != "Absence")
                {
                    MessageBox.Show("E032\r\n" + "GetStatus,Robot,LowPresence\r\n" + eFEM._Paser._Robot_Status.LowPresence, "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (eFEM._Paser._Robot_Status.UpPresence != "Absence" || eFEM._Paser._Robot_Status.LowPresence != "Absence")
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

                if (!eFEM._Paser._Aligner_Status.Send_Cmd(eFEM.client))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    return false;
                }
                if (eFEM._Paser._Aligner_Status.WaferPresence != "Absence")
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    MessageBox.Show("E033\r\n" + "GetStatus,Aligner1,WaferPresence\r\n" + eFEM._Paser._Aligner_Status.WaferPresence, "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

                this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,Loadport1"; }));
                eFEM._Paser._Loadport_Status.portNum = LoadPortNum.Loadport1;
                if (!eFEM._Paser._Loadport_Status.Send_Cmd(eFEM.client))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    return false;
                }
                this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,Loadport2"; }));

                eFEM._Paser._Loadport_Status.portNum = LoadPortNum.Loadport2;
                if (!eFEM._Paser._Loadport_Status.Send_Cmd(eFEM.client))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    return false;
                }
                this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,Loadport3"; }));

                eFEM._Paser._Loadport_Status.portNum = LoadPortNum.Loadport3;
                if (!eFEM._Paser._Loadport_Status.Send_Cmd(eFEM.client))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    return false;
                }

                this.BeginInvoke(new Action(() => { progresBar.Increment(3); }));

                //IO MPS IN10=ON (PG3-VS)----pass
                this.BeginInvoke(new Action(() => { lb_progress.Text = "PG3-VS"; }));
                if (!pass && !Wait_IO_Check(0, 1, 10, 1, IO_timeout))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    MessageBox.Show("E008\r\n" + "PG3-VS OFF", "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

                //IO MPS OUT5=ON (VC_ON_C1 ON)----pass
                this.BeginInvoke(new Action(() => { lb_progress.Text = "VC_ON_C1"; }));
                aCS_Motion._ACS.SetOutput(1, 5, 1);
                Thread.Sleep(10);
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

                this.BeginInvoke(new Action(() => { lb_progress.Text = "DMWAFER"; }));
                //----pass
                if (!pass && (!DMWAFER(ref d_Param.D110)))
                {
                    Thread.Sleep(5);
                    if (d_Param.D110 != 0 || d_Param.D110 != 4)
                    {
                        this.BeginInvoke(new Action(() => { Progres_update(false); }));
                        MessageBox.Show("E056", "DMWAFER", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));
                //IO MPS OUT5=OFF (VC_ON_C1 ON)
                this.BeginInvoke(new Action(() => { lb_progress.Text = "VC_ON_C1"; }));
                aCS_Motion._ACS.SetOutput(1, 5, 0);
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));
                this.BeginInvoke(new Action(() => { Progres_update(false); }));

                return true;
            }
            else
            {
                return true;
            }
        }

        private bool sys_Home()
        {
            if (!pass)
            {


                this.BeginInvoke(new Action(() => { Progres_update(true, 15, "System Home"); }));

                d_Param.D300 = 2;
                this.BeginInvoke(new Action(() => { lb_progress.Text = eFEM.EFEM_Cmd; }));
                if (!eFEM._Paser._Home_Cmd.Send_Cmd(eFEM.client))
                {
                    MessageBox.Show("E161\r\n" + eFEM._Paser._Home_Cmd.ErrorCode, "Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.BeginInvoke(new Action(() =>
                    {
                        Progres_update(false);
                    }));
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

                //IO MPS IN0=ON 
                this.BeginInvoke(new Action(() => { lb_progress.Text = "IOMps_IN0,IOMps_IN1,IOMps_IN2,IOMps_IN3 Check"; }));
                var IN0_chk = Wait_IO_Check(0, 1, 0, 1, IO_timeout);
                var IN1_chk = Wait_IO_Check(0, 1, 1, 1, IO_timeout);
                var IN2_chk = Wait_IO_Check(0, 1, 2, 1, IO_timeout);
                var IN3_chk = Wait_IO_Check(0, 1, 3, 1, IO_timeout);
                var msg = string.Empty;
                if (!IN0_chk || !IN1_chk || !IN2_chk || !IN3_chk)
                {
                    if (!IN0_chk)
                        msg += "IOMps_IN0 OFF\r\n";
                    else
                        this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));
                    if (!IN1_chk)
                        msg += "IOMps_IN1 OFF\r\n";
                    else
                        this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));
                    if (!IN2_chk)
                        msg += "IOMps_IN2 OFF\r\n";
                    else
                        this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));
                    if (!IN3_chk)
                        msg += "IOMps_IN3 OFF\r\n";
                    else
                        this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

                    MessageBox.Show("E167\r\n" + msg, "Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.BeginInvoke(new Action(() =>
                    {
                        Progres_update(false);
                    }));
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(3); }));
                this.BeginInvoke(new Action(() => { lb_progress.Text = "TN-XY Servo ON?\r" + "TN-Z Servo ON?\r" + "DM-DD Servo ON?\r"; }));
                cML.Query("?99");
                Wait_Cm1_Received_Update();
                var cm1_en = false;

                if (cML.recData != "Ux.1=8")
                {
                    cm1_en = false;
                }
                else
                {
                    cm1_en = true;
                }
                msg = string.Empty;
                if (!aCS_Motion.x_En || !aCS_Motion.y_En || !cm1_en)
                {
                    if (!aCS_Motion.x_En)
                        msg += "TN-X Servo OFF\r\n";
                    if (!aCS_Motion.y_En)
                        msg += "TN-Y Servo OFF\r\n";
                    if (!cm1_en)
                        msg += "TN-Z Servo OFF\r\n";
                    MessageBox.Show("E010\r\n" + msg, "Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!aCS_Motion.a_En)
                        MessageBox.Show("E011\r\n" + "DM-DD Servo OFF\r\n", "Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.BeginInvoke(new Action(() =>
                    {
                        Progres_update(false);
                    }));
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(3); }));

                this.BeginInvoke(new Action(() => { lb_progress.Text = "TN-Z Home..."; }));
                //Z軸歸Home
                cML.Origin();
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

                this.BeginInvoke(new Action(() => { lb_progress.Text = "TN-Z Home check..."; }));
                //IN5---->pass
                if (!pass && !Wait_IO_Check(0, 0, 5, 1, TimeSpan.FromMinutes(3)))
                {
                    MessageBox.Show("E165\r\n" + "Z_ULS OFF\r\n", "Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.BeginInvoke(new Action(() =>
                    {
                        Progres_update(false);
                    }));
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));
                home_end_flag[0] = false;
                home_end_flag[1] = false;
                home_end_flag[2] = false;
                this.BeginInvoke(new Action(() => { lb_progress.Text = "TN-X Home...\r\n" + "TN-Y Home...\r\n" + "DM-DD Home..."; }));
                //X軸歸Home
                aCS_Motion._ACS.Command("#3X");
                Thread.Sleep(3000);
                //Y軸歸Home
                aCS_Motion._ACS.Command("#2X");
                Thread.Sleep(3000);
                //A軸歸Home
                aCS_Motion._ACS.Command("#1X");
                Thread.Sleep(3000);
                Wait_XYA_Home_End("", 120000);
                //Thread.Sleep(3000);
                if (!home_end_flag[0] || !home_end_flag[1] || !home_end_flag[2] ||
                    Math.Round(aCS_Motion.m_X_lfFPos, 1) != 0.0 || Math.Round(aCS_Motion.m_Y_lfFPos, 1) != 0.0 || Math.Round(aCS_Motion.m_A_lfFPos, 1) != 0.0 ||
                    !aCS_Motion.x_Inp || !aCS_Motion.y_Inp || !aCS_Motion.a_Inp)
                {
                    if (!home_end_flag[0] || !home_end_flag[1])
                        msg += "E164\r\n" + "TN-XY Home Error\r\n";
                    if (!home_end_flag[2])
                        msg += "E166\r\n" + "DM-DD Home Error\r\n";
                    else msg += "E166\r\n" + "Exception\r\n";
                    this.BeginInvoke(new Action(() =>
                    {
                        MessageBox.Show(msg, "Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                    //MessageBox.Show(msg, "Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(3); }));
                d_Param.D110 = 4;
                this.BeginInvoke(new Action(() => { lb_progress.Text = "MOVE TO (XL,YL)..."; }));
                //TN-XY move to XL,YL
                aCS_Motion._ACS.Command("PTP/v (0,1)," + configWR.ReadSettings("XL") + "," + configWR.ReadSettings("YL") + ",100");
                Thread.Sleep(1000);
                wait_axis_Inp("x", 100000);
                wait_axis_Inp("y", 100000);
                this.BeginInvoke(new Action(() => { progresBar.Increment(2); }));



                this.BeginInvoke(new Action(() => { lb_progress.Text = "XN1_ON..."; }));
                //OUT8
                aCS_Motion._ACS.SetOutput(1, 8, 0);
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

                this.BeginInvoke(new Action(() => { lb_progress.Text = "Check X_LS..."; }));
                if (!Wait_IO_Check(0, 0, 0, 1, IO_timeout))
                {
                    MessageBox.Show("X_LS IN0 not on", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.BeginInvoke(new Action(() =>
                    {
                        Progres_update(false);
                    }));

                    return false;
                }

                if (!Wait_IO_Check(0, 0, 1, 1, IO_timeout))
                {
                    MessageBox.Show("Y_LS IN1 not on", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.BeginInvoke(new Action(() =>
                    {
                        Progres_update(false);
                    }));

                    return false;
                }

                this.BeginInvoke(new Action(() => { lb_progress.Text = "TNWAFER..."; }));
                //-------pass
                if (!pass && (!TNWAFER(ref d_Param.D111) || d_Param.D111 != 4))
                {
                    MessageBox.Show("E058", "Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.BeginInvoke(new Action(() =>
                    {
                        Progres_update(false);
                    }));

                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

                this.BeginInvoke(new Action(() => { lb_progress.Text = "XN1_ON OFF..."; }));
                //OUT8
                aCS_Motion._ACS.SetOutput(1, 8, 0);
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

                this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,EFEM"; }));
                if (!eFEM._Paser._EFEM_Status.Send_Cmd(eFEM.client))
                {
                    MessageBox.Show(msg + "\r\nE012" + "GetStatus,EFEM", "Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    return false;
                }
                if (eFEM._Paser._EFEM_Status.EMG != 1 ||
                   eFEM._Paser._EFEM_Status.FFU_Pressure != 1 ||
                   eFEM._Paser._EFEM_Status.EFEM_PositivePressure != 1 ||
                   eFEM._Paser._EFEM_Status.EFEM_NegativePressure != 1 ||
                   eFEM._Paser._EFEM_Status.Ionizer != 1 ||
                   eFEM._Paser._EFEM_Status.Light_Curtain != 1 ||
                   eFEM._Paser._EFEM_Status.FFU != 1 ||
                   eFEM._Paser._EFEM_Status.OperationMode != 1 ||
                   eFEM._Paser._EFEM_Status.RobotEnable != 1 ||
                   eFEM._Paser._EFEM_Status.Door != 1)
                {
                    MessageBox.Show(msg);
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));


                this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,Robot"; }));
                if (!eFEM._Paser._Robot_Status.Send_Cmd(eFEM.client))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    return false;
                }

                if (eFEM._Paser._Robot_Status.UpPresence != "Absence")
                {
                    MessageBox.Show("E031\r\n" + "GetStatus,Robot,UpPresence\r\n" + eFEM._Paser._Robot_Status.UpPresence, "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (eFEM._Paser._Robot_Status.LowPresence != "Absence")
                {
                    MessageBox.Show("E032\r\n" + "GetStatus,Robot,LowPresence\r\n" + eFEM._Paser._Robot_Status.LowPresence, "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (eFEM._Paser._Robot_Status.UpPresence != "Absence" || eFEM._Paser._Robot_Status.LowPresence != "Absence")
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        Progres_update(false);
                    }));
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));


                this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,Loadport1"; }));
                eFEM._Paser._Loadport_Status.portNum = LoadPortNum.Loadport1;
                if (!eFEM._Paser._Loadport_Status.Send_Cmd(eFEM.client))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    return false;
                }

                this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,Loadport2"; }));
                eFEM._Paser._Loadport_Status.portNum = LoadPortNum.Loadport2;
                if (!eFEM._Paser._Loadport_Status.Send_Cmd(eFEM.client))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    return false;
                }


                this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,Loadport3"; }));
                eFEM._Paser._Loadport_Status.portNum = LoadPortNum.Loadport3;
                if (!eFEM._Paser._Loadport_Status.Send_Cmd(eFEM.client))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    return false;
                }


                this.BeginInvoke(new Action(() => { progresBar.Increment(3); }));

                this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,Aligner1"; }));
                if (!eFEM._Paser._Aligner_Status.Send_Cmd(eFEM.client))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    return false;
                }
                if (eFEM._Paser._Aligner_Status.WaferPresence != "Absence")
                {
                    MessageBox.Show("E033\r\n" + "GetStatus,Aligner1,WaferPresence\r\n" + eFEM._Paser._Aligner_Status.WaferPresence, "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.BeginInvoke(new Action(() =>
                    {
                        Progres_update(false);
                    }));
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));



                this.BeginInvoke(new Action(() => { lb_progress.Text = "Set RobotSpeed"; }));
                if (!eFEM._Paser._RobotSpeed_Set_Cmd.Send_Cmd(eFEM.client))
                {
                    MessageBox.Show("E161\r\n" + eFEM._Paser._RobotSpeed_Set_Cmd.ErrorCode, "Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.BeginInvoke(new Action(() =>
                    {
                        Progres_update(false);
                    }));
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));


                this.BeginInvoke(new Action(() => { lb_progress.Text = "SignalTower,EFEM,All,Off"; }));
                eFEM._Paser._SignalTower_Status.color = SignalTower_Color.All;
                eFEM._Paser._SignalTower_Status.state = SignalTower_State.Off;
                if (!eFEM._Paser._SignalTower_Status.Send_Cmd(eFEM.client))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

                this.BeginInvoke(new Action(() => { lb_progress.Text = "SignalTower,EFEM,Green,ON"; }));
                eFEM._Paser._SignalTower_Status.color = SignalTower_Color.Green;
                eFEM._Paser._SignalTower_Status.state = SignalTower_State.On;
                if (!eFEM._Paser._SignalTower_Status.Send_Cmd(eFEM.client))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));
                this.BeginInvoke(new Action(() => { Progres_update(false); }));

                return true;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="D110"></param>
        /// <returns></returns>
        public bool DMWAFER(ref int D110)
        {
            try
            {
                var IN3 = aCS_Motion._ACS.GetInput(1, 3);
                var IN8 = aCS_Motion._ACS.GetInput(1, 8);
                var IN10 = aCS_Motion._ACS.GetInput(1, 10);
                aCS_Motion._ACS.SetOutput(1, 5, 1);
                var OUT5 = aCS_Motion._ACS.GetOutput(1, 5);
                var a_in_load_pos = ((Convert.ToDouble(aCS_Motion.m_A_lfFPos) - Convert.ToDouble(configWR.ReadSettings("AL")) < 2));
                if (IN10 == 1 && OUT5 == 1)
                {
                    switch (IN8)
                    {
                        case 0:
                            switch (IN3)
                            {
                                case 0:
                                    if (a_in_load_pos)
                                    {
                                        D110 = 2;
                                    }
                                    else
                                    {
                                        D110 = 4;//OK 3
                                    }
                                    break;
                                case 1:
                                    if (a_in_load_pos)
                                    {
                                        D110 = 0;//OK 1
                                    }
                                    else
                                    {
                                        D110 = 2;
                                    }
                                    break;
                            }
                            break;
                        case 1:
                            switch (IN3)
                            {
                                case 0:
                                    if (a_in_load_pos)
                                    {
                                        D110 = 2;
                                    }
                                    else
                                    {
                                        D110 = 5;//OK 4
                                    }
                                    break;
                                case 1:
                                    if (a_in_load_pos)
                                    {
                                        D110 = 1;//OK 2
                                    }
                                    else
                                    {
                                        D110 = 0;
                                    }
                                    break;
                            }
                            break;
                    }
                }
                else
                {
                    D110 = 2;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="D111"></param>
        /// <returns></returns>
        public bool TNWAFER(ref int D111)
        {
            try
            {
                this.BeginInvoke(new Action(() => { lb_progress.Text = "XN1_ON ON..."; }));
                //OUT8
                aCS_Motion._ACS.SetOutput(1, 8, 0);
                Thread.Sleep(1000);
                var OUT8 = aCS_Motion._ACS.GetOutput(1, 8);
                var IN0 = aCS_Motion._ACS.GetInput(0, 0);
                var IN1 = aCS_Motion._ACS.GetInput(1, 1);
                var IN2 = aCS_Motion._ACS.GetInput(0, 2);
                var IN6 = aCS_Motion._ACS.GetInput(1, 6);
                var xy_in_load_pos = (Math.Round(aCS_Motion.m_X_lfFPos, 1) - Convert.ToDouble(configWR.ReadSettings("XL")) < 2 &&
                    Math.Round(aCS_Motion.m_Y_lfFPos, 1) - Convert.ToDouble(configWR.ReadSettings("YL")) < 2);
                cML.Query("?96");
                Wait_Cm1_Received_Update();
                //當前位置回傳格式未檢查----待修正                
                var z_in_load_pos = (cML.recData == "Px.1=" + configWR.ReadSettings("ZL"));
                if (OUT8 == 0 && IN0 == 1 && IN1 == 1 && xy_in_load_pos)
                {
                    switch (IN6)
                    {
                        case 0:
                            if (z_in_load_pos)
                            {
                                switch (IN2)
                                {
                                    case 0:
                                        D111 = 2;
                                        break;
                                    case 1:
                                        D111 = 0;
                                        break;
                                }
                            }
                            else
                            {
                                switch (IN2)
                                {
                                    case 0:
                                        D111 = 4;
                                        break;
                                    case 1:
                                        D111 = 2;
                                        break;
                                }
                            }
                            break;
                        case 1:
                            if (z_in_load_pos)
                            {
                                switch (IN2)
                                {
                                    case 0:
                                        D111 = 2;
                                        break;
                                    case 1:
                                        D111 = 1;
                                        break;
                                }
                            }
                            else
                            {
                                switch (IN2)
                                {
                                    case 0:
                                        D111 = 5;
                                        break;
                                    case 1:
                                        D111 = 2;
                                        break;
                                }
                            }
                            break;
                    }
                    return true;
                }
                else
                {
                    D111 = 2;
                    return true;
                }
            }
            catch (Exception)
            {
                D111 = 2;
                return false;
            }
        }
        /// <summary>
        /// color:Red,Green,Blue,Yellow,ALL
        /// mode->0:OFF,1:ON,2:Flash
        /// </summary>
        /// <param name="color"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public bool EFEM_Light_Control(string color, int mode, string ex_title)
        {
            try
            {
                eFEM._Paser._SignalTower_Status.Cmd_Error = "";
                switch (mode)
                {
                    case 0:
                        eFEM.EFEM_Cmd = "SignalTower,EFEM," + color + ",Off";
                        break;
                    case 1:
                        eFEM.EFEM_Cmd = "SignalTower,EFEM," + color + ",On";
                        break;
                    case 2:
                        eFEM.EFEM_Cmd = "SignalTower,EFEM," + color + ",Flash";
                        break;
                }
                eFEM.EFEM_Send();
                Wait_eFEM_Received_Update(efem_timeout);
                if (eFEM._Paser._SignalTower_Status.Cmd_Error != "OK")
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    MessageBox.Show("W001\r\n" + eFEM.EFEM_Cmd + "\r\n" + eFEM._Paser._SignalTower_Status.ErrorCode, ex_title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception)
            {

                return false;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Loadport"></param>
        /// <param name="ex_title"></param>
        /// <returns></returns>
        public bool Get_EFEM_LoadPort_Status(LoadPortNum Loadport, string ex_title, bool show_error)
        {
            try
            {
                eFEM._Paser._Loadport_Status.portNum = Loadport;
                if (!eFEM._Paser._Loadport_Status.Send_Cmd(eFEM.client))
                {
                    if (show_error)
                        MessageBox.Show("_Loadport_Status\r\n" + eFEM._Paser._Loadport_Status.Cmd_Error, "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (eFEM._Paser._Loadport_Status.Error != "NoError")
                {
                    if (show_error)
                        MessageBox.Show("_Loadport_Status\r\n" + eFEM._Paser._Loadport_Status.Error, "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                //switch (Loadport)
                //{
                //    case 1:
                //        eFEM.EFEM_Cmd = "GetStatus,Loadport1";
                //        eFEM._Paser._Loadport_Status.Cmd_Error = "";
                //        eFEM._Paser._Loadport_Status.Mode = "";
                //        eFEM._Paser._Loadport_Status.Error = "";
                //        eFEM._Paser._Loadport_Status.ErrorCode = "";
                //        eFEM.EFEM_Send();
                //        Wait_eFEM_Received_Update(efem_timeout);
                //        if (eFEM._Paser._Loadport_Status.Cmd_Error != "OK")
                //        {
                //            if (show_error)
                //                MessageBox.Show("E015\r\n" + "_Loadport1_Status\r\n" + eFEM._Paser._Loadport_Status.Cmd_Error, "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            return false;
                //        }
                //        if (eFEM._Paser._Loadport_Status.Error != "NoError")
                //        {
                //            if (show_error)
                //                MessageBox.Show("E037\r\n" + "_Loadport1_Status\r\n" + eFEM._Paser._Loadport_Status.Error, "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            return false;
                //        }

                //        break;
                //    case 2:
                //        eFEM.EFEM_Cmd = "GetStatus,Loadport2";
                //        eFEM._Paser._Loadport_Status.Cmd_Error = "";
                //        eFEM._Paser._Loadport_Status.Mode = "";
                //        eFEM._Paser._Loadport_Status.Error = "";
                //        eFEM._Paser._Loadport_Status.ErrorCode = "";
                //        eFEM.EFEM_Send();
                //        Wait_eFEM_Received_Update(efem_timeout);
                //        if (eFEM._Paser._Loadport_Status.Cmd_Error != "OK")
                //        {
                //            if (show_error)
                //                MessageBox.Show("E016\r\n" + "_Loadport2_Status\r\n" + eFEM._Paser._Loadport_Status.Cmd_Error, "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            return false;
                //        }
                //        if (eFEM._Paser._Loadport_Status.Error != "NoError")
                //        {
                //            if (show_error)
                //                MessageBox.Show("E038\r\n" + "_Loadport2_Status\r\n" + eFEM._Paser._Loadport_Status.Error, "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            return false;
                //        }

                //        break;
                //    case 3:
                //        eFEM.EFEM_Cmd = "GetStatus,Loadport3";
                //        eFEM._Paser._Loadport_Status.Cmd_Error = "";
                //        eFEM._Paser._Loadport_Status.Mode = "";
                //        eFEM._Paser._Loadport_Status.Error = "";
                //        eFEM._Paser._Loadport_Status.ErrorCode = "";
                //        eFEM.EFEM_Send();
                //        Wait_eFEM_Received_Update(efem_timeout);
                //        if (eFEM._Paser._Loadport_Status.Cmd_Error != "OK")
                //        {
                //            MessageBox.Show("E017\r\n" + "_Loadport3_Status\r\n" + eFEM._Paser._Loadport_Status.Cmd_Error, "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            return false;
                //        }
                //        if (eFEM._Paser._Loadport_Status.Error != "NoError")
                //        {
                //            MessageBox.Show("E039\r\n" + "_Loadport2_Status\r\n" + eFEM._Paser._Loadport_Status.Error, "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            return false;
                //        }

                //        break;
                //}
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex_title"></param>
        /// <returns></returns>
        public bool Get_Aligner_Status(string ex_title)
        {
            try
            {
                if (!eFEM._Paser._Aligner_Status.Send_Cmd(eFEM.client) || eFEM._Paser._Aligner_Status.Mode != "Online")
                {

                    if (eFEM._Paser._Aligner_Status.Cmd_Error != "OK")
                    {
                        MessageBox.Show(eFEM._Paser._Aligner_Status.Cmd_Error);
                    }
                    if (eFEM._Paser._Aligner_Status.Mode != "Online")
                    {
                        MessageBox.Show(eFEM._Paser._Aligner_Status.Mode);
                    }
                    return false;
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex_title"></param>
        /// <returns></returns>
        public bool Get_Robot_Status(string ex_title)
        {
            try
            {
                eFEM.EFEM_Cmd = "GetStatus,Robot";
                eFEM._Paser._Robot_Status.Cmd_Error = "";
                eFEM.EFEM_Send();
                Wait_eFEM_Received_Update(efem_timeout);
                if (eFEM._Paser._Robot_Status.Cmd_Error != "OK")
                {
                    MessageBox.Show("E013\r\n" + "GetStatus,Robot\r\n" + eFEM._Paser._Robot_Status.ErrorCode, ex_title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="Loadport"></param>
        /// <param name="ex_title"></param>
        /// <returns></returns>
        public bool Reset_EFEM_LoadPort(LoadPortNum Loadport, string ex_title)
        {
            try
            {
                eFEM._Paser._Reset_Error_LoadPort.portNum = Loadport;
                if (!eFEM._Paser._Reset_Error_LoadPort.Send_Cmd(eFEM.client))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    MessageBox.Show("ResetError,Loadport1\r\n" + eFEM._Paser._Reset_Error_LoadPort.Cmd_Error, ex_title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }





        }

        public bool UnLoad_EFEM_LoadPort(LoadPortNum Loadport, string ex_title)
        {
            try
            {
                eFEM._Paser._Cmd_Loadport.cmdString = LoadportCmdString.Unload;
                eFEM._Paser._Cmd_Loadport.portNum = Loadport;
                if (!eFEM._Paser._Cmd_Loadport.Send_Cmd(eFEM.client))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    MessageBox.Show(eFEM.EFEM_Cmd + "\r\n" + eFEM._Paser._Cmd_Loadport.Cmd_Error, ex_title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }





        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex_title"></param>
        /// <returns></returns>
        public bool Reset_Aligner(string ex_title)
        {
            eFEM.EFEM_Cmd = "ResetError,Aligner1";
            eFEM._Paser._Reset_Error_Aligner.Cmd_Error = "";
            eFEM.EFEM_Send();
            Wait_eFEM_Received_Update(efem_timeout);
            if (eFEM._Paser._Reset_Error_Aligner.Cmd_Error != "OK")
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("ResetError,Aligner1\r\n" + eFEM._Paser._Reset_Error_Aligner.Cmd_Error, ex_title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool Get_EFEM_Status(ref string msg)
        {
            try
            {
                eFEM.EFEM_Cmd = "GetStatus,EFEM";
                eFEM._Paser._EFEM_Status.Cmd_Error = "";
                eFEM.EFEM_Send();
                Wait_eFEM_Received_Update(efem_timeout);
                if (eFEM._Paser._EFEM_Status.Cmd_Error != "OK")
                {
                    msg += "Cmd Error\r\n";
                    return false;
                }
                switch (eFEM._Paser._EFEM_Status.EMG)
                {
                    case 0:
                        msg += "EMO\r\n";
                        break;
                    case 1:
                        msg += "No EMO\r\n";
                        break;
                    case 9:
                        msg += "Unknown\r\n";
                        break;
                }
                switch (eFEM._Paser._EFEM_Status.FFU_Pressure)
                {
                    case 0:
                        msg += "PD too high\r\n";
                        break;
                    case 1:
                        msg += "PD Normal\r\n";
                        break;
                    case 9:
                        msg += "PD Unknown\r\n";
                        break;
                }
                switch (eFEM._Paser._EFEM_Status.EFEM_PositivePressure)
                {
                    case 0:
                        msg += "Positive Pressure not in setting range\r\n";
                        break;
                    case 1:
                        msg += "Positive Pressure Normal\r\n";
                        break;
                    case 9:
                        msg += "Positive Pressure Unknown\r\n";
                        break;
                }
                switch (eFEM._Paser._EFEM_Status.EFEM_NegativePressure)
                {
                    case 0:
                        msg += "Negative Pressure not in setting range\r\n";
                        break;
                    case 1:
                        msg += "Negative Pressure Normal\r\n";
                        break;
                    case 9:
                        msg += "Negative Pressure Unknown\r\n";
                        break;
                }
                switch (eFEM._Paser._EFEM_Status.Ionizer)
                {
                    case 1:
                        msg += "Ionizer Normal\r\n";
                        break;
                    case 2:
                        msg += "Ionizer Error Code 1005\r\n";
                        break;
                    case 3:
                        msg += "Ionizer Error Code 1006\r\n";
                        break;
                    case 4:
                        msg += "Ionizer Error Code 1007\r\n";
                        break;
                    case 9:
                        msg += "Ionizer Unknown\r\n";
                        break;
                }
                switch (eFEM._Paser._EFEM_Status.Light_Curtain)
                {
                    case 0:
                        msg += "Light Curtain Invalid\r\n";
                        break;
                    case 1:
                        msg += "Light Curtain Valid\r\n";
                        break;
                    case 9:
                        msg += "Light Curtain Unknown\r\n";
                        break;
                }
                switch (eFEM._Paser._EFEM_Status.FFU)
                {
                    case 1:
                        msg += "FFU Normal\r\n";
                        break;
                    case 2:
                        msg += "FFU Error Code 2001\r\n";
                        break;
                    case 3:
                        msg += "FFU Error Code 2002\r\n";
                        break;
                    case 4:
                        msg += "FFU Error Code 2003\r\n";
                        break;
                    case 5:
                        msg += "FFU Error Code 2004\r\n";
                        break;
                    case 6:
                        msg += "FFU Error Code 2005\r\n";
                        break;
                    case 7:
                        msg += "FFU Error Code 2006\r\n";
                        break;
                    case 8:
                        msg += "FFU Error Code 2007\r\n";
                        break;
                    case 9:
                        msg += "FFU Unknown\r\n";
                        break;
                }
                switch (eFEM._Paser._EFEM_Status.OperationMode)
                {
                    case 0:
                        msg += "Operation Mode Local\r\n";
                        break;
                    case 1:
                        msg += "Operation Mode Remote\r\n";
                        break;
                    case 9:
                        msg += "Operation ModeUnknown\r\n";
                        break;
                }
                switch (eFEM._Paser._EFEM_Status.RobotEnable)
                {
                    case 0:
                        msg += "Robot Disable\r\n";
                        break;
                    case 1:
                        msg += "Robot Enable\r\n";
                        break;
                    case 9:
                        msg += "RobotEnable Unknown\r\n";
                        break;
                }
                switch (eFEM._Paser._EFEM_Status.Door)
                {
                    case 0:
                        msg += "Door Open\r\n";
                        break;
                    case 1:
                        msg += "Door Close\r\n";
                        break;
                    case 9:
                        msg += "Unknown\r\n";
                        break;
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public CancellationTokenSource eFEM_Received_Update_tokenSource = new CancellationTokenSource();
        public void Wait_eFEM_Received_Update(int timeout)
        {
            CancellationToken cancellationToken = eFEM_Received_Update_tokenSource.Token;
            var t = Task.Run(() =>
            {
                while (!eFEM_Received_Update)
                {

                    if (eFEM_Received_Update_tokenSource.IsCancellationRequested)
                    {
                        break;
                    }
                    Thread.Sleep(5);
                }
                eFEM_Received_Update = false;
            }, cancellationToken);
            if (!t.Wait(efem_timeout))
            {
                MessageBox.Show("Timeout", "EFEM");
                eFEM_Received_Update = false;
                return;
            }
        }

        private void EFEM_receive_update(object sender, EventArgs e)
        {
            eFEM_Received_Update = true;
        }

        public void Wait_Cm1_Received_Update()
        {
            var t = Task.Run(() =>
            {
                while (!cm1_Received_Update)
                {
                    Thread.Sleep(5);
                }
                cm1_Received_Update = false;
            });
            if (!t.Wait(efem_timeout))
            {
                MessageBox.Show("Timeout", "CM1");
                cm1_Received_Update = false;
                return;
            }
        }

        public void _EFMM_SendChk(string cmd)
        {
            switch (cmd)
            {
                case "":
                    break;
            }
            var t = Task.Run(() =>
            {


            });
            if (!t.Wait(efem_timeout))
            {
                MessageBox.Show("Timeout", "EFEM");

                return;
            }
        }



        private void CML_receive_update(object sender, EventArgs e)
        {
            cm1_Received_Update = true;
        }
        int end_bufferNo = 0;
        private void _ACS_PROGRAMEND(ACS.SPiiPlusNET.BufferMasks buffer)
        {
            int bit = 0x01;
            end_bufferNo = 0;
            // Param value is bit number 
            // Bit Number = Axis Number
            for (int i = 0; i < 32; i++)
            {
                if ((int)buffer == bit)
                {
                    end_bufferNo = i;
                    break;
                }
                bit = bit << 1;
            }
            if (end_bufferNo == 1)
                home_end_flag[0] = true;
            if (end_bufferNo == 2)
                home_end_flag[1] = true;
            if (end_bufferNo == 3)
                home_end_flag[2] = true;
            if (end_bufferNo == Convert.ToInt32(configWR.ReadSettings("Mprog_8")))
                measure_end_flag[0] = true;
            if (end_bufferNo == Convert.ToInt32(configWR.ReadSettings("Mprog_12")))
                measure_end_flag[1] = true;
            //measure_end_flag
            PROGRAMEND_Status_Update = true;
        }


        public void Wait_XYA_Home_End(string msg, int timeout)
        {
            var t = Task.Run(() =>
            {
                while (!home_end_flag[0] || !home_end_flag[1] || !home_end_flag[2])
                {
                    Thread.Sleep(5);
                }
            });
            if (!t.Wait(efem_timeout))
            {
                MessageBox.Show("Timeout", "PROGRAMEND");
                return;
            }
        }

        public void wait_axis_Inp(string Axis, int timeout)
        {
            var t = Task.Run(() =>
            {
                switch (Axis)
                {
                    case "x":
                        while (!aCS_Motion.x_Inp) { Thread.Sleep(5); }
                        break;
                    case "y":
                        while (!aCS_Motion.y_Inp) { Thread.Sleep(5); }
                        break;
                    case "a":
                        while (!aCS_Motion.a_Inp) { Thread.Sleep(5); }
                        break;
                }
            });
            if (!t.Wait(timeout))
            {
                MessageBox.Show("Timeout", "ACS");
                return;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode">0:IN 1:OUT</param>
        /// <param name="port">Port</param>       
        /// <param name="bit">Bit</param>
        /// <param name="value"> Target value</param>
        /// <param name="timeout">Time Out</param>
        /// <returns></returns>
        public bool Wait_IO_Check(int mode, int port, int bit, int value, TimeSpan timeout)
        {
            var t = Task.Run(() =>
            {
                switch (mode)
                {
                    case 0:
                        while (aCS_Motion._ACS.GetInput(port, bit) != value)
                        {
                            Thread.Sleep(5);
                        }
                        break;
                    case 1:
                        while (aCS_Motion._ACS.GetOutput(port, bit) != value)
                        {
                            Thread.Sleep(5);
                        }
                        break;
                }

            });

            if (!t.Wait(timeout))
            {
                MessageBox.Show("Timeout", "IO MPS");
                return false;
            }
            return true;

        }




        private void AutoRunPage_Switch_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            switch (b.Name)
            {
                case "btn_Go_Page2":
                    Auto_Run_Page1.Hide();
                    Auto_Run_Page2.Show();
                    break;
                case "btn_Go_Page1":
                    Auto_Run_Page2.Hide();
                    Auto_Run_Page1.Show();
                    break;
            }

        }

        private void MaintainanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            switch (item.Name)
            {
                case "aCSToolStripMenuItem":
                    aCS_Motion.Show();
                    break;
                case "keyenceToolStripMenuItem":
                    keyence.Show();
                    break;
                case "cognexToolStripMenuItem":
                    Cognex.Show();
                    break;
                case "eFEMToolStripMenuItem":
                    eFEM.Show();
                    break;
                case "cm1ToolStripMenuItem":
                    cML.Show();
                    break;
                case "baslerToolStripMenuItem":
                    mutiCam.Show();
                    break;
            }
        }
        private void MonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            switch (item.Name)
            {
                case "EFEM_ToolStripMenuItem":
                    EFEM_Monitor.Show();
                    break;
                case "MorphToolStripMenuItem":
                    Morph_Monitor.Show();
                    break;
                case "DiameterToolStripMenuItem":
                    Diameter_Monitor.Show();
                    break;
            }
        }
        private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            switch (item.Name)
            {
                case "SystemSettingToolStripMenuItem":
                    System_Setting_Form.Show();
                    break;
            }
        }
        private void ReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report_Form.Show();
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            aCS_Motion.ACSClose();
            keyence.KeyenceClose();
            mutiCam.MutiCamClose();
            Cognex.CognexClose();
        }

        TimeSpan timeout = TimeSpan.FromSeconds(10);
        public static bool RetryUntilSuccessOrTimeout(Func<bool> task, TimeSpan timeout)
        {
            bool success = false;
            int elapsed = 0;

            while ((!success) && (elapsed < timeout.TotalMilliseconds))
            {
                Thread.Sleep(1000); // 等待 1 秒
                elapsed += 1000;
                success = task();
            }

            return success;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            configWR.WriteSettings("K1", "KK");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var t = Task.Run(() =>
            {
                eFEM._Paser._EFEM_Status.Send_Cmd(eFEM.client);
            });
            var k = Task.Run(() =>
            {
                eFEM._Paser._SignalTower_Status.color = SignalTower_Color.Yellow;
                eFEM._Paser._SignalTower_Status.state = SignalTower_State.Flash;
                eFEM._Paser._SignalTower_Status.Send_Cmd(eFEM.client);
            });


            var u = true;
        }

       
    }
}
