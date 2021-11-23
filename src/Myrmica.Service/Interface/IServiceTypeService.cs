using Myrmica.Solution.Business.Dtos.Product;
using Myrmica.Solution.EntityFramework.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myrmica.Solution.Business.Services.Interface
{
    public interface IServiceTypeService
    {
        public Task<string> AddServiceTypeAsync(ServiceTypeDto settingType);
        public Task<ServiceTypeDto> GetServiceTypeByIdAsync(string settingTypeId);
        public Task<PagedList<ServiceTypeDto>> GetPagedServiceTypeAsync(string keyword, int pageNumber, int pageSize);
        public Task<bool> EditServiceTypeAsync(ServiceTypeDto dto);
        public Task<bool> DeleteServiceTypeAsync(string settingTypeId);
    }
}
