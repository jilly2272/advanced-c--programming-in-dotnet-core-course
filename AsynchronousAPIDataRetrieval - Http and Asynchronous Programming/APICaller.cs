namespace AsynchronousAPIDataRetrieval___Http_and_Asynchronous_Programming;

public static class APICaller
{
    static readonly HttpClient client = new HttpClient();

    public static async Task<string> GetData(string requestUri)
    {
        try
        {
            using HttpResponseMessage response = await client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"{e.Message}");
            return "";
        }
    }
}