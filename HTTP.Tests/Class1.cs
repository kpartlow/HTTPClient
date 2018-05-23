using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HTTP.Tests
{
    public class TestHttpClientRedirection
    {
        [Test]
        public void Test_SendAsync_When_RequestIsRedirected_FollowsRedirection()
        {
            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, "http://www.cedarsoftware.com/"))
                {
                    using (var message = client.SendAsync(request, CancellationToken.None))
                    {
                        var result = message.Result;
                        var content = result.Content.ReadAsStringAsync().Result;
                        Assert.IsTrue(result.IsSuccessStatusCode);
                        Assert.AreEqual(new Uri("https://github.com/jdereg/n-cube"), result.RequestMessage.RequestUri);
                        Assert.IsTrue(content.Contains("n-cube"));
                    }
                }
            }

        }
    }
}
