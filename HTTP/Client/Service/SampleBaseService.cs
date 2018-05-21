using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HTTP.Client.Requests;

namespace HTTP.Client.Service
{
    public class SampleBaseService : HttpService
    {
        public SampleBaseService(IFilterChainFactory filterChainFactory, ISystemConfiguration config, IRequestFilter[] requestFilters)
            : base(filterChainFactory, config.getLocation("tax.location"))                
        {
            //  request filter is a chaining (pipeline) of things that must happen on every retry of every request (if you need new tokens for AUTH, etc.)
            this.RequestFilters = requestFilters;
        }

        /// <summary>
        /// I left the rety logic out of here for simplicity, but we could create a filter in the filter chain that is actually the retry logic.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="correlationId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected virtual async Task<string> GetData(string url, Guid correlationId, CancellationToken cancellationToken = default(CancellationToken))
        {
            // left out retries and stuff for now.
            using (var message = this.CreateRequest(HttpMethod.Get, this.CreatePath(url)))
            {
                var filterChain = this.CreateFilterChain(correlationId, cancellationToken);

                using (var response = await filterChain.DoFilter(message))
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

        protected override IRequestFilter[] RequestFilters { get; }
    }
}
