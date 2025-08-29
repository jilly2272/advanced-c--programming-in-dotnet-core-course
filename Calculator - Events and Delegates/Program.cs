// Objective: The project focuses on building a C# console application that facilitates fundamental mathematical operations with dynamic user input. Employing events and delegates, the application notifies subscribers about the results of diverse mathematical operations. The program prompts users to input two numbers and select an operation (addition, subtraction, multiplication, or division), utilizing event handlers to display the outcomes.

using Calculator___Events_and_Delegates;

public class Program
{
    public static void Main(string[] args)
    {
        MathOperations calculator = new MathOperations();
        ResultsDisplay resultsDisplay = new ResultsDisplay();

        calculator.Addition += resultsDisplay.DisplayResults;
        calculator.Subtraction += resultsDisplay.DisplayResults;
        calculator.Multiplication += resultsDisplay.DisplayResults;
        calculator.Division += resultsDisplay.DisplayResults;
        
        Console.WriteLine("Welcome to the calculator! Input first number:");
        string number1 = "";
        float x = 0;
        while (string.IsNullOrEmpty(number1) || !float.TryParse(number1, out x))
        {
            Console.WriteLine("Please enter a valid number.");
            number1 = Console.ReadLine();
        }
        
        Console.WriteLine("Input second number:");
        string number2 = "";
        float y = 0;
        while (string.IsNullOrEmpty(number2) || !float.TryParse(number2, out y))
        {
            Console.WriteLine("Please enter a valid number.");
            number2 = Console.ReadLine();
        }
        
        Console.WriteLine("Choose your operation (select num): 1. +, 2. -, 3. *, 4. /");
        string enumResult = "";
        int enumResultInt = 0;
        while (string.IsNullOrEmpty(enumResult) || !int.TryParse(enumResult, out enumResultInt) || enumResultInt - 1 is < 0 or > 3)
        {
            Console.WriteLine("Please enter a valid number. Choose your operation (select num): 1. +, 2. -, 3. *, 4. /");
            enumResult = Console.ReadLine();
        }
        
        OperationEnum operation = (OperationEnum)(enumResultInt - 1);

        switch (operation)
        {
            case OperationEnum.Addition:
                calculator.Add(x, y);
                break;
            case OperationEnum.Subtraction:
                calculator.Subtract(x, y);
                break;
            case OperationEnum.Multiplication:
                calculator.Multiply(x, y);
                break;
            case OperationEnum.Division:
                calculator.Divide(x, y);
                break;
        }
    }
}