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
    }
}