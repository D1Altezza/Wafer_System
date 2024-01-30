using ACS.SPiiPlusNET;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Wafer_System
{

    public struct _EFEM_Status
    {
        /// <summary>
        /// Command error
        /// </summary>
        public string Cmd_Error;
        /// <summary>
        /// Emergency stop 
        /// 0 = EMO 
        /// 1 = No EMO 
        /// 9 = Unknown 
        /// </summary>
        public int EMG;
        /// <summary>
        /// FFU PressureDifference 
        /// 0 = PD too high 
        /// 1 = Normal 
        /// 9 = Unknown 
        /// </summary>
        public int FFU_Pressure;
        /// <summary>
        /// EFEM PositivePressure
        /// 0 =Positive Pressure not in setting range
        /// 1 = Normal 
        /// 9 = Unknown 
        /// </summary>
        public int EFEM_PositivePressure;
        /// <summary>
        /// EFEM NegativePressure
        /// 0 =Negative Pressure not in setting range
        /// 1 = Normal
        /// 9 = Unknown 
        /// </summary>
        public int EFEM_NegativePressure;
        /// <summary>
        /// Ionizer 
        /// 1 = Normal 
        /// 2 = ErrorCode 1005
        /// 3 = ErrorCode 1006
        /// 4 = ErrorCode 1007
        /// 9 = Unknown 
        /// </summary>
        public int Ionizer;
        /// <summary>
        /// Light Curtain 
        /// 0 = Invalid
        /// 1 = Valid 
        /// 9 = Unknown 
        /// </summary>
        public int Light_Curtain;
        /// <summary>
        /// FFU 
        /// 1 = Normal
        /// 2 = ErrorCode 2001
        /// 3 = ErrorCode 2002
        /// 4 = ErrorCode 2003
        /// 5 = ErrorCode 2004
        /// 6 = ErrorCode 2005
        /// 7 = ErrorCode 2006
        /// 8 = ErrorCode 2007
        /// 9 = Unknown
        /// </summary>
        public int FFU;
        /// <summary>
        /// OperationMode
        /// 0 = Local 
        /// 1 = Remote 
        /// 9 = Unknown
        /// </summary>
        public int OperationMode;
        /// <summary>
        /// RobotEnable
        /// 0 = Disable 
        /// 1 = Enable 
        /// 9 = Unknown 
        /// </summary>
        public int RobotEnable;
        /// <summary>
        /// Command error
        /// 0 = Door Open 
        /// 1 = Door Close 
        /// 9 = Unknown 
        /// </summary>
        public int Door;
    }
    public struct _Robot_Status
    {
        /// <summary>
        /// Command error
        /// </summary>
        public string Cmd_Error;
        /// <summary>
        /// Controller will return a set of four-digit string (shown by hexadecimal)
        /// </summary>
        public string Controller_State;
        /// <summary>
        /// Wafer on upper arm or not, Absence/Presence/Unknown
        /// </summary>
        public string UpPresence;
        /// <summary>
        /// Wafer on lower arm or not, Absence/Presence/Unknown
        /// </summary>
        public string LowPresence;
        /// <summary>
        /// ErrorCode
        /// </summary>
        public string ErrorCode;
    }
    public struct _Aligner_Status
    {
        /// <summary>
        /// Command error
        /// </summary>
        public string Cmd_Error;
        /// <summary>
        /// Online/NoReady/Unknown
        /// </summary>
        public string Mode;
        /// <summary>
        /// Presence/Absence
        /// </summary>
        public string WaferPresence;
        /// <summary>
        /// True/False
        /// </summary>
        public string Vacuum;
        /// <summary>
        /// ErrorCode
        /// </summary>
        public string ErrorCode;
    }
    public struct _Loadport_Status
    {
        /// <summary>
        /// Command error
        /// </summary>
        public string Cmd_Error;
        /// <summary>
        /// Online/Teaching/Maintain/Unknown
        /// </summary>
        public string Mode;
        /// <summary>
        /// NoError/Recoverable/Unrecoverable/Unknown
        /// </summary>
        public string Error;
        /// <summary>
        /// Presence/Absence/Unknown
        /// </summary>
        public string Foup;
        /// <summary>
        /// Clamp/Unclamp/Unknown
        /// </summary>
        public string Clamp;
        /// <summary>
        /// Open/Close/Unknown
        /// </summary>
        public string Door;
        /// <summary>
        /// ErrorCode
        /// </summary>
        public string ErrorCode;
    }
    public struct _SignalTower_Status
    {
        /// <summary>
        /// OK/Error
        /// </summary>
        public string Error;
        /// <summary>
        /// ErrorCode
        /// </summary>
        public string ErrorCode;
    }
    public struct _Home_Cmd
    {
        /// <summary>
        /// OK/Error
        /// </summary>
        public string Error;
        /// <summary>
        /// ErrorCode
        /// </summary>
        public string ErrorCode;
    }
    public struct _RobotSpeed_Set_Cmd
    {
        /// <summary>
        /// OK/Error
        /// </summary>
        public string Error;
        /// <summary>
        /// ErrorCode
        /// </summary>
        public string ErrorCode;
    }
    public struct _AlignmentAngle_Set_Cmd
    {
        /// <summary>
        /// OK/Error
        /// </summary>
        public string Error;
        /// <summary>
        /// ErrorCode
        /// </summary>
        public string ErrorCode;
    }

    public struct _WaferType_Set_Cmd
    {
        /// <summary>
        /// OK/Error
        /// </summary>
        public string Error;
        /// <summary>
        /// ErrorCode
        /// </summary>
        public string ErrorCode;
    }
    public struct _WaferMode_Set_Cmd
    {
        /// <summary>
        /// OK/Error
        /// </summary>
        public string Error;
        /// <summary>
        /// ErrorCode
        /// </summary>
        public string ErrorCode;
    }
    public struct _WaferSize_Set_Cmd
    {
        /// <summary>
        /// OK/Error
        /// </summary>
        public string Error;
        /// <summary>
        /// ErrorCode
        /// </summary>
        public string ErrorCode;
    }

    public struct _Reset_Error_LoadPort
    {
        /// <summary>
        /// OK/Error ErrorCode
        /// </summary>
        public string Error;
    }
    public struct _Reset_Error_Aligner
    {
        /// <summary>
        /// OK/Error ErrorCode
        /// </summary>
        public string Error;
    }
    public class EFEM_Paser
    {
        public _EFEM_Status _EFEM_Status = new _EFEM_Status();
        public _Robot_Status _Robot_Status = new _Robot_Status();
        public _Aligner_Status _Aligner1_Status = new _Aligner_Status();
        public _Loadport_Status _Loadport1_Status = new _Loadport_Status();
        public _Loadport_Status _Loadport2_Status = new _Loadport_Status();
        public _Loadport_Status _Loadport3_Status = new _Loadport_Status();
        public _SignalTower_Status _SignalTower_Status = new _SignalTower_Status();
        public _Home_Cmd _Home_Cmd = new _Home_Cmd();   
        public _RobotSpeed_Set_Cmd _RobotSpeed_Set_Cmd = new _RobotSpeed_Set_Cmd();
        public _AlignmentAngle_Set_Cmd _AlignmentAngle_Set_Cmd = new _AlignmentAngle_Set_Cmd();
        public _WaferType_Set_Cmd _WaferType_Set_Cmd = new _WaferType_Set_Cmd();
        public _WaferMode_Set_Cmd _WaferMode_Set_Cmd = new _WaferMode_Set_Cmd();
        public _WaferSize_Set_Cmd _WaferSize_Set_Cmd=new _WaferSize_Set_Cmd();
        public _Reset_Error_LoadPort _Reset_Error_LoadPort1 = new _Reset_Error_LoadPort();
        public _Reset_Error_LoadPort _Reset_Error_LoadPort2 = new _Reset_Error_LoadPort();
        public _Reset_Error_LoadPort _Reset_Error_LoadPort3 = new _Reset_Error_LoadPort();
        public _Reset_Error_Aligner _Reset_Error_Aligner1 = new _Reset_Error_Aligner();
        string[] _Robot_Controller_State = new string[16]
        {
            "Macro command has been received but not executed yet"
            ,"Reserved bit"
            ,"Vacuum sensor has been activated"
            ,"Vacuum sensor has been turned on"
            ,"Single- or multi-axis motor has error"
            ,"Single- or multi-limit switch has been triggered"
            ,"Single- or multi-axis motor has not homed successfully yet"
            ,"Resrerved bit"
            ,"Macro command is executing"
            ,"Single- or multi-axis motor is moving"
            ,"Single- or multi-axis motor is disabled"
            ,"Resrerved bit"
            ,"Resrerved bit"
            ,"Resrerved bit"
            ,"Controller has errors"
            ,"Resrerved bit"
        };
        public void _Paser(string returnCode)
        {
            string[] words = returnCode.Split('#', ',', '$');
            try
            {
                if (words[1] == "GetStatus")
                {
                    switch (words[2])
                    {
                        case "EFEM":
                            _EFEM_Status.Cmd_Error = words[3];
                            if (_EFEM_Status.Cmd_Error == "OK")
                            {
                                _EFEM_Status.EMG = Convert.ToInt32(words[4]);
                                _EFEM_Status.FFU_Pressure = Convert.ToInt32(words[5]);
                                _EFEM_Status.EFEM_PositivePressure = Convert.ToInt32(words[6]);
                                _EFEM_Status.EFEM_NegativePressure = Convert.ToInt32(words[7]);
                                _EFEM_Status.Ionizer = Convert.ToInt32(words[8]);
                                _EFEM_Status.Light_Curtain = Convert.ToInt32(words[9]);
                                _EFEM_Status.FFU = Convert.ToInt32(words[10]);
                                _EFEM_Status.OperationMode = Convert.ToInt32(words[11]);
                                _EFEM_Status.RobotEnable = Convert.ToInt32(words[12]);
                                _EFEM_Status.Door = Convert.ToInt32(words[13]);

                            }
                            else
                            {
                                //_EFEM_Status.ErrorCode = words[4];
                            }

                            break;
                        case "Robot":
                            _Robot_Status.Cmd_Error = words[3];
                            _Robot_Status.Controller_State = _Robot_Controller_State[Convert.ToInt32(words[4], 2)];
                            _Robot_Status.UpPresence = words[5];
                            _Robot_Status.LowPresence = words[6];
                            break;
                        case "Aligner1":
                            _Aligner1_Status.Cmd_Error = words[3];
                            if (_Aligner1_Status.Cmd_Error == "OK")
                            {
                                _Aligner1_Status.Mode = words[4];
                                _Aligner1_Status.WaferPresence = words[5];
                                _Aligner1_Status.Vacuum = words[6];
                            }
                            else
                            {
                                _Aligner1_Status.ErrorCode = words[4];
                            }
                            break;
                        case "Loadport1":
                            _Loadport1_Status.Cmd_Error = words[3];
                            if (_Loadport1_Status.Cmd_Error == "OK")
                            {
                                _Loadport1_Status.Cmd_Error = words[3];
                                _Loadport1_Status.Mode = words[4];
                                _Loadport1_Status.Error = words[5];
                                _Loadport1_Status.Foup = words[6];
                                _Loadport1_Status.Clamp = words[7];
                                _Loadport1_Status.Door = words[8];
                            }
                            else
                            {
                                _Loadport1_Status.ErrorCode = words[4];
                            }
                            break;
                        case "Loadport2":
                            _Loadport2_Status.Cmd_Error = words[3];
                            if (_Loadport2_Status.Cmd_Error == "OK")
                            {
                                _Loadport2_Status.Cmd_Error = words[3];
                                _Loadport2_Status.Mode = words[4];
                                _Loadport2_Status.Error = words[5];
                                _Loadport2_Status.Foup = words[6];
                                _Loadport2_Status.Clamp = words[7];
                                _Loadport2_Status.Door = words[8];
                            }
                            else
                            {
                                _Loadport2_Status.ErrorCode = words[4];
                            }
                            break;
                        case "Loadport3":
                            _Loadport3_Status.Cmd_Error = words[3];
                            if (_Loadport3_Status.Cmd_Error == "OK")
                            {
                                _Loadport3_Status.Cmd_Error = words[3];
                                _Loadport3_Status.Mode = words[4];
                                _Loadport3_Status.Error = words[5];
                                _Loadport3_Status.Foup = words[6];
                                _Loadport3_Status.Clamp = words[7];
                                _Loadport3_Status.Door = words[8];
                            }
                            else
                            {
                                _Loadport3_Status.ErrorCode = words[4];
                            }
                            break;
                    }
                }
                else if (words[1] == "SignalTower")
                {
                    switch (words[2])
                    {
                        case "EFEM":
                            _SignalTower_Status.Error = words[3];
                            if (_SignalTower_Status.Error == "OK")
                            {
                                _SignalTower_Status.ErrorCode = "";
                                break;
                            }
                            else
                            {
                                _SignalTower_Status.ErrorCode = words[4];
                            }
                            break;
                    }
                }
                else if (words[1] == "ResetError")
                {
                    switch (words[2])
                    {
                        case "Loadport1":
                            _Reset_Error_LoadPort1.Error = words[3];
                            if (_Reset_Error_LoadPort1.Error == "OK")
                            {
                                break;
                            }
                            else
                            {
                                _Reset_Error_LoadPort1.Error = words[4];
                            }
                            break;
                        case "Loadport2":
                            _Reset_Error_LoadPort2.Error = words[3];
                            if (_Reset_Error_LoadPort2.Error == "OK")
                            {
                                break;
                            }
                            else
                            {
                                _Reset_Error_LoadPort2.Error = words[4];
                            }
                            break;
                        case "Loadport3":
                            _Reset_Error_LoadPort3.Error = words[3];
                            if (_Reset_Error_LoadPort3.Error == "OK")
                            {
                                break;
                            }
                            else
                            {
                                _Reset_Error_LoadPort3.Error = words[4];
                            }
                            break;
                        case "Aligner1":
                            _Reset_Error_Aligner1.Error = words[3];
                            if (_Reset_Error_Aligner1.Error == "OK")
                            {
                                break;
                            }
                            else
                            {
                                _Reset_Error_Aligner1.Error = words[4];
                            }
                            break;

                    }
                }
                else if (words[1] == "Home")
                {
                    switch (words[2])
                    {
                        case "EFEM":
                            _Home_Cmd.Error = words[3];
                            if (_Home_Cmd.Error == "OK")
                            {
                                _Home_Cmd.ErrorCode = "";
                                break;
                            }
                            else
                            {
                                _Home_Cmd.ErrorCode = words[4];
                            }
                            break;
                    }
                }
                else if (words[1] == "SetSpeed")
                {
                    switch (words[2])
                    {
                        case "Robot":
                            _RobotSpeed_Set_Cmd.Error = words[3];
                            if (_RobotSpeed_Set_Cmd.Error == "OK")
                            {
                                _RobotSpeed_Set_Cmd.ErrorCode = "";
                                break;
                            }
                            else
                            {
                                _RobotSpeed_Set_Cmd.ErrorCode = words[4];
                            }
                            break;
                    }
                }
                else if (words[1] == "SetAlignmentAngle")
                {
                    switch (words[2])
                    {
                        case "Aligner1":
                            _AlignmentAngle_Set_Cmd.Error = words[3];
                            if (_AlignmentAngle_Set_Cmd.Error == "OK")
                            {
                                _AlignmentAngle_Set_Cmd.ErrorCode = "";
                                break;
                            }
                            else
                            {
                                _AlignmentAngle_Set_Cmd.ErrorCode = words[4];
                            }
                            break;
                    }
                }
                else if (words[1] == "SetWaferType")
                {
                    switch (words[2])
                    {
                        case "Aligner1":
                            _WaferType_Set_Cmd.Error = words[3];
                            if (_WaferType_Set_Cmd.Error == "OK")
                            {
                                _WaferType_Set_Cmd.ErrorCode = "";
                                break;
                            }
                            else
                            {
                                _WaferType_Set_Cmd.ErrorCode = words[4];
                            }
                            break;
                    }
                }
                else if (words[1] == "SetWaferMode")
                {
                    switch (words[2])
                    {
                        case "Aligner1":
                            _WaferMode_Set_Cmd.Error = words[3];
                            if (_WaferMode_Set_Cmd.Error == "OK")
                            {
                                _WaferMode_Set_Cmd.ErrorCode = "";
                                break;
                            }
                            else
                            {
                                _WaferMode_Set_Cmd.ErrorCode = words[4];
                            }
                            break;
                    }
                }
                else if (words[1] == "SetWaferSize")
                {
                    switch (words[2])
                    {
                        case "Aligner1":
                            _WaferSize_Set_Cmd.Error = words[3];
                            if (_WaferSize_Set_Cmd.Error == "OK")
                            {
                                _WaferSize_Set_Cmd.ErrorCode = "";
                                break;
                            }
                            else
                            {
                                _WaferSize_Set_Cmd.ErrorCode = words[4];
                            }
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                //werite error 
                //throw;
            }

            

        }
    }
}
