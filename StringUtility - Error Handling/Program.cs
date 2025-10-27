//Objective: Develop a robust C# program that includes a method for converting a given string to uppercase. The objective is to create a reliable utility for text manipulation while addressing potential issues with null input strings.

public class Program
{
    public static void Main(string[] args)
    {
        bool continueRunning = true;

        while (continueRunning)
        {
            try
            {
                Console.WriteLine("Please enter a string to convert to uppercase:");
                string input = Console.ReadLine();
                string output = ConvertToUpperCase(input);
                Console.WriteLine($"Output: {output}");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Would you like to convert another string? (y/n)");
                string response = Console.ReadLine();
                while (string.IsNullOrEmpty(response) && (response != "y" || response != "n"))
                {
                    Console.WriteLine("Please enter 'y' or 'n'.");
                    response = Console.ReadLine();
                }

                if (response == "n")
                    continueRunning = false;
            }
        }
    }
    
    private static string ConvertToUpperCase(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new NullReferenceException("Input string cannot be null or empty");
        }
        return input.ToUpper();
    }
}