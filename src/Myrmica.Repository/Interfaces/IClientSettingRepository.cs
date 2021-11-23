using Myrmica.Entity;
using System;
using System.Threading.Tasks;

namespace Myrmica.Repository.Interfaces
{
    public interface IClientSettingRepository
    {
        Task<string> CreateClientSettingAsync(CLIENT_SETTINGS client_settings);
        Task<bool> DeleteClientSettingAsync(Guid id);
        Task<bool> EditClientSettingAsync(CLIENT_SETTINGS client_settings);
        Task<CLIENT_SETTINGS> GetClientSettingByIdAsync(Guid id);
        Task<IPagedList<CLIENT_SETTINGS>> GetPagedClientSettingAsync(string keyword, int pageNumber, int pageSize);
    }
}
