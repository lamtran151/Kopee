using Microsoft.AspNetCore.Http;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product.News;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Myrmica.Service.Interfaces
{
    public interface INewsService
    {
        public Task<string> AddNewsAsync(NewsDto news, IFormFile bannerImage, IFormFile bannerSpecialImage);
        public Task<bool> EditNewsAsync(NewsDto dto, IFormFile bannerImage, IFormFile bannerSpecialImage);
        public Task<NewsDto> GetNewsByIdAsync(string newsId);
        public Task<NewsDto> GetNewsByRouteAsync(string route, string clientId);
        public Task<IPagedList<NewsDto>> GetPagedNewsAsync(string keyword, int pageNumber, int pageSize);
        public Task<List<ListTopNewsDto>> GetTopNewsByCategoryAsync(List<TopNewsParamsDto> paramsDtos);
        public Task<IPagedList<NewsDto>> GetPagedNewsByCategoryRouteAsync(string categoryRoute, int pageNumber, int pageSize);
        public Task<bool> DeleteNewsAsync(string newsId);
    }
}
