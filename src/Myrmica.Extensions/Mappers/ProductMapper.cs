using AutoMapper;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;
using System.Collections.Generic;

namespace Myrmica.Extensions.Mappers
{
    public static class ProductMapper
    {
        internal static IMapper Mapper;

        static ProductMapper()
        {
            Mapper = new MapperConfiguration(config => config.AddProfile<ProductMapperProfile>()).CreateMapper();
        }

        //public static List<Activity> ToModel(this List<APP_ACTIVITY> _APP_ACTIVITY)
        //{
        //    return Mapper.Map<List<Activity>>(_APP_ACTIVITY);
        //}

        //public static Activity ToModel(this APP_ACTIVITY _APP_ACTIVITY)
        //{
        //    return Mapper.Map<Activity>(_APP_ACTIVITY);
        //}

        public static PRODUCT ToEntity(this ProductDto productDto)
        {
            return Mapper.Map<PRODUCT>(productDto);
        }
        public static ProductDto ToDto(this PRODUCT Product)
        {
            return Mapper.Map<ProductDto>(Product);
        }
        public static IPagedList<ProductDto> ToDto(this IPagedList<PRODUCT> product)
        {
            return Mapper.Map<IPagedList<ProductDto>>(product);
        }
        public static List<ProductDto> ToDto(this List<PRODUCT> product)
        {
            return Mapper.Map<List<ProductDto>>(product);
        }
    }
}
