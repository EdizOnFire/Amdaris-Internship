using static System.Console;
using System;

namespace Application
{
    public class ZeroException : Exception
    {
        public ZeroException()
            : base("Enter a number higher or lower than 0.")
        { }
    }
}
