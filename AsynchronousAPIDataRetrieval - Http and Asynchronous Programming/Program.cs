// Create a console application that demonstrates the asynchronous retrieval of data from two different API endpoints concurrently. The application should use the HttpClient class to make asynchronous API calls and handle the responses. The goal is to showcase the benefits of asynchronous programming by fetching data from two separate endpoints simultaneously, allowing for more efficient use of resources and reducing overall execution time.
namespace AsynchronousAPIDataRetrieval___Http_and_Asynchronous_Programming;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Retrieving data from two different API endpoints concurrently...");
        List<string> results = await MakeAPICalls();

        int taskNum = 0;
        foreach (string result in results)
        {
            taskNum++;
            Console.WriteLine($"Task {taskNum} result:\n{result}");
            Console.WriteLine();
        }
    }

    private static async Task<List<string>> MakeAPICalls()
    {
        List<Task<string>> tasks = new List<Task<string>>
        {
            APICaller.GetData("https://jsonplaceholder.typicode.com/posts/1"),
            APICaller.GetData("https://jsonplaceholder.typicode.com/posts/2")
        };
        
        await Task.WhenAll(tasks);
        return tasks.Select(t => t.Result).ToList();
    }
}