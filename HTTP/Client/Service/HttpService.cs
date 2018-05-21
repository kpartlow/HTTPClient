using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HTTP.Client.Requests;
using HTTP.Client.Requests.Filter;

namespace HTTP.Client.Service
{
    public abstract class HttpService
    {
        private readonly Uri baseUrl;

        private readonly IFilterChainFactory filterChainFactory;

        public HttpService(IFilterChainFactory filterChainFactory, string baseUrl)
        {
            this.filterChainFactory = filterChainFactory;
            this.baseUrl = new Uri(baseUrl, UriKind.Absolute);
        }

        // Creates the request.  If the assemblies don't need to be constructed they can be static.
        protected HttpRequestMessage CreateRequest(HttpMethod method, Uri uri)
        {
            //  May not need this since FilterChain will have the correlationId.  If we want the correlationId to not be passed via FilterChain
            //AsyncCorrelation.CreateCorrelationId();
            return new HttpRequestMessage(method, uri);
        }

        // performed for retries.
        protected  IFilterChain CreateFilterChain(Guid correlationId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.filterChainFactory.CreateFilterChain(this.RequestFilters, correlationId, cancellationToken);
        }

        // handle partial urls here.
        protected Uri CreatePath(string relativePath)
        {
            return new Uri(baseUrl, relativePath);
        }

        protected abstract IRequestFilter[] RequestFilters { get; }
    }
}
