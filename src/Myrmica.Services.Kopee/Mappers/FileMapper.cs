using AutoMapper;
using Microsoft.AspNetCore.Http;
using Myrmica.Extensions.Dtos.File;
using System.Collections.Generic;

namespace Myrmica.Services.Kopee.Mappers
{
    public static class FileMapper
    {
        internal static IMapper mapper;
        static FileMapper()
        {
            mapper = new MapperConfiguration(config => config.AddProfile<FileMapperProfile>()).CreateMapper();
        }

        public static FileDto ToDto(this IFormFile file)
        {
            return mapper.Map<FileDto>(file);
        }

        public static List<FileDto> ToDto(this List<IFormFile> files)
        {
            return mapper.Map<List<FileDto>>(files);
        }
    }
}
