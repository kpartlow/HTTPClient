using System;
using System.Threading;

namespace HTTP.Client.Requests.Chaining
{
    public class FilterChainFactory : IFilterChainFactory
    {
        private IHttpClientProvider httpClientProvider;

        public FilterChainFactory(IHttpClientProvider httpClientProvider)
        {
            this.httpClientProvider = httpClientProvider;
        }

        public IFilterChain CreateFilterChain(IRequestFilter[] filters, Guid correlationId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return new FilterChain(this.httpClientProvider, filters, correlationId, cancellationToken);
        }
    }
}
