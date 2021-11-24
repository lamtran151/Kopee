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

        public async Task<IPagedList<SettingTypeDto>> GetPagedSettingTypeAsync(string keyword, int pageNumber, int pageSize)
        {
            var listEntity = await settingTypeRepository.GetPagedSettingTypeAsync(keyword, pageNumber, pageSize);
            return listEntity.ToDto();
        }
    }
}
