using AutoMapper;
using Myrmica.Extensions.Dtos.Product;
using Myrmica.Extensions.Product.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Services.Kopee.Mappers
{
    public static class ClientMapper
    {
        internal static IMapper mapper;
        static ClientMapper()
        {
            mapper = new MapperConfiguration(config => config.AddProfile<ClientMapperProfile>()).CreateMapper();
        }

        public static ClientDto ToDto(this CreateClientParams pr)
        {
            return mapper.Map<ClientDto>(pr);
        }

        public static ClientDto ToDto(this EditClientParams pr)
        {
            return mapper.Map<ClientDto>(pr);
        }
    }
}
