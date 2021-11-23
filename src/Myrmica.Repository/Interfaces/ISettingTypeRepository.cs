using Myrmica.Entity;
using System;
using System.Threading.Tasks;

namespace Myrmica.Repository.Interfaces
{
    public interface ISettingTypeRepository
    {
        Task<string> CreateSettingTypeAsync(SETTING_TYPE settingType);
        Task<bool> DeleteSettingTypeAsync(Guid id);
        Task<bool> EditSettingTypeAsync(SETTING_TYPE settingType);
        Task<SETTING_TYPE> GetSettingTypeByIdAsync(Guid id);
        Task<IPagedList<SETTING_TYPE>> GetPagedSettingTypeAsync(string keyword, int pageNumber, int pageSize);
    }
}
