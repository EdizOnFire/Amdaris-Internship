using static System.Console;

namespace Domain
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
