using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Infrastructure.Connections
{
    public interface IHTTPConnection
    {
        HttpClient GetConnection();
    }
}
