using System.Net.Mime;

namespace WriteToFile___Error_Handling;

public static class FileProcessor
{
    public static string ReadDataFromFile(string path)
    {
        try
        {
            return File.ReadAllText(path);
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException("Invalid file path provided", ex);
        }
        catch (FileNotFoundException ex)
        {
            throw new FileNotFoundException("File not found", ex);
        }
        catch (InvalidDataException ex)
        {
            throw new InvalidDataException("Invalid data in file", ex);
        }
        catch (Exception ex)
        {
            throw new Exception("An unexpected error occurred", ex);
        }
    }

    public static void WriteDataToFile(string path, string data)
    {
        try
        {
            File.WriteAllText(path, data);
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException("Invalid file path provided", ex);
        }
        catch (Exception ex)
        {
            throw new Exception("An unexpected error occurred", ex);       
        }
    }
}