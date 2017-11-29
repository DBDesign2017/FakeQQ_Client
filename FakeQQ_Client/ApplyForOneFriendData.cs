using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeQQ_Client
{
    class ApplyForOneFriendData
    {
        public string UserID;
        public string FriendID;
        public ApplyForOneFriendData(string UserID, string FriendID)
        {
            this.UserID = UserID;
            this.FriendID = FriendID;
            return;
        }
    }
}
