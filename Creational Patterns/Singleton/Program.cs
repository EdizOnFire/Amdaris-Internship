using System;

namespace Singleton
{
    class Program
    {
        static void Main()
        {
            Singleton instance1 = Singleton.Instance;
            Singleton instance2 = Singleton.Instance;

            //When app runs, the second instance is not being created
        }
    }
}