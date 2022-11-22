using Models;
using Exceptions;
using static System.Console;

namespace StructuralPattern
{
    class TempoEditor : AudioEditor
    {
        public static string AnswerFromConsole(string request)
        {
            Write(request);
            return ReadLine();
        }
        public static void ChangeTempoQuestion()
        {
            string answer = AnswerFromConsole("Do you want to change the tempo? 'y' or 'n'.\n");
            if (answer == "y")
            {
                try
                {
                    answer = AnswerFromConsole("Do you want to increase or lower the tempo? 'i' or 'l'.\n");
                    if (answer == "i")
                    {
                        try
                        {
                            answer = AnswerFromConsole("By how many bpm?\n");
                            if (answer == "0")
                            {
                                throw new ZeroException();
                            }

                            IncreaseTempo(int.Parse(answer));
                        }
                        catch (ZeroException e)
                        {
                            WriteLine(e.Message);
                            ChangeTempoQuestion();
                        }
                        catch (FormatException)
                        {
                            WriteLine("Enter only numbers.\n");
                            ChangeTempoQuestion();
                        }
                    }
                    else if (answer == "l")
                    {
                        try
                        {
                            answer = AnswerFromConsole("By how many bpm?\n");
                            if (answer == "0")
                            {
                                throw new ZeroException();
                            }

                            LowerTempo(int.Parse(answer));
                        }
                        catch (ZeroException e)
                        {
                            WriteLine(e.Message);
                            ChangeTempoQuestion();
                        }
                        catch (FormatException)
                        {
                            WriteLine("Enter only numbers.\n");
                            ChangeTempoQuestion();
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
                    ChangeTempoQuestion();
                }
            }
        }

        public static void IncreaseTempo(int number)
        {
            Clear();
            WriteLine($"Your audio's bpm is increased by {number} bpm.\n");
        }

        public static void LowerTempo(int number)
        {
            Clear();
            WriteLine($"Your audio's bpm is lowered by {number} bpm.\n");
        }
    }
}
