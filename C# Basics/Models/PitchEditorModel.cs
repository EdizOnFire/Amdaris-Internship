using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Basics.Models
{
    public class PitchEditorModel : AudioEditorModel
    {
        public static void IncreasePitch(int number)
        {
            Console.WriteLine($"Pitch increased by {number} semitones.");
        }

        public static void LowerPitch(int number)
        {
            Console.WriteLine($"Pitch lowered by {number} semitones.");
        }
    }
}
