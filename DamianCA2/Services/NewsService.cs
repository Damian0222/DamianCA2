using System.Net.Http;
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class NewsService
{
    private readonly HttpClient httpClient;
    private readonly string apiKey = "ad20792cbde444f8857c901db7813ccb"; // Replace with your NewsAPI key

    public NewsService(HttpClient httpClient)
    {
        this.httpClient = httpClient;

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new Exception("NewsAPI key is missing. Please add it in the NewsService.");
        }
    }

    public async Task<string> FetchMovieNewsAsync()
    {
        try
        {
            var url = $"https://newsapi.org/v2/everything?q=movies&apiKey={apiKey}";

            Console.WriteLine($"Looking for news articles: {url}");

            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"NewsAPI Error: {response.StatusCode}");
                var error= await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error details: {error}");
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"NewsAPI response: {json}");
            return json;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception occurred: {ex.Message}");
            return null;
        }
    }
}
