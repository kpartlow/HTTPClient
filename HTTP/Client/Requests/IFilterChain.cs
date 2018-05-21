using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HTTP.Client.Requests
{
    public interface IFilterChain
    {
        Task<HttpResponseMessage> DoFilter(HttpRequestMessage message);

        CancellationToken CancellationToken { get;  }

        Guid CorrelationId { get; }
    }
}
