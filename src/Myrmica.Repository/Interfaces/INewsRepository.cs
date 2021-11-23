using Myrmica.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Myrmica.Repository.Interfaces
{
    public interface INewsRepository
    {
        Task<string> CreateNewsAsync(NEWS news);
        Task<bool> DeleteNewsAsync(Guid id);
        Task<bool> EditNewsAsync(NEWS news);
        Task<NEWS> GetNewsByIdAsync(Guid id);
        Task<NEWS> GetNewsByRouteAsync(string route, string clientId);
        Task<IPagedList<NEWS>> GetPagedNewsAsync(string keyword, int pageNumber, int pageSize);
        Task<IPagedList<NEWS>> GetPagedNewsByCategoryRouteAsync(Guid categoryId, int pageNumber, int pageSize);
        Task<List<NEWS>> GetTopNewsByCategoryAsync(string categoryId, bool isGetSpecial, int sizeLimit);
    }
}
