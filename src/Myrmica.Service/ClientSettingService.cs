using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;
using Myrmica.Extensions.Mappers;
using Myrmica.Repository.Interfaces;
using Myrmica.Service.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Myrmica.Service
{
    public class ClientSettingService : IClientSettingService
    {
        private readonly IClientSettingRepository clientSettingRepository;
        private readonly HttpClient httpClient;
        private readonly string[] _permittedExtensions = { ".txt", ".jpeg", ".jpg", ".png", ".tif", ".pdf" };
        private readonly string _targetFilePath;

        public ClientSettingService(IClientSettingRepository _clientSettingRepository, HttpClient _httpClient)
        {
            clientSettingRepository = _clientSettingRepository;
            // To save physical files to a path provided by configuration:
            _targetFilePath = $"{AppContext.BaseDirectory}/file/";
            httpClient = _httpClient;
        }

        public async Task<string> AddClientSettingAsync(ClientSettingDto clientSetting)
        {
            var clientSettingId = string.Empty;
            var clientSettingEntity = clientSetting.ToEntity();
            clientSettingId = await clientSettingRepository.CreateClientSettingAsync(clientSettingEntity);
            return clientSettingId;
        }

        public async Task<bool> DeleteClientSettingAsync(string clientSettingId)
        {
            if (string.IsNullOrEmpty(clientSettingId))
            {
                return false;
            }

            return await clientSettingRepository.DeleteClientSettingAsync(new Guid(clientSettingId));
        }

        public async Task<bool> EditClientSettingAsync(ClientSettingDto clientSetting)
        {
            var clientSettingEntity = clientSetting.ToEntity();
            return await clientSettingRepository.EditClientSettingAsync(clientSettingEntity);
        }

        public async Task<ClientSettingDto> GetClientSettingByIdAsync(string clientSettingId)
        {
            if (string.IsNullOrEmpty(clientSettingId))
            {
                return default;
            }

            var entity = await clientSettingRepository.GetClientSettingByIdAsync(new Guid(clientSettingId));

            if (entity == null)
            {
                return default;
            }

            return entity.ToDto();
        }

        public async Task<IPagedList<ClientSettingDto>> GetPagedClientSettingAsync(string keyword, int pageNumber, int pageSize)
        {
            var listEntity = await clientSettingRepository.GetPagedClientSettingAsync(keyword, pageNumber, pageSize);
            return listEntity.ToDto();
        }
    }
}
