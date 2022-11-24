using static System.Console;
using Domain;

namespace Application
{
    public class ServicesFacade
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
