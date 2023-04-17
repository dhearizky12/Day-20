using System.IO;
using System.Threading.Tasks;

class Program {
	static async Task Main() {
		string path = @"C:\Users\Formulatrix\Desktop\hello.txt";

		using (StreamReader reader = new StreamReader(path)) {
			char[] buffer = new char[1024];
			int bytesRead;
			while ((bytesRead = await reader.ReadAsync(buffer, 0, buffer.Length)) > 0) {
				string text = new string(buffer, 0, bytesRead);
				// process the text buffer
				Console.Write(text);
			}
            Console.WriteLine("\nDone reading file.");
            Console.ReadKey();
        }
	}  
}
