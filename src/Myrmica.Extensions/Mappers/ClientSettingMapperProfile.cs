using AutoMapper;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;
using System;

namespace Myrmica.Extensions.Mappers
{
    public class ClientSettingMapperProfile : Profile
    {
        public ClientSettingMapperProfile()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
            CreateMap<CLIENT_SETTINGS, ClientSettingDto>(MemberList.Destination)
                .ForMember(dto => dto.id, opt => opt.MapFrom(e => e.ID.ToString()))
                .ForMember(dto => dto.settingTypeId, opt => opt.MapFrom(e => e.SETTING_TYPE_ID.ToString()))
                .ForMember(dto => dto.clientId, opt => opt.MapFrom(e => e.CLIENT_ID));
            CreateMap<ClientSettingDto, CLIENT_SETTINGS>(MemberList.Destination)
                .ForMember(e => e.SETTING_TYPE_ID, opt => opt.MapFrom(dto => new Guid(dto.settingTypeId)))
                .ForMember(e => e.CLIENT_ID, opt => opt.MapFrom(dto => new Guid(dto.clientId)))
                .ForMember(e => e.ID, opt => opt.MapFrom(dto => string.IsNullOrEmpty(dto.id) ? default : new Guid(dto.id)));
            CreateMap<PagedList<CLIENT_SETTINGS>, PagedList<ClientSettingDto>>(MemberList.Destination).ReverseMap();
        }
    }
}
