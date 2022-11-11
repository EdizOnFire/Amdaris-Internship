using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class ZeroException : Exception
    {
        public ZeroException()
            : base("Enter a number higher or lower than 0.")
        { }
    }
}
