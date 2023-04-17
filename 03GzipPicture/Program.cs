using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "C:/Users/Formulatrix/Desktop/need purchase lagi.png";
        string outputFilePath = "tes.gz";

        NewMethod (inputFilePath);
      
        
        // Read input file as byte array
        byte[] inputBytes = File.ReadAllBytes(inputFilePath);
        
        // Create output stream
        using (FileStream outputStream = File.Create(outputFilePath))
        {
            // Create GZip stream
            using (GZipStream gzipStream = new GZipStream(outputStream, CompressionLevel.Optimal))
            {
                // Write byte array to GZip stream
                gzipStream.Write(inputBytes, 0, inputBytes.Length);
            }
        }
          NewMethod1(outputFilePath);
        Console.WriteLine($"File {inputFilePath} compressed to {outputFilePath}.");

    }
      private static void NewMethod(string inputFilePath)
    {
        // Get size of input file
        FileInfo inputFile = new FileInfo(inputFilePath);
        long inputFileSize = inputFile.Length;
        Console.WriteLine($"Input file size: {inputFileSize} bytes.");
    }
      private static void NewMethod1(string outputFilePath)
    {
        // Get size of output file
        FileInfo outputFile = new FileInfo(outputFilePath);
        long outputFileSize = outputFile.Length;
        Console.WriteLine($"Output file size: {outputFileSize} bytes.");
    }
}
