using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface  IUrlShortenerService
    {
        /// <summary>
        /// Saves a url if it has not been hashed.
        /// </summary>
        /// <param name="url">The plain url to save.</param>
        /// <returns>The shortened url parameter.</returns>
        string SaveUrl(string url);

        /// <summary>
        /// Decodes the url.
        /// </summary>
        /// <param name="hash">The hash to decode.</param>
        /// <returns>The location that this redirects too.</returns>
        string DecodeUrl(string hash);

    }
}
