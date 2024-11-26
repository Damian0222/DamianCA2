namespace DamianCA2.Services
{
    public class MovieService
    {
  
    private readonly HttpClient httpClient;

        public MovieService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

    }
}
