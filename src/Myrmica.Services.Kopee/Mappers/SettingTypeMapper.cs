using AutoMapper;
using Myrmica.Extensions.Dtos.Product;
using Myrmica.Extensions.Product.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Services.Kopee.Mappers
{
    public static class SettingTypeMapper
    {
        internal static IMapper mapper;
        static SettingTypeMapper()
        {
            mapper = new MapperConfiguration(config => config.AddProfile<SettingTypeMapperProfile>()).CreateMapper();
        }

        public static SettingTypeDto ToDto(this CreateSettingTypeParams pr)
        {
            return mapper.Map<SettingTypeDto>(pr);
        }

        public static SettingTypeDto ToDto(this EditSettingTypeParams pr)
        {
            return mapper.Map<SettingTypeDto>(pr);
        }
    }
}
