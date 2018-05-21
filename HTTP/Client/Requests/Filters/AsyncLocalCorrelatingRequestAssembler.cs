using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HTTP.Client.Requests.Filter
{
    public class AsyncLocalCorrelatingRequestAssembler : IRequestFilter
    {
        public const string CorrelationIdHttpHeaderName = "X-Correlation-Id";

        /// <summary>
        /// Uses AsyncLocal to retrieve the correlationId.  Not needed if we decide to use the IFilterChain to pass correlationId.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="chain"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Filter(HttpRequestMessage message, IFilterChain chain)
        {
            // add header
            Guid correlationId = AsyncCorrelation.RetrieveCorrelationId();

            // empty correlationId will be ignored.
            if (Guid.Empty != correlationId)
            {
                message.Headers.Add(CorrelationIdHttpHeaderName, correlationId.ToString("N"));
            }

            return await chain.DoFilter(message);
        }
    }
}
