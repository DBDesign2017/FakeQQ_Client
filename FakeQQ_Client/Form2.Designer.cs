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
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
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
    }
}