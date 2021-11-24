using AutoMapper;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;

namespace Myrmica.Extensions.Mappers
{
    public static class ClientSettingMapper
    {
        internal static IMapper Mapper;

        static ClientSettingMapper()
        {
            Mapper = new MapperConfiguration(config => config.AddProfile<ClientSettingMapperProfile>()).CreateMapper();
        }

        //public static List<Activity> ToModel(this List<APP_ACTIVITY> _APP_ACTIVITY)
        //{
        //    return Mapper.Map<List<Activity>>(_APP_ACTIVITY);
        //}

        //public static Activity ToModel(this APP_ACTIVITY _APP_ACTIVITY)
        //{
        //    return Mapper.Map<Activity>(_APP_ACTIVITY);
        //}

        public static CLIENT_SETTINGS ToEntity(this ClientSettingDto categoryDto)
        {
            return Mapper.Map<CLIENT_SETTINGS>(categoryDto);
        }

        public static ClientSettingDto ToDto(this CLIENT_SETTINGS category)
        {
            return Mapper.Map<ClientSettingDto>(category);
        }

        public static IPagedList<ClientSettingDto> ToDto(this IPagedList<CLIENT_SETTINGS> category)
        {
            return Mapper.Map<IPagedList<ClientSettingDto>>(category);
        }
    }
}
