using static System.Console;
using System;
using Domain;

namespace Application
{
    class PitchEditor : AudioEditor
    {
        public static void ChangePitchQuestion()
        {
            string answer = Answer.AnswerFromConsole("Do you want to change the pitch? 'y' or 'n'.\n");
            if (answer == "y")
            {
                try
                {
                    answer = Answer.AnswerFromConsole("Do you want to increase or lower the pitch? 'i' or 'l'.\n");
                    if (answer == "i")
                    {
                        try
                        {
                            answer = Answer.AnswerFromConsole("By how many semitones?\n");
                            if (answer == "0")
                            {
                                throw new ZeroException();
                            }

                            IncreasePitch(int.Parse(answer));
                        }
                        catch (ZeroException e)
                        {
                            WriteLine(e.Message);
                            ChangePitchQuestion();
                        }
                        catch (FormatException)
                        {
                            WriteLine("Enter only numbers.\n");
                            ChangePitchQuestion();
                        }
                    }
                    else if (answer == "l")
                    {
                        try
                        {
                            answer = Answer.AnswerFromConsole("By how much?\n");
                            if (answer == "0")
                            {
                                throw new ZeroException();
                            }

                            LowerPitch(int.Parse(answer));
                        }
                        catch (ZeroException e)
                        {
                            WriteLine(e.Message);
                            ChangePitchQuestion();
                        }
                        catch (FormatException)
                        {
                            WriteLine("Enter only numbers.\n");
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
                    WriteLine(e.Message);
                    ChangePitchQuestion();
                }
            }
        }
        public static void IncreasePitch(int number)
        {
            Clear();
            WriteLine($"Your audio's pitch is increased by {number} semitones.\n");
        }

        public static void LowerPitch(int number)
        {
            Clear();
            WriteLine($"Your audio's pitch is lowered by {number} semitones.\n");
        }
    }
}
