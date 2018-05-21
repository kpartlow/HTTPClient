using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HTTP.Client.Providers
{
    public class HttpClientProvider
    {
        private readonly HttpClient _httpClient;

        public HttpClientProvider(HttpClient client)
        {
            this._httpClient = client;
        }
    }
}
