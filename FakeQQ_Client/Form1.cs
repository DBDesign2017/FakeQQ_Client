using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace FakeQQ_Client
{
    public partial class Form1 : Form
    {
        private ClientOperation c;
        public Form1()
        {
            InitializeComponent();
            ClientOperation.LoginSuccess += new ClientOperation.CrossThreadCallControlHandler(LoginSuccess);
            ClientOperation.LoginFail += new ClientOperation.CrossThreadCallControlHandler(LoginFail);
            ClientOperation.RegisterSuccess += new ClientOperation.CrossThreadCallControlHandler(RegisterSuccess);
            ClientOperation.RegisterFail += new ClientOperation.CrossThreadCallControlHandler(RegisterFail);
            textBox1.Text = Properties.Settings.Default.LastUserID;
            lastLoginTimeLabel.Text = "最近登录时间：" + Properties.Settings.Default.LastLoginTime.ToString();
        }

        private delegate void ChangeControl(object sender, EventArgs e);

        private void button1_Click(object sender, EventArgs e)//用户登录
        {
            c = new ClientOperation();
            c.Login(textBox1.Text.Trim(), textBox2.Text.Trim());
            label5.Text = "登录中";
        }

        private void LoginSuccess(object sender, EventArgs e)
        {
            DataPacket packet = (DataPacket)e;
            if (this.InvokeRequired)
            {
                ChangeControl CC = new ChangeControl(LoginSuccess);
                this.Invoke(CC, sender, e);
            }
            else
            {
                //保存登录成功的账号，下次显示
                string UserID = packet.Content.Replace("\0", "");
                Properties.Settings.Default.LastUserID = UserID;
                Properties.Settings.Default.LastLoginTime = DateTime.Now;
                Properties.Settings.Default.Save();
                //打开新窗口
                new System.Threading.Thread(() =>
                {
                    Application.Run(new Form2(c, packet.Content.Replace("\0", "")));
                }).Start();
                //不解绑内存会不会泄露？
                /*ClientOperation.LoginSuccess -= LoginSuccess;
                ClientOperation.LoginFail -= LoginFail;
                ClientOperation.RegisterSuccess -= RegisterSuccess;
                ClientOperation.RegisterFail -= RegisterFail;*/
                this.Close();
            }
        }
        private void LoginFail(object sender, EventArgs e)
        {
            if (label5.InvokeRequired)
            {
                ChangeControl CC = new ChangeControl(LoginFail);
                this.Invoke(CC, sender, e);
            }
            else
            {
                label5.Text = "登录失败，用户名或密码错误";
            }
        }

        private void button2_Click(object sender, EventArgs e)//注册账户
        {
            c = new ClientOperation();
            string input_PW = textBox3.Text.Trim();//没有做安全性检查
            /*bool legal = true;
            for(int i=0; i< input_PW.Length; i++)
            {
                if(input_PW[i].IsNumber())
                {
                    legal = false;
                }
            }*/
            if (input_PW == textBox4.Text.Trim() && input_PW != "" && input_PW.Length < 17)
            {
                c.Register(input_PW);
                label6.Text = "注册中";
            }
            else
            {
                label6.Text = "密码不符合要求，注册失败";
            }
        }

        private void RegisterSuccess(object sender, EventArgs e)
        {
            DataPacket packet = (DataPacket)e;
            /*JavaScriptSerializer js = new JavaScriptSerializer();
            dynamic content = js.Deserialize<dynamic>(packet.Content.Replace("\0", ""));//动态的反序列化，不删除Content后面的结束符的话无法反序列化 
            string ID = content["UserID"];//动态反序列化的结果必须用索引取值*/
            string ID = packet.Content.Replace("\0", "");
            if (label6.InvokeRequired)
            {
                ChangeControl CC = new ChangeControl(RegisterSuccess);
                this.Invoke(CC, sender, e);
            }
            else
            {
                label6.Text = "注册成功！您的账号为：" + ID;
            }
        }
        private void RegisterFail(object sender, EventArgs e)
        {
            if (label6.InvokeRequired)
            {
                ChangeControl CC = new ChangeControl(RegisterFail);
                this.Invoke(CC, sender, e);
            }
            else
            {
                label6.Text = "服务器错误";
            }
        }
    }
}
