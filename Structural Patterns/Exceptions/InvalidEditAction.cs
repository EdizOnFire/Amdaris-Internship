using System;

namespace Exceptions
{
    public class InvalidEditAction : Exception
    {
        public InvalidEditAction()
            : base("Please choose either 'i' to increase or 'l' to lower.")
        { }
    }
}
