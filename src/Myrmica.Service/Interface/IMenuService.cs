using Myrmica.Solution.Business.Dtos.Product.MenuDtos;
using Myrmica.Solution.EntityFramework.Extensions.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Myrmica.Solution.Business.Services.Interface
{
    public interface IMenuService
    {
        public Task<string> AddMenuAsync(MenuDto menu);
        public Task<MenuDto> GetMenuByIdAsync(string menuId);
        public Task<MenuDto> GetMenuByRouteAsync(string route);
        public Task<PagedList<MenuDto>> GetPagedMenuAsync(string keyword, int pageNumber, int pageSize);
        public Task<List<MenuByClientDto>> GetMenuByClientAsync(string clientId, int menuTypeId);
        public Task<bool> EditMenuAsync(MenuDto dto);
        public Task<bool> DeleteMenuAsync(string menuId);
    }
}
