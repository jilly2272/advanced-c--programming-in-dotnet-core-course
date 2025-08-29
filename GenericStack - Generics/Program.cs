namespace GenericStack___Generics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> numStack = new()
            {
                5,
                26,
                48,
                96,
                131
            };

            List<string> oneSyllableWordsStack = new()
            {
                "book",
                "try",
                "love"
            };

            List<Person> people = new()
            {
                new Person(12, "Eva", "student"),
                new Person(78, "Calvin", "retried"),
                new Person(25, "Leigh", "programmer")
            };

            string choice = "";
            Console.WriteLine("Choose the type of list: (1) int, (2) string, (3) Person");
            while (string.IsNullOrEmpty(choice = Console.ReadLine()) || (choice != "1" && choice != "2" && choice != "3"))
            {
                Console.WriteLine("Please enter a valid option (1, 2, or 3):");
            }

            switch (choice)
            {
                case "1":
                    RunList(numStack);
                    break;
                case "2":
                    RunList(oneSyllableWordsStack);
                    break;
                case "3":
                    RunList(people);
                    break;
            }
        }
        
        static void RunList<T>(List<T> list)
        {
            GenericStack genericStack = new GenericStack();

            while (true)
            {
                string option = "";
                Console.WriteLine("\nChoose an option: (push, pop, print, exit)");
                while (string.IsNullOrEmpty(option = Console.ReadLine()?.ToLower()) ||
                       (option != "push" && option != "pop" && option != "print" && option != "exit"))
                {
                    Console.WriteLine("Invalid option. Please enter: push, pop, print, or exit.");
                }

                switch (option)
                {
                    case "push":
                        Console.WriteLine("Enter value to push:");
                        string input = "";
                        while (string.IsNullOrEmpty(input = Console.ReadLine()))
                        {
                            Console.WriteLine("Please enter a non-empty value to push:");
                        }

                        try
                        {
                            T item;
                            if (typeof(T) == typeof(int))
                            {
                                int parsedInt;
                                while (!int.TryParse(input, out parsedInt))
                                {
                                    Console.WriteLine("Please enter a valid integer value:");
                                    input = Console.ReadLine();
                                }
                                item = (T)(object)parsedInt;
                            }
                            else if (typeof(T) == typeof(string))
                            {
                                item = (T)(object)input;
                            }
                            else if (typeof(T) == typeof(Person))
                            {
                                string name = "";
                                Console.Write("Enter Name: ");
                                while (string.IsNullOrEmpty(name = Console.ReadLine()))
                                {
                                    Console.WriteLine("Name cannot be empty. Enter Name:");
                                }
                                
                                string ageInput = "";
                                int age;
                                Console.Write("Enter Age: ");
                                while (string.IsNullOrEmpty(ageInput = Console.ReadLine()) || !int.TryParse(ageInput, out age))
                                {
                                    Console.WriteLine("Please enter a valid integer for Age:");
                                }

                                string occupation = "";
                                Console.WriteLine("Enter occupation:");
                                while (string.IsNullOrEmpty(occupation = Console.ReadLine()))
                                {
                                    Console.WriteLine("Occupation cannot be empty. Enter occupation:");
                                }

                                item = (T)(object)new Person(age, name, occupation);
                            }
                            else
                            {
                                throw new NotSupportedException("Unsupported type.");
                            }

                            genericStack.Push(list, item);
                            Console.WriteLine("Item pushed.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "pop":
                        genericStack.Pop(list);
                        Console.WriteLine("Item popped");
                        break;

                    case "print":
                        Console.WriteLine("Current list:");
                        foreach (var item in list)
                        {
                            Console.WriteLine(item);
                        }
                        break;

                    case "exit":
                        return;
                }
            }
        }
    }
}