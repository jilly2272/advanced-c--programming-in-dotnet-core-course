namespace GenericCache___Constraints_and_Advanced_Generics;

public class GenericCache<T>
{
    private List<CacheItem<T>> cache = new ();
    
    public void AddItem(CacheItem<T> item)
    {
        RemoveExpiredItems();
        cache.Add(item);
    }

    public CacheItem<T> GetItem(T itemVal)
    {
        RemoveExpiredItems();
        CacheItem<T> item = cache.FirstOrDefault(i => Equals(i.value, itemVal));
        if (item != null)
            return item;
        
        throw new InvalidOperationException("Item does not exist in cache or is expired");
    }

    public void DisplayCache()
    {
        RemoveExpiredItems();
        if(cache.Count == 0)
        {
            Console.WriteLine("There are no items in the cache");
            return;
        }
        
        foreach (CacheItem<T> item in cache)
        {
            Console.WriteLine($"Value: {item.value}, Expiration Time: {item.expirationTime}");
        }
    }

    public void RemoveExpiredItems()
    {
        cache.RemoveAll(i => i.IsExpired());
    }
}