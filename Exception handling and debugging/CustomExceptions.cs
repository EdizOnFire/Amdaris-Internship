using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_handling_and_debugging
{
    public class ZeroException : Exception
    {
        public ZeroException()
            : base("Enter a number higher or lower than 0.")
        { }
    }

    public class PasswordLengthException : Exception
    {
        public PasswordLengthException()
            : base("The password must be at least 5 characters.")
        { }
    }
}
