using AutoMapper;
using Microsoft.AspNetCore.Http;
using Myrmica.Extensions.Dtos.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Services.Kopee.Mappers
{
    public class FileMapperProfile : Profile
    {
        public FileMapperProfile()
        {
            CreateMap<IFormFile, FileDto>().ForMember(dto => dto.FileContent, opt => {
                opt.MapFrom(pr => pr);
            });
        }
    }
}
