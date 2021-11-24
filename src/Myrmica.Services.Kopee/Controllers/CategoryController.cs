using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Myrmica.Extensions.Product.Parameters;
using Myrmica.Service.Interfaces;
using Myrmica.Services.Kopee.Mappers;
using System.Threading.Tasks;

namespace Myrmica.Services.Kopee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {

        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [Route("healthcheck")]
        [HttpGet]
        public string HealthCheck()
        {
            return "Ok";
        }

        [Route("add-category")]
        [HttpPost]
        public async Task<string> AddCategory([FromForm] CreateCategoryParams pr)
        {
            var dto = pr.ToDto();
            return await _categoryService.AddCategoryAsync(dto, pr.bannerImage);
        }

        [Route("get-category-by-id")]
        [HttpPost]
        public async Task<object> GetCategoryById(string categoryId)
        {
            return await _categoryService.GetCategoryByIdAsync(categoryId);
        }

        [Route("get-category-by-route")]
        [HttpPost]
        public async Task<object> GetCategoryByRoute(string route)
        {
            return await _categoryService.GetCategoryByRouteAsync(route);
        }

        [Route("get-paged-category")]
        [HttpPost]
        public async Task<object> GetPagedCategory(PagedParams pr)
        {
            var lst = await _categoryService.GetPagedCategoriesAsync(pr.keyword, pr.pageNumber, pr.pageSize);
            return lst;
        }

        [Route("edit-category")]
        [HttpPost]
        public async Task<bool> EditCategory([FromForm] EditCategoryParams pr)
        {
            var dto = pr.ToDto();
            return await _categoryService.EditCategoryAsync(dto, pr.bannerImage);
        }

        [Route("delete-category")]
        [HttpPost]
        public async Task<bool> DeleteCategory(string categoryId)
        {
            return await _categoryService.DeleteCategoryAsync(categoryId);
        }
        [Route("list-category-by-servicetype")]
        [HttpPost]
        public async Task<object> GetCategoryByServiceType(string serviceTypeId)
        {
            return await _categoryService.GetCategoryByServiceType(serviceTypeId);
        }
    }
}
