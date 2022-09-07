namespace HttpRequest.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
        private static HttpClient _httpClient = new HttpClient(new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(1)
        });
        public HttpClientService(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUrl = _configuration.GetSection("CoinDeskApi:Url").Value;
        }
        public async Task<string> GetBtcAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}currentprice.json");
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                return "Error";
            }
        }

        public async Task<string> GetBtcWithUsingAsync()
        {
            try
            {
                using var httpClient = new HttpClient();
                var response = await httpClient.GetAsync($"{_baseUrl}currentprice.json");
                return await response.Content.ReadAsStringAsync();

            }
            catch (Exception)
            {
                return "Error";
            }

        }
    }
}
