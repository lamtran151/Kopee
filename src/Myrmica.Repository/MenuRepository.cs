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
    public class MenuRepository : IMenuRepository
    {
        protected readonly IRepository<MENU> _repo;

        public MenuRepository(IRepository<MENU> repo)
        {
            _repo = repo;
        }

        public async Task<string> CreateMenuAsync(MENU Menu)
        {
            await _repo.AddAsync(Menu);

            return Menu.ID.ToString();
        }

        public async Task<bool> DeleteMenuAsync(Guid id)
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

        public async Task<bool> EditMenuAsync(MENU Menu)
        {
            var result = false;
            var menu_old = await _repo.FindAsync(Menu.ID);

            if (menu_old != null)
            {
                menu_old.ID = Menu.ID;
                menu_old.TITLE = Menu.TITLE;
                menu_old.ROUTE = Menu.ROUTE;
                menu_old.ORDER = Menu.ORDER;
                menu_old.PARENT_ID = Menu.PARENT_ID;
                menu_old.MENU_TYPE_ID = Menu.MENU_TYPE_ID;
                menu_old.CLIENT_ID = Menu.CLIENT_ID;
                menu_old.UPDATED_DATE = DateTime.Now;
                await _repo.UpdateAsync(menu_old);
                result = true;
            }
            return result;
        }

        public async Task<List<MENU>> GetMenuByClientAsync(Guid ClientId, int menuTypeId)
        {
            var menus = await _repo.Table.Where(m => m.CLIENT_ID == ClientId
                                                     && m.PARENT_ID == null
                                                     && m.MENU_TYPE_ID == menuTypeId
                                                     && m.IS_ACTIVE
                                                     && !m.IS_DELETED)
                                            .Include(m => m.CHILD_MENU)
                                            .ThenInclude(cm => cm.CHILD_MENU)
                                            .OrderBy(m => m.ORDER)
                                            .ToListAsync();
            return menus;
        }
        public async Task<List<MENU>> GetMenuByClientIdAsync(Guid ClientId, int menuTypeId)
        {
            var menus = await _repo.Table.Where(m => m.CLIENT_ID == ClientId
                                                     && m.PARENT_ID == null
                                                     && m.MENU_TYPE_ID == menuTypeId
                                                     && m.IS_ACTIVE
                                                     && !m.IS_DELETED)
                                            .OrderBy(m => m.ORDER)
                                            .ToListAsync();
            return menus;
        }

        public async Task<MENU> GetMenuByIdAsync(Guid id)
        {
            return await _repo.Table.Where(c => c.ID == id && c.IS_ACTIVE && !c.IS_DELETED)
                                       .FirstOrDefaultAsync();
        }
        public async Task<MENU> GetMenuByRouteAsync(string route)
        {
            return await _repo.Table.Where(c => c.ROUTE == route && c.IS_ACTIVE && !c.IS_DELETED)
                                           .FirstOrDefaultAsync();
        }

        public async Task<IPagedList<MENU>> GetPagedMenuAsync(string keyword, int pageNumber, int pageSize)
        {

            var auditLogs = await _repo.Table.Where(c => c.IS_ACTIVE && !c.IS_DELETED)
                                                .OrderBy(m => m.MENU_TYPE_ID)
                                                .ThenBy(m => m.ORDER)
                                                .ToListAsync();

            return new PagedList<MENU>(auditLogs, pageNumber, pageSize);
        }
    }
}
