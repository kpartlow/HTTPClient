using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HTTP.Client.Requests.Filters
{
    public class UserAgentRequestFilter : IRequestFilter
    {
        private readonly string userAgent;

        public UserAgentRequestFilter(string userAgent)
        {
            this.userAgent = userAgent;
        }

        public async Task<HttpResponseMessage> Filter(HttpRequestMessage message, IFilterChain chain)
        {
            message.Headers.Add("User-Agent", userAgent);
            return await chain.DoFilter(message);
        }
    }
}
