// Develop a C# application that simulates a simple file processing system. The application reads data from a file, performs some operations, and writes the result to another file. Implement error handling mechanisms to address potential issues such as file not found, invalid data format, or other exceptions.

using WriteToFile___Error_Handling;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the File Processor!");
        bool continueRunning = true;
        
        while(continueRunning)
        {
            Console.WriteLine("Would you like to 1. Read or 2. Write to a file (1/2)?");
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input) && (input != "1" || input != "2"))
            {
                Console.WriteLine("Please select option 1 or 2.");
                input = Console.ReadLine();
            }

            Console.WriteLine("Input path of file:");
            string path = Console.ReadLine();
            while (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("Please enter a valid path:");
                path = Console.ReadLine();
            }

            if (input == "1")
            {
                Console.WriteLine(FileProcessor.ReadDataFromFile(path));
            }
            else if (input == "2")
            {
                Console.WriteLine("Input what you'd like written to the file:");
                string text = Console.ReadLine();
                while (string.IsNullOrEmpty(text))
                {
                    Console.WriteLine("Please enter a valid string.");
                }

                FileProcessor.WriteDataToFile(path, text);
            }
            
            Console.WriteLine("\nDo you want to continue? (y/n)");
            string response = Console.ReadLine();
            if (response != null && response.ToLower() != "y")
            {
                continueRunning = false;
                Console.WriteLine("Exiting the application...");
            }
        }
    }
}