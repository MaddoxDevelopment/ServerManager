using System.Net;
using System.Net.Http;

namespace ServerManager.Infrastructure.Tests.Util
{
    public class FakeHttpClientFactory : IHttpClientFactory
    {
        private readonly string response;
        private readonly HttpStatusCode status;
        public FakeHttpMessageHandler Handler { get; private set; }

        public FakeHttpClientFactory(string response, HttpStatusCode status)
        {
            this.response = response;
            this.status = status;
        }

        public HttpClient CreateClient(string name)
        {
            Handler = FakeHttpMessageHandler.GetHttpMessageHandler(response, status);
            return new HttpClient(Handler);
        }
    }
}