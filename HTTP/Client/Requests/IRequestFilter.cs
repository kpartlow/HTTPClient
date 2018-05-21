
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HTTP.Client.Requests
{
    /// <summary>
    /// Interface implemented by the class that adds information to a request each time a request is sent, i.e. Authorization.
    /// They can also enhance the response on the way back, too.  Since this is called for each request in a retry care will
    /// be needed to not add multiple headers of the same type.
    ///  
    /// Each filter when done enhancing the request will call chain.DoFilter() to pass the request to the next spot in the chain.
    /// </summary>
    public interface IRequestFilter
    {
        
        Task<HttpResponseMessage> Filter(HttpRequestMessage message, IFilterChain chain);
    }
}
