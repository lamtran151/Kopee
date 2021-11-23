using Microsoft.EntityFrameworkCore;
using Myrmica.Data;
using Myrmica.Entity;
using Myrmica.Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Repository
{
    public class SettingTypeRepository : ISettingTypeRepository
    {
        protected readonly IRepository<SETTING_TYPE> _repo;

        public SettingTypeRepository(IRepository<SETTING_TYPE> repo)
        {
            _repo = repo;
        }

        public async Task<string> CreateSettingTypeAsync(SETTING_TYPE SettingType)
        {
            await _repo.AddAsync(SettingType);

            return SettingType.ID.ToString();
        }

        public async Task<bool> DeleteSettingTypeAsync(Guid id)
        {
            var result = false;
            var menu = await _repo.FindAsync(id);

            if (menu != null)
            {
                menu.IS_DELETED = true;
                menu.DELETED_DATE= DateTime.Now;

                await _repo.DeleteAsync(menu);
                result = true;
            }

            return result;
        }

        public async Task<bool> EditSettingTypeAsync(SETTING_TYPE SettingType)
        {
            var result = false;
            var menu_old = await _repo.FindAsync(SettingType.ID);

            if (menu_old != null)
            {
                menu_old.ID = SettingType.ID;
                menu_old.TITLE = SettingType.TITLE;
                menu_old.UPDATED_DATE = DateTime.Now;
                await _repo.UpdateAsync(menu_old);
                result = true;
            }
            return result;
        }

        public async Task<SETTING_TYPE> GetSettingTypeByIdAsync(Guid id)
        {
            return await _repo.Table.Where(c => c.ID == id && !c.IS_DELETED)
                                           .FirstOrDefaultAsync();
        }

        public async Task<IPagedList<SETTING_TYPE>> GetPagedSettingTypeAsync(string keyword, int pageNumber, int pageSize)
        {
            var auditLogs = await _repo.Table
                .Where(x => !x.IS_DELETED && x.IS_ACTIVE)
                .ToListAsync();

            return new PagedList<SETTING_TYPE>(auditLogs, pageNumber, pageSize);
        }
    }
}
