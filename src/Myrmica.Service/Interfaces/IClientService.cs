using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;
using System.Threading.Tasks;

namespace Myrmica.Service.Interfaces
{
    public interface IClientService
    {
        public Task<string> AddClientAsync(ClientDto client);
        public Task<ClientDto> GetClientByIdAsync(string clientId);
        public Task<IPagedList<ClientDto>> GetPagedClientAsync(string keyword, int pageNumber, int pageSize);
        public Task<bool> EditClientAsync(ClientDto dto);
        public Task<bool> DeleteClientAsync(string clientId);
    }
}
