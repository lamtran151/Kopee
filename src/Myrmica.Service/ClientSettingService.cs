using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using Myrmica.Solution.Business.Dtos.File;
using Myrmica.Solution.Business.Dtos.Product;
using Myrmica.Solution.Business.Mappers;
using Myrmica.Solution.Business.Services.Interface;
using Myrmica.Solution.Business.Shared.Helpers.FileHelpers;
using Myrmica.Solution.EntityFramework.Entities.Product;
using Myrmica.Solution.EntityFramework.Extensions.Common;
using Myrmica.Solution.EntityFramework.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Myrmica.Solution.Business.Services
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

        public async Task<PagedList<ClientSettingDto>> GetPagedClientSettingAsync(string keyword, int pageNumber, int pageSize)
        {
            var listEntity = await clientSettingRepository.GetPagedClientSettingAsync(keyword, pageNumber, pageSize);
            return listEntity.ToDto();
        }
    }
}
