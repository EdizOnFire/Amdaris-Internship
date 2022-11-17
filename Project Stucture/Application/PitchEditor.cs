using System;
using Domain;

namespace Application
{
    public class PitchEditor : AudioEditor
    {
        public override void Clarification()
        {
            Console.WriteLine("You've opened the Pitch Editor.");
        }

        public static void IncreasePitch(int number)
        {
            Console.WriteLine($"Your audio's pitch is increased by {number} semitones.");
        }

        public static void LowerPitch(int number)
        {
            Console.WriteLine($"Your audio's pitch is lowered by {number} semitones.");
        }
    }
}