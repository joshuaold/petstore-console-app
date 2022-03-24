using Core.Interfaces.Services;
using Core.PetAggregate;
using Infrastructure.Connections;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PetstoreService : WebApiService, IPetstoreService
    {
        public PetstoreService(IHTTPConnection connection) : base(connection)
        {
        }

        public async Task<IEnumerable<Pet>> GetPetsByStatus(string status)
        {
            var httpClient = GetInitializedConnection();
            using (HttpResponseMessage response = await httpClient.GetAsync($"https://petstore.swagger.io/v2/pet/findByStatus?status={status}"))
            {
                return await response.Content.ReadAsAsync<IEnumerable<Pet>>();
            }
        }
    }
}
