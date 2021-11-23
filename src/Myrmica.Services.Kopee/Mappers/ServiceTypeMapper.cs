using AutoMapper;
using Myrmica.Extensions.Dtos.Product;
using Myrmica.Extensions.Product.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Services.Kopee.Mappers
{
    public static class ServiceTypeMapper
    {
        internal static IMapper mapper;
        static ServiceTypeMapper()
        {
            mapper = new MapperConfiguration(config => config.AddProfile<ServiceTypeMapperProfile>()).CreateMapper();
        }

        public static ServiceTypeDto ToDto(this CreateServiceTypeParams pr)
        {
            return mapper.Map<ServiceTypeDto>(pr);
        }

        public static ServiceTypeDto ToDto(this EditServiceTypeParams pr)
        {
            return mapper.Map<ServiceTypeDto>(pr);
        }
    }
}
