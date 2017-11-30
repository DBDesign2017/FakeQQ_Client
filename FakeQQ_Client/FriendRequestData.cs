using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeQQ_Client
{
    class FriendRequestData
    {
        public string UserID;
        public string FriendID;
        public FriendRequestData(string UserID, string FriendID)
        {
            this.UserID = UserID;
            this.FriendID = FriendID;
            return;
        }
    }
}
