using AutoMapper;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product.MenuDtos;
using System.Collections.Generic;

namespace Myrmica.Extensions.Mappers
{
    public static class MenuMapper
    {
        internal static IMapper Mapper;

        static MenuMapper()
        {
            Mapper = new MapperConfiguration(config => config.AddProfile<MenuMapperProfile>()).CreateMapper();
        }

        //public static List<Activity> ToModel(this List<APP_ACTIVITY> _APP_ACTIVITY)
        //{
        //    return Mapper.Map<List<Activity>>(_APP_ACTIVITY);
        //}

        //public static Activity ToModel(this APP_ACTIVITY _APP_ACTIVITY)
        //{
        //    return Mapper.Map<Activity>(_APP_ACTIVITY);
        //}

        public static MENU ToEntity(this MenuDto categoryDto)
        {
            return Mapper.Map<MENU>(categoryDto);
        }

        public static MenuDto ToDto(this MENU category)
        {
            return Mapper.Map<MenuDto>(category);
        }

        public static PagedList<MenuDto> ToDto(this PagedList<MENU> category)
        {
            return Mapper.Map<PagedList<MenuDto>>(category);
        }

        public static List<MenuDto> ToDto(this List<MENU> category)
        {
            return Mapper.Map<List<MenuDto>>(category);
        }

        public static List<MenuByClientDto> ToMenuByClientDto(this List<MENU> category)
        {
            return Mapper.Map<List<MenuByClientDto>>(category);
        }
    }
}
