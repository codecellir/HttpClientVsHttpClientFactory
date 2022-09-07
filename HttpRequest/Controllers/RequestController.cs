using HttpRequest.Services;
using Microsoft.AspNetCore.Mvc;

namespace HttpRequest.Controllers
{
    [Route("api")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IHttpClientFactoryService _httpClientFactoryService;
        public RequestController(IHttpClientService httpClientService, IHttpClientFactoryService httpClientFactoryService)
        {
            _httpClientService = httpClientService;
            _httpClientFactoryService = httpClientFactoryService;
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetWithHttpClientWithUsing()
        {
            try
            {
                var result = await _httpClientService.GetBtcWithUsingAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetWithHttpClient()
        {
            try
            {
                var result = await _httpClientService.GetBtcAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("[Action]")]
        public async Task<IActionResult> GetWithHttpClientFactoryWithName()
        {
            try
            {
                var result = await _httpClientFactoryService.GetBtcWithClientNameAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetWithHttpClientFactory()
        {
            try
            {
                var result = await _httpClientFactoryService.GetBtcAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
