using AdvancedProgrammingCourse;

//Objective: The project aims to develop an interactive C# application for a music player, employing a robust event-driven architecture. Users can subscribe to playback events such as play, pause, stop, and skip, enhancing their engagement. The program utilizes delegates and events to implement this event-driven paradigm, allowing subscribers to receive real-time notifications.

public class Program
{
    public static List<string> songs = new()
    {
        "Wonderwall",
        "The Subway",
        "It's Raining Men",
        "21st Century Schizoid Man"
    };
    
    // Track subscription status for each action
    private static bool isSubscribedToPlay = false;
    private static bool isSubscribedToPause = false;
    private static bool isSubscribedToStop = false;
    private static bool isSubscribedToSkip = false;
    
    public static void Main(string[] args)
    {
        MultiPlayer player = new MultiPlayer();
        Subscriber subscriber = new Subscriber();
        
        Console.WriteLine("Welcome to the Music Player!");
        
        // Initial setup - song selection and subscriptions
        SetupSubscriptions(player, subscriber);
        
        // Main program loop
        bool continueRunning = true;
        while (continueRunning)
        {
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("MUSIC PLAYER MENU");
            Console.WriteLine(new string('=', 50));
            
            // Show current song options
            Console.WriteLine("Available songs:");
            for (int i = 0; i < songs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {songs[i]}");
            }
            
            // Get song selection
            string selectedSong = GetSongSelection();
            
            // Get action selection
            SubscribeAction selectedAction = GetActionSelection();
            
            // Perform the selected action
            Console.WriteLine($"\nPerforming {selectedAction} action on '{selectedSong}':");
            PerformAction(player, selectedAction, selectedSong);
            
            // Ask if user wants to continue
            continueRunning = AskToContinue();
        }
        
        Console.WriteLine("Thanks for using the Music Player! Goodbye!");
    }
    
    private static void SetupSubscriptions(MultiPlayer player, Subscriber subscriber)
    {
        Console.WriteLine("\n--- Initial Subscription Setup ---");
        foreach (SubscribeAction action in Enum.GetValues<SubscribeAction>())
        {
            bool currentlySubscribed = GetSubscriptionStatus(action);
            string status = currentlySubscribed ? " (already subscribed)" : "";
            Console.WriteLine($"Would you like to subscribe to {action}{status} (y/n)?");
            
            string input = "";
            while (string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                Console.WriteLine("Please enter 'y' or 'n':");
            }
            
            if (input.ToLower() == "y")
            {
                if (!GetSubscriptionStatus(action))
                {
                    Subscribe(player, subscriber, action);
                    SetSubscriptionStatus(action, true);
                    Console.WriteLine($"Successfully subscribed to {action} action.");
                }
                else
                {
                    Console.WriteLine($"You are already subscribed to {action} action.");
                }
            }
        }
    }
    
    private static string GetSongSelection()
    {
        Console.WriteLine("\nPick a song (enter the number):");
        string input = "";
        while (string.IsNullOrEmpty(input = Console.ReadLine()))
        {
            Console.WriteLine("Please enter a valid song number:");
        }
        
        if (int.TryParse(input, out int songIndex) && songIndex >= 1 && songIndex <= songs.Count)
        {
            return songs[songIndex - 1];
        }
        else
        {
            Console.WriteLine("Invalid selection. Defaulting to first song.");
            return songs[0];
        }
    }
    
    private static SubscribeAction GetActionSelection()
    {
        Console.WriteLine("\nPick an action to perform:");
        Console.WriteLine("1. Play");
        Console.WriteLine("2. Pause");
        Console.WriteLine("3. Stop");
        Console.WriteLine("4. Skip");
        Console.WriteLine("5. Manage Subscriptions");
        
        string input = "";
        while (string.IsNullOrEmpty(input = Console.ReadLine()))
        {
            Console.WriteLine("Please enter a number (1-5):");
        }
        
        return input switch
        {
            "1" => SubscribeAction.Play,
            "2" => SubscribeAction.Pause,
            "3" => SubscribeAction.Stop,
            "4" => SubscribeAction.Skip,
            "5" => ManageSubscriptions(),
            _ => SubscribeAction.Play // Default to Play
        };
    }
    
    private static SubscribeAction ManageSubscriptions()
    {
        Console.WriteLine("\n--- Subscription Management ---");
        Console.WriteLine("Current subscriptions:");
        
        foreach (SubscribeAction action in Enum.GetValues<SubscribeAction>())
        {
            string status = GetSubscriptionStatus(action) ? "✓ Subscribed" : "✗ Not subscribed";
            Console.WriteLine($"{action}: {status}");
        }
        
        Console.WriteLine("\nWhat would you like to do?");
        Console.WriteLine("1. Subscribe to an action");
        Console.WriteLine("2. Unsubscribe from an action");
        Console.WriteLine("3. Go back to main menu");
        
        string choice = "";
        while (string.IsNullOrEmpty(choice = Console.ReadLine()))
        {
            Console.WriteLine("Please enter 1, 2, or 3:");
        }
        
        // For simplicity, return Play action after managing subscriptions
        // You could extend this to allow immediate action selection
        return SubscribeAction.Play;
    }
    
    private static void PerformAction(MultiPlayer player, SubscribeAction action, string song)
    {
        switch (action)
        {
            case SubscribeAction.Play:
                player.Play(song);
                break;
            case SubscribeAction.Pause:
                player.Pause(song);
                break;
            case SubscribeAction.Stop:
                player.Stop(song);
                break;
            case SubscribeAction.Skip:
                player.Skip(song);
                break;
        }
    }
    
    private static bool AskToContinue()
    {
        Console.WriteLine("\nWould you like to continue using the music player? (y/n):");
        string input = "";
        while (string.IsNullOrEmpty(input = Console.ReadLine()))
        {
            Console.WriteLine("Please enter 'y' to continue or 'n' to exit:");
        }
        
        return input.ToLower() == "y";
    }
    
    private static bool GetSubscriptionStatus(SubscribeAction action)
    {
        return action switch
        {
            SubscribeAction.Play => isSubscribedToPlay,
            SubscribeAction.Pause => isSubscribedToPause,
            SubscribeAction.Stop => isSubscribedToStop,
            SubscribeAction.Skip => isSubscribedToSkip,
            _ => false
        };
    }
    
    private static void SetSubscriptionStatus(SubscribeAction action, bool status)
    {
        switch (action)
        {
            case SubscribeAction.Play:
                isSubscribedToPlay = status;
                break;
            case SubscribeAction.Pause:
                isSubscribedToPause = status;
                break;
            case SubscribeAction.Stop:
                isSubscribedToStop = status;
                break;
            case SubscribeAction.Skip:
                isSubscribedToSkip = status;
                break;
        }
    }
    
    public static void Subscribe(MultiPlayer player, Subscriber subscriber, SubscribeAction action)
    {
        switch (action) 
        {
            case SubscribeAction.Play:
                player.SongPlayed += subscriber.Played;
                break;
            case SubscribeAction.Pause:
                player.SongPaused += subscriber.Paused;
                break;
            case SubscribeAction.Stop:
                player.SongStopped += subscriber.Stopped;
                break;
            case SubscribeAction.Skip:
                player.SongSkipped += subscriber.Skipped;
                break;
        }
    }
    
    public static void Unsubscribe(MultiPlayer player, Subscriber subscriber, SubscribeAction action)
    {
        switch (action) 
        {
            case SubscribeAction.Play:
                player.SongPlayed -= subscriber.Played;
                break;
            case SubscribeAction.Pause:
                player.SongPaused -= subscriber.Paused;
                break;
            case SubscribeAction.Stop:
                player.SongStopped -= subscriber.Stopped;
                break;
            case SubscribeAction.Skip:
                player.SongSkipped -= subscriber.Skipped;
                break;
        }
    }
}