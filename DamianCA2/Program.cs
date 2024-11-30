using DamianCA2.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


namespace DamianCA2
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Create the builder for the WebAssembly host
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // Configure the HttpClient to be used throughout the application
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)

            });

            // Register the MusicService for dependency injection
            builder.Services.AddScoped<MovieService>();
            builder.Services.AddScoped<NewsService>();
         
            // Build the WebAssembly host
            var host = builder.Build();

            // Run the application       
            await host.RunAsync();
        }
    }

    // MusicService for handling API requests
}