namespace HttpRequest.Services
{
    public class HttpClientFactoryService : IHttpClientFactoryService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUrl;
        public HttpClientFactoryService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _baseUrl = _configuration.GetSection("CoinDeskApi:Url").Value;
        }
        public async Task<string> GetBtcAsync()
        {
            try
            {
                using var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"{_baseUrl}currentprice.json");
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                return "Error";
            }
        }

        public async Task<string> GetBtcWithClientNameAsync()
        {
            try
            {
                using var client = _httpClientFactory.CreateClient("coinDeskApi");
                var response = await client.GetAsync("currentprice.json");
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                return "Error";
            }
        }
    }
}
