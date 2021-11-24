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
    public class ClientSettingController : Controller
    {

        private readonly ILogger<ClientSettingController> _logger;
        private readonly IClientSettingService _clientsettingService;

        public ClientSettingController(ILogger<ClientSettingController> logger, IClientSettingService clientsettingService)
        {
            _logger = logger;
            _clientsettingService = clientsettingService;
        }

        [Route("healthcheck")]
        [HttpGet]
        public string HealthCheck()
        {
            return "Ok";
        }

        [Route("add-clientsetting")]
        [HttpPost]
        public async Task<string> AddClientSetting([FromForm] CreateClientSettingParams pr)
        {
            var dto = pr.ToDto();
            return await _clientsettingService.AddClientSettingAsync(dto);
        }

        [Route("get-clientsetting-by-id")]
        [HttpPost]
        public async Task<object> GetClientSettingById(string clientsettingId)
        {
            return await _clientsettingService.GetClientSettingByIdAsync(clientsettingId);
        }

        [Route("get-paged-clientsetting")]
        [HttpPost]
        public async Task<object> GetPagedClientSetting(PagedParams pr)
        {
            var lst = await _clientsettingService.GetPagedClientSettingAsync(pr.keyword, pr.pageNumber, pr.pageSize);
            return lst;
        }

        [Route("edit-clientsetting")]
        [HttpPost]
        public async Task<bool> EditClientSetting([FromForm] EditClientSettingParams pr)
        {
            var dto = pr.ToDto();
            return await _clientsettingService.EditClientSettingAsync(dto);
        }

        [Route("delete-clientsetting")]
        [HttpPost]
        public async Task<bool> DeleteClientSetting(string clientsettingId)
        {
            return await _clientsettingService.DeleteClientSettingAsync(clientsettingId);
        }
    }
}
