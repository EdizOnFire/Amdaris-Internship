using static System.Console;

namespace Singleton
{
    public sealed class Singleton
    {
        private static Singleton instance = null;
        private static int count = 0;
        private static readonly object InstanceLock = new object();
        private Singleton()
        {
            count++;
            WriteLine($"{count} number of instances created.");
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (InstanceLock)
                    {
                        instance = new Singleton();
                    }
                }

                return instance;
            }
        }
    }
}
