using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Collections;

namespace FakeQQ_Client
{
    public class ClientOperation
    {
        private Socket client;
        public ArrayList friendList;
        public string UserID;

        public ClientOperation()
        {
            //验证是否能够连接到服务器
            DataPacket packet = new DataPacket();
            packet.CommandNo = 255;
            packet.FromIP = IPAddress.Parse("127.0.0.2");
            packet.ToIP = IPAddress.Parse("127.0.0.2");
            packet.ComputerName = "client";
            packet.NameLength = packet.ComputerName.Length;
            packet.Content = "";

            try
            {
                IPAddress local = IPAddress.Parse("127.0.0.1");
                int port = 8500;
                IPEndPoint iep = new IPEndPoint(local, port);
                DataPacketManager sendedData = new DataPacketManager();
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sendedData.socket = this.client;
                sendedData.buffer = packet.PacketToBytes();
                client.BeginConnect(iep, new AsyncCallback(ConnectCallback), sendedData);
                Send(client, packet.PacketToBytes());
                //接收一次服务器的验证包
                //进入接收数据死循环
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
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        //定义了逻辑层和界面层通信的事件
        public delegate void CrossThreadCallControlHandler(object sender, EventArgs e);
        public static event CrossThreadCallControlHandler LoginSuccess;
        public static event CrossThreadCallControlHandler LoginFail;
        public static event CrossThreadCallControlHandler RegisterSuccess;
        public static event CrossThreadCallControlHandler RegisterFail;
        public static event CrossThreadCallControlHandler DownloadFriendListSuccess;
        public static event CrossThreadCallControlHandler FriendRequestFail;
        public static event CrossThreadCallControlHandler AnotherUserFriendRequest;
        public static event CrossThreadCallControlHandler AnotherUserConfirmFriendRequest;
        public static event CrossThreadCallControlHandler RecieveSystemMessage;
        public static event CrossThreadCallControlHandler UpdateFriendListView;
        public static event CrossThreadCallControlHandler RecieveMessage;
        public static event CrossThreadCallControlHandler ChangePasswordResult;
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
        private static void ToDownloadFriendListSuccess(object sender, EventArgs e)
        {
            DownloadFriendListSuccess?.Invoke(sender, e);
        }
        private static void ToFriendRequestFail(object sender, EventArgs e)
        {
            FriendRequestFail?.Invoke(sender, e);
        }
        private static void ToAnotherUserFriendRequest(object sender, EventArgs e)
        {
            AnotherUserFriendRequest?.Invoke(sender, e);
        }
        private static void ToAnotherUserConfirmFriendRequest(object sender, EventArgs e)
        {
            AnotherUserConfirmFriendRequest?.Invoke(sender, e);
        }
        private static void ToRecieveSystemMessage(object sender, EventArgs e)
        {
            RecieveSystemMessage?.Invoke(sender, e);
        }
        private static void ToUpdateFriendListView(object sender, EventArgs e)
        {
            UpdateFriendListView?.Invoke(sender, e);
        }
        private static void ToRecieveMessage(object sender, EventArgs e)
        {
            RecieveMessage?.Invoke(sender, e);
        }
        private static void ToChangePasswordResult(object sender, EventArgs e)
        {
            ChangePasswordResult?.Invoke(sender, e);
        }
        
        //发送心跳包
        public void SendHeartBeatPacket(object sender, System.Timers.ElapsedEventArgs e)
        {
            //构造数据包
            DataPacket packet = new DataPacket();
            packet.CommandNo = 254;
            packet.Content = UserID;
            packet.FromIP = IPAddress.Parse("127.0.0.2");
            packet.ToIP = IPAddress.Parse("127.0.0.2");
            packet.ComputerName = "client";
            packet.NameLength = packet.ComputerName.Length;
            //发送
            try
            {
                Send(client, packet.PacketToBytes());
            }
            catch
            {
                Console.WriteLine("发送心跳包出错");
            }
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
            //发送！
            try
            {
                Send(client, packet.PacketToBytes());
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
                Send(client, packet.PacketToBytes());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return;

        }

        //请求从服务器上下载好友列表
        public void DownloadFriendList(string UserID)
        {
            //构造要发送的数据包
            DataPacket packet = new DataPacket();
            packet.CommandNo = 9;
            packet.FromIP = IPAddress.Parse("127.0.0.2");
            packet.ToIP = IPAddress.Parse("127.0.0.2");
            packet.ComputerName = "";
            packet.NameLength = packet.ComputerName.Length;
            //处理数据包的Content部分
            packet.Content = UserID;//仅包含当前用户的ID
            //发送！
            try
            {
                Send(client, packet.PacketToBytes());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return;
        }

        //请求添加一个好友
        public void FriendRequest(string UserID, string FriendID)
        {
            //构造要发送的数据包
            DataPacket packet = new DataPacket();
            packet.CommandNo = 6;
            packet.FromIP = IPAddress.Parse("127.0.0.2");
            packet.ToIP = IPAddress.Parse("127.0.0.2");
            packet.ComputerName = "";
            packet.NameLength = packet.ComputerName.Length;
            //处理数据包的Content部分
            FriendRequestData content = new FriendRequestData(UserID, FriendID);
            JavaScriptSerializer js = new JavaScriptSerializer();
            packet.Content = js.Serialize(content);
            //发送！
            try
            {
                Send(client, packet.PacketToBytes());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return;
        }

        //同意别人的添加好友请求
        public void ConfirmFriendRequest(string Content)
        {
            //构造数据包
            DataPacket packet = new DataPacket();
            packet.Content = Content;
            packet.CommandNo = 10;
            packet.FromIP = IPAddress.Parse("127.0.0.2");
            packet.ToIP = IPAddress.Parse("127.0.0.2");
            packet.ComputerName = "client";
            packet.NameLength = packet.ComputerName.Length;
            //发送！
            try
            {
                Send(client, packet.PacketToBytes());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            //在本地的好友列表里面加一项
            JavaScriptSerializer js = new JavaScriptSerializer();
            dynamic content = js.Deserialize<dynamic>(Content.Replace("\0", ""));
            FriendListItem item = new FriendListItem();
            string newFriend = content["UserID"];
            item.UserID = newFriend;
            item.IsOnline = true;
            friendList.Add(item);
        }

        //请求发送即时消息
        public void SendMessage(string text, string UserID, string targetUserID, DateTime time)
        {
            //构造数据包
            DataPacket packet = new DataPacket();
            packet.CommandNo = 11;
            packet.ComputerName = "client";
            packet.NameLength = packet.ComputerName.Length;
            packet.FromIP = IPAddress.Parse("127.0.0.2");
            packet.ToIP = IPAddress.Parse("127.0.0.2");
            //处理数据包的Content部分
            Message message = new FakeQQ_Client.Message(text, UserID, targetUserID, time);
            JavaScriptSerializer js = new JavaScriptSerializer();
            packet.Content = js.Serialize(message);
            //发送！
            try
            {
                Send(client, packet.PacketToBytes());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //请求修改密码
        public void ChangePassword(ChangePasswordData data)
        {
            //构造要发送的数据包
            DataPacket packet = new DataPacket();
            packet.CommandNo = 3;
            packet.ComputerName = "client";
            packet.NameLength = packet.ComputerName.Length;
            packet.FromIP = IPAddress.Parse("127.0.0.2");
            packet.ToIP = IPAddress.Parse("127.0.0.2");
            //处理数据包的Content部分
            JavaScriptSerializer js = new JavaScriptSerializer();
            packet.Content = js.Serialize(data);
            //发送！
            try
            {
                Send(client, packet.PacketToBytes());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return;
        }

        //请求删除一个好友
        public void DeleteFriend(string FriendID)
        {
            //构造要发送的数据包
            DataPacket packet = new DataPacket();
            packet.CommandNo = 7;
            packet.ComputerName = "client";
            packet.NameLength = packet.ComputerName.Length;
            packet.FromIP = IPAddress.Parse("127.0.0.2");
            packet.ToIP = IPAddress.Parse("127.0.0.2");
            //处理数据包的Content部分
            DeleteFriendData data = new DeleteFriendData();
            data.UserID = UserID;
            data.FriendID = FriendID;
            JavaScriptSerializer js = new JavaScriptSerializer();
            packet.Content = js.Serialize(data);
            //发送！
            try
            {
                Send(client, packet.PacketToBytes());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            //在本地好友列表里面删除这一条，更新界面
            for(int i=0; i<friendList.Count; i++)
            {
                if(FriendID == ((FriendListItem)friendList[i]).UserID)
                {
                    friendList.RemoveAt(i);
                    break;
                }
            }
            ToUpdateFriendListView(null, null);
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
                    case 1://登录成功
                        {
                            UserID = packet.Content.Replace("\0", "");
                            //发布登录成功事件
                            Console.WriteLine("login success event occur");
                            ToLoginSuccess(null, packet);
                            break;
                        }
                    case 2://登录失败
                        {
                            //发布登录失败事件
                            Console.WriteLine("login fail event occur");
                            ToLoginFail(null, null);
                            break;
                        }
                    case 3://注册成功
                        {
                            //发布注册成功事件
                            Console.WriteLine("register success! event occur");
                            ToRegisterSuccess(null, packet);
                            break;
                        }
                    case 4://注册失败
                        {
                            //发布注册失败事件
                            Console.WriteLine("register fail! event occur");
                            ToRegisterFail(null, null);
                            break;
                        }
                    case 5://修改密码成功
                        {
                            ToChangePasswordResult(null, packet);
                            break;
                        }
                    case 6://修改密码失败
                        {
                            ToChangePasswordResult(null, packet);
                            break;
                        }
                    case 12://添加好友失败
                        {
                            //发布添加好友失败事件
                            Console.WriteLine("friend request fail! event occur");
                            ToFriendRequestFail(null, packet);
                            break;
                        }
                    case 13://被删好友了
                        {
                            JavaScriptSerializer js = new JavaScriptSerializer();
                            dynamic content = js.Deserialize<dynamic>(packet.Content.Replace("\0", ""));
                            string FriendID = content["UserID"];
                            for(int i=0; i < friendList.Count; i++)
                            {
                                if(FriendID == ((FriendListItem)friendList[i]).UserID)
                                {
                                    friendList.RemoveAt(i);
                                    break;
                                }
                            }
                            ToUpdateFriendListView(null, null);
                            break;
                        }
                    case 17://下载好友列表成功
                        {
                            //在逻辑层更新好友列表
                            friendList = new ArrayList();
                            JavaScriptSerializer js = new JavaScriptSerializer();
                            dynamic temp = js.Deserialize<dynamic>(packet.Content.Replace("\0", ""));
                            for(int i=0; i<temp.Length; i++)
                            {
                                FriendListItem item = new FriendListItem();
                                item.UserID = temp[i]["UserID"];
                                item.IsOnline = temp[i]["IsOnline"];
                                if(item != null)
                                {
                                    friendList.Add(item);
                                }
                            }
                            //发布下载好友列表成功事件
                            Console.WriteLine("download friend list success event occur");
                            ToDownloadFriendListSuccess(null, null);
                            break;
                        }
                    case 18://下载好友列表失败
                        {
                            //并没有发布下载好友列表失败事件
                            Console.WriteLine("download friend list fail event occur");
                            break;
                        }
                    case 19://有其他用户请求添加好友
                        {
                            //发布有其他用户请求添加好友事件
                            Console.WriteLine("a user want to be your friend!");
                            ToAnotherUserFriendRequest(null, packet);
                            break;
                        }
                    case 20://接收好友申请的用户同意了自己的好友申请，要修改
                        {
                            JavaScriptSerializer js = new JavaScriptSerializer();
                            dynamic content = js.Deserialize<dynamic>(packet.Content.Replace("\0", ""));
                            string ID = content["FriendID"];
                            FriendListItem item = new FriendListItem();
                            item.UserID = ID;
                            item.IsOnline = true;
                            //在逻辑层更新好友列表
                            friendList.Add(item);
                            //发布事件，让界面层显示新的好友列表
                            ToAnotherUserConfirmFriendRequest(null, null);
                            break;
                        }
                    case 21://来自其他用户的即时消息
                        {
                            Console.WriteLine("recieve callback case 21");
                            ToRecieveMessage(null, packet);
                            break;
                        }
                    case 24://接收到系统消息
                        {
                            //发布收到系统消息事件
                            ToRecieveSystemMessage(null, packet);
                            break;
                        }
                    case 25://某个好友上线了
                        {
                            Console.WriteLine("recieve callback case 25 a friendLogin");
                            //在逻辑层更新好友列表
                            string ID = packet.Content.Replace("\0", "");
                            for(int i=0; i<friendList.Count; i++)
                            {
                                if (((FriendListItem)friendList[i]).UserID == ID)
                                {
                                    ((FriendListItem)friendList[i]).IsOnline = true;
                                    break;
                                }
                            }
                            //发布需要在界面层刷新好友列表事件
                            ToUpdateFriendListView(null, null);
                            break;
                        }
                    case 26://自己发送的即时消息失败了
                        {
                            break;
                        }
                    case 27://某个好友下线了
                        {
                            Console.WriteLine("a firend is offline");
                            string friendID = packet.Content.Replace("\0", "");
                            for(int i=0; i<friendList.Count; i++)
                            {
                                if(((FriendListItem)friendList[i]).UserID == friendID)
                                {
                                    ((FriendListItem)friendList[i]).IsOnline = false;
                                    break;
                                }
                            }
                            ToUpdateFriendListView(null, null);
                            break;
                        }
                    default:
                        break;
                }
                DataPacketManager newRecieveData = new DataPacketManager();
                newRecieveData.socket = recieveData.socket;
                newRecieveData.socket.BeginReceive(newRecieveData.buffer, 0, DataPacketManager.MAX_SIZE, SocketFlags.None,
                    new AsyncCallback(RecieveCallback), newRecieveData);
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
            try
            {
                data.socket.EndConnect(iar);
                Send(data.socket, data.buffer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("连接到服务器失败");
                client.Close();
            }
        }

        private void Send(Socket handler, byte[] buffer)
        {
            handler.BeginSend(buffer, 0, buffer.Length, 0, new AsyncCallback(SendCallback), handler);
        }
        private void SendCallback(IAsyncResult iar)
        {
            try
            {
                //重新获取socket
                Socket handler = (Socket)iar.AsyncState;
                //handler.BeginAccept(new AsyncCallback(AcceptCallback), handler);//重新开始监听
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
