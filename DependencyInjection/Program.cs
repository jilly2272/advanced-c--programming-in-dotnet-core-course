// Objective: The project focuses on implementing a C# console application that showcases the principles of Dependency Injection (DI). The application allows users to input data, and operations are performed using a service with dependency injection, emphasizing the flexibility and modularity of dependency management.

using DependencyInjection;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter text data to process");
        string text = Console.ReadLine();
        while (string.IsNullOrEmpty(text))
        {
            Console.WriteLine("Enter valid text data to process");
            text = Console.ReadLine();
        }
        
        UserInputProcessor userInputProcessor = new UserInputProcessor();
        DataProcessingService dataProcessingService = new DataProcessingService(userInputProcessor);
        dataProcessingService.DisplayData(text);
    }
}