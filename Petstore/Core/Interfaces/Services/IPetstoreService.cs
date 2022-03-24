using Core.PetAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IPetstoreService : IWebApiService
    {
        Task<IEnumerable<Pet>> GetPetsByStatus(string status);
    }
}
