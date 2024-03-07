using ACS_DotNET_Library_Advanced_Demo;
using Cool_Muscle_CML_Example;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            if (!main.EFEM_Light_Control("All", 0, "Autorun Check"))
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
            if (main.eFEM._Paser._Reset_Error_LoadPort.Error != "OK")
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "ResetError,Loadport2"; }));
            main.Reset_EFEM_LoadPort(2, "AutoRun Check");
            if (main.eFEM._Paser._Reset_Error_LoadPort.Error != "OK")
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }
            this.BeginInvoke(new Action(() => { progresBar.Increment(1); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "ResetError,Loadport3"; }));
            main.Reset_EFEM_LoadPort(3, "AutoRun Check");
            if (main.eFEM._Paser._Reset_Error_LoadPort.Error != "OK")
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }

            this.BeginInvoke(new Action(() => { lb_progress.Text = "ResetError,Aligner1"; }));
            if (!main.Reset_Aligner("AutoRun Check"))
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
            if (main.eFEM._Paser._Aligner_Status.Cmd_Error != "OK" || main.eFEM._Paser._Aligner_Status.Mode != "Online")
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
            main.Get_EFEM_LoadPort_Status(1, "Initial Home", true);
            if (main.eFEM._Paser._Loadport_Status.Foup != "Presence")
            {
                MessageBox.Show("E040\r\n" + "GetStatus,Loadport1\r\n" + main.eFEM._Paser._Loadport_Status.Foup);
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }

            this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,Loadport2"; }));
            main.Get_EFEM_LoadPort_Status(2, "Initial Home", true);
            if (main.eFEM._Paser._Loadport_Status.Foup != "Presence")
            {
                MessageBox.Show("E041\r\n" + "GetStatus,Loadport2\r\n" + main.eFEM._Paser._Loadport_Status.Foup);
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }
            this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,Loadport3"; }));
            main.Get_EFEM_LoadPort_Status(3, "Initial Home", true);
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
            main.cML.Query("?96");
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
            main.aCS_Motion._ACS.Command("PTP(0,1)," + configWR.ReadSettings("XL") + "," + configWR.ReadSettings("YL"));
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
            main.aCS_Motion._ACS.Command("PTP(0,1)," + configWR.ReadSettings("XL") + "," + configWR.ReadSettings("YL"));
            Thread.Sleep(1000);
            main.wait_axis_Inp("x", 100000);
            main.wait_axis_Inp("y", 100000);
            this.BeginInvoke(new Action(() => { progresBar.Increment(2); }));

            this.BeginInvoke(new Action(() => { lb_progress.Text = "Check XY in load position..."; }));
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
            if (!main.Wait_IO_Check(0, 0, 0, 1, 10000))
            {
                MessageBox.Show("E173\r\n" + "X_LS CMnT_IN0 not on", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            this.BeginInvoke(new Action(() => { lb_progress.Text = "Pin UP..."; }));
            main.cML.pin_Up();
            if (!main.Wait_IO_Check(0, 0, 2, 1, 300000))
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
            Thread.Sleep(500);
            main.cML.Query("?96");
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
            //this.BeginInvoke(new Action(() => { lb_progress.Text = "Check Z_LS..."; }));
            //if (!main.Wait_IO_Check(0, 0, 2, 1, 10000))
            //{
            //    MessageBox.Show("Z_LS IN2 not on", "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.BeginInvoke(new Action(() =>
            //    {
            //        Progres_update(false);
            //    }));

            //    return false;
            //}


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
            main.eFEM.EFEM_Cmd = "Load,Loadport1";
            main.eFEM._Paser._Cmd_Loadport.Error = "";
            main.eFEM._Paser._Cmd_Loadport.ErrorCode = "";
            main.eFEM.EFEM_Send();
            main.Wait_eFEM_Received_Update(main.efem_timeout);
            if (main.eFEM._Paser._Cmd_Loadport.Error != "OK")
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E043\r\n" + "Load,Loadport1\r\n" + main.eFEM._Paser._Cmd_Loadport.Error + "\r\n" + main.eFEM._Paser._Cmd_Loadport.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            main.eFEM.EFEM_Cmd = "GetCurrentLPWaferSize,Loadport1";
            main.eFEM._Paser._GetCurrentLPWaferSize.Error = "";
            main.eFEM._Paser._GetCurrentLPWaferSize.ErrorCode = "";
            main.eFEM.EFEM_Send();
            main.Wait_eFEM_Received_Update(main.efem_timeout);
            if (main.eFEM._Paser._GetCurrentLPWaferSize.Error != "OK" || main.eFEM._Paser._GetCurrentLPWaferSize.Result != autorun_Prarm.wafer_Size.ToString())
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E046\r\n" + "GetCurrentLPWaferSize,Loadport1\r\n" + main.eFEM._Paser._GetCurrentLPWaferSize.Error +
                    "\r\n" + main.eFEM._Paser._GetCurrentLPWaferSize.ErrorCode, "AutoRun Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            this.BeginInvoke(new Action(() => { lb_progress.Text = "Get Current LPWaferSize Loadport2..."; }));
            main.eFEM.EFEM_Cmd = "GetCurrentLPWaferSize,Loadport2";
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
            main.eFEM.EFEM_Cmd = "GetCurrentLPWaferSize,Loadport3";
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




        public string[] cassett1_status = new string[25];
        public string[] cassett2_status = new string[25];
        public string[] cassett3_status = new string[25];
        private bool Auto_run()
        {
            this.BeginInvoke(new Action(() => { lb_progress.Text = "Check D400=0..."; }));
            if (main.d_Param.D400 == 0)
            {
                this.BeginInvoke(new Action(() => { Progres_update(true, 20, "AutoRun "); }));
                this.BeginInvoke(new Action(() => { lb_progress.Text = "Mapping Cassette1..."; }));
                if (!MappingCassette(1, out cassett1_status))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    MessageBox.Show("MappingCassette(1) Fail", "AutoRun ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                this.BeginInvoke(new Action(() => { lb_progress.Text = "Mapping Cassette2..."; }));
                if (!MappingCassette(2, out cassett2_status))
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    MessageBox.Show("MappingCassette(2) Fail", "AutoRun ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                this.BeginInvoke(new Action(() => { lb_progress.Text = "Mapping Cassette3..."; }));
                if (!MappingCassette(3, out cassett3_status))
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
                            if (!ANRUN())
                            {
                                MessageBox.Show("ANRUN Fail", "Error");
                                return false;
                            }
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
                            MessageBox.Show("LAgetAN Fail", "Error");
                            return false;
                        }
                        //Step11
                        main.d_Param.D300 = 11;
                        if (main.d_Param.D102 != 1 || main.d_Param.D123 != 0 || main.d_Param.D124 != 0)
                        {
                            MessageBox.Show("Step11 Fail", "Error");
                            return false;
                        }
                        if (!ANRUN())
                        {
                            MessageBox.Show("ANRUN Fail", "Error");
                            return false;
                        }
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
                        return true;
                    }
                }


            }
            else if (main.d_Param.D400 == 1)
            {
                //go end
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool LAputDM()
        {
            this.BeginInvoke(new Action(() => { lb_progress.Text = "LAputDM..."; }));
            main.d_Param.D125 = 1;
            var a_in_load_pos = (Math.Round(main.aCS_Motion.m_A_lfFPos,2) == Convert.ToDouble(configWR.ReadSettings("AL")));
            var IN3 = main.aCS_Motion._ACS.GetInput(1, 3);
            var IN1 = main.aCS_Motion._ACS.GetInput(1, 1);
            //chaeck DD motor in loadposition
            if (!a_in_load_pos || IN3 != 1)
            {
                //DD motor move to loadposition
                if (IN1!=1)
                {
                    MessageBox.Show("Robot in DM station");
                    return false;
                }
                main.aCS_Motion._ACS.Command("PTP/v 0," + Convert.ToDouble(configWR.ReadSettings("AL") + ",1000"));
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
            if (!UALAWAFER() || main.d_Param.D101 != 1 )
            {
                MessageBox.Show("E054\r\nUALAWAFER Fail\r\nManual remove robot wafer then manual reset home", "LAputDM Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (main.d_Param.D110!=0)
            {
                MessageBox.Show("D110!=0");
                return false;
            }
            else
            {
                main.aCS_Motion._ACS.SetOutput(1, 1, 1);
            }
            if (main.d_Param.D110!=0 ||main.d_Param.D101!=1)
            {
                MessageBox.Show("D110!=0 OR D101!=1");
                return false;
            }
            this.BeginInvoke(new Action(() => { lb_progress.Text = "SmartPut,Robot..."; }));
            main.eFEM.EFEM_Cmd = "SmartPut,Robot,LowArm,Stage2,1";
            main.eFEM._Paser._SmartPut_Robot.Error = "";
            main.eFEM._Paser._SmartPut_Robot.ErrorCode = "";
            main.eFEM.EFEM_Send();
            main.Wait_eFEM_Received_Update(main.efem_timeout);
            if (main.eFEM._Paser._SmartPut_Robot.Error != "OK")
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("SmartPut,Robot\r\n" + main.eFEM._Paser._SmartPut_Robot.Error +
                    "\r\n" + main.eFEM._Paser._SmartPut_Robot.ErrorCode, "LAputDM Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!main.Wait_IO_Check(0, 1, 1, 1, 120000))
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
            this.BeginInvoke(new Action(() => { lb_progress.Text = "UALAWAFER"; }));
            if (!UALAWAFER() || main.d_Param.D101 != 0)
            {
                MessageBox.Show("E032\r\nUALAWAFER Fail\r\nManual remove robot wafer then manual reset home", "LAputDM Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            main.d_Param.D125 = 0;
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
                var get_index = Array.FindIndex(cassett1_status, x => x == "Presence");
                if (get_index == -1)
                {
                    return false;
                }
                main.eFEM.EFEM_Cmd = "SmartGet,Robot,LowArm,Loadport1," + (Convert.ToInt32(get_index) + 1);//取有片的位置
                main.eFEM._Paser._SmartGet_Robot.Error = "";
                main.eFEM._Paser._SmartGet_Robot.ErrorCode = "";
                main.eFEM.EFEM_Send();
                main.Wait_eFEM_Received_Update(main.efem_timeout);
                if (main.eFEM._Paser._SmartGet_Robot.Error != "OK")
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    MessageBox.Show("SmartGet,Robot$\r\n" + main.eFEM._Paser._SmartGet_Robot.Error +
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
                        main.d_Param.D124 = 0;
                        return true;
                    }
                }
            }
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
            this.BeginInvoke(new Action(() => { lb_progress.Text = "Alignment,Aligner1..."; }));
            main.eFEM.EFEM_Cmd = "Alignment,Aligner1";
            main.eFEM._Paser._Alignment_Aligner.Error = "";
            main.eFEM._Paser._Alignment_Aligner.ErrorCode = "";
            main.eFEM.EFEM_Send();
            main.Wait_eFEM_Received_Update(main.efem_timeout);
            if (main.eFEM._Paser._Alignment_Aligner.Error != "OK")
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("Alignment,Aligner1\r\n" + main.eFEM._Paser._Alignment_Aligner.Error +
                    "\r\n" + main.eFEM._Paser._Alignment_Aligner.ErrorCode, "Alignment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            main.d_Param.D131 = 1;
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
                main.eFEM.EFEM_Cmd = "SmartPut,Robot,UpArm,Aligner1,1";
                main.eFEM._Paser._SmartPut_Robot.Error = "";
                main.eFEM._Paser._SmartPut_Robot.ErrorCode = "";
                main.eFEM.EFEM_Send();
                main.Wait_eFEM_Received_Update(main.efem_timeout);
                if (main.eFEM._Paser._SmartPut_Robot.Error != "OK")
                {
                    this.BeginInvoke(new Action(() => { Progres_update(false); }));
                    MessageBox.Show("SmartPut,Robot\r\n" + main.eFEM._Paser._SmartPut_Robot.Error +
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
                if (!MappingCassette(1, out cassett1_status))
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
                        main.eFEM.EFEM_Cmd = "SmartGet,Robot,UpArm,Loadport1," + (Convert.ToInt32(get_index) + 1);//取有片的位置
                        main.eFEM._Paser._SmartGet_Robot.Error = "";
                        main.eFEM._Paser._SmartGet_Robot.ErrorCode = "";
                        main.eFEM.EFEM_Send();
                        main.Wait_eFEM_Received_Update(main.efem_timeout);
                        if (main.eFEM._Paser._SmartGet_Robot.Error != "OK")
                        {
                            this.BeginInvoke(new Action(() => { Progres_update(false); }));
                            MessageBox.Show("SmartGet,Robot$\r\n" + main.eFEM._Paser._SmartGet_Robot.Error +
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
                                cassett1_status[get_index] = "Absence";
                                return true;
                            }
                        }
                    }
                }
            }
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
        /// <returns>很煩...變數已經夠多了...一直重複定義...複雜化大師....
        /// D100是上手臂有沒有料、D101是下手臂有沒有料
        /// D100,D101 對應 UpPresence,LowPresence
        /// </returns>
        public bool UALAWAFER()
        {
            this.BeginInvoke(new Action(() => { lb_progress.Text = "GetStatus,Robot..."; }));
            main.eFEM.EFEM_Cmd = "GetStatus,Robot";
            main.eFEM._Paser._Robot_Status.Cmd_Error = "";
            main.eFEM._Paser._Robot_Status.ErrorCode = "";
            main.eFEM._Paser._Robot_Status.UpPresence = "";
            main.eFEM._Paser._Robot_Status.LowPresence = "";
            main.eFEM.EFEM_Send();
            main.Wait_eFEM_Received_Update(main.efem_timeout);
            if (main.eFEM._Paser._Robot_Status.Cmd_Error != "OK")
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

        private bool MappingCassette(int loadport, out string[] map_status)
        {
            this.BeginInvoke(new Action(() => { lb_progress.Text = "Cssette_Mapping..."; }));
        Cssette_Mapping:
            this.BeginInvoke(new Action(() => { lb_progress.Text = "Loadport" + loadport + " Get Map Result..."; }));
            main.eFEM.EFEM_Cmd = "GetMapResult,Loadport" + loadport;
            main.eFEM._Paser._GetMapResult.Error = "";
            main.eFEM._Paser._GetMapResult.ErrorCode = "";
            main.eFEM.EFEM_Send();
            main.Wait_eFEM_Received_Update(main.efem_timeout);
            if (main.eFEM._Paser._GetMapResult.Error != "OK")
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                MessageBox.Show("E046\r\n" + "GetMapResult,Loadport" + loadport + "\r\n" + main.eFEM._Paser._GetCurrentLPWaferSize.Error +
                    "\r\n" + main.eFEM._Paser._GetMapResult.ErrorCode, "AutoRun ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                map_status = null;
                return false;
            }
            else if (main.eFEM._Paser._GetMapResult.Result.Contains("Tilted") ||
                main.eFEM._Paser._GetMapResult.Result.Contains("Overlapping") ||
                main.eFEM._Paser._GetMapResult.Result.Contains("Thin") ||
                main.eFEM._Paser._GetMapResult.Result.Contains("UpDown"))//!main.eFEM._Paser._GetMapResult.Result.All(x => x == "Presence") ||
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
            _map_status = main.eFEM._Paser._GetMapResult.Result.Reverse().ToArray();
            map_status = _map_status;
            return true;
        }

        CancellationTokenSource tokenSource = new CancellationTokenSource();

        private bool Cassette_Change(int loadport)
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
            if (main.eFEM._Paser._Reset_Error_LoadPort.Error != "OK")
            {
                this.BeginInvoke(new Action(() => { Progres_update(false); }));
                return false;
            }

            return true;
        }

        private bool Check_Cassette_Changed(int loadport)
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
                main.aCS_Motion._ACS.Command("PTP(0,1)," + configWR.ReadSettings("Xp" + i) + "," + configWR.ReadSettings("Yp" + i));
                Thread.Sleep(1000);
                main.wait_axis_Inp("x", 100000);
                main.wait_axis_Inp("y", 100000);
                switch (i)
                {
                    case 1:
                        if (main.Wait_IO_Check(0, 1, 7, 0, 120000))
                        {
                            pin1 = false;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case 2:
                        if (main.Wait_IO_Check(0, 1, 7, 0, 120000))
                        {
                            pin2 = false;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case 3:
                        if (main.Wait_IO_Check(0, 1, 7, 0, 120000))
                        {
                            pin3 = false;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case 4:
                        if (main.Wait_IO_Check(0, 1, 7, 0, 120000))
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


    }
}
