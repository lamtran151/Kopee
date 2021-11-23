using Myrmica.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Myrmica.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<string> CreateCategoryAsync(CATEGORY category);
        Task<bool> DeleteCategoryAsync(Guid id);
        Task<bool> EditCategoryAsync(CATEGORY category);
        Task<CATEGORY> GetCategoryByIdAsync(Guid id);
        Task<CATEGORY> GetCategoryByRouteAsync(string route);
        Task<List<CATEGORY>> GetCategoryByServiceType(string serviceTypeId);
        Task<IPagedList<CATEGORY>> GetPagedCategoriesAsync(string keyword, int pageNumber, int pageSize);
    }
}
