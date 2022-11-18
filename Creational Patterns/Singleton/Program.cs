using static System.Console;

namespace Singleton
{
    class Program
    {
        static void Main()
        {
            Singleton instance1 = Singleton.Instance;
            Singleton instance2 = Singleton.Instance;

            //When app runs, the second instance is not being created

            instance1.WriteMessage("Hello from instance1.");
            instance2.WriteMessage("Hello from instance2.");
        }
    }
}