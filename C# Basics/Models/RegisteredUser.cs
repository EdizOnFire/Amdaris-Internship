using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Basics.Models
{
    public class RegisteredUser : User
    {
        public override void Welcome()
        {
            Console.WriteLine($"Welcome, {this.Username}!");
        }
    }
}
