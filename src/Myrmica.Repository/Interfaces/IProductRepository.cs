using Myrmica.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Myrmica.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<string> CreateProductAsync(PRODUCT product);
        Task<bool> DeleteProductAsync(Guid id);
        Task<bool> EditProductAsync(PRODUCT product);
        Task<PRODUCT> GetProductByIdAsync(Guid id);
        Task<PRODUCT> GetProductByRouteAsync(string route);
        Task<IPagedList<PRODUCT>> GetPagedProductAsync(string keyword, int pageNumber, int pageSize);
        Task<IPagedList<PRODUCT>> GetPagedProductByCategoryAsync(string categoryId, int pageNumber, int pageSize);
        Task<List<PRODUCT>> GetNewProductsAsync(string clientId, int sizeLimit);
        Task<List<PRODUCT>> GetCategorizedProductsAsync(string clientId, Guid categoryId, int sizeLimit);
    }
}
