namespace HttpRequest.Services
{
    public interface IHttpClientFactoryService
    {
        Task<string> GetBtcAsync();
        Task<string> GetBtcWithClientNameAsync();
    }
}
