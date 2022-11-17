using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using static System.Console;

string fileName = "encrypted.bin";
byte[] key = { 145, 12, 32, 245, 98, 132, 98, 214, 6, 77, 131, 44, 221, 3, 9, 50 };
byte[] iv = { 15, 122, 132, 5, 93, 198, 44, 31, 9, 39, 241, 49, 250, 188, 80, 7 };
byte[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

CreateAndEncrypt();
Decrypt();
Compress();

//Create and Encrypt

void CreateAndEncrypt()
{
    using (SymmetricAlgorithm algorithm = Aes.Create())
    using (ICryptoTransform encryptor = algorithm.CreateEncryptor(key, iv))
    using (Stream f = File.Create(fileName))
    using (Stream c = new CryptoStream(f, encryptor, CryptoStreamMode.Write))
        c.Write(data, 0, data.Length);
}

//Decrypt

void Decrypt()
{
    WriteLine("Decrypted data:");
    byte[] decrypted = new byte[5];
    using (SymmetricAlgorithm algorithm = Aes.Create())
    using (ICryptoTransform decryptor = algorithm.CreateDecryptor(key, iv))
    using (Stream f = File.OpenRead(fileName))
    using (Stream c = new CryptoStream(f, decryptor, CryptoStreamMode.Read))
        for (int b; (b = c.ReadByte()) > -1;)
            Write(b + " ");
}

//Compress

void Compress()
{
    using FileStream originalFileStream = File.Open(fileName, FileMode.Open);
    using FileStream compressedFileStream = File.Create("compressed.gz");
    using var compressor = new GZipStream(compressedFileStream, CompressionMode.Compress);
    originalFileStream.CopyTo(compressor);
}
