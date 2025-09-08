namespace DependencyInjection;

public class DataProcessingService
{
    IDataProcessor _dataProcessor;
    public DataProcessingService(IDataProcessor dataProcessor)
    {
        _dataProcessor = dataProcessor;
    }

    public void DisplayData(string data)
    {
        string displayText = _dataProcessor.ProcessData(data);
        Console.WriteLine(displayText);
    }
}