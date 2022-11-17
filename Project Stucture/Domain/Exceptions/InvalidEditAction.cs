using System;

namespace Domain.Exceptions
{
    public class InvalidEditAction : Exception
    {
        public InvalidEditAction()
            : base("Please choose either 'i' to increase the pitch or 'l' to lower it.")
        { }
    }
}
