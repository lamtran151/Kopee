using AutoMapper;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;
using System;

namespace Myrmica.Extensions.Mappers
{
    public class ServiceTypeMapperProfile : Profile
    {
        public ServiceTypeMapperProfile()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
            CreateMap<SERVICE_TYPE, ServiceTypeDto>(MemberList.Destination)
                .ForMember(dto => dto.id, opt => opt.MapFrom(e => e.ID.ToString()));
            CreateMap<ServiceTypeDto, SERVICE_TYPE>(MemberList.Destination)
                .ForMember(e => e.ID, opt => opt.MapFrom(dto => string.IsNullOrEmpty(dto.id) ? new Guid() : new Guid(dto.id)));
            CreateMap<IPagedList<SERVICE_TYPE>, IPagedList<ServiceTypeDto>>(MemberList.Destination).ReverseMap();
        }
    }
}
