using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "D:/Dhea_Bootcamp/learn/Pertemuan 20/Day-20/04GZPicutreother/picture-before.png";
        string outputFilePath = "example-pictur1-1.gz";
        //string inputFilePath = "C:/Users/Formulatrix/Desktop/need purchase lagi.png";
        //string outputFilePath = "example-picture2.gz";

        // Read input file to byte array
        byte[] inputBytes = File.ReadAllBytes(inputFilePath);

        // Create output stream
        using (FileStream outputStream = File.Create(outputFilePath))
        {
            // Create GZip stream
            using (GZipStream gzipStream = new GZipStream(outputStream, CompressionLevel.Optimal))
            {
                // Write input bytes to GZip stream
                gzipStream.Write(inputBytes, 0, inputBytes.Length);
            }
        }

        // Get size of original file
        FileInfo originalFile = new FileInfo(inputFilePath);
        Console.WriteLine($"Original file size: {originalFile.Length} bytes");

        // Get size of compressed file
        FileInfo compressedFile = new FileInfo(outputFilePath);
        Console.WriteLine($"Compressed file size: {compressedFile.Length} bytes.");

        Console.WriteLine($"File {inputFilePath} compressed to {outputFilePath}.");
    }
}
