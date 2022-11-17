using System;

namespace Domain.Exceptions
{
    public class ZeroException : Exception
    {
        public ZeroException()
            : base("Enter a number higher or lower than 0.")
        { }
    }
}
