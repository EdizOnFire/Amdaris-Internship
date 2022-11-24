using static System.Console;

namespace Domain
{
    public class RegisteredUser : User
    {
        public override void Welcome()
        {
            WriteLine($"Welcome, {this.Username}!");
        }
    }
}
