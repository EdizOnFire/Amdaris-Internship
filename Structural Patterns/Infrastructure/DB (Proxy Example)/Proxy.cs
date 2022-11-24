using static System.Console;

namespace Infrastructure
{
    public class Proxy
    {
        public static void UploadToDB()
        {
            SecretDatabase.UploadToDB();
        }
    }
}
