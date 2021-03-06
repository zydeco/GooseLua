﻿namespace GooseLua {
    partial class formLoader {

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.modList = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroTextBox2 = new MetroFramework.Controls.MetroTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this._console = new System.Windows.Forms.RichTextBox();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.metroTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.tabPage1);
            this.metroTabControl1.Controls.Add(this.tabPage2);
            this.metroTabControl1.Controls.Add(this.tabPage3);
            this.metroTabControl1.Controls.Add(this.tabPage4);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(760, 351);
            this.metroTabControl1.TabIndex = 1;
            this.metroTabControl1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabControl1.UseSelectable = true;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(752, 309);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.metroButton2);
            this.panel1.Controls.Add(this.metroButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 309);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 90);
            this.label1.TabIndex = 3;
            this.label1.Text = "Welcome to GooseLua!\r\n\r\nRunning Lua {0}";
            // 
            // metroButton2
            // 
            this.metroButton2.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton2.Location = new System.Drawing.Point(636, 283);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(113, 23);
            this.metroButton2.TabIndex = 2;
            this.metroButton2.Text = "Join our Discord";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton1.Location = new System.Drawing.Point(3, 283);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(113, 23);
            this.metroButton1.TabIndex = 1;
            this.metroButton1.Text = "Visit our Website";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.modList);
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(752, 309);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Installed Mods";
            // 
            // modList
            // 
            this.modList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.modList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.modList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modList.Font = new System.Drawing.Font("Segoe UI Light", 9.25F);
            this.modList.ForeColor = System.Drawing.Color.White;
            this.modList.FormattingEnabled = true;
            this.modList.IntegralHeight = false;
            this.modList.ItemHeight = 15;
            this.modList.Location = new System.Drawing.Point(0, 0);
            this.modList.Name = "modList";
            this.modList.Size = new System.Drawing.Size(752, 309);
            this.modList.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.metroPanel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 38);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(752, 309);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Lua Editor";
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroButton3);
            this.metroPanel1.Controls.Add(this.metroTextBox2);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 22;
            this.metroPanel1.Location = new System.Drawing.Point(0, 0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(752, 309);
            this.metroPanel1.TabIndex = 2;
            this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 31;
            // 
            // metroButton3
            // 
            this.metroButton3.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton3.Location = new System.Drawing.Point(3, 283);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(103, 23);
            this.metroButton3.TabIndex = 3;
            this.metroButton3.Text = "Execute Lua";
            this.metroButton3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroTextBox2
            // 
            // 
            // 
            // 
            this.metroTextBox2.CustomButton.Image = null;
            this.metroTextBox2.CustomButton.Location = new System.Drawing.Point(476, 1);
            this.metroTextBox2.CustomButton.Name = "";
            this.metroTextBox2.CustomButton.Size = new System.Drawing.Size(275, 275);
            this.metroTextBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox2.CustomButton.TabIndex = 1;
            this.metroTextBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox2.CustomButton.UseSelectable = true;
            this.metroTextBox2.CustomButton.Visible = false;
            this.metroTextBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroTextBox2.ForeColor = System.Drawing.Color.Red;
            this.metroTextBox2.Lines = new string[0];
            this.metroTextBox2.Location = new System.Drawing.Point(0, 0);
            this.metroTextBox2.MaxLength = 32767;
            this.metroTextBox2.Multiline = true;
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.PasswordChar = '\0';
            this.metroTextBox2.PromptText = "Lua code";
            this.metroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox2.SelectedText = "";
            this.metroTextBox2.SelectionLength = 0;
            this.metroTextBox2.SelectionStart = 0;
            this.metroTextBox2.ShortcutsEnabled = true;
            this.metroTextBox2.Size = new System.Drawing.Size(752, 277);
            this.metroTextBox2.TabIndex = 2;
            this.metroTextBox2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox2.UseSelectable = true;
            this.metroTextBox2.WaterMark = "Lua code";
            this.metroTextBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.metroPanel3);
            this.tabPage4.Location = new System.Drawing.Point(4, 38);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(752, 309);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "Console";
            // 
            // metroPanel3
            // 
            this.metroPanel3.Controls.Add(this._console);
            this.metroPanel3.Controls.Add(this.metroTextBox1);
            this.metroPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 22;
            this.metroPanel3.Location = new System.Drawing.Point(0, 0);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(752, 309);
            this.metroPanel3.TabIndex = 1;
            this.metroPanel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 31;
            // 
            // _console
            // 
            this.metroStyleExtender1.SetApplyMetroTheme(this._console, true);
            this._console.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this._console.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._console.DetectUrls = false;
            this._console.Dock = System.Windows.Forms.DockStyle.Fill;
            this._console.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this._console.Location = new System.Drawing.Point(0, 0);
            this._console.Name = "_console";
            this._console.ReadOnly = true;
            this._console.Size = new System.Drawing.Size(752, 286);
            this._console.TabIndex = 2;
            this._console.Text = "";
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.metroTextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.metroTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(730, 1);
            this.metroTextBox1.CustomButton.Margin = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroTextBox1.ForeColor = System.Drawing.Color.White;
            this.metroTextBox1.Lines = new string[] {
        "help"};
            this.metroTextBox1.Location = new System.Drawing.Point(0, 286);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(752, 23);
            this.metroTextBox1.TabIndex = 3;
            this.metroTextBox1.Text = "help";
            this.metroTextBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.metroTextBox1_KeyDown);
            // 
            // metroStyleExtender1
            // 
            this.metroStyleExtender1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel1
            // 
            this.metroLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroLabel1.Location = new System.Drawing.Point(20, 411);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(760, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // formLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.metroLabel1);
            this.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.Name = "formLoader";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.ShowIcon = false;
            this.Text = "Goose Lua // Lua Modloader";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formLoader_FormClosing);
            this.Load += new System.EventHandler(this.formLoader_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.metroPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage4;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.ListBox modList;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.RichTextBox _console;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTextBox metroTextBox2;
        private MetroFramework.Controls.MetroButton metroButton3;
    }
}