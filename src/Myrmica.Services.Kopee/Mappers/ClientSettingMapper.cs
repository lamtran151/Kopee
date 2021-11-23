using AutoMapper;
using Myrmica.Extensions.Dtos.Product;
using Myrmica.Extensions.Product.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Services.Kopee.Mappers
{
    public static class ClientSettingMapper
    {
        internal static IMapper mapper;
        static ClientSettingMapper()
        {
            mapper = new MapperConfiguration(config => config.AddProfile<ClientSettingMapperProfile>()).CreateMapper();
        }

        public static ClientSettingDto ToDto(this CreateClientSettingParams pr)
        {
            return mapper.Map<ClientSettingDto>(pr);
        }

        public static ClientSettingDto ToDto(this EditClientSettingParams pr)
        {
            return mapper.Map<ClientSettingDto>(pr);
        }
    }
}
