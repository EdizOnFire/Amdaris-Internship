using Exception_handling_and_debugging.Models;
using Exceptions;

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
            try
            {
                answer = AnswerFromConsole("Do you want to increase or lower the pitch? 'i' or 'l'. ");
                if (answer == "i")
                {
                    try
                    {
                        answer = AnswerFromConsole("By how much? ");
                        if (answer == "0")
                        {
                            throw new ZeroException();
                        }

                        PitchEditor.IncreasePitch(int.Parse(answer));
                    }
                    catch (ZeroException e)
                    {
                        Console.WriteLine(e.Message);
                        ChangePitchQuestion();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Enter only numbers.");
                        ChangePitchQuestion();
                    }
                }
                else if (answer == "l")
                {
                    try
                    {
                        answer = AnswerFromConsole("By how much? ");
                        if (answer == "0")
                        {
                            throw new ZeroException();
                        }

                        PitchEditor.LowerPitch(int.Parse(answer));
                    }
                    catch (ZeroException e)
                    {
                        Console.WriteLine(e.Message);
                        ChangePitchQuestion();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Enter only numbers.");
                        ChangePitchQuestion();
                    }
                }
                else
                {
                    throw new InvalidEditAction();
                }
            }
            catch (InvalidEditAction e)
            {
                Console.WriteLine(e.Message);
                ChangePitchQuestion();
            }
        }
    }
}
