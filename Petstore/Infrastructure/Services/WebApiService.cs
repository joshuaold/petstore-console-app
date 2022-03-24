using Infrastructure.Connections;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Infrastructure.Services
{
    public class WebApiService
    {
        private readonly IHTTPConnection _connection;

        public WebApiService(IHTTPConnection connection)
        {
            _connection = connection;
        }

        public HttpClient GetInitializedConnection()
        {
            var connection = _connection.GetConnection();

            connection.DefaultRequestHeaders.Accept.Clear();
            connection.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return connection;
        }
    }
}
