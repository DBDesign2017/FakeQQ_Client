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

namespace FakeQQ_Client
{
    public partial class Form2 : Form
    {
        private ClientOperation c;
        private ArrayList friendList;
        public Form2(ClientOperation c)
        {
            this.c = c;
            friendList = new ArrayList();
            c.DownloadFriendList(ref friendList);//从服务器更新好友列表
            for(int i=0; i<friendList.Count; i++)
            {
                listView1.Items.Add(friendList[i].ToString());
            }
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("退出程序");
            Application.Exit();
        }
    }
}
