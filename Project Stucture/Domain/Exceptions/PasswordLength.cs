using System;

namespace Domain.Exceptions
{
    public class PasswordLengthException : Exception
    {
        public PasswordLengthException()
            : base("The password must be at least 5 characters.")
        { }
    }
}
