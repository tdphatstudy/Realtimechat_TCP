namespace ClientChat
{
    partial class ChatApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatApp));
            this.Friend = new System.Windows.Forms.ListBox();
            this.Group = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.yournameLb = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.inputMessTxt = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.receivernameLb = new System.Windows.Forms.Label();
            this.profile = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            this.display = new System.Windows.Forms.RichTextBox();
            this.shockIcon = new System.Windows.Forms.PictureBox();
            this.loveiCon = new System.Windows.Forms.PictureBox();
            this.angryIcon = new System.Windows.Forms.PictureBox();
            this.poopIcon = new System.Windows.Forms.PictureBox();
            this.cryingIcon = new System.Windows.Forms.PictureBox();
            this.fbLoveIcon = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shockIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loveiCon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angryIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.poopIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cryingIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fbLoveIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Friend
            // 
            this.Friend.FormattingEnabled = true;
            this.Friend.Location = new System.Drawing.Point(10, 63);
            this.Friend.Name = "Friend";
            this.Friend.Size = new System.Drawing.Size(109, 108);
            this.Friend.TabIndex = 0;
            this.Friend.SelectedIndexChanged += new System.EventHandler(this.Friend_SelectedIndexChanged);
            // 
            // Group
            // 
            this.Group.FormattingEnabled = true;
            this.Group.Location = new System.Drawing.Point(10, 200);
            this.Group.Name = "Group";
            this.Group.Size = new System.Drawing.Size(109, 95);
            this.Group.TabIndex = 1;
            this.Group.SelectedIndexChanged += new System.EventHandler(this.Group_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "FriendList";
            // 
            // yournameLb
            // 
            this.yournameLb.AutoSize = true;
            this.yournameLb.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.yournameLb.Location = new System.Drawing.Point(24, 16);
            this.yournameLb.Name = "yournameLb";
            this.yournameLb.Size = new System.Drawing.Size(83, 20);
            this.yournameLb.TabIndex = 3;
            this.yournameLb.Text = "YourName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "GroupList";
            // 
            // inputMessTxt
            // 
            this.inputMessTxt.Location = new System.Drawing.Point(128, 275);
            this.inputMessTxt.Name = "inputMessTxt";
            this.inputMessTxt.Size = new System.Drawing.Size(307, 20);
            this.inputMessTxt.TabIndex = 6;
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(439, 274);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(60, 20);
            this.sendBtn.TabIndex = 7;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.receivernameLb);
            this.panel1.Location = new System.Drawing.Point(128, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 29);
            this.panel1.TabIndex = 8;
            // 
            // receivernameLb
            // 
            this.receivernameLb.AutoSize = true;
            this.receivernameLb.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.receivernameLb.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.receivernameLb.Location = new System.Drawing.Point(0, 3);
            this.receivernameLb.Name = "receivernameLb";
            this.receivernameLb.Size = new System.Drawing.Size(132, 25);
            this.receivernameLb.TabIndex = 0;
            this.receivernameLb.Text = "ReceiverName";
            this.receivernameLb.Click += new System.EventHandler(this.receivernameLb_Click);
            // 
            // profile
            // 
            this.profile.Location = new System.Drawing.Point(364, 18);
            this.profile.Name = "profile";
            this.profile.Size = new System.Drawing.Size(60, 27);
            this.profile.TabIndex = 9;
            this.profile.Text = "Profile";
            this.profile.UseVisualStyleBackColor = true;
            this.profile.Click += new System.EventHandler(this.profile_Click);
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(439, 18);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(60, 27);
            this.logout.TabIndex = 10;
            this.logout.Text = "Logout";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // display
            // 
            this.display.Location = new System.Drawing.Point(128, 63);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(372, 174);
            this.display.TabIndex = 12;
            this.display.Text = "";
            this.display.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.display_LinkClicked);
            this.display.TextChanged += new System.EventHandler(this.display_TextChanged);
            // 
            // shockIcon
            // 
            this.shockIcon.Image = ((System.Drawing.Image)(resources.GetObject("shockIcon.Image")));
            this.shockIcon.Location = new System.Drawing.Point(128, 242);
            this.shockIcon.Name = "shockIcon";
            this.shockIcon.Size = new System.Drawing.Size(27, 28);
            this.shockIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.shockIcon.TabIndex = 13;
            this.shockIcon.TabStop = false;
            this.shockIcon.Click += new System.EventHandler(this.shockIcon_Click);
            // 
            // loveiCon
            // 
            this.loveiCon.Image = ((System.Drawing.Image)(resources.GetObject("loveiCon.Image")));
            this.loveiCon.Location = new System.Drawing.Point(160, 242);
            this.loveiCon.Name = "loveiCon";
            this.loveiCon.Size = new System.Drawing.Size(27, 28);
            this.loveiCon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loveiCon.TabIndex = 14;
            this.loveiCon.TabStop = false;
            this.loveiCon.Click += new System.EventHandler(this.loveiCon_Click);
            // 
            // angryIcon
            // 
            this.angryIcon.Image = ((System.Drawing.Image)(resources.GetObject("angryIcon.Image")));
            this.angryIcon.Location = new System.Drawing.Point(193, 242);
            this.angryIcon.Name = "angryIcon";
            this.angryIcon.Size = new System.Drawing.Size(27, 28);
            this.angryIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.angryIcon.TabIndex = 15;
            this.angryIcon.TabStop = false;
            this.angryIcon.Click += new System.EventHandler(this.angryIcon_Click);
            // 
            // poopIcon
            // 
            this.poopIcon.Image = ((System.Drawing.Image)(resources.GetObject("poopIcon.Image")));
            this.poopIcon.Location = new System.Drawing.Point(225, 242);
            this.poopIcon.Name = "poopIcon";
            this.poopIcon.Size = new System.Drawing.Size(27, 28);
            this.poopIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.poopIcon.TabIndex = 16;
            this.poopIcon.TabStop = false;
            this.poopIcon.Click += new System.EventHandler(this.poopIcon_Click);
            // 
            // cryingIcon
            // 
            this.cryingIcon.Image = ((System.Drawing.Image)(resources.GetObject("cryingIcon.Image")));
            this.cryingIcon.Location = new System.Drawing.Point(258, 242);
            this.cryingIcon.Name = "cryingIcon";
            this.cryingIcon.Size = new System.Drawing.Size(27, 28);
            this.cryingIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cryingIcon.TabIndex = 17;
            this.cryingIcon.TabStop = false;
            this.cryingIcon.Click += new System.EventHandler(this.cryingIcon_Click);
            // 
            // fbLoveIcon
            // 
            this.fbLoveIcon.Image = ((System.Drawing.Image)(resources.GetObject("fbLoveIcon.Image")));
            this.fbLoveIcon.Location = new System.Drawing.Point(291, 242);
            this.fbLoveIcon.Name = "fbLoveIcon";
            this.fbLoveIcon.Size = new System.Drawing.Size(27, 28);
            this.fbLoveIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fbLoveIcon.TabIndex = 18;
            this.fbLoveIcon.TabStop = false;
            this.fbLoveIcon.Click += new System.EventHandler(this.fbLoveIcon_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(471, 241);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ChatApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 297);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.fbLoveIcon);
            this.Controls.Add(this.cryingIcon);
            this.Controls.Add(this.poopIcon);
            this.Controls.Add(this.angryIcon);
            this.Controls.Add(this.loveiCon);
            this.Controls.Add(this.shockIcon);
            this.Controls.Add(this.display);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.profile);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.inputMessTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yournameLb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Group);
            this.Controls.Add(this.Friend);
            this.Name = "ChatApp";
            this.Text = "ChatApp";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shockIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loveiCon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angryIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.poopIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cryingIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fbLoveIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox Friend;
        private ListBox Group;
        private Label label1;
        private Label yournameLb;
        private Label label3;
        private TextBox inputMessTxt;
        private Button sendBtn;
        private Panel panel1;
        private Label receivernameLb;
        private Button profile;
        private Button logout;
        private RichTextBox display;
        private PictureBox shockIcon;
        private PictureBox loveiCon;
        private PictureBox angryIcon;
        private PictureBox poopIcon;
        private PictureBox cryingIcon;
        private PictureBox fbLoveIcon;
        private PictureBox pictureBox1;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
    }
}