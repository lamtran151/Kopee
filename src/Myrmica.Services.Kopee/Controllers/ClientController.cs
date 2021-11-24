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
    public class ClientController : Controller
    {

        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _clientService;

        public ClientController(ILogger<ClientController> logger, IClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        [Route("healthcheck")]
        [HttpGet]
        public string HealthCheck()
        {
            return "Ok";
        }

        [Route("add-client")]
        [HttpPost]
        public async Task<string> AddClient([FromForm] CreateClientParams pr)
        {
            var dto = pr.ToDto();
            return await _clientService.AddClientAsync(dto);
        }

        [Route("get-client-by-id")]
        [HttpPost]
        public async Task<object> GetClientById(string clientId)
        {
            return await _clientService.GetClientByIdAsync(clientId);
        }

        [Route("get-paged-client")]
        [HttpPost]
        public async Task<object> GetPagedClient(PagedParams pr)
        {
            var lst = await _clientService.GetPagedClientAsync(pr.keyword, pr.pageNumber, pr.pageSize);
            return lst;
        }

        [Route("edit-client")]
        [HttpPost]
        public async Task<bool> EditClient([FromForm] EditClientParams pr)
        {
            var dto = pr.ToDto();
            return await _clientService.EditClientAsync(dto);
        }

        [Route("delete-client")]
        [HttpPost]
        public async Task<bool> DeleteClient(string clientId)
        {
            return await _clientService.DeleteClientAsync(clientId);
        }
    }
}
