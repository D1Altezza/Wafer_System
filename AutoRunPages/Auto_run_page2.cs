using ACS_DotNET_Library_Advanced_Demo;
using CL3_IF_DllSample;
using Cool_Muscle_CML_Example;
using LiteDB;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wafer_System.BaslerMutiCam;
using Wafer_System.Config_Fun;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Wafer_System.Auto_run_page1;
using static Wafer_System.Main;
using ProgressBar = System.Windows.Forms.ProgressBar;



namespace Wafer_System
{
    public partial class Auto_run_page2 : Form
    {
        Main main;
        private Cognex cognex;
        ProgressBar progresBar = new ProgressBar();
        Label lb_progress = new Label();
        Label lb_progress_Title = new Label();
        ConfigWR configWR;
        private MutiCam mutiCam;
        //IF DM done TN_recID=DM_recID
        int DM_recID = 0, TN_recID = 0;
        public Auto_run_page1.Autorun_Prarm autorun_Prarm;
        Bitmap[] eight_bp = new Bitmap[3];
        Bitmap[] tweleve_bp = new Bitmap[3];
        EdgeDetect detect = new EdgeDetect();
        public Auto_run_page2(Main main, MutiCam mutiCam, Cognex cognex, Autorun_Prarm autorun_Prarm, ConfigWR configWR)
        {
            InitializeComponent();
            this.main = main;
            this.mutiCam = mutiCam;
            this.cognex = cognex;
            this.autorun_Prarm = autorun_Prarm;
            this.configWR = configWR;
            cognex.receive_update += Cognex_receive_update;
        }



        private void Auto_run_page2_Load(object sender, EventArgs e)
        {
            #region Splash
            progresBar.Step = 1;
            progresBar.Width = 500;
            progresBar.Location = new System.Drawing.Point(panel.Width / 2 - progresBar.Width / 2, panel.Height / 2 - progresBar.Height / 2);
            progresBar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            progresBar.Maximum = 150;
            panel.Controls.Add(progresBar);
            lb_progress.Location = new System.Drawing.Point(progresBar.Location.X, progresBar.Location.Y + progresBar.Height);
            lb_progress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lb_progress.BackColor = System.Drawing.SystemColors.Control;
            lb_progress.Font = new Font("Consolas", 11.25F);//Consolas, 11.25pt
            lb_progress.AutoSize = true;
            //lb_progress.Width = 500;
            panel.Controls.Add(lb_progress);
            lb_progress_Title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lb_progress_Title.BackColor = System.Drawing.SystemColors.Control;
            lb_progress_Title.Font = new Font("Consolas", 11.25F);//Consolas, 11.25pt
            lb_progress_Title.AutoSize = true;
            lb_progress_Title.Location = new System.Drawing.Point(progresBar.Location.X, progresBar.Location.Y - lb_progress_Title.Height);
            panel.Controls.Add(lb_progress_Title);
            lb_progress_Title.BringToFront();
            progresBar.BringToFront();
            lb_progress.BringToFront();
            lb_progress_Title.Visible = false;
            progresBar.Visible = false;
            lb_progress.Visible = false;
            #endregion
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            var ini = false;
            var start_chk = Task.Run(() =>
            {
                ini = Auto_run_chk();
            }).ContinueWith(task =>
            {
                if (ini && MessageBox.Show("Run?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Auto_run();
                    //home = sys_Home();
                }


            });

        }



        private bool Auto_run_chk()
        {
            this.BeginInvoke(new Action(() => { Progres_update(true, 20, "AutoRun Check"); }));
            //Start 燈號亮起 out6
            this.BeginInvoke(new Action(() => { lb_progress.Text = "Stop_LG_C2"; }));
            main.aCS_Motion._ACS.SetOutput(1, 6, 1);
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));


            this.BeginInvoke(new Action(() => { lb_progress.Text = "SignalTower,EFEM,ALL,OFF"; }));
            main.eFEM._Paser._SignalTower_Status.color = SignalTower_Color.All;
            main.eFEM._Paser._SignalTower_Status.state = SignalTower_State.Off;
            if (!main.eFEM._Paser._SignalTower_Status.Send_Cmd(main.eFEM.client))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "SignalTower,EFEM,Blue,ON"; }));
            main.eFEM._Paser._SignalTower_Status.color = SignalTower_Color.Blue;
            main.eFEM._Paser._SignalTower_Status.state = SignalTower_State.On;
            if (!main.eFEM._Paser._SignalTower_Status.Send_Cmd(main.eFEM.client))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));
            main.d_Param.D300 = 4;

            //設定量測參數         
            main.eFEM._Paser._AlignmentAngle_Set_Cmd.Degree = "0";
            if (!main.eFEM._Paser._AlignmentAngle_Set_Cmd.Send_Cmd(main.eFEM.client))
            {
                MessageBox.Show(main.eFEM._Paser._AlignmentAngle_Set_Cmd.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = main.eFEM.EFEM_Cmd; }));
            main.eFEM._Paser._WaferType_Set_Cmd.waferType = autorun_Prarm.waferType;
            if (!main.eFEM._Paser._WaferType_Set_Cmd.Send_Cmd(main.eFEM.client))
            {
                MessageBox.Show(main.eFEM._Paser._WaferType_Set_Cmd.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = main.eFEM.EFEM_Cmd; }));
            main.eFEM._Paser._WaferMode_Set_Cmd.waferMode = autorun_Prarm.waferMode;
            if (!main.eFEM._Paser._WaferMode_Set_Cmd.Send_Cmd(main.eFEM.client))
            {
                MessageBox.Show(main.eFEM._Paser._WaferMode_Set_Cmd.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));


            this.BeginInvoke(new Action(() => { lb_progress.Text = main.eFEM.EFEM_Cmd; }));
            switch (autorun_Prarm.wafer_Size)
            {
                case Wafer_Size.eight:
                    main.eFEM._Paser._WaferSize_Set_Cmd.Size = "8";
                    break;
                case Wafer_Size.tweleve:
                    main.eFEM._Paser._WaferSize_Set_Cmd.Size = "12";
                    break;
                case Wafer_Size.unknow:
                    break;
                default:
                    break;
            }
            if (!main.eFEM._Paser._WaferSize_Set_Cmd.Send_Cmd(main.eFEM.client))
            {
                MessageBox.Show(main.eFEM._Paser._WaferSize_Set_Cmd.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));


            this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,EFEM"; }));

            var msg = "";
            if (!main.eFEM._Paser._EFEM_Status.Send_Cmd(main.eFEM.client))
            {

                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show(msg + "\r\nE001" + "GetStatus,EFEM", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (main.eFEM._Paser._EFEM_Status.EMG != 1 ||
                main.eFEM._Paser._EFEM_Status.FFU_Pressure != 1 ||
                main.eFEM._Paser._EFEM_Status.EFEM_PositivePressure != 1 ||
                main.eFEM._Paser._EFEM_Status.EFEM_NegativePressure != 1 ||
                main.eFEM._Paser._EFEM_Status.Ionizer != 1 ||
                main.eFEM._Paser._EFEM_Status.Light_Curtain != 1 ||
                main.eFEM._Paser._EFEM_Status.FFU != 1 ||
                main.eFEM._Paser._EFEM_Status.OperationMode != 1 ||
                main.eFEM._Paser._EFEM_Status.RobotEnable != 1 ||
                main.eFEM._Paser._EFEM_Status.Door != 1)
            {
                MessageBox.Show(msg);
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "ResetError,Loadport1"; }));
            main.eFEM._Paser._Reset_Error_LoadPort.portNum = LoadPortNum.Loadport1;
            if (!main.eFEM._Paser._Reset_Error_LoadPort.Send_Cmd(main.eFEM.client))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "ResetError,Loadport2"; }));
            main.eFEM._Paser._Reset_Error_LoadPort.portNum = LoadPortNum.Loadport2;
            if (!main.eFEM._Paser._Reset_Error_LoadPort.Send_Cmd(main.eFEM.client))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "ResetError,Loadport3"; }));
            main.eFEM._Paser._Reset_Error_LoadPort.portNum = LoadPortNum.Loadport3;
            if (!main.eFEM._Paser._Reset_Error_LoadPort.Send_Cmd(main.eFEM.client))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }

            this.BeginInvoke(new Action(() => { lb_progress.Text = "ResetError,Aligner1"; }));
            if (!main.eFEM._Paser._Reset_Error_Aligner.Send_Cmd(main.eFEM.client))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("ResetError,Aligner1\r\n" + main.eFEM._Paser._Aligner_Status.Cmd_Error +
                       "\r\n" + main.eFEM._Paser._Aligner_Status.Mode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            //IO MPS IN9 (PG2-PS)----pass
            this.BeginInvoke(new Action(() => { lb_progress.Text = "PG2-PS"; }));
            if (!main.pass && !main.Wait_IO_Check(0, 1, 9, 1, main.IO_timeout))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E007" + "PG2-PS OFF", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));
            //IO MPS IN10 (PG3-VS)----pass
            this.BeginInvoke(new Action(() => { lb_progress.Text = "PG3-VS"; }));
            if (!main.pass && !main.Wait_IO_Check(0, 1, 10, 1, main.IO_timeout))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E008\r\n" + "PG3-VS OFF", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,Robot"; }));

            if (!main.eFEM._Paser._Robot_Status.Send_Cmd(main.eFEM.client))
            {
                MessageBox.Show("E013\r\n" + "GetStatus,Robot\r\n" + main.eFEM._Paser._Robot_Status.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }
            if (main.eFEM._Paser._Robot_Status.UpPresence != "Absence")
            {
                MessageBox.Show("E031\r\n" + "GetStatus,Robot,UpPresence\r\n" + main.eFEM._Paser._Robot_Status.UpPresence, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (main.eFEM._Paser._Robot_Status.LowPresence != "Absence")
            {
                MessageBox.Show("E032\r\n" + "GetStatus,Robot,LowPresence\r\n" + main.eFEM._Paser._Robot_Status.LowPresence, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (main.eFEM._Paser._Robot_Status.UpPresence != "Absence" || main.eFEM._Paser._Robot_Status.LowPresence != "Absence")
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            if (!main.eFEM._Paser._Aligner_Status.Send_Cmd(main.eFEM.client) || main.eFEM._Paser._Aligner_Status.Mode != "Online")
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E014\r\n" + "GetStatus,Aligner1\r\n" + main.eFEM._Paser._Aligner_Status.Mode + "\r\n" +
                    main.eFEM._Paser._Aligner_Status.Cmd_Error + "\r\n" +
                    main.eFEM._Paser._Aligner_Status.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (main.eFEM._Paser._Aligner_Status.WaferPresence != "Absence")
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E033\r\n" + "GetStatus,Aligner1,WaferPresence\r\n" + main.eFEM._Paser._Aligner_Status.WaferPresence, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            main.d_Param.D102 = 0;
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));


            this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,Loadport1"; }));
            main.eFEM._Paser._Loadport_Status.portNum = LoadPortNum.Loadport1;
            if (!main.eFEM._Paser._Loadport_Status.Send_Cmd(main.eFEM.client))
            {
                MessageBox.Show("Error GetStatus,Loadport1\r\n");
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }

            if (main.eFEM._Paser._Loadport_Status.Foup != "Presence")
            {
                MessageBox.Show("E040\r\n" + "GetStatus,Loadport1\r\n" + main.eFEM._Paser._Loadport_Status.Foup);
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }

            this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,Loadport2"; }));
            main.eFEM._Paser._Loadport_Status.portNum = LoadPortNum.Loadport2;
            if (!main.eFEM._Paser._Loadport_Status.Send_Cmd(main.eFEM.client))
            {
                MessageBox.Show("Error GetStatus,Loadport2\r\n");
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }

            if (main.eFEM._Paser._Loadport_Status.Foup != "Presence")
            {
                MessageBox.Show("E041\r\n" + "GetStatus,Loadport2\r\n" + main.eFEM._Paser._Loadport_Status.Foup);
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }
            this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,Loadport3"; }));
            main.eFEM._Paser._Loadport_Status.portNum = LoadPortNum.Loadport3;
            if (!main.eFEM._Paser._Loadport_Status.Send_Cmd(main.eFEM.client))
            {
                MessageBox.Show("Error GetStatus,Loadport3\r\n");
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }
            if (main.eFEM._Paser._Loadport_Status.Foup != "Presence")
            {
                MessageBox.Show("E042\r\n" + "GetStatus,Loadport3\r\n" + main.eFEM._Paser._Loadport_Status.Foup);
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(3); }));

            //EFEMOUT2 OFF----pass
            this.BeginInvoke(new Action(() => { lb_progress.Text = "PG3-VS"; }));
            if (!main.pass && !main.Wait_IO_Check(0, 1, 1, 1, main.IO_timeout))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E167\r\n" + "EFEMOUT2 OFF", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));



            this.BeginInvoke(new Action(() => { lb_progress.Text = "MOVE TO AL..."; }));
            //DM-DD move to A0
            //PTP/V 2,500,1000
            main.aCS_Motion._ACS.Command("PTP/v 2," + configWR.ReadSettings("AL") + "," + configWR.ReadSettings("DD_Vel"));
            Thread.Sleep(1000);
            main.wait_axis_Inp("z", 100000);

            this.BeginInvoke(new Action(() => { progresBar.Increment(2); }));


            var a_in_load_pos = (main.aCS_Motion.m_A_lfFPos == Convert.ToDouble(configWR.ReadSettings("AL")));
            this.BeginInvoke(new Action(() => { lb_progress.Text = "A_LS(CMnt_IN3)"; }));
            if (!main.pass && !main.Wait_IO_Check(0, 1, 3, 1, TimeSpan.FromMinutes(2)) || !a_in_load_pos)
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E172\r\n" + "DM_DD Pos Error\r\n", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));


            //IO MPS IN10 (PG3-VS)----pass
            this.BeginInvoke(new Action(() => { lb_progress.Text = "PG3-VS"; }));
            if (!main.pass && !main.Wait_IO_Check(0, 1, 10, 1, main.IO_timeout))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E008\r\n" + "PG3-VS OFF", "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            //IO MPS OUT5=ON (VC_ON_C1 ON)----pass
            this.BeginInvoke(new Action(() => { lb_progress.Text = "VC_ON_C1"; }));
            main.aCS_Motion._ACS.SetOutput(1, 5, 1);
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "DMWAFER"; }));
            //----pass
            if (!main.pass && (!main.DMWAFER(ref main.d_Param.D110) || main.d_Param.D110 != 0))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E056", "DMWAFER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));
            //IO MPS OUT5=OFF (VC_ON_C1 ON)
            this.BeginInvoke(new Action(() => { lb_progress.Text = "VC_ON_C1"; }));
            main.aCS_Motion._ACS.SetOutput(1, 5, 0);
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));
            //this.BeginInvoke(new Action(() => { Progres_update(false); }));



            //EFEMOUT3 OFF----pass
            this.BeginInvoke(new Action(() => { lb_progress.Text = "EFEMOUT3"; }));
            if (!main.pass && !main.Wait_IO_Check(0, 1, 2, 1, main.IO_timeout))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E167\r\n" + "EFEMOUT3 OFF", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            this.BeginInvoke(new Action(() => { lb_progress.Text = "Check Z in orgin"; }));
            //當前位置回傳格式未檢查----待修正       
            main.cML.Query("?96.1");
            main.Wait_Cm1_Received_Update();
            var z_in_zero_pos = (main.cML.recData == "Px.1=" + configWR.ReadSettings("Z0"));
            if (!z_in_zero_pos)
            {
                MessageBox.Show("E175\r\n" + "Z not in org pos", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));

                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "MOVE TO (XL,YL)..."; }));
            //TN-XY move to XL,YL
            main.aCS_Motion._ACS.Command("PTP/v (0,1)," + configWR.ReadSettings("XL") + "," + configWR.ReadSettings("YL") + ",100");
            Thread.Sleep(1000);
            main.wait_axis_Inp("x", 100000);
            main.wait_axis_Inp("y", 100000);
            this.BeginInvoke(new Action(() => { progresBar.Increment(2); }));


            this.BeginInvoke(new Action(() => { lb_progress.Text = "TNWAFER..."; }));
            //-------pass
            if (!main.pass && (!main.TNWAFER(ref main.d_Param.D111) || main.d_Param.D111 != 4))
            {
                MessageBox.Show("E058", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));

                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "XN1_ON OFF..."; }));
            //OUT8
            main.aCS_Motion._ACS.SetOutput(1, 8, 0);
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "XN2_ON ON..."; }));
            //OUT9 打開雷射
            main.aCS_Motion._ACS.SetOutput(1, 9, 1);
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "Check Pin not exist..."; }));
            if (!main.pass && !Chek_XY_pin_status())
            {
                MessageBox.Show("E049", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));

                return false;
            }

            this.BeginInvoke(new Action(() => { lb_progress.Text = "MOVE TO (XL,YL)..."; }));
            //TN-XY move to XL,YL
            main.aCS_Motion._ACS.Command("PTP/v (0,1)," + configWR.ReadSettings("XL") + "," + configWR.ReadSettings("YL") + ",100");
            Thread.Sleep(1000);
            main.wait_axis_Inp("x", 100000);
            main.wait_axis_Inp("y", 100000);
            this.BeginInvoke(new Action(() => { progresBar.Increment(2); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "Check XY in load position..."; }));
            Thread.Sleep(1000);
            var xy_in_load_pos = (Math.Round(main.aCS_Motion.m_X_lfFPos, 2) == Convert.ToDouble(configWR.ReadSettings("XL")) &&
                   Math.Round(main.aCS_Motion.m_Y_lfFPos, 2) == Convert.ToDouble(configWR.ReadSettings("YL")));
            if (!xy_in_load_pos)
            {
                MessageBox.Show("E173\r\n" + "X,Y not in load postion", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));

                return false;
            }
            this.BeginInvoke(new Action(() => { lb_progress.Text = "Check X_LS ON..."; }));
            if (!main.Wait_IO_Check(0, 0, 0, 1, TimeSpan.FromMinutes(2)))
            {
                MessageBox.Show("E173\r\n" + "X_LS CMnT_IN0 not on", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));

                return false;
            }
            this.BeginInvoke(new Action(() => { lb_progress.Text = "Check Y_LS ON..."; }));
            if (!main.Wait_IO_Check(0, 0, 1, 1, TimeSpan.FromMinutes(2)))
            {
                MessageBox.Show("E173" + "Y_LS CMnT_IN1 not on", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));

                return false;
            }

            this.BeginInvoke(new Action(() => { lb_progress.Text = "Pin UP..."; }));
            main.cML.pin_Up();
            if (!main.Wait_IO_Check(0, 0, 2, 1, TimeSpan.FromMinutes(2)))
            {
                MessageBox.Show("Z_LS IN2 not on", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));

                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));
            this.BeginInvoke(new Action(() => { lb_progress.Text = "Check Z in load pos..."; }));
            Thread.Sleep(1000);
            main.cML.Query("?96.1");
            main.Wait_Cm1_Received_Update();
            Thread.Sleep(1000);
            main.cML.Query("?96.1");
            main.Wait_Cm1_Received_Update();
            //當前位置回傳格式未檢查----待修正                                   
            var z_in_load_pos = (main.cML.recData == "Px.1=" + configWR.ReadSettings("ZL"));
            if (!z_in_load_pos)
            {
                MessageBox.Show("E175\r\n" + "Z not in looad pos", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));

                return false;
            }


            this.BeginInvoke(new Action(() => { lb_progress.Text = "TNWAFER..."; }));
            //-------pass
            if (!main.pass && (!main.TNWAFER(ref main.d_Param.D111)) && main.d_Param.D111 != 0)
            {
                MessageBox.Show("E058", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));

                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "XN1_ON OFF..."; }));
            //OUT8
            main.aCS_Motion._ACS.SetOutput(1, 8, 0);
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "Load LoadPort1..."; }));
            main.eFEM._Paser._Cmd_Loadport.portNum = LoadPortNum.Loadport1;
            main.eFEM._Paser._Cmd_Loadport.cmdString = LoadportCmdString.Load;
            if (!main.eFEM._Paser._Cmd_Loadport.Send_Cmd(main.eFEM.client))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E043\r\n" + "Load,Loadport1\r\n" + main.eFEM._Paser._Cmd_Loadport.Cmd_Error + "\r\n" + main.eFEM._Paser._Cmd_Loadport.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            this.BeginInvoke(new Action(() => { lb_progress.Text = "Load LoadPort2..."; }));
            main.eFEM._Paser._Cmd_Loadport.portNum = LoadPortNum.Loadport2;
            main.eFEM._Paser._Cmd_Loadport.cmdString = LoadportCmdString.Load;
            if (!main.eFEM._Paser._Cmd_Loadport.Send_Cmd(main.eFEM.client))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E044\r\n" + "Load,Loadport2\r\n" + main.eFEM._Paser._Cmd_Loadport.Cmd_Error + "\r\n" + main.eFEM._Paser._Cmd_Loadport.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            this.BeginInvoke(new Action(() => { lb_progress.Text = "Load LoadPort3..."; }));
            main.eFEM._Paser._Cmd_Loadport.portNum = LoadPortNum.Loadport3;
            main.eFEM._Paser._Cmd_Loadport.cmdString = LoadportCmdString.Load;
            if (!main.eFEM._Paser._Cmd_Loadport.Send_Cmd(main.eFEM.client))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E045\r\n" + "Load,Loadport3\r\n" + main.eFEM._Paser._Cmd_Loadport.Cmd_Error + "\r\n" + main.eFEM._Paser._Cmd_Loadport.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }





            this.BeginInvoke(new Action(() => { lb_progress.Text = "Get Current LPWaferSize Loadport1..."; }));
            main.eFEM._Paser._GetCurrentLPWaferSize.portNum = LoadPortNum.Loadport1;
            if (!main.eFEM._Paser._GetCurrentLPWaferSize.Send_Cmd(main.eFEM.client) || main.eFEM._Paser._GetCurrentLPWaferSize.Result != autorun_Prarm.wafer_Size.ToString())
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E046\r\n" + "GetCurrentLPWaferSize,Loadport1\r\n" + main.eFEM._Paser._GetCurrentLPWaferSize.Cmd_Error +
                    "\r\n" + main.eFEM._Paser._GetCurrentLPWaferSize.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            this.BeginInvoke(new Action(() => { lb_progress.Text = "Get Current LPWaferSize Loadport2..."; }));
            main.eFEM._Paser._GetCurrentLPWaferSize.portNum = LoadPortNum.Loadport2;
            if (!main.eFEM._Paser._GetCurrentLPWaferSize.Send_Cmd(main.eFEM.client) || main.eFEM._Paser._GetCurrentLPWaferSize.Result != autorun_Prarm.wafer_Size.ToString())
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E047\r\n" + "GetCurrentLPWaferSize,Loadport2\r\n" + main.eFEM._Paser._GetCurrentLPWaferSize.Cmd_Error +
                    "\r\n" + main.eFEM._Paser._GetCurrentLPWaferSize.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            this.BeginInvoke(new Action(() => { lb_progress.Text = "Get Current LPWaferSize Loadport3..."; }));
            main.eFEM._Paser._GetCurrentLPWaferSize.portNum = LoadPortNum.Loadport3;
            if (!main.eFEM._Paser._GetCurrentLPWaferSize.Send_Cmd(main.eFEM.client) || main.eFEM._Paser._GetCurrentLPWaferSize.Result != autorun_Prarm.wafer_Size.ToString())
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E047\r\n" + "GetCurrentLPWaferSize,Loadport3\r\n" + main.eFEM._Paser._GetCurrentLPWaferSize.Cmd_Error +
                    "\r\n" + main.eFEM._Paser._GetCurrentLPWaferSize.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            this.BeginInvoke(new Action(() => { Progres_update(false); progresBar.Hide(); }));
            return true;
        }


        public string[] cassett1_status = new string[25];
        public string[] cassett2_status = new string[25];
        public string[] cassett3_status = new string[25];
        Task<bool> an_run, dm_run, tn_run;
        private bool Auto_run()
        {
            this.BeginInvoke(new Action(() => { lb_progress.Text = "Check D400=0..."; }));
            if (main.d_Param.D400 == 0)
            {
                this.BeginInvoke(new Action(() => { Progres_update(true, 20, "AutoRun "); }));
                this.BeginInvoke(new Action(() => { lb_progress.Text = "Mapping Cassette1..."; }));
                if (!MappingCassette(LoadPortNum.Loadport1, out cassett1_status))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    MessageBox.Show("MappingCassette(1) Fail", "AutoRun ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                this.BeginInvoke(new Action(() => { lb_progress.Text = "Mapping Cassette2..."; }));
                if (!MappingCassette(LoadPortNum.Loadport2, out cassett2_status))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    MessageBox.Show("MappingCassette(2) Fail", "AutoRun ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                this.BeginInvoke(new Action(() => { lb_progress.Text = "Mapping Cassette3..."; }));
                if (!MappingCassette(LoadPortNum.Loadport3, out cassett3_status))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    MessageBox.Show("MappingCassette(3) Fail", "AutoRun ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //Step5
                this.BeginInvoke(new Action(() => { lb_progress.Text = "Set D300=5..."; }));
                main.d_Param.D300 = 5;
                this.BeginInvoke(new Action(() => { lb_progress.Text = "Check D100=0 D400=0..."; }));
                if (main.d_Param.D100 != 0 || main.d_Param.D400 != 0)
                {
                    MessageBox.Show("UAgetLP1 Fail D100!=0 or D400!=0");
                    return false;

                }
                else
                {
                    this.BeginInvoke(new Action(() => { lb_progress.Text = "UAgetLP1..."; }));
                    if (!UAgetLP1() || main.d_Param.D100 != 1)
                    {
                        MessageBox.Show("UAgetLP1 Fail");
                        return false;
                    }
                    else
                    {
                        //Step6
                        main.d_Param.D300 = 6;
                        if (main.d_Param.D100 != 1 || main.d_Param.D102 != 0 || main.d_Param.D131 != 0)
                        {
                            MessageBox.Show("Step 6 Fail", "Error");
                            return false;

                        }
                        else
                        {
                            this.BeginInvoke(new Action(() => { lb_progress.Text = "UAgetLP1..."; }));
                            if (!UAputAN())
                            {
                                MessageBox.Show("UAputAN Fail", "Error");
                                return false;
                            }
                        }
                        //Step7
                        main.d_Param.D300 = 7;
                        if (main.d_Param.D102 != 1 || main.d_Param.D123 != 0 || main.d_Param.D124 != 0)
                        {
                            MessageBox.Show("Step7 Fail", "Error");
                            return false;
                        }
                        else
                        {
                            this.BeginInvoke(new Action(() => { lb_progress.Text = "UAgetLP1..."; }));

                            an_run = Task<bool>.Run(() =>
                            {
                                if (!ANRUN())
                                {
                                    MessageBox.Show("ANRUN Fail", "Error");
                                    return Task.FromResult(false);
                                }
                                return Task.FromResult(true);
                            });

                        }
                        //Step8
                        main.d_Param.D300 = 8;
                        if (main.d_Param.D100 != 0 || main.d_Param.D400 != 0)
                        {
                            MessageBox.Show("Step8 Fail", "Error");
                            return false;
                        }
                        if (!UAgetLP1() || main.d_Param.D100 != 1)
                        {
                            MessageBox.Show("UAgetLP1 Fail");
                            return false;
                        }
                        //Step9
                        main.d_Param.D300 = 9;
                        if (main.d_Param.D131 != 0 || main.d_Param.D102 != 1 || main.d_Param.D101 != 0 || main.d_Param.D131 != 0)
                        {
                            MessageBox.Show("Step9 Fail", "Error");
                            return false;
                        }
                        if (!LAgetAN() || main.d_Param.D124 != 0 || main.d_Param.D101 != 1 || main.d_Param.D102 != 0)
                        {
                            MessageBox.Show("LAgetAN Fail", "Error");
                            return false;
                        }
                        //Step10
                        main.d_Param.D300 = 10;
                        if (main.d_Param.D100 != 1 || main.d_Param.D102 != 0 || main.d_Param.D131 != 0)
                        {
                            MessageBox.Show("Step10 Fail", "Error");
                            return false;
                        }
                        if (!UAputAN() || main.d_Param.D123 != 0 || main.d_Param.D100 != 0 || main.d_Param.D102 != 1)
                        {
                            MessageBox.Show("UAputAN Fail", "Error");
                            return false;
                        }
                        //Step11
                        main.d_Param.D300 = 11;
                        if (main.d_Param.D102 != 1 || main.d_Param.D123 != 0 || main.d_Param.D124 != 0)
                        {
                            MessageBox.Show("Step11 Fail", "Error");
                            return false;
                        }
                        an_run = Task.Run(() =>
                        {
                            if (!ANRUN())
                            {
                                MessageBox.Show("ANRUN Fail", "Error");
                                return Task.FromResult(false);
                            }
                            return Task.FromResult(true);
                        });
                        //Step12
                        main.d_Param.D300 = 12;
                        if (main.d_Param.D101 != 1 || main.d_Param.D110 != 0 || main.d_Param.D132 != 0)
                        {
                            MessageBox.Show("Step12 Fail", "Error");
                            return false;
                        }
                        if (!LAputDM() || main.d_Param.D125 != 0 || main.d_Param.D101 != 0 || main.d_Param.D110 != 1)
                        {
                            MessageBox.Show("LAputDM Fail", "Error");
                            return false;
                        }
                        //Step13
                        main.d_Param.D300 = 13;
                        if (main.d_Param.D110 != 1 || main.d_Param.D125 != 0 || main.d_Param.D126 != 0)
                        {
                            MessageBox.Show("Step13 Fail", "Error");
                            return false;
                        }
                        //執行外徑量測
                        dm_run = Task.Run(() =>
                        {
                            if (!DMRUN(autorun_Prarm.wafer_Size))
                            {
                                MessageBox.Show("DMRUN Fail", "Error");
                                return Task.FromResult(false);
                            }
                            return Task.FromResult(true);

                        });
                        //Step14
                        main.d_Param.D300 = 14;
                        if (main.d_Param.D100 != 0 || main.d_Param.D400 != 0)
                        {
                            MessageBox.Show("Step14 Fail", "Error");
                            return false;
                        }
                        if (!UAgetLP1() || main.d_Param.D100 != 1)
                        {
                            MessageBox.Show("UAgetLP1 Fail");
                            return false;
                        }
                        //Step15
                        main.d_Param.D300 = 15;
                        if (main.d_Param.D131 != 0 || main.d_Param.D102 != 1 || main.d_Param.D101 != 0)
                        {
                            MessageBox.Show("Step15 Fail", "Error");
                            return false;
                        }
                        if (!LAgetAN() || main.d_Param.D124 != 0 || main.d_Param.D101 != 1 || main.d_Param.D102 != 0)
                        {
                            MessageBox.Show("LAgetAN Fail");
                            return false;
                        }
                        //Step16
                        main.d_Param.D300 = 16;
                        if (main.d_Param.D100 != 1 || main.d_Param.D102 != 0 || main.d_Param.D131 != 0)
                        {
                            MessageBox.Show("Step16 Fail", "Error");
                            return false;
                        }
                        if (!UAputAN() || main.d_Param.D132 != 0 || main.d_Param.D100 != 0 || main.d_Param.D102 != 1)
                        {
                            MessageBox.Show("UAputAN Fail", "Error");
                            return false;
                        }
                        //Step17
                        main.d_Param.D300 = 17;
                        if (main.d_Param.D102 != 1 || main.d_Param.D123 != 0 || main.d_Param.D124 != 0)
                        {
                            MessageBox.Show("Step17 Fail", "Error");
                            return false;
                        }
                        an_run = Task<bool>.Run(() =>
                        {
                            if (!ANRUN())
                            {
                                MessageBox.Show("ANRUN Fail", "Error");
                                return Task.FromResult(false);
                            }
                            return Task.FromResult(true);
                        });
                        //Step18
                        main.d_Param.D300 = 18;
                        if (main.d_Param.D132 != 0 || main.d_Param.D110 != 1 || main.d_Param.D100 != 0)
                        {
                            MessageBox.Show("Step18 Fail", "Error");
                            return false;
                        }
                        if (!UAgetDM() || main.d_Param.D126 != 0 || main.d_Param.D100 != 1 || main.d_Param.D110 != 0)
                        {
                            MessageBox.Show("UAgetDM Fail", "Error");
                            return false;
                        }
                        //Step19
                        main.d_Param.D300 = 19;
                        if (main.d_Param.D101 != 1 || main.d_Param.D110 != 0 || main.d_Param.D132 != 0)
                        {
                            MessageBox.Show("Step19 Fail", "Error");
                            return false;
                        }
                        if (!LAputDM() || main.d_Param.D125 != 0 || main.d_Param.D101 != 0 || main.d_Param.D110 != 1)
                        {
                            MessageBox.Show("LAputDM Fail", "Error");
                            return false;
                        }
                        //Step20
                        main.d_Param.D300 = 20;
                        dm_run = Task.Run(() =>
                        {
                            if (!DMRUN(autorun_Prarm.wafer_Size))
                            {
                                MessageBox.Show("DMRUN Fail", "Error");
                                return Task.FromResult(false);
                            }
                            return Task.FromResult(true);

                        });
                        //Step21 UAputTN()
                        main.d_Param.D300 = 21;
                        if (main.d_Param.D100 != 1 || main.d_Param.D111 != 0 || main.d_Param.D133 != 0)
                        {
                            MessageBox.Show("Step21 fail");
                            return false;
                        }
                        if (!UAputTN() || main.d_Param.D127 != 0 || main.d_Param.D100 != 0 || main.d_Param.D111 != 1)
                        {
                            MessageBox.Show("UAputTN fail");
                        }
                        //Step22 TNRUN
                        main.d_Param.D300 = 22;
                        if (main.d_Param.D111 != 1 || main.d_Param.D127 != 0 || main.d_Param.D128 != 0)
                        {
                            MessageBox.Show("Step22 fail");
                        }
                        //Task.Run(() =>
                        //{
                        //    TNRUN(autorun_Prarm.wafer_Size);
                        //});
                        tn_run = Task<bool>.Run(() =>
                        {
                            if (!TNRUN(autorun_Prarm.wafer_Size))
                            {
                                MessageBox.Show("TNRUN Fail", "Error");
                                return Task.FromResult(false);
                            }
                            return Task.FromResult(true);
                        });
                        //Step23
                        main.d_Param.D300 = 23;
                        if (main.d_Param.D100 != 0 || main.d_Param.D400 != 0)
                        {
                            MessageBox.Show("Step23 fail");
                        }
                        if (!UAgetLP1() || main.d_Param.D122 != 0 || main.d_Param.D100 != 1)
                        {
                            MessageBox.Show("UAgetLP1 Fail");
                            return false;
                        }
                    //Step24
                    Step24:
                        main.d_Param.D300 = 24;
                        if (!CheckCondition(ref main.d_Param.D131, 0, TimeSpan.FromMinutes(2)) ||
                            !CheckCondition(ref main.d_Param.D102, 1, TimeSpan.FromMinutes(2)) ||
                            !CheckCondition(ref main.d_Param.D101, 0, TimeSpan.FromMinutes(2)))
                        {
                            MessageBox.Show("Step24 fail");
                        }
                        if (!LAgetAN() || main.d_Param.D124 != 0 || main.d_Param.D101 != 1 || main.d_Param.D102 != 0)
                        {
                            MessageBox.Show("LAgetAN fail");
                        }
                        //Step25
                        main.d_Param.D300 = 25;
                        if (main.d_Param.D100 != 1 || main.d_Param.D102 != 0 || main.d_Param.D131 != 0)
                        {
                            MessageBox.Show("Step25 fail");
                        }
                        if (!UAputAN() ||
                            main.d_Param.D123 != 0 ||
                            main.d_Param.D100 != 0 ||
                            main.d_Param.D102 != 1)
                        {
                            MessageBox.Show("UAputAN fail");
                        }
                        //Step26
                        main.d_Param.D300 = 26;
                        if (main.d_Param.D102 != 1 ||
                            main.d_Param.D123 != 0 ||
                            main.d_Param.D124 != 0)
                        {
                            MessageBox.Show("Step26 fail");
                        }
                        an_run = Task<bool>.Run(() =>
                        {
                            if (!ANRUN())
                            {
                                MessageBox.Show("ANRUN Fail", "Error");
                                return Task.FromResult(false);
                            }
                            return Task.FromResult(true);
                        });

                        //Step27
                        main.d_Param.D300 = 27;
                        if (!CheckCondition(ref main.d_Param.D132, 0, TimeSpan.FromMinutes(2)) ||
                            !CheckCondition(ref main.d_Param.D110, 1, TimeSpan.FromMinutes(2)))
                        {
                            MessageBox.Show("Step27 fail");
                        }
                        if (!UAgetDM() || main.d_Param.D126 != 0 || main.d_Param.D100 != 1 || main.d_Param.D110 != 0)
                        {
                            MessageBox.Show("UAgetDM Fail", "Error");
                            return false;
                        }
                        //Step28
                        main.d_Param.D300 = 28;

                        if (main.d_Param.D101 != 1 ||
                            main.d_Param.D110 != 0 ||
                            main.d_Param.D132 != 0)
                        {
                            MessageBox.Show("Step28 fail");
                        }
                        if (!LAputDM() || main.d_Param.D125 != 0 || main.d_Param.D101 != 0 || main.d_Param.D110 != 1)
                        {
                            MessageBox.Show("LAputDM Fail", "Error");
                            return false;
                        }

                        //Step29
                        main.d_Param.D300 = 29;
                        if (main.d_Param.D110 != 1 ||
                            main.d_Param.D125 != 0 ||
                            main.d_Param.D126 != 0)
                        {
                            MessageBox.Show("Step29 fail");
                            return false;
                        }

                        dm_run = Task.Run(() =>
                        {
                            if (!DMRUN(autorun_Prarm.wafer_Size))
                            {
                                MessageBox.Show("DMRUN Fail", "Error");
                                return Task.FromResult(false);
                            }
                            return Task.FromResult(true);
                        });
                        //Step30
                        main.d_Param.D300 = 30;
                        if (!CheckCondition(ref main.d_Param.D101, 0, TimeSpan.FromMinutes(3)) ||
                            !CheckCondition(ref main.d_Param.D111, 1, TimeSpan.FromMinutes(3)) ||
                            !CheckCondition(ref main.d_Param.D133, 0, TimeSpan.FromMinutes(3)))
                        {
                            MessageBox.Show("Step30 fail");
                            return false;
                        }

                        if (!LAgetTN() ||
                            main.d_Param.D128 != 0 ||
                            main.d_Param.D101 != 1 ||
                            main.d_Param.D111 != 0)
                        {
                            MessageBox.Show("LAgetTN fail");
                            return false;
                        }
                        //Step31
                        main.d_Param.D300 = 31;
                        if (main.d_Param.D100 != 1 ||
                            main.d_Param.D111 != 0 ||
                            main.d_Param.D133 != 0)
                        {
                            MessageBox.Show("Step31 fail");
                            return false;
                        }
                        if (!UAputTN() ||
                            main.d_Param.D127 != 0 ||
                            main.d_Param.D100 != 0 ||
                            main.d_Param.D111 != 1)
                        {
                            MessageBox.Show("UAputTN fail");
                            return false;
                        }
                        //Step32
                        main.d_Param.D300 = 32;
                        if (main.d_Param.D111 != 1 ||
                            main.d_Param.D127 != 0 ||
                            main.d_Param.D128 != 0)
                        {
                            MessageBox.Show("Step32 fail");
                            return false;
                        }
                        //tn_run = Task<bool>.Run(() =>
                        //{
                        //    if (!TNRUN(autorun_Prarm.wafer_Size))
                        //    {
                        //        MessageBox.Show("TNRUN Fail", "Error");
                        //        return Task.FromResult(false);
                        //    }
                        //    return Task.FromResult(true);
                        //});
                        if (!TNRUN(autorun_Prarm.wafer_Size))
                        {
                            MessageBox.Show("TNRUN Fail", "Error");
                            return false;
                        }
                        //Step33
                        main.d_Param.D300 = 33;
                        if ((main.d_Param.D200 == 0) && (main.d_Param.D201 == 0))
                        {
                            if (!LAputOKLP2())
                            {
                                MessageBox.Show("LAputOKLP2 fail");
                                return false;
                            }

                        }
                        else
                        {
                            if (!LAputNGLP3())
                            {
                                MessageBox.Show("LAputNGLP3 fail");
                                return false;
                            }
                        }
                        //Step34
                        main.d_Param.D300 = 34;
                        if (main.d_Param.D100 != 0 ||
                            main.d_Param.D400 != 0)
                        {
                            //MessageBox.Show("Step34 Fail");
                        }
                        else if (!UAgetLP1() || main.d_Param.D122 != 0 || main.d_Param.D100 != 1)
                        {
                            MessageBox.Show("UAgetLP1 fail");
                        }
                        if (main.d_Param.D100 == 1 ||
                            main.d_Param.D101 == 1 ||
                            main.d_Param.D102 == 1 ||
                            main.d_Param.D110 == 1 ||
                            main.d_Param.D111 == 1)
                        {
                            goto Step24;
                        }
                        else
                        {
                            AutoRun_End();
                            MessageBox.Show("finsh");
                        }
                        return true;
                    }
                }


            }
            else if (main.d_Param.D400 == 1)
            {
                //go end
                AutoRun_End();
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool AutoRun_End()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            main.d_Param.D300 = 35;
            if (!main.UnLoad_EFEM_LoadPort(LoadPortNum.Loadport1, ""))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }
            if (!main.UnLoad_EFEM_LoadPort(LoadPortNum.Loadport2, ""))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }
            if (!main.UnLoad_EFEM_LoadPort(LoadPortNum.Loadport3, ""))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }
            this.BeginInvoke(new Action(() => { lb_progress.Text = main.eFEM.EFEM_Cmd; }));
            if (!main.eFEM._Paser._Home_Cmd.Send_Cmd(main.eFEM.client))
            {
                MessageBox.Show("E161\r\n" + main.eFEM._Paser._Home_Cmd.ErrorCode, "Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));
            main.d_Param.D100 = 3;
            main.d_Param.D101 = 3;
            main.d_Param.D102 = 3;
            main.d_Param.D110 = 3;
            main.d_Param.D111 = 3;
            main.d_Param.D122 = 3;
            main.d_Param.D123 = 3;
            main.d_Param.D124 = 3;
            main.d_Param.D125 = 3;
            main.d_Param.D126 = 3;
            main.d_Param.D127 = 3;
            main.d_Param.D128 = 3;
            main.d_Param.D129 = 3;
            main.d_Param.D130 = 3;
            main.d_Param.D131 = 3;
            main.d_Param.D132 = 3;
            main.d_Param.D133 = 3;
            main.d_Param.D400 = 0;
            main.cML.Origin();

            this.BeginInvoke(new Action(() => { lb_progress.Text = "TN-Z Home check..."; }));
            //IN5---->pass
            if (!main.pass && !main.Wait_IO_Check(0, 0, 5, 1, TimeSpan.FromMinutes(3)))
            {
                MessageBox.Show("E165\r\n" + "Z_ULS OFF\r\n", "Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));
                return false;
            }

            main.home_end_flag[0] = false;
            main.home_end_flag[1] = false;
            main.home_end_flag[2] = false;
            this.BeginInvoke(new Action(() => { lb_progress.Text = "TN-X Home...\r\n" + "TN-Y Home...\r\n" + "DM-DD Home..."; }));
            //X軸歸Home
            main.aCS_Motion._ACS.Command("#3X");
            Thread.Sleep(3000);
            //Y軸歸Home
            main.aCS_Motion._ACS.Command("#2X");
            Thread.Sleep(3000);
            //A軸歸Home
            main.aCS_Motion._ACS.Command("#1X");
            Thread.Sleep(3000);
            main.Wait_XYA_Home_End("", 120000);
            var msg = string.Empty;
            //Thread.Sleep(3000);
            if (!main.home_end_flag[0] || !main.home_end_flag[1] || !main.home_end_flag[2] ||
                Math.Round(main.aCS_Motion.m_X_lfFPos, 1) != 0.0 || Math.Round(main.aCS_Motion.m_Y_lfFPos, 1) != 0.0 || Math.Round(main.aCS_Motion.m_A_lfFPos, 1) != 0.0 ||
                !main.aCS_Motion.x_Inp || !main.aCS_Motion.y_Inp || !main.aCS_Motion.a_Inp)
            {
                if (!main.home_end_flag[0] || !main.home_end_flag[1])
                    msg += "E164\r\n" + "TN-XY Home Error\r\n";
                if (!main.home_end_flag[2])
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
            main.aCS_Motion._ACS.SetOutput(1, 6, 0);
            main.aCS_Motion._ACS.SetOutput(1, 7, 1);

            main.eFEM._Paser._SignalTower_Status.color = SignalTower_Color.All;
            main.eFEM._Paser._SignalTower_Status.state = SignalTower_State.Off;
            if (!main.eFEM._Paser._SignalTower_Status.Send_Cmd(main.eFEM.client))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
            }
            main.eFEM._Paser._SignalTower_Status.color = SignalTower_Color.Blue;
            main.eFEM._Paser._SignalTower_Status.state = SignalTower_State.Flash;
            if (!main.eFEM._Paser._SignalTower_Status.Send_Cmd(main.eFEM.client))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
            }
            main.d_Param.D400 = 0;
            return true;
        }



        private bool LaserReset()
        {
            var rtn = "";
            //if (!main.keyence.AutoSystemZeroMulti(ref rtn, true)) { MessageBox.Show("AutoZeroMulti:" + rtn, "Keyence"); return false; }
            //Thread.Sleep(1000);
            if (!main.keyence.AutoSystemZeroMulti(ref rtn, false)) { MessageBox.Show("AutoZeroMulti:" + rtn, "Keyence"); return false; }

            if (!main.keyence.SystemTimingMulti(ref rtn, false)) { MessageBox.Show("TimingMulti:" + rtn, "Keyence"); return false; }
            Thread.Sleep(100);
            if (!main.keyence.SystemTimingMulti(ref rtn, true)) { MessageBox.Show("TimingMulti:" + rtn, "Keyence"); return false; }
            Thread.Sleep(100);
            if (!main.keyence.SystemTimingMulti(ref rtn, false)) { MessageBox.Show("TimingMulti:" + rtn, "Keyence"); return false; }
            Thread.Sleep(100);

            //if (!main.keyence.AutoSystemZeroMulti(ref rtn, false)) { MessageBox.Show("AutoZeroMulti:" + rtn, "Keyence"); return false; }
            //Thread.Sleep(1000);
            if (!main.keyence.AutoSystemZeroMulti(ref rtn, true)) { MessageBox.Show("AutoZeroMulti:" + rtn, "Keyence"); return false; }
            Thread.Sleep(100);

            if (!main.keyence.SystemTimingMulti(ref rtn, false)) { MessageBox.Show("TimingMulti:" + rtn, "Keyence"); return false; }
            Thread.Sleep(100);
            if (!main.keyence.SystemTimingMulti(ref rtn, true)) { MessageBox.Show("TimingMulti:" + rtn, "Keyence"); return false; }
            Thread.Sleep(100);
            if (!main.keyence.SystemTimingMulti(ref rtn, false)) { MessageBox.Show("TimingMulti:" + rtn, "Keyence"); return false; }
            Thread.Sleep(100);



            return true;
        }

        bool ccd_enable = true;
        double pexil_s;
        RecData recData;
        RecData recDataToUpdate;
        ILiteCollection<RecData> col;
        private bool DMRUN(Wafer_Size wafer_size)
        {
            //IO MPS IN10=ON (PG3-VS)----pass
            this.BeginInvoke(new Action(() => { lb_progress.Text = "PG3-VS"; }));
            if (!main.pass && !main.Wait_IO_Check(0, 1, 10, 1, main.IO_timeout))
            {
                MessageBox.Show("E008\r\n" + "PG3-VS OFF", "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            //IO MPS OUT5=ON (VC_ON_C1 ON)----pass
            this.BeginInvoke(new Action(() => { lb_progress.Text = "VC_ON_C1"; }));
            main.aCS_Motion._ACS.SetOutput(1, 5, 1);
            Thread.Sleep(10);

            this.BeginInvoke(new Action(() => { lb_progress.Text = "DMWAFER"; }));
            //----pass
            if (!main.pass && (!main.DMWAFER(ref main.d_Param.D110)))
            {
                if (main.d_Param.D110 != 1)
                {
                    MessageBox.Show("E057", "DMWAFER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }

            col = main.db.GetCollection<RecData>("RecData");
            recData = new RecData();
            var cc_Points = new Point2d[3];
            switch (wafer_size)
            {
                case Wafer_Size.eight:
                    col = main.db.GetCollection<RecData>("RecData");
                    recData = new RecData();
                    recData.FileName = autorun_Prarm.file_name;
                    recData.WaferID = "N/A";
                    col.EnsureIndex(x => x.Id, true);
                    col.Insert(recData);
                    DM_recID = recData.Id;
                    break;
                case Wafer_Size.tweleve:
                    main.aCS_Motion._ACS.Command("PTP/v 2," + configWR.ReadSettings("Aocr") + ",100");
                    main.wait_axis_Inp("a", 120000);
                    Thread.Sleep(1000);
                    //OCR 字元辨識
                    cognex.ReadData(0);
                    if (!CheckCondition(ref ocr_read_update, true, TimeSpan.FromSeconds(1)))
                    {
                        MessageBox.Show("OCR TimeOut");
                        return false;
                    }
                    //寫入資料庫
                    col = main.db.GetCollection<RecData>("RecData");
                    recData = new RecData();
                    recData.FileName = autorun_Prarm.file_name;
                    if (cognex.data == "************\r\n")
                    {
                        recData.WaferID = "N/A";
                    }
                    else
                    {
                        recData.WaferID = cognex.data;
                    }
                    col.EnsureIndex(x => x.Id, true);
                    col.Insert(recData);
                    DM_recID = recData.Id;
                    break;
                case Wafer_Size.unknow:
                    break;
                default:
                    break;
            }

            mutiCam.lightControl.ON();
            main.aCS_Motion._ACS.Command("PTP/v 2," + configWR.ReadSettings("A1") + ",100");
            main.wait_axis_Inp("a", 120000);
            Thread.Sleep(2000);
            switch (wafer_size)
            {
                case Wafer_Size.eight:
                    if (ccd_enable)
                        eight_bp[0] = (Bitmap)mutiCam.Cam1_OneShot().Clone();
                    break;
                case Wafer_Size.tweleve:
                    if (ccd_enable)
                        tweleve_bp[0] = (Bitmap)mutiCam.Cam2_OneShot().Clone();
                    break;
                case Wafer_Size.unknow:
                    break;
                default:
                    break;
            }

            main.aCS_Motion._ACS.Command("PTP/v 2," + configWR.ReadSettings("A2") + ",100");
            main.wait_axis_Inp("a", 120000);
            Thread.Sleep(2000);

            switch (wafer_size)
            {
                case Wafer_Size.eight:
                    if (ccd_enable)
                        eight_bp[1] = (Bitmap)mutiCam.Cam1_OneShot().Clone();
                    break;
                case Wafer_Size.tweleve:
                    if (ccd_enable)
                        tweleve_bp[1] = (Bitmap)mutiCam.Cam2_OneShot().Clone();
                    break;
                case Wafer_Size.unknow:
                    break;
                default:
                    break;
            }

            main.aCS_Motion._ACS.Command("PTP/v 2," + configWR.ReadSettings("A3") + ",100");
            main.wait_axis_Inp("a", 120000);
            Thread.Sleep(2000);
            switch (wafer_size)
            {
                case Wafer_Size.eight:
                    if (ccd_enable)
                        eight_bp[2] = (Bitmap)mutiCam.Cam1_OneShot().Clone();
                    break;
                case Wafer_Size.tweleve:
                    if (ccd_enable)
                        tweleve_bp[2] = (Bitmap)mutiCam.Cam2_OneShot().Clone();
                    break;
                case Wafer_Size.unknow:
                    break;
                default:
                    break;
            }
            mutiCam.lightControl.OFF();

            Task.Run(() =>
            {
                var c = 0;
                foreach (var item in tweleve_bp)
                {
                    this.BeginInvoke(new Action(() => { lb_progress.Text = "Save "; }));
                    item.Save("C:\\Users\\MyUser\\Desktop\\12_INCH_" + c + ".bmp", ImageFormat.Bmp);

                    c++;
                }
                c = 0;
            });


            main.aCS_Motion._ACS.Command("PTP/v 2," + Convert.ToDouble(configWR.ReadSettings("AL")) + ",100");
            Thread.Sleep(3000);
            main.wait_axis_Inp("a", 120000);
            Point2d center = new Point2d(800, 600);
            pexil_s = Convert.ToDouble(configWR.ReadSettings("Pixel_Size"));
            //影像處理計算分級寫入資料庫
            switch (wafer_size)
            {
                case Wafer_Size.eight:
                    var r_8 = Convert.ToDouble(configWR.ReadSettings("Radius_8"));
                    cc_Points[0] = new Point2d(detect.point_converter(r_8, 30).X + (detect.edge(eight_bp[0], "ref_Point_Left_Center").X - center.X) * pexil_s,
                                               detect.point_converter(r_8, 30).Y + (detect.edge(eight_bp[0], "ref_Point_Left_Center").Y - center.Y) * pexil_s);
                    cc_Points[1] = new Point2d(detect.point_converter(r_8, 150).X + (detect.edge(eight_bp[1], "ref_Point_Left_Center").X - center.X) * pexil_s,
                                               detect.point_converter(r_8, 150).Y + (detect.edge(eight_bp[1], "ref_Point_Left_Center").Y - center.Y) * pexil_s);
                    cc_Points[2] = new Point2d(detect.point_converter(r_8, 270).X + (detect.edge(eight_bp[2], "ref_Point_Left_Center").X - center.X) * pexil_s,
                                               detect.point_converter(r_8, 270).Y + (detect.edge(eight_bp[2], "ref_Point_Left_Center").Y - center.Y) * pexil_s);
                    var d_8 = detect.CalculateCicular(cc_Points[0], cc_Points[1], cc_Points[2]);
                    recDataToUpdate = col.FindById(DM_recID);

                    if (recDataToUpdate != null)
                    {
                        // 更新指定欄位
                        recDataToUpdate.Diameter = d_8.ToString();
                        // 執行更新操作
                        col.Update(recDataToUpdate);
                    }

                    break;
                case Wafer_Size.tweleve:
                    var r_12 = Convert.ToDouble(configWR.ReadSettings("Radius_12"));
                    cc_Points[0] = new Point2d(detect.point_converter(r_12, 30).X + (detect.edge(tweleve_bp[0], "ref_Point_Left_Center").X - center.X) * pexil_s,
                                               detect.point_converter(r_12, 30).Y + (detect.edge(tweleve_bp[0], "ref_Point_Left_Center").Y - center.Y) * pexil_s);
                    cc_Points[1] = new Point2d(detect.point_converter(r_12, 150).X + (detect.edge(tweleve_bp[1], "ref_Point_Left_Center").X - center.X) * pexil_s,
                                               detect.point_converter(r_12, 150).Y + (detect.edge(tweleve_bp[1], "ref_Point_Left_Center").Y - center.Y) * pexil_s);
                    cc_Points[2] = new Point2d(detect.point_converter(r_12, 270).X + (detect.edge(tweleve_bp[2], "ref_Point_Left_Center").X - center.X) * pexil_s,
                                               detect.point_converter(r_12, 270).Y + (detect.edge(tweleve_bp[2], "ref_Point_Left_Center").Y - center.Y) * pexil_s);
                    detect.CalculateCicular(cc_Points[0], cc_Points[1], cc_Points[2]);
                    var d_12 = detect.CalculateCicular(cc_Points[0], cc_Points[1], cc_Points[2]);
                    recDataToUpdate = col.FindById(DM_recID);

                    if (recDataToUpdate != null)
                    {
                        // 更新指定欄位
                        recDataToUpdate.Diameter = d_12.ToString();
                        // 執行更新操作
                        col.Update(recDataToUpdate);
                    }
                    break;
                case Wafer_Size.unknow:
                    break;
                default:
                    break;
            }

            //假設OK
            main.d_Param.D200 = 0;
            TN_recID = DM_recID;

            //IO MPS IN10=ON (PG3-VS)----pass
            this.BeginInvoke(new Action(() => { lb_progress.Text = "PG3-VS"; }));
            if (!main.pass && !main.Wait_IO_Check(0, 1, 10, 1, main.IO_timeout))
            {
                MessageBox.Show("E008\r\n" + "PG3-VS OFF", "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            //IO MPS OUT5=ON (VC_ON_C1 ON)----pass
            this.BeginInvoke(new Action(() => { lb_progress.Text = "VC_ON_C1"; }));
            main.aCS_Motion._ACS.SetOutput(1, 5, 1);
            Thread.Sleep(1000);

            this.BeginInvoke(new Action(() => { lb_progress.Text = "DMWAFER"; }));
            //----pass
            if (!main.pass && (!main.DMWAFER(ref main.d_Param.D110)) || main.d_Param.D110 != 1)
            {
                MessageBox.Show("E057", "DMWAFER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //IO MPS OUT5=OFF (VC_ON_C1 ON)
            this.BeginInvoke(new Action(() => { lb_progress.Text = "VC_ON_C1"; }));
            main.aCS_Motion._ACS.SetOutput(1, 5, 0);
            main.d_Param.D132 = 0;


            return true;
        }

        List<int> list_laser_low = new List<int>();
        List<int> list_laser_up = new List<int>();
        List<int> list_laser_thick = new List<int>();
        List<int> list_laser_low_up_Difference = new List<int>();
        List<int> bow_point_a_value = new List<int>();
        List<int> bow_point_b_value = new List<int>();
        List<int> bow_per = new List<int>();
        double thickness = 0, ttv = 0, warp = 0, bow = 0;
        public bool TNRUN(Wafer_Size wafer_Size)
        {
            main.d_Param.D133 = 1;
            if (!TNRUN_ACT(wafer_Size))
            {
                return false;
            }

            Random random1 = new Random();
            Random random2 = new Random();
            Random random3 = new Random();
            for (int i = 0; i < 157; i++)
            {
                list_laser_low.Add(random1.Next(1, 100));
                list_laser_up.Add(random2.Next(1, 100));
                list_laser_thick.Add(random3.Next(1, 100));
            }



            //main.keyence.StorageSave(); 
            //執行量測路徑
            //解析量測資料
            main.keyence.GetStorageData();
            list_laser_low.Clear();
            list_laser_up.Clear();
            //this.BeginInvoke(new Action(() => { main.keyence.StorageSave(); }));
            for (int i = 0; i < 157; i++)
            {
                list_laser_low.Add(main.keyence._storageData[i].outMeasurementData[0].measurementValue - main.calibration[i]);
                list_laser_up.Add(main.keyence._storageData[i].outMeasurementData[1].measurementValue + main.calibration[i]);
                list_laser_thick.Add(main.keyence._storageData[i].outMeasurementData[2].measurementValue);
            }

            this.BeginInvoke(new Action(() =>
            {
                var saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Write list values to the CSV file
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        for (int i = 0; i < Math.Max(list_laser_low.Count, list_laser_up.Count); i++)
                        {
                            int valueA = (i < list_laser_low.Count) ? list_laser_low[i] : 0;
                            int valueB = (i < list_laser_up.Count) ? list_laser_up[i] : 0;

                            writer.WriteLine($"{valueA},{valueB}");
                        }
                    }

                    Console.WriteLine($"CSV file saved at: {filePath}");
                }
                else
                {
                    Console.WriteLine("File save operation canceled.");
                }

            }));

            thickness = list_laser_thick.Average();
            ttv = list_laser_thick.Max() - list_laser_thick.Min();
            foreach (var OUT1 in list_laser_low)
            {
                foreach (var OUT2 in list_laser_up)
                {
                    list_laser_low_up_Difference.Add(OUT1 - OUT2);
                }
            }
            var max = list_laser_low_up_Difference.Max();
            var min = list_laser_low_up_Difference.Min();
            warp = (max - min) / 2;

            //var warp=
            switch (autorun_Prarm.wafer_Size)
            {
                case Wafer_Size.eight:
                    //var bow1 = list
                    break;
                case Wafer_Size.tweleve:
                    var C = list_laser_low[81];
                    bow_point_a_value.Clear();
                    bow_point_b_value.Clear();
                    bow_per.Clear();
                    bow_point_a_value.Add(list_laser_low[2]);
                    bow_point_a_value.Add(list_laser_low[21]);
                    bow_point_a_value.Add(list_laser_low[74]);
                    bow_point_a_value.Add(list_laser_low[151]);
                    bow_point_b_value.Add(list_laser_low[160]);
                    bow_point_b_value.Add(list_laser_low[141]);
                    bow_point_b_value.Add(list_laser_low[88]);
                    bow_point_b_value.Add(list_laser_low[11]);
                    for (int i = 0; i < 4; i++)
                    {
                        bow_per.Add(C - (bow_point_a_value[i] + bow_point_b_value[i]));
                    }
                    bow = bow_per.Max();
                    break;
                case Wafer_Size.unknow:
                    break;
                default:
                    break;
            }



            //var t1 = main.keyence._storageData[0].outMeasurementData[0].measurementValue;
            //var t2 = main.keyence._storageData[0].outMeasurementData[1].measurementValue;
            //var t3 = main.keyence._storageData[0].outMeasurementData[2].measurementValue;

            //量測完成 計算.......



            //判斷好壞...........



            recDataToUpdate = col.FindById(DM_recID);

            if (recDataToUpdate != null)
            {
                // 更新指定欄位
                recDataToUpdate.Thickness = thickness.ToString();
                //recDataToUpdate.Thickness_Level
                recDataToUpdate.TTV = ttv.ToString();
                //recDataToUpdate.TTV_Level
                recDataToUpdate.BOW = bow.ToString();
                //recDataToUpdate.BOW_Level
                recDataToUpdate.WARP = warp.ToString();
                //recDataToUpdate.WARP_Level                
                // 執行更新操作
                col.Update(recDataToUpdate);
            }



            //假設是好的
            main.d_Param.D201 = 0;
            main.d_Param.D133 = 0;
            return true;
        }
        public bool TNRUN_ACT(Wafer_Size wafer_Size)
        {
            if (!main.TNWAFER(ref main.d_Param.D111) || main.d_Param.D111 != 1)
            {
                MessageBox.Show("E059");
            }
            main.aCS_Motion._ACS.SetOutput(1, 8, 1);
            main.cML.pin_Down();
            //IN5---->pass
            if (!main.pass && !main.Wait_IO_Check(0, 0, 5, 1, TimeSpan.FromMinutes(2)))
            {
                MessageBox.Show("E174\r\n" + "Z_ULS OFF\r\n", "TNRUN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!main.pass && !main.Wait_IO_Check(0, 1, 1, 1, TimeSpan.FromMinutes(2)))
            {
                MessageBox.Show("EFEMOUT2 OFF\r\n", "TNRUN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            main.aCS_Motion._ACS.Command("PTP/v (0,1)," + configWR.ReadSettings("Xg") + "," + configWR.ReadSettings("Yg") + ",100");

            main.wait_axis_Inp("x", 100000);
            main.wait_axis_Inp("y", 100000);
            Thread.Sleep(TimeSpan.FromSeconds(5));
            //進行雷射頭補償
            //包含: 上、下雷射頭原點補償，及厚度補償???怎麼補??
            //????
            if (!LaserReset())
            {
                MessageBox.Show("CL reset zero fail");
            }
            Thread.Sleep(1000);
            switch (wafer_Size)
            {
                case Wafer_Size.eight:
                    main.aCS_Motion._ACS.Command("PTP/v (0,1)," + configWR.ReadSettings("X_8") + "," + configWR.ReadSettings("Y_8") + ",100");
                    Thread.Sleep(1000);
                    main.wait_axis_Inp("x", 100000);
                    main.wait_axis_Inp("y", 100000);
                    //執行8吋量測路徑
                    main.measure_end_flag[0] = false;
                    main.aCS_Motion._ACS.Command("#" + configWR.ReadSettings("Mprog_8") + "X");
                    main.keyence.ClearStorage();
                    main.keyence.StartStorage();
                    if (!CheckCondition(ref main.measure_end_flag[0], true, TimeSpan.FromMinutes(10)))
                    {
                        main.keyence.StopStorage();
                        MessageBox.Show("Measure TimeOut");
                        return false;
                    }
                    main.keyence.StopStorage();
                    return true;
                case Wafer_Size.tweleve:
                    main.aCS_Motion._ACS.Command("PTP/v (0,1)," + configWR.ReadSettings("X_12") + "," + configWR.ReadSettings("Y_12") + ",100");
                    Thread.Sleep(1000);
                    main.wait_axis_Inp("x", 100000);
                    main.wait_axis_Inp("y", 100000);
                    //執行12吋量測路徑
                    main.measure_end_flag[1] = false;
                    main.aCS_Motion._ACS.Command("#" + configWR.ReadSettings("Mprog_12") + "X");
                    main.keyence.ClearStorage();
                    main.keyence.StartStorage();
                    if (!CheckCondition(ref main.measure_end_flag[1], true, TimeSpan.FromMinutes(10)))
                    {
                        main.keyence.StopStorage();
                        MessageBox.Show("Measure TimeOut");
                        return false;
                    }
                    main.keyence.StopStorage();
                    return true;
                case Wafer_Size.unknow:
                    return false;
                default:
                    return false;
            }
        }
        bool ocr_read_update = false;
        private void Cognex_receive_update(object sender, EventArgs e)
        {
            ocr_read_update = true;
        }




        public bool ANRUN()
        {
            main.d_Param.D131 = 1;
            if (!ANWAFER())
            {
                MessageBox.Show("ANWAFER Fail");
                return false;
            }
            if (main.d_Param.D102 != 1)
            {
                MessageBox.Show("E055\r\nD102!=1", "ANRUN Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            var angle = 0;

            var size = 0;

            switch (autorun_Prarm.wafer_Size)
            {
                case Wafer_Size.eight:
                    size = 8;
                    angle = 0;
                    break;
                case Wafer_Size.tweleve:
                    size = 12;
                    angle = 1800;
                    break;
                case Wafer_Size.unknow:
                    return false;
                default:
                    return false;
            }


            this.BeginInvoke(new Action(() => { lb_progress.Text = "SetWaferMode..."; }));
            main.eFEM.EFEM_Cmd = "SetWaferMode,Aligner1," + autorun_Prarm.waferMode.ToString();
            main.eFEM._Paser._WaferMode_Set_Cmd.Cmd_Error = "";
            main.eFEM._Paser._WaferMode_Set_Cmd.ErrorCode = "";
            main.eFEM.EFEM_Send();


            this.BeginInvoke(new Action(() => { lb_progress.Text = "SetWaferSize..."; }));
            main.eFEM.EFEM_Cmd = "SetWaferSize,Aligner1," + size;
            main.eFEM._Paser._WaferSize_Set_Cmd.Cmd_Error = "";
            main.eFEM._Paser._WaferSize_Set_Cmd.ErrorCode = "";
            main.eFEM.EFEM_Send();


            this.BeginInvoke(new Action(() => { lb_progress.Text = "SetWaferType..."; }));
            main.eFEM.EFEM_Cmd = "SetWaferType,Aligner1," + autorun_Prarm.waferType.ToString();
            main.eFEM._Paser._WaferType_Set_Cmd.Cmd_Error = "";
            main.eFEM._Paser._WaferType_Set_Cmd.ErrorCode = "";
            main.eFEM.EFEM_Send();


            this.BeginInvoke(new Action(() => { lb_progress.Text = "SetAlignmentAngle..."; }));
            main.eFEM.EFEM_Cmd = "SetAlignmentAngle,Aligner1," + angle;
            main.eFEM._Paser._AlignmentAngle_Set_Cmd.Cmd_Error = "";
            main.eFEM._Paser._AlignmentAngle_Set_Cmd.ErrorCode = "";
            main.eFEM.EFEM_Send();

            this.BeginInvoke(new Action(() => { lb_progress.Text = "Alignment,Aligner1..."; }));
            main.eFEM.EFEM_Cmd = "Alignment,Aligner1";
            main.eFEM._Paser._Alignment_Aligner.Cmd_Error = "";
            main.eFEM._Paser._Alignment_Aligner.ErrorCode = "";
            main.eFEM.EFEM_Send();

            main.d_Param.D131 = 0;
            return true;
        }
        private bool LAgetAN()
        {
            this.BeginInvoke(new Action(() => { lb_progress.Text = "LAgetAN..."; }));
            main.d_Param.D124 = 1;

            if (!ANWAFER() || main.d_Param.D102 != 1)
            {
                MessageBox.Show("E055\r\nD102!=1", "LAgetAN Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (!UALAWAFER() || main.d_Param.D101 != 0 || main.d_Param.D102 != 1)
            {
                MessageBox.Show("E032\r\nUALAWAFER Fail\r\nManual remove robot wafer then manual reset home", "LAgetAN Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                this.BeginInvoke(new Action(() => { lb_progress.Text = "SmartGet,Robot..."; }));


                main.eFEM._Paser._SmartGet_Robot.arm = _RobotArm.LowArm;
                main.eFEM._Paser._SmartGet_Robot.dest = _RobotDest.Aligner1;
                main.eFEM._Paser._SmartGet_Robot.Slot = "1";
                if (!main.eFEM._Paser._SmartGet_Robot.Send_Cmd(main.eFEM.client))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    MessageBox.Show("SmartGet,Robot$\r\n" + main.eFEM._Paser._SmartGet_Robot.Cmd_Error +
                        "\r\n" + main.eFEM._Paser._SmartGet_Robot.ErrorCode, "LAgetAN Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    if (!UALAWAFER() && main.d_Param.D101 != 1)
                    {
                        MessageBox.Show("E054\r\nUALAWAFER Fail\r\nRobot get wafer fail manual reset error reset home", "LAgetAN Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;

                    }
                    else
                    {
                        if (!ANWAFER() || main.d_Param.D102 != 0)
                        {
                            MessageBox.Show("E055\r\nD102!=1", "LAgetAN Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        main.d_Param.D124 = 0;
                        return true;
                    }
                }
            }
        }
        //判斷有料取片
        public bool UAgetLP1()
        {
            this.BeginInvoke(new Action(() => { lb_progress.Text = "UAgetLP1..."; }));
            main.d_Param.D122 = 1;

            if (!UALAWAFER() && main.d_Param.D100 != 0)
            {
                MessageBox.Show("E031\r\nUALAWAFER Fail\r\nManual remove robot wafer then manual reset home", "UAgetLP1 Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                Array.Clear(cassett1_status, 0, cassett1_status.Length);
                if (!MappingCassette(LoadPortNum.Loadport1, out cassett1_status))
                {
                    MessageBox.Show("Cassette Mapping Fail", "UAgetLP1 Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    if (!UALAWAFER() && main.d_Param.D100 != 0)
                    {
                        MessageBox.Show("E031\r\nUALAWAFER Fail\r\nManual remove robot wafer then manual reset home", "UAgetLP1 Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;

                    }
                    else
                    {
                        this.BeginInvoke(new Action(() => { lb_progress.Text = "SmartGet,Robot..."; }));
                        var get_index = Array.FindIndex(cassett1_status, x => x == "Presence");
                        if (get_index == -1)
                        {
                            return false;
                        }
                        main.eFEM._Paser._SmartGet_Robot.arm = _RobotArm.UpArm;
                        main.eFEM._Paser._SmartGet_Robot.dest = _RobotDest.Loadport1;
                        main.eFEM._Paser._SmartGet_Robot.Slot = (Convert.ToInt32(get_index) + 1).ToString();//取有片的位置
                        if (!main.eFEM._Paser._SmartGet_Robot.Send_Cmd(main.eFEM.client))
                        {
                            this.BeginInvoke(new Action(() => { Progres_update(false); }));
                            MessageBox.Show("SmartGet,Robot$\r\n" + main.eFEM._Paser._SmartGet_Robot.Cmd_Error +
                                "\r\n" + main.eFEM._Paser._SmartGet_Robot.ErrorCode, "UAgetLP1 Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        else
                        {
                            if (!UALAWAFER() && main.d_Param.D100 != 1)
                            {
                                MessageBox.Show("E053\r\nUALAWAFER Fail\r\nRobot get wafer fail manual reset error reset home", "UAgetLP1 Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;

                            }
                            else
                            {
                                main.d_Param.D122 = 0;
                                //取片完位置狀態更改
                                //cassett1_status[get_index] = "Absence";
                                return true;
                            }
                        }
                    }
                }
            }
        }
        public bool UAgetDM()
        {
            this.BeginInvoke(new Action(() => { lb_progress.Text = "UAgutDM..."; }));
            main.d_Param.D126 = 1;
            var a_in_load_pos = (Math.Round(main.aCS_Motion.m_A_lfFPos, 2) == Convert.ToDouble(configWR.ReadSettings("AL")));
            var IN3 = main.aCS_Motion._ACS.GetInput(1, 3);
            var IN1 = main.aCS_Motion._ACS.GetInput(1, 1);
            //chaeck DD motor in loadposition
            if (!a_in_load_pos || IN3 != 1)
            {
                //DD motor move to loadposition
                if (IN1 != 1)
                {
                    MessageBox.Show("Robot in DM station");
                    return false;
                }

                main.aCS_Motion._ACS.Command("PTP/v 2," + Convert.ToDouble(configWR.ReadSettings("AL")) + ",100");
                main.wait_axis_Inp("a", 120000);
            }
            //IO MPS IN10=ON (PG3-VS)----pass
            this.BeginInvoke(new Action(() => { lb_progress.Text = "PG3-VS"; }));
            if (!main.pass && !main.Wait_IO_Check(0, 1, 10, 1, main.IO_timeout))
            {
                MessageBox.Show("E008\r\n" + "PG3-VS OFF", "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            //IO MPS OUT5=ON (VC_ON_C1 ON)----pass
            this.BeginInvoke(new Action(() => { lb_progress.Text = "VC_ON_C1"; }));
            main.aCS_Motion._ACS.SetOutput(1, 5, 1);
            Thread.Sleep(1000);

            this.BeginInvoke(new Action(() => { lb_progress.Text = "DMWAFER"; }));
            //----pass
            if (!main.pass && (!main.DMWAFER(ref main.d_Param.D110)) || main.d_Param.D110 != 1)
            {
                MessageBox.Show("E057", "DMWAFER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (main.d_Param.D100 != 0)
            {
                MessageBox.Show("E031", "UperArm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //IO MPS OUT5=OFF (VC_ON_C1 ON)
            this.BeginInvoke(new Action(() => { lb_progress.Text = "VC_ON_C1"; }));
            main.aCS_Motion._ACS.SetOutput(1, 5, 0);


            //IO MPS IN8=OFF (PG1-WSS)----pass
            this.BeginInvoke(new Action(() => { lb_progress.Text = "PG1-WSS"; }));
            if (!main.pass && !main.Wait_IO_Check(0, 1, 8, 0, main.IO_timeout))
            {
                MessageBox.Show("??\r\n" + "PG1-WSS OFF", "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //IO MPS IN1=OFF (EFOUT2)----pass
            this.BeginInvoke(new Action(() => { lb_progress.Text = "EFOUT2"; }));
            if (!main.pass && !main.Wait_IO_Check(0, 1, 1, 1, main.IO_timeout))
            {
                MessageBox.Show("??\r\n" + "EFOUT2 OFF", "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            this.BeginInvoke(new Action(() => { lb_progress.Text = "EFIN2_C1"; }));
            if (main.d_Param.D110 != 1)
            {
                MessageBox.Show("D110!=1\r\n" + "EFIN2_C1", "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            main.aCS_Motion._ACS.SetOutput(1, 1, 1);

            this.BeginInvoke(new Action(() => { lb_progress.Text = "SmartGet,Robot..."; }));

            main.eFEM._Paser._SmartGet_Robot.arm = _RobotArm.UpArm;
            main.eFEM._Paser._SmartGet_Robot.dest = _RobotDest.Stage2;
            main.eFEM._Paser._SmartGet_Robot.Slot = "1";
            if (!main.eFEM._Paser._SmartGet_Robot.Send_Cmd(main.eFEM.client))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("SmartPut,Robot\r\n" + main.eFEM._Paser._SmartPut_Robot.Cmd_Error +
                    "\r\n" + main.eFEM._Paser._SmartPut_Robot.ErrorCode, "LAputDM Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!main.Wait_IO_Check(0, 1, 1, 1, TimeSpan.FromMinutes(2)))
            {
                MessageBox.Show("SmartGet,Robot Fail", "UAgetDM Error");
                return false;
            }
            main.d_Param.D110 = 0;
            main.d_Param.D100 = 1;
            //EFIN2_C1 OFF
            main.aCS_Motion._ACS.SetOutput(1, 1, 0);

            if (main.d_Param.D110 != 0)
            {
                MessageBox.Show("E056", "UAgetDM Error");
                return false;
            }
            if (main.d_Param.D100 != 1)
            {
                MessageBox.Show("E053", "UAgetDM Error");
                return false;
            }
            main.d_Param.D126 = 0;
            return true;

        }
        private bool LAputDM()
        {
            this.BeginInvoke(new Action(() => { lb_progress.Text = "LAputDM..."; }));
            main.d_Param.D125 = 1;
            var a_in_load_pos = (Math.Round(main.aCS_Motion.m_A_lfFPos, 2) == Convert.ToDouble(configWR.ReadSettings("AL")));
            var IN3 = main.aCS_Motion._ACS.GetInput(1, 3);
            var IN1 = main.aCS_Motion._ACS.GetInput(1, 1);
            //chaeck DD motor in loadposition
            if (!a_in_load_pos || IN3 != 1)
            {
                //DD motor move to loadposition
                if (IN1 != 1)
                {
                    MessageBox.Show("Robot in DM station");
                    return false;
                }
                main.aCS_Motion._ACS.Command("PTP/v 2," + Convert.ToDouble(configWR.ReadSettings("AL")) + ",100");
                main.wait_axis_Inp("a", 120000);
            }
            //IO MPS IN10=ON (PG3-VS)----pass
            this.BeginInvoke(new Action(() => { lb_progress.Text = "PG3-VS"; }));
            if (!main.pass && !main.Wait_IO_Check(0, 1, 10, 1, main.IO_timeout))
            {
                MessageBox.Show("E008\r\n" + "PG3-VS OFF", "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            //IO MPS OUT5=ON (VC_ON_C1 ON)----pass
            this.BeginInvoke(new Action(() => { lb_progress.Text = "VC_ON_C1"; }));
            main.aCS_Motion._ACS.SetOutput(1, 5, 1);
            Thread.Sleep(10);

            this.BeginInvoke(new Action(() => { lb_progress.Text = "DMWAFER"; }));
            //----pass
            if (!main.pass && (!main.DMWAFER(ref main.d_Param.D110)))
            {
                if (main.d_Param.D110 != 0 || main.d_Param.D110 != 4)
                {
                    MessageBox.Show("E056", "DMWAFER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            //IO MPS OUT5=OFF (VC_ON_C1 ON)
            this.BeginInvoke(new Action(() => { lb_progress.Text = "VC_ON_C1"; }));
            main.aCS_Motion._ACS.SetOutput(1, 5, 0);
            this.BeginInvoke(new Action(() => { lb_progress.Text = "UALAWAFER"; }));
            if (!UALAWAFER() || main.d_Param.D101 != 1)
            {
                MessageBox.Show("E054\r\nUALAWAFER Fail\r\nManual remove robot wafer then manual reset home", "LAputDM Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (main.d_Param.D110 != 0)
            {
                MessageBox.Show("D110!=0");
                return false;
            }
            else
            {
                main.aCS_Motion._ACS.SetOutput(1, 1, 1);
            }
            if (main.d_Param.D110 != 0 || main.d_Param.D101 != 1)
            {
                MessageBox.Show("D110!=0 OR D101!=1");
                return false;
            }
            this.BeginInvoke(new Action(() => { lb_progress.Text = "SmartPut,Robot..."; }));

            main.eFEM._Paser._SmartPut_Robot.arm = _RobotArm.LowArm;
            main.eFEM._Paser._SmartPut_Robot.dest = _RobotDest.Stage2;
            main.eFEM._Paser._SmartPut_Robot.Slot = "1";
            if (!main.eFEM._Paser._SmartPut_Robot.Send_Cmd(main.eFEM.client))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("SmartPut,Robot\r\n" + main.eFEM._Paser._SmartPut_Robot.Cmd_Error +
                    "\r\n" + main.eFEM._Paser._SmartPut_Robot.ErrorCode, "LAputDM Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!main.Wait_IO_Check(0, 1, 1, 1, TimeSpan.FromMinutes(2)))
            {
                MessageBox.Show("SmartPut,Robot Fail", "LAputDM Error");
                return false;
            }
            main.aCS_Motion._ACS.SetOutput(1, 1, 0);
            //IO MPS IN10=ON (PG3-VS)----pass
            this.BeginInvoke(new Action(() => { lb_progress.Text = "PG3-VS"; }));
            if (!main.pass && !main.Wait_IO_Check(0, 1, 10, 1, main.IO_timeout))
            {
                MessageBox.Show("E008\r\n" + "PG3-VS OFF", "Initial Home", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            //IO MPS OUT5=ON (VC_ON_C1 ON)----pass
            this.BeginInvoke(new Action(() => { lb_progress.Text = "VC_ON_C1"; }));
            main.aCS_Motion._ACS.SetOutput(1, 5, 1);
            Thread.Sleep(1000);

            this.BeginInvoke(new Action(() => { lb_progress.Text = "DMWAFER"; }));
            //----pass
            if (!main.pass && (!main.DMWAFER(ref main.d_Param.D110)))
            {
                if (main.d_Param.D110 != 1)
                {
                    MessageBox.Show("E057", "DMWAFER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            this.BeginInvoke(new Action(() => { lb_progress.Text = "UALAWAFER"; }));
            if (!UALAWAFER() || main.d_Param.D101 != 0)
            {
                MessageBox.Show("E032\r\nUALAWAFER Fail\r\nManual remove robot wafer then manual reset home", "LAputDM Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            main.d_Param.D125 = 0;
            return true;
        }
        public bool UAputAN()
        {
            main.d_Param.D123 = 1;
            if (!ANWAFER())
            {
                MessageBox.Show("ANWAFER Fail");
                return false;
            }
            if (main.d_Param.D102 != 0)
            {
                MessageBox.Show("E033\r\nD102!=0", "UAputAN Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!UALAWAFER())
            {
                MessageBox.Show("UALAWAFER Fail", "Error");
                return false;
            }
            else if (main.d_Param.D100 != 1)
            {
                MessageBox.Show("E053\r\nUALAWAFER Fail\r\nRobot get wafer fail manual reset error reset home", "UAgetLP1 Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (main.d_Param.D102 != 0 || main.d_Param.D100 != 1)
            {
                MessageBox.Show("main.d_Param.D102 != 0 && main.d_Param.D100 != 1", "Error");
                return false;
            }
            else
            {
                this.BeginInvoke(new Action(() => { lb_progress.Text = "SmartPut,Robot..."; }));
                main.eFEM._Paser._SmartPut_Robot.arm = _RobotArm.UpArm;
                main.eFEM._Paser._SmartPut_Robot.dest = _RobotDest.Aligner1;
                main.eFEM._Paser._SmartPut_Robot.Slot = "1";
                if (!main.eFEM._Paser._SmartPut_Robot.Send_Cmd(main.eFEM.client))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    MessageBox.Show("SmartPut,Robot\r\n" + main.eFEM._Paser._SmartPut_Robot.Cmd_Error +
                        "\r\n" + main.eFEM._Paser._SmartPut_Robot.ErrorCode, "UAputAN Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!ANWAFER() || main.d_Param.D102 != 1)
                {
                    MessageBox.Show("E055\r\nANWAFER FAIL\r\n Please manual reset home", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!UALAWAFER() || main.d_Param.D100 != 0)
                {
                    MessageBox.Show("E031\r\nUALAWAFER Fail\r\nManual remove robot wafer then manual reset home", "UAputAN Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                main.d_Param.D123 = 0;
                return true;
            }
        }
        public bool UAputTN()
        {
            main.d_Param.D127 = 1;
            //check EFEMOUT3 ON
            main.Wait_IO_Check(0, 1, 2, 1, main.IO_timeout);
            var x_in_loadpos = (Math.Round(main.aCS_Motion.m_X_lfFPos, 2) == Convert.ToDouble(configWR.ReadSettings("XL")));
            var y_in_loadpos = (Math.Round(main.aCS_Motion.m_Y_lfFPos, 2) == Convert.ToDouble(configWR.ReadSettings("YL")));

            var z_in_load_pos = false;
            var z_in_org_pos = false;
            main.cML.Query("?96.1");
            main.Wait_Cm1_Received_Update();
            Thread.Sleep(1000);
            main.cML.Query("?96.1");
            main.Wait_Cm1_Received_Update();
            if (main.cML.recData == "Px.1=" + configWR.ReadSettings("ZL"))
            {
                z_in_load_pos = true;
            }
            else if (main.cML.recData == "Px.1=" + configWR.ReadSettings("Z0"))
            {
                z_in_org_pos = true;
            }

            //XY not in load pos
            if (!main.Wait_IO_Check(0, 0, 0, 1, TimeSpan.FromMinutes(2)) ||
                !main.Wait_IO_Check(0, 0, 1, 1, TimeSpan.FromMinutes(2)) ||
                !main.Wait_IO_Check(0, 0, 2, 1, TimeSpan.FromMinutes(2)) ||
                !x_in_loadpos ||
                !y_in_loadpos ||
                !z_in_load_pos)
            {
                if (!z_in_org_pos)
                {
                    //Z軸歸Home
                    main.cML.Origin();
                    this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

                    this.BeginInvoke(new Action(() => { lb_progress.Text = "TN-Z Home check..."; }));
                    //IN5---->pass
                    if (!main.pass && !main.Wait_IO_Check(0, 0, 5, 1, TimeSpan.FromMinutes(2)))
                    {
                        MessageBox.Show("E165\r\n" + "Z_ULS OFF\r\n", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                this.BeginInvoke(new Action(() => { lb_progress.Text = "MOVE TO (XL,YL)..."; }));
                //TN-XY move to XL,YL
                main.aCS_Motion._ACS.Command("PTP/v (0,1)," + configWR.ReadSettings("XL") + "," + configWR.ReadSettings("YL") + ",100");
                Thread.Sleep(1000);
                main.wait_axis_Inp("x", 100000);
                main.wait_axis_Inp("y", 100000);
                main.cML.pin_Up();
                if (!main.Wait_IO_Check(0, 0, 2, 1, TimeSpan.FromMinutes(2)))
                {
                    MessageBox.Show("Z_LS IN2 not on", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.BeginInvoke(new Action(() =>
                    {
                        Progres_update(false);
                    }));

                    return false;
                }
                this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));
                this.BeginInvoke(new Action(() => { lb_progress.Text = "Check Z in load pos..."; }));
                Thread.Sleep(1000);
                main.cML.Query("?96.1");
                main.Wait_Cm1_Received_Update();
                Thread.Sleep(1000);
                main.cML.Query("?96.1");
                main.Wait_Cm1_Received_Update();
                //當前位置回傳格式未檢查----待修正                                   
                z_in_load_pos = (main.cML.recData == "Px.1=" + configWR.ReadSettings("ZL"));
                if (!z_in_load_pos)
                {
                    MessageBox.Show("E175\r\n" + "Z not in looad pos", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            if (!main.Wait_IO_Check(0, 1, 9, 1, main.IO_timeout))
            {
                MessageBox.Show("E007");
                return false;
            }
            if (!main.Wait_IO_Check(0, 1, 9, 1, main.IO_timeout) || !main.Wait_IO_Check(0, 1, 9, 1, main.IO_timeout))
            {
                MessageBox.Show("E018");
                return false;
            }
            if (!main.TNWAFER(ref main.d_Param.D111) || main.d_Param.D111 != 0)
            {
                MessageBox.Show("E058");
                return false;
            }
            if (main.d_Param.D100 != 1)
            {
                MessageBox.Show("E053");
                return false;
            }
            if (!main.Wait_IO_Check(0, 1, 2, 1, main.IO_timeout))
            {
                MessageBox.Show("EFOUT3 ON");
                return false;
            }
            main.aCS_Motion._ACS.SetOutput(1, 2, 1);
            main.eFEM._Paser._SmartPut_Robot.arm = _RobotArm.UpArm;
            main.eFEM._Paser._SmartPut_Robot.dest = _RobotDest.Stage3;
            main.eFEM._Paser._SmartPut_Robot.Slot = "1";
            if (!main.eFEM._Paser._SmartPut_Robot.Send_Cmd(main.eFEM.client))
            {
                MessageBox.Show("smart put stage3 fail");
                return false;
            }
            main.d_Param.D111 = 1;
            main.d_Param.D100 = 0;
            if (!main.Wait_IO_Check(0, 1, 2, 1, main.IO_timeout))
            {
                MessageBox.Show("smart put stage3 fail");
                return false;
            }
            main.aCS_Motion._ACS.SetOutput(1, 2, 0);

            Thread.Sleep(500);
            if (!main.TNWAFER(ref main.d_Param.D111) || main.d_Param.D111 != 1)
            {
                MessageBox.Show("E059");
                main.aCS_Motion._ACS.SetOutput(1, 8, 1);
                return false;
            }
            Thread.Sleep(500);
            main.aCS_Motion._ACS.SetOutput(1, 8, 1);
            if (main.d_Param.D100 != 0)
            {
                MessageBox.Show("E031");
            }
            main.d_Param.D127 = 0;
            return true;
        }
        public bool LAgetTN()
        {

            main.d_Param.D128 = 1;
        Check_ON_LoadPos:
            var x_in_loadpos = (Math.Round(main.aCS_Motion.m_X_lfFPos, 2) == Convert.ToDouble(configWR.ReadSettings("XL")));
            var y_in_loadpos = (Math.Round(main.aCS_Motion.m_Y_lfFPos, 2) == Convert.ToDouble(configWR.ReadSettings("YL")));

            var z_in_load_pos = false;
            var z_in_org_pos = false;
            main.cML.Query("?96.1");
            main.Wait_Cm1_Received_Update();
            Thread.Sleep(1000);
            main.cML.Query("?96.1");
            main.Wait_Cm1_Received_Update();
            if (main.cML.recData == "Px.1=" + configWR.ReadSettings("ZL"))
            {
                z_in_load_pos = true;
            }
            else if (main.cML.recData == "Px.1=" + configWR.ReadSettings("Z0"))
            {
                z_in_org_pos = true;
            }

            //XY not in load pos
            if (!main.Wait_IO_Check(0, 0, 0, 1, TimeSpan.FromSeconds(3)) ||
                !main.Wait_IO_Check(0, 0, 1, 1, TimeSpan.FromSeconds(3)) ||
                main.aCS_Motion._ACS.GetInput(0, 2) != 1 ||
                !x_in_loadpos ||
                !y_in_loadpos ||
                !z_in_load_pos)
            {
                if (!z_in_org_pos)
                {
                    //Z軸歸Home
                    main.cML.pin_Down();
                    this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

                    this.BeginInvoke(new Action(() => { lb_progress.Text = "TN-Z Home check..."; }));
                    //IN5---->pass
                    if (!main.pass && !main.Wait_IO_Check(0, 0, 5, 1, TimeSpan.FromMinutes(2)))
                    {
                        MessageBox.Show("E165\r\n" + "Z_ULS OFF\r\n", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                this.BeginInvoke(new Action(() => { lb_progress.Text = "MOVE TO (XL,YL)..."; }));

                if (main.aCS_Motion._ACS.GetInput(1, 2) != 1)
                {
                    MessageBox.Show("EFEMOUT3 OFF\r\n", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //TN-XY move to XL,YL
                main.aCS_Motion._ACS.Command("PTP/v (0,1)," + configWR.ReadSettings("XL") + "," + configWR.ReadSettings("YL") + ",100");
                Thread.Sleep(1000);
                main.wait_axis_Inp("x", 100000);
                main.wait_axis_Inp("y", 100000);
                main.cML.pin_Up();
                if (!main.Wait_IO_Check(0, 0, 2, 1, TimeSpan.FromMinutes(2)))
                {
                    MessageBox.Show("Z_LS IN2 not on", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.BeginInvoke(new Action(() =>
                    {
                        Progres_update(false);
                    }));

                    return false;
                }
                this.BeginInvoke(new Action(() => { lb_progress.Text = "Check Z in load pos..."; }));
                Thread.Sleep(1000);
                main.cML.Query("?96.1");
                main.Wait_Cm1_Received_Update();
                Thread.Sleep(1000);
                main.cML.Query("?96.1");
                main.Wait_Cm1_Received_Update();
                //當前位置回傳格式未檢查----待修正                                   
                z_in_load_pos = (main.cML.recData == "Px.1=" + configWR.ReadSettings("ZL"));
                if (!z_in_load_pos)
                {
                    MessageBox.Show("E175\r\n" + "Z not in looad pos", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                goto Check_ON_LoadPos;
            }
            //PG2_PS
            main.Wait_IO_Check(0, 1, 9, 1, TimeSpan.FromSeconds(1));
            //C_CL1_C4
            main.aCS_Motion._ACS.SetOutput(1, 10, 1);
            //C_CLS1
            main.Wait_IO_Check(0, 1, 13, 1, TimeSpan.FromSeconds(10));
            //C_CL_C0
            main.aCS_Motion._ACS.SetOutput(1, 4, 1);
            //C_CLS
            main.Wait_IO_Check(0, 1, 4, 1, TimeSpan.FromSeconds(1));
            //C_CL_C0
            main.aCS_Motion._ACS.SetOutput(1, 4, 0);
            //C_UCLS
            main.Wait_IO_Check(0, 1, 5, 1, TimeSpan.FromSeconds(1));
            //C_CL1_C4
            main.aCS_Motion._ACS.SetOutput(1, 10, 0);
            //C_ UCLS 1
            main.Wait_IO_Check(0, 1, 14, 1, TimeSpan.FromSeconds(1));



            if (main.aCS_Motion._ACS.GetInput(1, 9) == 1 &&
                 main.aCS_Motion._ACS.GetInput(1, 5) == 0 &&
                   main.aCS_Motion._ACS.GetOutput(1, 4) == 0)
            {
                main.d_Param.D111 = 2;
                MessageBox.Show("E018");
                return false;
            }


            //if (!main.Wait_IO_Check(1, 1, 4, 0, TimeSpan.FromSeconds(3)) &&
            //    !main.Wait_IO_Check(0, 1, 9, 1, TimeSpan.FromSeconds(3)) &&
            //    !main.Wait_IO_Check(0, 1, 5, 0, TimeSpan.FromSeconds(3)))
            //{
            //    main.d_Param.D111 = 2;
            //    MessageBox.Show("E018");
            //    return false;
            //}



            if (main.aCS_Motion._ACS.GetInput(1, 9) == 1 &&
                  main.aCS_Motion._ACS.GetInput(1, 14) == 0 &&
                    main.aCS_Motion._ACS.GetOutput(1, 10) == 0)
            {
                main.d_Param.D111 = 2;
                MessageBox.Show("E018");
                return false;
            }
            //if (main.Wait_IO_Check(1, 1, 10, 0, TimeSpan.FromSeconds(3)) &&
            //   main.Wait_IO_Check(0, 1, 9, 1, TimeSpan.FromSeconds(3)) &&
            //   main.Wait_IO_Check(0, 1, 14, 0, TimeSpan.FromSeconds(3)))
            //{
            //    main.d_Param.D111 = 2;
            //    MessageBox.Show("E018");
            //    return false;
            //}
            if (!main.Wait_IO_Check(0, 1, 9, 1, TimeSpan.FromSeconds(3)))
            {
                main.d_Param.D111 = 2;
                MessageBox.Show("E007");
                return false;
            }

            if (!main.TNWAFER(ref main.d_Param.D111) || main.d_Param.D111 != 1)
            {
                MessageBox.Show("TNWAFER fail");
                return false;
            }
            main.aCS_Motion._ACS.SetOutput(1, 8, 1);
            if (main.d_Param.D101 != 0)
            {
                MessageBox.Show("E032");
            }
            main.aCS_Motion._ACS.SetOutput(1, 2, 1);

            this.BeginInvoke(new Action(() => { lb_progress.Text = "SmartGet,Robot..."; }));


            main.eFEM._Paser._SmartGet_Robot.arm = _RobotArm.LowArm;
            main.eFEM._Paser._SmartGet_Robot.dest = _RobotDest.Stage3;
            main.eFEM._Paser._SmartGet_Robot.Slot = "1";
            if (!main.eFEM._Paser._SmartGet_Robot.Send_Cmd(main.eFEM.client))
            {
                MessageBox.Show("SmartGet,Robot$\r\n" + main.eFEM._Paser._SmartGet_Robot.Cmd_Error +
                    "\r\n" + main.eFEM._Paser._SmartGet_Robot.ErrorCode, "LAgetAN Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            main.d_Param.D111 = 0;
            main.d_Param.D101 = 1;
            main.Wait_IO_Check(0, 1, 2, 1, TimeSpan.FromSeconds(3));
            main.aCS_Motion._ACS.SetOutput(1, 2, 0);


            if (!main.TNWAFER(ref main.d_Param.D111) || main.d_Param.D111 != 0)
            {
                MessageBox.Show("TNWAFER fail");
                return false;
            }
            main.aCS_Motion._ACS.SetOutput(1, 8, 1);
            if (main.d_Param.D101 != 1)
            {
                MessageBox.Show("E054");
            }
            main.d_Param.D128 = 0;
            return true;
        }

        private bool LAputOKLP2()
        {
            main.d_Param.D129 = 1;
            if (!MappingCassette(LoadPortNum.Loadport1, out cassett1_status))
            {
                MessageBox.Show("Cassette Mapping Fail", "LAput Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!MappingCassette(LoadPortNum.Loadport2, out cassett2_status))
            {
                MessageBox.Show("Cassette Mapping Fail", "LAput Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            this.BeginInvoke(new Action(() => { lb_progress.Text = "SmartPutt,Robot..."; }));
            var get_index = Array.FindIndex(cassett2_status, x => x == "Absence");
            if (get_index == -1)
            {
                return false;
            }
            main.eFEM._Paser._SmartPut_Robot.arm = _RobotArm.LowArm;
            main.eFEM._Paser._SmartPut_Robot.dest = _RobotDest.Loadport2;
            main.eFEM._Paser._SmartPut_Robot.Slot = (Convert.ToInt32(get_index) + 1).ToString();//取無片的位置
            if (!main.eFEM._Paser._SmartPut_Robot.Send_Cmd(main.eFEM.client))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("SmartPut,Robot$\r\n" + main.eFEM._Paser._SmartPut_Robot.Cmd_Error +
                    "\r\n" + main.eFEM._Paser._SmartPut_Robot.ErrorCode, "LAput Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            recDataToUpdate = col.FindById(TN_recID);

            if (recDataToUpdate != null)
            {
                // 更新指定欄位
                recDataToUpdate.Slot = get_index.ToString();
                recDataToUpdate.Cassette_Number = autorun_Prarm.cassette2_number;
            }

            main.d_Param.D101 = 0;
            main.d_Param.D129 = 0;
            return true;
        }
        private bool LAputNGLP3()
        {
            main.d_Param.D130 = 1;
            if (!MappingCassette(LoadPortNum.Loadport1, out cassett1_status))
            {
                MessageBox.Show("Cassette Mapping Fail", "LAput Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!MappingCassette(LoadPortNum.Loadport3, out cassett3_status))
            {
                MessageBox.Show("Cassette Mapping Fail", "LAput Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            this.BeginInvoke(new Action(() => { lb_progress.Text = "SmartPutt,Robot..."; }));
            var get_index = Array.FindIndex(cassett3_status, x => x == "Absence");
            if (get_index == -1)
            {
                return false;
            }
            main.eFEM._Paser._SmartPut_Robot.arm = _RobotArm.LowArm;
            main.eFEM._Paser._SmartPut_Robot.dest = _RobotDest.Loadport3;
            main.eFEM._Paser._SmartPut_Robot.Slot = (Convert.ToInt32(get_index) + 1).ToString();//取無片的位置
            if (!main.eFEM._Paser._SmartPut_Robot.Send_Cmd(main.eFEM.client))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("SmartPut,Robot$\r\n" + main.eFEM._Paser._SmartPut_Robot.Cmd_Error +
                    "\r\n" + main.eFEM._Paser._SmartPut_Robot.ErrorCode, "LAput Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            recDataToUpdate = col.FindById(TN_recID);

            if (recDataToUpdate != null)
            {
                // 更新指定欄位
                recDataToUpdate.Slot = get_index.ToString();
                recDataToUpdate.Cassette_Number = autorun_Prarm.cassette3_number;
            }

            main.d_Param.D101 = 0;
            main.d_Param.D130 = 0;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>FUCK GetStatus Aligner</returns>
        public bool ANWAFER()
        {
            if (!main.Get_Aligner_Status("ANWAFER"))
            {
                main.d_Param.D102 = 2;
                return false;
            }
            else
            {
                if (main.eFEM._Paser._Aligner_Status.WaferPresence == "Absence")
                {
                    main.d_Param.D102 = 0;
                    return true;
                }
                else if (main.eFEM._Paser._Aligner_Status.WaferPresence == "Presence")
                {
                    main.d_Param.D102 = 1;
                    return true;
                }
                else
                {
                    main.d_Param.D102 = 2;
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// D100是上手臂有沒有料、D101是下手臂有沒有料
        /// D100,D101 對應 UpPresence,LowPresence
        /// </returns>
        /// 
        public bool UALAWAFER()
        {
            this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,Robot..."; }));

            if (!main.eFEM._Paser._Robot_Status.Send_Cmd(main.eFEM.client))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("GetStatus,Robot$\r\n" + main.eFEM._Paser._Robot_Status.Cmd_Error +
                    "\r\n" + main.eFEM._Paser._Robot_Status.ErrorCode, "UALAWAFER Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (main.eFEM._Paser._Robot_Status.UpPresence == "Absence")
            {
                if (main.eFEM._Paser._Robot_Status.LowPresence == "Absence")
                {
                    main.d_Param.D100 = 0;
                    main.d_Param.D101 = 0;
                }
                else if (main.eFEM._Paser._Robot_Status.LowPresence == "Presence")
                {
                    main.d_Param.D100 = 0;
                    main.d_Param.D101 = 1;
                }
                else
                {
                    MessageBox.Show("GetStatus,Robot$\r\n" + main.eFEM._Paser._Robot_Status.Cmd_Error +
                    "\r\n" + main.eFEM._Paser._Robot_Status.ErrorCode, "_Robot_Status Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else if (main.eFEM._Paser._Robot_Status.UpPresence == "Presence")
            {
                if (main.eFEM._Paser._Robot_Status.LowPresence == "Absence")
                {
                    main.d_Param.D100 = 1;
                    main.d_Param.D101 = 0;
                }
                else if (main.eFEM._Paser._Robot_Status.LowPresence == "Presence")
                {
                    main.d_Param.D100 = 1;
                    main.d_Param.D101 = 1;
                }
                else
                {
                    MessageBox.Show("GetStatus,Robot$\r\n" + main.eFEM._Paser._Robot_Status.Cmd_Error +
                    "\r\n" + main.eFEM._Paser._Robot_Status.ErrorCode, "_Robot_Status Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("GetStatus,Robot$\r\n" + main.eFEM._Paser._Robot_Status.Cmd_Error +
                  "\r\n" + main.eFEM._Paser._Robot_Status.ErrorCode, "_Robot_Status Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        #region Mapping Wafer & Exchange Casette

        private bool MappingCassette(LoadPortNum loadport, out string[] map_status)
        {
            this.BeginInvoke(new Action(() => { lb_progress.Text = "Cssette_Mapping..."; }));
        Cssette_Mapping:
            this.BeginInvoke(new Action(() => { lb_progress.Text = "Loadport" + loadport + " Get Map Result..."; }));


            main.eFEM._Paser._GetMapResult.portNum = loadport;
            if (!main.eFEM._Paser._GetMapResult.Send_Cmd(main.eFEM.client))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E046\r\n" + "GetMapResult,Loadport" + loadport + "\r\n" + main.eFEM._Paser._GetCurrentLPWaferSize.Cmd_Error +
                    "\r\n" + main.eFEM._Paser._GetMapResult.ErrorCode, "AutoRun ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                map_status = null;
                return false;
            }
            else if (main.eFEM._Paser._GetMapResult.Result.Contains("Tilted") ||
                main.eFEM._Paser._GetMapResult.Result.Contains("Overlapping") ||
                main.eFEM._Paser._GetMapResult.Result.Contains("Thin") ||
                main.eFEM._Paser._GetMapResult.Result.Contains("UpDown") ||
                (main.eFEM._Paser._GetMapResult.Result.All(x => x == "Absence") && loadport == LoadPortNum.Loadport1) ||
                (main.eFEM._Paser._GetMapResult.Result.All(x => x == "Presence") && (loadport == LoadPortNum.Loadport2)) ||
                (main.eFEM._Paser._GetMapResult.Result.All(x => x == "Presence") && (loadport == LoadPortNum.Loadport3)))//!main.eFEM._Paser._GetMapResult.Result.All(x => x == "Presence") ||
            {
            UpdateLoadport:
                MessageBoxManager.Unregister();
                MessageBoxManager.Yes = "更換卡匣";
                MessageBoxManager.No = "結束量測";
                MessageBoxManager.Register();
                var result = MessageBox.Show("請更換 Loadport" + loadport + " 卡匣\r\n", "卡匣更換提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                switch (result)
                {
                    case DialogResult.Yes:
                        if (!Cassette_Change(loadport))
                            goto UpdateLoadport;
                        goto Cssette_Mapping;
                    case DialogResult.No:

                        //執行 Stop
                        break;
                }

            }
            else if (main.eFEM._Paser._GetMapResult.Result.Contains("Unknow"))
            {
                map_status = null;
                return false;
            }
            string[] _map_status = new string[25];

            if (Array.FindIndex(main.eFEM._Paser._GetMapResult.Result, x => x == null) != -1)
            {
                goto Cssette_Mapping;
            }
            _map_status = main.eFEM._Paser._GetMapResult.Result.Reverse().ToArray();
            map_status = _map_status;
            return true;
        }

        CancellationTokenSource tokenSource = new CancellationTokenSource();


        private bool Cassette_Change(LoadPortNum loadport)
        {
            this.BeginInvoke(new Action(() => { lb_progress.Text = "SignalTower,EFEM,ALL,OFF"; }));
            if (!main.EFEM_Light_Control("All", 0, "Autorun Check"))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                //return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "SignalTower,EFEM,Yellow,ON"; }));
            if (!main.EFEM_Light_Control("Yellow", 2, "Autorun"))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                //return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            if (!main.UnLoad_EFEM_LoadPort(loadport, ""))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));
            this.BeginInvoke(new Action(() => { lb_progress.Text = "等待卡匣更新..."; }));
            //CancellationToken cancellationToken = tokenSource.Token;
            //Task.Run(() => { Check_Cassette_Changed(1); }, cancellationToken);

            Check_Cassette_Changed(loadport);
            this.BeginInvoke(new Action(() => { lb_progress.Text = "ResetError,Loadport" + loadport; }));
            main.Reset_EFEM_LoadPort(loadport, "Autorun");
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));
            if (!main.eFEM._Paser._Reset_Error_LoadPort.Send_Cmd(main.eFEM.client))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }
            this.BeginInvoke(new Action(() => { lb_progress.Text = "Load " + loadport + "..."; }));
            main.eFEM._Paser._Cmd_Loadport.portNum = loadport;
            main.eFEM._Paser._Cmd_Loadport.cmdString = LoadportCmdString.Load;
            if (!main.eFEM._Paser._Cmd_Loadport.Send_Cmd(main.eFEM.client))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E043\r\n" + "Load," + loadport + "\r\n" + main.eFEM._Paser._Cmd_Loadport.Cmd_Error + "\r\n" + main.eFEM._Paser._Cmd_Loadport.ErrorCode, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool Check_Cassette_Changed(LoadPortNum loadport)
        {

            try
            {
                main.Get_EFEM_LoadPort_Status(loadport, "", false);
                if (main.eFEM._Paser._Loadport_Status.Foup == "Presence")
                {
                    main.Get_EFEM_LoadPort_Status(loadport, "", false);
                    while (main.eFEM._Paser._Loadport_Status.Foup != "Absence")
                    {

                        if (tokenSource.IsCancellationRequested)
                        {
                            return false;
                        }
                        else
                        {
                            main.Get_EFEM_LoadPort_Status(loadport, "", false);
                        }

                    }
                    while (main.eFEM._Paser._Loadport_Status.Foup != "Presence")
                    {
                        if (tokenSource.IsCancellationRequested)
                        {
                            return false;
                        }
                        else
                        {
                            main.Get_EFEM_LoadPort_Status(loadport, "", false);
                        }

                    }
                    MessageBoxManager.Unregister();
                    MessageBoxManager.Yes = "完成";
                    MessageBoxManager.No = "結束量測";
                    MessageBoxManager.Register();
                    var result = MessageBox.Show(" Loadport" + loadport + " 卡匣已更新?\r\n", "卡匣更換提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            //tokenSource.Cancel();
                            //main.eFEM_Received_Update_tokenSource.Cancel();
                            return true;

                        case DialogResult.No:
                            tokenSource.Cancel();
                            main.eFEM_Received_Update_tokenSource.Cancel();
                            return false;
                    }

                }
                else if (main.eFEM._Paser._Loadport_Status.Foup == "Absence")
                {
                    while (main.eFEM._Paser._Loadport_Status.Foup != "Presence")
                    {
                        if (tokenSource.IsCancellationRequested)
                        {
                            return false;
                        }
                        else
                        {
                            main.Get_EFEM_LoadPort_Status(loadport, "", false);
                        }
                    }
                    MessageBoxManager.Unregister();
                    MessageBoxManager.Yes = "完成";
                    MessageBoxManager.No = "結束量測";
                    MessageBoxManager.Register();
                    var result = MessageBox.Show(" Loadport" + loadport + " 卡匣已更新?\r\n", "卡匣更換提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            tokenSource.Cancel();
                            main.eFEM_Received_Update_tokenSource.Cancel();
                            return true;

                        case DialogResult.No:
                            tokenSource.Cancel();
                            main.eFEM_Received_Update_tokenSource.Cancel();
                            return false;
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }

        #endregion


        //check pin is not exist
        private bool Chek_XY_pin_status()
        {
            var pin2 = false;
            var pin3 = false;
            var pin4 = false;
            var pin1 = false;
            //TN-XY move to Xp1,Yp1~Xp4,Yp4
            for (int i = 1; i < 4; i++)
            {
                main.aCS_Motion._ACS.Command("PTP/v (0,1)," + configWR.ReadSettings("Xp" + i) + "," + configWR.ReadSettings("Yp" + i) + ",100");
                Thread.Sleep(1000);
                main.wait_axis_Inp("x", 100000);
                main.wait_axis_Inp("y", 100000);
                switch (i)
                {
                    case 1:
                        if (main.Wait_IO_Check(0, 1, 7, 1, TimeSpan.FromMinutes(2)))
                        {
                            pin1 = false;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case 2:
                        if (main.Wait_IO_Check(0, 1, 7, 1, TimeSpan.FromMinutes(2)))
                        {
                            pin2 = false;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case 3:
                        if (main.Wait_IO_Check(0, 1, 7, 1, TimeSpan.FromMinutes(2)))
                        {
                            pin3 = false;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case 4:
                        if (main.Wait_IO_Check(0, 1, 7, 1, TimeSpan.FromMinutes(2)))
                        {
                            pin4 = false;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                }

            }
            if ((pin1 & pin2 & pin3 & pin4) == false)
                return true;
            else return false;

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

        private void button2_Click(object sender, EventArgs e)
        {

            var bp = mutiCam.Cam1_OneShot();
        }

        private void btn_DM_Run_Click(object sender, EventArgs e)
        {
            if (!DMRUN(autorun_Prarm.wafer_Size))
            {
                MessageBox.Show("DMRUN Fail", "Error");
            }

        }

        private void btn_TN_Run_Click(object sender, EventArgs e)
        {


            var tn_run = Task<bool>.Run(() =>
            {
                if (!TNRUN(autorun_Prarm.wafer_Size))
                {
                    MessageBox.Show("TNRUN Fail", "Error");
                    return Task.FromResult(false);
                }
                return Task.FromResult(true);
            });
            //if (!TNRUN(autorun_Prarm.wafer_Size))
            //{
            //    MessageBox.Show("DMRUN Fail", "Error");
            //}
        }

        private void btn_reset_LAser_Click(object sender, EventArgs e)
        {
            LaserReset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var col = main.db.GetCollection<RecData>("RecData");
            var recdata = new RecData();
            recdata.FileName = autorun_Prarm.file_name;
            recdata.WaferID = "12345";
            col.EnsureIndex(x => x.Id, true);
            col.Insert(recdata);
            var t = recdata.Id;

        }



        public bool CheckCondition(ref int value, int tg, TimeSpan timeout)
        {
            DateTime startTime = DateTime.Now;
            while (DateTime.Now - startTime < timeout)
            {
                // Your condition-checking logic here
                if (value == tg)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckCondition(ref bool value, bool tg, TimeSpan timeout)
        {
            DateTime startTime = DateTime.Now;
            while (DateTime.Now - startTime < timeout)
            {
                // Your condition-checking logic here
                if (value == tg)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
