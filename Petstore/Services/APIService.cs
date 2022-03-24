using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Services
{
    public class APIService
    {
        private HttpClient _httpClient;

        public void InitializeClient()
        {
            _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpClient GetClient()
        {
            return _httpClient;
        }
    }
}
