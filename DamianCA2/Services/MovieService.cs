using DamianCA2.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DamianCA2.Services
{
    public class MovieService
    {
        private readonly HttpClient httpClient;
        private readonly string apiKey = "9fb03db06401769da1426077f6d5fd9c"; // Replace with your TMDb API key

        public MovieService(HttpClient httpClient)
        {
            this.httpClient = httpClient;

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new Exception("No API key added, please try again");
            }
        }
        public async Task<string> FetchMusicData(string query)
        {
            try
            {
                var url = $"https://api.themoviedb.org/3/search/movie?api_key={apiKey}&query={Uri.EscapeDataString(query)}";

                Console.WriteLine($"Searching: {url}");
                var response = await httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Api error: {response.StatusCode}");
                    var errorDetails = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error details: {errorDetails}");
                    return null;
                }

                // Read and return the JSON response
                var jsonResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Response: {jsonResponse}");
                return jsonResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred in MovieService: {ex.Message}");
                return null;
            }
        }
    }
}