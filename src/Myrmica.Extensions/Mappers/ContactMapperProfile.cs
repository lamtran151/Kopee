using AutoMapper;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;
using System;

namespace Myrmica.Extensions.Mappers
{
    public class ContactMapperProfile : Profile
    {
        public ContactMapperProfile()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
            CreateMap<CONTACT, ContactDto>(MemberList.Destination)
                .ForMember(dto => dto.clientId, opt => opt.MapFrom(e => e.CLIENT_ID.ToString()))
                .ForMember(dto => dto.id, opt => opt.MapFrom(e => e.ID.ToString()));
            CreateMap<ContactDto, CONTACT>(MemberList.Destination)
                .ForMember(e => e.CLIENT_ID, opt => opt.MapFrom(dto => new Guid(dto.clientId)))
                .ForMember(e => e.ID, opt => opt.MapFrom(dto => string.IsNullOrEmpty(dto.id) ? new Guid() : new Guid(dto.id)));
            CreateMap<IPagedList<CONTACT>, IPagedList<ContactDto>>(MemberList.Destination).ReverseMap();
        }
    }
}
