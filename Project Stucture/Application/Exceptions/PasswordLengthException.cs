using static System.Console;
using System;

namespace Application
{
    public class PasswordLengthException : Exception
    {
        public PasswordLengthException()
            : base("The password must be at least 5 characters.")
        { }
    }
}
