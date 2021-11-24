using Microsoft.AspNetCore.Http;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product.News;
using Myrmica.Extensions.Helpers.FileHelpers;
using Myrmica.Extensions.Mappers;
using Myrmica.Repository.Interfaces;
using Myrmica.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Myrmica.Service
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository newsRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly HttpClient httpClient;
        private readonly string[] _permittedExtensions = { ".txt", ".jpeg", ".jpg", ".png", ".tif", ".pdf" };
        private readonly string _targetFilePath;

        public NewsService(INewsRepository _newsRepository, ICategoryRepository _categoryRepository, HttpClient _httpClient)
        {
            newsRepository = _newsRepository;
            categoryRepository = _categoryRepository;
            // To save physical files to a path provided by configuration:
            _targetFilePath = $"{AppContext.BaseDirectory}/file/";
            httpClient = _httpClient;
        }

        public async Task<string> AddNewsAsync(NewsDto news, IFormFile bannerImage, IFormFile bannerSpecialImage)
        {
            //Xử lý ảnh banner
            var newsId = string.Empty;
            var isProcess = true;
            if (bannerImage != null && bannerImage.Length > 0)
            {
                news.bannerId = await bannerImage.HandleFile(httpClient);
                isProcess = !string.IsNullOrEmpty(news.bannerId);
            }

            if (bannerSpecialImage != null && bannerSpecialImage.Length > 0 && isProcess)
            {
                news.bannerSpecialId = await bannerSpecialImage.HandleFile(httpClient);
                isProcess = !string.IsNullOrEmpty(news.bannerId);
            }

            if (isProcess)
            {
                var newsEntity = news.ToEntity();
                newsId = await newsRepository.CreateNewsAsync(newsEntity);
            }
            return newsId;
        }

        public async Task<bool> EditNewsAsync(NewsDto news, IFormFile bannerImage, IFormFile bannerSpecialImage)
        {
            var isProcess = true;
            var result = false;
            if (bannerImage != null && bannerImage.Length > 0)
            {
                news.bannerId = await bannerImage.HandleFile(httpClient);
                isProcess = !string.IsNullOrEmpty(news.bannerId);
            }

            if (bannerSpecialImage != null && bannerSpecialImage.Length > 0 && isProcess)
            {
                news.bannerSpecialId = await bannerSpecialImage.HandleFile(httpClient);
                isProcess = !string.IsNullOrEmpty(news.bannerId);
            }

            if (isProcess)
            {
                var newsEntity = news.ToEntity();
                result = await newsRepository.EditNewsAsync(newsEntity);
            }
            return result;
        }

        public async Task<bool> DeleteNewsAsync(string newsId)
        {
            if (string.IsNullOrEmpty(newsId))
            {
                return false;
            }

            return await newsRepository.DeleteNewsAsync(new Guid(newsId));
        }

        public async Task<NewsDto> GetNewsByIdAsync(string newsId)
        {
            if (string.IsNullOrEmpty(newsId))
            {
                return default;
            }

            var entity = await newsRepository.GetNewsByIdAsync(new Guid(newsId));

            if (entity == null)
            {
                return default;
            }

            return entity.ToDto();
        }
        public async Task<NewsDto> GetNewsByRouteAsync(string route, string clientId)
        {
            if (string.IsNullOrEmpty(route))
            {
                return default;
            }

            var entity = await newsRepository.GetNewsByRouteAsync(route, clientId);

            if (entity == null)
            {
                return default;
            }

            return entity.ToDto();
        }

        public async Task<IPagedList<NewsDto>> GetPagedNewsAsync(string keyword, int pageNumber, int pageSize)
        {
            var listEntity = await newsRepository.GetPagedNewsAsync(keyword, pageNumber, pageSize);
            return listEntity.ToDto();
        }
        public async Task<IPagedList<NewsDto>> GetPagedNewsByCategoryRouteAsync(string categoryRoute, int pageNumber, int pageSize)
        {
            var cate = await categoryRepository.GetCategoryByRouteAsync(categoryRoute);
            if (cate != null)
            {
                var listEntity = await newsRepository.GetPagedNewsByCategoryRouteAsync(cate.ID, pageNumber, pageSize);
                listEntity.CategoryTitle = cate.NAME;
                return listEntity.ToDto();
            }
            return default;
        }

        public async Task<List<ListTopNewsDto>> GetTopNewsByCategoryAsync(List<TopNewsParamsDto> paramsDtos)
        {
            var result = new List<ListTopNewsDto>();
            foreach (var pr in paramsDtos)
            {
                var listEntity = await newsRepository.GetTopNewsByCategoryAsync(pr.categoryId, pr.isGetSpecial, pr.sizeLimit);
                var listNews = new ListTopNewsDto() { categoryId = pr.categoryId };
                //Nếu bản ghi đầu tiên là special
                if (listEntity[0].IS_SPECIAL)
                {
                    listNews.specialNews = listEntity[0].ToDto();
                    listNews.listNews = listEntity.GetRange(1, listEntity.Count - 1).ToDto();
                }
                else
                {
                    listNews.listNews = listEntity.ToDto();
                }

                result.Add(listNews);
            }

            return result;
        }
    }
}
