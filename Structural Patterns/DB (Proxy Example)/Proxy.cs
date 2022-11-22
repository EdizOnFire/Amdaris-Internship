using static System.Console;

namespace StructuralPattern
{
    internal class Proxy
    {
        public static void UploadToDB()
        {
            SecretDatabase.UploadToDB();
        }
    }
}
