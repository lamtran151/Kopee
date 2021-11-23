using Myrmica.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Myrmica.Repository.Interfaces
{
    public interface IMenuRepository
    {
        Task<string> CreateMenuAsync(MENU menu);
        Task<bool> DeleteMenuAsync(Guid id);
        Task<bool> EditMenuAsync(MENU menu);
        Task<MENU> GetMenuByIdAsync(Guid id);
        Task<MENU> GetMenuByRouteAsync(string route);
        Task<IPagedList<MENU>> GetPagedMenuAsync(string keyword, int pageNumber, int pageSize);
        Task<List<MENU>> GetMenuByClientAsync(Guid ClientId, int menuTypeId);
        Task<List<MENU>> GetMenuByClientIdAsync(Guid ClientId, int menuTypeId);
    }
}
