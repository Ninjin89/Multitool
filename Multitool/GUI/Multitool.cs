using Memory;
using Multitool.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multitool
{
    public partial class Multitool : Form
    {
        public Multitool()
        {
            InitializeComponent();

        }

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);


        ProcessStartInfo Info = new ProcessStartInfo();
        public Mem m = new Mem();
        public bool openProc = false;
        public long aobscanaddr = 0;
        public long aobscanaddr2 = 0;
               

        protected override void WndProc(ref Message m) //hotbuttons
        {
            if (m.Msg == 0x0312)
            {
                int id = m.WParam.ToInt32();
                if (id == 1)
                {
                    pictureBox4_Click(this.pictureBox4, null);
                }
                else if (id == 2)
                {
                    pictureBox6_Click(this.pictureBox6, null);
                }
                else if (id == 3)
                {
                    pictureBox8_Click(this.pictureBox6, null);
                }
                else if (id == 4)
                {
                    pictureBox16_Click(this.pictureBox6, null);
                }
                else if (id == 5)
                {
                    pictureBox14_Click(this.pictureBox6, null);
                }
                else if (id == 6)
                {
                    pictureBox12_Click(this.pictureBox6, null);
                }
            }
            base.WndProc(ref m);
        }

        ///======================================================
        ///   DESIGN RELATED STUFF + DEFAULT USER SETTINGS
        ///====================================================== 
        private void Multitool_Load(object sender, EventArgs e) // Application Load
        {
            RegisterHotKey(this.Handle, 1, 0x0001, (int)Keys.F5);
            RegisterHotKey(this.Handle, 2, 0x0001, (int)Keys.F6);
            RegisterHotKey(this.Handle, 3, 0x0001, (int)Keys.F7);
            RegisterHotKey(this.Handle, 4, 0x0001, (int)Keys.F8);
            RegisterHotKey(this.Handle, 5, 0x0001, (int)Keys.F9);
            RegisterHotKey(this.Handle, 6, 0x0001, (int)Keys.F10);

            Panel1.Show();
            metroLabel6.Show();
            metroLabel7.Show();
            metroLabel8.Show();
            enemybox.Enabled = false;
            mylpbox.Enabled = false;
            RecoverLpBox.Enabled = false;

            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();

            if (!backgroundWorker2.IsBusy)
                backgroundWorker2.RunWorkerAsync();

            if (!backgroundWorker4.IsBusy)
                backgroundWorker4.RunWorkerAsync();

            //  Text Checkboxes.
            //enemymin.Text = Settings.Default.enemymin;
            //enemymax.Text = Settings.Default.enemymax;
            enemylp.Text = Settings.Default.enemymax;
            mylpmin.Text = Settings.Default.mylpmin;
            mylpmax.Text = Settings.Default.mylpmax;
            mylp.Text = Settings.Default.mylp;
            //recovermin.Text = Settings.Default.recovermin;
            //recovermax.Text = Settings.Default.recovermax;
            recoverlp.Text = Settings.Default.recoverlp;
            mydeckmin.Text = Settings.Default.mydeckmin;
            mydeckmax.Text = Settings.Default.mydeckmax;
            mydeck.Text = Settings.Default.mydeck;
            myhandmin.Text = Settings.Default.myhandmin;
            myhandmax.Text = Settings.Default.myhandmax;
            myhand.Text = Settings.Default.myhand;
            enemydeckmin.Text = Settings.Default.enemydeckmin;
            enemydeckmax.Text = Settings.Default.enemydeckmax;
            enemydeck.Text = Settings.Default.enemydeck;
            enemyhandmin.Text = Settings.Default.enemyhandmin;
            enemyhandmax.Text = Settings.Default.enemyhandmax;
            enemyhand.Text = Settings.Default.enemyhand;
            continmin.Text = Settings.Default.continmin;
            continmax.Text = Settings.Default.continmax;
            continresult.Text = Settings.Default.continresult;
            Profile1.Text = Settings.Default.Profile1;
            Profile2.Text = Settings.Default.Profile2;
            Profile3.Text = Settings.Default.Profile3;
            Profile4.Text = Settings.Default.Profile4;
            Profile5.Text = Settings.Default.Profile5;
            Profile6.Text = Settings.Default.Profile6;
            enemydeck.Text = Settings.Default.enemydeck;
            recoverlp.Text = Settings.Default.recoverlp;
            mydeck.Text = Settings.Default.mydeck;
            myhand.Text = Settings.Default.myhand;
            enemyhand.Text = Settings.Default.enemyhand;
            skillusemission.Text = Settings.Default.skillusemission;
            effectdamagevalue.Text = Settings.Default.effectdamagevalue;
            normalsummon.Text = Settings.Default.normalsummon;
            tributesummon.Text = Settings.Default.tributesummon;
            specialsummon.Text = Settings.Default.specialsummon;
            activatedspell.Text = Settings.Default.activatedspell;
            continspells.Text = Settings.Default.continspells;
            quickspells.Text = Settings.Default.quickspells;
            activatedtraps.Text = Settings.Default.activatedtraps;
            normalsummon.Text = Settings.Default.ns1;
            ritualsummon.Text = Settings.Default.ritualsummon;
            countertraps.Text = Settings.Default.countertraps;
            fieldspells.Text = Settings.Default.fieldspells;
            equipspells.Text = Settings.Default.equipspells;
            battledama.Text = Settings.Default.maxbattledamagemission;
            fusionsummon.Text = Settings.Default.fusionsummon;
            attacksm.Text = Settings.Default.attacksm;
            mydeckmax.Text = Settings.Default.mydeckmax;
            myhandmax.Text = Settings.Default.myhandmax;
            //recovermax.Text = Settings.Default.recovermax;
            enemydeckmax.Text = Settings.Default.enemydeckmax;
            enemyhandmax.Text = Settings.Default.enemyhandmax;
            activatespellmax.Text = Settings.Default.activatespellmax;
            activatetrapmax.Text = Settings.Default.activatetrapmax;
            quickspellsmax.Text = Settings.Default.quickspellsmax;
            fieldspellsmax.Text = Settings.Default.fieldspellsmax;
            equipspellsmax.Text = Settings.Default.equipspellsmax;
            continspellsmax.Text = Settings.Default.continspellsmax;
            countertrapsmax.Text = Settings.Default.countertrapsmax;
            normalsummonmax.Text = Settings.Default.normalsummonmax;
            tributemax.Text = Settings.Default.tributemax;
            specialmax.Text = Settings.Default.specialmax;
            ritualmax.Text = Settings.Default.ritualmax;
            fusionmax.Text = Settings.Default.fusionmax;
            attacksmademax.Text = Settings.Default.attacksmademax;
            skillsmax.Text = Settings.Default.skillsmax;
            mbdmax.Text = Settings.Default.maxbdmax;
            efdbdmmax.Text = Settings.Default.efdbdmmax;
            mydeckmin.Text = Settings.Default.mydeckmin;
            myhandmin.Text = Settings.Default.myhandmin;
            //recovermin.Text = Settings.Default.recovermin;
            enemydeckmin.Text = Settings.Default.enemydeckmin;
            enemyhandmin.Text = Settings.Default.enemyhandmin;
            activatespellmin.Text = Settings.Default.activatespellmin;
            activatetrapmin.Text = Settings.Default.activatetrapmin;
            quickspellsmin.Text = Settings.Default.quickspellsmin;
            fieldspellsmin.Text = Settings.Default.fieldspellsmin;
            equipspellsmin.Text = Settings.Default.equipspellsmin;
            continspellsmin.Text = Settings.Default.continspellsmin;
            countertrapsmin.Text = Settings.Default.countertrapsmin;
            normalsummonmin.Text = Settings.Default.normalsummonmin;
            tributemin.Text = Settings.Default.tributemin;
            specialmin.Text = Settings.Default.specialmin;
            ritualmin.Text = Settings.Default.ritualmin;
            fusionmin.Text = Settings.Default.fusionmin;
            attacksmademin.Text = Settings.Default.attacksmademin;
            skillsmin.Text = Settings.Default.skillsmin;
            mbdmin.Text = Settings.Default.maxbdmin;
            efdbdmmin.Text = Settings.Default.efdbdmmin;

            syncrosmin.Text = Settings.Default.syncrosmin;
            syncrosmax.Text = Settings.Default.syncrosmax;
            syncrosresult.Text = Settings.Default.syncrosresult;

            turnsmin.Text = Settings.Default.turnsmin;
            turnsmax.Text = Settings.Default.turnsmax;
            turnsresult.Text = Settings.Default.turnsresult;


            // Checkboxes.       
            contintraps.Checked = Settings.Default.contintraps;
            asBox.Checked = Settings.Default.asBox;
            csBox.Checked = Settings.Default.csBox;
            qsBox.Checked = Settings.Default.qsBox;
            fssBox.Checked = Settings.Default.fssBox;
            eqBox.Checked = Settings.Default.eqBox;
            atBox.Checked = Settings.Default.atBox;
            ctBox.Checked = Settings.Default.ctBox;
            nsBox.Checked = Settings.Default.nsBox;
            tsBox.Checked = Settings.Default.tsBox;
            ssBox.Checked = Settings.Default.ssBox;
            rsBox.Checked = Settings.Default.rsBox;
            fsBox.Checked = Settings.Default.fsBox;
            sumBox.Checked = Settings.Default.sumBox;
            edBox.Checked = Settings.Default.edBox;
            maxbdbox.Checked = Settings.Default.maxbdbox;
            enemybox.Checked = Settings.Default.enemybox;
            attacksmbox.Checked = Settings.Default.attacksmadebox;
            enemyhandbox.Checked = Settings.Default.enemyhandbox;
            enemydeckbox.Checked = Settings.Default.enemydeckbox;
            RecoverLpBox.Checked = Settings.Default.RecoverLpBox;
            myhandbox.Checked = Settings.Default.myhandbox;
            mydeckbox.Checked = Settings.Default.mydeckbox;
            mylpbox.Checked = Settings.Default.mylpbox;
            syncros.Checked = Settings.Default.syncros;
            turns.Checked = Settings.Default.turns;
            // End User Settings.

        }

        ///======================================================
        ///                 SPEEDHACK
        ///======================================================
        private void metroButton2_Click(object sender, EventArgs e) // Start Speedhack
        {

            Process[] prs = Process.GetProcesses();


            foreach (Process pr in prs)
            {
                if (pr.ProcessName == "A3E5")
                {

                    pr.Kill();

                }

            }
            Thread.Sleep(100);
            string[] t = Directory.GetFiles(Environment.CurrentDirectory, "A3E5.exe");
            Array.ForEach(t, File.Delete);
            Thread.Sleep(100);
            string tempExeName = Path.Combine(Directory.GetCurrentDirectory(), "A3E5.exe");
            using (FileStream fsDst = new FileStream(tempExeName, FileMode.CreateNew, FileAccess.Write))
            {
                byte[] bytes = Resources.GetSubExe();
                fsDst.Write(bytes, 0, bytes.Length);
            }
            Info.Arguments = "/C rd /s /q \"C:\\MyFolder";
            Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.CreateNoWindow = true;
            Info.FileName = "A3E5.exe";
            Process.Start(Info);
        }

        ///======================================================
        ///                 PANELS
        ///======================================================
        private void bunifuFlatButton1_Click(object sender, EventArgs e) // Life + Recovery
        {
            Panel1.Show();
            Panel2.Hide();
            Panel3.Hide();
            Panel4.Hide();
            Panel5.Hide();
            Panel6.Hide();
            Panel7.Hide();
            Panel8.Hide();
            Panel9.Hide();
            metroLabel6.Show();
            metroLabel7.Show();
            metroLabel8.Show();
            resetsettings.Show();
            metroButton1.Show();
            metroButton2.Show();
            metroButton3.Show();
            metroLabel2.Show();
            metroTrackBar1.Show();
            metroCheckBox1.Show();
            metroCheckBox2.Show();
            pictureBox2.Show();
            //pictureBox11.Show();
            randomda.Show();
            alwayswin.Show();
            autoduel.Show();
            metroCheckBox8.Show();
            pictureBox3.Show();
            metroCheckBox9.Show();
            pictureBox10.Show();
        }
        private void bunifuFlatButton2_Click(object sender, EventArgs e) // Deck + Hand
        {
            Panel2.Show();
            Panel1.Hide();
            Panel3.Hide();
            Panel4.Hide();
            Panel5.Hide();
            Panel6.Hide();
            Panel7.Hide();
            Panel8.Hide();
            Panel9.Hide();
            metroLabel6.Show();
            metroLabel7.Show();
            metroLabel8.Show();
            resetsettings.Show();
            metroButton1.Show();
            metroButton2.Show();
            metroButton3.Show();
            metroLabel2.Show();
            metroTrackBar1.Show();
            metroCheckBox1.Show();
            metroCheckBox2.Show();
            pictureBox2.Show();
          //  pictureBox11.Show();
            randomda.Show();
            alwayswin.Show();
            autoduel.Show();
            metroCheckBox8.Show();
            pictureBox3.Show();
            metroCheckBox9.Show();
            pictureBox10.Show();
        }
        private void bunifuFlatButton3_Click(object sender, EventArgs e) // Damage
        {
            Panel3.Show();
            Panel1.Hide();
            Panel2.Hide();
            Panel4.Hide();
            Panel5.Hide();
            Panel6.Hide();
            Panel7.Hide();
            Panel8.Hide();
            Panel9.Hide();
            metroLabel6.Show();
            metroLabel7.Show();
            metroLabel8.Show();
            resetsettings.Show();
            metroButton1.Show();
            metroButton2.Show();
            metroButton3.Show();
            metroLabel2.Show();
            metroTrackBar1.Show();
            metroCheckBox1.Show();
            metroCheckBox2.Show();
            pictureBox2.Show();
            //pictureBox11.Show();
            randomda.Show();
            alwayswin.Show();
            autoduel.Show();
            metroCheckBox8.Show();
            pictureBox3.Show();
            pictureBox10.Show();
            metroCheckBox9.Show();
        }
        private void bunifuFlatButton5_Click(object sender, EventArgs e) // Spells
        {
            Panel5.Show();
            Panel1.Hide();
            Panel2.Hide();
            Panel3.Hide();
            Panel4.Hide();
            Panel6.Hide();
            Panel7.Hide();
            Panel8.Hide();
            Panel9.Hide();
            metroLabel6.Show();
            metroLabel7.Show();
            metroLabel8.Show();
            resetsettings.Show();
            metroButton1.Show();
            metroButton2.Show();
            metroButton3.Show();
            metroLabel2.Show();
            metroTrackBar1.Show();
            metroCheckBox1.Show();
            metroCheckBox2.Show();
            pictureBox2.Show();
            //pictureBox11.Show();
            randomda.Show();
            alwayswin.Show();
            autoduel.Show();
            metroCheckBox8.Show();
            pictureBox3.Show();
            metroCheckBox9.Show();
            pictureBox10.Show();
        }
        private void bunifuFlatButton6_Click(object sender, EventArgs e) // Traps
        {
            Panel6.Show();
            Panel4.Hide();
            Panel1.Hide();
            Panel2.Hide();
            Panel3.Hide();
            Panel5.Hide();
            Panel7.Hide();
            Panel8.Hide();
            Panel9.Hide();
            metroLabel6.Show();
            metroLabel7.Show();
            metroLabel8.Show();
            resetsettings.Show();
            metroButton1.Show();
            metroButton2.Show();
            metroButton3.Show();
            metroLabel2.Show();
            metroTrackBar1.Show();
            metroCheckBox1.Show();
            metroCheckBox2.Show();
            pictureBox2.Show();
            //pictureBox11.Show();
            randomda.Show();
            alwayswin.Show();
            autoduel.Show();
            metroCheckBox8.Show();
            pictureBox3.Show();
            metroCheckBox9.Show();
            pictureBox10.Show();
        }
        private void bunifuFlatButton4_Click(object sender, EventArgs e) // Summons
        {
            Panel4.Show();
            Panel6.Hide();
            Panel1.Hide();
            Panel2.Hide();
            Panel3.Hide();
            Panel5.Hide();
            Panel7.Hide();
            Panel8.Hide();
            Panel9.Hide();
            metroLabel6.Show();
            metroLabel7.Show();
            metroLabel8.Show();
            resetsettings.Show();
            metroButton1.Show();
            metroButton2.Show();
            metroButton3.Show();
            metroLabel2.Show();
            metroTrackBar1.Show();
            metroCheckBox1.Show();
            metroCheckBox2.Show();
            pictureBox2.Show();
            //pictureBox11.Show();
            randomda.Show();
            alwayswin.Show();
            autoduel.Show();
            metroCheckBox8.Show();
            pictureBox3.Show();
            metroCheckBox9.Show();
            pictureBox10.Show();
        }
        private void bunifuFlatButton8_Click(object sender, EventArgs e) // Profiles
        {
            Panel7.Show();
            Panel1.Hide();
            Panel2.Hide();
            Panel3.Hide();
            Panel4.Hide();
            Panel5.Hide();
            Panel6.Hide();
            Panel8.Hide();
            Panel9.Hide();
            metroLabel6.Hide();
            metroLabel7.Hide();
            metroLabel8.Hide();
            resetsettings.Show();
            metroButton1.Show();
            metroButton2.Show();
            metroButton3.Show();
            metroLabel2.Show();
            metroTrackBar1.Show();
            metroCheckBox1.Show();
            metroCheckBox2.Show();
            pictureBox2.Show();
            //pictureBox11.Show();
            randomda.Show();
            alwayswin.Show();
            autoduel.Show();
            metroCheckBox8.Show();
            pictureBox3.Show();
            metroCheckBox9.Show();
            pictureBox10.Show();
        }
        private void misc_Click(object sender, EventArgs e) // Misc
        {
            Panel1.Hide();
            Panel2.Hide();
            Panel3.Hide();
            Panel4.Hide();
            Panel5.Hide();
            Panel6.Hide();
            Panel7.Hide();
            Panel8.Show();
            Panel9.Hide();
            resetsettings.Show();
            metroButton1.Show();
            metroButton2.Show();
            metroButton3.Show();
            metroLabel2.Show();
            metroTrackBar1.Show();
            metroCheckBox1.Show();
            metroCheckBox2.Show();
            pictureBox2.Show();
            //pictureBox11.Show();
            randomda.Show();          
            alwayswin.Show();
            autoduel.Show();
            metroCheckBox8.Show();
            pictureBox3.Show();
            metroCheckBox9.Show();
            pictureBox10.Show();
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            Panel1.Hide();
            Panel2.Hide();
            Panel3.Hide();
            Panel4.Hide();
            Panel5.Hide();
            Panel6.Hide();
            Panel7.Hide();
            Panel8.Hide();
            Panel9.Show();
            resetsettings.Hide();
            metroButton1.Hide();
            metroButton2.Hide();
            metroButton3.Hide();
            metroLabel2.Hide();
            metroTrackBar1.Hide();
            metroCheckBox1.Hide();
            metroCheckBox2.Hide();
            pictureBox2.Hide();
            //pictureBox11.Hide();
            randomda.Hide();
            alwayswin.Hide();
            autoduel.Hide();
            metroCheckBox8.Hide();
            pictureBox3.Hide();
            metroCheckBox9.Hide();
            pictureBox10.Hide();
        }

        ///======================================================
        ///                 WEBSITE CLICKS
        ///======================================================
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("http://duel.ninjin.eu");
        }
        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://ninjin.eu/forum/showthread.php?tid=2");
        }
        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.duel.ninjin.eu/changelog");
        }
        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("http://duel.ninjin.eu");
        }

        ///======================================================
        ///                 CARD SEARCH
        ///======================================================
        private void bunifuFlatButton9_Click(object sender, EventArgs e) // Card Search
        {
            var myForm = new cards();
            myForm.Show();
        }

        ///======================================================
        ///                      ONTOP
        ///======================================================
        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e) // OnTop
        {
            if (((CheckBox)sender).Checked)
            {
                TopMost = true;
            }
            else
            {
                TopMost = false;
            }
        }

        ///======================================================
        ///                     OPPACITY
        ///======================================================
        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e) // Set Oppacity
        {
            this.Opacity = (double)metroTrackBar1.Value / 100;
        }

        ///======================================================
        ///                EXIT + MINIMIZE
        ///======================================================
        private void bunifuImageButton1_Click(object sender, EventArgs e) // Exit Application
        {
            Application.ExitThread();
            Application.Exit();
   
        }
        private void bunifuImageButton2_Click_1(object sender, EventArgs e) // Minimize
        {
            this.WindowState = FormWindowState.Minimized;
        }

        ///======================================================
        ///            START DUEL LINKS + SPEEDHACK
        ///======================================================
        private void metroButton3_Click(object sender, EventArgs e) // Start Speedhack and Duel Links
        {

            Process.Start("steam://rungameid/601510");
            Process[] prs = Process.GetProcesses();


            foreach (Process pr in prs)
            {
                if (pr.ProcessName == "A3E5")
                {

                    pr.Kill();

                }
                if (pr.ProcessName == "dlpc")
                {

                    pr.Kill();

                }

            }
            Thread.Sleep(100);
            string[] t = Directory.GetFiles(Environment.CurrentDirectory, "A3E5.exe");
            Array.ForEach(t, File.Delete);
            Thread.Sleep(100);
            string tempExeName = Path.Combine(Directory.GetCurrentDirectory(), "A3E5.exe");
            using (FileStream fsDst = new FileStream(tempExeName, FileMode.CreateNew, FileAccess.Write))
            {
                byte[] bytes = Resources.GetSubExe();
                fsDst.Write(bytes, 0, bytes.Length);
            }
            Info.Arguments = "/C rd /s /q \"C:\\MyFolder";
            Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.CreateNoWindow = true;
            Info.FileName = "A3E5.exe";
            Process.Start(Info);
        }

        ///======================================================
        ///                 ATTACH GAME
        ///======================================================
        private void metroButton1_Click(object sender, EventArgs e) // Attach Trainer to the Game
        {
          
            int pID = m.getProcIDFromName("dlpc");
            bool openProc = false; // is process open?
            if (pID != 0) // Attach Game
            {

                openProc = m.OpenProcess("dlpc");
                if (backgroundWorker2.IsBusy == false)
                    backgroundWorker2.RunWorkerAsync();

                if (backgroundWorker4.IsBusy == false)
                    backgroundWorker4.RunWorkerAsync();
                MessageBox.Show("Attached to Duel Links");
            }
            else
            {
                MessageBox.Show("Duel Links is not running!");
            }
        }

        ///======================================================
        ///          CHECK IF GAME IS OPEN > DO WORK
        ///======================================================
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) // Check if Game is Open or not
        {
            int pID = m.getProcIDFromName("dlpc");
            bool openProc = false; // is process open?
            if (pID != 0)
            {
                openProc = m.OpenProcess("dlpc");

            }
        }

        ///======================================================
        ///                 REVEAL CARDS
        ///======================================================
        //private async void metroCheckBox2_CheckedChanged(object sender, EventArgs e) // Enable Reveal Cards
        //{

        //    //if (metroCheckBox2.Checked)
        //    //{
        //    //    //Reveal Cards
        //    //    await Task.Run(async () =>
        //    //    {
        //    //        long aobscanaddr = m.AoBScan("0x0000000", 0xFFFFFFFFFF, "17 00 89 48 28 C3 CC").Result;
        //    //        // aobscanaddr = m.AoBScan("0x5000000", 0x14000000, "7E ?? ?? ?? ?? 3A ?? ?? ?? ?? 16 2A 28 ?? ?? ?? ?? 39 ?? ?? ?? ?? 02 03 04 28 ?? ?? ?? ?? 16 FE 02 2A 02 03 04 28 ?? ?? ?? ?? 2A 9A 7E").Result;
        //    //        //if (aobscanaddr > 0) // 
        //    //        //{
        //    //        //    m.writeMemory(aobscanaddr.ToString("x4"), "bytes", "17 00 E9 B4 AF 1E 00");

        //    //        //}
        //    //        MessageBox.Show("Found:" + aobscanaddr.ToString("x4"));
        //    //    });
        //    //    metroCheckBox2.Enabled = false;
        //    //}
        //}


        ///======================================================
        ///                 Skip Duel
        ///======================================================
        private async void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked)
            {
                long aobscanaddr = (await m.AoBScan("CB E8 72 04 00 00 E9")).FirstOrDefault();
                if (aobscanaddr > 0)
                    {
                        m.writeMemory(aobscanaddr.ToString("x4"), "bytes", "CB E8 82 FC FF FF E9");
                    }
                else
                {
                   MessageBox.Show("Skip Duel was already activated before or not found.\nMake sure Multitool isn't running in TaskManager under Background-Processes.\nRe-check the Checkbox twice, if it still doesnt work, contact the Admin.\n\nIf Checkbox has Green Background = Activ!\n\nIf Checkbox has no Background = Inactiv!\n");
                }

                long aobscanaddr2 = (await m.AoBScan("CB E8 82 FC FF FF E9")).FirstOrDefault();
                if (aobscanaddr2 > 0)
                {
                    var colorss = Color.FromArgb(100, Color.LimeGreen);
                    metroCheckBox2.BackColor = colorss;
                }    
            }
            else
            {       
                long aobscanaddr3 = (await m.AoBScan("CB E8 82 FC FF FF E9")).FirstOrDefault();
                if (aobscanaddr3 > 0)
                {
                    m.writeMemory(aobscanaddr3.ToString("x4"), "bytes", "CB E8 72 04 00 00 E9");
                }
                else
                {

                }

                long aobscanaddr4 = (await m.AoBScan("CB E8 72 04 00 00 E9")).FirstOrDefault();
                if (aobscanaddr4 > 0)
                {
                    var colors = Color.FromArgb(0, Color.Blue);
                    metroCheckBox2.BackColor = colors;

                }
            }
        }


        ///======================================================
        ///                 Reveal Card's PVE + PVP Duel
        ///======================================================
        ///
        private async void metroCheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            //PVE PART
            if (metroCheckBox9.Checked)
            {
                long aobscanaddr6 = (await m.AoBScan("24 20 E8 19 AD FF FF 85 C0 0F 9F")).FirstOrDefault();
                if (aobscanaddr6 > 0)
                {
                    m.writeMemory(aobscanaddr6.ToString("x4"), "bytes", "24 20 B8 01 00 00 00 85 C0 0F 9F");
                }
                else
                {
                //    MessageBox.Show("Skip Duel was already activated before or not found.\nMake sure Multitool isn't running in TaskManager under Background-Processes.\nRe-check the Checkbox twice, if it still doesnt work, contact the Admin.\n\nIf Checkbox has Green Background = Activ!\n\nIf Checkbox has no Background = Inactiv!\n");
                }

                long aobscanaddr7 = (await m.AoBScan("24 20 B8 01 00 00 00 85 C0 0F 9F")).FirstOrDefault();
                if (aobscanaddr7 > 0)
                {
                    var colorss = Color.FromArgb(100, Color.LimeGreen);
                    metroCheckBox9.BackColor = colorss;
                }
            }
            else
            {
                long aobscanaddr8 = (await m.AoBScan("24 20 B8 01 00 00 00 85 C0 0F 9F")).FirstOrDefault();
                if (aobscanaddr8 > 0)
                {
                    m.writeMemory(aobscanaddr8.ToString("x4"), "bytes", "24 20 E8 19 AD FF FF 85 C0 0F 9F");
                }
                else
                {

                }

                long aobscanaddr9 = (await m.AoBScan("24 20 E8 19 AD FF FF 85 C0 0F 9F")).FirstOrDefault();
                if (aobscanaddr9 > 0)
                {
                    var colors = Color.FromArgb(0, Color.Blue);
                    metroCheckBox9.BackColor = colors;

                }
            }
            //PVE PART END




            //PVP PART
            if (metroCheckBox9.Checked)
            {
                long aobscanaddr6 = (await m.AoBScan("24 20 E8 4B 6F 00 00 48 8B 5C 24 40")).FirstOrDefault();
                if (aobscanaddr6 > 0)
                {
                    m.writeMemory(aobscanaddr6.ToString("x4"), "bytes", "24 20 B8 01 00 00 00 48 8B 5C 24 40");
                }
                else
                {
                 //   MessageBox.Show("Skip Duel was already activated before or not found.\nMake sure Multitool isn't running in TaskManager under Background-Processes.\nRe-check the Checkbox twice, if it still doesnt work, contact the Admin.\n\nIf Checkbox has Green Background = Activ!\n\nIf Checkbox has no Background = Inactiv!\n");
                }

                long aobscanaddr7 = (await m.AoBScan("24 20 B8 01 00 00 00 48 8B 5C 24 40")).FirstOrDefault();
                if (aobscanaddr7 > 0)
                {
                    var colorss = Color.FromArgb(100, Color.LimeGreen);
                    metroCheckBox9.BackColor = colorss;
                }
            }
            else
            {
                long aobscanaddr8 = (await m.AoBScan("24 20 B8 01 00 00 00 48 8B 5C 24 40")).FirstOrDefault();
                if (aobscanaddr8 > 0)
                {
                    m.writeMemory(aobscanaddr8.ToString("x4"), "bytes", "24 20 E8 4B 6F 00 00 48 8B 5C 24 40");
                }
                else
                {

                }

                long aobscanaddr9 = (await m.AoBScan("24 20 E8 4B 6F 00 00 48 8B 5C 24 40")).FirstOrDefault();
                if (aobscanaddr9 > 0)
                {
                    var colors = Color.FromArgb(0, Color.Blue);
                    metroCheckBox9.BackColor = colors;

                }
            }
            //PVP PART END


































































        }























        ///======================================================
        ///      ENABLE LP + RECOVERY CHECKBOX RESETS
        ///======================================================
        private void sumBox_CheckStateChanged(object sender, EventArgs e) // Enable Life + Recovery CheckBoxes
        {
            if (disablexor.Checked) // XOR 
            {
                enemybox.Enabled = true;
                mylpbox.Enabled = true;
                RecoverLpBox.Enabled = true;
            }
            else
            {
                enemybox.Checked = false;
                mylpbox.Checked = false;
                RecoverLpBox.Checked = false;
                enemybox.Enabled = false;
                mylpbox.Enabled = false;
                RecoverLpBox.Enabled = false;
            }
        }




        ///======================================================
        ///                DO WORK (EDIT MEMORY)
        ///======================================================
        ///

         private void backgroundWorker4_DoWork_1(object sender, DoWorkEventArgs e)
        {
            
            while (true) // Loop
            {
                var duelchecks = m.readInt("GameAssembly.dll+0194D620, 0xB8, 0x0, 0xC0,0x160, 0x28");

                if (openProc = true) // If process is open do code.
                {
                    if (alwayswin.Checked)
                    {
                        //m.writeMemory("duel.dll+850408, 0x28", "byte", "0"); // Always First
                        //m.writeMemory("duel.dll+850408, 0x2CC", "byte", "0"); // Always First
                        //m.writeMemory("duel.dll+850408, 0x4A4", "byte", "0"); // Always First
                        m.writeMemory("duel.dll+850408, 0x330", "byte", "1"); // Get DuelResult
                        m.writeMemory("duel.dll+850408, 0x334", "byte", "1"); // Get Duel Finish                           
                    }
                                       
                    if (metroCheckBox8.Checked)
                    {
                        if (duelchecks > 0)
                        {
                            m.writeMemory("duel.dll+850418, 0xE18", "bytes", "1");
                        }
                    }



                }
                Thread.Sleep(5);
            }
        }



        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

            
            Random r = new Random();
            while (true) // Loop
            {
                  var duelcheck = m.readInt("GameAssembly.dll+0194D620, 0xB8, 0x0, 0xC0,0x160, 0x28");
               // var duelcheck = m.readInt("GameAssembly.dll+01833F58, 0x4A0, 0xB8, 0x60,0x80, 0x0");
                // var duelcheck = m.readInt("GameAssembly.dll+019323C8, 0xB8, 0x60, 0x10, 0x28, 0x1B0");

                if (openProc = true) // If process is open do code.
                {
    

                    ///======================================================
                    ///                 LIFE + RECOVERY
                    ///======================================================
                    if (disablexor.Checked) // XOR  (ENCRYPTION FOR LP STUFF)
                    {
                        var xored = m.readInt("GameAssembly.dll+019323C8, 0xB8, 0x60, 0x10, 0x28, 0x1B0");
                        if (duelcheck > 0)
                        {
                            m.writeMemory("duel.dll+850408, 0x0", "int", "0");
                        }
                    }
                    
                    if (autoduel.Checked)
                    {
                        m.writeMemory("GameAssembly.dll+0195D4A0, 0xB8, 0x60, 0x10, 0x28, 0x1A8", "byte", "1");
                    }
                    else
                    {
                        m.writeMemory("GameAssembly.dll+0195D4A0, 0xB8, 0x60, 0x10, 0x28, 0x1A8", "byte", "0");
                    }

      
                          


                    if (enemybox.Checked) // Enemy LP
                    {                  
                            if (!String.IsNullOrEmpty(enemylp.Text.ToString()))
                            if (Convert.ToInt32(enemylp.Text.ToString()) > -1)
                                if (duelcheck > 0)
                                {
                                    m.writeMemory("duel.dll+850418, 0xD90", "int", enemylp.Text.ToString());
                                }
                    }



                    if (mylpbox.Checked) // My LP 
                    {
                        Random rs = new Random();
                        if (!String.IsNullOrEmpty(mylpmin.ToString()))
                        if (!String.IsNullOrEmpty(mylpmax.ToString()))
                        {
                            if (randomda.Checked)
                            {
                                if (String.IsNullOrEmpty(mylpmin.Text.ToString()))
                                {
                                    MessageBox.Show("Fill My LP: >From< TextBox and press the Button >Attach Game<!");
                                }
                                else if (String.IsNullOrEmpty(mylpmax.Text.ToString()))
                                {
                                    MessageBox.Show("Fill My LP: >TO< TextBox and press the Button >Attach Game<!");
                                }
                                else if (String.IsNullOrEmpty(mylp.Text.ToString()))
                                {
                                    MessageBox.Show("Fill My LP: >Result< TextBox and press the Button >Attach Game<!");
                                }

                                var mylpsmi = Convert.ToInt32(mylpmin.Text);
                                var mylpsma = Convert.ToInt32(mylpmax.Text);
                                if (duelcheck > 0 && mylpsmi > mylpsma)
                                {
                                    MessageBox.Show("My LP: <FROM> Value, cant be bigger than <TO> Value.\nChange it and press <Attach Game Button>!");
                                }
                                else
                                {
                                    int multiplesOf = 50;
                                    int rand = r.Next(mylpsmi / multiplesOf, (mylpsma + multiplesOf) / multiplesOf) * multiplesOf;

                                    if (duelcheck > 0)
                                    {
                                        m.writeMemory("duel.dll+850418, 0x0", "int", rand.ToString());
                                    }
                                }
                            }
                            else
                            {
                                if (mylpbox.Checked)
                                {

                                    if (!String.IsNullOrEmpty(mylp.Text.ToString()))
                                        if (Convert.ToInt32(mylp.Text.ToString()) > -1)
                                            if (duelcheck > 0)
                                            {
                                                m.writeMemory("duel.dll+850418, 0x0", "int", mylp.Text.ToString());
                                            }
                                }
                            }
                        }
                    }

     

                    if (RecoverLpBox.Checked) // Recover LP
                    {
              
                        if (duelcheck > 0)
                        {
                            m.writeMemory("duel.dll+8503C8, 0xA4", "int", recoverlp.Text.ToString());
                        }                                     
                        
                    }

                    


                    ///======================================================
                    ///                     DECK + HAND
                    ///======================================================
                    if (mydeckbox.Checked) // My Deck
                    {
                                        
                        if (!String.IsNullOrEmpty(mydeck.Text.ToString()))
                            if (Convert.ToInt32(mydeck.Text.ToString()) > -1)
                                if (duelcheck > 0)
                                {
                                    m.writeMemory("duel.dll+850418, 0x10", "int", mydeck.Text.ToString());
                                }
                    }

                    if (myhandbox.Checked) // My Hand
                    {
                                             
                        if (!String.IsNullOrEmpty(myhand.Text.ToString()))
                            if (duelcheck > 0)
                            {
                                m.writeMemory("duel.dll+850418, 0x0C", "int", myhand.Text.ToString());
                            }
                    }

                    if (enemydeckbox.Checked) // Enemy Deck
                    {
                               
                        if (!String.IsNullOrEmpty(enemydeck.Text.ToString()))
                            if (Convert.ToInt32(enemydeck.Text.ToString()) > -1)
                                if (duelcheck > 0)
                                {

                                    m.writeMemory("duel.dll+850418, 0xDA0", "int", enemydeck.Text.ToString());
                                }

                    }

                    if (enemyhandbox.Checked) // Enemy Hand
                    {
                    
                        if (!String.IsNullOrEmpty(enemyhand.Text.ToString()))
                            if (Convert.ToInt32(enemyhand.Text.ToString()) > -1)
                                if (duelcheck > 0)
                                {
                                    m.writeMemory("duel.dll+850418, 0xD9C", "int", enemyhand.Text.ToString());
                                }
                    }

                    ///======================================================
                    ///                     DAMAGE
                    ///======================================================
                    if (edBox.Checked) // Effect Damage
                    {

                        if (randomda.Checked)
                        {
                            if (String.IsNullOrEmpty(efdbdmmin.Text.ToString()))
                            {
                                MessageBox.Show("Fill Effect Damage: >From< TextBox and press the Button >Attach Game<!");
                            }
                            else if (String.IsNullOrEmpty(efdbdmmax.Text.ToString()))
                            {
                                MessageBox.Show("Fill Effect Damage: >TO< TextBox and press the Button >Attach Game<!");
                            }

                            int efdbdmminn = Convert.ToInt32(efdbdmmin.Text);
                            int efdbdmmaxx = Convert.ToInt32(efdbdmmax.Text);
                            if (efdbdmminn > efdbdmmaxx)
                            {
                                MessageBox.Show("Effect Damage: <FROM> Value, cant be bigger than <TO> Value.\nChange it and press <Attach Game Button>!");
                            }
                            else
                            {
                                int multiplesOfeffectdamagevalue = 50;
                                int effectdamagevaluerand = r.Next(efdbdmminn / multiplesOfeffectdamagevalue, (efdbdmmaxx + multiplesOfeffectdamagevalue) / multiplesOfeffectdamagevalue) * multiplesOfeffectdamagevalue;
                                if (!String.IsNullOrEmpty(efdbdmmin.Text.ToString()))
                                    if (!String.IsNullOrEmpty(efdbdmmax.Text.ToString()))
                                        if (edBox.Checked)                                       
                                       {
                                            if (duelcheck > 0)
                                            {
                                                m.writeMemory("duel.dll+8503C8, 0x88", "int", effectdamagevaluerand.ToString()); // Effect Damage Mission  
                                                m.writeMemory("duel.dll+8503C8, 0xDC", "int", effectdamagevaluerand.ToString()); // Effect Damage
                                            }
                                  
                                       }
                            }
                        }
                        else
                        {
                            if (edBox.Checked)
                            {
                                if (!String.IsNullOrEmpty(effectdamagevalue.Text.ToString()))
                                    if (Convert.ToInt32(effectdamagevalue.Text.ToString()) > -1)
                                    if (duelcheck > 0)
                                    {
                                        m.writeMemory("duel.dll+8503C8, 0x88", "int", effectdamagevalue.Text.ToString()); // Effect Damage Mission  
                                        m.writeMemory("duel.dll+8503C8, 0xDC", "int", effectdamagevalue.Text.ToString()); // Effect Damage
                                    }

                            }
                        }
                    }

                    if (maxbdbox.Checked)// Battle Damage
                    {

                        if (randomda.Checked)
                        {
                            if (String.IsNullOrEmpty(mbdmin.Text.ToString()))
                            {
                                MessageBox.Show("Fill Battle Damage: >From< TextBox and press the Button >Attach Game<!");
                            }
                            else if (String.IsNullOrEmpty(mbdmax.Text.ToString()))
                            {
                                MessageBox.Show("Fill Battle Damage: >TO< TextBox and press the Button >Attach Game<!");
                            }

                            int mbdminn = Convert.ToInt32(mbdmin.Text);
                            int mbdmaxx = Convert.ToInt32(mbdmax.Text);

                            if (mbdminn > mbdmaxx)
                            {
                                MessageBox.Show("Battle Damage: <FROM> Value, cant be bigger than <TO> Value.\nChange it and press <Attach Game Button>!");
                            }
                            else
                            {
                                int multiplesOfeffectdamagevalue = 50;
                                int mbdmaxxx = r.Next(mbdminn / multiplesOfeffectdamagevalue, (mbdmaxx + multiplesOfeffectdamagevalue) / multiplesOfeffectdamagevalue) * multiplesOfeffectdamagevalue;
                                if (!String.IsNullOrEmpty(mbdmin.Text.ToString()))
                                    if (!String.IsNullOrEmpty(mbdmax.Text.ToString()))
                                    if (maxbdbox.Checked)
                                    {
                                        if (duelcheck > 0)
                                        {
                                            m.writeMemory("duel.dll+8503C8, 0xDE", "2bytes", mbdmaxxx.ToString()); //Max Battle Damage 
                                            m.writeMemory("duel.dll+8503C8, 0x8C", "2bytes", mbdmaxxx.ToString());  // Battle Damage Mission  
                                        }
                                    }
                            }
                       
                        }
                        else
                        {
                            if (maxbdbox.Checked)

                                if (!String.IsNullOrEmpty(battledama.Text.ToString()))
                                if (Convert.ToInt32(battledama.Text.ToString()) > -1)
                                if (duelcheck > 0)
                                {
                                    m.writeMemory("duel.dll+8503C8, 0xDE", "2bytes", battledama.Text.ToString()); //Max Battle Damage 
                                    m.writeMemory("duel.dll+8503C8, 0x8C", "2bytes", battledama.Text.ToString());  // Battle Damage Mission  
                                }


                        }
                    }

                    if (attacksmbox.Checked) // Attacks Made
                    {

                        if (randomda.Checked)
                        {
                            if (String.IsNullOrEmpty(attacksmademin.Text.ToString()))
                            {
                                MessageBox.Show("Fill Attacks Made: >From< TextBox and press the Button >Attach Game<!");
                            }
                            else if (String.IsNullOrEmpty(attacksmademax.Text.ToString()))
                            {
                                MessageBox.Show("Fill Attacks Made: >TO< TextBox and press the Button >Attach Game<!");
                            }
                            int attacksmademinn = Convert.ToInt32(attacksmademin.Text);
                            int attacksmademaxx = Convert.ToInt32(attacksmademax.Text);
                            if (attacksmademinn > attacksmademaxx)
                            {
                                MessageBox.Show("My LP: <FROM> Value, cant be bigger than <TO> Value.\nChange it and press <Attach Game Button>!");
                            }
                            else
                            {
                                int attacksmademaxxa = r.Next(attacksmademinn, attacksmademaxx);
                                if (!String.IsNullOrEmpty(attacksmademin.Text.ToString()))
                                    if (!String.IsNullOrEmpty(attacksmademax.Text.ToString()))
                                        if (attacksmbox.Checked)
                                        {
                                            if (duelcheck > 0) { }
                                            {
                                                m.writeMemory("duel.dll+8503C8, 0xE6", "2bytes", attacksmademaxxa.ToString()); // Attacks Made
                                                m.writeMemory("duel.dll+8503C8, 0xee", "2bytes", attacksmademaxxa.ToString()); // Monster Destroyed  
                                            }
                                        }
                            }
                        }
                        else
                        {
                            if (attacksmbox.Checked)
                            {
                                if (!String.IsNullOrEmpty(attacksm.Text.ToString()))
                                    if (Convert.ToInt32(attacksm.Text.ToString()) > -1)
                                        if (duelcheck > 0)
                                        {                                            
                                                m.writeMemory("duel.dll+8503C8, 0xE6", "2bytes", attacksm.Text.ToString()); // Attacks Made
                                                m.writeMemory("duel.dll+8503C8, 0xee", "2bytes", attacksm.Text.ToString()); // Monster Destroyed                                    
                                   
                                        }
                     
                            }
                        }
                    }

                    ///======================================================
                    ///                     SUMMONS
                    ///======================================================                    
                    if (nsBox.Checked) // Normal Summon
                    {

                        if (randomda.Checked)
                        {
                            if (String.IsNullOrEmpty(normalsummonmin.Text.ToString()))
                            {
                                MessageBox.Show("Fill Normal Summon: >From< TextBox and press the Button >Attach Game<!");
                            }
                            else if (String.IsNullOrEmpty(normalsummonmax.Text.ToString()))
                            {
                                MessageBox.Show("Fill Normal Summon: >TO< TextBox and press the Button >Attach Game<!");
                            }
                            int normalsummonmins = Convert.ToInt32(normalsummonmin.Text);
                            int normalsummonmaxx = Convert.ToInt32(normalsummonmax.Text);
                            if (normalsummonmins > normalsummonmaxx)
                            {
                                MessageBox.Show("Normal Summon: <FROM> Value, cant be bigger than <TO> Value.\nChange it and press <Attach Game Button>!");
                            }
                            else
                            {
                                int normalsummonmina = r.Next(normalsummonmins, normalsummonmaxx);
                                if (!String.IsNullOrEmpty(normalsummonmin.Text.ToString()))
                                    if (!String.IsNullOrEmpty(normalsummonmax.Text.ToString()))
                                    {
                                        if (duelcheck > 0)
                                        {
                                            m.writeMemory("duel.dll+8503C8, 0xF6", "2bytes", normalsummonmina.ToString());
                                        }
                                    }
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(normalsummon.Text.ToString()))
                                if (Convert.ToInt32(normalsummon.Text.ToString()) > -1)
                                    if (duelcheck > 0)
                                {
                                    m.writeMemory("duel.dll+8503C8, 0xF6", "2bytes", normalsummon.Text.ToString());
                                }
                        }
                    }

                    if (tsBox.Checked)  // Tribute Summon  
                    {

                        if (randomda.Checked)
                        {
                            if (String.IsNullOrEmpty(tributemin.Text.ToString()))
                            {
                                MessageBox.Show("Fill Tribute Summon: >From< TextBox and press the Button >Attach Game<!");
                            }
                            else if (String.IsNullOrEmpty(tributemax.Text.ToString()))
                            {
                                MessageBox.Show("Fill Tribute Summon: >TO< TextBox and press the Button >Attach Game<!");
                            }
                            int tributemins = Convert.ToInt32(tributemin.Text);
                            int tributemaxx = Convert.ToInt32(tributemax.Text);

                            if (tributemins > tributemaxx)
                            {
                                MessageBox.Show("Tribute Summon: <FROM> Value, cant be bigger than <TO> Value.\nChange it and press <Attach Game Button>!");
                            }
                            else
                            {
                                int tributemina = r.Next(tributemins, tributemaxx);
                                if (!String.IsNullOrEmpty(tributemin.Text.ToString()))
                                    if (!String.IsNullOrEmpty(tributemax.Text.ToString()))
                                    {
                                        if (duelcheck > 0)
                                        {
                                            m.writeMemory("duel.dll+8503C8, 0xFE", "2bytes", tributemina.ToString());
                                        }
                                    }
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(tributesummon.Text.ToString()))
                                if (Convert.ToInt32(tributesummon.Text.ToString()) > -1)
                                if (duelcheck > 0)
                                {
                                    m.writeMemory("duel.dll+8503C8, 0xFE", "2bytes", tributesummon.Text.ToString());
                                }
                        }
                    }

                    if (ssBox.Checked) // Special Summon   
                    {

                        if (randomda.Checked)
                        {
                            if (String.IsNullOrEmpty(specialmin.Text.ToString()))
                            {
                                MessageBox.Show("Fill Special Summon: >From< TextBox and press the Button >Attach Game<!");
                            }
                            else if (String.IsNullOrEmpty(specialmax.Text.ToString()))
                            {
                                MessageBox.Show("Fill Special Summon: >TO< TextBox and press the Button >Attach Game<!");
                            }
                            int specialmins = Convert.ToInt32(specialmin.Text);
                            int specialmaxx = Convert.ToInt32(specialmax.Text);
                            if (specialmins > specialmaxx)
                            {
                                MessageBox.Show("Special Summon: <FROM> Value, cant be bigger than <TO> Value.\nChange it and press <Attach Game Button>!");
                            }
                            else
                            {
                                int specialminsa = r.Next(specialmins, specialmaxx);
                                if (!String.IsNullOrEmpty(specialmin.Text.ToString()))
                                    if (!String.IsNullOrEmpty(specialmax.Text.ToString()))
                                    {
                                        if (duelcheck > 0)
                                        {
                                            m.writeMemory("duel.dll+8503C8, 0x100", "2bytes", specialminsa.ToString());
                                        }
                                    }
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(specialsummon.Text.ToString()))
                                if (Convert.ToInt32(specialsummon.Text.ToString()) > -1)
                                    if (duelcheck > 0)
                                    {
                                    m.writeMemory("duel.dll+8503C8, 0x100", "2bytes", specialsummon.Text.ToString());
                                }
                        }
                    }

                    if (fsBox.Checked) // Fusion Summon 
                    {

                        if (randomda.Checked)
                        {
                            if (String.IsNullOrEmpty(fusionmin.Text.ToString()))
                            {
                                MessageBox.Show("Fill Fusion Summon: >From< TextBox and press the Button >Attach Game<!");
                            }
                            else if (String.IsNullOrEmpty(fusionmax.Text.ToString()))
                            {
                                MessageBox.Show("Fill Fusion Summon: >TO< TextBox and press the Button >Attach Game<!");
                            }
                            int fusionmins = Convert.ToInt32(fusionmin.Text);
                            int fusionmaxx = Convert.ToInt32(fusionmax.Text);
                            if (fusionmins > fusionmaxx)
                            {
                                MessageBox.Show("Fusion Summon: <FROM> Value, cant be bigger than <TO> Value.\nChange it and press <Attach Game Button>!");
                            }
                            else
                            {
                                int fusionminsa = r.Next(fusionmins, fusionmaxx);
                                if (!String.IsNullOrEmpty(fusionmin.Text.ToString()))
                                    if (!String.IsNullOrEmpty(fusionmax.Text.ToString()))
                                    {
                                        if (duelcheck > 0)
                                        {
                                            m.writeMemory("duel.dll+8503C8, 0x120", "2bytes", fusionminsa.ToString());
                                        }
                                    }
                            }

                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(fusionsummon.Text.ToString()))
                                if (Convert.ToInt32(fusionsummon.Text.ToString()) > -1)
                                if (duelcheck > 0)
                                {
                                    m.writeMemory("duel.dll+8503C8, 0x120", "2bytes", fusionsummon.Text.ToString());
                                }
                        }
                    }

                    if (rsBox.Checked) // Ritual Summon
                    {

                        if (randomda.Checked)
                        {
                            if (String.IsNullOrEmpty(ritualmin.Text.ToString()))
                            {
                                MessageBox.Show("Fill Ritual Summon: >From< TextBox and press the Button >Attach Game<!");
                            }
                            else if (String.IsNullOrEmpty(ritualmax.Text.ToString()))
                            {
                                MessageBox.Show("Fill Ritual Summon: >TO< TextBox and press the Button >Attach Game<!");
                            }
                            int ritualmins = Convert.ToInt32(ritualmin.Text);
                            int ritualmaxx = Convert.ToInt32(ritualmax.Text);
                            if (ritualmins > ritualmaxx)
                            {
                                MessageBox.Show("Ritual Summon: <FROM> Value, cant be bigger than <TO> Value.\nChange it and press <Attach Game Button>!");
                            }
                            else
                            {
                                int ritualmina = r.Next(ritualmins, ritualmaxx);
                                if (!String.IsNullOrEmpty(ritualmin.Text.ToString()))
                                    if (!String.IsNullOrEmpty(ritualmax.Text.ToString()))
                                    {
                                        if (duelcheck > 0)
                                        {
                                            m.writeMemory("duel.dll+8503C8, 0x122", "2bytes", ritualmina.ToString());
                                        }
                                    }
                            }

                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(ritualsummon.Text.ToString()))
                                if (Convert.ToInt32(ritualsummon.Text.ToString()) > -1)
                                    if (duelcheck > 0)
                                    {

                                    m.writeMemory("duel.dll+8503C8, 0x122", "2bytes", ritualsummon.Text.ToString());
                                }
                        }
                    }
                      
                    if (syncros.Checked) // Syncros Summon 
                    {

                        if (randomda.Checked)
                        {
                            if (String.IsNullOrEmpty(syncrosmin.Text.ToString()))
                            {
                                MessageBox.Show("Fill Syncro Summon: >From< TextBox and press the Button >Attach Game<!");
                            }
                            else if (String.IsNullOrEmpty(syncrosmax.Text.ToString()))
                            {
                                MessageBox.Show("Fill Syncro Summon: >TO< TextBox and press the Button >Attach Game<!");
                            }
                            int syncromins = Convert.ToInt32(syncrosmin.Text);
                            int syncromaxx = Convert.ToInt32(syncrosmax.Text);
                            if (syncromins > syncromaxx)
                            {
                                MessageBox.Show("Syncro Summon: <FROM> Value, cant be bigger than <TO> Value.\nChange it and press <Attach Game Button>!");
                            }
                            else
                            {
                                int syncrosmina = r.Next(syncromins, syncromaxx);
                                if (!String.IsNullOrEmpty(syncrosmin.Text.ToString()))
                                    if (!String.IsNullOrEmpty(syncrosmax.Text.ToString()))
                                    {
                                        if (duelcheck > 0)
                                        {
                                            m.writeMemory("duel.dll+8503C8, 0x124", "2bytes", syncrosmina.ToString());
                                        }
                                    }
                            }

                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(syncrosresult.Text.ToString()))
                                if (Convert.ToInt32(syncrosresult.Text.ToString()) > -1)
                                    if (duelcheck > 0)
                                    {
                                    m.writeMemory("duel.dll+8503C8, 0x124", "2bytes", syncrosresult.Text.ToString());
                                }
                        }
                    }
                                                                                                                       
                    ///======================================================
                    ///                    SPELLS
                    ///======================================================   
                    if (asBox.Checked) // Activated Spell
                    {

                        if (randomda.Checked)
                        {
                            if (String.IsNullOrEmpty(activatespellmin.Text.ToString()))
                            {
                                MessageBox.Show("Fill Activate Spell: >From< TextBox and press the Button >Attach Game<!");
                            }
                            else if (String.IsNullOrEmpty(activatespellmax.Text.ToString()))
                            {
                                MessageBox.Show("Fill Activate Spell: >TO< TextBox and press the Button >Attach Game<!");
                            }
                            int activatespellmins = Convert.ToInt32(activatespellmin.Text);
                            int activatespellmaxx = Convert.ToInt32(activatespellmax.Text);
                            if (activatespellmins > activatespellmaxx)
                            {
                                MessageBox.Show("Activated Spell: <FROM> Value, cant be bigger than <TO> Value.\nChange it and press <Attach Game Button>!");
                            }
                            else
                            {
                                int activatedspells = r.Next(activatespellmins, activatespellmaxx);
                                if (!String.IsNullOrEmpty(activatespellmin.Text.ToString()))
                                    if (!String.IsNullOrEmpty(activatespellmax.Text.ToString()))
                                    {
                                        if (duelcheck > 0)
                                        {
                                            m.writeMemory("duel.dll+8503C8, 0x10A", "2bytes", activatedspells.ToString());
                                        }
                                    }
                            }

                        }
                        else
                        {
                            if (asBox.Checked)
                            {
                                if (!String.IsNullOrEmpty(activatedspell.Text.ToString()))
                                    if (Convert.ToInt32(activatedspell.Text.ToString()) > -1)
                                        if (duelcheck > 0)
                                        {
                                        m.writeMemory("duel.dll+8503C8, 0x10A", "2bytes", activatedspell.Text.ToString());
                                    }
                            }
                        }
                    }

                    if (csBox.Checked) // Continspells
                    {

                        if (randomda.Checked)
                        {
                            if (String.IsNullOrEmpty(continspellsmin.Text.ToString()))
                            {
                                MessageBox.Show("Fill Continspells: >From< TextBox and press the Button >Attach Game<!");
                            }
                            else if (String.IsNullOrEmpty(continspellsmax.Text.ToString()))
                            {
                                MessageBox.Show("Fill Continspells: >TO< TextBox and press the Button >Attach Game<!");
                            }
                            int continspellsmins = Convert.ToInt32(continspellsmin.Text);
                            int continspellsmaxx = Convert.ToInt32(continspellsmax.Text);
                            if (continspellsmins > continspellsmaxx)
                            {
                                MessageBox.Show("Continspells: <FROM> Value, cant be bigger than <TO> Value.\nChange it and press <Attach Game Button>!");
                            }
                            else
                            {
                                int continspellsa = r.Next(continspellsmins, continspellsmaxx);
                                if (!String.IsNullOrEmpty(continspellsmin.Text.ToString()))
                                    if (!String.IsNullOrEmpty(continspellsmax.Text.ToString()))
                                    {
                                        if (duelcheck > 0)
                                        {
                                            m.writeMemory("duel.dll+8503C8, 0x112", "2bytes", continspellsa.ToString());
                                        }
                                    }
                            }

                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(continspells.Text.ToString()))
                                if (Convert.ToInt32(continspells.Text.ToString()) > -1)
                                    if (duelcheck > 0)
                                    {
                                    m.writeMemory("duel.dll+8503C8, 0x112", "2bytes", continspells.Text.ToString());
                                }
                        }
                    }

                    if (fssBox.Checked) // Field Spells  
                    {

                        if (randomda.Checked)
                        {
                            if (String.IsNullOrEmpty(fieldspellsmin.Text.ToString()))
                            {
                                MessageBox.Show("Fill Field Spells: >From< TextBox and press the Button >Attach Game<!");
                            }
                            else if (String.IsNullOrEmpty(fieldspellsmax.Text.ToString()))
                            {
                                MessageBox.Show("Fill Field Spells: >TO< TextBox and press the Button >Attach Game<!");
                            }
                            int fieldspellsmins = Convert.ToInt32(fieldspellsmin.Text);
                            int fieldspellsmaxx = Convert.ToInt32(fieldspellsmax.Text);
                            if (fieldspellsmins > fieldspellsmaxx)
                            {
                                MessageBox.Show("Field Spells : <FROM> Value, cant be bigger than <TO> Value.\nChange it and press <Attach Game Button>!");
                            }
                            else
                            {
                                int fieldspellsminsa = r.Next(fieldspellsmins, fieldspellsmaxx);
                                if (!String.IsNullOrEmpty(fieldspellsmin.Text.ToString()))
                                    if (!String.IsNullOrEmpty(fieldspellsmax.Text.ToString()))
                                    {
                                        if (duelcheck > 0)
                                        {
                                            m.writeMemory("duel.dll+8503C8, 0x10C", "2bytes", fieldspellsminsa.ToString());
                                        }
                                    }
                            }

                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(fieldspells.Text.ToString()))
                                if (Convert.ToInt32(fieldspells.Text.ToString()) > -1)
                                    if (duelcheck > 0)
                                    {
                                    m.writeMemory("duel.dll+8503C8, 0x10C", "2bytes", fieldspells.Text.ToString());
                                }
                        }
                    }

                    if (eqBox.Checked) // Equip  Spells  
                    {

                        if (randomda.Checked)
                        {
                            if (String.IsNullOrEmpty(equipspellsmin.Text.ToString()))
                            {
                                MessageBox.Show("Fill Equip Spells: >From< TextBox and press the Button >Attach Game<!");
                            }
                            else if (String.IsNullOrEmpty(equipspellsmax.Text.ToString()))
                            {
                                MessageBox.Show("Fill Equip Spells: >TO< TextBox and press the Button >Attach Game<!");
                            }
                            int equipspellsmins = Convert.ToInt32(equipspellsmin.Text);
                            int equipspellsmaxx = Convert.ToInt32(equipspellsmax.Text);
                            if (equipspellsmins > equipspellsmaxx)
                            {
                                MessageBox.Show("Equip  Spells: <FROM> Value, cant be bigger than <TO> Value.\nChange it and press <Attach Game Button>!");
                            }
                            else
                            {
                                int equipspellsminsa = r.Next(equipspellsmins, equipspellsmaxx);
                                if (!String.IsNullOrEmpty(equipspellsmin.Text.ToString()))
                                    if (!String.IsNullOrEmpty(equipspellsmax.Text.ToString()))
                                    {
                                        if (duelcheck > 0)
                                        {
                                            m.writeMemory("duel.dll+8503C8, 0x11E", "2bytes", equipspellsminsa.ToString());
                                        }
                                    }
                            }

                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(equipspells.Text.ToString()))
                                if (Convert.ToInt32(equipspells.Text.ToString()) > -1)
                                    if (duelcheck > 0)
                                    {
                                    m.writeMemory("duel.dll+8503C8, 0x11E", "2bytes", equipspells.Text.ToString());
                                }
                        }
                    }

                    if (qsBox.Checked) // Quick Spells
                    {

                        if (randomda.Checked)
                        {
                            if (String.IsNullOrEmpty(quickspellsmin.Text.ToString()))
                            {
                                MessageBox.Show("Fill Quick Spells: >From< TextBox and press the Button >Attach Game<!");
                            }
                            else if (String.IsNullOrEmpty(quickspellsmax.Text.ToString()))
                            {
                                MessageBox.Show("Fill Quick Spells: >TO< TextBox and press the Button >Attach Game<!");
                            }
                            int quickspellsmins = Convert.ToInt32(quickspellsmin.Text);
                            int quickspellsmaxx = Convert.ToInt32(quickspellsmax.Text);
                            if (quickspellsmins > quickspellsmaxx)
                            {
                                MessageBox.Show("Quick Spells: <FROM> Value, cant be bigger than <TO> Value.\nChange it and press <Attach Game Button>!");
                            }
                            else
                            {
                                int quickspellsminsa = r.Next(quickspellsmins, quickspellsmaxx);
                                if (!String.IsNullOrEmpty(quickspellsmin.Text.ToString()))
                                    if (!String.IsNullOrEmpty(quickspellsmax.Text.ToString()))
                                    {
                                        if (duelcheck > 0)
                                        {
                                            m.writeMemory("duel.dll+8503C8, 0x10E", "2bytes", quickspellsminsa.ToString());
                                        }
                                    }
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(quickspells.Text.ToString()))
                                if (Convert.ToInt32(quickspells.Text.ToString()) > -1)
                                    if (duelcheck > 0)
                                    {
                                    m.writeMemory("duel.dll+8503C8, 0x10E", "2bytes", quickspells.Text.ToString());
                                }
                        }
                    }

                    ///======================================================
                    ///                     TRAPS
                    ///======================================================   
                    if (atBox.Checked) // Activated Trap  
                    {

                        if (randomda.Checked)
                        {
                            if (String.IsNullOrEmpty(activatetrapmin.Text.ToString()))
                            {
                                MessageBox.Show("Fill Activated Trap: >From< TextBox and press the Button >Attach Game<!");
                            }
                            else if (String.IsNullOrEmpty(activatetrapmax.Text.ToString()))
                            {
                                MessageBox.Show("Fill Activated Trap: >TO< TextBox and press the Button >Attach Game<!");
                            }
                            int activatetrapmins = Convert.ToInt32(activatetrapmin.Text);
                            int activatetrapmaxx = Convert.ToInt32(activatetrapmax.Text);
                            if (activatetrapmins > activatetrapmaxx)
                            {
                                MessageBox.Show("Activated Trap: <FROM> Value, cant be bigger than <TO> Value.\nChange it and press <Attach Game Button>!");
                            }
                            else
                            {
                                int activatetrapmina = r.Next(activatetrapmins, activatetrapmaxx);
                                if (!String.IsNullOrEmpty(activatetrapmin.Text.ToString()))
                                    if (!String.IsNullOrEmpty(activatetrapmax.Text.ToString()))
                                    {
                                        if (duelcheck > 0)
                                        {
                                            m.writeMemory("duel.dll+8503C8, 0x118", "2bytes", activatetrapmina.ToString());
                                        }
                                    }
                            }

                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(activatedtraps.Text.ToString()))
                                if (Convert.ToInt32(activatedtraps.Text.ToString()) > -1)
                                    if (duelcheck > 0)
                                    {
                                    m.writeMemory("duel.dll+8503C8, 0x118", "2bytes", activatedtraps.Text.ToString());
                                }
                        }
                    }

                    if (ctBox.Checked) // Counter Traps
                    {

                        if (randomda.Checked)
                        {
                            if (String.IsNullOrEmpty(countertrapsmin.Text.ToString()))
                            {
                                MessageBox.Show("Fill Counter Trap: >From< TextBox and press the Button >Attach Game<!");
                            }
                            else if (String.IsNullOrEmpty(countertrapsmax.Text.ToString()))
                            {
                                MessageBox.Show("Fill Counter Trap: >TO< TextBox and press the Button >Attach Game<!");
                            }
                            int countertrapsmins = Convert.ToInt32(countertrapsmin.Text);
                            int countertrapsmaxx = Convert.ToInt32(countertrapsmax.Text);
                            if (countertrapsmins > countertrapsmaxx)
                            {
                                MessageBox.Show("Counter Traps: <FROM> Value, cant be bigger than <TO> Value.\nChange it and press <Attach Game Button>!");
                            }
                            else
                            {
                                int countertrapsminsa = r.Next(countertrapsmins, countertrapsmaxx);
                                if (!String.IsNullOrEmpty(countertrapsmin.Text.ToString()))
                                    if (!String.IsNullOrEmpty(countertrapsmax.Text.ToString()))
                                    {
                                        if (duelcheck > 0)
                                        {
                                            m.writeMemory("duel.dll+8503C8, 0x11A", "2bytes", countertrapsminsa.ToString());
                                        }
                                    }
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(countertraps.Text.ToString()))
                                if (Convert.ToInt32(countertraps.Text.ToString()) > -1)
                                    if (duelcheck > 0)
                                    {
                                    m.writeMemory("duel.dll+8503C8, 0x11A", "2bytes", countertraps.Text.ToString());
                                }
                        }
                    }

                    if (contintraps.Checked) // Contin Traps
                    {

                        if (randomda.Checked)
                        {
                            if (String.IsNullOrEmpty(continmin.Text.ToString()))
                            {
                                MessageBox.Show("Fill Contin Trap: >From< TextBox and press the Button >Attach Game<!");
                            }
                            else if (String.IsNullOrEmpty(continmax.Text.ToString()))
                            {
                                MessageBox.Show("Fill Contin Trap: >TO< TextBox and press the Button >Attach Game<!");
                            }
                            int continmins = Convert.ToInt32(continmin.Text);
                            int continmaxx = Convert.ToInt32(continmax.Text);
                            if (continmins > continmaxx)
                            {
                                MessageBox.Show("Contin Traps: <FROM> Value, cant be bigger than <TO> Value.\nChange it and press <Attach Game Button>!");
                            }
                            else
                            {
                                int continmaxxa = r.Next(continmins, continmaxx);
                                if (!String.IsNullOrEmpty(continmin.Text.ToString()))
                                    if (!String.IsNullOrEmpty(continmax.Text.ToString()))
                                    {
                                        if (duelcheck > 0)
                                        {
                                            m.writeMemory("duel.dll+8503C8, 0x110", "2bytes", continmaxxa.ToString());
                                        }
                                    }
                            }

                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(continresult.Text.ToString()))
                                if (Convert.ToInt32(continresult.Text.ToString()) > -1)
                                    if (duelcheck > 0)
                                    {
                                    m.writeMemory("duel.dll+8503C8, 0x110", "2bytes", continresult.Text.ToString());
                                }
                        }
                    }



                    ///======================================================
                    ///                     MISC
                    ///======================================================   
                    if (sumBox.Checked) // Skills used
                    {

                        if (randomda.Checked)
                        {
                            if (String.IsNullOrEmpty(skillsmin.Text.ToString()))
                            {
                                MessageBox.Show("Fill Skills used: >From< TextBox and press the Button >Attach Game<!");
                            }
                            else if (String.IsNullOrEmpty(skillsmax.Text.ToString()))
                            {
                                MessageBox.Show("Fill Skills used: >TO< TextBox and press the Button >Attach Game<!");
                            }
                            int skillsmina = Convert.ToInt32(skillsmin.Text);
                            int skillsmaxa = Convert.ToInt32(skillsmax.Text);
                            if (skillsmina > skillsmaxa)
                            {
                                MessageBox.Show("Skills used: <FROM> Value, cant be bigger than <TO> Value.\nChange it and press <Attach Game Button>!");
                            }
                            else
                            {
                                int skillsmaxx = r.Next(skillsmina, skillsmaxa);
                                if (!String.IsNullOrEmpty(skillsmin.Text.ToString()))
                                    if (!String.IsNullOrEmpty(skillsmax.Text.ToString()))
                                    {
                                        if (duelcheck > 0)
                                        {
                                            m.writeMemory("duel.dll+8502F4", "int", skillsmaxx.ToString());
                                        }
                                    }
                            }

                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(skillusemission.Text.ToString()))
                                if (Convert.ToInt32(skillusemission.Text.ToString()) > -1)
                                    if (sumBox.Checked)
                                    {
                                        if (duelcheck > 0)
                                        {                                     
                                        m.writeMemory("duel.dll+8502F4", "int", skillusemission.Text.ToString());
                                        }
                                    }
                        }
                    }


                    if (finisher.Checked) // Finisher ID
                    {
                        if (!String.IsNullOrEmpty(finisherid.Text.ToString()))
                            if (!String.IsNullOrEmpty(finisherid.Text.ToString()))
                            if (duelcheck > 0)
                            {
                                m.writeMemory("duel.dll+850418, 0x3598", "int", finisherid.Text.ToString());
                            }
                    }


                    if (turns.Checked) // Turns Made 
                    {

                        if (randomda.Checked)
                        {
                            if (String.IsNullOrEmpty(turnsmin.Text.ToString()))
                            {
                                MessageBox.Show("Fill Truns: >From< TextBox and press the Button >Attach Game<!");
                            }
                            else if (String.IsNullOrEmpty(turnsmax.Text.ToString()))
                            {
                                MessageBox.Show("Fill Truns: >TO< TextBox and press the Button >Attach Game<!");
                            }
                            int turnsmins = Convert.ToInt32(turnsmin.Text);
                            int turnsmaxx = Convert.ToInt32(turnsmax.Text);
                            if (turnsmins > turnsmaxx)
                            {
                                MessageBox.Show("Truns: <FROM> Value, cant be bigger than <TO> Value.\nChange it and press <Attach Game Button>!");
                            }
                            else
                            {
                                int turnsmina = r.Next(turnsmins, turnsmaxx);
                                if (!String.IsNullOrEmpty(turnsmin.Text.ToString()))
                                    if (!String.IsNullOrEmpty(turnsmax.Text.ToString()))
                                    {
                                        if (duelcheck > 0)
                                        {
                                            m.writeMemory("duel.dll+850418, 0x3578", "int", turnsmina.ToString());
                                        }
                                    }
                            }

                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(turnsresult.Text.ToString()))
                                if (Convert.ToInt32(turnsresult.Text.ToString()) > -1)
                                    if (duelcheck > 0)
                                    {
                                    m.writeMemory("duel.dll+850418, 0x3578", "int", turnsresult.Text.ToString());
                                }
                        }
                    }


                    ///======================================================
                    ///                     CARD IDS OUTPUT
                    ///======================================================  
                    // Highlighted Card ID 
                    var currents = m.read2Byte("GameAssembly.dll+01B10200, 0xB8,0x0,0xB0,0xA8,0x108");
                    metroTextBox555.Invoke((MethodInvoker)delegate
                    {
                        if (currents > 14782)
                        {
                            metroTextBox555.Text = "None";
                        }
                        else
                        {
                            metroTextBox555.Text = currents.ToString();

                        }
                    });

                    // Output Card ID #1
                    var current = m.read2Byte("GameAssembly.dll+01B1C978, 0xB8,0x0,0x18,0x20,0x20");
                    metroTextBox10.Invoke((MethodInvoker)delegate
                    {
                        if (current == 0)
                        {
                            metroTextBox10.Text = "None";
                        }
                        else
                        {
                            metroTextBox10.Text = current.ToString();

                        }
                    });
                    // Output Card ID played amount #1
                    var timesss = m.read2Byte("GameAssembly.dll+01B1C978, 0xB8,0x0,0x18,0x28,0x20");
                    metroTextBox9.Invoke((MethodInvoker)delegate
                    {
                        if (timesss == 0)
                        {
                            metroTextBox9.Text = "None";
                        }
                        else
                        {
                            metroTextBox9.Text = timesss.ToString();

                        }
                    });


                    // Output Card ID #2
                    var current2 = m.read2Byte("GameAssembly.dll+01B1C978, 0xB8,0x0,0x18,0x20,0x24");
                    metroTextBox6.Invoke((MethodInvoker)delegate
                    {
                        if (current2 == 0)
                        {
                            metroTextBox6.Text = "None";
                        }
                        else
                        {
                            metroTextBox6.Text = current2.ToString();

                        }
                    });
                    // Output Card ID played amount #2
                    var times2 = m.read2Byte("GameAssembly.dll+01B1C978, 0xB8,0x0,0x18,0x28,0x24");
                    metroTextBox5.Invoke((MethodInvoker)delegate
                    {
                        if (times2 == 0)
                        {
                            metroTextBox5.Text = "None";
                        }
                        else
                        {
                            metroTextBox5.Text = times2.ToString();

                        }
                    });


                    // Output Card ID #3
                    var current3 = m.read2Byte("GameAssembly.dll+01B1C978, 0xB8,0x0,0x18,0x20,0x28");
                    metroTextBox12.Invoke((MethodInvoker)delegate
                    {
                        if (current3 == 0)
                        {
                            metroTextBox12.Text = "None";
                        }
                        else
                        {
                            metroTextBox12.Text = current3.ToString();

                        }
                    });
                    // Output Card ID played amount #3
                    var times3 = m.read2Byte("GameAssembly.dll+01B1C978, 0xB8,0x0,0x18,0x28,0x28");
                    metroTextBox11.Invoke((MethodInvoker)delegate
                    {
                        if (times3 == 0)
                        {
                            metroTextBox11.Text = "None";
                        }
                        else
                        {
                            metroTextBox11.Text = times3.ToString();

                        }
                    });


                    ///======================================================
                    ///                     CARD IDS INPUT
                    ///======================================================  
                    if (cardid1.Checked) // Played Card ID #1
                    {
                        var current1 = m.read2Byte("GameAssembly.dll+01B1C978, 0xB8,0x0,0x18,0x20,0x20");
                        if (!String.IsNullOrEmpty(metroTextBox4.Text.ToString()))
                            if (Convert.ToInt32(metroTextBox4.Text.ToString()) > -1)
                                if (current1 > 0)
                                {
                                    m.writeMemory("GameAssembly.dll+01B1C978, 0xB8,0x0,0x18,0x20,0x20", "int", metroTextBox4.Text.ToString());
                                }


                    }

                    if (cardp1.Checked) // Played amount #1
                    {
                        var timess = m.readLong("GameAssembly.dll+01B1C978, 0xB8,0x0,0x18,0x28,0x20");
                        if (!String.IsNullOrEmpty(metroTextBox3.Text.ToString()))
                            if (Convert.ToInt32(metroTextBox3.Text.ToString()) > -1)
                                if (timess > 0)
                                {
                                    m.writeMemory("GameAssembly.dll+01B1C978, 0xB8,0x0,0x18,0x28,0x20", "int", metroTextBox3.Text.ToString());
                                }


                    }

                    if (metroCheckBox5.Checked) // Played Card ID #2
                    {
                        var id2 = m.read2Byte("GameAssembly.dll+01B1C978, 0xB8,0x0,0x18,0x20,0x24");
                        if (!String.IsNullOrEmpty(metroTextBox8.Text.ToString()))
                            if (Convert.ToInt32(metroTextBox8.Text.ToString()) > -1)
                                if (id2 > 0)
                                {
                                    m.writeMemory("GameAssembly.dll+01B1C978, 0xB8,0x0,0x18,0x20,0x24", "int", metroTextBox8.Text.ToString());
                                }


                    }

                    if (metroCheckBox4.Checked) // Played amount #2
                    {
                        var amount2 = m.readLong("GameAssembly.dll+01B1C978, 0xB8,0x0,0x18,0x28,0x24");
                        if (!String.IsNullOrEmpty(metroTextBox7.Text.ToString()))
                            if (Convert.ToInt32(metroTextBox7.Text.ToString()) > -1)
                                if (amount2 > 0)
                                {
                                    m.writeMemory("GameAssembly.dll+01B1C978, 0xB8,0x0,0x18,0x28,0x24", "int", metroTextBox7.Text.ToString());
                                }
                    }

                    if (metroCheckBox7.Checked) // Played Card ID #3
                    {
                        var id3 = m.read2Byte("GameAssembly.dll+01B1C978, 0xB8,0x0,0x18,0x20,0x28");
                        if (!String.IsNullOrEmpty(metroTextBox14.Text.ToString()))
                            if (Convert.ToInt32(metroTextBox14.Text.ToString()) > -1)
                                if (id3 > 0)
                                {
                                    m.writeMemory("GameAssembly.dll+01B1C978, 0xB8,0x0,0x18,0x20,0x28", "int", metroTextBox14.Text.ToString());
                                }


                    }

                    if (metroCheckBox6.Checked) // Played amount #3
                    {
                        var amount3 = m.readLong("GameAssembly.dll+01B1C978, 0xB8,0x0,0x18,0x28,0x28");
                        if (!String.IsNullOrEmpty(metroTextBox13.Text.ToString()))
                            if (Convert.ToInt32(metroTextBox13.Text.ToString()) > -1)
                                if (amount3 > 0)
                                {
                                    m.writeMemory("GameAssembly.dll+01B1C978, 0xB8,0x0,0x18,0x28,0x28", "int", metroTextBox13.Text.ToString());
                                }
                    }
                }
                else
                {
                    return;
                }
                Thread.Sleep(1000);
            }
        }

        ///======================================================
        ///    KEYPRESS HANDLER FOR TEXTBOXES (ONLY NUMBERS)
        ///======================================================
        ///



        private void syncrosmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }


        private void enemymin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void enemymax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void enemylp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void mylpmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void mylpmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void mylp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void recovermin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void recovermax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void recoverlp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void mydeckmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void mydeckmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void mydeck_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void myhandmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void myhandmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void myhand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void enemydeckmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void enemydeckmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void enemydeck_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void enemyhandmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void enemyhandmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void enemyhand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void efdbdmmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void efdbdmmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void effectdamagevalue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void mbdmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void mbdmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void battledama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void attacksmademin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void attacksmademax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void attacksm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void skillsmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void skillsmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void skillusemission_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void normalsummonmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void normalsummonmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void normalsummon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void tributemin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void tributemax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void tributesummon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void specialmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void specialmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void specialsummon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void ritualmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void ritualmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void ritualsummon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void fusionmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void fusionmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void fusionsummon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void activatespellmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void activatespellmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void activatedspell_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void continspellsmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void continspellsmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void continspells_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void quickspellsmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void quickspellsmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void quickspells_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void fieldspellsmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void fieldspellsmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void fieldspells_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void equipspellsmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void equipspellsmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void equipspells_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void activatetrapmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void activatetrapmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void activatedtraps_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void countertrapsmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void countertrapsmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void countertraps_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void continmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void continmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void continresult_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void skillsmin_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void skillsmax_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        private void skillusemission_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }

        //Setting Profiles Start.
        private void pictureBox5_Click(object sender, EventArgs e) // Profile 1 - Save
        {
            ///======================================================
            ///                 Profile 1 Save
            ///======================================================
            p1.Default.continmin = continmin.Text;
            p1.Default.continmax = continmax.Text;
            p1.Default.continresult = continresult.Text;
            p1.Default.enemydeck = enemydeck.Text;
            p1.Default.recoverlp = recoverlp.Text;
            p1.Default.mydeck = mydeck.Text;
            p1.Default.myhand = myhand.Text;
            p1.Default.mylp = mylp.Text;
            p1.Default.enemyhand = enemyhand.Text;
            p1.Default.skillusemission = skillusemission.Text;
            p1.Default.effectdamagevalue = effectdamagevalue.Text;
            p1.Default.normalsummon = normalsummon.Text;
            p1.Default.tributesummon = tributesummon.Text;
            p1.Default.specialsummon = specialsummon.Text;
            p1.Default.activatedspell = activatedspell.Text;
            p1.Default.continspells = continspells.Text;
            p1.Default.quickspells = quickspells.Text;
            p1.Default.activatedtraps = activatedtraps.Text;
            p1.Default.ns1 = normalsummon.Text;
            p1.Default.ritualsummon = ritualsummon.Text;
            p1.Default.countertraps = countertraps.Text;
            p1.Default.fieldspells = fieldspells.Text;
            p1.Default.equipspells = equipspells.Text;
            p1.Default.maxbattledamagemission = battledama.Text;
            p1.Default.fusionsummon = fusionsummon.Text;
            p1.Default.attacksm = attacksm.Text;

            p1.Default.min = mylpmin.Text;
            p1.Default.max = mylpmax.Text;
            // p1.Default.enemymin = enemymin.Text;
            p1.Default.mydeckmin = mydeckmin.Text;
            p1.Default.myhandmin = myhandmin.Text;
            p1.Default.enemyhand = enemyhand.Text;
            //p1.Default.recovermin = recovermin.Text;
            p1.Default.enemydeckmin = enemydeckmin.Text;
            p1.Default.enemyhandmin = enemyhandmin.Text;
            p1.Default.activatespellmin = activatespellmin.Text;
            p1.Default.activatetrapmin = activatetrapmin.Text;
            p1.Default.quickspellsmin = quickspellsmin.Text;
            p1.Default.fieldspellsmin = fieldspellsmin.Text;
            p1.Default.equipspellsmin = equipspellsmin.Text;
            p1.Default.continspellsmin = continspellsmin.Text;
            p1.Default.countertrapsmin = countertrapsmin.Text;
            p1.Default.normalsummonmin = normalsummonmin.Text;
            p1.Default.tributemin = tributemin.Text;
            p1.Default.specialmin = specialmin.Text;
            p1.Default.ritualmin = ritualmin.Text;
            p1.Default.fusionmin = fusionmin.Text;
            p1.Default.attacksmademin = attacksmademin.Text;
            p1.Default.skillsmin = skillsmin.Text;
            p1.Default.maxbdmin = mbdmin.Text;
            p1.Default.efdbdmmin = efdbdmmin.Text;
            //p1.Default.enemymax = enemymax.Text;
            p1.Default.mydeckmax = mydeckmax.Text;
            p1.Default.myhandmax = myhandmax.Text;
            p1.Default.enemyhand = enemyhand.Text;
            //p1.Default.recovermax = recovermax.Text;
            p1.Default.enemydeckmax = enemydeckmax.Text;
            p1.Default.enemyhandmax = enemyhandmax.Text;
            p1.Default.activatespellmax = activatespellmax.Text;
            p1.Default.activatetrapmax = activatetrapmax.Text;
            p1.Default.quickspellsmax = quickspellsmax.Text;
            p1.Default.fieldspellsmax = fieldspellsmax.Text;
            p1.Default.equipspellsmax = equipspellsmax.Text;
            p1.Default.continspellsmax = continspellsmax.Text;
            p1.Default.countertrapsmax = countertrapsmax.Text;
            p1.Default.normalsummonmax = normalsummonmax.Text;
            p1.Default.tributemax = tributemax.Text;
            p1.Default.specialmax = specialmax.Text;
            p1.Default.ritualmax = ritualmax.Text;
            p1.Default.fusionmax = fusionmax.Text;
            p1.Default.attacksmademax = attacksmademax.Text;
            p1.Default.skillsmax = skillsmax.Text;
            p1.Default.maxbdmax = mbdmax.Text;
            p1.Default.efdbdmmax = efdbdmmax.Text;
            p1.Default.enemylp = enemylp.Text;
            p1.Default.syncrosmin = syncrosmin.Text;
            p1.Default.syncrosmax = syncrosmax.Text;
            p1.Default.syncrosresult = syncrosresult.Text;
            p1.Default.turnsmin = turnsmin.Text;
            p1.Default.turnsmax = turnsmax.Text;
            p1.Default.turnsresult = turnsresult.Text;


            p1.Default.turns = turns.Checked;





            //Saving CheckBoxes.  
            p1.Default.disablexor = disablexor.Checked;
            p1.Default.contintraps = contintraps.Checked;
            p1.Default.asBox = asBox.Checked;
            p1.Default.csBox = csBox.Checked;
            p1.Default.qsBox = qsBox.Checked;
            p1.Default.fssBox = fssBox.Checked;
            p1.Default.eqBox = eqBox.Checked;
            p1.Default.atBox = atBox.Checked;
            p1.Default.ctBox = ctBox.Checked;
            p1.Default.nsBox = nsBox.Checked;
            p1.Default.tsBox = tsBox.Checked;
            p1.Default.ssBox = ssBox.Checked;
            p1.Default.rsBox = rsBox.Checked;
            p1.Default.fsBox = fsBox.Checked;
            p1.Default.sumBox = sumBox.Checked;
            p1.Default.syncros = syncros.Checked;
            p1.Default.edBox = edBox.Checked;
            p1.Default.maxbdbox = maxbdbox.Checked;
            p1.Default.enemybox = enemybox.Checked;
            p1.Default.attacksmadebox = attacksmbox.Checked;
            p1.Default.enemyhandbox = enemyhandbox.Checked;
            p1.Default.enemydeckbox = enemydeckbox.Checked;
            p1.Default.RecoverLpBox = RecoverLpBox.Checked;
            p1.Default.myhandbox = myhandbox.Checked;
            p1.Default.mydeckbox = mydeckbox.Checked;
            p1.Default.mylpbox = mylpbox.Checked;
            p1.Default.Save();


            var msg = "Saved your Profile: " + Profile1.Text + "!";
            MessageBox.Show(msg, "Saved your Profile", MessageBoxButtons.OK, MessageBoxIcon.None);



        }
        private void pictureBox4_Click(object sender, EventArgs e) // Profile 1 - Load
        {
            ///======================================================
            ///                 Profile 1 Load
            ///======================================================
            continmin.Text = p1.Default.continmin;
            continmax.Text = p1.Default.continmax;
            continresult.Text = p1.Default.continresult;
            enemydeck.Text = p1.Default.enemydeck;
            recoverlp.Text = p1.Default.recoverlp;
            mydeck.Text = p1.Default.mydeck;
            myhand.Text = p1.Default.myhand;
            mylp.Text = p1.Default.mylp;
            enemyhand.Text = p1.Default.enemyhand;
            skillusemission.Text = p1.Default.skillusemission;
            effectdamagevalue.Text = p1.Default.effectdamagevalue;
            normalsummon.Text = p1.Default.normalsummon;
            tributesummon.Text = p1.Default.tributesummon;
            specialsummon.Text = p1.Default.specialsummon;
            activatedspell.Text = p1.Default.activatedspell;
            continspells.Text = p1.Default.continspells;
            quickspells.Text = p1.Default.quickspells;
            activatedtraps.Text = p1.Default.activatedtraps;
            normalsummon.Text = p1.Default.ns1;
            ritualsummon.Text = p1.Default.ritualsummon;
            countertraps.Text = p1.Default.countertraps;
            fieldspells.Text = p1.Default.fieldspells;
            equipspells.Text = p1.Default.equipspells;
            battledama.Text = p1.Default.maxbattledamagemission;
            fusionsummon.Text = p1.Default.fusionsummon;
            attacksm.Text = p1.Default.attacksm;


            mylpmin.Text = p1.Default.min;
            mylpmax.Text = p1.Default.max;
            //enemymax.Text = p1.Default.enemymax;
            mydeckmax.Text = p1.Default.mydeckmax;
            myhandmax.Text = p1.Default.myhandmax;
            //recovermax.Text = p1.Default.recovermax;
            enemydeckmax.Text = p1.Default.enemydeckmax;
            enemyhandmax.Text = p1.Default.enemyhandmax;
            activatespellmax.Text = p1.Default.activatespellmax;
            activatetrapmax.Text = p1.Default.activatetrapmax;
            quickspellsmax.Text = p1.Default.quickspellsmax;
            fieldspellsmax.Text = p1.Default.fieldspellsmax;
            equipspellsmax.Text = p1.Default.equipspellsmax;
            continspellsmax.Text = p1.Default.continspellsmax;
            countertrapsmax.Text = p1.Default.countertrapsmax;
            normalsummonmax.Text = p1.Default.normalsummonmax;
            tributemax.Text = p1.Default.tributemax;
            specialmax.Text = p1.Default.specialmax;
            ritualmax.Text = p1.Default.ritualmax;
            fusionmax.Text = p1.Default.fusionmax;
            attacksmademax.Text = p1.Default.attacksmademax;
            skillsmax.Text = p1.Default.skillsmax;

            mbdmax.Text = p1.Default.maxbdmax;
            efdbdmmax.Text = p1.Default.efdbdmmax;
            enemylp.Text = p1.Default.enemylp;

            turnsmin.Text = p1.Default.turnsmin;
            turnsmax.Text = p1.Default.turnsmax;
            turnsresult.Text = p1.Default.turnsresult;
            turns.Checked = p1.Default.turns;

            //enemymin.Text = p1.Default.enemymin;
            mydeckmin.Text = p1.Default.mydeckmin;
            myhandmin.Text = p1.Default.myhandmin;
            //recovermin.Text = p1.Default.recovermin;
            enemydeckmin.Text = p1.Default.enemydeckmin;
            enemyhandmin.Text = p1.Default.enemyhandmin;
            activatespellmin.Text = p1.Default.activatespellmin;
            activatetrapmin.Text = p1.Default.activatetrapmin;
            quickspellsmin.Text = p1.Default.quickspellsmin;
            fieldspellsmin.Text = p1.Default.fieldspellsmin;
            equipspellsmin.Text = p1.Default.equipspellsmin;
            continspellsmin.Text = p1.Default.continspellsmin;
            countertrapsmin.Text = p1.Default.countertrapsmin;
            normalsummonmin.Text = p1.Default.normalsummonmin;
            tributemin.Text = p1.Default.tributemin;
            specialmin.Text = p1.Default.specialmin;
            ritualmin.Text = p1.Default.ritualmin;
            fusionmin.Text = p1.Default.fusionmin;
            attacksmademin.Text = p1.Default.attacksmademin;
            skillsmin.Text = p1.Default.skillsmin;
            mbdmin.Text = p1.Default.maxbdmin;
            efdbdmmin.Text = p1.Default.efdbdmmin;

            syncrosmin.Text = p1.Default.syncrosmin;
            syncrosmax.Text = p1.Default.syncrosmax;
            syncrosresult.Text = p1.Default.syncrosresult;

      




            // Checkboxes.
            disablexor.Checked = p1.Default.disablexor;
            contintraps.Checked = p1.Default.contintraps;
            asBox.Checked = p1.Default.asBox;
            csBox.Checked = p1.Default.csBox;
            qsBox.Checked = p1.Default.qsBox;
            fssBox.Checked = p1.Default.fssBox;
            eqBox.Checked = p1.Default.eqBox;
            atBox.Checked = p1.Default.atBox;
            ctBox.Checked = p1.Default.ctBox;
            nsBox.Checked = p1.Default.nsBox;
            tsBox.Checked = p1.Default.tsBox;
            ssBox.Checked = p1.Default.ssBox;
            rsBox.Checked = p1.Default.rsBox;
            fsBox.Checked = p1.Default.fsBox;
            sumBox.Checked = p1.Default.sumBox;
            edBox.Checked = p1.Default.edBox;
            maxbdbox.Checked = p1.Default.maxbdbox;
            enemybox.Checked = p1.Default.enemybox;
            attacksmbox.Checked = p1.Default.attacksmadebox;
            enemyhandbox.Checked = p1.Default.enemyhandbox;
            enemydeckbox.Checked = p1.Default.enemydeckbox;
            RecoverLpBox.Checked = p1.Default.RecoverLpBox;
            myhandbox.Checked = p1.Default.myhandbox;
            mydeckbox.Checked = p1.Default.mydeckbox;
            mylpbox.Checked = p1.Default.mylpbox;
            syncros.Checked = p1.Default.syncros;


            Profile1.ForeColor = Color.Green;
            Profile2.ForeColor = Color.Gray;
            Profile3.ForeColor = Color.Gray;
            Profile4.ForeColor = Color.Gray;
            Profile5.ForeColor = Color.Gray;
            Profile6.ForeColor = Color.Gray;


        }

        private void pictureBox7_Click(object sender, EventArgs e) // Profile 2 - Save
        {
            ///======================================================
            ///                 Profile 2 Save
            ///======================================================   
            p2.Default.continmin = continmin.Text;
            p2.Default.continmax = continmax.Text;
            p2.Default.continresult = continresult.Text;
            p2.Default.enemydeck = enemydeck.Text;
            p2.Default.recoverlp = recoverlp.Text;
            p2.Default.mydeck = mydeck.Text;
            p2.Default.myhand = myhand.Text;
            p2.Default.mylp = mylp.Text;
            p2.Default.enemyhand = enemyhand.Text;
            p2.Default.skillusemission = skillusemission.Text;
            p2.Default.effectdamagevalue = effectdamagevalue.Text;
            p2.Default.normalsummon = normalsummon.Text;
            p2.Default.tributesummon = tributesummon.Text;
            p2.Default.specialsummon = specialsummon.Text;
            p2.Default.activatedspell = activatedspell.Text;
            p2.Default.continspells = continspells.Text;
            p2.Default.quickspells = quickspells.Text;
            p2.Default.activatedtraps = activatedtraps.Text;
            p2.Default.ns1 = normalsummon.Text;
            p2.Default.ritualsummon = ritualsummon.Text;
            p2.Default.countertraps = countertraps.Text;
            p2.Default.fieldspells = fieldspells.Text;
            p2.Default.equipspells = equipspells.Text;
            p2.Default.maxbattledamagemission = battledama.Text;
            p2.Default.fusionsummon = fusionsummon.Text;
            p2.Default.attacksm = attacksm.Text;

            p2.Default.min = mylpmin.Text;
            p2.Default.max = mylpmax.Text;
            //p2.Default.enemymin = enemymin.Text;
            p2.Default.mydeckmin = mydeckmin.Text;
            p2.Default.myhandmin = myhandmin.Text;
            p2.Default.enemyhand = enemyhand.Text;
            //p2.Default.recovermin = recovermin.Text;
            p2.Default.enemydeckmin = enemydeckmin.Text;
            p2.Default.enemyhandmin = enemyhandmin.Text;
            p2.Default.activatespellmin = activatespellmin.Text;
            p2.Default.activatetrapmin = activatetrapmin.Text;
            p2.Default.quickspellsmin = quickspellsmin.Text;
            p2.Default.fieldspellsmin = fieldspellsmin.Text;
            p2.Default.equipspellsmin = equipspellsmin.Text;
            p2.Default.continspellsmin = continspellsmin.Text;
            p2.Default.countertrapsmin = countertrapsmin.Text;
            p2.Default.normalsummonmin = normalsummonmin.Text;
            p2.Default.tributemin = tributemin.Text;
            p2.Default.specialmin = specialmin.Text;
            p2.Default.ritualmin = ritualmin.Text;
            p2.Default.fusionmin = fusionmin.Text;
            p2.Default.attacksmademin = attacksmademin.Text;
            p2.Default.skillsmin = skillsmin.Text;
            p2.Default.maxbdmin = mbdmin.Text;
            p2.Default.efdbdmmin = efdbdmmin.Text;
            // p2.Default.enemymax = enemymax.Text;
            p2.Default.mydeckmax = mydeckmax.Text;
            p2.Default.myhandmax = myhandmax.Text;
            p2.Default.enemyhand = enemyhand.Text;
            //p2.Default.recovermax = recovermax.Text;
            p2.Default.enemydeckmax = enemydeckmax.Text;
            p2.Default.enemyhandmax = enemyhandmax.Text;
            p2.Default.activatespellmax = activatespellmax.Text;
            p2.Default.activatetrapmax = activatetrapmax.Text;
            p2.Default.quickspellsmax = quickspellsmax.Text;
            p2.Default.fieldspellsmax = fieldspellsmax.Text;
            p2.Default.equipspellsmax = equipspellsmax.Text;
            p2.Default.continspellsmax = continspellsmax.Text;
            p2.Default.countertrapsmax = countertrapsmax.Text;
            p2.Default.normalsummonmax = normalsummonmax.Text;
            p2.Default.tributemax = tributemax.Text;
            p2.Default.specialmax = specialmax.Text;
            p2.Default.ritualmax = ritualmax.Text;
            p2.Default.fusionmax = fusionmax.Text;
            p2.Default.attacksmademax = attacksmademax.Text;
            p2.Default.skillsmax = skillsmax.Text;

            p2.Default.maxbdmax = mbdmax.Text;
            p2.Default.efdbdmmax = efdbdmmax.Text;
            p2.Default.enemylp = enemylp.Text;
            p2.Default.syncrosmin = syncrosmin.Text;
            p2.Default.syncrosmax = syncrosmax.Text;
            p2.Default.syncrosresult = syncrosresult.Text;


            p2.Default.turnsmin = turnsmin.Text;
            p2.Default.turnsmax = turnsmax.Text;
            p2.Default.turnsresult = turnsresult.Text;
            p2.Default.turns = turns.Checked;

            //Saving CheckBoxes.
            p2.Default.asBox = asBox.Checked;
            p2.Default.disablexor = disablexor.Checked;
            p2.Default.contintraps = contintraps.Checked;
            p2.Default.csBox = csBox.Checked;
            p2.Default.qsBox = qsBox.Checked;
            p2.Default.fssBox = fssBox.Checked;
            p2.Default.eqBox = eqBox.Checked;
            p2.Default.atBox = atBox.Checked;
            p2.Default.ctBox = ctBox.Checked;
            p2.Default.nsBox = nsBox.Checked;
            p2.Default.tsBox = tsBox.Checked;
            p2.Default.ssBox = ssBox.Checked;
            p2.Default.rsBox = rsBox.Checked;
            p2.Default.fsBox = fsBox.Checked;
            p2.Default.sumBox = sumBox.Checked;
            p2.Default.edBox = edBox.Checked;
            p2.Default.maxbdbox = maxbdbox.Checked;
            p2.Default.enemybox = enemybox.Checked;
            p2.Default.attacksmadebox = attacksmbox.Checked;
            p2.Default.enemyhandbox = enemyhandbox.Checked;
            p2.Default.enemydeckbox = enemydeckbox.Checked;
            p2.Default.RecoverLpBox = RecoverLpBox.Checked;
            p2.Default.myhandbox = myhandbox.Checked;
            p2.Default.mydeckbox = mydeckbox.Checked;
            p2.Default.mylpbox = mylpbox.Checked;
            p2.Default.syncros = syncros.Checked;
            p2.Default.Save();
            var msg = "Saved your Profile: " + Profile2.Text + "!";
            MessageBox.Show(msg, "Saved your Profile", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
        private void pictureBox6_Click(object sender, EventArgs e) // Profile 2 - Load
        {
            ///======================================================
            ///                 Profile 2 Load
            ///======================================================
            continmin.Text = p2.Default.continmin;
            continmax.Text = p2.Default.continmax;
            continresult.Text = p2.Default.continresult;
            enemydeck.Text = p2.Default.enemydeck;
            recoverlp.Text = p2.Default.recoverlp;
            mydeck.Text = p2.Default.mydeck;
            myhand.Text = p2.Default.myhand;
            mylp.Text = p2.Default.mylp;
            enemyhand.Text = p2.Default.enemyhand;
            skillusemission.Text = p2.Default.skillusemission;
            effectdamagevalue.Text = p2.Default.effectdamagevalue;
            normalsummon.Text = p2.Default.normalsummon;
            tributesummon.Text = p2.Default.tributesummon;
            specialsummon.Text = p2.Default.specialsummon;
            activatedspell.Text = p2.Default.activatedspell;
            continspells.Text = p2.Default.continspells;
            quickspells.Text = p2.Default.quickspells;
            activatedtraps.Text = p2.Default.activatedtraps;
            normalsummon.Text = p2.Default.ns1;
            ritualsummon.Text = p2.Default.ritualsummon;
            countertraps.Text = p2.Default.countertraps;
            fieldspells.Text = p2.Default.fieldspells;
            equipspells.Text = p2.Default.equipspells;
            battledama.Text = p2.Default.maxbattledamagemission;
            fusionsummon.Text = p2.Default.fusionsummon;
            attacksm.Text = p2.Default.attacksm;


            mylpmin.Text = p2.Default.min;
            mylpmax.Text = p2.Default.max;
            //enemymax.Text = p2.Default.enemymax;
            mydeckmax.Text = p2.Default.mydeckmax;
            myhandmax.Text = p2.Default.myhandmax;
            //recovermax.Text = p2.Default.recovermax;
            enemydeckmax.Text = p2.Default.enemydeckmax;
            enemyhandmax.Text = p2.Default.enemyhandmax;
            activatespellmax.Text = p2.Default.activatespellmax;
            activatetrapmax.Text = p2.Default.activatetrapmax;
            quickspellsmax.Text = p2.Default.quickspellsmax;
            fieldspellsmax.Text = p2.Default.fieldspellsmax;
            equipspellsmax.Text = p2.Default.equipspellsmax;
            continspellsmax.Text = p2.Default.continspellsmax;
            countertrapsmax.Text = p2.Default.countertrapsmax;
            normalsummonmax.Text = p2.Default.normalsummonmax;
            tributemax.Text = p2.Default.tributemax;
            specialmax.Text = p2.Default.specialmax;
            ritualmax.Text = p2.Default.ritualmax;
            fusionmax.Text = p2.Default.fusionmax;
            attacksmademax.Text = p2.Default.attacksmademax;
            skillsmax.Text = p2.Default.skillsmax;

            mbdmax.Text = p2.Default.maxbdmax;
            efdbdmmax.Text = p2.Default.efdbdmmax;
            enemylp.Text = p2.Default.enemylp;


            //enemymin.Text = p2.Default.enemymin;
            mydeckmin.Text = p2.Default.mydeckmin;
            myhandmin.Text = p2.Default.myhandmin;
            //recovermin.Text = p2.Default.recovermin;
            enemydeckmin.Text = p2.Default.enemydeckmin;
            enemyhandmin.Text = p2.Default.enemyhandmin;
            activatespellmin.Text = p2.Default.activatespellmin;
            activatetrapmin.Text = p2.Default.activatetrapmin;
            quickspellsmin.Text = p2.Default.quickspellsmin;
            fieldspellsmin.Text = p2.Default.fieldspellsmin;
            equipspellsmin.Text = p2.Default.equipspellsmin;
            continspellsmin.Text = p2.Default.continspellsmin;
            countertrapsmin.Text = p2.Default.countertrapsmin;
            normalsummonmin.Text = p2.Default.normalsummonmin;
            tributemin.Text = p2.Default.tributemin;
            specialmin.Text = p2.Default.specialmin;
            ritualmin.Text = p2.Default.ritualmin;
            fusionmin.Text = p2.Default.fusionmin;
            attacksmademin.Text = p2.Default.attacksmademin;
            skillsmin.Text = p2.Default.skillsmin;
            mbdmin.Text = p2.Default.maxbdmin;
            efdbdmmin.Text = p2.Default.efdbdmmin;
            syncrosmin.Text = p2.Default.syncrosmin;
            syncrosmax.Text = p2.Default.syncrosmax;
            syncrosresult.Text = p2.Default.syncrosresult;


            turnsmin.Text = p2.Default.turnsmin;
            turnsmax.Text = p2.Default.turnsmax;
            turnsresult.Text = p2.Default.turnsresult;
            turns.Checked = p2.Default.turns;



            // Checkboxes.
            asBox.Checked = p2.Default.asBox;
            disablexor.Checked = p2.Default.disablexor;
            contintraps.Checked = p2.Default.contintraps;
            csBox.Checked = p2.Default.csBox;
            qsBox.Checked = p2.Default.qsBox;
            fssBox.Checked = p2.Default.fssBox;
            eqBox.Checked = p2.Default.eqBox;
            atBox.Checked = p2.Default.atBox;
            ctBox.Checked = p2.Default.ctBox;
            nsBox.Checked = p2.Default.nsBox;
            tsBox.Checked = p2.Default.tsBox;
            ssBox.Checked = p2.Default.ssBox;
            rsBox.Checked = p2.Default.rsBox;
            fsBox.Checked = p2.Default.fsBox;
            sumBox.Checked = p2.Default.sumBox;
            edBox.Checked = p2.Default.edBox;
            maxbdbox.Checked = p2.Default.maxbdbox;
            enemybox.Checked = p2.Default.enemybox;
            attacksmbox.Checked = p2.Default.attacksmadebox;
            enemyhandbox.Checked = p2.Default.enemyhandbox;
            enemydeckbox.Checked = p2.Default.enemydeckbox;
            RecoverLpBox.Checked = p2.Default.RecoverLpBox;
            myhandbox.Checked = p2.Default.myhandbox;
            mydeckbox.Checked = p2.Default.mydeckbox;
            mylpbox.Checked = p2.Default.mylpbox;
            syncros.Checked = p2.Default.syncros;





            Profile1.ForeColor = Color.Gray;
            Profile2.ForeColor = Color.Green;
            Profile3.ForeColor = Color.Gray;
            Profile4.ForeColor = Color.Gray;
            Profile5.ForeColor = Color.Gray;
            Profile6.ForeColor = Color.Gray;
        }

        private void pictureBox9_Click(object sender, EventArgs e) // Profile 3 - Save
        {
            ///======================================================
            ///                 Profile 3 Save
            ///======================================================
            p3.Default.continmin = continmin.Text;
            p3.Default.continmax = continmax.Text;
            p3.Default.continresult = continresult.Text;
            p3.Default.enemydeck = enemydeck.Text;
            p3.Default.recoverlp = recoverlp.Text;
            p3.Default.mydeck = mydeck.Text;
            p3.Default.myhand = myhand.Text;
            p3.Default.mylp = mylp.Text;
            p3.Default.enemyhand = enemyhand.Text;
            p3.Default.skillusemission = skillusemission.Text;
            p3.Default.effectdamagevalue = effectdamagevalue.Text;
            p3.Default.normalsummon = normalsummon.Text;
            p3.Default.tributesummon = tributesummon.Text;
            p3.Default.specialsummon = specialsummon.Text;
            p3.Default.activatedspell = activatedspell.Text;
            p3.Default.continspells = continspells.Text;
            p3.Default.quickspells = quickspells.Text;
            p3.Default.activatedtraps = activatedtraps.Text;
            p3.Default.ns1 = normalsummon.Text;
            p3.Default.ritualsummon = ritualsummon.Text;
            p3.Default.countertraps = countertraps.Text;
            p3.Default.fieldspells = fieldspells.Text;
            p3.Default.equipspells = equipspells.Text;
            p3.Default.maxbattledamagemission = battledama.Text;
            p3.Default.fusionsummon = fusionsummon.Text;
            p3.Default.attacksm = attacksm.Text;

            p3.Default.min = mylpmin.Text;
            p3.Default.max = mylpmax.Text;
            // p3.Default.enemymin = enemymin.Text;
            p3.Default.mydeckmin = mydeckmin.Text;
            p3.Default.myhandmin = myhandmin.Text;
            p3.Default.enemyhand = enemyhand.Text;
            //p3.Default.recovermin = recovermin.Text;
            p3.Default.enemydeckmin = enemydeckmin.Text;
            p3.Default.enemyhandmin = enemyhandmin.Text;
            p3.Default.activatespellmin = activatespellmin.Text;
            p3.Default.activatetrapmin = activatetrapmin.Text;
            p3.Default.quickspellsmin = quickspellsmin.Text;
            p3.Default.fieldspellsmin = fieldspellsmin.Text;
            p3.Default.equipspellsmin = equipspellsmin.Text;
            p3.Default.continspellsmin = continspellsmin.Text;
            p3.Default.countertrapsmin = countertrapsmin.Text;
            p3.Default.normalsummonmin = normalsummonmin.Text;
            p3.Default.tributemin = tributemin.Text;
            p3.Default.specialmin = specialmin.Text;
            p3.Default.ritualmin = ritualmin.Text;
            p3.Default.fusionmin = fusionmin.Text;
            p3.Default.attacksmademin = attacksmademin.Text;
            p3.Default.skillsmin = skillsmin.Text;
            p3.Default.maxbdmin = mbdmin.Text;
            p3.Default.efdbdmmin = efdbdmmin.Text;
            // p3.Default.enemymax = enemymax.Text;
            p3.Default.mydeckmax = mydeckmax.Text;
            p3.Default.myhandmax = myhandmax.Text;
            p3.Default.enemyhand = enemyhand.Text;
            //p3.Default.recovermax = recovermax.Text;
            p3.Default.enemydeckmax = enemydeckmax.Text;
            p3.Default.enemyhandmax = enemyhandmax.Text;
            p3.Default.activatespellmax = activatespellmax.Text;
            p3.Default.activatetrapmax = activatetrapmax.Text;
            p3.Default.quickspellsmax = quickspellsmax.Text;
            p3.Default.fieldspellsmax = fieldspellsmax.Text;
            p3.Default.equipspellsmax = equipspellsmax.Text;
            p3.Default.continspellsmax = continspellsmax.Text;
            p3.Default.countertrapsmax = countertrapsmax.Text;
            p3.Default.normalsummonmax = normalsummonmax.Text;
            p3.Default.tributemax = tributemax.Text;
            p3.Default.specialmax = specialmax.Text;
            p3.Default.ritualmax = ritualmax.Text;
            p3.Default.fusionmax = fusionmax.Text;
            p3.Default.attacksmademax = attacksmademax.Text;
            p3.Default.skillsmax = skillsmax.Text;

            p3.Default.maxbdmax = mbdmax.Text;
            p3.Default.efdbdmmax = efdbdmmax.Text;
            p3.Default.enemylp = enemylp.Text;


            p3.Default.syncrosmin = syncrosmin.Text;
            p3.Default.syncrosmax = syncrosmax.Text;
            p3.Default.syncrosresult = syncrosresult.Text;


            p3.Default.turnsmin = turnsmin.Text;
            p3.Default.turnsmax = turnsmax.Text;
            p3.Default.turnsresult = turnsresult.Text;
            p3.Default.turns = turns.Checked;


            //Saving CheckBoxes.
            p3.Default.asBox = asBox.Checked;
            p3.Default.disablexor = disablexor.Checked;
            p3.Default.contintraps = contintraps.Checked;
            p3.Default.qsBox = qsBox.Checked;
            p3.Default.fssBox = fssBox.Checked;
            p3.Default.eqBox = eqBox.Checked;
            p3.Default.atBox = atBox.Checked;
            p3.Default.ctBox = ctBox.Checked;
            p3.Default.nsBox = nsBox.Checked;
            p3.Default.tsBox = tsBox.Checked;
            p3.Default.ssBox = ssBox.Checked;
            p3.Default.rsBox = rsBox.Checked;
            p3.Default.fsBox = fsBox.Checked;
            p3.Default.sumBox = sumBox.Checked;
            p3.Default.edBox = edBox.Checked;
            p3.Default.maxbdbox = maxbdbox.Checked;
            p3.Default.enemybox = enemybox.Checked;
            p3.Default.attacksmadebox = attacksmbox.Checked;
            p3.Default.enemyhandbox = enemyhandbox.Checked;
            p3.Default.enemydeckbox = enemydeckbox.Checked;
            p3.Default.RecoverLpBox = RecoverLpBox.Checked;
            p3.Default.myhandbox = myhandbox.Checked;
            p3.Default.mydeckbox = mydeckbox.Checked;
            p3.Default.mylpbox = mylpbox.Checked;
            p3.Default.syncros = syncros.Checked;
            p3.Default.Save();
            var msg = "Saved your Profile: " + Profile3.Text + "!";
            MessageBox.Show(msg, "Saved your Profile", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
        private void pictureBox8_Click(object sender, EventArgs e) // Profile 3 - Load
        {
            ///======================================================
            ///                 Profile 3 Load
            ///======================================================
            continmin.Text = p3.Default.continmin;
            continmax.Text = p3.Default.continmax;
            continresult.Text = p3.Default.continresult;
            recoverlp.Text = p3.Default.recoverlp;
            mydeck.Text = p3.Default.mydeck;
            myhand.Text = p3.Default.myhand;
            mylp.Text = p3.Default.mylp;
            enemyhand.Text = p3.Default.enemyhand;
            skillusemission.Text = p3.Default.skillusemission;
            effectdamagevalue.Text = p3.Default.effectdamagevalue;
            normalsummon.Text = p3.Default.normalsummon;
            tributesummon.Text = p3.Default.tributesummon;
            specialsummon.Text = p3.Default.specialsummon;
            activatedspell.Text = p3.Default.activatedspell;
            continspells.Text = p3.Default.continspells;
            quickspells.Text = p3.Default.quickspells;
            activatedtraps.Text = p3.Default.activatedtraps;
            normalsummon.Text = p3.Default.ns1;
            ritualsummon.Text = p3.Default.ritualsummon;
            countertraps.Text = p3.Default.countertraps;
            fieldspells.Text = p3.Default.fieldspells;
            equipspells.Text = p3.Default.equipspells;
            battledama.Text = p3.Default.maxbattledamagemission;
            fusionsummon.Text = p3.Default.fusionsummon;
            attacksm.Text = p3.Default.attacksm;


            mylpmin.Text = p3.Default.min;
            mylpmax.Text = p3.Default.max;
            //enemymax.Text = p3.Default.enemymax;
            mydeckmax.Text = p3.Default.mydeckmax;
            myhandmax.Text = p3.Default.myhandmax;
            //recovermax.Text = p3.Default.recovermax;
            enemydeckmax.Text = p3.Default.enemydeckmax;
            enemyhandmax.Text = p3.Default.enemyhandmax;
            activatespellmax.Text = p3.Default.activatespellmax;
            activatetrapmax.Text = p3.Default.activatetrapmax;
            quickspellsmax.Text = p3.Default.quickspellsmax;
            fieldspellsmax.Text = p3.Default.fieldspellsmax;
            equipspellsmax.Text = p3.Default.equipspellsmax;
            continspellsmax.Text = p3.Default.continspellsmax;
            countertrapsmax.Text = p3.Default.countertrapsmax;
            normalsummonmax.Text = p3.Default.normalsummonmax;
            tributemax.Text = p3.Default.tributemax;
            specialmax.Text = p3.Default.specialmax;
            ritualmax.Text = p3.Default.ritualmax;
            fusionmax.Text = p3.Default.fusionmax;
            attacksmademax.Text = p3.Default.attacksmademax;
            skillsmax.Text = p3.Default.skillsmax;

            mbdmax.Text = p3.Default.maxbdmax;
            efdbdmmax.Text = p3.Default.efdbdmmax;
            enemylp.Text = p3.Default.enemylp;


            //enemymin.Text = p3.Default.enemymin;
            mydeckmin.Text = p3.Default.mydeckmin;
            myhandmin.Text = p3.Default.myhandmin;
            //recovermin.Text = p3.Default.recovermin;
            enemydeckmin.Text = p3.Default.enemydeckmin;
            enemyhandmin.Text = p3.Default.enemyhandmin;
            activatespellmin.Text = p3.Default.activatespellmin;
            activatetrapmin.Text = p3.Default.activatetrapmin;
            quickspellsmin.Text = p3.Default.quickspellsmin;
            fieldspellsmin.Text = p3.Default.fieldspellsmin;
            equipspellsmin.Text = p3.Default.equipspellsmin;
            continspellsmin.Text = p3.Default.continspellsmin;
            countertrapsmin.Text = p3.Default.countertrapsmin;
            normalsummonmin.Text = p3.Default.normalsummonmin;
            tributemin.Text = p3.Default.tributemin;
            specialmin.Text = p3.Default.specialmin;
            ritualmin.Text = p3.Default.ritualmin;
            fusionmin.Text = p3.Default.fusionmin;
            attacksmademin.Text = p3.Default.attacksmademin;
            skillsmin.Text = p3.Default.skillsmin;
            mbdmin.Text = p3.Default.maxbdmin;
            efdbdmmin.Text = p3.Default.efdbdmmin;
            syncrosmin.Text = p3.Default.syncrosmin;
            syncrosmax.Text = p3.Default.syncrosmax;
            syncrosresult.Text = p3.Default.syncrosresult;



            turnsmin.Text = p3.Default.turnsmin;
            turnsmax.Text = p3.Default.turnsmax;
            turnsresult.Text = p3.Default.turnsresult;
            turns.Checked = p3.Default.turns;


            // Checkboxes.
            asBox.Checked = p3.Default.asBox;
            disablexor.Checked = p3.Default.disablexor;
            contintraps.Checked = p3.Default.contintraps;
            qsBox.Checked = p3.Default.qsBox;
            fssBox.Checked = p3.Default.fssBox;
            eqBox.Checked = p3.Default.eqBox;
            atBox.Checked = p3.Default.atBox;
            ctBox.Checked = p3.Default.ctBox;
            nsBox.Checked = p3.Default.nsBox;
            tsBox.Checked = p3.Default.tsBox;
            ssBox.Checked = p3.Default.ssBox;
            rsBox.Checked = p3.Default.rsBox;
            fsBox.Checked = p3.Default.fsBox;
            sumBox.Checked = p3.Default.sumBox;
            edBox.Checked = p3.Default.edBox;
            maxbdbox.Checked = p3.Default.maxbdbox;
            enemybox.Checked = p3.Default.enemybox;
            attacksmbox.Checked = p3.Default.attacksmadebox;
            enemyhandbox.Checked = p3.Default.enemyhandbox;
            enemydeckbox.Checked = p3.Default.enemydeckbox;
            RecoverLpBox.Checked = p3.Default.RecoverLpBox;
            myhandbox.Checked = p3.Default.myhandbox;
            mydeckbox.Checked = p3.Default.mydeckbox;
            mylpbox.Checked = p3.Default.mylpbox;
            syncros.Checked = p3.Default.syncros;



            Profile1.ForeColor = Color.Gray;
            Profile2.ForeColor = Color.Gray;
            Profile3.ForeColor = Color.Green;
            Profile4.ForeColor = Color.Gray;
            Profile5.ForeColor = Color.Gray;
            Profile6.ForeColor = Color.Gray;
        }

        private void pictureBox17_Click(object sender, EventArgs e) // Profile 4 - Save
        {
            ///======================================================
            ///                 Profile 4 Save
            ///======================================================   
            p4.Default.syncrosmin = syncrosmin.Text;
            p4.Default.syncrosmax = syncrosmax.Text;
            p4.Default.syncrosresult = syncrosresult.Text;
            p4.Default.continmin = continmin.Text;
            p4.Default.continmax = continmax.Text;
            p4.Default.continresult = continresult.Text;
            p4.Default.enemydeck = enemydeck.Text;
            p4.Default.recoverlp = recoverlp.Text;
            p4.Default.mydeck = mydeck.Text;
            p4.Default.myhand = myhand.Text;
            p4.Default.mylp = mylp.Text;
            p4.Default.enemyhand = enemyhand.Text;
            p4.Default.skillusemission = skillusemission.Text;
            p4.Default.effectdamagevalue = effectdamagevalue.Text;
            p4.Default.normalsummon = normalsummon.Text;
            p4.Default.tributesummon = tributesummon.Text;
            p4.Default.specialsummon = specialsummon.Text;
            p4.Default.activatedspell = activatedspell.Text;
            p4.Default.continspells = continspells.Text;
            p4.Default.quickspells = quickspells.Text;
            p4.Default.activatedtraps = activatedtraps.Text;
            p4.Default.ns1 = normalsummon.Text;
            p4.Default.ritualsummon = ritualsummon.Text;
            p4.Default.countertraps = countertraps.Text;
            p4.Default.fieldspells = fieldspells.Text;
            p4.Default.equipspells = equipspells.Text;
            p4.Default.maxbattledamagemission = battledama.Text;
            p4.Default.fusionsummon = fusionsummon.Text;
            p4.Default.attacksm = attacksm.Text;

            p4.Default.min = mylpmin.Text;
            p4.Default.max = mylpmax.Text;
            // p4.Default.enemymin = enemymin.Text;
            p4.Default.mydeckmin = mydeckmin.Text;
            p4.Default.myhandmin = myhandmin.Text;
            p4.Default.enemyhand = enemyhand.Text;
            //p4.Default.recovermin = recovermin.Text;
            p4.Default.enemydeckmin = enemydeckmin.Text;
            p4.Default.enemyhandmin = enemyhandmin.Text;
            p4.Default.activatespellmin = activatespellmin.Text;
            p4.Default.activatetrapmin = activatetrapmin.Text;
            p4.Default.quickspellsmin = quickspellsmin.Text;
            p4.Default.fieldspellsmin = fieldspellsmin.Text;
            p4.Default.equipspellsmin = equipspellsmin.Text;
            p4.Default.continspellsmin = continspellsmin.Text;
            p4.Default.countertrapsmin = countertrapsmin.Text;
            p4.Default.normalsummonmin = normalsummonmin.Text;
            p4.Default.tributemin = tributemin.Text;
            p4.Default.specialmin = specialmin.Text;
            p4.Default.ritualmin = ritualmin.Text;
            p4.Default.fusionmin = fusionmin.Text;
            p4.Default.attacksmademin = attacksmademin.Text;
            p4.Default.skillsmin = skillsmin.Text;
            p4.Default.maxbdmin = mbdmin.Text;
            p4.Default.efdbdmmin = efdbdmmin.Text;
            //  p4.Default.enemymax = enemymax.Text;
            p4.Default.mydeckmax = mydeckmax.Text;
            p4.Default.myhandmax = myhandmax.Text;
            p4.Default.enemyhand = enemyhand.Text;
            //p4.Default.recovermax = recovermax.Text;
            p4.Default.enemydeckmax = enemydeckmax.Text;
            p4.Default.enemyhandmax = enemyhandmax.Text;
            p4.Default.activatespellmax = activatespellmax.Text;
            p4.Default.activatetrapmax = activatetrapmax.Text;
            p4.Default.quickspellsmax = quickspellsmax.Text;
            p4.Default.fieldspellsmax = fieldspellsmax.Text;
            p4.Default.equipspellsmax = equipspellsmax.Text;
            p4.Default.continspellsmax = continspellsmax.Text;
            p4.Default.countertrapsmax = countertrapsmax.Text;
            p4.Default.normalsummonmax = normalsummonmax.Text;
            p4.Default.tributemax = tributemax.Text;
            p4.Default.specialmax = specialmax.Text;
            p4.Default.ritualmax = ritualmax.Text;
            p4.Default.fusionmax = fusionmax.Text;
            p4.Default.attacksmademax = attacksmademax.Text;
            p4.Default.skillsmax = skillsmax.Text;

            p4.Default.maxbdmax = mbdmax.Text;
            p4.Default.efdbdmmax = efdbdmmax.Text;
            p4.Default.enemylp = enemylp.Text;

            p4.Default.turnsmin = turnsmin.Text;
            p4.Default.turnsmax = turnsmax.Text;
            p4.Default.turnsresult = turnsresult.Text;
            p4.Default.turns = turns.Checked;


            //Saving CheckBoxes.
            p4.Default.syncros = syncros.Checked;
            p4.Default.disablexor = disablexor.Checked;
            p4.Default.contintraps = contintraps.Checked;
            p4.Default.asBox = asBox.Checked;
            p4.Default.csBox = csBox.Checked;
            p4.Default.qsBox = qsBox.Checked;
            p4.Default.fssBox = fssBox.Checked;
            p4.Default.eqBox = eqBox.Checked;
            p4.Default.atBox = atBox.Checked;
            p4.Default.ctBox = ctBox.Checked;
            p4.Default.nsBox = nsBox.Checked;
            p4.Default.tsBox = tsBox.Checked;
            p4.Default.ssBox = ssBox.Checked;
            p4.Default.rsBox = rsBox.Checked;
            p4.Default.fsBox = fsBox.Checked;
            p4.Default.sumBox = sumBox.Checked;
            p4.Default.edBox = edBox.Checked;
            p4.Default.maxbdbox = maxbdbox.Checked;
            p4.Default.enemybox = enemybox.Checked;
            p4.Default.attacksmadebox = attacksmbox.Checked;
            p4.Default.enemyhandbox = enemyhandbox.Checked;
            p4.Default.enemydeckbox = enemydeckbox.Checked;
            p4.Default.RecoverLpBox = RecoverLpBox.Checked;
            p4.Default.myhandbox = myhandbox.Checked;
            p4.Default.mydeckbox = mydeckbox.Checked;
            p4.Default.mylpbox = mylpbox.Checked;
            p4.Default.Save();


            var msg = "Saved your Profile: " + Profile4.Text + "!";
            MessageBox.Show(msg, "Saved your Profile", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
        private void pictureBox16_Click(object sender, EventArgs e) // Profile 4 - Load
        {
            ///======================================================
            ///                 Profile 4 Load
            ///======================================================
            ///
            syncrosmin.Text = p4.Default.syncrosmin;
            syncrosmax.Text = p4.Default.syncrosmax;
            syncrosresult.Text = p4.Default.syncrosresult;
            continmin.Text = p4.Default.continmin;
            continmax.Text = p4.Default.continmax;
            continresult.Text = p4.Default.continresult;
            enemydeck.Text = p4.Default.enemydeck;
            recoverlp.Text = p4.Default.recoverlp;
            mydeck.Text = p4.Default.mydeck;
            myhand.Text = p4.Default.myhand;
            mylp.Text = p4.Default.mylp;
            enemyhand.Text = p4.Default.enemyhand;
            skillusemission.Text = p4.Default.skillusemission;
            effectdamagevalue.Text = p4.Default.effectdamagevalue;
            normalsummon.Text = p4.Default.normalsummon;
            tributesummon.Text = p4.Default.tributesummon;
            specialsummon.Text = p4.Default.specialsummon;
            activatedspell.Text = p4.Default.activatedspell;
            continspells.Text = p4.Default.continspells;
            quickspells.Text = p4.Default.quickspells;
            activatedtraps.Text = p4.Default.activatedtraps;
            normalsummon.Text = p4.Default.ns1;
            ritualsummon.Text = p4.Default.ritualsummon;
            countertraps.Text = p4.Default.countertraps;
            fieldspells.Text = p4.Default.fieldspells;
            equipspells.Text = p4.Default.equipspells;
            battledama.Text = p4.Default.maxbattledamagemission;
            fusionsummon.Text = p4.Default.fusionsummon;
            attacksm.Text = p4.Default.attacksm;


            mylpmin.Text = p4.Default.min;
            mylpmax.Text = p4.Default.max;
            //enemymax.Text = p4.Default.enemymax;
            mydeckmax.Text = p4.Default.mydeckmax;
            myhandmax.Text = p4.Default.myhandmax;
            //recovermax.Text = p4.Default.recovermax;
            enemydeckmax.Text = p4.Default.enemydeckmax;
            enemyhandmax.Text = p4.Default.enemyhandmax;
            activatespellmax.Text = p4.Default.activatespellmax;
            activatetrapmax.Text = p4.Default.activatetrapmax;
            quickspellsmax.Text = p4.Default.quickspellsmax;
            fieldspellsmax.Text = p4.Default.fieldspellsmax;
            equipspellsmax.Text = p4.Default.equipspellsmax;
            continspellsmax.Text = p4.Default.continspellsmax;
            countertrapsmax.Text = p4.Default.countertrapsmax;
            normalsummonmax.Text = p4.Default.normalsummonmax;
            tributemax.Text = p4.Default.tributemax;
            specialmax.Text = p4.Default.specialmax;
            ritualmax.Text = p4.Default.ritualmax;
            fusionmax.Text = p4.Default.fusionmax;
            attacksmademax.Text = p4.Default.attacksmademax;
            skillsmax.Text = p4.Default.skillsmax;
            mbdmax.Text = p4.Default.maxbdmax;
            efdbdmmax.Text = p4.Default.efdbdmmax;
            enemylp.Text = p4.Default.enemylp;


            //enemymin.Text = p4.Default.enemymin;
            mydeckmin.Text = p4.Default.mydeckmin;
            myhandmin.Text = p4.Default.myhandmin;
            //recovermin.Text = p4.Default.recovermin;
            enemydeckmin.Text = p4.Default.enemydeckmin;
            enemyhandmin.Text = p4.Default.enemyhandmin;
            activatespellmin.Text = p4.Default.activatespellmin;
            activatetrapmin.Text = p4.Default.activatetrapmin;
            quickspellsmin.Text = p4.Default.quickspellsmin;
            fieldspellsmin.Text = p4.Default.fieldspellsmin;
            equipspellsmin.Text = p4.Default.equipspellsmin;
            continspellsmin.Text = p4.Default.continspellsmin;
            countertrapsmin.Text = p4.Default.countertrapsmin;
            normalsummonmin.Text = p4.Default.normalsummonmin;
            tributemin.Text = p4.Default.tributemin;
            specialmin.Text = p4.Default.specialmin;
            ritualmin.Text = p4.Default.ritualmin;
            fusionmin.Text = p4.Default.fusionmin;
            attacksmademin.Text = p4.Default.attacksmademin;
            skillsmin.Text = p4.Default.skillsmin;
            mbdmin.Text = p4.Default.maxbdmin;
            efdbdmmin.Text = p4.Default.efdbdmmin;




            turnsmin.Text = p4.Default.turnsmin;
            turnsmax.Text = p4.Default.turnsmax;
            turnsresult.Text = p4.Default.turnsresult;
            turns.Checked = p4.Default.turns;

            // Checkboxes.
            asBox.Checked = p4.Default.asBox;
            disablexor.Checked = p4.Default.disablexor;
            contintraps.Checked = p4.Default.contintraps;
            asBox.Checked = p4.Default.asBox;
            qsBox.Checked = p4.Default.qsBox;
            fssBox.Checked = p4.Default.fssBox;
            eqBox.Checked = p4.Default.eqBox;
            atBox.Checked = p4.Default.atBox;
            ctBox.Checked = p4.Default.ctBox;
            nsBox.Checked = p4.Default.nsBox;
            tsBox.Checked = p4.Default.tsBox;
            ssBox.Checked = p4.Default.ssBox;
            rsBox.Checked = p4.Default.rsBox;
            fsBox.Checked = p4.Default.fsBox;
            sumBox.Checked = p4.Default.sumBox;
            edBox.Checked = p4.Default.edBox;
            maxbdbox.Checked = p4.Default.maxbdbox;
            enemybox.Checked = p4.Default.enemybox;
            attacksmbox.Checked = p4.Default.attacksmadebox;
            enemyhandbox.Checked = p4.Default.enemyhandbox;
            enemydeckbox.Checked = p4.Default.enemydeckbox;
            RecoverLpBox.Checked = p4.Default.RecoverLpBox;
            myhandbox.Checked = p4.Default.myhandbox;
            mydeckbox.Checked = p4.Default.mydeckbox;
            mylpbox.Checked = p4.Default.mylpbox;
            syncros.Checked = p4.Default.syncros;



            Profile1.ForeColor = Color.Gray;
            Profile2.ForeColor = Color.Gray;
            Profile3.ForeColor = Color.Gray;
            Profile4.ForeColor = Color.Green;
            Profile5.ForeColor = Color.Gray;
            Profile6.ForeColor = Color.Gray;
        }

        private void pictureBox15_Click(object sender, EventArgs e) // Profile 5 - Save
        {
            ///======================================================
            ///                 Profile 5 Save
            ///======================================================  
            p5.Default.continmin = continmin.Text;
            p5.Default.continmax = continmax.Text;
            p5.Default.continresult = continresult.Text;
            p5.Default.enemydeck = enemydeck.Text;
            p5.Default.recoverlp = recoverlp.Text;
            p5.Default.mydeck = mydeck.Text;
            p5.Default.myhand = myhand.Text;
            p5.Default.mylp = mylp.Text;
            p5.Default.enemyhand = enemyhand.Text;
            p5.Default.skillusemission = skillusemission.Text;
            p5.Default.effectdamagevalue = effectdamagevalue.Text;
            p5.Default.normalsummon = normalsummon.Text;
            p5.Default.tributesummon = tributesummon.Text;
            p5.Default.specialsummon = specialsummon.Text;
            p5.Default.activatedspell = activatedspell.Text;
            p5.Default.continspells = continspells.Text;
            p5.Default.quickspells = quickspells.Text;
            p5.Default.activatedtraps = activatedtraps.Text;
            p5.Default.ns1 = normalsummon.Text;
            p5.Default.ritualsummon = ritualsummon.Text;
            p5.Default.countertraps = countertraps.Text;
            p5.Default.fieldspells = fieldspells.Text;
            p5.Default.equipspells = equipspells.Text;
            p5.Default.maxbattledamagemission = battledama.Text;
            p5.Default.fusionsummon = fusionsummon.Text;
            p5.Default.attacksm = attacksm.Text;

            p5.Default.min = mylpmin.Text;
            p5.Default.max = mylpmax.Text;
            // p5.Default.enemymin = enemymin.Text;
            p5.Default.mydeckmin = mydeckmin.Text;
            p5.Default.myhandmin = myhandmin.Text;
            p5.Default.enemyhand = enemyhand.Text;
            //p5.Default.recovermin = recovermin.Text;
            p5.Default.enemydeckmin = enemydeckmin.Text;
            p5.Default.enemyhandmin = enemyhandmin.Text;
            p5.Default.activatespellmin = activatespellmin.Text;
            p5.Default.activatetrapmin = activatetrapmin.Text;
            p5.Default.quickspellsmin = quickspellsmin.Text;
            p5.Default.fieldspellsmin = fieldspellsmin.Text;
            p5.Default.equipspellsmin = equipspellsmin.Text;
            p5.Default.continspellsmin = continspellsmin.Text;
            p5.Default.countertrapsmin = countertrapsmin.Text;
            p5.Default.normalsummonmin = normalsummonmin.Text;
            p5.Default.tributemin = tributemin.Text;
            p5.Default.specialmin = specialmin.Text;
            p5.Default.ritualmin = ritualmin.Text;
            p5.Default.fusionmin = fusionmin.Text;
            p5.Default.attacksmademin = attacksmademin.Text;
            p5.Default.skillsmin = skillsmin.Text;
            p5.Default.maxbdmin = mbdmin.Text;
            p5.Default.efdbdmmin = efdbdmmin.Text;
            // p5.Default.enemymax = enemymax.Text;
            p5.Default.mydeckmax = mydeckmax.Text;
            p5.Default.myhandmax = myhandmax.Text;
            p5.Default.enemyhand = enemyhand.Text;
            //p5.Default.recovermax = recovermax.Text;
            p5.Default.enemydeckmax = enemydeckmax.Text;
            p5.Default.enemyhandmax = enemyhandmax.Text;
            p5.Default.activatespellmax = activatespellmax.Text;
            p5.Default.activatetrapmax = activatetrapmax.Text;
            p5.Default.quickspellsmax = quickspellsmax.Text;
            p5.Default.fieldspellsmax = fieldspellsmax.Text;
            p5.Default.equipspellsmax = equipspellsmax.Text;
            p5.Default.continspellsmax = continspellsmax.Text;
            p5.Default.countertrapsmax = countertrapsmax.Text;
            p5.Default.normalsummonmax = normalsummonmax.Text;
            p5.Default.tributemax = tributemax.Text;
            p5.Default.specialmax = specialmax.Text;
            p5.Default.ritualmax = ritualmax.Text;
            p5.Default.fusionmax = fusionmax.Text;
            p5.Default.attacksmademax = attacksmademax.Text;
            p5.Default.skillsmax = skillsmax.Text;

            p5.Default.maxbdmax = mbdmax.Text;
            p5.Default.efdbdmmax = efdbdmmax.Text;
            p5.Default.enemylp = enemylp.Text;

            p5.Default.syncrosmin = syncrosmin.Text;
            p5.Default.syncrosmax = syncrosmax.Text;
            p5.Default.syncrosresult = syncrosresult.Text;


            p5.Default.turnsmin = turnsmin.Text;
            p5.Default.turnsmax = turnsmax.Text;
            p5.Default.turnsresult = turnsresult.Text;
            p5.Default.turns = turns.Checked;

            //Saving CheckBoxes.
            p5.Default.disablexor = disablexor.Checked;
            p5.Default.contintraps = contintraps.Checked;
            p5.Default.asBox = asBox.Checked;
            p5.Default.csBox = csBox.Checked;
            p5.Default.qsBox = qsBox.Checked;
            p5.Default.fssBox = fssBox.Checked;
            p5.Default.eqBox = eqBox.Checked;
            p5.Default.atBox = atBox.Checked;
            p5.Default.ctBox = ctBox.Checked;
            p5.Default.nsBox = nsBox.Checked;
            p5.Default.tsBox = tsBox.Checked;
            p5.Default.ssBox = ssBox.Checked;
            p5.Default.rsBox = rsBox.Checked;
            p5.Default.fsBox = fsBox.Checked;
            p5.Default.sumBox = sumBox.Checked;
            p5.Default.edBox = edBox.Checked;
            p5.Default.maxbdbox = maxbdbox.Checked;
            p5.Default.enemybox = enemybox.Checked;
            p5.Default.attacksmadebox = attacksmbox.Checked;
            p5.Default.enemyhandbox = enemyhandbox.Checked;
            p5.Default.enemydeckbox = enemydeckbox.Checked;
            p5.Default.RecoverLpBox = RecoverLpBox.Checked;
            p5.Default.myhandbox = myhandbox.Checked;
            p5.Default.mydeckbox = mydeckbox.Checked;
            p5.Default.mylpbox = mylpbox.Checked;
            p5.Default.syncros = syncros.Checked;
            p5.Default.Save();


            var msg = "Saved your Profile: " + Profile5.Text + "!";
            MessageBox.Show(msg, "Saved your Profile", MessageBoxButtons.OK, MessageBoxIcon.None);

        }
        private void pictureBox14_Click(object sender, EventArgs e) // Profile 5 - Load
        {
            ///======================================================
            ///                 Profile 5 Load
            ///======================================================
            continmin.Text = p5.Default.continmin;
            continmax.Text = p5.Default.continmax;
            continresult.Text = p5.Default.continresult;
            enemydeck.Text = p5.Default.enemydeck;
            recoverlp.Text = p5.Default.recoverlp;
            mydeck.Text = p5.Default.mydeck;
            myhand.Text = p5.Default.myhand;
            mylp.Text = p5.Default.mylp;
            enemyhand.Text = p5.Default.enemyhand;
            skillusemission.Text = p5.Default.skillusemission;
            effectdamagevalue.Text = p5.Default.effectdamagevalue;
            normalsummon.Text = p5.Default.normalsummon;
            tributesummon.Text = p5.Default.tributesummon;
            specialsummon.Text = p5.Default.specialsummon;
            activatedspell.Text = p5.Default.activatedspell;
            continspells.Text = p5.Default.continspells;
            quickspells.Text = p5.Default.quickspells;
            activatedtraps.Text = p5.Default.activatedtraps;
            normalsummon.Text = p5.Default.ns1;
            ritualsummon.Text = p5.Default.ritualsummon;
            countertraps.Text = p5.Default.countertraps;
            fieldspells.Text = p5.Default.fieldspells;
            equipspells.Text = p5.Default.equipspells;
            battledama.Text = p5.Default.maxbattledamagemission;
            fusionsummon.Text = p5.Default.fusionsummon;
            attacksm.Text = p5.Default.attacksm;


            mylpmin.Text = p5.Default.min;
            mylpmax.Text = p5.Default.max;
            //enemymax.Text = p5.Default.enemymax;
            mydeckmax.Text = p5.Default.mydeckmax;
            myhandmax.Text = p5.Default.myhandmax;
            //recovermax.Text = p5.Default.recovermax;
            enemydeckmax.Text = p5.Default.enemydeckmax;
            enemyhandmax.Text = p5.Default.enemyhandmax;
            activatespellmax.Text = p5.Default.activatespellmax;
            activatetrapmax.Text = p5.Default.activatetrapmax;
            quickspellsmax.Text = p5.Default.quickspellsmax;
            fieldspellsmax.Text = p5.Default.fieldspellsmax;
            equipspellsmax.Text = p5.Default.equipspellsmax;
            continspellsmax.Text = p5.Default.continspellsmax;
            countertrapsmax.Text = p5.Default.countertrapsmax;
            normalsummonmax.Text = p5.Default.normalsummonmax;
            tributemax.Text = p5.Default.tributemax;
            specialmax.Text = p5.Default.specialmax;
            ritualmax.Text = p5.Default.ritualmax;
            fusionmax.Text = p5.Default.fusionmax;
            attacksmademax.Text = p5.Default.attacksmademax;
            skillsmax.Text = p5.Default.skillsmax;
            mbdmax.Text = p5.Default.maxbdmax;
            efdbdmmax.Text = p5.Default.efdbdmmax;
            enemylp.Text = p5.Default.enemylp;


            //enemymin.Text = p5.Default.enemymin;
            mydeckmin.Text = p5.Default.mydeckmin;
            myhandmin.Text = p5.Default.myhandmin;
            //recovermin.Text = p5.Default.recovermin;
            enemydeckmin.Text = p5.Default.enemydeckmin;
            enemyhandmin.Text = p5.Default.enemyhandmin;
            activatespellmin.Text = p5.Default.activatespellmin;
            activatetrapmin.Text = p5.Default.activatetrapmin;
            quickspellsmin.Text = p5.Default.quickspellsmin;
            fieldspellsmin.Text = p5.Default.fieldspellsmin;
            equipspellsmin.Text = p5.Default.equipspellsmin;
            continspellsmin.Text = p5.Default.continspellsmin;
            countertrapsmin.Text = p5.Default.countertrapsmin;
            normalsummonmin.Text = p5.Default.normalsummonmin;
            tributemin.Text = p5.Default.tributemin;
            specialmin.Text = p5.Default.specialmin;
            ritualmin.Text = p5.Default.ritualmin;
            fusionmin.Text = p5.Default.fusionmin;
            attacksmademin.Text = p5.Default.attacksmademin;
            skillsmin.Text = p5.Default.skillsmin;
            mbdmin.Text = p5.Default.maxbdmin;
            efdbdmmin.Text = p5.Default.efdbdmmin;
            syncrosmin.Text = p5.Default.syncrosmin;
            syncrosmax.Text = p5.Default.syncrosmax;
            syncrosresult.Text = p5.Default.syncrosresult;



            turnsmin.Text = p5.Default.turnsmin;
            turnsmax.Text = p5.Default.turnsmax;
            turnsresult.Text = p5.Default.turnsresult;
            turns.Checked = p5.Default.turns;


            // Checkboxes.
            syncros.Checked = p5.Default.syncros;
            asBox.Checked = p5.Default.asBox;
            disablexor.Checked = p5.Default.disablexor;
            contintraps.Checked = p5.Default.contintraps;
            asBox.Checked = p5.Default.asBox;
            qsBox.Checked = p5.Default.qsBox;
            fssBox.Checked = p5.Default.fssBox;
            eqBox.Checked = p5.Default.eqBox;
            atBox.Checked = p5.Default.atBox;
            ctBox.Checked = p5.Default.ctBox;
            nsBox.Checked = p5.Default.nsBox;
            tsBox.Checked = p5.Default.tsBox;
            ssBox.Checked = p5.Default.ssBox;
            rsBox.Checked = p5.Default.rsBox;
            fsBox.Checked = p5.Default.fsBox;
            sumBox.Checked = p5.Default.sumBox;
            edBox.Checked = p5.Default.edBox;
            maxbdbox.Checked = p5.Default.maxbdbox;
            enemybox.Checked = p5.Default.enemybox;
            attacksmbox.Checked = p5.Default.attacksmadebox;
            enemyhandbox.Checked = p5.Default.enemyhandbox;
            enemydeckbox.Checked = p5.Default.enemydeckbox;
            RecoverLpBox.Checked = p5.Default.RecoverLpBox;
            myhandbox.Checked = p5.Default.myhandbox;
            mydeckbox.Checked = p5.Default.mydeckbox;
            mylpbox.Checked = p5.Default.mylpbox;



            Profile1.ForeColor = Color.Gray;
            Profile2.ForeColor = Color.Gray;
            Profile3.ForeColor = Color.Gray;
            Profile4.ForeColor = Color.Gray;
            Profile5.ForeColor = Color.Green;
            Profile6.ForeColor = Color.Gray;
        }

        private void pictureBox13_Click(object sender, EventArgs e) // Profile 6 - save
        {
            ///======================================================
            ///                 Profile 6 Save
            ///====================================================== 
            p6.Default.continmin = continmin.Text;
            p6.Default.continmax = continmax.Text;
            p6.Default.continresult = continresult.Text;
            p6.Default.enemydeck = enemydeck.Text;
            p6.Default.recoverlp = recoverlp.Text;
            p6.Default.mydeck = mydeck.Text;
            p6.Default.myhand = myhand.Text;
            p6.Default.mylp = mylp.Text;
            p6.Default.enemyhand = enemyhand.Text;
            p6.Default.skillusemission = skillusemission.Text;
            p6.Default.effectdamagevalue = effectdamagevalue.Text;
            p6.Default.normalsummon = normalsummon.Text;
            p6.Default.tributesummon = tributesummon.Text;
            p6.Default.specialsummon = specialsummon.Text;
            p6.Default.activatedspell = activatedspell.Text;
            p6.Default.continspells = continspells.Text;
            p6.Default.quickspells = quickspells.Text;
            p6.Default.activatedtraps = activatedtraps.Text;
            p6.Default.ns1 = normalsummon.Text;
            p6.Default.ritualsummon = ritualsummon.Text;
            p6.Default.countertraps = countertraps.Text;
            p6.Default.fieldspells = fieldspells.Text;
            p6.Default.equipspells = equipspells.Text;
            p6.Default.maxbattledamagemission = battledama.Text;
            p6.Default.fusionsummon = fusionsummon.Text;
            p6.Default.attacksm = attacksm.Text;

            p6.Default.min = mylpmin.Text;
            p6.Default.max = mylpmax.Text;
            // p6.Default.enemymin = enemymin.Text;
            p6.Default.mydeckmin = mydeckmin.Text;
            p6.Default.myhandmin = myhandmin.Text;
            p6.Default.enemyhand = enemyhand.Text;
            //p6.Default.recovermin = recovermin.Text;
            p6.Default.enemydeckmin = enemydeckmin.Text;
            p6.Default.enemyhandmin = enemyhandmin.Text;
            p6.Default.activatespellmin = activatespellmin.Text;
            p6.Default.activatetrapmin = activatetrapmin.Text;
            p6.Default.quickspellsmin = quickspellsmin.Text;
            p6.Default.fieldspellsmin = fieldspellsmin.Text;
            p6.Default.equipspellsmin = equipspellsmin.Text;
            p6.Default.continspellsmin = continspellsmin.Text;
            p6.Default.countertrapsmin = countertrapsmin.Text;
            p6.Default.normalsummonmin = normalsummonmin.Text;
            p6.Default.tributemin = tributemin.Text;
            p6.Default.specialmin = specialmin.Text;
            p6.Default.ritualmin = ritualmin.Text;
            p6.Default.fusionmin = fusionmin.Text;
            p6.Default.attacksmademin = attacksmademin.Text;
            p6.Default.skillsmin = skillsmin.Text;
            p6.Default.maxbdmin = mbdmin.Text;
            p6.Default.efdbdmmin = efdbdmmin.Text;
            // p6.Default.enemymax = enemymax.Text;
            p6.Default.mydeckmax = mydeckmax.Text;
            p6.Default.myhandmax = myhandmax.Text;
            p6.Default.enemyhand = enemyhand.Text;
            //p6.Default.recovermax = recovermax.Text;
            p6.Default.enemydeckmax = enemydeckmax.Text;
            p6.Default.enemyhandmax = enemyhandmax.Text;
            p6.Default.activatespellmax = activatespellmax.Text;
            p6.Default.activatetrapmax = activatetrapmax.Text;
            p6.Default.quickspellsmax = quickspellsmax.Text;
            p6.Default.fieldspellsmax = fieldspellsmax.Text;
            p6.Default.equipspellsmax = equipspellsmax.Text;
            p6.Default.continspellsmax = continspellsmax.Text;
            p6.Default.countertrapsmax = countertrapsmax.Text;
            p6.Default.normalsummonmax = normalsummonmax.Text;
            p6.Default.tributemax = tributemax.Text;
            p6.Default.specialmax = specialmax.Text;
            p6.Default.ritualmax = ritualmax.Text;
            p6.Default.fusionmax = fusionmax.Text;
            p6.Default.attacksmademax = attacksmademax.Text;
            p6.Default.skillsmax = skillsmax.Text;
            p6.Default.maxbdmax = mbdmax.Text;
            p6.Default.efdbdmmax = efdbdmmax.Text;
            p6.Default.enemylp = enemylp.Text;
            p6.Default.syncrosmin = syncrosmin.Text;
            p6.Default.syncrosmax = syncrosmax.Text;
            p6.Default.syncrosresult = syncrosresult.Text;


            p6.Default.turnsmin = turnsmin.Text;
            p6.Default.turnsmax = turnsmax.Text;
            p6.Default.turnsresult = turnsresult.Text;
            p6.Default.turns = turns.Checked;

            //Saving CheckBoxes.
            p6.Default.disablexor = disablexor.Checked;
            p6.Default.contintraps = contintraps.Checked;
            p6.Default.asBox = asBox.Checked;
            p6.Default.csBox = csBox.Checked;
            p6.Default.qsBox = qsBox.Checked;
            p6.Default.fssBox = fssBox.Checked;
            p6.Default.eqBox = eqBox.Checked;
            p6.Default.atBox = atBox.Checked;
            p6.Default.ctBox = ctBox.Checked;
            p6.Default.nsBox = nsBox.Checked;
            p6.Default.tsBox = tsBox.Checked;
            p6.Default.ssBox = ssBox.Checked;
            p6.Default.rsBox = rsBox.Checked;
            p6.Default.fsBox = fsBox.Checked;
            p6.Default.sumBox = sumBox.Checked;
            p6.Default.edBox = edBox.Checked;
            p6.Default.maxbdbox = maxbdbox.Checked;
            p6.Default.enemybox = enemybox.Checked;
            p6.Default.attacksmadebox = attacksmbox.Checked;
            p6.Default.enemyhandbox = enemyhandbox.Checked;
            p6.Default.enemydeckbox = enemydeckbox.Checked;
            p6.Default.RecoverLpBox = RecoverLpBox.Checked;
            p6.Default.myhandbox = myhandbox.Checked;
            p6.Default.mydeckbox = mydeckbox.Checked;
            p6.Default.mylpbox = mylpbox.Checked;
            p6.Default.syncros = syncros.Checked;
            p6.Default.Save();


            var msg = "Saved your Profile: " + Profile6.Text + "!";
            MessageBox.Show(msg, "Saved your Profile", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
        private void pictureBox12_Click(object sender, EventArgs e) // Profile 6 - Load
        {
            ///======================================================
            ///                 Profile 6 Load
            ///======================================================
            continmin.Text = p6.Default.continmin;
            continmax.Text = p6.Default.continmax;
            continresult.Text = p6.Default.continresult;
            enemydeck.Text = p6.Default.enemydeck;
            recoverlp.Text = p6.Default.recoverlp;
            mydeck.Text = p6.Default.mydeck;
            myhand.Text = p6.Default.myhand;
            mylp.Text = p6.Default.mylp;
            enemyhand.Text = p6.Default.enemyhand;
            skillusemission.Text = p6.Default.skillusemission;
            effectdamagevalue.Text = p6.Default.effectdamagevalue;
            normalsummon.Text = p6.Default.normalsummon;
            tributesummon.Text = p6.Default.tributesummon;
            specialsummon.Text = p6.Default.specialsummon;
            activatedspell.Text = p6.Default.activatedspell;
            continspells.Text = p6.Default.continspells;
            quickspells.Text = p6.Default.quickspells;
            activatedtraps.Text = p6.Default.activatedtraps;
            normalsummon.Text = p6.Default.ns1;
            ritualsummon.Text = p6.Default.ritualsummon;
            countertraps.Text = p6.Default.countertraps;
            fieldspells.Text = p6.Default.fieldspells;
            equipspells.Text = p6.Default.equipspells;
            battledama.Text = p6.Default.maxbattledamagemission;
            fusionsummon.Text = p6.Default.fusionsummon;
            attacksm.Text = p6.Default.attacksm;


            mylpmin.Text = p6.Default.min;
            mylpmax.Text = p6.Default.max;
            //enemymax.Text = p6.Default.enemymax;
            mydeckmax.Text = p6.Default.mydeckmax;
            myhandmax.Text = p6.Default.myhandmax;
            //recovermax.Text = p6.Default.recovermax;
            enemydeckmax.Text = p6.Default.enemydeckmax;
            enemyhandmax.Text = p6.Default.enemyhandmax;
            activatespellmax.Text = p6.Default.activatespellmax;
            activatetrapmax.Text = p6.Default.activatetrapmax;
            quickspellsmax.Text = p6.Default.quickspellsmax;
            fieldspellsmax.Text = p6.Default.fieldspellsmax;
            equipspellsmax.Text = p6.Default.equipspellsmax;
            continspellsmax.Text = p6.Default.continspellsmax;
            countertrapsmax.Text = p6.Default.countertrapsmax;
            normalsummonmax.Text = p6.Default.normalsummonmax;
            tributemax.Text = p6.Default.tributemax;
            specialmax.Text = p6.Default.specialmax;
            ritualmax.Text = p6.Default.ritualmax;
            fusionmax.Text = p6.Default.fusionmax;
            attacksmademax.Text = p6.Default.attacksmademax;
            skillsmax.Text = p6.Default.skillsmax;
            mbdmax.Text = p6.Default.maxbdmax;
            efdbdmmax.Text = p6.Default.efdbdmmax;
            enemylp.Text = p6.Default.enemylp;


            //enemymin.Text = p6.Default.enemymin;
            mydeckmin.Text = p6.Default.mydeckmin;
            myhandmin.Text = p6.Default.myhandmin;
            //recovermin.Text = p6.Default.recovermin;
            enemydeckmin.Text = p6.Default.enemydeckmin;
            enemyhandmin.Text = p6.Default.enemyhandmin;
            activatespellmin.Text = p6.Default.activatespellmin;
            activatetrapmin.Text = p6.Default.activatetrapmin;
            quickspellsmin.Text = p6.Default.quickspellsmin;
            fieldspellsmin.Text = p6.Default.fieldspellsmin;
            equipspellsmin.Text = p6.Default.equipspellsmin;
            continspellsmin.Text = p6.Default.continspellsmin;
            countertrapsmin.Text = p6.Default.countertrapsmin;
            normalsummonmin.Text = p6.Default.normalsummonmin;
            tributemin.Text = p6.Default.tributemin;
            specialmin.Text = p6.Default.specialmin;
            ritualmin.Text = p6.Default.ritualmin;
            fusionmin.Text = p6.Default.fusionmin;
            attacksmademin.Text = p6.Default.attacksmademin;
            skillsmin.Text = p6.Default.skillsmin;
            mbdmin.Text = p6.Default.maxbdmin;
            efdbdmmin.Text = p6.Default.efdbdmmin;
            syncrosmin.Text = p6.Default.syncrosmin;
            syncrosmax.Text = p6.Default.syncrosmax;
            syncrosresult.Text = p6.Default.syncrosresult;



            turnsmin.Text = p6.Default.turnsmin;
            turnsmax.Text = p6.Default.turnsmax;
            turnsresult.Text = p6.Default.turnsresult;
            turns.Checked = p6.Default.turns;


            // Checkboxes.
            asBox.Checked = p6.Default.asBox;
            disablexor.Checked = p6.Default.disablexor;
            contintraps.Checked = p6.Default.contintraps;
            asBox.Checked = p6.Default.asBox;
            csBox.Checked = p6.Default.csBox;
            qsBox.Checked = p6.Default.qsBox;
            fssBox.Checked = p6.Default.fssBox;
            eqBox.Checked = p6.Default.eqBox;
            atBox.Checked = p6.Default.atBox;
            ctBox.Checked = p6.Default.ctBox;
            nsBox.Checked = p6.Default.nsBox;
            tsBox.Checked = p6.Default.tsBox;
            ssBox.Checked = p6.Default.ssBox;
            rsBox.Checked = p6.Default.rsBox;
            fsBox.Checked = p6.Default.fsBox;
            sumBox.Checked = p6.Default.sumBox;
            edBox.Checked = p6.Default.edBox;
            maxbdbox.Checked = p6.Default.maxbdbox;
            enemybox.Checked = p6.Default.enemybox;
            attacksmbox.Checked = p6.Default.attacksmadebox;
            enemyhandbox.Checked = p6.Default.enemyhandbox;
            enemydeckbox.Checked = p6.Default.enemydeckbox;
            RecoverLpBox.Checked = p6.Default.RecoverLpBox;
            myhandbox.Checked = p6.Default.myhandbox;
            mydeckbox.Checked = p6.Default.mydeckbox;
            mylpbox.Checked = p6.Default.mylpbox;
            syncros.Checked = p6.Default.syncros;




            Profile2.ForeColor = Color.Gray;
            Profile1.ForeColor = Color.Gray;
            Profile3.ForeColor = Color.Gray;
            Profile4.ForeColor = Color.Gray;
            Profile5.ForeColor = Color.Gray;
            Profile6.ForeColor = Color.Green;

        }


        ///======================================================
        ///                 RESET USER SETTINGS
        ///======================================================
        private void resetsettings_Click(object sender, EventArgs e) // Reset User Settings
        {

            // Reset TextBoxes         
            attacksm.ResetText();
            enemydeck.ResetText();
            recoverlp.ResetText();
            mydeck.ResetText();
            myhand.ResetText();
            mylp.ResetText();
            enemyhand.ResetText();
            skillusemission.ResetText();
            effectdamagevalue.ResetText();
            normalsummon.ResetText();
            tributesummon.ResetText();
            specialsummon.ResetText();
            activatedspell.ResetText();
            continspells.ResetText();
            quickspells.ResetText();
            activatedtraps.ResetText();
            normalsummon.ResetText();
            ritualsummon.ResetText();
            countertraps.ResetText();
            fieldspells.ResetText();
            equipspells.ResetText();
            battledama.ResetText();
            fusionsummon.ResetText();
            enemylp.ResetText();
            mylpmin.ResetText();
            mylpmax.ResetText();
            //enemymin.ResetText();
            mydeckmin.ResetText();
            myhandmin.ResetText();
            //recovermin.ResetText();
            enemydeckmin.ResetText();
            enemyhandmin.ResetText();
            activatespellmin.ResetText();
            activatetrapmin.ResetText();
            quickspellsmin.ResetText();
            fieldspellsmin.ResetText();
            equipspellsmin.ResetText();
            continspellsmin.ResetText();
            countertrapsmin.ResetText();
            normalsummonmin.ResetText();
            tributemin.ResetText();
            specialmin.ResetText();
            ritualmin.ResetText();
            fusionmin.ResetText();
            attacksmademin.ResetText();
            skillsmin.ResetText();
            mbdmin.ResetText();
            efdbdmmin.ResetText();
            //enemymax.ResetText();
            mydeckmax.ResetText();
            myhandmax.ResetText();
            //recovermax.ResetText();
            enemydeckmax.ResetText();
            enemyhandmax.ResetText();
            activatespellmax.ResetText();
            activatetrapmax.ResetText();
            quickspellsmax.ResetText();
            fieldspellsmax.ResetText();
            equipspellsmax.ResetText();
            continspellsmax.ResetText();
            countertrapsmax.ResetText();
            normalsummonmax.ResetText();
            tributemax.ResetText();
            specialmax.ResetText();
            ritualmax.ResetText();
            fusionmax.ResetText();
            attacksmademax.ResetText();
            skillsmax.ResetText();
            mbdmax.ResetText();
            efdbdmmax.ResetText();
            continmin.ResetText();
            continmax.ResetText();
            continresult.ResetText();
            syncrosmin.ResetText();
            syncrosmax.ResetText();
            syncrosresult.ResetText();
            turnsmin.ResetText();
            turnsmax.ResetText();
            turnsresult.ResetText();


            // Reset Checkboxes  
            disablexor.Checked = false;
            contintraps.Checked = false;
            asBox.Checked = false;
            csBox.Checked = false;
            qsBox.Checked = false;
            fssBox.Checked = false;
            eqBox.Checked = false;
            syncros.Checked = false;
            atBox.Checked = false;
            ctBox.Checked = false;
            nsBox.Checked = false;
            tsBox.Checked = false;
            ssBox.Checked = false;
            rsBox.Checked = false;
            fsBox.Checked = false;
            sumBox.Checked = false;
            edBox.Checked = false;
            maxbdbox.Checked = false;
            enemybox.Checked = false;
            attacksmbox.Checked = false;
            mylpbox.Checked = false;
            mydeckbox.Checked = false;
            myhandbox.Checked = false;
            RecoverLpBox.Checked = false;
            enemydeckbox.Checked = false;
            enemyhandbox.Checked = false;
            turns.Checked = false;
        }

        ///======================================================
        ///            CRACKING SOFTWARE CHECKS
        ///======================================================
        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e) // Check for Cracking Softwares
        {
            //Process[] pname = Process.GetProcessesByName("dnSpy");
            //if (pname.Length > 0)
            //{
            //    Application.Exit();
            //}
            //Process[] dnSpy = Process.GetProcessesByName("dnSpy-x86");
            //if (dnSpy.Length > 0)
            //{
            //    Application.Exit();
            //}
            //Process[] dnSpyx64 = Process.GetProcessesByName("dnSpy-x64");
            //if (dnSpyx64.Length > 0)
            //{
            //    Application.Exit();
            //}
            //Process[] pname2 = Process.GetProcessesByName("ILSpy");
            //if (pname2.Length > 0)
            //{
            //    Application.Exit();
            //}
            //Process[] pname3 = Process.GetProcessesByName("Reflector");
            //if (pname3.Length > 0)
            //{
            //    Application.Exit();
            //}
            //Process[] pname4 = Process.GetProcessesByName("JustDecompile");
            //if (pname4.Length > 0)
            //{
            //    Application.Exit();
            //}
            //Process[] pname5 = Process.GetProcessesByName("ProcessHacker");
            //if (pname5.Length > 0)
            //{
            //    Application.Exit();
            //}
            //Process[] pname10 = Process.GetProcessesByName("peview");
            //if (pname10.Length > 0)
            //{
            //    Application.Exit();
            //}
            //Process[] pname6 = Process.GetProcessesByName("Wireshark");
            //if (pname6.Length > 0)
            //{
            //    Application.Exit();
            //}
            //Process[] pname7 = Process.GetProcessesByName("Fiddler");
            //if (pname7.Length > 0)
            //{
            //    Application.Exit();
            //}
            //Process[] pname8 = Process.GetProcessesByName("de4dot");
            //if (pname8.Length > 0)
            //{
            //    Application.Exit();
            //}
            //Process[] pname9 = Process.GetProcessesByName("de4dot-x64");
            //if (pname9.Length > 0)
            //{
            //    Application.Exit();
            //}
            //Process[] pname11 = Process.GetProcessesByName("dotPeek64");
            //if (pname11.Length > 0)
            //{
            //    Application.Exit();
            //}
            //Process[] pname12 = Process.GetProcessesByName("dotPeek32");
            //if (pname12.Length > 0)
            //{
            //    Application.Exit();
            //}
            //Process[] pname13 = Process.GetProcessesByName("Dile");
            //if (pname13.Length > 0)
            //{
            //    Application.Exit();
            //}
            //Process[] pname14 = Process.GetProcessesByName("OLLYDBG");
            //if (pname14.Length > 0)
            //{
            //    Application.Exit();
            //}            

        }



        ///======================================================
        ///    BACKGROUNDWORKER - CRACKING SOFTWARE CHECKS
        ///======================================================
        private void timer2_Tick(object sender, EventArgs e) // Background Check for Cracking Softwares
        {
            if (!backgroundWorker3.IsBusy)
                backgroundWorker3.RunWorkerAsync();
        }

        ///======================================================
        ///                PROGRAMM CLOSING
        ///======================================================
        private async void Multitool_FormClosing(object sender, FormClosingEventArgs e) // Close Application
        {

        ///KILL SPEEDHACK PROCESS           
        Process[] prs = Process.GetProcesses();
            foreach (Process pr in prs)
            {
                if (pr.ProcessName == "A3E5")
                {

                    pr.Kill();

                }

            }
            Thread.Sleep(500);
            string[] t = Directory.GetFiles(Environment.CurrentDirectory, "A3E5.exe");
            Array.ForEach(t, File.Delete);


            long aobscanaddr100 = (await m.AoBScan("CB E8 82 FC FF FF E9")).FirstOrDefault(); // Skip duel
            m.writeMemory(aobscanaddr100.ToString("x4"), "bytes", "CB E8 72 04 00 00 E9");

            long aobscanaddr101 = (await m.AoBScan("24 20 B8 01 00 00 00 85 C0 0F 9F")).FirstOrDefault(); // PVE Reveal
            m.writeMemory(aobscanaddr101.ToString("x4"), "bytes", "24 20 E8 19 AD FF FF 85 C0 0F 9F");

            long aobscanaddr102 = (await m.AoBScan("24 20 B8 01 00 00 00 48 8B 5C 24 40")).FirstOrDefault(); // PVP Reveal
            m.writeMemory(aobscanaddr102.ToString("x4"), "bytes", "24 20 E8 4B 6F 00 00 48 8B 5C 24 40");

            ///SAVE DEFAULT USER SETTINGS
            //  Settings.Default.enemymin = enemymin.Text;
            //  Settings.Default.enemymax = enemymax.Text;
            Settings.Default.enemymax = enemylp.Text;
            Settings.Default.mylpmin = mylpmin.Text;
            Settings.Default.mylpmax = mylpmax.Text;
            Settings.Default.mylp = mylp.Text;
            //Settings.Default.recovermin = recovermin.Text;
            //Settings.Default.recovermax = recovermax.Text;
            Settings.Default.recoverlp = recoverlp.Text;
            Settings.Default.mydeckmin = mydeckmin.Text;
            Settings.Default.mydeckmax = mydeckmax.Text;
            Settings.Default.mydeck = mydeck.Text;
            Settings.Default.myhandmin = myhandmin.Text;
            Settings.Default.myhandmax = myhandmax.Text;
            Settings.Default.myhand = myhand.Text;
            Settings.Default.enemydeckmin = enemydeckmin.Text;
            Settings.Default.enemydeckmax = enemydeckmax.Text;
            Settings.Default.enemydeck = enemydeck.Text;
            Settings.Default.enemyhandmin = enemyhandmin.Text;
            Settings.Default.enemyhandmax = enemyhandmax.Text;
            Settings.Default.enemyhand = enemyhand.Text;
            Settings.Default.continmin = continmin.Text;
            Settings.Default.continmax = continmax.Text;
            Settings.Default.continresult = continresult.Text;
            Settings.Default.Profile1 = Profile1.Text;
            Settings.Default.Profile2 = Profile2.Text;
            Settings.Default.Profile3 = Profile3.Text;
            Settings.Default.Profile4 = Profile4.Text;
            Settings.Default.Profile5 = Profile5.Text;
            Settings.Default.Profile6 = Profile6.Text;
            Settings.Default.skillusemission = skillusemission.Text;
            Settings.Default.effectdamagevalue = effectdamagevalue.Text;
            Settings.Default.normalsummon = normalsummon.Text;
            Settings.Default.tributesummon = tributesummon.Text;
            Settings.Default.specialsummon = specialsummon.Text;
            Settings.Default.activatedspell = activatedspell.Text;
            Settings.Default.continspells = continspells.Text;
            Settings.Default.quickspells = quickspells.Text;
            Settings.Default.activatedtraps = activatedtraps.Text;
            Settings.Default.ns1 = normalsummon.Text;
            Settings.Default.ritualsummon = ritualsummon.Text;
            Settings.Default.countertraps = countertraps.Text;
            Settings.Default.fieldspells = fieldspells.Text;
            Settings.Default.equipspells = equipspells.Text;
            Settings.Default.maxbattledamagemission = battledama.Text;
            Settings.Default.fusionsummon = fusionsummon.Text;
            Settings.Default.attacksm = attacksm.Text;
            Settings.Default.activatespellmin = activatespellmin.Text;
            Settings.Default.activatetrapmin = activatetrapmin.Text;
            Settings.Default.quickspellsmin = quickspellsmin.Text;
            Settings.Default.fieldspellsmin = fieldspellsmin.Text;
            Settings.Default.equipspellsmin = equipspellsmin.Text;
            Settings.Default.continspellsmin = continspellsmin.Text;
            Settings.Default.countertrapsmin = countertrapsmin.Text;
            Settings.Default.normalsummonmin = normalsummonmin.Text;
            Settings.Default.tributemin = tributemin.Text;
            Settings.Default.specialmin = specialmin.Text;
            Settings.Default.ritualmin = ritualmin.Text;
            Settings.Default.fusionmin = fusionmin.Text;
            Settings.Default.attacksmademin = attacksmademin.Text;
            Settings.Default.skillsmin = skillsmin.Text;
            Settings.Default.maxbdmin = mbdmin.Text;
            Settings.Default.efdbdmmin = efdbdmmin.Text;
            // Settings.Default.enemymax = enemymax.Text;
            Settings.Default.mydeckmax = mydeckmax.Text;
            Settings.Default.myhandmax = myhandmax.Text;
            Settings.Default.enemyhand = enemyhand.Text;
            //Settings.Default.recovermax = recovermax.Text;
            Settings.Default.enemydeckmax = enemydeckmax.Text;
            Settings.Default.enemyhandmax = enemyhandmax.Text;
            Settings.Default.activatespellmax = activatespellmax.Text;
            Settings.Default.activatetrapmax = activatetrapmax.Text;
            Settings.Default.quickspellsmax = quickspellsmax.Text;
            Settings.Default.fieldspellsmax = fieldspellsmax.Text;
            Settings.Default.equipspellsmax = equipspellsmax.Text;
            Settings.Default.continspellsmax = continspellsmax.Text;
            Settings.Default.countertrapsmax = countertrapsmax.Text;
            Settings.Default.normalsummonmax = normalsummonmax.Text;
            Settings.Default.tributemax = tributemax.Text;
            Settings.Default.specialmax = specialmax.Text;
            Settings.Default.ritualmax = ritualmax.Text;
            Settings.Default.fusionmax = fusionmax.Text;
            Settings.Default.attacksmademax = attacksmademax.Text;
            Settings.Default.skillsmax = skillsmax.Text;
            Settings.Default.maxbdmax = mbdmax.Text;
            Settings.Default.efdbdmmax = efdbdmmax.Text;
            Settings.Default.syncrosmin = syncrosmin.Text;
            Settings.Default.syncrosmax = syncrosmax.Text;
            Settings.Default.syncrosresult = syncrosresult.Text;

            Settings.Default.turnsmin = turnsmin.Text;
            Settings.Default.turnsmax = turnsmax.Text;
            Settings.Default.turnsresult = turnsresult.Text;

            //Saving CheckBoxes.
            Settings.Default.contintraps = contintraps.Checked;
            Settings.Default.asBox = asBox.Checked;
            Settings.Default.syncros = syncros.Checked;
            Settings.Default.csBox = csBox.Checked;
            Settings.Default.qsBox = qsBox.Checked;
            Settings.Default.fssBox = fssBox.Checked;
            Settings.Default.eqBox = eqBox.Checked;
            Settings.Default.atBox = atBox.Checked;
            Settings.Default.ctBox = ctBox.Checked;
            Settings.Default.nsBox = nsBox.Checked;
            Settings.Default.tsBox = tsBox.Checked;
            Settings.Default.ssBox = ssBox.Checked;
            Settings.Default.rsBox = rsBox.Checked;
            Settings.Default.fsBox = fsBox.Checked;
            Settings.Default.sumBox = sumBox.Checked;
            Settings.Default.syncros = syncros.Checked;
            Settings.Default.edBox = edBox.Checked;
            Settings.Default.maxbdbox = maxbdbox.Checked;
            Settings.Default.attacksmadebox = attacksmbox.Checked;
            Settings.Default.turns = turns.Checked;
            Settings.Default.Save();
        }

        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroCheckBox3_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {

        }

     
    }
}
