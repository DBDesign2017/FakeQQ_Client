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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //构造要发送的数据包
            DataPacket packet = new DataPacket();
            packet.CommandNo = 1;
            /*IPAddress local = IPAddress.Parse("127.0.0.1");
            int port = 8500;
            IPEndPoint iep = new IPEndPoint(local, port);*/
            packet.FromIP = IPAddress.Parse("127.0.0.2");
            //处理数据包的Content部分
            LoginData content = new LoginData();
            content.UserID = textBox1.Text.Trim();
            content.PassWord = textBox1.Text.Trim();
            JavaScriptSerializer js = new JavaScriptSerializer();
            packet.Content = js.Serialize(content);

            //发送！
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress local = IPAddress.Parse("127.0.0.1");
            int port = 8500;
            IPEndPoint iep = new IPEndPoint(local, port);
            client.BeginConnect(iep, new AsyncCallback(Connect), client);
        }

        void Connect(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            try
            {
                client.EndConnect(iar);
                Console.WriteLine("success");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {

            }
        }
    }
}
