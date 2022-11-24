using static System.Console;
using Domain;

namespace Application
{
    class RegisterUser
    {
        public static void Register(RegisteredUser user)
        {
            user.Username = Answer.AnswerFromConsole("Please enter your username:\n");
            user.Password = Answer.AnswerFromConsole("Please enter your password:\n");
        }
    }
}
