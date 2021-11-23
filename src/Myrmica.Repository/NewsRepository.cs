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
    public class NewsRepository : INewsRepository
    {
        protected readonly IRepository<NEWS> _repo;

        public NewsRepository(IRepository<NEWS> repo)
        {
            _repo = repo;
        }

        public async Task<string> CreateNewsAsync(NEWS News)
        {
            await _repo.AddAsync(News);

            return News.ID.ToString();
        }

        public async Task<bool> DeleteNewsAsync(Guid id)
        {
            var result = false;
            var menu = await _repo.FindAsync(id);

            if (menu != null)
            {
                menu.IS_DELETED = true;
                menu.DELETED_DATE = DateTime.Now;

                await _repo.DeleteAsync(menu);
                result = true;
            }

            return result;
        }

        public async Task<bool> EditNewsAsync(NEWS News)
        {
            var result = false;
            var newsOld = await _repo.FindAsync(News.ID);

            if (newsOld != null)
            {
                newsOld.ID = News.ID;
                newsOld.TITLE = News.TITLE;
                newsOld.ROUTE = News.ROUTE;
                newsOld.CONTENT = News.CONTENT;
                newsOld.SHORT_DESCRIPTION = News.SHORT_DESCRIPTION;
                newsOld.FULL_DESCRIPTION = News.FULL_DESCRIPTION;
                if (News.BANNER_ID != null)
                {
                    newsOld.BANNER_ID = News.BANNER_ID;
                }
                if (News.BANNER_SPECIAL_ID != null)
                {
                    newsOld.BANNER_SPECIAL_ID = News.BANNER_SPECIAL_ID;
                }
                newsOld.CATEGORY_ID = News.CATEGORY_ID;
                newsOld.IS_SPECIAL = News.IS_SPECIAL;
                newsOld.UPDATED_DATE = DateTime.Now;
                await _repo.UpdateAsync(newsOld);
                result = true;
            }
            return result;
        }

        public async Task<NEWS> GetNewsByIdAsync(Guid id)
        {
            return await _repo.Table.Where(c => c.ID == id && !c.IS_DELETED && c.IS_ACTIVE)
                                           .FirstOrDefaultAsync();
        }

        public async Task<NEWS> GetNewsByRouteAsync(string route, string clientId)
        {
            return await _repo.Table.Where(c => c.ROUTE == route
                                                   && !c.IS_DELETED
                                                   && c.IS_ACTIVE
                                                   && c.CATEGORY.CLIENT_ID == new Guid(clientId))
                                       .Include(c => c.CATEGORY)
                                       .FirstOrDefaultAsync();
        }

        public async Task<IPagedList<NEWS>> GetPagedNewsAsync(string keyword, int pageNumber, int pageSize)
        {
            var auditLogs = await _repo.Table
                .Where(x => !x.IS_DELETED && x.IS_ACTIVE && x.TITLE.Contains(keyword))
                .ToListAsync();

            return new PagedList<NEWS>(auditLogs, pageNumber, pageSize);
        }
        public async Task<IPagedList<NEWS>> GetPagedNewsByCategoryRouteAsync(Guid categoryId, int pageNumber, int pageSize)
        {
            // từ Route Lấy ra categoryId

            var data = await _repo.Table
                .Where(x => x.CATEGORY_ID == categoryId && !x.IS_DELETED && x.IS_ACTIVE)
                .ToListAsync();

            return new PagedList<NEWS>(data, pageNumber, pageSize);
        }
        public async Task<List<NEWS>> GetTopNewsByCategoryAsync(string categoryId, bool isGetSpecial, int sizeLimit)
        {
            var data = new List<NEWS>();

            //Nếu lấy bài viết đặc biệt
            if (isGetSpecial && await _repo.Table.Where(n => n.IS_SPECIAL
                                                             && (string.IsNullOrEmpty(categoryId) || n.CATEGORY_ID == new Guid(categoryId))
                                                             && n.IS_ACTIVE
                                                             && !n.IS_DELETED).AnyAsync())
            {
                //add bài viết đặc biệt vào đầu tiên
                var specialNews = await _repo.Table.Where(n => n.IS_SPECIAL
                                                    && (string.IsNullOrEmpty(categoryId) || n.CATEGORY_ID == new Guid(categoryId))
                                                    && n.IS_ACTIVE
                                                    && !n.IS_DELETED)
                                             .OrderByDescending(n => n.CREATED_DATE)
                                             .FirstAsync();
                data.Add(specialNews);

                //add các bài viết bình thường
                data.AddRange(await _repo.Table.Where(n => (string.IsNullOrEmpty(categoryId) || n.CATEGORY_ID == new Guid(categoryId))
                                                           && n.IS_ACTIVE
                                                           && n.ID != specialNews.ID
                                                           && !n.IS_DELETED)
                                                  .OrderByDescending(n => n.CREATED_DATE)
                                                  .Take(sizeLimit - 1)
                                                  .ToListAsync());
            }
            else
            {
                data = await _repo.Table.Where(n => n.CATEGORY_ID == new Guid(categoryId) && n.IS_ACTIVE && !n.IS_DELETED)
                                           .OrderByDescending(n => n.CREATED_DATE)
                                           .Take(sizeLimit)
                                           .ToListAsync();
            }


            return data;
        }
    }
}
