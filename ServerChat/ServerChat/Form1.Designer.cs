namespace ServerChat
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ipTxt = new System.Windows.Forms.TextBox();
            this.portTxt = new System.Windows.Forms.TextBox();
            this.connect = new System.Windows.Forms.Button();
            this.CurrentOnlineUser = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ServerIp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "ServerPort";
            // 
            // ipTxt
            // 
            this.ipTxt.Enabled = false;
            this.ipTxt.Location = new System.Drawing.Point(71, 12);
            this.ipTxt.Name = "ipTxt";
            this.ipTxt.Size = new System.Drawing.Size(306, 23);
            this.ipTxt.TabIndex = 3;
            // 
            // portTxt
            // 
            this.portTxt.Enabled = false;
            this.portTxt.Location = new System.Drawing.Point(509, 12);
            this.portTxt.Name = "portTxt";
            this.portTxt.Size = new System.Drawing.Size(159, 23);
            this.portTxt.TabIndex = 4;
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(316, 66);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(118, 23);
            this.connect.TabIndex = 5;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // CurrentOnlineUser
            // 
            this.CurrentOnlineUser.FormattingEnabled = true;
            this.CurrentOnlineUser.ItemHeight = 15;
            this.CurrentOnlineUser.Location = new System.Drawing.Point(19, 107);
            this.CurrentOnlineUser.Name = "CurrentOnlineUser";
            this.CurrentOnlineUser.Size = new System.Drawing.Size(649, 214);
            this.CurrentOnlineUser.TabIndex = 6;
            this.CurrentOnlineUser.SelectedIndexChanged += new System.EventHandler(this.CurrentOnlineUser_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 338);
            this.Controls.Add(this.CurrentOnlineUser);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.portTxt);
            this.Controls.Add(this.ipTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox ipTxt;
        private TextBox portTxt;
        private Button connect;
        private ListBox CurrentOnlineUser;
    }
}