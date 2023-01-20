using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioShare.Application.Exceptions
{
    public class NotOwnerException : Exception
    {
        public NotOwnerException()
          : base("The user is not the owner.")
        { }
    }
}
