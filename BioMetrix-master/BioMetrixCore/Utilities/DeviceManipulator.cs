using System;
using System.Collections.Generic;
using System.Text;

namespace BioMetrixCore
{
    internal class DeviceManipulator
    {
        
        public ICollection<UserInfo> GetAllUserInfo(ZkemClient objZkeeper, int dwMachineNumber, int count)
        {
           string dwEnrollNumber ="";
           string Name = "";
           string Password = "";
           int Privilege = 0;
           bool Enabled = false;
           int dwFingerIndex;
           string TmpData = "";
           int TmpLength = 0;
           int Flag = 0;


            ICollection<UserInfo> lstFPTemplates = new List<UserInfo>();

            objZkeeper.ReadAllUserID(dwMachineNumber);
            objZkeeper.ReadAllTemplate(dwMachineNumber);
           // bool SSR_GetAllUserInfo(int dwMachineNumber, out string dwEnrollNumber, out string Name, out string Password, out int Privilege, out bool Enabled)

            while (objZkeeper.SSR_GetAllUserInfo(dwMachineNumber, out dwEnrollNumber, out Name, out Password, out Privilege, out Enabled))
            {
                
                for (dwFingerIndex = 0; dwFingerIndex < 10; dwFingerIndex++)
                {
                  //  bool SSR_GetUserTmpStr(int dwMachineNumber, string dwEnrollNumber, int dwFingerIndex, out string TmpData, out int TmpLength)
                   if (objZkeeper.SSR_GetUserTmpStr(dwMachineNumber, dwEnrollNumber, dwFingerIndex, out TmpData, out TmpLength))
                    {
                        UserInfo fpInfo = new UserInfo();
                        fpInfo.MachineNumber = dwMachineNumber;
                        fpInfo.EnrollNumber = dwEnrollNumber;
                        fpInfo.Name = Name;
                        fpInfo.FingerIndex = dwFingerIndex;
                        fpInfo.TmpData = TmpData;
                        fpInfo.Privelage = Privilege;
                        fpInfo.Password = Password;
                        fpInfo.Enabled = Enabled;
                        fpInfo.iFlag = Flag.ToString();

                        lstFPTemplates.Add(fpInfo);
                   }
                }

            }
            return lstFPTemplates; 
        }

       
 /* public ICollection<MachineInfo> GetLogData(ZkemClient objZkeeper, int dwMachineNumber)
    {
        string dwEnrollNumber = "";
        int dwVerifyMode = 0;
        int dwInOutMode = 0;
        int dwYear = 0;
        int dwMonth = 0;
        int dwDay = 0;
        int dwHour = 0;
        int dwMinute = 0;
        int dwSecond = 0;
        int dwWorkCode = 0;

        ICollection<MachineInfo> lstEnrollData = new List<MachineInfo>();

            if (objZkeeper.ReadAllGLogData(dwMachineNumber))
            {
                //    bool SSR_GetGeneralLogData(int dwMachineNumber, out string dwEnrollNumber, out int dwVerifyMode, out int dwInOutMode, out int dwYear, out int dwMonth, out int dwDay, out int dwHour, out int dwMinute, out int dwSecond, ref int dwWorkCode)
                while (objZkeeper.SSR_GetGeneralLogData(dwMachineNumber, out dwEnrollNumber, out dwVerifyMode, out dwInOutMode, out dwYear, out dwMonth, out dwDay, out dwHour, out dwMinute, out dwSecond, ref dwWorkCode))
                {
                    string inputDate = new DateTime(dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond).ToString();

                    MachineInfo objInfo = new MachineInfo();
                    objInfo.MachineNumber = dwMachineNumber;
                    objInfo.IndRegID = int.Parse(dwEnrollNumber);
                    objInfo.DateTimeRecord = inputDate;

                    lstEnrollData.Add(objInfo);
                }

                return lstEnrollData;
            }
    } */

        public ICollection<UserIDInfo> GetAllUserID(ZkemClient objZkeeper, int dwMachineNumber)
        {
            int dwEnrollNumber = 0;
            int dwEMachineNumber = 0;
            int dwBackupNumber = 0;
            int dwMachinePrivilege = 0;
            int dwEnable = 0;

            ICollection<UserIDInfo> lstUserIDInfo = new List<UserIDInfo>();
            //bool GetAllUserID(int dwMachineNumber, ref int dwEnrollNumber, ref int dwEMachineNumber, ref int dwBackupNumber, ref int dwMachinePrivilege, ref int dwEnable)

           
                while (objZkeeper.GetAllUserID(dwMachineNumber, ref dwEnrollNumber, ref dwEMachineNumber, ref dwBackupNumber, ref dwMachinePrivilege, ref dwEnable))
                {
                    UserIDInfo userID = new UserIDInfo();
                    userID.BackUpNumber = dwBackupNumber;
                    userID.Enabled = dwEnable;
                    userID.EnrollNumber = dwEnrollNumber;
                    userID.MachineNumber = dwEMachineNumber;
                    userID.Privelage = dwMachinePrivilege;
                    lstUserIDInfo.Add(userID);
                }
                return lstUserIDInfo;
            
        }
        
      /*  public void GetGeneratLog(ZkemClient objZkeeper, int machineNumber, string enrollNo)
        {
            string name = null;
            string password = null;
            int previlage = 0;
            bool enabled = false;
            byte[] byTmpData = new byte[2000];
            int tempLength = 0;

            int idwFingerIndex = 0;// [ <--- Enter your fingerprint index here ]
            int iFlag = 0;

            objZkeeper.ReadAllTemplate(machineNumber);

            while (objZkeeper.SSR_GetUserInfo(machineNumber, enrollNo, out name, out password, out previlage, out enabled))
            {
                if (objZkeeper.SSR_GetUserTmpExStr(machineNumber, enrollNo, idwFingerIndex, out iFlag, out byTmpData[0], out tempLength))
                {
                    break;
                }
            }
        }

        

        public bool PushUserDataToDevice(ZkemClient objZkeeper, int machineNumber, string enrollNo)
        {
            string userName = string.Empty;
            string password = string.Empty;
            int privelage = 1;
            return objZkeeper.SSR_SetUserInfo(machineNumber, enrollNo, userName, password, privelage, true);
        }

        public bool UploadFTPTemplate(ZkemClient objZkeeper, int machineNumber, List<UserInfo> lstUserInfo)
        {
            string sdwEnrollNumber = string.Empty, sName = string.Empty, sTmpData = string.Empty;
            int idwFingerIndex = 0, iPrivilege = 0, iFlag = 1, iUpdateFlag = 1;
            string sPassword = "";
            string sEnabled = "";
            bool bEnabled = false;

            if (objZkeeper.BeginBatchUpdate(machineNumber, iUpdateFlag))
            {
                string sLastEnrollNumber = "";

                for (int i = 0; i < lstUserInfo.Count; i++)
                {
                    sdwEnrollNumber = lstUserInfo[i].EnrollNumber;
                    sName = lstUserInfo[i].Name;
                    idwFingerIndex = lstUserInfo[i].FingerIndex;
                    sTmpData = lstUserInfo[i].TmpData;
                    iPrivilege = lstUserInfo[i].Privelage;
                    sPassword = lstUserInfo[i].Password;
                    sEnabled = lstUserInfo[i].Enabled.ToString();
                    iFlag = Convert.ToInt32(lstUserInfo[i].iFlag);
                    bEnabled = true;
                    */
                    /* [ Identify whether the user 
                         information(except fingerprint templates) has been uploaded */
/*
                    if (sdwEnrollNumber != sLastEnrollNumber)
                    {
                        if (objZkeeper.SSR_SetUserInfo(machineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled))//upload user information to the memory
                            objZkeeper.SSR_SetUserTmpExStr(machineNumber, sdwEnrollNumber, idwFingerIndex, iFlag, sTmpData);//upload templates information to the memory
                        else return false;
                    }
                    else
                    {
                        /* [ The current fingerprint and the former one belongs the same user,
                        i.e one user has more than one template ] */
/*
                        objZkeeper.SSR_SetUserTmpExStr(machineNumber, sdwEnrollNumber, idwFingerIndex, iFlag, sTmpData);
                    }

                    sLastEnrollNumber = sdwEnrollNumber;
                }

                return true;
            }
            else
                return false;
        }
*/
        public object ClearData(ZkemClient objZkeeper, int machineNumber, ClearFlag clearFlag)
        {
            int iDataFlag = (int)clearFlag;

            if (objZkeeper.ClearData(machineNumber, iDataFlag))
                return objZkeeper.RefreshData(machineNumber);
            else
            {
                int idwErrorCode = 0;
                objZkeeper.GetLastError(ref idwErrorCode);
                return idwErrorCode;
            }
        }

        public bool ClearGLog(ZkemClient objZkeeper, int machineNumber)
        {
            return objZkeeper.ClearGLog(machineNumber);
        }


        public string FetchDeviceInfo(ZkemClient objZkeeper, int machineNumber)
        {
            StringBuilder sb = new StringBuilder();

            string returnValue = string.Empty;


            objZkeeper.GetFirmwareVersion(machineNumber, ref returnValue);
            if (returnValue.Trim() != string.Empty)
            {
                sb.Append("Firmware V: ");
                sb.Append(returnValue);
                sb.Append(",");
            }


            returnValue = string.Empty;
            objZkeeper.GetVendor(ref returnValue);
            if (returnValue.Trim() != string.Empty)
            {
                sb.Append("Vendor: ");
                sb.Append(returnValue);
                sb.Append(",");
            }

            string sWiegandFmt = string.Empty;
            objZkeeper.GetWiegandFmt(machineNumber, ref sWiegandFmt);

            returnValue = string.Empty;
            objZkeeper.GetSDKVersion(ref returnValue);
            if (returnValue.Trim() != string.Empty)
            {
                sb.Append("SDK V: ");
                sb.Append(returnValue);
                sb.Append(",");
            }

            returnValue = string.Empty;
            objZkeeper.GetSerialNumber(machineNumber, out returnValue);
            if (returnValue.Trim() != string.Empty)
            {
                sb.Append("Serial No: ");
                sb.Append(returnValue);
                sb.Append(",");
            }

            returnValue = string.Empty;
            objZkeeper.GetDeviceMAC(machineNumber, ref returnValue);
            if (returnValue.Trim() != string.Empty)
            {
                sb.Append("Device MAC: ");
                sb.Append(returnValue);
            }

            return sb.ToString();
        }



    }
}
