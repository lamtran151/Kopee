using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;
using System.Threading.Tasks;

namespace Myrmica.Service.Interfaces
{
    public interface IClientSettingService
    {
        public Task<string> AddClientSettingAsync(ClientSettingDto menu);
        public Task<ClientSettingDto> GetClientSettingByIdAsync(string menuId);
        public Task<IPagedList<ClientSettingDto>> GetPagedClientSettingAsync(string keyword, int pageNumber, int pageSize);
        public Task<bool> EditClientSettingAsync(ClientSettingDto dto);
        public Task<bool> DeleteClientSettingAsync(string menuId);
    }
}
