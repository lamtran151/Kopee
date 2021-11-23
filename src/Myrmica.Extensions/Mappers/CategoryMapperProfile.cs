using AutoMapper;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;
using System;

namespace Myrmica.Extensions.Mappers
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            CreateMap<CATEGORY, CategoryDto>(MemberList.Destination)
                .ForMember(dto => dto.bannerId, opt => opt.MapFrom(e => e.BANNER_ID.ToString()))
                .ForMember(dto => dto.clientId, opt => opt.MapFrom(e => e.CLIENT_ID.ToString()))
                .ForMember(dto => dto.parentId, opt => opt.MapFrom(e => e.CATEGORY_PARENT_ID.ToString()))
                .ForMember(dto => dto.serviceTypeId, opt => opt.MapFrom(e => e.SERVICE_TYPE_ID.ToString()))
                .ForMember(dto => dto.id, opt => opt.MapFrom(e => e.ID.ToString()));

            CreateMap<CategoryDto, CATEGORY>(MemberList.Destination)
                .ForMember(e => e.BANNER_ID, opt => opt.MapFrom(dto => string.IsNullOrEmpty(dto.bannerId) ? default : new Guid(dto.bannerId)))
                .ForMember(e => e.CLIENT_ID, opt => opt.MapFrom(dto => new Guid(dto.clientId)))
                .ForMember(e => e.CATEGORY_PARENT_ID, opt => opt.MapFrom(dto => new Guid(dto.parentId)))
                .ForMember(e => e.SERVICE_TYPE_ID, opt => opt.MapFrom(dto => new Guid(dto.serviceTypeId)))
                .ForMember(e => e.ID, opt => opt.MapFrom(dto => string.IsNullOrEmpty(dto.id) ? new Guid() : new Guid(dto.id)));
            CreateMap<IPagedList<CATEGORY>, IPagedList<CategoryDto>>(MemberList.Destination).ReverseMap();
        }
    }
}
