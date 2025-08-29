namespace AdvancedProgrammingCourse;

public enum SubscribeAction
{
    Play,
    Pause,
    Stop,
    Skip
}

public class MultiPlayer
{
    public delegate void PlayerEventHandler(string message);
    
    public event PlayerEventHandler SongPlayed;
    public event PlayerEventHandler SongPaused;
    public event PlayerEventHandler SongStopped;
    public event PlayerEventHandler SongSkipped;
    
    public void Play(string title)
    {
        SongPlayed?.Invoke(title);
    }
    
    public void Pause(string title)
    {
        SongPaused?.Invoke(title);
    }
    
    public void Stop(string title)
    {
        SongStopped?.Invoke(title);
    }
    
    public void Skip(string title)
    {
        SongSkipped?.Invoke(title);
    }
}

public class Subscriber
{
    public void Played(string message)
    {
        Console.WriteLine($"Playing: {message}");
    }

    public void Paused(string message)
    {
        Console.WriteLine($"Paused: {message}");
    }

    public void Stopped(string message)
    {
        Console.WriteLine($"Stopped: {message}");
    }

    public void Skipped(string message)
    {
        Console.WriteLine($"Skipped: {message}");
    }
}