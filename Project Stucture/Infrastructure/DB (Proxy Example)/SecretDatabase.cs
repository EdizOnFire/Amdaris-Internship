using static System.Console;

namespace Infrastructure
{
    internal class SecretDatabase : ISecretDatabase
    {
        private static int _audioFilesCount;
        public static int AudioFilesCount
        {
            get { return _audioFilesCount; }
            set { _audioFilesCount = value; }
        }

        public static void UploadToDB()
        {
            AudioFilesCount += 1;
            WriteLine($"You currently have {AudioFilesCount} audio files in the database.");
        }
    }
}
