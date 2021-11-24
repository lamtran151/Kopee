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
    public class ClientService : IClientService
    {
        private readonly IClientRepository clientRepository;
        private readonly HttpClient httpClient;
        private readonly string[] _permittedExtensions = { ".txt", ".jpeg", ".jpg", ".png", ".tif", ".pdf" };
        private readonly string _targetFilePath;

        public ClientService(IClientRepository _clientRepository, HttpClient _httpClient)
        {
            clientRepository = _clientRepository;
            // To save physical files to a path provided by configuration:
            _targetFilePath = $"{AppContext.BaseDirectory}/file/";
            httpClient = _httpClient;
        }

        public async Task<string> AddClientAsync(ClientDto client)
        {
            var clientId = string.Empty;
            var clientEntity = client.ToEntity();
            clientId = await clientRepository.CreateClientAsync(clientEntity);
            return clientId;
        }

        public async Task<bool> DeleteClientAsync(string clientId)
        {
            if (string.IsNullOrEmpty(clientId))
            {
                return false;
            }

            return await clientRepository.DeleteClientAsync(new Guid(clientId));
        }

        public async Task<bool> EditClientAsync(ClientDto client)
        {
            var clientEntity = client.ToEntity();
            return await clientRepository.EditClientAsync(clientEntity);
        }

        public async Task<ClientDto> GetClientByIdAsync(string clientId)
        {
            if (string.IsNullOrEmpty(clientId))
            {
                return default;
            }

            var entity = await clientRepository.GetClientByIdAsync(new Guid(clientId));

            if (entity == null)
            {
                return default;
            }

            return entity.ToDto();
        }

        public async Task<IPagedList<ClientDto>> GetPagedClientAsync(string keyword, int pageNumber, int pageSize)
        {
            var listEntity = await clientRepository.GetPagedClientAsync(keyword, pageNumber, pageSize);
            return listEntity.ToDto();
        }
    }
}
