using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakeQQ_Client
{
    class FriendListItem : ListViewItem
    {
        private string userID;
        private bool isOnline;
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public bool IsOnline
        {
            get { return isOnline; }
            set { isOnline = value; }
        }
    }
}
