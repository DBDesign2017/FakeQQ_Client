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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c = new ClientOperation();
            c.Login(textBox1.Text.Trim(), textBox2.Text.Trim());
            button1.Text = "登录中";
            ClientOperation.LoginSuccess += new ClientOperation.LoginSuccessHandler(LoginSuccess);
            /*if(c.Login(textBox1.Text.Trim(), textBox2.Text.Trim()) == true)
            {
                new System.Threading.Thread(() =>
                {
                    Application.Run(new Form2(c));
                }).Start();
                this.Close();
            }
            else
            {
                MessageBox.Show("登录失败！");
            }*/
        }

        private void LoginSuccess(object sender, EventArgs e)
        {
            new System.Threading.Thread(() =>
            {
                Application.Run(new Form2(c));
            }).Start();
            this.Close();
        }
    }
}
