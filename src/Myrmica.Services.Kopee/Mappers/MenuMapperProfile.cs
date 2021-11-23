using AutoMapper;
using Myrmica.Extensions.Dtos.Product;
using Myrmica.Extensions.Dtos.Product.MenuDtos;
using Myrmica.Extensions.Product.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Services.Kopee.Mappers
{
    public class MenuMapperProfile : Profile
    {
        public MenuMapperProfile()
        {
            CreateMap<CreateMenuParams, MenuDto>();
            CreateMap<EditMenuParams, MenuDto>().ForMember(dto => dto.parentId, opt => opt.MapFrom(pr => pr.parentId.Length > 0 ? pr.parentId : null));
        }
    }
}
