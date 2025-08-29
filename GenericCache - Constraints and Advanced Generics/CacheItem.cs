namespace GenericCache___Constraints_and_Advanced_Generics;

public class CacheItem<T>
{
    public T value;
    public DateTime expirationTime;

    public CacheItem(T val, DateTime exp)
    {
        value = val;
        expirationTime = exp;
    }

    public bool IsExpired()
    {
        return DateTime.Now > expirationTime;
    }
}