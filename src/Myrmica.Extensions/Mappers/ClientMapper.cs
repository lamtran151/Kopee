using AutoMapper;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;

namespace Myrmica.Extensions.Mappers
{
    public static class ClientMapper
    {
        internal static IMapper Mapper;

        static ClientMapper()
        {
            Mapper = new MapperConfiguration(config => config.AddProfile<ClientMapperProfile>()).CreateMapper();
        }

        //public static List<Activity> ToModel(this List<APP_ACTIVITY> _APP_ACTIVITY)
        //{
        //    return Mapper.Map<List<Activity>>(_APP_ACTIVITY);
        //}

        //public static Activity ToModel(this APP_ACTIVITY _APP_ACTIVITY)
        //{
        //    return Mapper.Map<Activity>(_APP_ACTIVITY);
        //}

        public static CLIENT ToEntity(this ClientDto clientDto)
        {
            return Mapper.Map<CLIENT>(clientDto);
        }

        public static ClientDto ToDto(this CLIENT client)
        {
            return Mapper.Map<ClientDto>(client);
        }

        public static PagedList<ClientDto> ToDto(this PagedList<CLIENT> client)
        {
            return Mapper.Map<PagedList<ClientDto>>(client);
        }
    }
}
