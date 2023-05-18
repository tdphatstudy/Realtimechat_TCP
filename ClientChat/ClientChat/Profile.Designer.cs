namespace ClientChat
{
    partial class Profile
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
            this.ProfileTab = new System.Windows.Forms.TabControl();
            this.groupTab = new System.Windows.Forms.TabPage();
            this.friendTab = new System.Windows.Forms.TabPage();
            this.changePassTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userTxt = new System.Windows.Forms.TextBox();
            this.passTxt = new System.Windows.Forms.TextBox();
            this.changeBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.ProfileTab.SuspendLayout();
            this.friendTab.SuspendLayout();
            this.changePassTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProfileTab
            // 
            this.ProfileTab.Controls.Add(this.groupTab);
            this.ProfileTab.Controls.Add(this.friendTab);
            this.ProfileTab.Controls.Add(this.changePassTab);
            this.ProfileTab.Location = new System.Drawing.Point(0, -1);
            this.ProfileTab.Name = "ProfileTab";
            this.ProfileTab.SelectedIndex = 0;
            this.ProfileTab.Size = new System.Drawing.Size(506, 389);
            this.ProfileTab.TabIndex = 0;
            // 
            // groupTab
            // 
            this.groupTab.Location = new System.Drawing.Point(4, 24);
            this.groupTab.Name = "groupTab";
            this.groupTab.Padding = new System.Windows.Forms.Padding(3);
            this.groupTab.Size = new System.Drawing.Size(498, 361);
            this.groupTab.TabIndex = 0;
            this.groupTab.Text = "Groups";
            this.groupTab.UseVisualStyleBackColor = true;
            // 
            // friendTab
            // 
            this.friendTab.Controls.Add(this.listBox2);
            this.friendTab.Controls.Add(this.listBox1);
            this.friendTab.Controls.Add(this.button4);
            this.friendTab.Controls.Add(this.button3);
            this.friendTab.Controls.Add(this.button2);
            this.friendTab.Controls.Add(this.button1);
            this.friendTab.Controls.Add(this.textBox1);
            this.friendTab.Controls.Add(this.label5);
            this.friendTab.Controls.Add(this.label4);
            this.friendTab.Controls.Add(this.label3);
            this.friendTab.Location = new System.Drawing.Point(4, 24);
            this.friendTab.Name = "friendTab";
            this.friendTab.Padding = new System.Windows.Forms.Padding(3);
            this.friendTab.Size = new System.Drawing.Size(498, 361);
            this.friendTab.TabIndex = 1;
            this.friendTab.Text = "Friends";
            this.friendTab.UseVisualStyleBackColor = true;
            // 
            // changePassTab
            // 
            this.changePassTab.Controls.Add(this.changeBtn);
            this.changePassTab.Controls.Add(this.passTxt);
            this.changePassTab.Controls.Add(this.userTxt);
            this.changePassTab.Controls.Add(this.label2);
            this.changePassTab.Controls.Add(this.label1);
            this.changePassTab.Location = new System.Drawing.Point(4, 24);
            this.changePassTab.Name = "changePassTab";
            this.changePassTab.Padding = new System.Windows.Forms.Padding(3);
            this.changePassTab.Size = new System.Drawing.Size(498, 361);
            this.changePassTab.TabIndex = 2;
            this.changePassTab.Text = "Change Password";
            this.changePassTab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "NewPassword";
            // 
            // userTxt
            // 
            this.userTxt.Location = new System.Drawing.Point(124, 80);
            this.userTxt.Name = "userTxt";
            this.userTxt.Size = new System.Drawing.Size(257, 23);
            this.userTxt.TabIndex = 2;
            // 
            // passTxt
            // 
            this.passTxt.Location = new System.Drawing.Point(124, 161);
            this.passTxt.Name = "passTxt";
            this.passTxt.Size = new System.Drawing.Size(257, 23);
            this.passTxt.TabIndex = 3;
            // 
            // changeBtn
            // 
            this.changeBtn.Location = new System.Drawing.Point(219, 265);
            this.changeBtn.Name = "changeBtn";
            this.changeBtn.Size = new System.Drawing.Size(75, 23);
            this.changeBtn.TabIndex = 4;
            this.changeBtn.Text = "Change";
            this.changeBtn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "label5";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(66, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(300, 23);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(399, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(399, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(399, 215);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(399, 259);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(21, 67);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(345, 94);
            this.listBox1.TabIndex = 8;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 15;
            this.listBox2.Location = new System.Drawing.Point(21, 215);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(345, 94);
            this.listBox2.TabIndex = 9;
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 387);
            this.Controls.Add(this.ProfileTab);
            this.Name = "Profile";
            this.Text = "Profile";
            this.ProfileTab.ResumeLayout(false);
            this.friendTab.ResumeLayout(false);
            this.friendTab.PerformLayout();
            this.changePassTab.ResumeLayout(false);
            this.changePassTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl ProfileTab;
        private TabPage groupTab;
        private TabPage friendTab;
        private TabPage changePassTab;
        private Button changeBtn;
        private TextBox passTxt;
        private TextBox userTxt;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private ListBox listBox2;
        private ListBox listBox1;
    }
}