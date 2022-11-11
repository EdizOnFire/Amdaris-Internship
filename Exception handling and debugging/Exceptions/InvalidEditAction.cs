using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class InvalidEditAction : Exception
    {
        public InvalidEditAction()
            : base("Please choose either 'i' to increase the pitch or 'l' to lower it.")
        { }
    }
}
