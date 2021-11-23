using Microsoft.EntityFrameworkCore;
using Myrmica.Data;
using Myrmica.Entity;
using Myrmica.Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Repository
{
    public class ClientSettingRepository : IClientSettingRepository
    {
        protected readonly IRepository<CLIENT_SETTINGS> _repo;

        public ClientSettingRepository(IRepository<CLIENT_SETTINGS> repo)
        {
            _repo = repo;
        }

        public async Task<string> CreateClientSettingAsync(CLIENT_SETTINGS ClientSetting)
        {
            await _repo.AddAsync(ClientSetting);

            return ClientSetting.ID.ToString();
        }

        public async Task<bool> DeleteClientSettingAsync(Guid id)
        {
            var result = false;
            var client_settings = await _repo.FindAsync(id);
            if (client_settings != null)
            {
                client_settings.IS_DELETED = true;
                client_settings.DELETED_DATE= DateTime.Now;

                await _repo.DeleteAsync(client_settings);
                result = true;
            }

            return result;
        }

        public async Task<bool> EditClientSettingAsync(CLIENT_SETTINGS ClientSetting)
        {
            var result = false;
            var client_settings_old = await _repo.FindAsync(ClientSetting.ID);
            client_settings_old.KEY = ClientSetting.KEY;
            client_settings_old.VALUE = ClientSetting.VALUE;
            client_settings_old.CLIENT_ID = ClientSetting.CLIENT_ID;
            client_settings_old.SETTING_TYPE_ID = ClientSetting.SETTING_TYPE_ID;
            client_settings_old.UPDATED_DATE = DateTime.Now;

            if (client_settings_old != null)
            {
                client_settings_old.ID = ClientSetting.ID;
                await _repo.UpdateAsync(client_settings_old);
                result = true;
            }
            return result;
        }

        public async Task<CLIENT_SETTINGS> GetClientSettingByIdAsync(Guid id)
        {
            return await _repo.Table.Where(c => c.ID.ToString() == id.ToString() && !c.IS_DELETED)
                                           .FirstOrDefaultAsync();
        }

        public async Task<IPagedList<CLIENT_SETTINGS>> GetPagedClientSettingAsync(string keyword, int pageNumber, int pageSize)
        {
            var auditLogs = await _repo.Table
                .Where(x => !x.IS_DELETED && x.IS_ACTIVE)
                .ToListAsync();

            return new PagedList<CLIENT_SETTINGS>(auditLogs, pageNumber, pageSize);
        }
    }
}
