using AutoMapper;
using Myrmica.Extensions.Dtos.Product;
using Myrmica.Extensions.Product.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Services.Kopee.Mappers
{
    public static class ContactMapper
    {
        internal static IMapper mapper;
        static ContactMapper()
        {
            mapper = new MapperConfiguration(config => config.AddProfile<ContactMapperProfile>()).CreateMapper();
        }
        public static ContactDto ToDto(this CreateContactParams pr)
        {
            return mapper.Map<ContactDto>(pr);
        }
    }
}
