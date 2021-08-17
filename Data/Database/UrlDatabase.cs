using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Domain.Database;

namespace Data.Database
{
    public static class UrlDatabase
    {

        private static List<UrlData> _data = new List<UrlData>();

        public static string GetRedirectByHash(string hash)
        {
            return _data.FirstOrDefault(e => e.hash == hash)?.redirect;
        }

        public static string GetHashByRedirect(string redirect)
        {

            return _data.FirstOrDefault(e => e.redirect == redirect)?.hash;
        }

        public static void Insert(UrlData data)
        {
            _data.Add(data);
        }
    }
}
