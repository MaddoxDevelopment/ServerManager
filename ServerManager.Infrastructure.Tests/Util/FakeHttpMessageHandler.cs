using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ServerManager.Infrastructure.Tests.Util
{
    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        public HttpRequestMessage RequestMessage => requestMessage;

        private readonly HttpResponseMessage response;
        private HttpRequestMessage requestMessage;

        public static FakeHttpMessageHandler GetHttpMessageHandler(string content, HttpStatusCode httpStatusCode)
        {
            var memStream = new MemoryStream();

            var sw = new StreamWriter(memStream);
            sw.Write(content);
            sw.Flush();
            memStream.Position = 0;

            var httpContent = new StreamContent(memStream);

            var responseMessage = new HttpResponseMessage
            {
                StatusCode = httpStatusCode,
                Content = httpContent
            };

            var messageHandler = new FakeHttpMessageHandler(responseMessage);

            return messageHandler;
        }

        public FakeHttpMessageHandler(HttpResponseMessage response)
        {
            this.response = response;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            requestMessage = request;
            var tcs = new TaskCompletionSource<HttpResponseMessage>();

            tcs.SetResult(response);

            return tcs.Task;
        }
    }
}