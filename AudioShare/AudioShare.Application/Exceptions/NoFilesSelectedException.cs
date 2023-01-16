using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioShare.Application.Exceptions
{
    public class NoFilesSelectedException : Exception
    {
        public NoFilesSelectedException()
          : base("No files selected.")
        { }
    }
}
