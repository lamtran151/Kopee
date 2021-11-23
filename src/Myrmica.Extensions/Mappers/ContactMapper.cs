using AutoMapper;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;
using System.Collections.Generic;

namespace Myrmica.Extensions.Mappers
{
    public static class ContactMapper
    {
        internal static IMapper Mapper;

        static ContactMapper()
        {
            Mapper = new MapperConfiguration(config => config.AddProfile<ContactMapperProfile>()).CreateMapper();
        }

        //public static List<Activity> ToModel(this List<APP_ACTIVITY> _APP_ACTIVITY)
        //{
        //    return Mapper.Map<List<Activity>>(_APP_ACTIVITY);
        //}

        //public static Activity ToModel(this APP_ACTIVITY _APP_ACTIVITY)
        //{
        //    return Mapper.Map<Activity>(_APP_ACTIVITY);
        //}

        public static CONTACT ToEntity(this ContactDto categoryDto)
        {
            return Mapper.Map<CONTACT>(categoryDto);
        }

        public static ContactDto ToDto(this CONTACT category)
        {
            return Mapper.Map<ContactDto>(category);
        }

        public static List<ContactDto> ToListDto(this List<CONTACT> category)
        {
            return Mapper.Map<List<ContactDto>>(category);
        }

        public static PagedList<ContactDto> ToDto(this PagedList<CONTACT> category)
        {
            return Mapper.Map<PagedList<ContactDto>>(category);
        }
    }
}
