using Myrmica.Solution.Business.Dtos.Product;
using Myrmica.Solution.EntityFramework.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myrmica.Solution.Business.Services.Interface
{
    public interface IClientService
    {
        public Task<string> AddClientAsync(ClientDto client);
        public Task<ClientDto> GetClientByIdAsync(string clientId);
        public Task<PagedList<ClientDto>> GetPagedClientAsync(string keyword, int pageNumber, int pageSize);
        public Task<bool> EditClientAsync(ClientDto dto);
        public Task<bool> DeleteClientAsync(string clientId);
    }
}
