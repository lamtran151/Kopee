using Microsoft.AspNetCore.Cors;
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
    public class MenuController : Controller
    {

        private readonly ILogger<MenuController> _logger;
        private readonly IMenuService _menuService;

        public MenuController(ILogger<MenuController> logger, IMenuService menuService)
        {
            _logger = logger;
            _menuService = menuService;
        }

        [Route("healthcheck")]
        [EnableCors("MyrmicaCors")]
        [HttpGet]
        public string HealthCheck()
        {
            return "Ok";
        }

        [Route("add-menu")]
        [EnableCors("MyrmicaCors")]
        [HttpPost]
        public async Task<string> AddMenu([FromForm] CreateMenuParams pr)
        {
            var dto = pr.ToDto();
            return await _menuService.AddMenuAsync(dto);
        }

        [Route("get-menu-by-id")]
        [EnableCors("MyrmicaCors")]
        [HttpPost]
        public async Task<object> GetMenuById(string menuId)
        {
            return await _menuService.GetMenuByIdAsync(menuId);
        }

        [Route("get-paged-menu")]
        [EnableCors("MyrmicaCors")]
        [HttpPost]
        public async Task<object> GetPagedMenu(PagedParams pr)
        {
            var lst = await _menuService.GetPagedMenuAsync(pr.keyword, pr.pageNumber, pr.pageSize);
            return lst;
        }

        [Route("get-menu-by-client")]
        [EnableCors("MyrmicaCors")]
        [HttpPost]
        public async Task<object> GetMenuByClient(MenuByClientParams pr)
        {
            var lst = await _menuService.GetMenuByClientAsync(pr.clientId, pr.menuTypeId);
            return lst;
        }

        [Route("edit-menu")]
        [EnableCors("MyrmicaCors")]
        [HttpPost]
        public async Task<bool> EditMenu([FromForm] EditMenuParams pr)
        {
            var dto = pr.ToDto();
            return await _menuService.EditMenuAsync(dto);
        }

        [Route("delete-menu")]
        [EnableCors("MyrmicaCors")]
        [HttpPost]
        public async Task<bool> DeleteMenu(string menuId)
        {
            return await _menuService.DeleteMenuAsync(menuId);
        }
    }
}
