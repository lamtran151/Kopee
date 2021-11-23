using Microsoft.EntityFrameworkCore;
using Myrmica.Data;
using Myrmica.Entity;
using Myrmica.Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Repository
{
    public class ServiceTypeRepository: IServiceTypeRepository
    {
        protected readonly IRepository<SERVICE_TYPE> _repo;

        public ServiceTypeRepository(IRepository<SERVICE_TYPE> repo)
        {
            _repo = repo;
        }

        public async Task<string> CreateServiceTypeAsync(SERVICE_TYPE ServiceType)
        {
            await _repo.AddAsync(ServiceType);

            return ServiceType.ID.ToString();
        }

        public async Task<bool> DeleteServiceTypeAsync(Guid id)
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

        public async Task<bool> EditServiceTypeAsync(SERVICE_TYPE ServiceType)
        {
            var result = false;
            var menu_old = await _repo.FindAsync(ServiceType.ID);

            if (menu_old != null)
            {
                menu_old.ID = ServiceType.ID;
                menu_old.TITLE = ServiceType.TITLE;
                menu_old.UPDATED_DATE = DateTime.Now;
                await _repo.UpdateAsync(menu_old);
                result = true;
            }
            return result;
        }

        public async Task<SERVICE_TYPE> GetServiceTypeByIdAsync(Guid id)
        {
            return await _repo.Table.Where(c => c.ID == id && !c.IS_DELETED)
                                           .FirstOrDefaultAsync();
        }

        public async Task<IPagedList<SERVICE_TYPE>> GetPagedServiceTypeAsync(string keyword, int pageNumber, int pageSize)
        {
            var auditLogs = await _repo.Table
                .Where(x => !x.IS_DELETED && x.IS_ACTIVE)
                .ToListAsync();

            return new PagedList<SERVICE_TYPE>(auditLogs, pageNumber, pageSize);
        }
    }
}
