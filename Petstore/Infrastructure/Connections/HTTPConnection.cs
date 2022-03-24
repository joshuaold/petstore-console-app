using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Infrastructure.Connections
{
    public class HTTPConnection : IHTTPConnection
    {
        private HttpClient _httpClient;

        public HttpClient GetConnection()
        {
            if (_httpClient != null)
            {
                return _httpClient;
            }
            else
            {
                return new HttpClient();
            }
        }
    }
}
