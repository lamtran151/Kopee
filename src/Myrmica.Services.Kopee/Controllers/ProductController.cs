using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Myrmica.Extensions.Product.Parameters;
using Myrmica.Extensions.Product.Parameters.Product;
using Myrmica.Service.Interfaces;
using Myrmica.Services.Kopee.Mappers;
using System.Threading.Tasks;

namespace Myrmica.Services.Kopee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [Route("healthcheck")]
        [HttpGet]
        public string HealthCheck()
        {
            return "Ok";
        }

        [Route("add-product")]
        [HttpPost]
        public async Task<object> AddProduct([FromForm] CreateProductParams pr)
        {
            var dto = pr.ToDto();
            return await _productService.AddProductAsync(dto, pr.bannerImage, pr.slideImages, pr.categoryImage);
        }

        [Route("edit-product")]
        [HttpPost]
        public async Task<object> EditProduct([FromForm] EditProductParams pr)
        {
            var dto = pr.ToDto();
            return await _productService.EditProductAsync(dto, pr.bannerImage, pr.slideImages, pr.categoryImage);
        }

        [Route("delete-product")]
        [HttpPost]
        public async Task<bool> DeleteProduct(string productId)
        {
            return await _productService.DeleteProductAsync(productId);
        }

        [Route("get-product-by-id")]
        [HttpPost]
        public async Task<object> GetProductById(string productId)
        {
            return await _productService.GetProductByIdAsync(productId);
        }

        [Route("get-product-by-route")]
        [HttpPost]
        public async Task<object> GetProductByRoute(string route)
        {
            return await _productService.GetProductByRouteAsync(route);
        }

        [Route("get-paged-product")]
        [HttpPost]
        public async Task<object> GetPagedProduct(PagedParams pr)
        {
            var lst = await _productService.GetPagedProductAsync(pr.keyword, pr.pageNumber, pr.pageSize);
            return lst;
        }
        [Route("get-paged-product-by-category")]
        [HttpPost]
        public async Task<object> GetPagedProductByCategory(PagedParams pr)
        {
            var lst = await _productService.GetPagedProductByCategoryAsync(pr.keyword, pr.pageNumber, pr.pageSize);
            return lst;
        }

        [Route("get-new-products")]
        [HttpPost]
        public async Task<object> GetNewProducts(NewProductParams pr)
        {
            var lst = await _productService.GetNewProductsAsync(pr.clientId, pr.sizeLimit);
            return lst;
        }

        [Route("get-categorized-products")]
        [HttpPost]
        public async Task<object> GetCategorizedProducts(CategorizedProductParams pr)
        {
            var lst = await _productService.GetCategorizedProductsAsync(pr.clientId, pr.categoryIds, pr.sizeLimit);
            return lst;
        }
    }
}
