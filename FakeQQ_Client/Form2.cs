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


namespace FakeQQ_Client
{
    public partial class Form2 : Form
    {
        private ClientOperation c;
        private string UserID;
        public Form2(ClientOperation c, string UserID)
        {
            this.UserID = UserID;
            this.Text = "FakeQQ " + UserID;
            this.c = c;
            this.c.DownloadFriendList(UserID);//从服务器更新好友列表
            InitializeComponent();
            ClientOperation.DownloadFriendListSuccess += new ClientOperation.CrossThreadCallControlHandler(DownloadFriendListSuccess);
            ClientOperation.FriendRequestFail += new ClientOperation.CrossThreadCallControlHandler(FriendRequestFail);
            ClientOperation.AnotherUserFriendRequest += new ClientOperation.CrossThreadCallControlHandler(AnotherUserFriendRequest);
        }

        private delegate void ChangeControl(object sender, EventArgs e);

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("退出程序");
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)//用户请求添加好友
        {
            string friendID = textBox1.Text.Trim();
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
        private void DownloadFriendListSuccess(object sender, EventArgs e)
        {
            DataPacket packet = (DataPacket)e;
            JavaScriptSerializer js = new JavaScriptSerializer();
            ArrayList friendList = js.Deserialize<ArrayList>(packet.Content.Replace("\0", ""));
            if (listView1.InvokeRequired)
            {
                ChangeControl CC = new ChangeControl(DownloadFriendListSuccess);
                this.Invoke(CC, sender, e);
            }
            else
            {
                listView1.Clear();
                for(int i=0; i<friendList.Count; i++)
                {
                    listView1.Items.Add(friendList[i].ToString());
                }
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
            DataPacket packet = (DataPacket)e;
            JavaScriptSerializer js = new JavaScriptSerializer();
            dynamic content = js.Deserialize<dynamic>(packet.Content.Replace("\0", ""));
            string UserID = content["UserID"];
            if (MessageBox.Show("用户" + UserID + "申请成为你的好友，是否同意？", "新的好友申请", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                c.ConfirmFriendRequest(packet.Content);
            }
        }
    }
}