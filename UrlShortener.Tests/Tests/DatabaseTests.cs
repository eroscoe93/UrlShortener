using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Domain.Database;
using Xunit;

namespace UrlShortener.Tests.Tests
{
    public class DatabaseTests
    {

        [Fact]
        public void InsertAndCheckRedirectDatabase()
        {
            var data = new UrlData() {redirect = "test1", hash = "test1hash"};
            UrlDatabase.Insert(data);
            Assert.Equal(UrlDatabase.GetRedirectByHash(data.hash), data.redirect);
        }

        [Fact]
        public void InsertAndCheckHashDatabase()
        {
            var data = new UrlData() { redirect = "test2", hash = "test2hash" };
            UrlDatabase.Insert(data);
            Assert.Equal(UrlDatabase.GetHashByRedirect(data.redirect), data.hash);
        }

    }
}
