using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using Microsoft.Win32;

namespace AutoRunWhenStart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoStart(true);

        }

        public static void AutoStart(bool isAuto)
        {
            //LocalMachine機碼位置
            //電腦\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\StartupApproved\Run32
            try
            {
                if (isAuto == true)
                {
                    RegistryKey R_local = Registry.LocalMachine;
                    //RegistryKey R_local = Registry.CurrentUser;
                    RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                    R_run.SetValue("開機自動執行", Application.ExecutablePath.ToString());
                    R_run.Close();
                    R_local.Close();
                }
                else
                {
                    RegistryKey R_local = Registry.LocalMachine;
                    //RegistryKey R_local = Registry.CurrentUser;
                    RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                    R_run.DeleteValue("開機自動執行", false);
                    R_run.Close();
                    R_local.Close();
                }

                //GlobalVariant.Instance.UserConfig.AutoStart = isAuto;
            }
            catch (Exception)
            {
                //MessageBoxDlg dlg = new MessageBoxDlg();
                //dlg.InitialData("您需要管理員許可權修改", "提示", MessageBoxButtons.OK, MessageBoxDlgIcon.Error);
                //dlg.ShowDialog();
                MessageBox.Show("您需要管理員許可權修改", "提示");
            }
        }
    }
}
