using C_Sharp_Basics.Models;

public static class AudioEditorApp
{
    public static string AnswerFromConsole(string request)
    {
        Console.Write(request);
        return Console.ReadLine();
    }

    public static void Register(RegisteredUser user)
    {
        user.Username = AnswerFromConsole("Please enter your username: ");
        user.Password = AnswerFromConsole("Please enter your password: ");
    }

    public static void UploadFileQuestion()
    {
        string answer = AnswerFromConsole("Do you want to upload audio? 'y' or 'n'. ");
        if (answer == "y")
        {
            AudioEditor.UploadAudio();
            ChangePitchQuestion();
        }
    }

    public static void ChangePitchQuestion()
    {
        string answer = AnswerFromConsole("Do you want to change the pitch? 'y' or 'n'. ");
        if (answer == "y")
        {
            answer = AnswerFromConsole("Do you want to increase or lower the pitch? 'i' or 'l'. ");
            if (answer == "i")
            {
                answer = AnswerFromConsole("By how much? ");
                PitchEditor.IncreasePitch(int.Parse(answer));
            }
            else if (answer == "l")
            {
                answer = AnswerFromConsole("By how much? ");
                PitchEditor.LowerPitch(int.Parse(answer));
            }
        }
    }
}