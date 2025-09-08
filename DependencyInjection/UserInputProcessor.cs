namespace DependencyInjection;

public class UserInputProcessor: IDataProcessor
{
    public string ProcessData(string data)
    {
        if(string.IsNullOrEmpty(data))
            return "The data is null or empty";

        return data.ToUpper();
    }
}