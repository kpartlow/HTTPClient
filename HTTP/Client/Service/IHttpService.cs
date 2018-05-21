using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HTTP.Client.Service
{
    public interface IHttpService
    {
        HttpRequestMessage CreateRequest(HttpMethod method, string url);

        Task<HttpResponseMessage> FilterRequest(HttpRequestMessage message);
    }
}
