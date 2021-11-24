using AutoMapper;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;

namespace Myrmica.Extensions.Mappers
{
    public static class SettingTypeMapper
    {
        internal static IMapper Mapper;

        static SettingTypeMapper()
        {
            Mapper = new MapperConfiguration(config => config.AddProfile<SettingTypeMapperProfile>()).CreateMapper();
        }

        //public static List<Activity> ToModel(this List<APP_ACTIVITY> _APP_ACTIVITY)
        //{
        //    return Mapper.Map<List<Activity>>(_APP_ACTIVITY);
        //}

        //public static Activity ToModel(this APP_ACTIVITY _APP_ACTIVITY)
        //{
        //    return Mapper.Map<Activity>(_APP_ACTIVITY);
        //}

        public static SETTING_TYPE ToEntity(this SettingTypeDto SettingTypeDto)
        {
            return Mapper.Map<SETTING_TYPE>(SettingTypeDto);
        }

        public static SettingTypeDto ToDto(this SETTING_TYPE SettingType)
        {
            return Mapper.Map<SettingTypeDto>(SettingType);
        }

        public static IPagedList<SettingTypeDto> ToDto(this IPagedList<SETTING_TYPE> SettingType)
        {
            return Mapper.Map<IPagedList<SettingTypeDto>>(SettingType);
        }
    }
}
