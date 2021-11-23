using AutoMapper;
using Myrmica.Extensions.Dtos.Product;
using Myrmica.Extensions.Product.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Services.Kopee.Mappers
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<CreateCategoryParams, CategoryDto>();
            CreateMap<EditCategoryParams, CategoryDto>();
        }
    }
}
