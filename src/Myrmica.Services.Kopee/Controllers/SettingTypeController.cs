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
    public class SettingTypeController : Controller
    {

        private readonly ILogger<SettingTypeController> _logger;
        private readonly ISettingTypeService _settingTypeService;

        public SettingTypeController(ILogger<SettingTypeController> logger, ISettingTypeService settingTypeService)
        {
            _logger = logger;
            _settingTypeService = settingTypeService;
        }

        [Route("healthcheck")]
        [HttpGet]
        public string HealthCheck()
        {
            return "Ok";
        }

        [Route("add-settingType")]
        [HttpPost]
        public async Task<string> AddSettingType([FromForm] CreateSettingTypeParams pr)
        {
            var dto = pr.ToDto();
            return await _settingTypeService.AddSettingTypeAsync(dto);
        }

        [Route("get-settingType-by-id")]
        [HttpPost]
        public async Task<object> GetSettingTypeById(string settingTypeId)
        {
            return await _settingTypeService.GetSettingTypeByIdAsync(settingTypeId);
        }

        [Route("get-paged-settingType")]
        [HttpPost]
        public async Task<object> GetPagedSettingType(PagedParams pr)
        {
            var lst = await _settingTypeService.GetPagedSettingTypeAsync(pr.keyword, pr.pageNumber, pr.pageSize);
            return lst;
        }

        [Route("edit-settingType")]
        [HttpPost]
        public async Task<bool> EditSettingType([FromForm] EditSettingTypeParams pr)
        {
            var dto = pr.ToDto();
            return await _settingTypeService.EditSettingTypeAsync(dto);
        }

        [Route("delete-settingType")]
        [HttpPost]
        public async Task<bool> DeleteSettingType(string settingTypeId)
        {
            return await _settingTypeService.DeleteSettingTypeAsync(settingTypeId);
        }
    }
}
