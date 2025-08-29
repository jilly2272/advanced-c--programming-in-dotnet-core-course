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
        //TODO: Collection was modified; enumeration operation may not execute error - investigate
        RemoveExpiredItems();
        CacheItem<T> item = cache.FirstOrDefault(i => Equals(i.value, itemVal));
        if (item != null)
            return item;
        
        throw new InvalidOperationException("Item does not exist in cache or is expired");
    }

    public void DisplayCache()
    {
        RemoveExpiredItems();
        foreach (CacheItem<T> item in cache)
        {
            Console.WriteLine($"{item}");
            Console.WriteLine($"\n");
        }
    }

    public void RemoveExpiredItems()
    {
        foreach (CacheItem<T> item in cache)
        {
            if (item.IsExpired())
                cache.Remove(item);
        }
    }
}