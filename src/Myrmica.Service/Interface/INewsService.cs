using Microsoft.AspNetCore.Http;
using Myrmica.Solution.Business.Dtos.File;
using Myrmica.Solution.Business.Dtos.Product.News;
using Myrmica.Solution.EntityFramework.Extensions.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Myrmica.Solution.Business.Services.Interface
{
    public interface INewsService
    {
        public Task<string> AddNewsAsync(NewsDto news, IFormFile bannerImage, IFormFile bannerSpecialImage);
        public Task<bool> EditNewsAsync(NewsDto dto, IFormFile bannerImage, IFormFile bannerSpecialImage);
        public Task<NewsDto> GetNewsByIdAsync(string newsId);
        public Task<NewsDto> GetNewsByRouteAsync(string route, string clientId);
        public Task<PagedList<NewsDto>> GetPagedNewsAsync(string keyword, int pageNumber, int pageSize);
        public Task<List<ListTopNewsDto>> GetTopNewsByCategoryAsync(List<TopNewsParamsDto> paramsDtos);
        public Task<PagedList<NewsDto>> GetPagedNewsByCategoryRouteAsync(string categoryRoute, int pageNumber, int pageSize);
        public Task<bool> DeleteNewsAsync(string newsId);
    }
}
