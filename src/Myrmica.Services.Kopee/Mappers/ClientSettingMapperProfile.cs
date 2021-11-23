using AutoMapper;
using Myrmica.Extensions.Dtos.Product;
using Myrmica.Extensions.Product.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Services.Kopee.Mappers
{
    public class ClientSettingMapperProfile : Profile
    {
        public ClientSettingMapperProfile()
        {
            CreateMap<CreateClientSettingParams, ClientSettingDto>();
            CreateMap<EditClientSettingParams, ClientSettingDto>();
        }
    }
}
