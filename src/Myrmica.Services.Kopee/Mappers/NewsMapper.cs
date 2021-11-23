using AutoMapper;
using Myrmica.Extensions.Dtos.Product.News;
using Myrmica.Extensions.Product.Parameters.News;
using System.Collections.Generic;

namespace Myrmica.Services.Kopee.Mappers
{
    public static class NewsMapper
    {
        internal static IMapper mapper;
        static NewsMapper()
        {
            mapper = new MapperConfiguration(config => config.AddProfile<NewsMapperProfile>()).CreateMapper();
        }

        public static NewsDto ToDto(this CreateNewsParams pr)
        {
            return mapper.Map<NewsDto>(pr);
        }

        public static NewsDto ToDto(this EditNewsParams pr)
        {
            return mapper.Map<NewsDto>(pr);
        }

        public static TopNewsParamsDto ToDto(this TopNewsParams pr)
        {
            return mapper.Map<TopNewsParamsDto>(pr);
        }

        public static List<TopNewsParamsDto> ToDto(this List<TopNewsParams> pr)
        {
            return mapper.Map<List<TopNewsParamsDto>>(pr);
        }
    }
}
