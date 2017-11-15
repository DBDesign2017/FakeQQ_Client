using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c = new ClientOperation();
            c.Login(textBox1.Text.Trim(), textBox2.Text.Trim());
            label5.Text = "登录中";
        }

        private delegate void ChangeControl(object sender, EventArgs e);
        private void LoginSuccess(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                ChangeControl CC = new ChangeControl(LoginSuccess);
                this.Invoke(CC, sender, e);
            }
            else
            {
                new System.Threading.Thread(() =>
                {
                    Application.Run(new Form2(c));
                }).Start();
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

        private void button2_Click(object sender, EventArgs e)
        {
            /*if (textBox3.Text.Trim() == textBox4.Text.Trim() && textBox3.Text.Trim() != "" && textBox3.Text.Trim().Length < 17)
            {
                c.Register(textBox3.Text.Trim());
                label5.Text = "注册中";
            }
            else
            {
                label5.Text = "注册失败";
            }*/
        }

        /*private void RegisterSuccess(object sender, EventArgs e)
        {
            string ID = (string)e;
            label5.Text = "注册成功！您的账号为：" + ID;
        }*/
    }
}
