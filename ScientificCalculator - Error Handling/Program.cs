//Problem: Develop a scientific calculator application that allows users to perform various mathematical operations, including division. Implement advanced error handling to deal with scenarios such as division by zero and invalid mathematical expressions.

public static class Program
{
    public static void Main(string[] args)
    {
        bool continueRunning = true;
        while (continueRunning)
        {
            try
            {
                Console.WriteLine("Welcome to the Scientific Calculator. Please input a mathematical expression:");
                string userInput = Console.ReadLine();

                while (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Please enter a valid mathematical expression.");
                    userInput = Console.ReadLine();
                }

                string expression = userInput.Replace(" ", "");

                if (expression.Contains('/'))
                {
                    float result = float.Parse(expression.Split('/')[0]) / float.Parse(expression.Split('/')[1]);
                    Console.WriteLine($"{expression} = {result}");
                }
                else if (expression.Contains('*'))
                {
                    float result = float.Parse(expression.Split('*')[0]) * float.Parse(expression.Split('*')[1]);
                    Console.WriteLine($"{expression} = {result}");
                }
                else if (expression.Contains('+'))
                {
                    float result = float.Parse(expression.Split('+')[0]) + float.Parse(expression.Split('+')[1]);
                    Console.WriteLine($"{expression} = {result}");
                }
                else if (expression.Contains('-'))
                {
                    float result = float.Parse(expression.Split('-')[0]) - float.Parse(expression.Split('-')[1]);
                    Console.WriteLine($"{expression} = {result}");
                }
                else
                {
                    Console.WriteLine("Invalid mathematical expression.");
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Would you like to continue using the calculator? (y/n)");
                string input = Console.ReadLine();
                while(string.IsNullOrEmpty(input) || (input != "y" && input != "n"))
                {
                    Console.WriteLine("Please enter 'y' or 'n'.");
                    input = Console.ReadLine();
                }
                continueRunning = input.ToLower() == "y";
            }
        }
    }
}