using static System.Console;

namespace Application
{
    class Answer
    {
        public static string AnswerFromConsole(string request)
        {
            Write(request);
            return ReadLine();
        }
    }
}
