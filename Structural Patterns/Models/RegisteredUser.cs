using static System.Console;

namespace Models
{
    public class RegisteredUser : User
    {
        public override void Welcome()
        {
            WriteLine($"Welcome, {this.Username}!");
        }
    }
}
