using static System.Console;
using System;

namespace Application
{
    public class InvalidEditAction : Exception
    {
        public InvalidEditAction()
            : base("Please choose either 'i' to increase or 'l' to lower.")
        { }
    }
}
