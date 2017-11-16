using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace FakeQQ_Client
{
    public class ClientOperation
    {
        private Form2 Form;
        private Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public delegate void CrossThreadCallControlHandler(object sender, EventArgs e);
        public static event CrossThreadCallControlHandler LoginSuccess;
        public static event CrossThreadCallControlHandler LoginFail;
        public static event CrossThreadCallControlHandler RegisterSuccess;
        public static event CrossThreadCallControlHandler RegisterFail;
        private static void ToLoginSuccess(object sender, EventArgs e)
        {
            LoginSuccess?.Invoke(sender, e);
        }
        private static void ToLoginFail(object sender, EventArgs e)
        {
            LoginFail?.Invoke(sender, e);
        }
        private static void ToRegisterSuccess(object sender, EventArgs e)
        {
            RegisterSuccess?.Invoke(sender, e);
        }
        private static void ToRegisterFail(object sender, EventArgs e)
        {
            RegisterFail?.Invoke(sender, e);
        }

        //用户登录
        public void Login(string input_ID, string input_PW)
        {
            //构造要发送的数据包
            DataPacket packet = new DataPacket();
            packet.CommandNo = 1;
            packet.FromIP = IPAddress.Parse("127.0.0.2");
            packet.ToIP = IPAddress.Parse("127.0.0.2");
            packet.ComputerName = input_ID;
            packet.NameLength = packet.ComputerName.Length;

            //处理数据包的Content部分
            LoginData content = new LoginData();
            content.UserID = input_ID;
            content.Password = input_PW;
            JavaScriptSerializer js = new JavaScriptSerializer();
            packet.Content = js.Serialize(content);

            /*dynamic test = js.Deserialize<dynamic>(packet.Content);//动态的反序列化
            string test1 = test["UserID"];
            string test2 = test["PassWord"];*/
            //序列化和反序列化没问题

            //发送！
            try
            {
                IPAddress local = IPAddress.Parse("127.0.0.1");
                int port = 8500;
                IPEndPoint iep = new IPEndPoint(local, port);
                DataPacketManager sendedData = new DataPacketManager();
                sendedData.socket = this.client;
                sendedData.buffer = packet.PacketToBytes();
                client.BeginConnect(iep, new AsyncCallback(ConnectCallback), sendedData);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            //等待服务器的回信
            DataPacketManager recieveData = new DataPacketManager();
            recieveData.socket = client;
            try
            {
                client.BeginReceive(recieveData.buffer, 0, DataPacketManager.MAX_SIZE, SocketFlags.None,
                new AsyncCallback(RecieveCallback), recieveData);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return;
        }
        
        //用户注册
        public void Register(string input_PW)
        {
            //构造要发送的数据包
            DataPacket packet = new DataPacket();
            packet.CommandNo = 2;
            packet.FromIP = IPAddress.Parse("127.0.0.2");
            packet.ToIP = IPAddress.Parse("127.0.0.2");
            packet.ComputerName = "";
            packet.NameLength = packet.ComputerName.Length;
            //处理数据包的Content部分
            RegisterData content = new RegisterData();
            content.Password = input_PW;
            JavaScriptSerializer js = new JavaScriptSerializer();
            packet.Content = js.Serialize(content);
            //发送！
            try
            {
                IPAddress local = IPAddress.Parse("127.0.0.1");
                int port = 8500;
                IPEndPoint iep = new IPEndPoint(local, port);
                DataPacketManager sendedData = new DataPacketManager();
                sendedData.socket = client;
                sendedData.buffer = packet.PacketToBytes();
                client.BeginConnect(iep, new AsyncCallback(ConnectCallback), sendedData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            //等待服务器的回信
            DataPacketManager recieveData = new DataPacketManager();
            recieveData.socket = client;
            try
            {
                client.BeginReceive(recieveData.buffer, 0, DataPacketManager.MAX_SIZE, SocketFlags.None,
                new AsyncCallback(RecieveCallback), recieveData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return;

        }
        private void RecieveCallback(IAsyncResult iar)
        {
            DataPacketManager recieveData = iar.AsyncState as DataPacketManager;
            int bytes = recieveData.socket.EndReceive(iar);
            if (bytes > 0)
            {
                DataPacket packet = new DataPacket(recieveData.buffer);
                Console.WriteLine("recieve packet commandNo = " + packet.CommandNo.ToString());
                //接下根据packet内的commandNo进行各种不同操作
                switch (packet.CommandNo)
                {
                    case 1:
                        {
                            //发布登录成功事件
                            Console.WriteLine("login success");
                            ToLoginSuccess(null, null);
                            break;
                        }
                    case 2:
                        {
                            //发布登录失败事件
                            Console.WriteLine("login fail");
                            ToLoginFail(null, null);
                            break;
                        }
                    case 3:
                        {
                            //发布注册成功事件
                            Console.WriteLine("register success!");
                            ToRegisterSuccess(null, packet);
                            break;
                        }
                    case 4:
                        {
                            //发布注册失败事件
                            Console.WriteLine("register fail!");
                            ToRegisterFail(null, null);
                            break;
                        }
                    default:
                        break;
                }
            }
            else
            {
                recieveData.socket.BeginReceive(recieveData.buffer, 0, DataPacketManager.MAX_SIZE, SocketFlags.None,
                new AsyncCallback(RecieveCallback), recieveData);
            }
        }
        private void ConnectCallback(IAsyncResult iar)
        {
            DataPacketManager data = (DataPacketManager)iar.AsyncState;
            bool success = true;
            try
            {
                data.socket.EndConnect(iar);
                Send(data.socket, data.buffer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("连接到服务器失败");
                success = false;
                client.Close();
            }
            finally
            {

            }
            if (success == true)
            {
                Console.WriteLine("success");
            }
            else
            {
                Console.WriteLine("fail");
            }
        }

        private static void Send(Socket handler, byte[] buffer)
        {
            handler.BeginSend(buffer, 0, buffer.Length, 0, new AsyncCallback(SendCallback), handler);
        }
        private static void SendCallback(IAsyncResult iar)
        {
            try
            {
                //重新获取socket
                Socket handler = (Socket)iar.AsyncState;
                //完成发送字节数组动作
                int bytesSent = handler.EndSend(iar);
                Console.WriteLine("Send {0} bytes to server ", bytesSent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
