using AutoMapper;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;

namespace Myrmica.Extensions.Mappers
{
    public static class ServiceTypeMapper
    {
        internal static IMapper Mapper;

        static ServiceTypeMapper()
        {
            Mapper = new MapperConfiguration(config => config.AddProfile<ServiceTypeMapperProfile>()).CreateMapper();
        }

        //public static List<Activity> ToModel(this List<APP_ACTIVITY> _APP_ACTIVITY)
        //{
        //    return Mapper.Map<List<Activity>>(_APP_ACTIVITY);
        //}

        //public static Activity ToModel(this APP_ACTIVITY _APP_ACTIVITY)
        //{
        //    return Mapper.Map<Activity>(_APP_ACTIVITY);
        //}

        public static SERVICE_TYPE ToEntity(this ServiceTypeDto ServiceTypeDto)
        {
            return Mapper.Map<SERVICE_TYPE>(ServiceTypeDto);
        }

        public static ServiceTypeDto ToDto(this SERVICE_TYPE ServiceType)
        {
            return Mapper.Map<ServiceTypeDto>(ServiceType);
        }

        public static PagedList<ServiceTypeDto> ToDto(this PagedList<SERVICE_TYPE> ServiceType)
        {
            return Mapper.Map<PagedList<ServiceTypeDto>>(ServiceType);
        }
    }
}
