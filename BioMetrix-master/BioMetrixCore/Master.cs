using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Net;

//using System.Data.SqlClient;
//using MySql.Data.MySqlClient;

namespace BioMetrixCore
{
    public partial class Master : Form
    {
        DeviceManipulator manipulator = new DeviceManipulator();
        public ZkemClient objZkeeper;
        private bool isDeviceConnected = false;
        public static int c = 0;
       

        public bool IsDeviceConnected
        {
            get { return isDeviceConnected; }
            set
            {
                isDeviceConnected = value;
                if (isDeviceConnected)
                {
                    ShowStatusBar("The device is connected !!", true);
                    btnConnect.Text = "Disconnect";
                    ToggleControls(true);
                }
                else
                {
                    ShowStatusBar("The device is diconnected !!", true);
                    objZkeeper.Disconnect();
                    btnConnect.Text = "Connect";
                    ToggleControls(false);
                }
            }
        }


        private void ToggleControls(bool value)
        {
            btnBeep.Enabled = value;
            btnDownloadFingerPrint.Enabled = value;
            btnPullData.Enabled = value;
            btnPowerOff.Enabled = value;
            btnRestartDevice.Enabled = value;
            btnGetDeviceTime.Enabled = value;
            btnEnableDevice.Enabled = value;
            btnDisableDevice.Enabled = value;
            btnGetAllUserID.Enabled = value;

            tbxMachineNumber.Enabled = !value;
            tbxPort.Enabled = !value;
            tbxDeviceIP.Enabled = !value;

        }

        public Master()
        {
            InitializeComponent();
            ToggleControls(false);
            ShowStatusBar(string.Empty, true);
            DisplayEmpty();
            string ipAddress = "192.168.0.201";
            int port = 4370;

            objZkeeper = new ZkemClient(RaiseDeviceEvent);
            isDeviceConnected = objZkeeper.Connect_Net(ipAddress, port);

        }


        private void RaiseDeviceEvent(object sender, string actionType)
        {
            switch (actionType)
            {
                case UniversalStatic.acx_Disconnect:
                    {
                        ShowStatusBar("The device is switched off", true);
                        DisplayEmpty();
                        btnConnect.Text = "Connect";
                        ToggleControls(false);
                        break;
                    }

                default:
                    break;
            }

        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ShowStatusBar(string.Empty, true);

                if (IsDeviceConnected)
                {
                    IsDeviceConnected = false;
                    this.Cursor = Cursors.Default;

                    return;
                }

                string ipAddress = tbxDeviceIP.Text.Trim();
                string port = tbxPort.Text.Trim();
                if (ipAddress == string.Empty || port == string.Empty)
                    throw new Exception("The Device IP Address and Port is mandotory !!");

                int portNumber = 4370;
                if (!int.TryParse(port, out portNumber))
                    throw new Exception("Not a valid port number");

                bool isValidIpA = UniversalStatic.ValidateIP(ipAddress);
                if (!isValidIpA)
                    throw new Exception("The Device IP is invalid !!");

                isValidIpA = UniversalStatic.PingTheDevice(ipAddress);
                if (!isValidIpA)
                    throw new Exception("The device at " + ipAddress + ":" + port + " did not respond!!");

                objZkeeper = new ZkemClient(RaiseDeviceEvent);
                IsDeviceConnected = objZkeeper.Connect_Net(ipAddress, portNumber);

                if (IsDeviceConnected)
                {
                    string deviceInfo = manipulator.FetchDeviceInfo(objZkeeper, int.Parse(tbxMachineNumber.Text.Trim()));
                    lblDeviceInfo.Text = deviceInfo;

                  /*  objZkeeper.OnAttTransaction(string EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
                    {
                        string time = Year + "-" + Month + "-" + Day + " " + Hour + ":" + Minute + ":" + Second;

                        gRealEventListBox.Items.Add("Verify OK.UserID=" + EnrollNumber + " isInvalid=" + IsInValid.ToString() + " state=" + AttState.ToString() + " verifystyle=" + VerifyMethod.ToString() + " time=" + time);

                        throw new NotImplementedException();
                    }*/
                }

            }
            catch (Exception ex)
            {
                ShowStatusBar(ex.Message, false);
            }
            this.Cursor = Cursors.Default;

        }


        public void ShowStatusBar(string message, bool type)
        {
            if (message.Trim() == string.Empty)
            {
                lblStatus.Visible = false;
                return;
            }

            lblStatus.Visible = true;
            lblStatus.Text = message;
            lblStatus.ForeColor = Color.White;

            if (type)
                lblStatus.BackColor = Color.FromArgb(79, 208, 154);
            else
                lblStatus.BackColor = Color.FromArgb(230, 112, 134);
        }


        private void btnPingDevice_Click(object sender, EventArgs e)
        {
            ShowStatusBar(string.Empty, true);

            string ipAddress = tbxDeviceIP.Text.Trim();

            bool isValidIpA = UniversalStatic.ValidateIP(ipAddress);
            if (!isValidIpA)
                throw new Exception("The Device IP is invalid !!");

            isValidIpA = UniversalStatic.PingTheDevice(ipAddress);
            if (isValidIpA)
                ShowStatusBar("The device is active", true);
            else
                ShowStatusBar("Could not read any response", false);
        }

        private void btnGetAllUserID_Click(object sender, EventArgs e)
        {
            try
            {
                // ICollection<UserIDInfo> lstUserIDInfo = manipulator.GetAllUserID(objZkeeper, int.Parse(tbxMachineNumber.Text.Trim()));

                int dwEnrollNumber = 0;
                int dwEMachineNumber = 0;
                int dwBackupNumber = 0;
                int dwMachinePrivilege = 0;
                int dwEnable = 1;
                int dwMachineNumber = int.Parse(tbxMachineNumber.Text.Trim());
                ICollection<UserIDInfo> lstUserIDInfo = new List<UserIDInfo>();
                //bool GetAllUserID(int dwMachineNumber, ref int dwEnrollNumber, ref int dwEMachineNumber, ref int dwBackupNumber, ref int dwMachinePrivilege, ref int dwEnable)

                objZkeeper.ReadAllUserID(dwMachineNumber);
                
                    while (objZkeeper.GetAllUserID(dwMachineNumber, ref dwEnrollNumber, ref dwEMachineNumber, ref dwBackupNumber, ref dwMachinePrivilege, ref dwEnable))
                    {
                        UserIDInfo userID = new UserIDInfo();
                        userID.BackUpNumber = dwBackupNumber;
                        userID.Enabled = dwEnable;
                        userID.EnrollNumber = dwEnrollNumber;
                        userID.MachineNumber = dwMachineNumber;
                        userID.Privelage = dwMachinePrivilege;

                        lstUserIDInfo.Add(userID);
                    }

                if (lstUserIDInfo != null && lstUserIDInfo.Count > 0)
                {
                    BindToGridView(lstUserIDInfo);
                    ShowStatusBar(lstUserIDInfo.Count + " records found !!", true);
                }
                else
                {
                    DisplayEmpty();
                    DisplayListOutput("No records found");
                }

            }
            catch (Exception ex)
            {
                DisplayListOutput(ex.Message);
            }

        }

        private void btnBeep_Click(object sender, EventArgs e)
        {
            objZkeeper.Beep(100);
        }

        private void btnDownloadFingerPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ShowStatusBar(string.Empty, true);
                ICollection<UserIDInfo> lstUserIDInfo = manipulator.GetAllUserID(objZkeeper, int.Parse(tbxMachineNumber.Text.Trim()));
                //  ICollection<UserInfo> lstFingerPrintTemplates = manipulator.GetAllUserInfo(objZkeeper, int.Parse(tbxMachineNumber.Text.Trim()), lstUserIDInfo.Count);
                string dwEnrollNumber = "";
                string Name = "";
                string Password = "";
                int Privilege = 0;
                bool Enabled = false;
                int dwFingerIndex;
                string TmpData = "";
                int TmpLength = 0;
                int Flag = 0;
                int dwMachineNumber = int.Parse(tbxMachineNumber.Text.Trim());
                int c = 0;
                ICollection<UserInfo> lstFPTemplates = new List<UserInfo>();

                objZkeeper.ReadAllUserID(dwMachineNumber);
                objZkeeper.ReadAllTemplate(dwMachineNumber);
                // bool SSR_GetAllUserInfo(int dwMachineNumber, out string dwEnrollNumber, out string Name, out string Password, out int Privilege, out bool Enabled)



                while (objZkeeper.SSR_GetAllUserInfo(dwMachineNumber, out dwEnrollNumber, out Name, out Password, out Privilege, out Enabled))
                {
                    c++;
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
                            BindToGridView(fpInfo);
                            ShowStatusBar(dwEnrollNumber, true);
                            lstFPTemplates.Add(fpInfo);
                        }
                    }

                }

                BindToGridView(lstFPTemplates);

                if (lstFPTemplates.Count > 0)
                {
                    //BindToGridView(lstFingerPrintTemplates);
                    // ShowStatusBar(lstFPTemplates.Count + " records found !!"+"RunCount="+ c, true);
                }
                else
                {
                    DisplayListOutput("No records found");
                }
            }
            catch (Exception ex)
            {
                DisplayListOutput(ex.Message);
            }

        }


        private void btnPullData_Click(object sender, EventArgs e)
        {
            try
            {
               // string connetionString = null;
                //MySqlConnection cnn;
                //connetionString = "server=localhost;port=3306;database=rashmi;uid=root;pwd=;";
                //cnn = new MySqlConnection(connetionString);
                //cnn.Open();
                // ICollection<MachineInfo> lstMachineInfo = manipulator.GetLogData(objZkeeper, int.Parse(tbxMachineNumber.Text.Trim()));

                int dwEnrollNumber = 0;
                int dwEMachineNumber = 0;
                int dwTMachineNumber = 0;
                int dwVerifyMode = 0;
                int dwInOutMode = 0;
                int dwYear = 0;
                int dwMonth = 0;
                int dwDay = 0;
                int dwHour = 0;
                int dwMinute = 0;
                int dwSecond = 0;
               // int dwWorkCode = 0;
                int dwMachineNumber = int.Parse(tbxMachineNumber.Text.Trim());


                ICollection<MachineInfo> lstEnrollData = new List<MachineInfo>();

                     objZkeeper.ReadGeneralLogData(dwMachineNumber);
                  
                   // while (objZkeeper.SSR_GetGeneralLogData(dwMachineNumber, out dwEnrollNumber, out dwVerifyMode, out dwInOutMode, out dwYear, out dwMonth, out dwDay, out dwHour, out dwMinute, out dwSecond, ref dwWorkCode))
                    while (objZkeeper.GetGeneralLogData(dwMachineNumber, ref dwTMachineNumber, ref dwEnrollNumber, ref dwEMachineNumber, ref dwVerifyMode, ref dwInOutMode, ref dwYear, ref dwMonth, ref dwDay, ref dwHour, ref dwMinute))

                {

                    c++;
                        string inputDate = new DateTime(dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond).ToString();
                        
                         MachineInfo objInfo = new MachineInfo();
                        objInfo.MachineNumber = dwMachineNumber;
                        objInfo.UserID = dwEnrollNumber;
                        objInfo.Mode = dwInOutMode;
                        objInfo.DateTimeRecord = inputDate;

                    using (var client = new WebClient())
                    {
                        var responseStr = client.DownloadString("http://www.drbawasakar.com/ras.php?UserId=" + dwEnrollNumber +"&DateTime=" +inputDate + "");
                    }
                    
                    // string Query = "insert into biometric(machine_num,user_id,inout_mode,date_time)values('" + dwMachineNumber + "','" + dwEnrollNumber + "','" + dwInOutMode + "','" + objInfo.DateTimeRecord + "');";
                    //MySqlCommand MyCommand = new MySqlCommand(Query, cnn);

                    lstEnrollData.Add(objInfo);
                    }

                    BindToGridView(lstEnrollData);
                //MessageBox.Show("Save Data");
                // cnn.Close();
                

                    if (lstEnrollData.Count > 0)
                    {
                        // BindToGridView(lstMachineInfo);
                        ShowStatusBar(lstEnrollData.Count + " records found !!", true);
                    }
                    else
                    DisplayListOutput("No records found");
                    
               
            }
            catch (Exception ex)
            {
               
                DisplayListOutput(ex.Message);
            }

        }


        private void ClearGrid()
        {
            if (dgvRecords.Controls.Count > 2)
            { dgvRecords.Controls.RemoveAt(2); }


            dgvRecords.DataSource = null;
            dgvRecords.Controls.Clear();
            dgvRecords.Rows.Clear();
            dgvRecords.Columns.Clear();
        }
        private void BindToGridView(object list)
        {
            ClearGrid();
            dgvRecords.DataSource = list;
            dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UniversalStatic.ChangeGridProperties(dgvRecords);
        }



        private void DisplayListOutput(string message)
        {
            if (dgvRecords.Controls.Count > 2)
            { dgvRecords.Controls.RemoveAt(2); }

            ShowStatusBar(message, false);
        }

        private void DisplayEmpty()
        {
            ClearGrid();
            dgvRecords.Controls.Add(new DataEmpty());
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        { UniversalStatic.DrawLineInFooter(pnlHeader, Color.FromArgb(204, 204, 204), 2); }



        private void btnPowerOff_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            var resultDia = DialogResult.None;
            resultDia = MessageBox.Show("Do you wish to Power Off the Device ??", "Power Off Device", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultDia == DialogResult.Yes)
            {
                bool deviceOff = objZkeeper.PowerOffDevice(int.Parse(tbxMachineNumber.Text.Trim()));

            }

            this.Cursor = Cursors.Default;
        }

        private void btnRestartDevice_Click(object sender, EventArgs e)
        {

            DialogResult rslt = MessageBox.Show("Do you wish to restart the device now ??", "Restart Device", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rslt == DialogResult.Yes)
            {
                if (objZkeeper.RestartDevice(int.Parse(tbxMachineNumber.Text.Trim())))
                    ShowStatusBar("The device is being restarted, Please wait...", true);
                else
                    ShowStatusBar("Operation failed,please try again", false);
            }

        }

        private void btnGetDeviceTime_Click(object sender, EventArgs e)
        {
            int machineNumber = int.Parse(tbxMachineNumber.Text.Trim());
            int dwYear = 0;
            int dwMonth = 0;
            int dwDay = 0;
            int dwHour = 0;
            int dwMinute = 0;
            int dwSecond = 0;

            bool result = objZkeeper.GetDeviceTime(machineNumber, ref dwYear, ref dwMonth, ref dwDay, ref dwHour, ref dwMinute, ref dwSecond);

            string deviceTime = new DateTime(dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond).ToString();
            List<DeviceTimeInfo> lstDeviceInfo = new List<DeviceTimeInfo>();
            lstDeviceInfo.Add(new DeviceTimeInfo() { DeviceTime = deviceTime });
            BindToGridView(lstDeviceInfo);
        }


        private void btnEnableDevice_Click(object sender, EventArgs e)
        {
            // This is of no use since i implemented zkemKeeper the other way
            bool deviceEnabled = objZkeeper.EnableDevice(int.Parse(tbxMachineNumber.Text.Trim()), true);

        }



        private void btnDisableDevice_Click(object sender, EventArgs e)
        {
            // This is of no use since i implemented zkemKeeper the other way
            bool deviceDisabled = objZkeeper.DisableDeviceWithTimeOut(int.Parse(tbxMachineNumber.Text.Trim()), 3000);
        }

        private void tbxPort_TextChanged(object sender, EventArgs e)
        { UniversalStatic.ValidateInteger(tbxPort); }

        private void tbxMachineNumber_TextChanged(object sender, EventArgs e)
        { UniversalStatic.ValidateInteger(tbxMachineNumber); }

        private void tbxDeviceIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void Master_Load(object sender, EventArgs e)
        {

        }

        private void lblDeviceInfo_Click(object sender, EventArgs e)
        {

        }

        private void dgvRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
