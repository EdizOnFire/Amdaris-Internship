using Models;

namespace StructuralPattern
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
