namespace HttpRequest.Services
{
    public interface IHttpClientService
    {
        Task<string> GetBtcAsync();

        Task<string> GetBtcWithUsingAsync();
    }
}
