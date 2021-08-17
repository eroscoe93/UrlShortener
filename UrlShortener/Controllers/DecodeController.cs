using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UrlShortener.Dtos;

namespace UrlShortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DecodeController : ControllerBase
    {
        private readonly ILogger<DecodeController> _logger;
        private IUrlShortenerService _urlShortener;

        public DecodeController(ILogger<DecodeController> logger, IUrlShortenerService urlShortener)
        {
            _logger = logger;
            _urlShortener = urlShortener;
        }

        [HttpPost]
        public UrlDto Decode(ShortenedUrlDto request)
        {
            UrlDto url = new UrlDto()
            {
                Url = _urlShortener.DecodeUrl(request.ShortenedUrl.Split("/")[^1])
            };
            return url;
        }
    }
}
