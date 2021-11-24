using AutoMapper;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product.News;
using System;

namespace Myrmica.Extensions.Mappers
{
    public class NewsMapperProfile : Profile
    {
        public NewsMapperProfile()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            CreateMap<NEWS, NewsDto>(MemberList.Destination)
                .ForMember(dto => dto.bannerId, opt => opt.MapFrom(e => e.BANNER_ID.ToString()))
                .ForMember(dto => dto.bannerSpecialId, opt => opt.MapFrom(e => e.BANNER_SPECIAL_ID.ToString()))
                .ForMember(dto => dto.categoryId, opt => opt.MapFrom(e => e.CATEGORY_ID.ToString()))
                .ForMember(dto => dto.shortDescription, opt => opt.MapFrom(e => e.SHORT_DESCRIPTION.ToString()))
                .ForMember(dto => dto.fullDescription, opt => opt.MapFrom(e => e.FULL_DESCRIPTION.ToString()))
                .ForMember(dto => dto.isSpecial, opt => opt.MapFrom(e => e.IS_SPECIAL))
                .ForMember(dto => dto.categoryTitle, opt => opt.MapFrom(e => e.CATEGORY != null ? e.CATEGORY.NAME : string.Empty))
                .ForMember(dto => dto.id, opt => opt.MapFrom(e => e.ID.ToString()));

            CreateMap<NewsDto, NEWS>(MemberList.Destination)
                .ForMember(e => e.BANNER_ID, opt => opt.MapFrom(dto => string.IsNullOrEmpty(dto.bannerId) ? default : new Guid(dto.bannerId)))
                .ForMember(e => e.BANNER_SPECIAL_ID, opt => opt.MapFrom(dto => string.IsNullOrEmpty(dto.bannerSpecialId) ? default : new Guid(dto.bannerSpecialId)))
                .ForMember(e => e.CATEGORY_ID, opt => opt.MapFrom(dto => new Guid(dto.categoryId)))
                .ForMember(e => e.SHORT_DESCRIPTION, opt => opt.MapFrom(dto => dto.shortDescription))
                .ForMember(e => e.IS_SPECIAL, opt => opt.MapFrom(dto => dto.isSpecial))
                .ForMember(e => e.FULL_DESCRIPTION, opt => opt.MapFrom(dto => dto.fullDescription))
                .ForMember(e => e.ID, opt => opt.MapFrom(dto => string.IsNullOrEmpty(dto.id) ? default : new Guid(dto.id)));

            CreateMap<IPagedList<NEWS>, IPagedList<NewsDto>>(MemberList.Destination).ReverseMap();
        }
    }
}
