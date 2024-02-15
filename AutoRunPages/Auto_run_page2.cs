using ACS_DotNET_Library_Advanced_Demo;
using Cool_Muscle_CML_Example;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wafer_System.Config_Fun;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Wafer_System.Auto_run_page1;
using static Wafer_System.Main;
using ProgressBar = System.Windows.Forms.ProgressBar;

namespace Wafer_System
{
    public partial class Auto_run_page2 : Form
    {
        Main main;
        ProgressBar progresBar = new ProgressBar();
        Label lb_progress = new Label();
        Label lb_progress_Title = new Label();
        ConfigWR configWR;
        private Auto_run_page1.Autorun_Prarm autorun_Prarm;

        public Auto_run_page2(Main main, Auto_run_page1.Autorun_Prarm autorun_Prarm, ConfigWR configWR)
        {
            InitializeComponent();
            this.main = main;
            this.autorun_Prarm = autorun_Prarm;
            this.configWR = configWR;
        }


        private void Auto_run_page2_Load(object sender, EventArgs e)
        {
            #region Splash
            progresBar.Step = 1;
            progresBar.Width = 500;
            progresBar.Location = new Point(panel.Width / 2 - progresBar.Width / 2, panel.Height / 2 - progresBar.Height / 2);
            progresBar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            progresBar.Maximum = 150;
            panel.Controls.Add(progresBar);
            lb_progress.Location = new Point(progresBar.Location.X, progresBar.Location.Y + progresBar.Height);
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
            lb_progress_Title.Location = new Point(progresBar.Location.X, progresBar.Location.Y - lb_progress_Title.Height);
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
            var start_chk = Task.Run(() =>
            {
                Auto_run_chk();
            });

        }

        private bool Auto_run_chk()
        {
            this.BeginInvoke(new Action(() => { Progres_update(true, 15, "AutoRun Check"); }));
            //Start 燈號亮起 out6
            this.BeginInvoke(new Action(() => { lb_progress.Text = "Stop_LG_C2"; }));
            main.aCS_Motion._ACS.SetOutput(1, 6, 1);
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));


            this.BeginInvoke(new Action(() => { lb_progress.Text = "SignalTower,EFEM,ALL,OFF"; }));
            if (!main.EFEM_Light_Control("ALL", 0, "Autorun Check"))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "SignalTower,EFEM,Blue,ON"; }));
            if (!main.EFEM_Light_Control("Blue", 1, "Autorun Check"))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));
            main.d_Param.D300 = 4;

            //設定量測參數
            main.eFEM.EFEM_Cmd = "SetAlignmentAngle,Aligner1,0";
            main.eFEM._Paser._AlignmentAngle_Set_Cmd.Error = "";
            main.eFEM._Paser._AlignmentAngle_Set_Cmd.ErrorCode = "";
            main.eFEM.EFEM_Send();
            this.BeginInvoke(new Action(() => { lb_progress.Text = main.eFEM.EFEM_Cmd; }));
            main.Wait_eFEM_Received_Update(5000);
            if (main.eFEM._Paser._AlignmentAngle_Set_Cmd.Error != "OK")
            {
                MessageBox.Show(main.eFEM._Paser._AlignmentAngle_Set_Cmd.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            main.eFEM.EFEM_Cmd = "SetWaferType,Aligner1,Notch";
            main.eFEM._Paser._WaferType_Set_Cmd.Error = "";
            main.eFEM._Paser._WaferType_Set_Cmd.ErrorCode = "";
            main.eFEM.EFEM_Send();
            this.BeginInvoke(new Action(() => { lb_progress.Text = main.eFEM.EFEM_Cmd; }));
            main.Wait_eFEM_Received_Update(5000);
            if (main.eFEM._Paser._WaferType_Set_Cmd.Error != "OK")
            {
                MessageBox.Show(main.eFEM._Paser._WaferType_Set_Cmd.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            main.eFEM.EFEM_Cmd = "SetWaferMode,Aligner1,Nontransparent";
            main.eFEM._Paser._WaferMode_Set_Cmd.Error = "";
            main.eFEM._Paser._WaferMode_Set_Cmd.ErrorCode = "";
            main.eFEM.EFEM_Send();
            this.BeginInvoke(new Action(() => { lb_progress.Text = main.eFEM.EFEM_Cmd; }));
            main.Wait_eFEM_Received_Update(5000);
            if (main.eFEM._Paser._WaferMode_Set_Cmd.Error != "OK")
            {
                MessageBox.Show(main.eFEM._Paser._WaferMode_Set_Cmd.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            main.eFEM.EFEM_Cmd = "SetWaferSize,Aligner1,12";
            main.eFEM._Paser._WaferSize_Set_Cmd.Error = "";
            main.eFEM._Paser._WaferSize_Set_Cmd.ErrorCode = "";
            main.eFEM.EFEM_Send();
            this.BeginInvoke(new Action(() => { lb_progress.Text = main.eFEM.EFEM_Cmd; }));
            main.Wait_eFEM_Received_Update(5000);
            if (main.eFEM._Paser._WaferSize_Set_Cmd.Error != "OK")
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
            if (!main.Get_EFEM_Status(ref msg))
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
            main.Reset_EFEM_LoadPort(1, "AutoRun Check");
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "ResetError,Loadport2"; }));
            main.Reset_EFEM_LoadPort(2, "AutoRun Check");
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "ResetError,Loadport3"; }));
            main.Reset_EFEM_LoadPort(3, "AutoRun Check");

            if (main.eFEM._Paser._Reset_Error_LoadPort1.Error != "OK" ||
                main.eFEM._Paser._Reset_Error_LoadPort2.Error != "OK" ||
                main.eFEM._Paser._Reset_Error_LoadPort3.Error != "OK")
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }

            this.BeginInvoke(new Action(() => { lb_progress.Text = "ResetError,Aligner1"; }));
            if (!main.Reset_Aligner("AutoRun Check"))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("ResetError,Aligner1\r\n" + main.eFEM._Paser._Aligner1_Status.Cmd_Error +
                       "\r\n" + main.eFEM._Paser._Aligner1_Status.Mode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (!main.Get_Robot_Status("AutoRun Check"))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }
            if (main.eFEM._Paser._Robot_Status.Cmd_Error != "OK")
            {
                MessageBox.Show("E013\r\n" + "GetStatus,Robot\r\n" + main.eFEM._Paser._Robot_Status.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (!main.Get_Aligner_Status("AutoRun Check"))
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }
            if (main.eFEM._Paser._Aligner1_Status.Cmd_Error != "OK" || main.eFEM._Paser._Aligner1_Status.Mode != "Online")
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E014\r\n" + "GetStatus,Aligner1\r\n" + main.eFEM._Paser._Aligner1_Status.Mode + "\r\n" +
                    main.eFEM._Paser._Aligner1_Status.Cmd_Error + "\r\n" +
                    main.eFEM._Paser._Aligner1_Status.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (main.eFEM._Paser._Aligner1_Status.WaferPresence != "Absence")
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E033\r\n" + "GetStatus,Aligner1,WaferPresence\r\n" + main.eFEM._Paser._Aligner1_Status.WaferPresence, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            main.d_Param.D102 = 0;
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));


            this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,Loadport1"; }));
            main.Get_EFEM_LoadPort_Status(1, "Initial Home");

            this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,Loadport2"; }));
            main.Get_EFEM_LoadPort_Status(2, "Initial Home");
            this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,Loadport3"; }));
            main.Get_EFEM_LoadPort_Status(3, "Initial Home");


            if (main.eFEM._Paser._Loadport1_Status.Foup != "Presence")
                MessageBox.Show("E040\r\n" + "GetStatus,Loadport1\r\n" + main.eFEM._Paser._Loadport1_Status.Foup);
            if (main.eFEM._Paser._Loadport2_Status.Foup != "Presence")
                MessageBox.Show("E041\r\n" + "GetStatus,Loadport2\r\n" + main.eFEM._Paser._Loadport2_Status.Foup);
            if (main.eFEM._Paser._Loadport3_Status.Foup != "Presence")
                MessageBox.Show("E042\r\n" + "GetStatus,Loadport3\r\n" + main.eFEM._Paser._Loadport3_Status.Foup);



            if (main.eFEM._Paser._Loadport1_Status.Cmd_Error != "OK"
                || main.eFEM._Paser._Loadport2_Status.Cmd_Error != "OK"
                || main.eFEM._Paser._Loadport3_Status.Cmd_Error != "OK"
                || main.eFEM._Paser._Loadport1_Status.Error != "NoError"
                || main.eFEM._Paser._Loadport2_Status.Error != "NoError"
                || main.eFEM._Paser._Loadport3_Status.Error != "NoError")
            {
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
            main.aCS_Motion._ACS.Command("PTP/V 2," + configWR.ReadSettings("AL") + "," + configWR.ReadSettings("DD_Vel"));
            Thread.Sleep(1000);
            main.wait_axis_Inp("z", 100000);

            this.BeginInvoke(new Action(() => { progresBar.Increment(2); }));


            var a_in_load_pos = (main.aCS_Motion.m_A_lfFPos == Convert.ToDouble(configWR.ReadSettings("AL")));
            this.BeginInvoke(new Action(() => { lb_progress.Text = "A_LS(CMnt_IN3)"; }));
            if (!main.pass && !main.Wait_IO_Check(0, 1, 3, 1, 120000) || !a_in_load_pos)
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
            main.cML.Query("?69");
            main.Wait_Cm1_Received_Update();
            var z_in_zero_pos = (main.cML.recData == configWR.ReadSettings("Z0"));
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "MOVE TO (XL,YL)..."; }));
            //TN-XY move to XL,YL
            main.aCS_Motion._ACS.Command("PTP(0,1)," + configWR.ReadSettings("XL") + "," + configWR.ReadSettings("YL"));
            Thread.Sleep(1000);
            main.wait_axis_Inp("x", 100000);
            main.wait_axis_Inp("y", 100000);
            this.BeginInvoke(new Action(() => { progresBar.Increment(2); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "XN1_ON ON..."; }));
            //OUT8
            main.aCS_Motion._ACS.SetOutput(1, 8, 1);
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));


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
            main.aCS_Motion._ACS.SetOutput(1, 9, 0);
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
            main.aCS_Motion._ACS.Command("PTP(0,1)," + configWR.ReadSettings("XL") + "," + configWR.ReadSettings("YL"));
            Thread.Sleep(1000);
            main.wait_axis_Inp("x", 100000);
            main.wait_axis_Inp("y", 100000);
            this.BeginInvoke(new Action(() => { progresBar.Increment(2); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "Check XY in load position..."; }));
            var xy_in_load_pos = (main.aCS_Motion.m_X_lfFPos == Convert.ToDouble(configWR.ReadSettings("XL")) &&
                   main.aCS_Motion.m_Y_lfFPos == Convert.ToDouble(configWR.ReadSettings("YL")));
            if (!xy_in_load_pos)
            {
                MessageBox.Show("E173\r\n"+"X,Y not in load postion", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));

                return false;
            }
            this.BeginInvoke(new Action(() => { lb_progress.Text = "Check X_LS ON..."; }));
            if (!main.Wait_IO_Check(0, 0, 0, 1, 10000))
            {
                MessageBox.Show("E173\r\n"+"X_LS CMnT_IN0 not on", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));

                return false;
            }
            this.BeginInvoke(new Action(() => { lb_progress.Text = "Check Y_LS ON..."; }));
            if (!main.Wait_IO_Check(0, 0, 1, 1, 10000))
            {
                MessageBox.Show("E173" + "Y_LS CMnT_IN1 not on", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));

                return false;
            }
            this.BeginInvoke(new Action(() => { lb_progress.Text = "Check IOMps IN2 ON..."; }));
            if (!main.Wait_IO_Check(0, 1, 2, 1, 10000))
            {
                MessageBox.Show("IN2 not on", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));

                return false;
            }
            this.BeginInvoke(new Action(() => { lb_progress.Text = "Check Z in load pos..."; }));
            main.cML.Query("?69");
            main.Wait_Cm1_Received_Update();
            //當前位置回傳格式未檢查----待修正              
            var z_in_load_pos = (main.cML.recData == configWR.ReadSettings("ZL"));
            if (!z_in_load_pos) 
            {
                MessageBox.Show("E175"+"Z not in looad pos", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));

                return false;
            }
            this.BeginInvoke(new Action(() => { lb_progress.Text = "Check Z_LS..."; }));
            if (!main.Wait_IO_Check(0, 0, 2, 1, 10000))
            {
                MessageBox.Show("Z_LS IN2 not on", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));

                return false;
            }

            this.BeginInvoke(new Action(() => { lb_progress.Text = "TNWAFER..."; }));
            //-------pass
            if (!main.pass && (!main.TNWAFER(ref main.d_Param.D111)))
            {
                MessageBox.Show("E058", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new Action(() =>
                {
                    Progres_update(false);
                }));

                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "Load LoadPort1..."; }));
            main.eFEM.EFEM_Cmd = "Load,Loadport1";
            main.eFEM._Paser._Cmd_Loadport.Error = "";
            main.eFEM._Paser._Cmd_Loadport.ErrorCode = "";
            main.eFEM.EFEM_Send();
            main.Wait_eFEM_Received_Update(main.efem_timeout);
            if (main.eFEM._Paser._Cmd_Loadport.Error != "OK")
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E043\r\n" + "Load,Loadport1\r\n" + main.eFEM._Paser._Cmd_Loadport.Error+"\r\n"+main.eFEM._Paser._Cmd_Loadport.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            this.BeginInvoke(new Action(() => { lb_progress.Text = "Load LoadPort2..."; }));
            main.eFEM.EFEM_Cmd = "Load,Loadport2";
            main.eFEM._Paser._Cmd_Loadport.Error = "";
            main.eFEM._Paser._Cmd_Loadport.ErrorCode = "";
            main.eFEM.EFEM_Send();
            main.Wait_eFEM_Received_Update(main.efem_timeout);
            if (main.eFEM._Paser._Cmd_Loadport.Error != "OK")
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E044\r\n" + "Load,Loadport2\r\n" + main.eFEM._Paser._Cmd_Loadport.Error + "\r\n" + main.eFEM._Paser._Cmd_Loadport.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            this.BeginInvoke(new Action(() => { lb_progress.Text = "Load LoadPort3..."; }));
            main.eFEM.EFEM_Cmd = "Load,Loadport3";
            main.eFEM._Paser._Cmd_Loadport.Error = "";
            main.eFEM._Paser._Cmd_Loadport.ErrorCode = "";
            main.eFEM.EFEM_Send();
            main.Wait_eFEM_Received_Update(main.efem_timeout);
            if (main.eFEM._Paser._Cmd_Loadport.Error != "OK")
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E045\r\n" + "Load,Loadport3\r\n" + main.eFEM._Paser._Cmd_Loadport.Error + "\r\n" + main.eFEM._Paser._Cmd_Loadport.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



            

            this.BeginInvoke(new Action(() => { lb_progress.Text = "Get Current LPWaferSize Loadport1..."; }));
            main.eFEM.EFEM_Cmd = " GetCurrentLPWaferSize,Loadport1";
            main.eFEM._Paser._GetCurrentLPWaferSize.Error = "";
            main.eFEM._Paser._GetCurrentLPWaferSize.ErrorCode = "";
            main.eFEM.EFEM_Send();
            main.Wait_eFEM_Received_Update(main.efem_timeout);
            if (main.eFEM._Paser._GetCurrentLPWaferSize.Error != "OK" || main.eFEM._Paser._GetCurrentLPWaferSize.Result!= autorun_Prarm.wafer_Size.ToString())
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E046\r\n" + "GetCurrentLPWaferSize,Loadport1\r\n" + main.eFEM._Paser._GetCurrentLPWaferSize.Error +
                    "\r\n" + main.eFEM._Paser._GetCurrentLPWaferSize.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            this.BeginInvoke(new Action(() => { lb_progress.Text = "Get Current LPWaferSize Loadport2..."; }));
            main.eFEM.EFEM_Cmd = " GetCurrentLPWaferSize,Loadport2";
            main.eFEM._Paser._GetCurrentLPWaferSize.Error = "";
            main.eFEM._Paser._GetCurrentLPWaferSize.ErrorCode = "";
            main.eFEM.EFEM_Send();
            main.Wait_eFEM_Received_Update(main.efem_timeout);
            if (main.eFEM._Paser._GetCurrentLPWaferSize.Error != "OK" || main.eFEM._Paser._GetCurrentLPWaferSize.Result != autorun_Prarm.wafer_Size.ToString())
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E047\r\n" + "GetCurrentLPWaferSize,Loadport2\r\n" + main.eFEM._Paser._GetCurrentLPWaferSize.Error +
                    "\r\n" + main.eFEM._Paser._GetCurrentLPWaferSize.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            this.BeginInvoke(new Action(() => { lb_progress.Text = "Get Current LPWaferSize Loadport3..."; }));
            main.eFEM.EFEM_Cmd = " GetCurrentLPWaferSize,Loadport3";
            main.eFEM._Paser._GetCurrentLPWaferSize.Error = "";
            main.eFEM._Paser._GetCurrentLPWaferSize.ErrorCode = "";
            main.eFEM.EFEM_Send();
            main.Wait_eFEM_Received_Update(main.efem_timeout);
            if (main.eFEM._Paser._GetCurrentLPWaferSize.Error != "OK" || main.eFEM._Paser._GetCurrentLPWaferSize.Result != autorun_Prarm.wafer_Size.ToString())
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E047\r\n" + "GetCurrentLPWaferSize,Loadport3\r\n" + main.eFEM._Paser._GetCurrentLPWaferSize.Error +
                    "\r\n" + main.eFEM._Paser._GetCurrentLPWaferSize.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            this.BeginInvoke(new Action(() => { Progres_update(false); progresBar.Hide(); }));
            return true;
        }
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
                main.aCS_Motion._ACS.Command("PTP(0,1)," + configWR.ReadSettings("Xp" + i) + "," + configWR.ReadSettings("Yp" + i));
                Thread.Sleep(1000);
                main.wait_axis_Inp("x", 100000);
                main.wait_axis_Inp("y", 100000);
                switch (i)
                {
                    case 1:
                        if (main.Wait_IO_Check(0, 1, 7, 1, 1000))
                        {
                            pin1 = true;
                        }                       
                        break;
                    case 2:
                        if (main.Wait_IO_Check(0, 1, 7, 1, 1000))
                        {
                            pin2 = true;
                        }
                        break;
                    case 3:
                        if (main.Wait_IO_Check(0, 1, 7, 1, 1000))
                        {
                            pin3 = true;
                        }
                        break;
                    case 4:
                        if (main.Wait_IO_Check(0, 1, 7, 1, 1000))
                        {
                            pin4 = true;
                        }
                        break;
                }
             
            }
            if (pin1 & pin2 & pin3 & pin4)
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


    }
}
