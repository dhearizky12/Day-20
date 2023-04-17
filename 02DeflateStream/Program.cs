using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        
        CompressWithDeflate("C:/Users/Formulatrix/Desktop/hello.txt", "C:/Users/Formulatrix/Desktop/Deflate-Output.deflate");

    }
    
    static void CompressWithDeflate(string inputFilePath, string outputFilePath)
    {
        NewMethod(inputFilePath);

        // Read in input file.
        byte[] b = File.ReadAllBytes(inputFilePath);

        // Write compressed data with DeflateStream.
        using (FileStream f2 = new FileStream(outputFilePath, FileMode.Create))
        using (DeflateStream deflate = new DeflateStream(f2, CompressionMode.Compress, false))
        {
            deflate.Write(b, 0, b.Length);
        }

        NewMethod1(outputFilePath);

        Console.WriteLine("==========================================================================================================");
        Console.WriteLine($"File {inputFilePath} compressed to {outputFilePath}.");
        Console.WriteLine("=================================================================================================");
    }

    private static void NewMethod1(string outputFilePath)
    {
        // Get size of output file
        FileInfo outputFile = new FileInfo(outputFilePath);
        long outputFileSize = outputFile.Length;
        Console.WriteLine($"Output file size: {outputFileSize} bytes.");
    }

    private static void NewMethod(string inputFilePath)
    {
        // Get size of input file
        FileInfo inputFile = new FileInfo(inputFilePath);
        long inputFileSize = inputFile.Length;
        Console.WriteLine($"Input file size: {inputFileSize} bytes.");
    }
}