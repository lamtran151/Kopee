using Microsoft.EntityFrameworkCore;
using Myrmica.Data;
using Myrmica.Entity;
using Myrmica.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Repository
{
    public class CategoryRepository :ICategoryRepository
    {
        protected readonly IRepository<CATEGORY> _repo;

        public CategoryRepository(IRepository<CATEGORY> repo)
        {
            _repo = repo;
        }

        public async Task<string> CreateCategoryAsync(CATEGORY category)
        {
            await _repo.AddAsync(category);
            return category.ID.ToString();
        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            var result = false;
            var cate = await _repo.FindAsync(id);

            if (cate != null)
            {
                cate.IS_DELETED = true;
                cate.DELETED_DATE = DateTime.Now;

                await _repo.DeleteAsync(cate);
                result = true;
            }

            return result;
        }

        public async Task<bool> EditCategoryAsync(CATEGORY category)
        {
            var result = false;
            var cate = await _repo.FindAsync(category.ID);

            if (cate != null)
            {
                cate.NAME = category.NAME;
                cate.ROUTE = category.ROUTE;
                cate.IS_ACTIVE = category.IS_ACTIVE;
                cate.UPDATED_DATE = DateTime.Now;
                if (category.BANNER_ID != null)
                {
                    cate.BANNER_ID = category.BANNER_ID;
                }
                cate.CATEGORY_PARENT_ID = category.CATEGORY_PARENT_ID;
                cate.CLIENT_ID = category.CLIENT_ID;
                cate.SERVICE_TYPE_ID = category.SERVICE_TYPE_ID;

                await _repo.UpdateAsync(cate);
                result = true;
            }

            return result;
        }

        public async Task<CATEGORY> GetCategoryByIdAsync(Guid id)
        {
            return await _repo.Table.Where(c => c.ID.ToString() == id.ToString() && !c.IS_DELETED && c.IS_ACTIVE)
                                           .FirstOrDefaultAsync();
        }
        public async Task<CATEGORY> GetCategoryByRouteAsync(string route)
        {
            return await _repo.Table.Where(c => c.ROUTE == route && !c.IS_DELETED && c.IS_ACTIVE)
                                           .FirstOrDefaultAsync();
        }
        public async Task<List<CATEGORY>> GetCategoryByServiceType(string serviceTypeId)
        {
            return await _repo.Table.Where(c => c.SERVICE_TYPE_ID == new Guid(serviceTypeId) && !c.IS_DELETED && c.IS_ACTIVE).ToListAsync();
        }
        public async Task<IPagedList<CATEGORY>> GetPagedCategoriesAsync(string keyword, int pageNumber, int pageSize)
        {
            var categories = await _repo.Table
                .Where(c => !c.IS_DELETED && c.IS_ACTIVE).ToListAsync();

            return new PagedList<CATEGORY>(categories, pageNumber, pageSize);
        }
    }
}
