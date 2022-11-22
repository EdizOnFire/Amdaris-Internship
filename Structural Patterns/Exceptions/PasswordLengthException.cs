using static System.Console;

namespace Exceptions
{
    public class PasswordLengthException : Exception
    {
        public PasswordLengthException()
            : base("The password must be at least 5 characters.")
        { }
    }
}
