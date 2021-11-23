using AutoMapper;
using Myrmica.Extensions.Dtos.Product.MenuDtos;
using Myrmica.Extensions.Product.Parameters;

namespace Myrmica.Services.Kopee.Mappers
{
    public static class MenuMapper
    {
        internal static IMapper mapper;
        static MenuMapper()
        {
            mapper = new MapperConfiguration(config => config.AddProfile<MenuMapperProfile>()).CreateMapper();
        }

        public static MenuDto ToDto(this CreateMenuParams pr)
        {
            return mapper.Map<MenuDto>(pr);
        }

        public static MenuDto ToDto(this EditMenuParams pr)
        {
            return mapper.Map<MenuDto>(pr);
        }
    }
}
