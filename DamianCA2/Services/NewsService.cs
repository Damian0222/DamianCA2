using System.Net.Http;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using DamianCA2;

//NewsService class fpr newsfeed
public class NewsService
{
    // This is a read only field for HTTP
    private readonly HttpClient httpClient;
    // API key to NewsAPI
    private readonly string apiKey = "ad20792cbde444f8857c901db7813ccb"; 
    // Constructor for NewsService
     public NewsService(HttpClient httpClient)
    {
       // Puts the provided HttpClient to a private field
        this.httpClient = httpClient;
        // Checks if the API key is empty or has whitespaces
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            // Throws an exception if the API key is wrong
            throw new Exception("NewsAPI key is missing. Please add it in the NewsService.");
        }
    }
    // Async method to fetch news articles
    public async Task<string> FetchMovieNewsAsync()
    {
        try
        {
            // URL for the NewsAPI request and API key.
            var url = $"https://newsapi.org/v2/everything?q=movies&apiKey={apiKey}";
            Console.WriteLine($"Looking for news articles: {url}");
            // Sends an getasync request to the NewsAPI 
            var response = await httpClient.GetAsync(url);
            // Checksthere is an an error.
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"NewsAPI Error: {response.StatusCode}");
                // Reads error message from the response
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error details: {error}");
                return null;
            }
            // Reads the response as a JSON string
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
