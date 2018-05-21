using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HTTP.Client.Requests.Chaining
{
    // Chain of Responsibility for filtering HttpRequestMessages.  This needs to be created for each request.
    public class FilterChain : IFilterChain
    {
        private readonly IHttpClientProvider httpClientProvider;
        private readonly IRequestFilter[] filters;
        private readonly int lastPos;
        private int currentPos;

        public FilterChain(IHttpClientProvider httpClientProvider, IRequestFilter[] filters, Guid correlationId, CancellationToken cancellationToken = default(CancellationToken))
        {
            this.httpClientProvider = httpClientProvider ?? throw new ArgumentNullException(nameof(httpClientProvider), "httpClientProvider cannot be null");

            this.filters = filters ?? new IRequestFilter[0];
            this.lastPos = this.filters.Length - 1;
            this.currentPos = 0;
            this.CorrelationId = correlationId;
            this.CancellationToken = cancellationToken;
        }

        public async Task<HttpResponseMessage> DoFilter(HttpRequestMessage message)
        {
            if (currentPos < lastPos)
            {
                return await filters[currentPos++].Filter(message, this);
            }

            return await this.httpClientProvider.GetClient().SendAsync(message, CancellationToken);
        }

        public CancellationToken CancellationToken { get; }
        public Guid CorrelationId { get; }
    }
}
