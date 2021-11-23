using AutoMapper;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;
using System;

namespace Myrmica.Extensions.Mappers
{
    public class ClientMapperProfile : Profile
    {
        public ClientMapperProfile()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
            CreateMap<CLIENT, ClientDto>(MemberList.Destination)
                .ForMember(dto => dto.id, opt => opt.MapFrom(e => e.ID.ToString()));
            CreateMap<ClientDto, CLIENT>(MemberList.Destination)
                .ForMember(e => e.ID, opt => opt.MapFrom(dto => string.IsNullOrEmpty(dto.id) ? new Guid() : new Guid(dto.id)));
            CreateMap<PagedList<CLIENT>, PagedList<ClientDto>>(MemberList.Destination).ReverseMap();
        }
    }
}
