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
        // API key to MovieDb
        private readonly string apiKey = "9fb03db06401769da1426077f6d5fd9c";
        // Constructor for MovieService
        public MovieService(HttpClient httpClient)
        {// Puts the provided HttpClient to a private field
            this.httpClient = httpClient;

            if (string.IsNullOrWhiteSpace(apiKey))
            {  // Throws an exception if the API key is wrong
                throw new Exception("No API key added, please try again");
            }
        } 
       // Async method to fetch news articles
           public async Task<string> FetchMovieData(string query){
            try
            {  // URL for the movieDB API request and API key.
                var url = $"https://api.themoviedb.org/3/search/movie?api_key={apiKey}&query={Uri.EscapeDataString(query)}";
                Console.WriteLine($"Searching: {url}");
                // Sends an getasync request to the NewsAPI 
                var response = await httpClient.GetAsync(url);
                // Checksthere is an an error.
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Api error: {response.StatusCode}");
                    // Reads error message from the response
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