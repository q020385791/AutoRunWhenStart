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
            //IWshRuntimeLibrary
            //增加參考，選擇 COM 選項卡，然後 選擇Windows Script Host Object Model
            //WshShell shell = new WshShell();
            //IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + " " + "\\Test.lnk");
            //shortcut.TargetPath = Application.ExecutablePath;
            //shortcut.WorkingDirectory = System.Environment.CurrentDirectory;
            //shortcut.WindowStyle = 1;
            //shortcut.Description = "test Application";
            //shortcut.Save();
            AutoStart(false);

        }

        public static void AutoStart(bool isAuto)
        {
            
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
