using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FakeQQ_Client
{
    class SendPacket
    {
        public static void Send(Socket handler, DataPacket packet)
        {
            byte[] byteData = packet.PacketToBytes();
            handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
        }
        public static void SendCallback(IAsyncResult iar)
        {
            try
            {
                //重新获取socket
                Socket handler = (Socket)iar.AsyncState;
                //完成发送字节数组动作
                int bytesSent = handler.EndSend(iar);
                Console.WriteLine("Send {0} bytes to server ", bytesSent);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
