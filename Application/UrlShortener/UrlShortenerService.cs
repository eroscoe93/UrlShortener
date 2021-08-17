using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Application.Interface;
using Data.Database;
using Domain.Database;

namespace Application.UrlShortener
{
    public class UrlShortenerService : IUrlShortenerService
    {
        public string CheckUrl(string url)
        {
            return UrlDatabase.GetHashByRedirect(url);
        }

        
        public string SaveUrl(string url)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                string hashedUrl = CheckUrl(url);
                if (string.IsNullOrEmpty(hashedUrl))
                {
                    SHA256 sha = SHA256.Create();
                    string encryptedHash = BitConverter.ToString(sha.ComputeHash(Encoding.Unicode.GetBytes(url)))
                        .Replace("-", "");
                    string shortUrl = encryptedHash.Substring(0, 6);

                    //Make sure the short url is unique.
                    int i = 0;
                    while (!string.IsNullOrEmpty(UrlDatabase.GetRedirectByHash(shortUrl)))
                    {
                        shortUrl += encryptedHash.Substring(6 + i, 1);
                        i++;
                    }

                    UrlDatabase.Insert(new UrlData() {hash = shortUrl, redirect = url});
                    return shortUrl;
                }
                else
                {
                    return hashedUrl;
                }
            }
            else
            {
                throw new Exception("Error parsing URL");
            }
        }

        public string DecodeUrl(string hash)
        {
            return UrlDatabase.GetRedirectByHash(hash);
        }
    }
}
