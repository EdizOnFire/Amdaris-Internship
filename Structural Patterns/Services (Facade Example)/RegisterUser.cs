using Models;

namespace StructuralPattern
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
