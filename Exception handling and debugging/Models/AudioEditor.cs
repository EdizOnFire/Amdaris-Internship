using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_handling_and_debugging.Models
{
    public abstract class AudioEditor
    {
        public virtual void Clarification()
        {
            Console.WriteLine("You've opened the Audio Editor.");
        }

        public static void UploadAudio()
        {
            Console.WriteLine("The audio file is uploaded.");
        }

        public static void UploadAudio(int number)
        {
            Console.WriteLine($"{number} audio files are uploaded.");
        }
    }
}
