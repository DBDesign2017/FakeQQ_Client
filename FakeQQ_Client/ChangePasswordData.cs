using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeQQ_Client
{
    public class ChangePasswordData
    {
        private string userID;
        private string oldPassword;
        private string newPassword;
        public string UserID
        {
            get
            {
                return userID;
            }
            set
            {
                this.userID = value;
            }
        }
        public string OldPassword
        {
            get
            {
                return oldPassword;
            }
            set
            {
                this.oldPassword = value;
            }
        }
        public string NewPassword
        {
            get
            {
                return newPassword;
            }
            set
            {
                this.newPassword = value;
            }
        }
    }
}
