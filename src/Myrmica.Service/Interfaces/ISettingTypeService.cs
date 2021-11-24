using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;
using System.Threading.Tasks;

namespace Myrmica.Service.Interfaces
{
    public interface ISettingTypeService
    {
        public Task<string> AddSettingTypeAsync(SettingTypeDto settingType);
        public Task<SettingTypeDto> GetSettingTypeByIdAsync(string settingTypeId);
        public Task<IPagedList<SettingTypeDto>> GetPagedSettingTypeAsync(string keyword, int pageNumber, int pageSize);
        public Task<bool> EditSettingTypeAsync(SettingTypeDto dto);
        public Task<bool> DeleteSettingTypeAsync(string settingTypeId);
    }
}
