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
    public class SettingTypeService : ISettingTypeService
    {
        private readonly ISettingTypeRepository settingTypeRepository;
        private readonly HttpClient httpClient;
        private readonly string[] _permittedExtensions = { ".txt", ".jpeg", ".jpg", ".png", ".tif", ".pdf" };
        private readonly string _targetFilePath;

        public SettingTypeService(ISettingTypeRepository _settingTypeRepository, HttpClient _httpClient)
        {
            settingTypeRepository = _settingTypeRepository;
            // To save physical files to a path provided by configuration:
            _targetFilePath = $"{AppContext.BaseDirectory}/file/";
            httpClient = _httpClient;
        }

        public async Task<string> AddSettingTypeAsync(SettingTypeDto settingType)
        {
            var settingTypeId = string.Empty;
            var settingTypeEntity = settingType.ToEntity();
            settingTypeId = await settingTypeRepository.CreateSettingTypeAsync(settingTypeEntity);
            return settingTypeId;
        }

        public async Task<bool> DeleteSettingTypeAsync(string settingTypeId)
        {
            if (string.IsNullOrEmpty(settingTypeId))
            {
                return false;
            }

            return await settingTypeRepository.DeleteSettingTypeAsync(new Guid(settingTypeId));
        }

        public async Task<bool> EditSettingTypeAsync(SettingTypeDto settingType)
        {
            var settingTypeEntity = settingType.ToEntity();
            return await settingTypeRepository.EditSettingTypeAsync(settingTypeEntity);
        }

        public async Task<SettingTypeDto> GetSettingTypeByIdAsync(string settingTypeId)
        {
            if (string.IsNullOrEmpty(settingTypeId))
            {
                return default;
            }

            var entity = await settingTypeRepository.GetSettingTypeByIdAsync(new Guid(settingTypeId));

            if (entity == null)
            {
                return default;
            }

            return entity.ToDto();
        }

        public async Task<PagedList<SettingTypeDto>> GetPagedSettingTypeAsync(string keyword, int pageNumber, int pageSize)
        {
            var listEntity = await settingTypeRepository.GetPagedSettingTypeAsync(keyword, pageNumber, pageSize);
            return listEntity.ToDto();
        }
    }
}
