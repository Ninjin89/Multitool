using MetroFramework;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
namespace Multitool
{
    public partial class cards : MetroFramework.Forms.MetroForm
    {
        public cards()
        {
            InitializeComponent();
        }

        private void search_Click(object sender, EventArgs e)
        {
            metroSetRichTextBox1.ResetText();
            string searchfor = searchtext.Text;
            Assembly assm = Assembly.GetExecutingAssembly();
            using (Stream datastream = assm.GetManifestResourceStream("Multitool.Resources.cards.txt"))
            using (StreamReader reader = new StreamReader(datastream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(searchtext.Text))
                    {
                        MetroMessageBox.Show(this, "Please enter a Card name! Make sure it's case sensitive!", "Card not found!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        if (DialogResult != DialogResult.OK) return;
                    }
                    if (line.Contains(searchtext.Text))
                    {
                        metroSetRichTextBox1.Text += "\n" + line.ToString();
                    }
                }
            }
        }

        private void searchtext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                metroSetRichTextBox1.ResetText();
                string searchfor = searchtext.Text;
                Assembly assm = Assembly.GetExecutingAssembly();
                using (Stream datastream = assm.GetManifestResourceStream("Multitool.Resources.cards.txt"))
                using (StreamReader reader = new StreamReader(datastream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(searchtext.Text))
                        {
                            MetroMessageBox.Show(this, "Please enter a Card name! Make sure it's case sensitive!", "Card not found!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            if (DialogResult != DialogResult.OK) return;
                        }
                        if (line.Contains(searchtext.Text))
                        {
                            metroSetRichTextBox1.Text += "\n" + line.ToString();
                        }
                    }
                }
            }
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroCheckBox1_CheckedChanged_1(object sender, EventArgs e)
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
    }
}
