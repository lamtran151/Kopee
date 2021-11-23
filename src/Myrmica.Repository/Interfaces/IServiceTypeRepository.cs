using Myrmica.Entity;
using System;
using System.Threading.Tasks;

namespace Myrmica.Repository.Interfaces
{
    public interface IServiceTypeRepository
    {
        Task<string> CreateServiceTypeAsync(SERVICE_TYPE serviceType);
        Task<bool> DeleteServiceTypeAsync(Guid id);
        Task<bool> EditServiceTypeAsync(SERVICE_TYPE serviceType);
        Task<SERVICE_TYPE> GetServiceTypeByIdAsync(Guid id);
        Task<IPagedList<SERVICE_TYPE>> GetPagedServiceTypeAsync(string keyword, int pageNumber, int pageSize);
    }
}
