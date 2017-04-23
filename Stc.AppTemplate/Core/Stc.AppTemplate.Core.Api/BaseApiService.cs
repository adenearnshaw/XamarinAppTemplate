using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Stc.AppTemplate.Core.Api
{
    public class BaseApiService
    {
        private readonly string _serviceBaseUrl;

        public BaseApiService(string serviceBaseUrl)
        {
            _serviceBaseUrl = serviceBaseUrl;
        }

        protected async Task<HttpResponseMessage> SendUnauthorisedRequestAsync(HttpRequestMessage message)
        {
            var client = BuildClient();
            var response = await client.SendAsync(message);
            return response;
        }

        private HttpClient BuildClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(_serviceBaseUrl)
            };
            return client;
        }
    }
}
