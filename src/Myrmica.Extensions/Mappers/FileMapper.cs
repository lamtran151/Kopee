using AutoMapper;
using Myrmica.Entity.File;
using Myrmica.Extensions.Dtos.File;
using System.Collections.Generic;

namespace Myrmica.Extensions.Mappers
{
    public static class FileMapper
    {
        internal static IMapper Mapper;

        static FileMapper()
        {
            Mapper = new MapperConfiguration(config => config.AddProfile<FileMapperProfile>()).CreateMapper();
        }

        //public static List<Activity> ToModel(this List<APP_ACTIVITY> _APP_ACTIVITY)
        //{
        //    return Mapper.Map<List<Activity>>(_APP_ACTIVITY);
        //}

        //public static Activity ToModel(this APP_ACTIVITY _APP_ACTIVITY)
        //{
        //    return Mapper.Map<Activity>(_APP_ACTIVITY);
        //}

        public static List<FILE> ToEntity(this List<FileDto> fileDtos)
        {
            return Mapper.Map<List<FILE>>(fileDtos);
        }

        public static FILE ToEntity(this FileDto fileDto)
        {
            return Mapper.Map<FILE>(fileDto);
        }

        public static FileDto ToDto(this FILE file)
        {
            return Mapper.Map<FileDto>(file);
        }
    }
}
