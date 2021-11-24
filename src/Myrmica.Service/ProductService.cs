using Microsoft.AspNetCore.Http;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;
using Myrmica.Extensions.Helpers.FileHelpers;
using Myrmica.Extensions.Helpers.StringHelper;
using Myrmica.Extensions.Mappers;
using Myrmica.Repository.Interfaces;
using Myrmica.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Myrmica.Service
{
    public class ProductService : IProductService
    {
        protected readonly IProductRepository productRepository;
        private readonly HttpClient httpClient;

        public ProductService(IProductRepository _productRepository, HttpClient _httpClient)
        {
            productRepository = _productRepository;
            // To save physical files to a path provided by configuration:
            httpClient = _httpClient;
        }

        public async Task<ProductDto> AddProductAsync(ProductDto product, IFormFile bannerImage, IList<IFormFile> slideImages, IFormFile categoryImage)
        {
            string result = string.Empty;
            var isProcess = true;
            #region Xử lý file và lưu file vật lý trước khi chuyển thành entity
            //Xử lý ảnh banner
            if (bannerImage != null && bannerImage.Length > 0)
            {
                product.BannerImageId = await bannerImage.HandleFile(httpClient);
                isProcess = !string.IsNullOrEmpty(product.BannerImageId);
            }

            //Xử lý ảnh SlideImageIds
            if (slideImages != null && slideImages.Count > 0 && isProcess)
            {
                product.SlideImageIds = string.Join(",", await slideImages.HandleFiles(httpClient));
                isProcess = !string.IsNullOrEmpty(product.SlideImageIds);
            }

            //Xử lý ảnh ThumbnailId
            if (categoryImage != null && categoryImage.Length > 0 && isProcess)
            {
                product.ThumbnailId = await categoryImage.HandleFile(httpClient);
                isProcess = !string.IsNullOrEmpty(product.ThumbnailId);
            }
            #endregion


            #region Lưu thông tin của file
            if (isProcess)
            {
                //secure html
                product.Content = WebUtility.HtmlEncode(product.Content);
                //Chuyển sang entity
                var productEntity = product.ToEntity();
                //Xử lý description
                if (product.Description.Length > 200)
                {
                    var arrayShortDes = product.Description.Substring(0, 200).Split(" ");
                    productEntity.SHORT_DESCRIPTION = $"{string.Join(" ", arrayShortDes.Take(arrayShortDes.Length - 1).ToArray())}...";

                }
                else
                {
                    productEntity.SHORT_DESCRIPTION = product.Description;
                }
                productEntity.FULL_DESCRIPTION = product.Description;
                //Xử lý route
                productEntity.ROUTE = string.IsNullOrEmpty(productEntity.ROUTE) ? product.Name.Slugify() : productEntity.ROUTE;
                //Lưu và lấy ID
                product.Id = await productRepository.CreateProductAsync(productEntity);
            }
            #endregion
            return product;
        }

        public async Task<bool> DeleteProductAsync(string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return false;
            }

            return await productRepository.DeleteProductAsync(new Guid(productId));
        }

        public async Task<ProductDto> EditProductAsync(ProductDto product, IFormFile bannerImage, List<IFormFile> slideImages, IFormFile categoryImage)
        {
            bool result = false;
            var isProcess = true;
            #region Xử lý file và lưu file vật lý trước khi chuyển thành entity
            //Xử lý ảnh banner
            if (bannerImage != null && bannerImage.Length > 0)
            {
                product.BannerImageId = await bannerImage.HandleFile(httpClient);
                isProcess = !string.IsNullOrEmpty(product.BannerImageId);
            }

            //Xử lý ảnh SlideImageIds
            if (slideImages != null && slideImages.Count > 0 && isProcess)
            {
                product.SlideImageIds = $"{product.SlideImageIds},{string.Join(",", await slideImages.HandleFiles(httpClient))}";
                isProcess = !string.IsNullOrEmpty(product.SlideImageIds);
            }

            //Xử lý ảnh ThumbnailId
            if (categoryImage != null && categoryImage.Length > 0 && isProcess)
            {
                product.ThumbnailId = await categoryImage.HandleFile(httpClient);
                isProcess = !string.IsNullOrEmpty(product.ThumbnailId);
            }
            #endregion


            #region Lưu thông tin của file
            if (isProcess)
            {
                //secure html
                product.Content = WebUtility.HtmlEncode(product.Content);
                //Chuyển sang entity
                var productEntity = product.ToEntity();
                //Xử lý description
                if (product.Description.Length > 200)
                {
                    var arrayShortDes = product.Description.Substring(0, 200).Split(" ");
                    productEntity.SHORT_DESCRIPTION = $"{string.Join(" ", arrayShortDes.Take(arrayShortDes.Length - 1).ToArray())}...";

                }
                else
                {
                    productEntity.SHORT_DESCRIPTION = product.Description;
                }
                productEntity.FULL_DESCRIPTION = product.Description;
                //Xử lý route
                productEntity.ROUTE = string.IsNullOrEmpty(productEntity.ROUTE) ? product.Name.Slugify() : productEntity.ROUTE;
                //Lưu và lấy ID
                result = await productRepository.EditProductAsync(productEntity);
            }
            #endregion
            return result ? product : default;
        }

        public async Task<ProductDto> GetProductByIdAsync(string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return default;
            }

            var entity = await productRepository.GetProductByIdAsync(new Guid(productId));

            if (entity == null)
            {
                return default;
            }

            return entity.ToDto();
        }

        public async Task<ProductDto> GetProductByRouteAsync(string route)
        {
            if (string.IsNullOrEmpty(route))
            {
                return default;
            }

            var entity = await productRepository.GetProductByRouteAsync(route);

            if (entity == null)
            {
                return default;
            }

            return entity.ToDto();
        }

        public async Task<IPagedList<ProductDto>> GetPagedProductAsync(string keyword, int pageNumber, int pageSize)
        {
            var listEntity = await productRepository.GetPagedProductAsync(keyword, pageNumber, pageSize);
            return listEntity.ToDto();
        }
        public async Task<IPagedList<ProductDto>> GetPagedProductByCategoryAsync(string categoryId, int pageNumber, int pageSize)
        {
            var listEntity = await productRepository.GetPagedProductByCategoryAsync(categoryId, pageNumber, pageSize);
            return listEntity.ToDto();
        }

        public async Task<List<ProductDto>> GetNewProductsAsync(string clientId, int sizeLimit)
        {
            var entity = await productRepository.GetNewProductsAsync(clientId, sizeLimit);
            return entity.ToDto();
        }

        public async Task<List<List<ProductDto>>> GetCategorizedProductsAsync(string clientId, List<string> categoryIds, int sizeLimit)
        {
            var result = new List<List<ProductDto>>();
            foreach (var id in categoryIds)
            {
                var entity = await productRepository.GetCategorizedProductsAsync(clientId, new Guid(id), sizeLimit);
                result.Add(entity.ToDto());
            }
            return result;
        }
    }
}
