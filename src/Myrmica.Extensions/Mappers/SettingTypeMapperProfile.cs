using AutoMapper;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;
using System;

namespace Myrmica.Extensions.Mappers
{
    public class SettingTypeMapperProfile : Profile
    {
        public SettingTypeMapperProfile()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
            CreateMap<SETTING_TYPE, SettingTypeDto>(MemberList.Destination)
                .ForMember(dto => dto.id, opt => opt.MapFrom(e => e.ID.ToString()));
            CreateMap<SettingTypeDto, SETTING_TYPE>(MemberList.Destination)
                .ForMember(e => e.ID, opt => opt.MapFrom(dto => string.IsNullOrEmpty(dto.id) ? new Guid() : new Guid(dto.id)));
            CreateMap<IPagedList<SETTING_TYPE>, IPagedList<SettingTypeDto>>(MemberList.Destination).ReverseMap();
        }
    }
}
