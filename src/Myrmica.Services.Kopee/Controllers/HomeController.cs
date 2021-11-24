using Microsoft.AspNetCore.Mvc;
using Myrmica.Data;
using Myrmica.Entity;
using Myrmica.Extensions.Product.Parameters;
using Myrmica.Repository.Interfaces;
using Myrmica.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Myrmica.Services.Kopee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IRepository<Demo> _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryService _categoryService;
        public HomeController(IRepository<Demo> repository, ICategoryRepository categoryRepository, ICategoryService categoryService)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var a = await _categoryRepository.GetPagedCategoriesAsync("a", 0, 10);
                return Ok(a);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        [Route("get-paged-category")]
        [HttpPost]
        public async Task<object> GetPagedCategory(PagedParams pr)
        {
            var lst = await _categoryService.GetPagedCategoriesAsync(pr.keyword, pr.pageNumber, pr.pageSize);
            return lst;
        }
    }
}
