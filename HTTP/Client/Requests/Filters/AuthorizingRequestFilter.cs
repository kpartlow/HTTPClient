using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HTTP.Client.Security;

namespace HTTP.Client.Requests
{
    public class AuthorizingRequestFilter : IRequestFilter
    {
        public readonly IAuthTokenProvider AuthTokenProvider;
        public readonly bool isAuthenticating;

        public const string BEARER = "Bearer";

        public AuthorizingRequestFilter(IAuthTokenProvider tokenProvider /*, ISystemConfig systemConfig */)
        {
            this.AuthTokenProvider = tokenProvider;
            this.isAuthenticating = false;
        }

        public async Task<HttpResponseMessage> Filter(HttpRequestMessage message, IFilterChain chain)
        {
            if (isAuthenticating)
            {
                message.Headers.Authorization = this.CreateAuthHeader();
            }

            return await chain.DoFilter(message);
        }

        public AuthenticationHeaderValue CreateAuthHeader()
        {
            var basicBytes = Encoding.ASCII.GetBytes("SOME STRING");
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(basicBytes));
        }
    }
}
