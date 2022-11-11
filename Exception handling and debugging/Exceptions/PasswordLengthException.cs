using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class PasswordLengthException : Exception
    {
        public PasswordLengthException()
            : base("The password must be at least 5 characters.")
        { }
    }
}
