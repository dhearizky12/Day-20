using System;
using System.IO;
using System.IO.Compression;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Starting file is 17,529,625 bytes.
            string anyString = File.ReadAllText("C:/Users/Formulatrix/Desktop/hello.txt");
            
            // Output file is 85,041 bytes.
            CompressStringToFile("newdoc.gz", anyString);

            // Get size of original file
            FileInfo originalFile = new FileInfo("C:/Users/Formulatrix/Desktop/hello.txt");
            Console.WriteLine($"Original file size: {originalFile.Length} bytes");

            // Get size of compressed file
            FileInfo compressedFile = new FileInfo("newdoc.gz");
            Console.WriteLine($"Compressed file size: {compressedFile.Length} bytes");
        }
        catch (Exception ex)
        {
              Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    
    public static void CompressStringToFile(string fileName, string value)
    {
        // Part A: write string to temporary file.
        string temp = Path.GetTempFileName();
        File.WriteAllText(temp, value);
        
        // Part B: read file into byte array buffer.
        byte[] b;
        using (FileStream filestream = new FileStream(temp, FileMode.Open))
        {
            b = new byte[filestream.Length];
            filestream.Read(b, 0, (int)filestream.Length);
        }
        
        // Part C: use GZipStream to write compressed bytes to target file.
        using (FileStream filestream2 = new FileStream(fileName, FileMode.Create))
        using (GZipStream gzipstream = new GZipStream(filestream2, CompressionMode.Compress, false))
        {
            gzipstream.Write(b, 0, b.Length);
        }
    }
}
