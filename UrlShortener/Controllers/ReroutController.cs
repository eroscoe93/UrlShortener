using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.Extensions.Logging;

namespace UrlShortener.Controllers
{
    //Route changed to keep url as short as possible
    [ApiController]
    [Route("r")]
    public class ReroutController : Controller
    {
        private readonly ILogger<ReroutController> _logger;
        private IUrlShortenerService _urlShortener;

        public ReroutController(ILogger<ReroutController> logger, IUrlShortenerService urlShortener)
        {
            _logger = logger;
            _urlShortener = urlShortener;
        }

        [HttpGet("{id}")]
        public RedirectResult rerout(string id)
        {
            string redirect = _urlShortener.DecodeUrl(id);
            if (!string.IsNullOrEmpty(redirect))
            {
                return Redirect(redirect);
            }
            else
            {
                throw new Exception("URL not found");
            }
        }
    }
}
