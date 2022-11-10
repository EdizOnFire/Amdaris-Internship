using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_handling_and_debugging.Models
{
    public abstract class User
    {
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }

        public abstract void Welcome();
    }
}
