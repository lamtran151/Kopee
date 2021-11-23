using AutoMapper;
using Myrmica.Extensions.Dtos.Product;
using Myrmica.Extensions.Product.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Services.Kopee.Mappers
{
    public static class CategoryMapper
    {
        internal static IMapper mapper;
        static CategoryMapper()
        {
            mapper = new MapperConfiguration(config => config.AddProfile<CategoryMapperProfile>()).CreateMapper();
        }

        public static CategoryDto ToDto(this CreateCategoryParams pr)
        {
            return mapper.Map<CategoryDto>(pr);
        }

        public static CategoryDto ToDto(this EditCategoryParams pr)
        {
            return mapper.Map<CategoryDto>(pr);
        }
    }
}
