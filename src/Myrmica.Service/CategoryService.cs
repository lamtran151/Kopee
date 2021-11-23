using Microsoft.AspNetCore.Http;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;
using Myrmica.Extensions.Helpers.FileHelpers;
using Myrmica.Extensions.Mappers;
using Myrmica.Repository.Interfaces;
using Myrmica.Service.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Myrmica.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly HttpClient httpClient;

        public CategoryService(ICategoryRepository categoryRepository, HttpClient _httpClient)
        {
            _categoryRepository = categoryRepository;
            httpClient = _httpClient;
        }

        public async Task<string> AddCategoryAsync(CategoryDto category, IFormFile bannerImage)
        {
            var categoryId = string.Empty;
            var isProceed = true;

            //Xử lý ảnh banner
            if (bannerImage != null)
            {
                category.bannerId = await bannerImage.HandleFile(httpClient);
                isProceed = !string.IsNullOrEmpty(category.bannerId);
            }

            if (isProceed)
            {
                var categoryEntity = category.ToEntity();
                categoryId = await _categoryRepository.CreateCategoryAsync(categoryEntity);
            }
            return categoryId;
        }

        public async Task<bool> DeleteCategoryAsync(string categoryId)
        {
            if (string.IsNullOrEmpty(categoryId))
            {
                return false;
            }

            return await _categoryRepository.DeleteCategoryAsync(new Guid(categoryId));
        }

        public async Task<bool> EditCategoryAsync(CategoryDto category, IFormFile bannerImage)
        {
            var result = true;
            var isProceed = true;

            //Xử lý ảnh banner
            if (bannerImage != null)
            {
                category.bannerId = await bannerImage.HandleFile(httpClient);
                isProceed = !string.IsNullOrEmpty(category.bannerId);
            }

            if (isProceed)
            {
                var categoryEntity = category.ToEntity();
                result = await _categoryRepository.EditCategoryAsync(categoryEntity);
            }

            return result;
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(string categoryId)
        {
            if (string.IsNullOrEmpty(categoryId))
            {
                return default;
            }

            var entity = await _categoryRepository.GetCategoryByIdAsync(new Guid(categoryId));

            if (entity == null)
            {
                return default;
            }

            return entity.ToDto();
        }
        public async Task<CategoryDto> GetCategoryByRouteAsync(string route)
        {
            if (string.IsNullOrEmpty(route))
            {
                return default;
            }

            var entity = await _categoryRepository.GetCategoryByRouteAsync(route);

            if (entity == null)
            {
                return default;
            }

            return entity.ToDto();
        }
        public async Task<List<CategoryDto>> GetCategoryByServiceType(string serviceTypeId)
        {
            if (string.IsNullOrEmpty(serviceTypeId))
            {
                return default;
            }

            var entity = await _categoryRepository.GetCategoryByServiceType(serviceTypeId);

            if (entity == null)
            {
                return default;
            }

            return entity.ToListDto();
        }

        public async Task<IPagedList<CategoryDto>> GetPagedCategoriesAsync(string keyword, int pageNumber, int pageSize)
        {
            var listEntity = await _categoryRepository.GetPagedCategoriesAsync(keyword, pageNumber, pageSize);
            listEntity.Data = listEntity.Data.ToListDto();
            return listEntity.ToDto();
        }
    }
}
