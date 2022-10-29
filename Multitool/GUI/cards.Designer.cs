namespace Multitool
{
    partial class cards
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cards));
            this.metroSetRichTextBox1 = new MetroSet_UI.Controls.MetroSetRichTextBox();
            this.search = new MetroFramework.Controls.MetroButton();
            this.searchtext = new MetroFramework.Controls.MetroTextBox();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.SuspendLayout();
            // 
            // metroSetRichTextBox1
            // 
            this.metroSetRichTextBox1.AutoWordSelection = false;
            this.metroSetRichTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.metroSetRichTextBox1.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.metroSetRichTextBox1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroSetRichTextBox1.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroSetRichTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.metroSetRichTextBox1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.metroSetRichTextBox1.Lines = null;
            this.metroSetRichTextBox1.Location = new System.Drawing.Point(21, 27);
            this.metroSetRichTextBox1.MaxLength = 32767;
            this.metroSetRichTextBox1.Name = "metroSetRichTextBox1";
            this.metroSetRichTextBox1.ReadOnly = false;
            this.metroSetRichTextBox1.Size = new System.Drawing.Size(296, 103);
            this.metroSetRichTextBox1.Style = MetroSet_UI.Design.Style.Dark;
            this.metroSetRichTextBox1.StyleManager = null;
            this.metroSetRichTextBox1.TabIndex = 0;
            this.metroSetRichTextBox1.Text = "Make sure you search case sensitive!!!";
            this.metroSetRichTextBox1.ThemeAuthor = "Narwin";
            this.metroSetRichTextBox1.ThemeName = "MetroDark";
            this.metroSetRichTextBox1.WordWrap = true;
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.Color.Transparent;
            this.search.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.search.Location = new System.Drawing.Point(20, 165);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(296, 25);
            this.search.Style = MetroFramework.MetroColorStyle.Pink;
            this.search.TabIndex = 142;
            this.search.TabStop = false;
            this.search.Text = "Search for Card ID";
            this.search.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.search.UseCustomBackColor = true;
            this.search.UseCustomForeColor = true;
            this.search.UseSelectable = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // searchtext
            // 
            // 
            // 
            // 
            this.searchtext.CustomButton.Image = null;
            this.searchtext.CustomButton.Location = new System.Drawing.Point(274, 1);
            this.searchtext.CustomButton.Name = "";
            this.searchtext.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.searchtext.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.searchtext.CustomButton.TabIndex = 1;
            this.searchtext.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.searchtext.CustomButton.UseSelectable = true;
            this.searchtext.CustomButton.Visible = false;
            this.searchtext.Lines = new string[0];
            this.searchtext.Location = new System.Drawing.Point(21, 136);
            this.searchtext.MaxLength = 32767;
            this.searchtext.Name = "searchtext";
            this.searchtext.PasswordChar = '\0';
            this.searchtext.PromptText = "Write down your card name here";
            this.searchtext.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.searchtext.SelectedText = "";
            this.searchtext.SelectionLength = 0;
            this.searchtext.SelectionStart = 0;
            this.searchtext.ShortcutsEnabled = true;
            this.searchtext.Size = new System.Drawing.Size(296, 23);
            this.searchtext.Style = MetroFramework.MetroColorStyle.Purple;
            this.searchtext.TabIndex = 141;
            this.searchtext.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.searchtext.UseSelectable = true;
            this.searchtext.WaterMark = "Write down your card name here";
            this.searchtext.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.searchtext.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.searchtext.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchtext_KeyPress);
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Location = new System.Drawing.Point(258, 196);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(59, 15);
            this.metroCheckBox1.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroCheckBox1.TabIndex = 143;
            this.metroCheckBox1.Text = "OnTop";
            this.metroCheckBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroCheckBox1.UseSelectable = true;
            this.metroCheckBox1.CheckedChanged += new System.EventHandler(this.metroCheckBox1_CheckedChanged_1);
            // 
            // cards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 217);
            this.Controls.Add(this.metroCheckBox1);
            this.Controls.Add(this.search);
            this.Controls.Add(this.searchtext);
            this.Controls.Add(this.metroSetRichTextBox1);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "cards";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "cards";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroSet_UI.Controls.MetroSetRichTextBox metroSetRichTextBox1;
        private MetroFramework.Controls.MetroButton search;
        private MetroFramework.Controls.MetroTextBox searchtext;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
    }
}