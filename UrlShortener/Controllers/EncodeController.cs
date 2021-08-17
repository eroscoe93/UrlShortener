using System;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UrlShortener.Dtos;

namespace UrlShortener.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncodeController : ControllerBase
    {
        private readonly ILogger<EncodeController> _logger;
        private IUrlShortenerService _urlShortener;

        public EncodeController(ILogger<EncodeController> logger, IUrlShortenerService urlShortener)
        {
            _logger = logger;
            _urlShortener = urlShortener;
        }

        [HttpPost]
        public ShortenedUrlDto Encode(UrlDto request)
        {
            string shortUrl = _urlShortener.SaveUrl(request.Url);
            
            return new ShortenedUrlDto()
            {
                ShortenedUrl = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/r/" + shortUrl
            };
        }
    }
}
