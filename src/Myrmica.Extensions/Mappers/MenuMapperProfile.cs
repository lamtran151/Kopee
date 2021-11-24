using AutoMapper;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product.MenuDtos;
using System;

namespace Myrmica.Extensions.Mappers
{
    public class MenuMapperProfile : Profile
    {
        public MenuMapperProfile()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
            CreateMap<MENU, MenuDto>(MemberList.Destination)
                .ForMember(dto => dto.id, opt => opt.MapFrom(e => e.ID.ToString()))
                .ForMember(dto => dto.parentId, opt => opt.MapFrom(e => e.PARENT_ID.ToString()))
                .ForMember(dto => dto.clientId, opt => opt.MapFrom(e => e.CLIENT_ID.ToString()))
                .ForMember(dto => dto.menuTypeId, opt => opt.MapFrom(e => e.MENU_TYPE_ID));

            CreateMap<MenuDto, MENU>(MemberList.Destination)
                .ForMember(e => e.PARENT_ID, opt => opt.MapFrom(dto => new Guid(dto.parentId)))
                .ForMember(e => e.CLIENT_ID, opt => opt.MapFrom(dto => new Guid(dto.clientId)))
                .ForMember(e => e.MENU_TYPE_ID, opt => opt.MapFrom(dto => dto.menuTypeId))
                .ForMember(e => e.ID, opt => opt.MapFrom(dto => string.IsNullOrEmpty(dto.id) ? default : new Guid(dto.id)));

            CreateMap<MENU, MenuByClientDto>(MemberList.Destination)
                .ForMember(e => e.childMenu, opt => opt.MapFrom(e => e.CHILD_MENU));
            CreateMap<IPagedList<MENU>, IPagedList<MenuDto>>(MemberList.Destination);
        }
    }
}
