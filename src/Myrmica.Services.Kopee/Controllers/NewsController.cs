using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Myrmica.Extensions.Product.Parameters;
using Myrmica.Extensions.Product.Parameters.News;
using Myrmica.Service.Interfaces;
using Myrmica.Services.Kopee.Mappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Myrmica.Services.Kopee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : Controller
    {

        private readonly ILogger<NewsController> _logger;
        private readonly INewsService _newsService;

        public NewsController(ILogger<NewsController> logger, INewsService newsService)
        {
            _logger = logger;
            _newsService = newsService;
        }

        [Route("healthcheck")]
        [HttpGet]
        public string HealthCheck()
        {
            return "Ok";
        }

        [Route("add-news")]
        [HttpPost]
        public async Task<string> AddNews([FromForm] CreateNewsParams pr)
        {
            var dto = pr.ToDto();
            return await _newsService.AddNewsAsync(dto, pr.bannerImage, pr.bannerSpecialImage);
        }

        [Route("edit-news")]
        [HttpPost]
        public async Task<bool> EditNews([FromForm] EditNewsParams pr)
        {
            var dto = pr.ToDto();
            return await _newsService.EditNewsAsync(dto, pr.bannerImage, pr.bannerSpecialImage);
        }

        [Route("delete-news")]
        [HttpPost]
        public async Task<bool> DeleteNews(string newsId)
        {
            return await _newsService.DeleteNewsAsync(newsId);
        }

        [Route("get-news-by-id")]
        [HttpPost]
        public async Task<object> GetNewsById(string newsId)
        {
            return await _newsService.GetNewsByIdAsync(newsId);
        }

        [Route("get-news-by-route")]
        [HttpPost]
        public async Task<object> GetNewsByRoute(NewsByRoute pr)
        {
            return await _newsService.GetNewsByRouteAsync(pr.route, pr.clientId);
        }

        [Route("get-paged-news")]
        [HttpPost]
        public async Task<object> GetPagedNews(PagedParams pr)
        {
            var lst = await _newsService.GetPagedNewsAsync(pr.keyword, pr.pageNumber, pr.pageSize);
            return lst;
        }

        [Route("get-top-news-by-category")]
        [HttpPost]
        public async Task<object> GetTopNewsByCategory(List<TopNewsParams> pr)
        {
            var dto = pr.ToDto();
            var lst = await _newsService.GetTopNewsByCategoryAsync(dto);
            return lst;
        }

        [Route("get-paged-news-by-route")]
        [HttpPost]
        public async Task<object> GetPagedNewsByCategoryRoute(PagedNewsByCategoryParams pr)
        {
            var lst = await _newsService.GetPagedNewsByCategoryRouteAsync(pr.categoryRoute, pr.pageNumber, pr.pageSize);
            return lst;
        }
    }
}
