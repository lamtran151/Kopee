using AutoMapper;
using Myrmica.Extensions.Dtos.Product;
using Myrmica.Extensions.Product.Parameters.Product;

namespace Myrmica.Services.Kopee.Mappers
{
    public static class ProductMapper
    {
        internal static IMapper mapper;
        static ProductMapper()
        {
            mapper = new MapperConfiguration(config => config.AddProfile<ProductMapperProfile>()).CreateMapper();
        }

        public static ProductDto ToDto(this CreateProductParams pr)
        {
            return mapper.Map<ProductDto>(pr);
        }
        public static ProductDto ToDto(this EditProductParams pr)
        {
            return mapper.Map<ProductDto>(pr);
        }
    }
}
