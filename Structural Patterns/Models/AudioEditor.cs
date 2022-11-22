using static System.Console;

namespace Models
{
    public abstract class AudioEditor
    {
        public virtual void Clarification()
        {
            WriteLine("You've opened the Audio Editor.");
        }

        public static void UploadAudio()
        {
            WriteLine("The audio file is uploaded.");
        }

        public static void UploadAudio(int number)
        {
            WriteLine($"{number} audio files are uploaded.");
        }
    }
}
