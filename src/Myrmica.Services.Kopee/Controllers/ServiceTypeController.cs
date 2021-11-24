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
    public class ServiceTypeController : Controller
    {

        private readonly ILogger<ServiceTypeController> _logger;
        private readonly IServiceTypeService _serviceTypeService;

        public ServiceTypeController(ILogger<ServiceTypeController> logger, IServiceTypeService serviceTypeService)
        {
            _logger = logger;
            _serviceTypeService = serviceTypeService;
        }

        [Route("healthcheck")]
        [HttpGet]
        public string HealthCheck()
        {
            return "Ok";
        }

        [Route("add-serviceType")]
        [HttpPost]
        public async Task<string> AddServiceType([FromForm] CreateServiceTypeParams pr)
        {
            var dto = pr.ToDto();
            return await _serviceTypeService.AddServiceTypeAsync(dto);
        }

        [Route("get-serviceType-by-id")]
        [HttpPost]
        public async Task<object> GetServiceTypeById(string serviceTypeId)
        {
            return await _serviceTypeService.GetServiceTypeByIdAsync(serviceTypeId);
        }

        [Route("get-paged-serviceType")]
        [HttpPost]
        public async Task<object> GetPagedServiceType(PagedParams pr)
        {
            var lst = await _serviceTypeService.GetPagedServiceTypeAsync(pr.keyword, pr.pageNumber, pr.pageSize);
            return lst;
        }

        [Route("edit-serviceType")]
        [HttpPost]
        public async Task<bool> EditServiceType([FromForm] EditServiceTypeParams pr)
        {
            var dto = pr.ToDto();
            return await _serviceTypeService.EditServiceTypeAsync(dto);
        }

        [Route("delete-serviceType")]
        [HttpPost]
        public async Task<bool> DeleteServiceType(string serviceTypeId)
        {
            return await _serviceTypeService.DeleteServiceTypeAsync(serviceTypeId);
        }
    }
}
