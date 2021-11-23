using Myrmica.Solution.Business.Dtos.Product;
using Myrmica.Solution.EntityFramework.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myrmica.Solution.Business.Services.Interface
{
    public interface ISettingTypeService
    {
        public Task<string> AddSettingTypeAsync(SettingTypeDto settingType);
        public Task<SettingTypeDto> GetSettingTypeByIdAsync(string settingTypeId);
        public Task<PagedList<SettingTypeDto>> GetPagedSettingTypeAsync(string keyword, int pageNumber, int pageSize);
        public Task<bool> EditSettingTypeAsync(SettingTypeDto dto);
        public Task<bool> DeleteSettingTypeAsync(string settingTypeId);
    }
}
