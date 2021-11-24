using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product.MenuDtos;
using Myrmica.Extensions.Mappers;
using Myrmica.Repository.Interfaces;
using Myrmica.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Myrmica.Service
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository menuRepository;
        private readonly HttpClient httpClient;
        private readonly string[] _permittedExtensions = { ".txt", ".jpeg", ".jpg", ".png", ".tif", ".pdf" };
        private readonly string _targetFilePath;

        public MenuService(IMenuRepository _menuRepository, HttpClient _httpClient)
        {
            menuRepository = _menuRepository;
            // To save physical files to a path provided by configuration:
            _targetFilePath = $"{AppContext.BaseDirectory}/file/";
            httpClient = _httpClient;
        }

        public async Task<string> AddMenuAsync(MenuDto menu)
        {
            var menuId = string.Empty;
            var menuEntity = menu.ToEntity();
            menuId = await menuRepository.CreateMenuAsync(menuEntity);
            return menuId;
        }

        public async Task<bool> DeleteMenuAsync(string menuId)
        {
            if (string.IsNullOrEmpty(menuId))
            {
                return false;
            }

            return await menuRepository.DeleteMenuAsync(new Guid(menuId));
        }

        public async Task<bool> EditMenuAsync(MenuDto menu)
        {
            var menuEntity = menu.ToEntity();
            return await menuRepository.EditMenuAsync(menuEntity);
        }

        public async Task<List<MenuByClientDto>> GetMenuByClientAsync(string clientId, int menuTypeId)
        {
            var listEntities = await menuRepository.GetMenuByClientAsync(new Guid(clientId), menuTypeId);
            
            return listEntities.ToMenuByClientDto();
        }

        public async Task<MenuDto> GetMenuByIdAsync(string menuId)
        {
            if (string.IsNullOrEmpty(menuId))
            {
                return default;
            }

            var entity = await menuRepository.GetMenuByIdAsync(new Guid(menuId));

            if (entity == null)
            {
                return default;
            }

            return entity.ToDto();
        }
        public async Task<MenuDto> GetMenuByRouteAsync(string route)
        {
            if (string.IsNullOrEmpty(route))
            {
                return default;
            }

            var entity = await menuRepository.GetMenuByRouteAsync(route);

            if (entity == null)
            {
                return default;
            }

            return entity.ToDto();
        }

        public async Task<IPagedList<MenuDto>> GetPagedMenuAsync(string keyword, int pageNumber, int pageSize)
        {
            var listEntity = await menuRepository.GetPagedMenuAsync(keyword, pageNumber, pageSize);
            return listEntity.ToDto();
        }
    }
}
