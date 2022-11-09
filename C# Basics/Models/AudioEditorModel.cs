using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Basics.Models
{
    public class AudioEditorModel
    {
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
