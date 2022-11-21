using System.IO.Compression;
using System.Security.Cryptography;
using static System.Console;

namespace File_System_and_Streams
{
    class Program
    {
        public static void Main()
        {
            string fileName = "encrypted.txt";
            string compressedFileName = "compressed.gz";
            string decompressedFileName = "decompressed.txt";
            string data = "This is decrypted data.";
            using Aes aes = Aes.Create();
            byte[] key = aes.Key;
            byte[] iv = aes.IV;

            Encrypt();
            Decrypt();
            Compress();
            Decompress();
            PrintResults();

            void Encrypt()
            {

                try
                {
                    using FileStream myStream = new FileStream(fileName, FileMode.OpenOrCreate);
                    myStream.Write(iv, 0, iv.Length);

                    using CryptoStream cryptStream = new CryptoStream(
                        myStream,
                        aes.CreateEncryptor(),
                        CryptoStreamMode.Write);

                    using StreamWriter sWriter = new StreamWriter(cryptStream);
                    sWriter.WriteLine(data);
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                    throw;
                }

                try
                {
                    string text = File.ReadAllText(fileName);
                    WriteLine($"Encrypted data: {text}");
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                    throw;
                }
            }

            void Decrypt()
            {
                try
                {
                    using FileStream myStream = new FileStream(fileName, FileMode.Open);
                    myStream.Read(iv, 0, iv.Length);

                    using CryptoStream cryptStream = new CryptoStream(
                       myStream,
                       aes.CreateDecryptor(key, iv),
                       CryptoStreamMode.Read);

                    using StreamReader sReader = new StreamReader(cryptStream);
                    WriteLine($"Decrypted data: {sReader.ReadToEnd()}");
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                    throw;
                }
            }

            void Compress()
            {
                using FileStream originalFileStream = File.Open(fileName, FileMode.Open);
                using FileStream compressedFileStream = File.Create(compressedFileName);
                using var compressor = new GZipStream(compressedFileStream, CompressionMode.Compress);
                originalFileStream.CopyTo(compressor);
            }

            void Decompress()
            {
                using FileStream compressedFileStream = File.Open(compressedFileName, FileMode.Open);
                using FileStream outputFileStream = File.Create(decompressedFileName);
                using var decompressor = new GZipStream(compressedFileStream, CompressionMode.Decompress);
                decompressor.CopyTo(outputFileStream);
            }

            void PrintResults()
            {
                long originalSize = new FileInfo(fileName).Length;
                long compressedSize = new FileInfo(compressedFileName).Length;
                long decompressedSize = new FileInfo(decompressedFileName).Length;

                WriteLine($"The original file '{fileName}' weighs {originalSize} bytes.");
                WriteLine($"The compressed file '{compressedFileName}' weighs {compressedSize} bytes.");
                WriteLine($"The decompressed file '{decompressedFileName}' weighs {decompressedSize} bytes.");
            }
        }
    }
}
