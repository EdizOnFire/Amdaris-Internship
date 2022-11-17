using System;
using Domain;

namespace Application
{
    public class RegisteredUser : User
    {
        public override void Welcome()
        {
            Console.WriteLine($"Welcome, {this.Username}!");
        }
    }
}