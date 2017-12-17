namespace FakeQQ_Client
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.friendListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chatButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.friendRequestWarningLabel = new System.Windows.Forms.Label();
            this.sendFriendRequestButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.sendButton = new System.Windows.Forms.Button();
            this.sendTextBox = new System.Windows.Forms.TextBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.chattingFriendLabel = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox_3 = new System.Windows.Forms.GroupBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.label_signature = new System.Windows.Forms.Label();
            this.textBox_signature = new System.Windows.Forms.TextBox();
            this.button_change = new System.Windows.Forms.Button();
            this.label_email = new System.Windows.Forms.Label();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.label_sex = new System.Windows.Forms.Label();
            this.textBox_sex = new System.Windows.Forms.TextBox();
            this.label_birthday = new System.Windows.Forms.Label();
            this.textBox_birthday = new System.Windows.Forms.TextBox();
            this.label_tel = new System.Windows.Forms.Label();
            this.textBox_location = new System.Windows.Forms.TextBox();
            this.label_location = new System.Windows.Forms.Label();
            this.textBox_nickname = new System.Windows.Forms.TextBox();
            this.label_nickname = new System.Windows.Forms.Label();
            this.textBox_tel = new System.Windows.Forms.TextBox();
            this.label_id = new System.Windows.Forms.Label();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.groupBox_4 = new System.Windows.Forms.GroupBox();
            this.label_ChangePasswordWarning = new System.Windows.Forms.Label();
            this.button_pwd = new System.Windows.Forms.Button();
            this.label_againpwd = new System.Windows.Forms.Label();
            this.textBox_againpwd = new System.Windows.Forms.TextBox();
            this.label_newpwd = new System.Windows.Forms.Label();
            this.textBox_newpwd = new System.Windows.Forms.TextBox();
            this.label_oldpwd = new System.Windows.Forms.Label();
            this.textBox_oldpwd = new System.Windows.Forms.TextBox();
            this.contextMenuStrip_FriendListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_DeleteFriend = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox_3.SuspendLayout();
            this.groupBox_4.SuspendLayout();
            this.contextMenuStrip_FriendListView.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(533, 427);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(525, 401);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "好友管理";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.friendListView);
            this.groupBox2.Controls.Add(this.chatButton);
            this.groupBox2.Location = new System.Drawing.Point(7, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 278);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "好友列表";
            // 
            // friendListView
            // 
            this.friendListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.friendListView.ContextMenuStrip = this.contextMenuStrip_FriendListView;
            this.friendListView.FullRowSelect = true;
            this.friendListView.Location = new System.Drawing.Point(6, 20);
            this.friendListView.MultiSelect = false;
            this.friendListView.Name = "friendListView";
            this.friendListView.Size = new System.Drawing.Size(500, 223);
            this.friendListView.TabIndex = 1;
            this.friendListView.UseCompatibleStateImageBehavior = false;
            this.friendListView.View = System.Windows.Forms.View.List;
            // 
            // chatButton
            // 
            this.chatButton.Location = new System.Drawing.Point(431, 249);
            this.chatButton.Name = "chatButton";
            this.chatButton.Size = new System.Drawing.Size(75, 23);
            this.chatButton.TabIndex = 2;
            this.chatButton.Text = "聊天";
            this.chatButton.UseVisualStyleBackColor = true;
            this.chatButton.Click += new System.EventHandler(this.chatButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.friendRequestWarningLabel);
            this.groupBox1.Controls.Add(this.sendFriendRequestButton);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "添加好友";
            // 
            // friendRequestWarningLabel
            // 
            this.friendRequestWarningLabel.AutoSize = true;
            this.friendRequestWarningLabel.Location = new System.Drawing.Point(31, 66);
            this.friendRequestWarningLabel.Name = "friendRequestWarningLabel";
            this.friendRequestWarningLabel.Size = new System.Drawing.Size(0, 12);
            this.friendRequestWarningLabel.TabIndex = 4;
            // 
            // sendFriendRequestButton
            // 
            this.sendFriendRequestButton.Location = new System.Drawing.Point(236, 19);
            this.sendFriendRequestButton.Name = "sendFriendRequestButton";
            this.sendFriendRequestButton.Size = new System.Drawing.Size(93, 23);
            this.sendFriendRequestButton.TabIndex = 2;
            this.sendFriendRequestButton.Text = "发送好友申请";
            this.sendFriendRequestButton.UseVisualStyleBackColor = true;
            this.sendFriendRequestButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(91, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(126, 21);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入用户ID：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.sendButton);
            this.tabPage2.Controls.Add(this.sendTextBox);
            this.tabPage2.Controls.Add(this.messageTextBox);
            this.tabPage2.Controls.Add(this.chattingFriendLabel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(525, 401);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "聊天窗口";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(444, 367);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "发送";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // sendTextBox
            // 
            this.sendTextBox.Location = new System.Drawing.Point(9, 265);
            this.sendTextBox.MaxLength = 100;
            this.sendTextBox.Multiline = true;
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.Size = new System.Drawing.Size(510, 92);
            this.sendTextBox.TabIndex = 2;
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(9, 23);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.ReadOnly = true;
            this.messageTextBox.Size = new System.Drawing.Size(510, 236);
            this.messageTextBox.TabIndex = 1;
            // 
            // chattingFriendLabel
            // 
            this.chattingFriendLabel.AutoSize = true;
            this.chattingFriendLabel.Location = new System.Drawing.Point(7, 7);
            this.chattingFriendLabel.Name = "chattingFriendLabel";
            this.chattingFriendLabel.Size = new System.Drawing.Size(41, 12);
            this.chattingFriendLabel.TabIndex = 0;
            this.chattingFriendLabel.Text = "label2";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox_3);
            this.tabPage3.Controls.Add(this.groupBox_4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(525, 401);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "账户管理";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox_3
            // 
            this.groupBox_3.Controls.Add(this.button_ok);
            this.groupBox_3.Controls.Add(this.label_signature);
            this.groupBox_3.Controls.Add(this.textBox_signature);
            this.groupBox_3.Controls.Add(this.button_change);
            this.groupBox_3.Controls.Add(this.label_email);
            this.groupBox_3.Controls.Add(this.textBox_email);
            this.groupBox_3.Controls.Add(this.label_sex);
            this.groupBox_3.Controls.Add(this.textBox_sex);
            this.groupBox_3.Controls.Add(this.label_birthday);
            this.groupBox_3.Controls.Add(this.textBox_birthday);
            this.groupBox_3.Controls.Add(this.label_tel);
            this.groupBox_3.Controls.Add(this.textBox_location);
            this.groupBox_3.Controls.Add(this.label_location);
            this.groupBox_3.Controls.Add(this.textBox_nickname);
            this.groupBox_3.Controls.Add(this.label_nickname);
            this.groupBox_3.Controls.Add(this.textBox_tel);
            this.groupBox_3.Controls.Add(this.label_id);
            this.groupBox_3.Controls.Add(this.textBox_id);
            this.groupBox_3.Location = new System.Drawing.Point(3, 3);
            this.groupBox_3.Name = "groupBox_3";
            this.groupBox_3.Size = new System.Drawing.Size(519, 233);
            this.groupBox_3.TabIndex = 19;
            this.groupBox_3.TabStop = false;
            this.groupBox_3.Text = "个人信息";
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(348, 185);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 24;
            this.button_ok.Text = "确认";
            this.button_ok.UseVisualStyleBackColor = true;
            // 
            // label_signature
            // 
            this.label_signature.AutoSize = true;
            this.label_signature.Location = new System.Drawing.Point(253, 31);
            this.label_signature.Name = "label_signature";
            this.label_signature.Size = new System.Drawing.Size(47, 12);
            this.label_signature.TabIndex = 31;
            this.label_signature.Text = "签 名：";
            // 
            // textBox_signature
            // 
            this.textBox_signature.Location = new System.Drawing.Point(312, 28);
            this.textBox_signature.Name = "textBox_signature";
            this.textBox_signature.Size = new System.Drawing.Size(123, 21);
            this.textBox_signature.TabIndex = 30;
            // 
            // button_change
            // 
            this.button_change.Location = new System.Drawing.Point(63, 185);
            this.button_change.Name = "button_change";
            this.button_change.Size = new System.Drawing.Size(75, 23);
            this.button_change.TabIndex = 24;
            this.button_change.Text = "修改";
            this.button_change.UseVisualStyleBackColor = true;
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Location = new System.Drawing.Point(49, 144);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(47, 12);
            this.label_email.TabIndex = 29;
            this.label_email.Text = "邮 箱：";
            // 
            // textBox_email
            // 
            this.textBox_email.Location = new System.Drawing.Point(108, 141);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(117, 21);
            this.textBox_email.TabIndex = 28;
            // 
            // label_sex
            // 
            this.label_sex.AutoSize = true;
            this.label_sex.Location = new System.Drawing.Point(253, 72);
            this.label_sex.Name = "label_sex";
            this.label_sex.Size = new System.Drawing.Size(47, 12);
            this.label_sex.TabIndex = 27;
            this.label_sex.Text = "性 别：";
            // 
            // textBox_sex
            // 
            this.textBox_sex.Location = new System.Drawing.Point(312, 63);
            this.textBox_sex.Name = "textBox_sex";
            this.textBox_sex.Size = new System.Drawing.Size(123, 21);
            this.textBox_sex.TabIndex = 26;
            // 
            // label_birthday
            // 
            this.label_birthday.AutoSize = true;
            this.label_birthday.Location = new System.Drawing.Point(49, 105);
            this.label_birthday.Name = "label_birthday";
            this.label_birthday.Size = new System.Drawing.Size(47, 12);
            this.label_birthday.TabIndex = 25;
            this.label_birthday.Text = "生 日：";
            // 
            // textBox_birthday
            // 
            this.textBox_birthday.Location = new System.Drawing.Point(108, 102);
            this.textBox_birthday.Name = "textBox_birthday";
            this.textBox_birthday.Size = new System.Drawing.Size(117, 21);
            this.textBox_birthday.TabIndex = 24;
            // 
            // label_tel
            // 
            this.label_tel.AutoSize = true;
            this.label_tel.Location = new System.Drawing.Point(253, 144);
            this.label_tel.Name = "label_tel";
            this.label_tel.Size = new System.Drawing.Size(47, 12);
            this.label_tel.TabIndex = 23;
            this.label_tel.Text = "电 话：";
            // 
            // textBox_location
            // 
            this.textBox_location.Location = new System.Drawing.Point(312, 102);
            this.textBox_location.Name = "textBox_location";
            this.textBox_location.Size = new System.Drawing.Size(123, 21);
            this.textBox_location.TabIndex = 22;
            // 
            // label_location
            // 
            this.label_location.AutoSize = true;
            this.label_location.Location = new System.Drawing.Point(253, 108);
            this.label_location.Name = "label_location";
            this.label_location.Size = new System.Drawing.Size(47, 12);
            this.label_location.TabIndex = 21;
            this.label_location.Text = "位 置：";
            // 
            // textBox_nickname
            // 
            this.textBox_nickname.Location = new System.Drawing.Point(108, 63);
            this.textBox_nickname.Name = "textBox_nickname";
            this.textBox_nickname.Size = new System.Drawing.Size(117, 21);
            this.textBox_nickname.TabIndex = 20;
            // 
            // label_nickname
            // 
            this.label_nickname.AutoSize = true;
            this.label_nickname.Location = new System.Drawing.Point(49, 66);
            this.label_nickname.Name = "label_nickname";
            this.label_nickname.Size = new System.Drawing.Size(47, 12);
            this.label_nickname.TabIndex = 19;
            this.label_nickname.Text = "昵 称：";
            // 
            // textBox_tel
            // 
            this.textBox_tel.Location = new System.Drawing.Point(312, 141);
            this.textBox_tel.Name = "textBox_tel";
            this.textBox_tel.Size = new System.Drawing.Size(123, 21);
            this.textBox_tel.TabIndex = 18;
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(49, 31);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(47, 12);
            this.label_id.TabIndex = 17;
            this.label_id.Text = "账 号：";
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(108, 28);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.Size = new System.Drawing.Size(117, 21);
            this.textBox_id.TabIndex = 16;
            // 
            // groupBox_4
            // 
            this.groupBox_4.Controls.Add(this.label_ChangePasswordWarning);
            this.groupBox_4.Controls.Add(this.button_pwd);
            this.groupBox_4.Controls.Add(this.label_againpwd);
            this.groupBox_4.Controls.Add(this.textBox_againpwd);
            this.groupBox_4.Controls.Add(this.label_newpwd);
            this.groupBox_4.Controls.Add(this.textBox_newpwd);
            this.groupBox_4.Controls.Add(this.label_oldpwd);
            this.groupBox_4.Controls.Add(this.textBox_oldpwd);
            this.groupBox_4.Location = new System.Drawing.Point(3, 242);
            this.groupBox_4.Name = "groupBox_4";
            this.groupBox_4.Size = new System.Drawing.Size(519, 156);
            this.groupBox_4.TabIndex = 18;
            this.groupBox_4.TabStop = false;
            this.groupBox_4.Text = " 修改密码 ";
            // 
            // label_ChangePasswordWarning
            // 
            this.label_ChangePasswordWarning.AutoSize = true;
            this.label_ChangePasswordWarning.Location = new System.Drawing.Point(346, 58);
            this.label_ChangePasswordWarning.Name = "label_ChangePasswordWarning";
            this.label_ChangePasswordWarning.Size = new System.Drawing.Size(0, 12);
            this.label_ChangePasswordWarning.TabIndex = 24;
            // 
            // button_pwd
            // 
            this.button_pwd.Location = new System.Drawing.Point(348, 116);
            this.button_pwd.Name = "button_pwd";
            this.button_pwd.Size = new System.Drawing.Size(75, 23);
            this.button_pwd.TabIndex = 23;
            this.button_pwd.Text = "确认";
            this.button_pwd.UseVisualStyleBackColor = true;
            this.button_pwd.Click += new System.EventHandler(this.button_pwd_Click);
            // 
            // label_againpwd
            // 
            this.label_againpwd.AutoSize = true;
            this.label_againpwd.Location = new System.Drawing.Point(19, 123);
            this.label_againpwd.Name = "label_againpwd";
            this.label_againpwd.Size = new System.Drawing.Size(83, 12);
            this.label_againpwd.TabIndex = 22;
            this.label_againpwd.Text = "确 认 密 码：";
            // 
            // textBox_againpwd
            // 
            this.textBox_againpwd.Location = new System.Drawing.Point(108, 118);
            this.textBox_againpwd.Name = "textBox_againpwd";
            this.textBox_againpwd.PasswordChar = '*';
            this.textBox_againpwd.Size = new System.Drawing.Size(168, 21);
            this.textBox_againpwd.TabIndex = 21;
            // 
            // label_newpwd
            // 
            this.label_newpwd.AutoSize = true;
            this.label_newpwd.Location = new System.Drawing.Point(37, 81);
            this.label_newpwd.Name = "label_newpwd";
            this.label_newpwd.Size = new System.Drawing.Size(65, 12);
            this.label_newpwd.TabIndex = 20;
            this.label_newpwd.Text = "新 密 码：";
            // 
            // textBox_newpwd
            // 
            this.textBox_newpwd.Location = new System.Drawing.Point(108, 78);
            this.textBox_newpwd.Name = "textBox_newpwd";
            this.textBox_newpwd.PasswordChar = '*';
            this.textBox_newpwd.Size = new System.Drawing.Size(168, 21);
            this.textBox_newpwd.TabIndex = 19;
            // 
            // label_oldpwd
            // 
            this.label_oldpwd.AutoSize = true;
            this.label_oldpwd.Location = new System.Drawing.Point(37, 35);
            this.label_oldpwd.Name = "label_oldpwd";
            this.label_oldpwd.Size = new System.Drawing.Size(65, 12);
            this.label_oldpwd.TabIndex = 18;
            this.label_oldpwd.Text = "原 密 码：";
            // 
            // textBox_oldpwd
            // 
            this.textBox_oldpwd.Location = new System.Drawing.Point(108, 32);
            this.textBox_oldpwd.Name = "textBox_oldpwd";
            this.textBox_oldpwd.PasswordChar = '*';
            this.textBox_oldpwd.Size = new System.Drawing.Size(168, 21);
            this.textBox_oldpwd.TabIndex = 17;
            // 
            // contextMenuStrip_FriendListView
            // 
            this.contextMenuStrip_FriendListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DeleteFriend});
            this.contextMenuStrip_FriendListView.Name = "contextMenuStrip_FriendListView";
            this.contextMenuStrip_FriendListView.Size = new System.Drawing.Size(153, 48);
            // 
            // toolStripMenuItem_DeleteFriend
            // 
            this.toolStripMenuItem_DeleteFriend.Name = "toolStripMenuItem_DeleteFriend";
            this.toolStripMenuItem_DeleteFriend.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_DeleteFriend.Text = "删除好友";
            this.toolStripMenuItem_DeleteFriend.Click += new System.EventHandler(this.toolStripMenuItem_DeleteFriend_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 451);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox_3.ResumeLayout(false);
            this.groupBox_3.PerformLayout();
            this.groupBox_4.ResumeLayout(false);
            this.groupBox_4.PerformLayout();
            this.contextMenuStrip_FriendListView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button chatButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button sendFriendRequestButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label friendRequestWarningLabel;
        private System.Windows.Forms.ListView friendListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox sendTextBox;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Label chattingFriendLabel;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox_3;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Label label_signature;
        private System.Windows.Forms.TextBox textBox_signature;
        private System.Windows.Forms.Button button_change;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.Label label_sex;
        private System.Windows.Forms.TextBox textBox_sex;
        private System.Windows.Forms.Label label_birthday;
        private System.Windows.Forms.TextBox textBox_birthday;
        private System.Windows.Forms.Label label_tel;
        private System.Windows.Forms.TextBox textBox_location;
        private System.Windows.Forms.Label label_location;
        private System.Windows.Forms.TextBox textBox_nickname;
        private System.Windows.Forms.Label label_nickname;
        private System.Windows.Forms.TextBox textBox_tel;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.GroupBox groupBox_4;
        private System.Windows.Forms.Label label_ChangePasswordWarning;
        private System.Windows.Forms.Button button_pwd;
        private System.Windows.Forms.Label label_againpwd;
        private System.Windows.Forms.TextBox textBox_againpwd;
        private System.Windows.Forms.Label label_newpwd;
        private System.Windows.Forms.TextBox textBox_newpwd;
        private System.Windows.Forms.Label label_oldpwd;
        private System.Windows.Forms.TextBox textBox_oldpwd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_FriendListView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DeleteFriend;
    }
}