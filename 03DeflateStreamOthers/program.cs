using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "hello.txt";
        string outputFilePath = "Deflate-Output";

          // Get size of input file
        FileInfo inputFile = new FileInfo(inputFilePath);
        long inputFileSize = inputFile.Length;
        Console.WriteLine($"Input file size: {inputFileSize} bytes.");

        
        // Create input stream
        using (FileStream inputStream = File.OpenRead(inputFilePath))
        {
            // Create output stream
            using (FileStream outputStream = File.Create(outputFilePath))
            {
                // Create deflate stream
                using (DeflateStream deflateStream = new DeflateStream(outputStream, CompressionLevel.Optimal))
                {
                    // Read input stream and write to deflate stream
                    inputStream.CopyTo(deflateStream);
                }
            }
        }

        // Get size of output file
        FileInfo outputFile = new FileInfo(outputFilePath);
        long outputFileSize = outputFile.Length;
        Console.WriteLine($"Output file size: {outputFileSize} bytes.");
        
        Console.WriteLine($"File {inputFilePath} compressed to {outputFilePath}.");
    }
}
