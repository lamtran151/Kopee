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
    public class ProductRepository : IProductRepository
    {
        protected readonly IRepository<PRODUCT> _repo;

        public ProductRepository(IRepository<PRODUCT> repo)
        {
            _repo = repo;
        }

        public async Task<string> CreateProductAsync(PRODUCT product)
        {
            await _repo.AddAsync(product);
            return product.ID.ToString();
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var result = false;
            var product_old = await _repo.FindAsync(id);

            if (product_old != null)
            {
                product_old.IS_DELETED = true;
                product_old.DELETED_DATE = DateTime.Now;

                await _repo.DeleteAsync(product_old);
                result = true;
            }

            return result;
        }

        public async Task<bool> EditProductAsync(PRODUCT product)
        {
            var result = false;
            var product_old = await _repo.FindAsync(product.ID);

            if (product_old != null)
            {
                product_old.NAME = product.NAME;
                product_old.ROUTE = product.ROUTE;
                product_old.IS_ACTIVE = product.IS_ACTIVE;
                product_old.UPDATED_DATE = DateTime.Now;
                product_old.PRICE = product.PRICE;
                product_old.SHORT_DESCRIPTION = product.SHORT_DESCRIPTION;
                product_old.FULL_DESCRIPTION = product.FULL_DESCRIPTION;
                product_old.CONTENT = product.CONTENT;
                product_old.IS_HOT = product.IS_HOT;
                product_old.IS_NEW = product.IS_NEW;
                product_old.IS_SPECIAL = product.IS_SPECIAL;
                product_old.IS_DISCOUNT = product.IS_DISCOUNT;
                if (!string.IsNullOrEmpty(product.SLIDE_IMAGE_IDS))
                {
                    product_old.SLIDE_IMAGE_IDS = product.SLIDE_IMAGE_IDS;
                }
                if (product.THUMBNAIL_ID != null)
                {
                    product_old.THUMBNAIL_ID = product.THUMBNAIL_ID;
                }
                if (product.BANNER_ID != null)
                {
                    product_old.BANNER_ID = product.BANNER_ID;
                }
                product_old.CATEGORY_ID = product.CATEGORY_ID;
                await _repo.UpdateAsync(product);
                result = true;
            }

            return result;
        }

        public async Task<PRODUCT> GetProductByIdAsync(Guid id)
        {
            return await _repo.Table.Where(c => c.ID.ToString() == id.ToString()
                                                   && !c.IS_DELETED
                                                   && c.IS_ACTIVE)
                                           .FirstOrDefaultAsync();
        }

        public async Task<PRODUCT> GetProductByRouteAsync(string route)
        {
            return await _repo.Table.Where(c => c.ROUTE == route
                                                   && !c.IS_DELETED
                                                   && c.IS_ACTIVE)
                                           .FirstOrDefaultAsync();
        }

        public async Task<List<PRODUCT>> GetNewProductsAsync(string clientId, int sizeLimit)
        {
            return await _repo.TableNoTracking.Where(c => c.CATEGORY.CLIENT_ID == new Guid(clientId)
                                                   && !c.IS_DELETED
                                                   && c.IS_ACTIVE)
                                          .OrderByDescending(c => c.CREATED_DATE)
                                          .Take(sizeLimit)
                                          .ToListAsync();
        }

        /// <summary>
        /// Lấy các product theo category
        /// </summary>
        /// <param name="categoryIds"></param>
        /// <param name="sizeLimit"></param>
        /// <returns></returns>
        public async Task<List<PRODUCT>> GetCategorizedProductsAsync(string clientId, Guid categoryId, int sizeLimit)
        {
            return await _repo.Table.Where(c => c.CATEGORY_ID != null
                                                   && c.CATEGORY_ID == categoryId
                                                   && c.CATEGORY.CLIENT_ID == new Guid(clientId)
                                                   && !c.IS_DELETED
                                                   && c.IS_ACTIVE)
                                          .Include(c => c.CATEGORY)
                                          .OrderByDescending(c => c.CREATED_DATE)
                                          .Take(sizeLimit)
                                          .ToListAsync();
        }

        public async Task<IPagedList<PRODUCT>> GetPagedProductAsync(string keyword, int pageNumber, int pageSize)
        {
            var auditLogs = await _repo.Table
                .Where(x => !x.IS_DELETED && x.IS_ACTIVE && x.NAME.Contains(keyword))
                .ToListAsync();

            return new PagedList<PRODUCT>(auditLogs, pageNumber, pageSize);
        }
        public async Task<IPagedList<PRODUCT>> GetPagedProductByCategoryAsync(string categoryId, int pageNumber, int pageSize)
        {
            var auditLogs = await _repo.Table
                .Where(x => x.CATEGORY_ID == new Guid(categoryId) && !x.IS_DELETED && x.IS_ACTIVE)
                .ToListAsync();

            return new PagedList<PRODUCT>(auditLogs, pageNumber, pageSize);
        }
    }
}
