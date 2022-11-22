using static System.Console;

namespace Exceptions
{
    public class ZeroException : Exception
    {
        public ZeroException()
            : base("Enter a number higher or lower than 0.")
        { }
    }
}
