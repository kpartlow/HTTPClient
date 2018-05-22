using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HTTP.Client.Requests.Filters
{
    public class CorrelatingRequestFilter : IRequestFilter
    {
        public const string XCorrelationIdHeader = "X-Correlation-Id";

        public Task<HttpResponseMessage> Filter(HttpRequestMessage message, IFilterChain chain)
        {
            if (message == null) { throw new ArgumentException("message cannot be null"); }

            // empty correlationId will be ignored.
            if (Guid.Empty != chain.CorrelationId)
            {
                message.Headers.Add(XCorrelationIdHeader, chain.CorrelationId.ToString("N"));
            }

            return chain.DoFilter(message);
        }
    }
}
