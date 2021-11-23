using AutoMapper;
using Myrmica.Extensions.Dtos.Product.News;
using Myrmica.Extensions.Product.Parameters.News;

namespace Myrmica.Services.Kopee.Mappers
{
    public class NewsMapperProfile : Profile
    {
        public NewsMapperProfile()
        {
            CreateMap<CreateNewsParams, NewsDto>();
            CreateMap<EditNewsParams, NewsDto>();
            CreateMap<TopNewsParams, TopNewsParamsDto>();
        }
    }
}
