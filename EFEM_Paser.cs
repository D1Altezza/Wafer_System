using ACS.SPiiPlusNET;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    public struct _Cmd_Loadport
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

    public struct _GetCurrentLPWaferSize
    {
        /// <summary>
        /// 4: 8inch,6: 12inch
        /// </summary>
        public string Result;
        /// <summary>
        /// OK/Error
        /// </summary>
        public string Error;
        /// <summary>
        /// ErrorCode
        /// </summary>
        public string ErrorCode;
    }

    enum map_result_state
    {
        Absence,
        Presence, 
        Tilted , 
        Overlapping ,
        Thin , 
        UpDown, 
        tile ,
        Unknown

    }
    public struct _GetMapResult
    {

        /// <summary>
        /// Slot1~Slot25
        /// 0: Absence 1: Presence 2: Tilted 3: Overlapping 4: Thin 5: Up/Down tile 9:Unknown
        /// </summary>
        public string[] Result;
        /// <summary>
        /// OK/Error
        /// </summary>
        public string Error;
        /// <summary>
        /// ErrorCode
        /// </summary>
        public string ErrorCode;
    }

    public class EFEM_Paser
    {
        public _EFEM_Status _EFEM_Status = new _EFEM_Status();
        public _Robot_Status _Robot_Status = new _Robot_Status();
        public _Aligner_Status _Aligner1_Status = new _Aligner_Status();
        public _Loadport_Status _Loadport_Status = new _Loadport_Status();       
        public _SignalTower_Status _SignalTower_Status = new _SignalTower_Status();
        public _Home_Cmd _Home_Cmd = new _Home_Cmd();
        public _RobotSpeed_Set_Cmd _RobotSpeed_Set_Cmd = new _RobotSpeed_Set_Cmd();
        public _AlignmentAngle_Set_Cmd _AlignmentAngle_Set_Cmd = new _AlignmentAngle_Set_Cmd();
        public _WaferType_Set_Cmd _WaferType_Set_Cmd = new _WaferType_Set_Cmd();
        public _WaferMode_Set_Cmd _WaferMode_Set_Cmd = new _WaferMode_Set_Cmd();
        public _WaferSize_Set_Cmd _WaferSize_Set_Cmd = new _WaferSize_Set_Cmd();
        public _Reset_Error_LoadPort _Reset_Error_LoadPort1 = new _Reset_Error_LoadPort();
        public _Reset_Error_LoadPort _Reset_Error_LoadPort2 = new _Reset_Error_LoadPort();
        public _Reset_Error_LoadPort _Reset_Error_LoadPort3 = new _Reset_Error_LoadPort();
        public _Reset_Error_Aligner _Reset_Error_Aligner1 = new _Reset_Error_Aligner();
        public _Cmd_Loadport _Cmd_Loadport = new _Cmd_Loadport();
        public _GetCurrentLPWaferSize _GetCurrentLPWaferSize = new _GetCurrentLPWaferSize();
        public _GetMapResult _GetMapResult = new _GetMapResult();

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
            _GetMapResult.Result = new string[25];
            string[] words = returnCode.Split(',');

            try
            {
                if (words[0] == "GetStatus")
                {
                    switch (words[1])
                    {
                        case "EFEM":
                            _EFEM_Status.Cmd_Error = words[2];
                            if (_EFEM_Status.Cmd_Error == "OK")
                            {
                                _EFEM_Status.EMG = Convert.ToInt32(words[3]);
                                _EFEM_Status.FFU_Pressure = Convert.ToInt32(words[4]);
                                _EFEM_Status.EFEM_PositivePressure = Convert.ToInt32(words[5]);
                                _EFEM_Status.EFEM_NegativePressure = Convert.ToInt32(words[6]);
                                _EFEM_Status.Ionizer = Convert.ToInt32(words[7]);
                                _EFEM_Status.Light_Curtain = Convert.ToInt32(words[8]);
                                _EFEM_Status.FFU = Convert.ToInt32(words[9]);
                                _EFEM_Status.OperationMode = Convert.ToInt32(words[10]);
                                _EFEM_Status.RobotEnable = Convert.ToInt32(words[11]);
                                _EFEM_Status.Door = Convert.ToInt32(words[12]);

                            }
                            else
                            {
                                //_EFEM_Status.ErrorCode = words[4];
                            }

                            break;
                        case "Robot":
                            _Robot_Status.Cmd_Error = words[2];
                            //_Robot_Status.Controller_State = _Robot_Controller_State[Convert.ToInt32(words[3], 2)];
                            _Robot_Status.UpPresence = words[4];
                            _Robot_Status.LowPresence = words[5];
                            break;
                        case "Aligner1":
                            _Aligner1_Status.Cmd_Error = words[2];
                            if (_Aligner1_Status.Cmd_Error == "OK")
                            {
                                _Aligner1_Status.Mode = words[3];
                                _Aligner1_Status.WaferPresence = words[4];
                                _Aligner1_Status.Vacuum = words[5];
                            }
                            else
                            {
                                _Aligner1_Status.ErrorCode = words[3];
                            }
                            break;
                        case string s when s.Substring(0, s.Length - 1) == "Loadport":
                            _Loadport_Status.Cmd_Error = words[2];
                            if (_Loadport_Status.Cmd_Error == "OK")
                            {
                                _Loadport_Status.Cmd_Error = words[2];
                                _Loadport_Status.Mode = words[3];
                                _Loadport_Status.Error = words[4];
                                _Loadport_Status.Foup = words[5];
                                _Loadport_Status.Clamp = words[6];
                                _Loadport_Status.Door = words[7];
                            }
                            else
                            {
                                _Loadport_Status.ErrorCode = words[3];
                            }
                            break;                      
                    }
                }
                else if (words[0] == "SignalTower")
                {
                    switch (words[1])
                    {
                        case "EFEM":
                            _SignalTower_Status.Error = words[2];
                            if (_SignalTower_Status.Error == "OK")
                            {
                                _SignalTower_Status.ErrorCode = "";
                                break;
                            }
                            else
                            {
                                _SignalTower_Status.ErrorCode = words[3];
                            }
                            break;
                    }
                }
                else if (words[0] == "ResetError")
                {
                    switch (words[1])
                    {
                        case "Loadport1":
                            _Reset_Error_LoadPort1.Error = words[2];
                            if (_Reset_Error_LoadPort1.Error == "OK")
                            {
                                break;
                            }
                            else
                            {
                                _Reset_Error_LoadPort1.Error = words[3];
                            }
                            break;
                        case "Loadport2":
                            _Reset_Error_LoadPort2.Error = words[2];
                            if (_Reset_Error_LoadPort2.Error == "OK")
                            {
                                break;
                            }
                            else
                            {
                                _Reset_Error_LoadPort2.Error = words[3];
                            }
                            break;
                        case "Loadport3":
                            _Reset_Error_LoadPort3.Error = words[2];
                            if (_Reset_Error_LoadPort3.Error == "OK")
                            {
                                break;
                            }
                            else
                            {
                                _Reset_Error_LoadPort3.Error = words[3];
                            }
                            break;
                        case "Aligner1":
                            _Reset_Error_Aligner1.Error = words[2];
                            if (_Reset_Error_Aligner1.Error == "OK")
                            {
                                break;
                            }
                            else
                            {
                                _Reset_Error_Aligner1.Error = words[3];
                            }
                            break;

                    }
                }
                else if (words[0] == "Home")
                {
                    switch (words[1])
                    {
                        case "EFEM":
                            _Home_Cmd.Error = words[2];
                            if (_Home_Cmd.Error == "OK")
                            {
                                _Home_Cmd.ErrorCode = "";
                                break;
                            }
                            else
                            {
                                _Home_Cmd.ErrorCode = words[3];
                            }
                            break;
                    }
                }
                else if (words[0] == "SetSpeed")
                {
                    switch (words[1])
                    {
                        case "Robot":
                            _RobotSpeed_Set_Cmd.Error = words[2];
                            if (_RobotSpeed_Set_Cmd.Error == "OK")
                            {
                                _RobotSpeed_Set_Cmd.ErrorCode = "";
                                break;
                            }
                            else
                            {
                                _RobotSpeed_Set_Cmd.ErrorCode = words[3];
                            }
                            break;
                    }
                }
                else if (words[0] == "SetAlignmentAngle")
                {
                    switch (words[1])
                    {
                        case "Aligner1":
                            _AlignmentAngle_Set_Cmd.Error = words[2];
                            if (_AlignmentAngle_Set_Cmd.Error == "OK")
                            {
                                _AlignmentAngle_Set_Cmd.ErrorCode = "";
                                break;
                            }
                            else
                            {
                                _AlignmentAngle_Set_Cmd.ErrorCode = words[3];
                            }
                            break;
                    }
                }
                else if (words[0] == "SetWaferType")
                {
                    switch (words[1])
                    {
                        case "Aligner1":
                            _WaferType_Set_Cmd.Error = words[2];
                            if (_WaferType_Set_Cmd.Error == "OK")
                            {
                                _WaferType_Set_Cmd.ErrorCode = "";
                                break;
                            }
                            else
                            {
                                _WaferType_Set_Cmd.ErrorCode = words[3];
                            }
                            break;
                    }
                }
                else if (words[0] == "SetWaferMode")
                {
                    switch (words[1])
                    {
                        case "Aligner1":
                            _WaferMode_Set_Cmd.Error = words[2];
                            if (_WaferMode_Set_Cmd.Error == "OK")
                            {
                                _WaferMode_Set_Cmd.ErrorCode = "";
                                break;
                            }
                            else
                            {
                                _WaferMode_Set_Cmd.ErrorCode = words[3];
                            }
                            break;
                    }
                }
                else if (words[0] == "SetWaferSize")
                {
                    switch (words[1])
                    {
                        case "Aligner1":
                            _WaferSize_Set_Cmd.Error = words[2];
                            if (_WaferSize_Set_Cmd.Error == "OK")
                            {
                                _WaferSize_Set_Cmd.ErrorCode = "";
                                break;
                            }
                            else
                            {
                                _WaferSize_Set_Cmd.ErrorCode = words[3];
                            }
                            break;
                    }
                }
                else if (words[0] == "Home" || words[0] == "Load" ||
                    words[0] == "Unload" || words[0] == "Clamp" ||
                    words[0] == "Unclamp" || words[0] == "HoldPlate" ||
                    words[0] == "Unholdplate" || words[0] == "Map")
                {
                    switch (words[1])
                    {
                        case "Loadport1":
                            _Cmd_Loadport.Error = words[2];
                            if (_Cmd_Loadport.Error == "OK")
                            {
                                _Cmd_Loadport.ErrorCode = "";
                                break;
                            }
                            else
                            {
                                _Cmd_Loadport.ErrorCode = words[3];
                            }
                            break;
                        case "Loadport2":
                            _Cmd_Loadport.Error = words[2];
                            if (_Cmd_Loadport.Error == "OK")
                            {
                                _Cmd_Loadport.ErrorCode = "";
                                break;
                            }
                            else
                            {
                                _Cmd_Loadport.ErrorCode = words[3];
                            }
                            break;
                        case "Loadport3":
                            _Cmd_Loadport.Error = words[2];
                            if (_Cmd_Loadport.Error == "OK")
                            {
                                _Cmd_Loadport.ErrorCode = "";
                                break;
                            }
                            else
                            {
                                _Cmd_Loadport.ErrorCode = words[3];
                            }
                            break;
                    }
                }
                else if (words[0] == "GetCurrentLPWaferSize")
                {
                    switch (words[1])
                    {
                        case "Loadport1":
                            _GetCurrentLPWaferSize.Error = words[2];
                            if (_GetCurrentLPWaferSize.Error == "OK")
                            {
                                _GetCurrentLPWaferSize.ErrorCode = "";
                                switch (words[3])
                                {
                                    case "4":
                                        _GetCurrentLPWaferSize.Result = "eight";
                                        break;
                                    case "6":
                                        _GetCurrentLPWaferSize.Result = "tweleve";
                                        break;
                                }

                                break;
                            }
                            else
                            {
                                _GetCurrentLPWaferSize.ErrorCode = words[3];
                            }
                            break;
                        case "Loadport2":
                            _GetCurrentLPWaferSize.Error = words[2];
                            if (_GetCurrentLPWaferSize.Error == "OK")
                            {
                                _GetCurrentLPWaferSize.ErrorCode = "";
                                switch (words[3])
                                {
                                    case "4":
                                        _GetCurrentLPWaferSize.Result = "eight";
                                        break;
                                    case "6":
                                        _GetCurrentLPWaferSize.Result = "tweleve";
                                        break;
                                }

                                break;
                            }
                            else
                            {
                                _GetCurrentLPWaferSize.ErrorCode = words[3];
                            }
                            break;
                        case "Loadport3":
                            _GetCurrentLPWaferSize.Error = words[2];
                            if (_GetCurrentLPWaferSize.Error == "OK")
                            {
                                _GetCurrentLPWaferSize.ErrorCode = "";
                                switch (words[3])
                                {
                                    case "4":
                                        _GetCurrentLPWaferSize.Result = "eight";
                                        break;
                                    case "6":
                                        _GetCurrentLPWaferSize.Result = "tweleve";
                                        break;
                                }

                                break;
                            }
                            else
                            {
                                _GetCurrentLPWaferSize.ErrorCode = words[3];
                            }
                            break;
                    }
                }
                else if (words[0] == "GetMapResult")
                {
                    _GetMapResult.Error = words[2];
                    if (_GetMapResult.Error == "OK")
                    {
                        _GetMapResult.ErrorCode = "";
                        for (int i = 3; i < words.Count(); i++)
                        {

                            _GetMapResult.Result[i-3]=( ((map_result_state)Convert.ToInt32(words[i])).ToString());
                        }

                    }
                    else
                    {
                        _GetMapResult.ErrorCode = words[3];
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
