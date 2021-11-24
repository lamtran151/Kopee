using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Myrmica.Extensions.Product.Parameters;
using System;
using System.Threading.Tasks;

namespace Myrmica.Services.Kopee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {

        private readonly ILogger<CategoryController> _logger;
        //private readonly ICategoryService _categoryService;

        public UserController(ILogger<CategoryController> logger)
        {
            _logger = logger;
            //_categoryService = categoryService;
        }

        [Route("healthcheck")]
        [HttpGet]
        public string HealthCheck()
        {
            return "Ok";
        }

        [Route("login")]
        [HttpPost]
        public async Task<string> Login([FromForm] LoginParams pr)
        {
            if(pr.username == "test" && pr.password == "test")
            {
                return Guid.NewGuid().ToString();
            }
            else
            {
                return String.Empty;
            }
        }
    }
}
