namespace WebApp.Client.Services
{
    public interface IAntiforgeryHttpClientFactory
    {
        Task<HttpClient> CreateClientAsync(string clientName = "authorizedClient");
    }
}
