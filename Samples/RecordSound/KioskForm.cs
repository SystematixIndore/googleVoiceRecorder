using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Diagnostics;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;

namespace RecordSound
{
    public partial class KioskForm : Form
    {

        #region Properties

        private globalKeyboardHook GBHook;
        private bool ClosingAllowed = false;
      

        private string Password
        {
            get
            {
                return Properties.Settings.Default.Password;
            }
        }
     

        private Stopwatch InactiveStopWatch = new Stopwatch();


        #endregion


        private System.Windows.Forms.Panel _panel;

        private const  string _processName = @"C:\Program Files (x86)\Default Company Name\RecordingSetup\RecordSound.exe";
        [DllImport("user32")]
        private static extern IntPtr SetParent(IntPtr hWnd, IntPtr hWndParent);
        public KioskForm()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.ClosingAllowed == false)
            {
                e.Cancel = true;
            }
            base.OnClosing(e);
        }

        private void EnableKioskMode()
        {
            if (this.IsAdministrator() == false)
            {
                MessageBox.Show("This program can only run under an administrator account.");
                this.ClosingAllowed = true;
                this.Close();
                return;
            }

            //Init exe, webbrowser and others
            this.InitControls();

            //Global keyboardhook
            this.GBHook = new globalKeyboardHook(Process.GetCurrentProcess(), this);

            this.ClosingAllowed = false;
            this.DisableTaskmanager();
            Taskbar.Hide();
            this.Startup(true);
        }

        public void DisableTaskmanager()
        {
            try
            {
                using (RegistryKey keyTaskManager = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", true))
                {
                    if (keyTaskManager == null)
                    {
                        using (RegistryKey subKeyLogOff = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies", true))
                        {
                            subKeyLogOff.CreateSubKey("System");
                        }
                    }
                }
                using (RegistryKey keyTaskManager = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", true))
                {
                    keyTaskManager.SetValue("DisableTaskMgr", 1);
                }
            }
            catch
            {
                MessageBox.Show("An error occured while disabling the task manager.");
            }
        }

        public void EnableTaskManager()
        {
            try
            {
                using (RegistryKey keyTaskManager = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", true))
                {
                    keyTaskManager.SetValue("DisableTaskMgr", 0);
                }
            }
            catch 
            {
                MessageBox.Show("En error occured while enabling the taskmanager.");
            }
        }

        public bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public void InitControls()
        {
            RunFormOnKiosk();

            //this.WebBrowser = new WebBrowser();
            //this.WebBrowser.Location = new Point(0, 36);
            //this.WebBrowser.Size = new Size(this.Width, this.Height - 36);
            //this.WebBrowser.Navigate(this.HomeAddress);

            //this.WebBrowser.CanGoBackChanged += new EventHandler(WebBrowser_CanGoBackChanged);
            //this.WebBrowser.CanGoForwardChanged += new EventHandler(WebBrowser_CanGoForwardChanged);
            //this.WebBrowser.NewWindow += new CancelEventHandler(WebBrowser_NewWindow);
            //this.WebBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser_DocumentCompleted);
            //this.WebBrowser.Navigating += new WebBrowserNavigatingEventHandler(WebBrowser_Navigating);
            //this.WebBrowser.AllowWebBrowserDrop = false;
            //((SHDocVw.WebBrowser)this.WebBrowser.ActiveXInstance).FileDownload += new SHDocVw.DWebBrowserEvents2_FileDownloadEventHandler(WebBrowser_FileDownload);

            //this.Controls.Add(this.WebBrowser);

            //this.tbUrl.Text = this.HomeAddress;
            //this.tbUrl.Size = new Size((int)(this.Width * 0.75) - 117, this.tbUrl.Height);
        }

        private void RunFormOnKiosk()
        {
            this._panel = new Panel();
            this._panel.Location = new Point(0, 36);
            this._panel.Size = new Size(this.Width, this.Height - 36);

            RecordSoundWithPcm frm = new RecordSoundWithPcm();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.Controls.Add(frm);
            frm.Show();
        }

  
        public void DisableKiosMode()
        {
            this.ClosingAllowed = true;

            try
            {
                this.GBHook.unhook();
                this.GBHook = null;

                this.EnableTaskManager();

                Taskbar.Show();

                this.Startup(false);
            }
            catch
            {
                MessageBox.Show("An error occured while restoring all settings.");
            }

            this.Close();
        }


    


        private void Form1_Load(object sender, EventArgs e)
        {
            this.EnableKioskMode();
            this.tmrCheckInactive.Start();
        }
     

 

        private void Startup(bool add)
        {
            using (RegistryKey keyExplorer = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer", true))
            {
                if (keyExplorer == null)
                {
                    using (RegistryKey subKeyLogOff = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies", true))
                    {
                        subKeyLogOff.CreateSubKey("Explorer");
                    }
                }
            }
          

            using (RegistryKey keyAppRun = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
            using (RegistryKey keyExplorer = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer", true))
            using (RegistryKey keySystemCU = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", true))
            using (RegistryKey keySystemLM = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", true))
            {
                if (add)
                {
                    keyAppRun.SetValue("RecordSound", System.Reflection.Assembly.GetEntryAssembly().Location);

                    keySystemLM.SetValue("HideFastUserSwitching", 1);
                    keySystemCU.SetValue("DisableLockWorkstation", 1);
                    keySystemCU.SetValue("DisableChangePassword", 1);
                    keyExplorer.SetValue("NoLogoff", 1);
                    keyExplorer.SetValue("NoClose", 1);
                }
                else
                {
                    keyExplorer.SetValue("NoLogoff", 0);
                    keyExplorer.SetValue("NoClose", 0);
                    keySystemLM.SetValue("HideFastUserSwitching", 0);

                    if (keySystemCU != null)
                    {
                        keySystemCU.SetValue("DisableLockWorkstation", 0);
                        keySystemCU.SetValue("DisableChangePassword", 0);
                    }
                }
            }
        }

        private const int INTERNET_OPTION_END_BROWSER_SESSION = 42;

        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);

        private void tmrCheckInactive_Tick(object sender, EventArgs e)
        {
            //if (this.InactiveStopWatch.Elapsed.TotalMinutes >= this.InactiveResetTime && this.tbUrl.Text != this.HomeAddress)
            //{
            //    this.NavigateToHome();
            //}
        }

        /// <summary>
        /// Show the admin pannel in a new thread so the keyboard isn't locked up.
        /// </summary>
        internal void ShowAdmin()
        {
            BackgroundWorker b = new BackgroundWorker();
            b.RunWorkerCompleted += new RunWorkerCompletedEventHandler(b_RunWorkerCompleted);
            b.RunWorkerAsync();
        }

        void b_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowAdminThread();
        }

        private void ShowAdminThread()
        {
            InputForm i = new InputForm(this.Password);
            if (i.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.DisableKiosMode();
                using (RegistryKey keyAppRun = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
                {
                    keyAppRun.DeleteValue("RecordSound");
                    foreach (var proc in Process.GetProcessesByName("RecordSound"))
                    {
                        proc.Kill();
                    }
                }
            }
        }
    }
}
