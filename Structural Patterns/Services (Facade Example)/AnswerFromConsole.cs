using Models;
using Exceptions;
using static System.Console;

namespace StructuralPattern
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
