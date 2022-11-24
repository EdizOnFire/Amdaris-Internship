using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BaseAudioFile : IAudioEffect
    {
        public double GetSize()
        {
            return 8.54;
        }

        public string GetType()
        {
            return "Audio file";
        }
    }
}
