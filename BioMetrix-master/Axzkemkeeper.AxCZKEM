using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Axzkemkeeper
{
    [DefaultEvent("OnAttTransaction")]
    [DesignTimeVisible(true)]
    public class AxCZKEM : AxHost
    {
        public AxCZKEM();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DispId(79)]
        public virtual int AccGroup { get; set; }
        [DispId(76)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int BASE64 { get; set; }
        [DispId(2)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int CommPort { get; set; }
        [DispId(64)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int ConvertBIG5 { get; set; }
        [DispId(123)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int MachineNumber { get; set; }
        [DispId(78)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual uint PIN2 { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DispId(102)]
        public virtual int PINWidth { get; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DispId(1)]
        public virtual bool ReadMark { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DispId(191)]
        public virtual int SSRPin { get; }

        public event _IZKEMEvents_OnAlarmEventHandler OnAlarm;
        public event _IZKEMEvents_OnAttTransactionEventHandler OnAttTransaction;
        public event _IZKEMEvents_OnAttTransactionExEventHandler OnAttTransactionEx;
        public event EventHandler OnConnected;
        public event _IZKEMEvents_OnDeleteTemplateEventHandler OnDeleteTemplate;
        public event EventHandler OnDisConnected;
        public event _IZKEMEvents_OnDoorEventHandler OnDoor;
        public event _IZKEMEvents_OnEMDataEventHandler OnEMData;
        public event _IZKEMEvents_OnEmptyCardEventHandler OnEmptyCard;
        public event _IZKEMEvents_OnEnrollFingerEventHandler OnEnrollFinger;
        public event _IZKEMEvents_OnEnrollFingerExEventHandler OnEnrollFingerEx;
        public event EventHandler OnFinger;
        public event _IZKEMEvents_OnFingerFeatureEventHandler OnFingerFeature;
        public event _IZKEMEvents_OnHIDNumEventHandler OnHIDNum;
        public event _IZKEMEvents_OnKeyPressEventHandler OnKeyPress;
        public event _IZKEMEvents_OnNewUserEventHandler OnNewUser;
        public event _IZKEMEvents_OnVerifyEventHandler OnVerify;
        public event _IZKEMEvents_OnWriteCardEventHandler OnWriteCard;

        public virtual bool ACUnlock(int dwMachineNumber, int delay);
        protected override void AttachInterfaces();
        public virtual bool BackupData(string dataFile);
        public virtual bool BatchUpdate(int dwMachineNumber);
        public virtual bool Beep(int delayMS);
        public virtual bool BeginBatchUpdate(int dwMachineNumber, int updateFlag);
        public virtual bool CancelBatchUpdate(int dwMachineNumber);
        public virtual bool CancelOperation();
        public virtual bool CaptureImage(bool fullImage, ref int width, ref int height, ref byte image, string imageFile);
        public virtual bool ClearAdministrators(int dwMachineNumber);
        public virtual bool ClearData(int dwMachineNumber, int dataFlag);
        public virtual bool ClearGLog(int dwMachineNumber);
        public virtual bool ClearKeeperData(int dwMachineNumber);
        public virtual bool ClearLCD();
        public virtual bool ClearSLog(int dwMachineNumber);
        public virtual bool ClearSMS(int dwMachineNumber);
        public virtual bool ClearUserSMS(int dwMachineNumber);
        public virtual bool ClearWorkCode();
        public virtual bool Connect_Com(int comPort, int machineNumber, int baudRate);
        public virtual bool Connect_Modem(int comPort, int machineNumber, int baudRate, string telephone);
        public virtual bool Connect_Net(string iPAdd, int port);
        public virtual bool Connect_USB(int machineNumber);
        public virtual void ConvertPassword(int dwSrcPSW, ref int dwDestPSW, int dwLength);
        protected override void CreateSink();
        public virtual bool DelCustomizeAttState(int dwMachineNumber, int stateID);
        public virtual bool DelCustomizeVoice(int dwMachineNumber, int voiceID);
        public virtual bool DeleteEnrollData(int dwMachineNumber, int dwEnrollNumber, int dwEMachineNumber, int dwBackupNumber);
        public virtual bool DeleteSMS(int dwMachineNumber, int iD);
        public virtual bool DeleteUserInfoEx(int dwMachineNumber, int dwEnrollNumber);
        public virtual bool DeleteUserSMS(int dwMachineNumber, int dwEnrollNumber, int sMSID);
        public virtual bool DeleteWorkCode(int workCodeID);
        public virtual bool DelUserFace(int dwMachineNumber, string dwEnrollNumber, int dwFaceIndex);
        public virtual bool DelUserTmp(int dwMachineNumber, int dwEnrollNumber, int dwFingerIndex);
        protected override void DetachSink();
        public virtual bool DisableDeviceWithTimeOut(int dwMachineNumber, int timeOutSec);
        public virtual void Disconnect();
        public virtual bool EmptyCard(int dwMachineNumber);
        public virtual bool EnableClock(int enabled);
        public virtual bool EnableCustomizeAttState(int dwMachineNumber, int stateID, int enable);
        public virtual bool EnableCustomizeVoice(int dwMachineNumber, int voiceID, int enable);
        public virtual bool EnableDevice(int dwMachineNumber, bool bFlag);
        public virtual bool EnableUser(int dwMachineNumber, int dwEnrollNumber, int dwEMachineNumber, int dwBackupNumber, bool bFlag);
        public virtual bool FPTempConvert(ref byte tmpData1, ref byte tmpData2, ref int size);
        public virtual bool FPTempConvertNew(ref byte tmpData1, ref byte tmpData2, ref int size);
        public virtual bool FPTempConvertNewStr(string tmpData1, ref string tmpData2, ref int size);
        public virtual bool FPTempConvertStr(string tmpData1, ref string tmpData2, ref int size);
        public virtual int get_AccTimeZones(int index);
        public virtual int get_CardNumber(int index);
        public virtual string get_STR_CardNumber(int index);
        public virtual bool GetACFun(ref int aCFun);
        public virtual bool GetAllGLogData(int dwMachineNumber, ref int dwTMachineNumber, ref int dwEnrollNumber, ref int dwEMachineNumber, ref int dwVerifyMode, ref int dwInOutMode, ref int dwYear, ref int dwMonth, ref int dwDay, ref int dwHour, ref int dwMinute);
        public virtual bool GetAllSLogData(int dwMachineNumber, ref int dwTMachineNumber, ref int dwSEnrollNumber, ref int params4, ref int params1, ref int params2, ref int dwManipulation, ref int params3, ref int dwYear, ref int dwMonth, ref int dwDay, ref int dwHour, ref int dwMinute);
        public virtual bool GetAllUserID(int dwMachineNumber, ref int dwEnrollNumber, ref int dwEMachineNumber, ref int dwBackupNumber, ref int dwMachinePrivilege, ref int dwEnable);
        public virtual bool GetAllUserInfo(int dwMachineNumber, ref int dwEnrollNumber, ref string name, ref string password, ref int privilege, ref bool enabled);
        public virtual int GetBackupNumber(int dwMachineNumber);
        public virtual bool GetCardFun(int dwMachineNumber, ref int cardFun);
        public virtual bool GetDataFile(int dwMachineNumber, int dataFlag, string fileName);
        public virtual bool GetDaylight(int dwMachineNumber, ref int support, ref string beginTime, ref string endTime);
        public virtual bool GetDeviceInfo(int dwMachineNumber, int dwInfo, ref int dwValue);
        public virtual bool GetDeviceIP(int dwMachineNumber, ref string iPAddr);
        public virtual bool GetDeviceMAC(int dwMachineNumber, ref string sMAC);
        public virtual bool GetDeviceStatus(int dwMachineNumber, int dwStatus, ref int dwValue);
        public virtual bool GetDeviceStrInfo(int dwMachineNumber, int dwInfo, out string value);
        public virtual bool GetDeviceTime(int dwMachineNumber, ref int dwYear, ref int dwMonth, ref int dwDay, ref int dwHour, ref int dwMinute, ref int dwSecond);
        public virtual bool GetDoorState(int machineNumber, ref int state);
        public virtual bool GetEnrollData(int dwMachineNumber, int dwEnrollNumber, int dwEMachineNumber, int dwBackupNumber, ref int dwMachinePrivilege, ref int dwEnrollData, ref int dwPassWord);
        public virtual bool GetEnrollDataStr(int dwMachineNumber, int dwEnrollNumber, int dwEMachineNumber, int dwBackupNumber, ref int dwMachinePrivilege, ref string dwEnrollData, ref int dwPassWord);
        public virtual bool GetFirmwareVersion(int dwMachineNumber, ref string strVersion);
        public virtual int GetFPTempLength(ref byte dwEnrollData);
        public virtual int GetFPTempLengthStr(string dwEnrollData);
        public virtual bool GetGeneralExtLogData(int dwMachineNumber, ref int dwEnrollNumber, ref int dwVerifyMode, ref int dwInOutMode, ref int dwYear, ref int dwMonth, ref int dwDay, ref int dwHour, ref int dwMinute, ref int dwSecond, ref int dwWorkCode, ref int dwReserved);
        public virtual bool GetGeneralLogData(int dwMachineNumber, ref int dwTMachineNumber, ref int dwEnrollNumber, ref int dwEMachineNumber, ref int dwVerifyMode, ref int dwInOutMode, ref int dwYear, ref int dwMonth, ref int dwDay, ref int dwHour, ref int dwMinute);
        public virtual bool GetGeneralLogDataStr(int dwMachineNumber, ref int dwEnrollNumber, ref int dwVerifyMode, ref int dwInOutMode, ref string timeStr);
        public virtual bool GetGroupTZs(int dwMachineNumber, int groupIndex, ref int tZs);
        public virtual bool GetGroupTZStr(int dwMachineNumber, int groupIndex, ref string tZs);
        public virtual bool GetHIDEventCardNumAsStr(out string strHIDEventCardNum);
        public virtual bool GetHoliday(int dwMachineNumber, ref string holiday);
        public virtual void GetLastError(ref int dwErrorCode);
        public virtual bool GetPIN2(int userID, ref int pIN2);
        public virtual bool GetPlatform(int dwMachineNumber, ref string platform);
        public virtual bool GetProductCode(int dwMachineNumber, out string lpszProductCode);
        public virtual bool GetRTLog(int dwMachineNumber);
        public virtual bool GetSDKVersion(ref string strVersion);
        public virtual bool GetSensorSN(int dwMachineNumber, ref string sensorSN);
        public virtual bool GetSerialNumber(int dwMachineNumber, out string dwSerialNumber);
        public virtual bool GetSMS(int dwMachineNumber, int iD, ref int tag, ref int validMinutes, ref string startTime, ref string content);
        public virtual bool GetStrCardNumber(out string aCardNumber);
        public virtual bool GetSuperLogData(int dwMachineNumber, ref int dwTMachineNumber, ref int dwSEnrollNumber, ref int params4, ref int params1, ref int params2, ref int dwManipulation, ref int params3, ref int dwYear, ref int dwMonth, ref int dwDay, ref int dwHour, ref int dwMinute);
        public virtual bool GetSuperLogData2(int dwMachineNumber, ref int dwTMachineNumber, ref int dwSEnrollNumber, ref int params4, ref int params1, ref int params2, ref int dwManipulation, ref int params3, ref int dwYear, ref int dwMonth, ref int dwDay, ref int dwHour, ref int dwMinute, ref int dwSecs);
        public virtual bool GetSysOption(int dwMachineNumber, string option, out string value);
        public virtual bool GetTZInfo(int dwMachineNumber, int tZIndex, ref string tZ);
        public virtual bool GetUnlockGroups(int dwMachineNumber, ref string grps);
        public virtual bool GetUserFace(int dwMachineNumber, string dwEnrollNumber, int dwFaceIndex, ref byte tmpData, ref int tmpLength);
        public virtual bool GetUserFaceStr(int dwMachineNumber, string dwEnrollNumber, int dwFaceIndex, ref string tmpData, ref int tmpLength);
        public virtual bool GetUserGroup(int dwMachineNumber, int dwEnrollNumber, ref int userGrp);
        public virtual bool GetUserIDByPIN2(int pIN2, ref int userID);
        public virtual bool GetUserInfo(int dwMachineNumber, int dwEnrollNumber, ref string name, ref string password, ref int privilege, ref bool enabled);
        public virtual bool GetUserInfoByCard(int dwMachineNumber, ref string name, ref string password, ref int privilege, ref bool enabled);
        public virtual bool GetUserInfoByPIN2(int dwMachineNumber, ref string name, ref string password, ref int privilege, ref bool enabled);
        public virtual bool GetUserInfoEx(int dwMachineNumber, int dwEnrollNumber, out int verifyStyle, out byte reserved);
        public virtual bool GetUserTmp(int dwMachineNumber, int dwEnrollNumber, int dwFingerIndex, ref byte tmpData, ref int tmpLength);
        public virtual bool GetUserTmpEx(int dwMachineNumber, string dwEnrollNumber, int dwFingerIndex, out int flag, out byte tmpData, out int tmpLength);
        public virtual bool GetUserTmpExStr(int dwMachineNumber, string dwEnrollNumber, int dwFingerIndex, out int flag, out string tmpData, out int tmpLength);
        public virtual bool GetUserTmpStr(int dwMachineNumber, int dwEnrollNumber, int dwFingerIndex, ref string tmpData, ref int tmpLength);
        public virtual bool GetUserTZs(int dwMachineNumber, int dwEnrollNumber, ref int tZs);
        public virtual bool GetUserTZStr(int dwMachineNumber, int dwEnrollNumber, ref string tZs);
        public virtual bool GetVendor(ref string strVendor);
        public virtual bool GetWiegandFmt(int dwMachineNumber, ref string sWiegandFmt);
        public virtual bool GetWorkCode(int workCodeID, out int aWorkCode);
        public virtual bool IsTFTMachine(int dwMachineNumber);
        public virtual bool MergeTemplate(IntPtr templates, int fingerCount, ref byte templateDest, ref int fingerSize);
        public virtual bool ModifyPrivilege(int dwMachineNumber, int dwEnrollNumber, int dwEMachineNumber, int dwBackupNumber, int dwMachinePrivilege);
        public virtual bool PlayVoice(int position, int length);
        public virtual bool PlayVoiceByIndex(int index);
        public virtual bool PowerOffDevice(int dwMachineNumber);
        public virtual void PowerOnAllDevice();
        public virtual bool QueryState(ref int state);
        public virtual bool ReadAllGLogData(int dwMachineNumber);
        public virtual bool ReadAllSLogData(int dwMachineNumber);
        public virtual bool ReadAllTemplate(int dwMachineNumber);
        public virtual bool ReadAllUserID(int dwMachineNumber);
        public virtual bool ReadAOptions(string aOption, out string aValue);
        public virtual bool ReadAttRule(int dwMachineNumber);
        public virtual bool ReadCustData(int dwMachineNumber, ref string custData);
        public virtual bool ReadDPTInfo(int dwMachineNumber);
        public virtual bool ReadFile(int dwMachineNumber, string fileName, string filePath);
        public virtual bool ReadGeneralLogData(int dwMachineNumber);
        public virtual bool ReadRTLog(int dwMachineNumber);
        public virtual bool ReadSuperLogData(int dwMachineNumber);
        public virtual bool ReadTurnInfo(int dwMachineNumber);
        public virtual bool RefreshData(int dwMachineNumber);
        public virtual bool RegEvent(int dwMachineNumber, int eventMask);
        public virtual bool RestartDevice(int dwMachineNumber);
        public virtual bool RestoreData(string dataFile);
        public virtual bool SaveTheDataToFile(int dwMachineNumber, string theFilePath, int fileFlag);
        public virtual bool SendCMDMsg(int dwMachineNumber, int param1, int param2);
        public virtual bool SendFile(int dwMachineNumber, string fileName);
        public virtual void set_AccTimeZones(int index, int pVal);
        public virtual void set_CardNumber(int index, int pVal);
        public virtual void set_STR_CardNumber(int index, string pVal);
        public virtual bool SetCommPassword(int commKey);
        public virtual bool SetCustomizeAttState(int dwMachineNumber, int stateID, int newState);
        public virtual bool SetCustomizeVoice(int dwMachineNumber, int voiceID, string fileName);
        public virtual bool SetDaylight(int dwMachineNumber, int support, string beginTime, string endTime);
        public virtual bool SetDeviceCommPwd(int dwMachineNumber, int commKey);
        public virtual bool SetDeviceInfo(int dwMachineNumber, int dwInfo, int dwValue);
        public virtual bool SetDeviceIP(int dwMachineNumber, string iPAddr);
        public virtual bool SetDeviceMAC(int dwMachineNumber, string sMAC);
        public virtual bool SetDeviceTime(int dwMachineNumber);
        public virtual bool SetDeviceTime2(int dwMachineNumber, int dwYear, int dwMonth, int dwDay, int dwHour, int dwMinute, int dwSecond);
        public virtual bool SetEnrollData(int dwMachineNumber, int dwEnrollNumber, int dwEMachineNumber, int dwBackupNumber, int dwMachinePrivilege, ref int dwEnrollData, int dwPassWord);
        public virtual bool SetEnrollDataStr(int dwMachineNumber, int dwEnrollNumber, int dwEMachineNumber, int dwBackupNumber, int dwMachinePrivilege, string dwEnrollData, int dwPassWord);
        public virtual bool SetGroupTZs(int dwMachineNumber, int groupIndex, ref int tZs);
        public virtual bool SetGroupTZStr(int dwMachineNumber, int groupIndex, string tZs);
        public virtual bool SetHoliday(int dwMachineNumber, string holiday);
        public virtual bool SetLanguageByID(int dwMachineNumber, int languageID, string language);
        public virtual bool SetLastCount(int count);
        public virtual bool SetSMS(int dwMachineNumber, int iD, int tag, int validMinutes, string startTime, string content);
        public virtual bool SetStrCardNumber(string aCardNumber);
        public virtual bool SetSysOption(int dwMachineNumber, string option, string value);
        public virtual bool SetTZInfo(int dwMachineNumber, int tZIndex, string tZ);
        public virtual bool SetUnlockGroups(int dwMachineNumber, string grps);
        public virtual bool SetUserFace(int dwMachineNumber, string dwEnrollNumber, int dwFaceIndex, ref byte tmpData, int tmpLength);
        public virtual bool SetUserFaceStr(int dwMachineNumber, string dwEnrollNumber, int dwFaceIndex, string tmpData, int tmpLength);
        public virtual bool SetUserGroup(int dwMachineNumber, int dwEnrollNumber, int userGrp);
        public virtual bool SetUserInfo(int dwMachineNumber, int dwEnrollNumber, string name, string password, int privilege, bool enabled);
        public virtual bool SetUserInfoEx(int dwMachineNumber, int dwEnrollNumber, int verifyStyle, ref byte reserved);
        public virtual bool SetUserSMS(int dwMachineNumber, int dwEnrollNumber, int sMSID);
        public virtual bool SetUserTmp(int dwMachineNumber, int dwEnrollNumber, int dwFingerIndex, ref byte tmpData);
        public virtual bool SetUserTmpEx(int dwMachineNumber, string dwEnrollNumber, int dwFingerIndex, int flag, ref byte tmpData);
        public virtual bool SetUserTmpExStr(int dwMachineNumber, string dwEnrollNumber, int dwFingerIndex, int flag, string tmpData);
        public virtual bool SetUserTmpStr(int dwMachineNumber, int dwEnrollNumber, int dwFingerIndex, string tmpData);
        public virtual bool SetUserTZs(int dwMachineNumber, int dwEnrollNumber, ref int tZs);
        public virtual bool SetUserTZStr(int dwMachineNumber, int dwEnrollNumber, string tZs);
        public virtual bool SetWiegandFmt(int dwMachineNumber, string sWiegandFmt);
        public virtual bool SetWorkCode(int workCodeID, int aWorkCode);
        public virtual bool SplitTemplate(ref byte template, IntPtr templates, ref int fingerCount, ref int fingerSize);
        public virtual bool SSR_ClearWorkCode();
        public virtual bool SSR_DeleteEnrollData(int dwMachineNumber, string dwEnrollNumber, int dwBackupNumber);
        public virtual bool SSR_DeleteEnrollDataExt(int dwMachineNumber, string dwEnrollNumber, int dwBackupNumber);
        public virtual bool SSR_DeleteUserSMS(int dwMachineNumber, string dwEnrollNumber, int sMSID);
        public virtual bool SSR_DeleteWorkCode(int pIN);
        public virtual bool SSR_DelUserTmp(int dwMachineNumber, string dwEnrollNumber, int dwFingerIndex);
        public virtual bool SSR_DelUserTmpExt(int dwMachineNumber, string dwEnrollNumber, int dwFingerIndex);
        public virtual bool SSR_EnableUser(int dwMachineNumber, string dwEnrollNumber, bool bFlag);
        public virtual bool SSR_GetAllUserInfo(int dwMachineNumber, out string dwEnrollNumber, out string name, out string password, out int privilege, out bool enabled);
        public virtual bool SSR_GetGeneralLogData(int dwMachineNumber, out string dwEnrollNumber, out int dwVerifyMode, out int dwInOutMode, out int dwYear, out int dwMonth, out int dwDay, out int dwHour, out int dwMinute, out int dwSecond, ref int dwWorkCode);
        public virtual bool SSR_GetGroupTZ(int dwMachineNumber, int groupNo, ref int tz1, ref int tz2, ref int tz3, ref int vaildHoliday, ref int verifyStyle);
        public virtual bool SSR_GetHoliday(int dwMachineNumber, int holidayID, ref int beginMonth, ref int beginDay, ref int endMonth, ref int endDay, ref int timeZoneID);
        public virtual bool SSR_GetShortkey(int shortKeyID, ref int shortKeyFun, ref int stateCode, ref string stateName, ref int autoChange, ref string autoChangeTime);
        public virtual bool SSR_GetSuperLogData(int machineNumber, out int number, out string admin, out string user, out int manipulation, out string time, out int params1, out int params2, out int params3);
        public virtual bool SSR_GetUnLockGroup(int dwMachineNumber, int combNo, ref int group1, ref int group2, ref int group3, ref int group4, ref int group5);
        public virtual bool SSR_GetUserInfo(int dwMachineNumber, string dwEnrollNumber, out string name, out string password, out int privilege, out bool enabled);
        public virtual bool SSR_GetUserTmp(int dwMachineNumber, string dwEnrollNumber, int dwFingerIndex, out byte tmpData, out int tmpLength);
        public virtual bool SSR_GetUserTmpStr(int dwMachineNumber, string dwEnrollNumber, int dwFingerIndex, out string tmpData, out int tmpLength);
        public virtual bool SSR_GetWorkCode(int aWorkCode, out string name);
        public virtual bool SSR_OutPutHTMLRep(int dwMachineNumber, string dwEnrollNumber, string attFile, string userFile, string deptFile, string timeClassFile, string attruleFile, int bYear, int bMonth, int bDay, int bHour, int bMinute, int bSecond, int eYear, int eMonth, int eDay, int eHour, int eMinute, int eSecond, string tempPath, string outFileName, int hTMLFlag, int resv1, string resv2);
        public virtual bool SSR_SetGroupTZ(int dwMachineNumber, int groupNo, int tz1, int tz2, int tz3, int vaildHoliday, int verifyStyle);
        public virtual bool SSR_SetHoliday(int dwMachineNumber, int holidayID, int beginMonth, int beginDay, int endMonth, int endDay, int timeZoneID);
        public virtual bool SSR_SetShortkey(int shortKeyID, int shortKeyFun, int stateCode, string stateName, int stateAutoChange, string stateAutoChangeTime);
        public virtual bool SSR_SetUnLockGroup(int dwMachineNumber, int combNo, int group1, int group2, int group3, int group4, int group5);
        public virtual bool SSR_SetUserInfo(int dwMachineNumber, string dwEnrollNumber, string name, string password, int privilege, bool enabled);
        public virtual bool SSR_SetUserSMS(int dwMachineNumber, string dwEnrollNumber, int sMSID);
        public virtual bool SSR_SetUserTmp(int dwMachineNumber, string dwEnrollNumber, int dwFingerIndex, ref byte tmpData);
        public virtual bool SSR_SetUserTmpExt(int dwMachineNumber, int isDeleted, string dwEnrollNumber, int dwFingerIndex, ref byte tmpData);
        public virtual bool SSR_SetUserTmpStr(int dwMachineNumber, string dwEnrollNumber, int dwFingerIndex, string tmpData);
        public virtual bool SSR_SetWorkCode(int aWorkCode, string name);
        public virtual bool StartEnroll(int userID, int fingerID);
        public virtual bool StartEnrollEx(string userID, int fingerID, int flag);
        public virtual bool StartIdentify();
        public virtual bool StartVerify(int userID, int fingerID);
        public virtual bool UpdateFirmware(string firmwareFile);
        public virtual bool UseGroupTimeZone();
        public virtual bool WriteCard(int dwMachineNumber, int dwEnrollNumber, int dwFingerIndex1, ref byte tmpData1, int dwFingerIndex2, ref byte tmpData2, int dwFingerIndex3, ref byte tmpData3, int dwFingerIndex4, ref byte tmpData4);
        public virtual bool WriteCustData(int dwMachineNumber, string custData);
        public virtual bool WriteLCD(int row, int col, string text);
    }
}