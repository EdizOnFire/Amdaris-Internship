using System;
using Infrastructure;
using Domain.Exceptions;
using Application;

namespace ConsolePresentation
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("You will have to register in order to use the app.");
            RegisteredUser user = new RegisteredUser();

            try
            {
                AudioEditorApp.Register(user);
                if (user.Password.Length < 5)
                {
                    throw new PasswordLengthException();
                }
            }
            catch (PasswordLengthException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Console.Clear();
            user.Welcome();
            AudioEditorApp.UploadFileQuestion();
            Console.ReadLine();
        }
    }
}