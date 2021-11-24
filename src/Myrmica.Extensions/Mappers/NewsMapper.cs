using AutoMapper;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product.News;
using System.Collections.Generic;

namespace Myrmica.Extensions.Mappers
{
    public static class NewsMapper
    {
        internal static IMapper Mapper;

        static NewsMapper()
        {
            Mapper = new MapperConfiguration(config => config.AddProfile<NewsMapperProfile>()).CreateMapper();
        }

        //public static List<Activity> ToModel(this List<APP_ACTIVITY> _APP_ACTIVITY)
        //{
        //    return Mapper.Map<List<Activity>>(_APP_ACTIVITY);
        //}

        //public static Activity ToModel(this APP_ACTIVITY _APP_ACTIVITY)
        //{
        //    return Mapper.Map<Activity>(_APP_ACTIVITY);
        //}

        public static NEWS ToEntity(this NewsDto newsDto)
        {
            return Mapper.Map<NEWS>(newsDto);
        }

        public static NewsDto ToDto(this NEWS news)
        {
            return Mapper.Map<NewsDto>(news);
        }

        public static List<NewsDto> ToDto(this List<NEWS> news)
        {
            return Mapper.Map<List<NewsDto>>(news);
        }

        public static IPagedList<NewsDto> ToDto(this IPagedList<NEWS> news)
        {
            return Mapper.Map<IPagedList<NewsDto>>(news);
        }
    }
}
