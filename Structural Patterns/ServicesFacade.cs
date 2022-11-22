using Models;
using Exceptions;
using static System.Console;

namespace StructuralPattern
{
    class ServicesFacade
    {
        public static void UseServices()
        {
            WriteLine("You will have to register in order to use the app.");
            RegisteredUser user = new RegisteredUser();
            try
            {
                RegisterUser.Register(user);
                if (user.Password.Length < 5)
                {
                    throw new PasswordLengthException();
                }
            }
            catch (PasswordLengthException e)
            {
                WriteLine(e.Message);
                return;
            }

            Clear();
            user.Welcome();
            Upload.UploadFileQuestion();
        }
    }
}
