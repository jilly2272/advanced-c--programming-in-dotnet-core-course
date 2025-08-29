//Objective: This project centers around the development of a C# console application utilizing LINQ to perform diverse operations on a collection of data, offering users the ability to input data and execute LINQ queries for filtering, sorting, and aggregate calculations.
namespace LINQDataManipulation;

public static class Program
{
    static List<Person> people = new List<Person>();
    
    public static void Main(string[] args)
    {
        people.Add(new Person("Emily", 24, 27500));
        people.Add(new Person("George", 25, 36000));
        people.Add(new Person("Chaka Khan", 72, 100000));
        people.Add(new Person("Barak Obama", 64, 400000));
        people.Add(new Person("Taylor", 29, 32000));
        people.Add(new Person("Timothy", 45, 55000));

        Console.WriteLine("Would you like to add a person to the database (y/n)?");
        string? input = Console.ReadLine();
        while (string.IsNullOrEmpty(input) && (input != "y" || input != "n"))
        {
            Console.WriteLine("Please type 'y' or 'n'. Would you like to add a person to the database?");
            input = Console.ReadLine();
        }
        
        if(input == "y")
            AddPerson();
        
        Console.WriteLine("Would you like to sort the database?");
        input = Console.ReadLine();
        while (string.IsNullOrEmpty(input) && (input != "y" || input != "n"))
        {
            Console.WriteLine("Please type 'y' or 'n'. Would you like to sort the database?");
        }

        if (input == "n")
            return;

        // Prompt the user for sorting preferences
        Console.WriteLine("How would you like to sort the database?");
        Console.WriteLine("1. Sort by first name");
        Console.WriteLine("2. Sort by age");
        Console.WriteLine("3. Sort by salary");
        Console.Write("Enter your choice (1-3): ");
        string? sortChoiceInput = Console.ReadLine();
        int sortChoice;
        while (!int.TryParse(sortChoiceInput, out sortChoice) || sortChoice < 1 || sortChoice > 3)
        {
            Console.WriteLine("Please enter a valid choice: 1, 2, or 3.");
            sortChoiceInput = Console.ReadLine();
        }

        // Ask about sorting order
        Console.WriteLine("Do you want to sort in ascending or descending order? (a/d)");
        string? orderInput = Console.ReadLine();
        while (string.IsNullOrEmpty(orderInput) || (orderInput != "a" && orderInput != "d"))
        {
            Console.WriteLine("Please type 'a' for ascending or 'd' for descending.");
            orderInput = Console.ReadLine();
        }

        List<Person> sortedPeople;
        if (orderInput == "a")
        {
            sortedPeople = DisplayAscendingBy(sortChoice);
        }
        else
        {
            sortedPeople = DisplayDescendingBy(sortChoice);
        }

        // Display the sorted results
        Console.WriteLine("Sorted List:");
        foreach (Person p in sortedPeople)
        {
            Console.WriteLine($"Name: {p.FirstName}, Age: {p.Age}, Salary: {p.Salary}");
        }
        
    }

    private static void AddPerson()
    {
        Console.WriteLine("Input the name of the person");
        string? name = Console.ReadLine();
        while (string.IsNullOrEmpty(name) || !name.All(char.IsDigit))
        {
            Console.WriteLine("Please enter a valid name.");
            name = Console.ReadLine();
        }
        
        Console.WriteLine("Input the age of the person");
        string? ageInput = Console.ReadLine();
        int age = 0;
        while (string.IsNullOrEmpty(ageInput) || !int.TryParse(ageInput, out age) && age is > 16 and < 120)
        {
            Console.WriteLine("Please write a valid number > 16 and < 120");
            ageInput = Console.ReadLine();
        }
        
        Console.WriteLine("Input the person's salary");
        string? salaryInput = Console.ReadLine();
        int salary = 0;
        while (string.IsNullOrEmpty(salaryInput) || !int.TryParse(salaryInput, out salary) && salary >= 18000)
        {
            Console.WriteLine("Please write a valid number that is more than or equal to 18000");
            salaryInput = Console.ReadLine();
        }
        
        people.Add(new Person(name, age, salary));
    }

    public static List<Person> DisplayNamesStartingWith(char letter)
    {
        return people.Where(p => p.FirstName.ToLower()[0] == letter).ToList();
    }

    public static List<Person> DisplaySalaryAbove(int minSalary)
    {
        return people.Where(p => p.Salary > minSalary).ToList();
    }
    
    public static List<Person> DisplaySalaryBelow(int maxSalary)
    {
        return people.Where(p => p.Salary < maxSalary).ToList();
    }

    public static List<Person> DisplayAscendingBy(int choice)
    {
        List<Person> orderedList = new List<Person>();
        switch (choice)
        {
            case 1:
                orderedList = people.OrderBy(p => p.FirstName[0]).ToList();
                break;
            case 2:
                orderedList = people.OrderBy(p => p.Age).ToList();
                break;
            case 3:
                orderedList = people.OrderBy(p => p.Salary).ToList();
                break;
        }

        return orderedList;
    }
    
    public static List<Person> DisplayDescendingBy(int choice)
    {
        List<Person> orderedList = new List<Person>();
        switch (choice)
        {
            case 1:
                orderedList = people.OrderByDescending(p => p.FirstName[0]).ToList();
                break;
            case 2:
                orderedList = people.OrderByDescending(p => p.Age).ToList();
                break;
            case 3:
                orderedList = people.OrderByDescending(p => p.Salary).ToList();
                break;
        }

        return orderedList;
    }
}