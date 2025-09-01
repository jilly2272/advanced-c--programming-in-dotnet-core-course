//Objective: The project aims to design and implement a generic cache class in C# that supports storing items of diverse data types with a designated expiration time. The goal is to create a versatile caching solution that dynamically manages and purges expired entries, promoting efficient memory utilization.

using GenericCache___Constraints_and_Advanced_Generics;

public class Program
{
    public static void Main(string[] args)
    {
        //Starting data
        GenericCache<int> integerCache = new GenericCache<int>();
        integerCache.AddItem(new CacheItem<int>(5, DateTime.Now.AddSeconds(10)));
        integerCache.AddItem(new CacheItem<int>(152, DateTime.Now.AddSeconds(15)));
        integerCache.AddItem(new CacheItem<int>(67, DateTime.Now.AddSeconds(12)));
        
        GenericCache<string> wordCache = new GenericCache<string>();
        wordCache.AddItem(new CacheItem<string>("car", DateTime.Now.AddSeconds(10)));
        wordCache.AddItem(new CacheItem<string>("robot", DateTime.Now.AddSeconds(14)));
        wordCache.AddItem(new CacheItem<string>("cheese", DateTime.Now.AddSeconds(17)));

        Console.WriteLine("Which cache would you like to access, 1. integer or 2. word (1/2)?");
        string cacheChoice = "";
        while(string.IsNullOrEmpty(cacheChoice = Console.ReadLine()) || (cacheChoice != "1" && cacheChoice != "2"))
        {
            Console.WriteLine("Please select option 1 or 2.");
        }
        
        Console.WriteLine("Would you like to 1. Add to the cache, 2. Retrieve an item from the cache, or 3. Display the cahce (1/2/3)");
        string action = "";
        while(string.IsNullOrEmpty(action = Console.ReadLine()) || (action != "1" && action != "2" && action != "3"))
        {
            Console.WriteLine("Please select option 1, 2, or  3.");
        }

        switch (action)
        {
            //Add to cache
            case "1":
                if(cacheChoice == "1")
                {
                    Console.WriteLine("What value should this item contain (integer)?");
                    string integerStr;
                    int integer;
                    while(string.IsNullOrEmpty(integerStr = Console.ReadLine()) || !int.TryParse(integerStr, out integer))
                    {
                        Console.WriteLine("Please enter a valid integer");
                    }
                    
                    Console.WriteLine("In how many seconds should this item expire?");
                    string secStr;
                    int secs;
                    while(string.IsNullOrEmpty(secStr = Console.ReadLine()) || !int.TryParse(secStr, out secs))
                    {
                        Console.WriteLine("Please enter a valid integer");
                    }
                    
                    integerCache.AddItem(new CacheItem<int>(integer, DateTime.Now.AddSeconds(secs)));
                }
                if(cacheChoice == "2")
                {
                    Console.WriteLine("What value should this item contain (word)?");
                    string wordStr;
                    while(string.IsNullOrEmpty(wordStr = Console.ReadLine()))
                    {
                        Console.WriteLine("Please enter a valid string");
                    }
                    
                    Console.WriteLine("In how many seconds should this item expire?");
                    string secStr;
                    int secs;
                    while(string.IsNullOrEmpty(secStr = Console.ReadLine()) || !int.TryParse(secStr, out secs))
                    {
                        Console.WriteLine("Please enter a valid integer");
                    }
                    
                    wordCache.AddItem(new CacheItem<string>(wordStr, DateTime.Now.AddSeconds(secs)));
                }
                break;
            //Retrieve item from cache
            case "2":
                if (cacheChoice == "1")
                {
                    Console.WriteLine("What value (int) would you like to retrieve from the cache?");
                    string retrieveStr;
                    int retrieveInt;
                    while (string.IsNullOrEmpty(retrieveStr = Console.ReadLine()) || !int.TryParse(retrieveStr, out retrieveInt))
                    {
                        Console.WriteLine("Please enter a valid int.");
                    }

                    CacheItem<int> item = integerCache.GetItem(retrieveInt);
                    Console.WriteLine($"Retrieved item: {item.value}, {item.expirationTime}");
                }

                if (cacheChoice == "2")
                {
                    Console.WriteLine("What value (string) would you like to retrieve from the cache?");
                    string retrieveStr;
                    while (string.IsNullOrEmpty(retrieveStr = Console.ReadLine()))
                    {
                        Console.WriteLine("Please enter a valid string.");
                    }

                    CacheItem<string> item = wordCache.GetItem(retrieveStr);
                    Console.WriteLine($"Retrieved item: {item.value}, {item.expirationTime}");
                }
                break;
            //Display cache
            case "3":
                if(cacheChoice == "1")
                    integerCache.DisplayCache();
                if(cacheChoice == "2") 
                    wordCache.DisplayCache();
                break;
        }
    }
}