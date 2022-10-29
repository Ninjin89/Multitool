using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using Memory;
using System.Net;
using System.IO;
using System.Diagnostics;
using Multitool.Properties;
using AutoUpdaterDotNET;
using System.Threading;
using System.Net.Http;

namespace Multitool
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {

        CookieContainer Cookie = null;
        public Login()
        {
            InitializeComponent();
            AutoUpdater.Start("https://ninjin.eu/update/version66.xml");
            AutoUpdater.ShowSkipButton = false;
            AutoUpdater.ShowRemindLaterButton = false;

        }


        public Mem m = new Mem();

        private void Login_Load(object sender, EventArgs e)
        {
            TopMost = true;
            Cookie = new CookieContainer(); // important 
            dfgv35v3fg3v23.Text = Settings.Default.dfgv35v3fg3v23;
            dfgpkvmdfuih9iu.Text = Settings.Default.dfgpkvmdfuih9iu;
            efdvjkfdhijdbzui76834.Text = Settings.Default.efdvjkfdhijdbzui76834;

        }

        private string PerformRequest(string tg5vgf34t, string ghjmghngvhfd, string vtzrgh67unh43, string tgrvfdfbs)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(tg5vgf34t);
            request.CookieContainer = Cookie; // use the global cookie variable
            string postData = "2r53efv54tzh534thb=" + ghjmghngvhfd + "&43fr23rfeds1edc123frt43vev=" + vtzrgh67unh43 + "&32tg356z34tfrv34erf2f=" + tgrvfdfbs;
            byte[] data = Encoding.UTF8.GetBytes(postData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
            request.ContentLength = data.Length;


            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }



            WebResponse response = (HttpWebResponse)request.GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();


        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dfgpkvmdfuih9iu.Text) || string.IsNullOrWhiteSpace(efdvjkfdhijdbzui76834.Text) || string.IsNullOrEmpty(efdvjkfdhijdbzui76834.Text) || string.IsNullOrWhiteSpace(dfgv35v3fg3v23.Text) || string.IsNullOrEmpty(dfgv35v3fg3v23.Text) || string.IsNullOrWhiteSpace(dfgpkvmdfuih9iu.Text))
            {
                MessageBox.Show("Please enter forum Username + password + email!");
            }
            else
            {
                var login = (PerformRequest("https://ninjin.eu/update/h56uhj35t4g4.php", dfgpkvmdfuih9iu.Text, dfgv35v3fg3v23.Text, efdvjkfdhijdbzui76834.Text));
                if (login == "5g%5=$&rtfg!4%&=!3t4%§532§f")
                {
                    Form frm = new Multitool();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong credentials!");
                }

            }

            Settings.Default.dfgpkvmdfuih9iu = dfgpkvmdfuih9iu.Text;
            Settings.Default.efdvjkfdhijdbzui76834 = efdvjkfdhijdbzui76834.Text;
            Settings.Default.dfgv35v3fg3v23 = dfgv35v3fg3v23.Text;
            Settings.Default.Save();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

            Settings.Default.dfgv35v3fg3v23 = dfgv35v3fg3v23.Text;
            Settings.Default.efdvjkfdhijdbzui76834 = efdvjkfdhijdbzui76834.Text;
            Settings.Default.dfgpkvmdfuih9iu = dfgpkvmdfuih9iu.Text;
            Settings.Default.Save();
            Application.Exit();

        }

        private void efdvjkfdhijdbzui76834_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrEmpty(dfgpkvmdfuih9iu.Text) || string.IsNullOrWhiteSpace(efdvjkfdhijdbzui76834.Text) || string.IsNullOrEmpty(efdvjkfdhijdbzui76834.Text) || string.IsNullOrWhiteSpace(dfgv35v3fg3v23.Text) || string.IsNullOrEmpty(dfgv35v3fg3v23.Text) || string.IsNullOrWhiteSpace(dfgpkvmdfuih9iu.Text))
                {
                    MessageBox.Show("Please enter forum Username + password + email!");
                }
                else
                {
                    var login = (PerformRequest("https://ninjin.eu/update/h56uhj35t4g4.php", dfgpkvmdfuih9iu.Text, dfgv35v3fg3v23.Text, efdvjkfdhijdbzui76834.Text));
                    if (login == "5g%5=$&rtfg!4%&=!3t4%§532§f")
                    {
                        Form frm = new Multitool();
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong credentials!");
                    }
                }

                Settings.Default.dfgpkvmdfuih9iu = dfgpkvmdfuih9iu.Text;
                Settings.Default.efdvjkfdhijdbzui76834 = efdvjkfdhijdbzui76834.Text;
                Settings.Default.dfgv35v3fg3v23 = dfgv35v3fg3v23.Text;
                Settings.Default.Save();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("dnSpy");
            if (pname.Length > 0)
            {
                Application.Exit();
            }
            Process[] dnSpy = Process.GetProcessesByName("dnSpy-x86");
            if (dnSpy.Length > 0)
            {
                Application.Exit();
            }
            Process[] dnSpyx64 = Process.GetProcessesByName("dnSpy-x64");
            if (dnSpyx64.Length > 0)
            {
                Application.Exit();
            }
            Process[] pname2 = Process.GetProcessesByName("ILSpy");
            if (pname2.Length > 0)
            {
                Application.Exit();
            }
            Process[] pname3 = Process.GetProcessesByName("Reflector");
            if (pname3.Length > 0)
            {
                Application.Exit();
            }
            Process[] pname4 = Process.GetProcessesByName("JustDecompile");
            if (pname4.Length > 0)
            {
                Application.Exit();
            }
            Process[] pname5 = Process.GetProcessesByName("ProcessHacker");
            if (pname5.Length > 0)
            {
                Application.Exit();
            }
            Process[] pname10 = Process.GetProcessesByName("peview");
            if (pname10.Length > 0)
            {
                Application.Exit();
            }
            Process[] pname6 = Process.GetProcessesByName("Wireshark");
            if (pname6.Length > 0)
            {
                Application.Exit();
            }
            Process[] pname7 = Process.GetProcessesByName("Fiddler");
            if (pname7.Length > 0)
            {

                Application.Exit();
            }
            Process[] pname8 = Process.GetProcessesByName("de4dot");
            if (pname8.Length > 0)
            {
                Application.Exit();
            }
            Process[] pname9 = Process.GetProcessesByName("de4dot-x64");
            if (pname9.Length > 0)
            {
                Application.Exit();
            }
            Process[] pname11 = Process.GetProcessesByName("dotPeek64");
            if (pname11.Length > 0)
            {
                Application.Exit();
            }
            Process[] pname12 = Process.GetProcessesByName("dotPeek32");
            if (pname12.Length > 0)
            {
                Application.Exit();
            }
            Process[] pname13 = Process.GetProcessesByName("Dile");
            if (pname13.Length > 0)
            {
                Application.Exit();
            }
            Process[] pname14 = Process.GetProcessesByName("OLLYDBG");
            if (pname14.Length > 0)
            {
                Application.Exit();
            }
            Process[] pname15 = Process.GetProcessesByName("Nmap");
            if (pname15.Length > 0)
            {
                Application.Exit();
            }
            Process[] pname16 = Process.GetProcessesByName("IDA");
            if (pname16.Length > 0)
            {
                Application.Exit();
            }
            Process[] pname17 = Process.GetProcessesByName("ida");
            if (pname17.Length > 0)
            {
                Application.Exit();
            }
            Process[] runningProcs = Process.GetProcesses();
            

            foreach (Process process in runningProcs)
            {
                Console.WriteLine(process.MainWindowTitle);
                Console.WriteLine(process.MainWindowHandle);
                var xx = process;             
                if (process.MainWindowTitle == 
                    ("Progress Telerik Fiddler Web Debugger") 
                    || process.MainWindowTitle == "dnSpy v4.5.3 (x64)"
                    || process.MainWindowTitle == "dnSpy v4.5.3 (x86)"
                    || process.MainWindowTitle == "Die Wireshark Netzwerk Analysesoftware"
                    || process.MainWindowTitle == "Wireshark"
                    || process.MainWindowTitle == "Capturing from Ethernet"
                    || process.MainWindowTitle == "Progress® Telerik® JustDecompile - DefaultAssemblyList - (0 files)"
                    || process.MainWindowTitle == "Progress® Telerik® JustDecompile - DefaultAssemblyList - (1 file)"
                    || process.MainWindowTitle == "Progress® Telerik® JustDecompile - DefaultAssemblyList - (2 files)"
                    || process.MainWindowTitle == "Progress® Telerik® JustDecompile - DefaultAssemblyList - (3 files)"
                    || process.MainWindowTitle == "Progress® Telerik® JustDecompile - DefaultAssemblyList - (4 files)"
                    || process.MainWindowTitle == "Progress® Telerik® JustDecompile - DefaultAssemblyList - (5 files)"
                    || process.MainWindowTitle == "Progress® Telerik® JustDecompile - DefaultAssemblyList - (6 files)"
                    || process.MainWindowTitle == "Progress® Telerik® JustDecompile - DefaultAssemblyList - (7 files)"
                    || process.MainWindowTitle == "Progress® Telerik® JustDecompile - DefaultAssemblyList - (8 files)"
                    || process.MainWindowTitle == "Progress® Telerik® JustDecompile - DefaultAssemblyList - (9 files)"
                    || process.MainWindowTitle == "Progress® Telerik® JustDecompile - DefaultAssemblyList - (10 files)"
                    || process.MainWindowTitle == "Progress® Telerik® JustDecompile - DefaultAssemblyList - (11 files)"
                    || process.MainWindowTitle == "Progress® Telerik® JustDecompile - DefaultAssemblyList - (12 files)"
                    || process.MainWindowTitle == "Progress® Telerik® JustDecompile - DefaultAssemblyList - (13 files)"
                    || process.MainWindowTitle == "Progress® Telerik® JustDecompile - DefaultAssemblyList - (14 files)"
                    || process.MainWindowTitle == "Progress® Telerik® JustDecompile - DefaultAssemblyList - (15 files)"
                    || process.MainWindowTitle == "Progress® Telerik® JustDecompile - DefaultAssemblyList - (16 files)"
                    || process.MainWindowTitle == "Progress® Telerik® JustDecompile - DefaultAssemblyList - (17 files)"
                    || process.MainWindowTitle == "Progress® Telerik® JustDecompile - DefaultAssemblyList - (18 files)"
                    || process.MainWindowTitle == "Progress® Telerik® JustDecompile - DefaultAssemblyList - (19 files)"
                    || process.MainWindowTitle == "Progress® Telerik® JustDecompile - DefaultAssemblyList - (20 files)"
                    )
                {
                    Application.Exit();
                }           
            }
            Thread.Sleep(1000);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }
    }
}
