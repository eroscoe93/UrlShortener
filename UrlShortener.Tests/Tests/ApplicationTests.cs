using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Application.UrlShortener;
using Xunit;

namespace UrlShortener.Tests.Tests
{
    public class ApplicationTests
    {
        [Fact]
        public void CheckFindsUrl()
        {
            UrlShortenerService service = new UrlShortenerService();
            var value1 = service.SaveUrl("https://google.com");
            Assert.Equal("https://google.com", service.DecodeUrl(value1));
        }

        [Fact]
        public void CheckInvalidUrlError()
        {
            UrlShortenerService service = new UrlShortenerService();
            try
            {
                service.SaveUrl("htts://google.com");
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void CheckDecodeSameUrl()
        {
            UrlShortenerService service = new UrlShortenerService();
            var value1 = service.SaveUrl("https://google.com");
            Assert.Equal("https://google.com", service.DecodeUrl(value1.Split("/")[^1]));
        }

        [Fact]
        public void CheckSameValueGetsSameUrl()
        {
            UrlShortenerService service = new UrlShortenerService();
            var value1 = service.SaveUrl("https://google.com");
            var value2 = service.SaveUrl("https://google.com");
            Assert.Equal(value1, value2);
        }
    }
}
