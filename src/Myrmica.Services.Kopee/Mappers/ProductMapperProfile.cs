using AutoMapper;
using Myrmica.Extensions.Dtos.Product;
using Myrmica.Extensions.Product.Parameters.Product;

namespace Myrmica.Services.Kopee.Mappers
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<CreateProductParams, ProductDto>(MemberList.Destination);
            CreateMap<EditProductParams, ProductDto>(MemberList.Destination);
        }
    }
}
