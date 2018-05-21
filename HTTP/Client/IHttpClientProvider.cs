using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HTTP.Client
{
    public interface IHttpClientProvider
    {
        HttpClient GetClient();
    }
}
