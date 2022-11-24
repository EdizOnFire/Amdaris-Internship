using static System.Console;
using Domain;
using Infrastructure;

namespace Application
{
    class Upload
    {
        public static void UploadFileQuestion()
        {
            string answer = Answer.AnswerFromConsole("Do you want to upload audio? 'y' or 'n'.\n");
            if (answer == "y")
            {
                AudioEditor.UploadAudio();
                Proxy.UploadToDB();
                PitchEditor.ChangePitchQuestion();
                TempoEditor.ChangeTempoQuestion();
            }
        }
    }
}
