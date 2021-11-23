using Microsoft.AspNetCore.Http;
using Myrmica.Solution.Business.Dtos.File;
using Myrmica.Solution.Business.Dtos.Product;
using Myrmica.Solution.EntityFramework.Extensions.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Myrmica.Solution.Business.Services.Interface
{
    public interface IProductService
    {
        public Task<ProductDto> AddProductAsync(ProductDto product, IFormFile bannerImage, IList<IFormFile> slideImages, IFormFile categoryImage);
        public Task<PagedList<ProductDto>> GetPagedProductAsync(string keyword, int pageNumber, int pageSize);
        public Task<PagedList<ProductDto>> GetPagedProductByCategoryAsync(string categoryId, int pageNumber, int pageSize);
        public Task<ProductDto> EditProductAsync(ProductDto product, IFormFile bannerImage, List<IFormFile> slideImages, IFormFile categoryImage);
        public Task<bool> DeleteProductAsync(string productId);
        public Task<ProductDto> GetProductByIdAsync(string productId);
        public Task<ProductDto> GetProductByRouteAsync(string route);
        public Task<List<ProductDto>> GetNewProductsAsync(string clientId, int sizeLimit);
        public Task<List<List<ProductDto>>> GetCategorizedProductsAsync(string clientId, List<string> categoryIds, int sizeLimit);
    }
}
