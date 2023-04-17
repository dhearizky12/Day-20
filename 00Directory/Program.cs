using System.IO;

class Program {
    static void Main() {
       // string path = @"C:\Users\Kinara\Documents\Bootcamp";
        string path = @"C:\Users\Formulatrix\Documents";

        // Create a new directory
        Directory.CreateDirectory(path);

        // Check if the directory exists
        if (Directory.Exists(path)) {
            Console.WriteLine("Directory exists.");
        }

        // Create a file in the directory
        string filePath = Path.Combine(path, "bootcamp.txt");
        File.WriteAllText(filePath, "Hello, world!");

        // List all files in the directory
        string[] files = Directory.GetFiles(path);
        foreach (string file in files) {
            Console.WriteLine(file);
        }

        // Delete the directory and all files in it
        Directory.Delete(path, true);
    }
}
