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
}
