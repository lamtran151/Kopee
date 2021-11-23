using Microsoft.AspNetCore.Http;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Myrmica.Service.Interface
{
    public interface ICategoryService
    {
        public Task<string> AddCategoryAsync(CategoryDto category, IFormFile bannerImage);
        public Task<CategoryDto> GetCategoryByIdAsync(string categoryId);
        public Task<CategoryDto> GetCategoryByRouteAsync(string categoryId);
        public Task<List<CategoryDto>> GetCategoryByServiceType(string serviceTypeId);
        public Task<IPagedList<CategoryDto>> GetPagedCategoriesAsync(string keyword, int pageNumber, int pageSize);
        public Task<bool> EditCategoryAsync(CategoryDto dto, IFormFile bannerImage);
        public Task<bool> DeleteCategoryAsync(string categoryId);
    }
}
