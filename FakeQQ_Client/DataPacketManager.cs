using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FakeQQ_Client
{
    class DataPacketManager:EventArgs
    {
        public Socket socket = null;
        public const int MAX_SIZE = 8096;
        public byte[] buffer = new byte[MAX_SIZE];
    }
}
