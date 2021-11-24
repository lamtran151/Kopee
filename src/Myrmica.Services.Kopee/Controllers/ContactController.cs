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
    public class ContactController : Controller
    {

        private readonly ILogger<ContactController> _logger;
        private readonly IContactService _contactService;

        public ContactController(ILogger<ContactController> logger, IContactService contactService)
        {
            _logger = logger;
            _contactService = contactService;
        }

        [Route("healthcheck")]
        [HttpGet]
        public string HealthCheck()
        {
            return "Ok";
        }

        [Route("add-contact")]
        [HttpPost]
        public async  Task<bool> AddContact([FromForm] CreateContactParams pr)
        {
            var dto = pr.ToDto();
            return await _contactService.AddContactAsync(dto);
        }
        [Route("get-paged-contact")]
        [HttpPost]
        public async Task<object> GetPagedCategory(PagedParams pr)
        {
            var lst = await _contactService.GetPagedContactAsync(pr.keyword, pr.pageNumber, pr.pageSize);
            return lst;
        }


    }
}
