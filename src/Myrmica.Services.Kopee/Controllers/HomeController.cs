using Microsoft.AspNetCore.Mvc;
using Myrmica.Data;
using Myrmica.Entity;
using System.Linq;

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
            var a = _repository.Table.ToList();
            return Ok(a);
        }
    }
}
