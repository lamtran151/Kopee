using Myrmica.Entity;
using System;
using System.Threading.Tasks;

namespace Myrmica.Repository.Interfaces
{
    public interface IClientRepository
    {
        Task<string> CreateClientAsync(CLIENT client);
        Task<bool> DeleteClientAsync(Guid id);
        Task<bool> EditClientAsync(CLIENT client);
        Task<CLIENT> GetClientByIdAsync(Guid id);
        Task<IPagedList<CLIENT>> GetPagedClientAsync(string keyword, int pageNumber, int pageSize);
    }
}
