using DamianCA2.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


namespace DamianCA2
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

           
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)

            });

            builder.Services.AddScoped<MovieService>();
            builder.Services.AddScoped<NewsService>();
         
            // Build the WebAssembly host
            var host = builder.Build();

            // Run the application       
            await host.RunAsync();
        }
    }


}