using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;
using System.Threading.Tasks;

namespace Myrmica.Service.Interfaces
{
    public interface IServiceTypeService
    {
        public Task<string> AddServiceTypeAsync(ServiceTypeDto settingType);
        public Task<ServiceTypeDto> GetServiceTypeByIdAsync(string settingTypeId);
        public Task<IPagedList<ServiceTypeDto>> GetPagedServiceTypeAsync(string keyword, int pageNumber, int pageSize);
        public Task<bool> EditServiceTypeAsync(ServiceTypeDto dto);
        public Task<bool> DeleteServiceTypeAsync(string settingTypeId);
    }
}
