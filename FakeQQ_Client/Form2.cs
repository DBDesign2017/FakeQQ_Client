using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Media;

namespace FakeQQ_Client
{
    public partial class Form2 : Form
    {
        private ClientOperation c;
        private string UserID;
        private string chattingFriendID;
        public Form2(ClientOperation c, string UserID)
        {
            this.UserID = UserID;
            this.chattingFriendID = "";
            Text = "FakeQQ 用户：" + UserID;
            this.c = c;
            this.c.DownloadFriendList(UserID);//从服务器更新好友列表
            InitializeComponent();
            ClientOperation.DownloadFriendListSuccess += new ClientOperation.CrossThreadCallControlHandler(DownloadFriendListSuccess);
            ClientOperation.FriendRequestFail += new ClientOperation.CrossThreadCallControlHandler(FriendRequestFail);
            ClientOperation.AnotherUserFriendRequest += new ClientOperation.CrossThreadCallControlHandler(AnotherUserFriendRequest);
            ClientOperation.AnotherUserConfirmFriendRequest += new ClientOperation.CrossThreadCallControlHandler(AnotherUserConfirmFriendRequest);
            ClientOperation.RecieveSystemMessage += new ClientOperation.CrossThreadCallControlHandler(RecieveSystemMessage);
            ClientOperation.UpdateFriendListView += new ClientOperation.CrossThreadCallControlHandler(UpdateFriendListView);
            ClientOperation.RecieveMessage += new ClientOperation.CrossThreadCallControlHandler(RecieveMessage);
            //设置向服务器发送心跳包的定时器
            System.Timers.Timer heartBeatTimer = new System.Timers.Timer();
            heartBeatTimer.Interval = 3000;
            heartBeatTimer.Enabled = true;
            heartBeatTimer.Elapsed += new System.Timers.ElapsedEventHandler(c.SendHeartBeatPacket);
        }

        private delegate void ChangeControl(object sender, EventArgs e);

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)//用户请求添加好友
        {
            string friendID = textBox1.Text.Trim();
            if(textBox1.Text.Trim() == "")
            {
                return;
            }
            if(friendID == UserID)
            {
                friendRequestWarningLabel.Text = "错误：不能加自己为好友";
                return;
            }
            bool legal = true;
            for(int i=0; i<friendID.Length; i++)
            {
                if(friendID[i]<48 || friendID[i] > 57)
                {
                    legal = false;
                }
            }
            if (legal == false)
            {
                friendRequestWarningLabel.ForeColor = Color.Red;
                friendRequestWarningLabel.Text = "错误：输入的ID只能包含数字";
            }
            else
            {
                c.FriendRequest(UserID, friendID);
            }
        }
        private void chatButton_Click(object sender, EventArgs e)
        {
            try
            {
                string friendID = friendListView.SelectedItems[0].Text;
                bool isOnline = true;
                for(int i=0; i<c.friendList.Count; i++)
                {
                    if(((FriendListItem)c.friendList[i]).UserID == friendID)
                    {
                        isOnline = ((FriendListItem)c.friendList[i]).IsOnline;
                    }
                }
                if (isOnline)
                {
                    tabControl1.SelectedTab = tabPage2;//切换选项卡
                    chattingFriendLabel.Text = "正在与" + friendID + "聊天";
                    chattingFriendID = friendID;
                }
            }
            catch { }
        }
        private void sendButton_Click(object sender, EventArgs e)
        {
            if (sendTextBox.Text == "")
                return;
            DateTime time = DateTime.Now;
            messageTextBox.AppendText(DateTime.Now.ToString() + "  用户：" + UserID + "\n");
            messageTextBox.AppendText(" " + sendTextBox.Text.Trim() + "\n\n");
            c.SendMessage(sendTextBox.Text.Trim(), UserID, chattingFriendID, time);
            sendTextBox.Text = "";
        }
        private void DownloadFriendListSuccess(object sender, EventArgs e)
        {
            if (friendListView.InvokeRequired)
            {
                ChangeControl CC = new ChangeControl(DownloadFriendListSuccess);
                this.Invoke(CC, sender, e);
            }
            else
            {
                //MessageBox.Show("form2.cs 118");
                friendListView.Clear();
                friendListView.BeginUpdate();
                friendListView.Columns.Add("好友");
                friendListView.Columns.Add("状态");
                friendListView.View = View.Details;
                for (int i=0; i<c.friendList.Count; i++)
                {
                    string UserID = ((FriendListItem)c.friendList[i]).UserID;
                    string IsOnline = "";
                    if(((FriendListItem)c.friendList[i]).IsOnline == true)
                    {
                        IsOnline = "在线";
                    }
                    else
                    {
                        IsOnline = "离线";
                    }
                    string[] s = { UserID, IsOnline };
                    ListViewItem item = new ListViewItem(s);
                    friendListView.Items.Add(item);
                }
                friendListView.EndUpdate();
            }
        }
        private void FriendRequestFail(object sender, EventArgs e)
        {
            DataPacket packet = (DataPacket)e;
            if (friendRequestWarningLabel.InvokeRequired)
            {
                ChangeControl CC = new ChangeControl(FriendRequestFail);
                this.Invoke(CC, sender, e);
            }
            else
            {
                friendRequestWarningLabel.Text = packet.Content.Replace("\0", "");
            }
        }
        private void AnotherUserFriendRequest(object sender, EventArgs e)
        {
            if (friendListView.InvokeRequired)
            {
                ChangeControl CC = new ChangeControl(AnotherUserFriendRequest);
                this.Invoke(CC, sender, e);
            }
            else
            {
                DataPacket packet = (DataPacket)e;
                JavaScriptSerializer js = new JavaScriptSerializer();
                dynamic content = js.Deserialize<dynamic>(packet.Content.Replace("\0", ""));
                string temp = content["UserID"];
                if (MessageBox.Show("用户" + temp + "申请成为你的好友，是否同意？", "新的好友申请", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //在逻辑层更新好友列表
                    c.ConfirmFriendRequest(packet.Content);
                    //刷新界面层的好友列表
                    friendListView.Clear();
                    friendListView.BeginUpdate();
                    friendListView.Columns.Add("好友");
                    friendListView.Columns.Add("状态");
                    friendListView.View = View.Details;
                    for (int i = 0; i < c.friendList.Count; i++)
                    {
                        string UserID = ((FriendListItem)c.friendList[i]).UserID;
                        string IsOnline = "";
                        if (((FriendListItem)c.friendList[i]).IsOnline == true)
                        {
                            IsOnline = "在线";
                        }
                        else
                        {
                            IsOnline = "离线";
                        }
                        string[] s = { UserID, IsOnline };
                        ListViewItem item = new ListViewItem(s);
                        friendListView.Items.Add(item);
                    }
                    friendListView.EndUpdate();
                }
            }
        }
        private void AnotherUserConfirmFriendRequest(object sender, EventArgs e)
        {
            if (friendListView.InvokeRequired)
            {
                ChangeControl CC = new ChangeControl(AnotherUserConfirmFriendRequest);
                this.Invoke(CC, sender, e);
            }
            else
            {
                friendListView.Clear();
                friendListView.BeginUpdate();
                friendListView.Columns.Add("好友");
                friendListView.Columns.Add("状态");
                friendListView.View = View.Details;
                for (int i = 0; i < c.friendList.Count; i++)
                {
                    string UserID = ((FriendListItem)c.friendList[i]).UserID;
                    string IsOnline = "";
                    if (((FriendListItem)c.friendList[i]).IsOnline == true)
                    {
                        IsOnline = "在线";
                    }
                    else
                    {
                        IsOnline = "离线";
                    }
                    string[] s = { UserID, IsOnline };
                    ListViewItem item = new ListViewItem(s);
                    friendListView.Items.Add(item);
                }
                friendListView.EndUpdate();
            }
        }
        private void RecieveSystemMessage(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                ChangeControl CC = new ChangeControl(RecieveSystemMessage);
                this.Invoke(CC, sender, e);
            }
            else
            {
                DataPacket packet = (DataPacket)e;
                MessageBox.Show(packet.Content.Replace("\0", ""), "系统消息");
            }
        }
        private void UpdateFriendListView(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                ChangeControl CC = new ChangeControl(UpdateFriendListView);
                this.Invoke(CC, sender, e);
            }
            else
            {
                friendListView.Clear();
                friendListView.BeginUpdate();
                friendListView.Columns.Add("好友");
                friendListView.Columns.Add("状态");
                friendListView.View = View.Details;
                for (int i = 0; i < c.friendList.Count; i++)
                {
                    string UserID = ((FriendListItem)c.friendList[i]).UserID;
                    string IsOnline = "";
                    if (((FriendListItem)c.friendList[i]).IsOnline == true)
                    {
                        IsOnline = "在线";
                    }
                    else
                    {
                        IsOnline = "离线";
                    }
                    string[] s = { UserID, IsOnline };
                    ListViewItem item = new ListViewItem(s);
                    friendListView.Items.Add(item);
                }
                friendListView.EndUpdate();
            }
        }
        private void RecieveMessage(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                ChangeControl CC = new ChangeControl(RecieveMessage);
                this.Invoke(CC, sender, e);
            }
            else
            {
                //播放声音
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = "C:\\Data\\c#\\FakeQQ_Client\\FakeQQ_Client\\message.wav";
                player.Load();
                player.Play();
                //闪烁托盘图标

                //显示消息
                DataPacket packet = (DataPacket)e;
                JavaScriptSerializer js = new JavaScriptSerializer();
                dynamic content = js.Deserialize<dynamic>(packet.Content.Replace("\0", ""));
                string SourceUserID = content["SourceUserID"];
                string Text = content["Text"];
                DateTime time = content["Time"];
                tabControl1.SelectedTab = tabPage2;//切换选项卡
                if (chattingFriendID == SourceUserID)
                {
                    messageTextBox.AppendText(time.ToString() + "  用户：" + SourceUserID + "\n");
                    messageTextBox.AppendText(" " + Text + "\n\n");
                }
                else
                {
                    chattingFriendID = SourceUserID;
                    chattingFriendLabel.Text = "正在与" + SourceUserID + "聊天";
                    messageTextBox.Clear();
                    messageTextBox.AppendText(time.ToString() + "  用户：" + SourceUserID + "\n");
                    messageTextBox.AppendText(" " + Text + "\n\n");
                }
            }
        }
    }
}