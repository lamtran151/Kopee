using Microsoft.AspNetCore.Mvc;
using Myrmica.Data;
using Myrmica.Entity;

namespace Myrmica.Services.Kopee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IRepository<Demo> _repository;
        public HomeController(IRepository<Demo> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var a = _repository.Table;
            return Ok();
        }
    }
}
