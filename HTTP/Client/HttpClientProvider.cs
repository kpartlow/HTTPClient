using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HTTP.Client
{
    /**
     * Should be a singleton for the whole application.
     * this will make the best reuse of ports in each VM.
     */
    public class HttpClientProvider : IHttpClientProvider
    {
        private readonly HttpClient client;

        public HttpClientProvider(HttpClient httpClient)
        {
            this.client = httpClient;
        }

        public HttpClient GetClient()
        {
            return this.client;
        }
    }
}
