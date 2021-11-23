using AutoMapper;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;
using System.Collections.Generic;

namespace Myrmica.Extensions.Mappers
{
    public static class CategoryMapper
    {
        internal static IMapper Mapper;

        static CategoryMapper()
        {
            Mapper = new MapperConfiguration(config => config.AddProfile<CategoryMapperProfile>()).CreateMapper();
        }

        //public static List<Activity> ToModel(this List<APP_ACTIVITY> _APP_ACTIVITY)
        //{
        //    return Mapper.Map<List<Activity>>(_APP_ACTIVITY);
        //}

        //public static Activity ToModel(this APP_ACTIVITY _APP_ACTIVITY)
        //{
        //    return Mapper.Map<Activity>(_APP_ACTIVITY);
        //}

        public static CATEGORY ToEntity(this CategoryDto categoryDto)
        {
            return Mapper.Map<CATEGORY>(categoryDto);
        }

        public static CategoryDto ToDto(this CATEGORY category)
        {
            return Mapper.Map<CategoryDto>(category);
        }

        public static List<CategoryDto> ToListDto(this List<CATEGORY> category)
        {
            return Mapper.Map<List<CategoryDto>>(category);
        }

        public static IPagedList<CategoryDto> ToDto(this IPagedList<CATEGORY> category)
        {
            return Mapper.Map<IPagedList<CategoryDto>>(category);
        }
    }
}
