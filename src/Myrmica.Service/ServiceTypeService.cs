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
    public class ServiceTypeService : IServiceTypeService
    {
        private readonly IServiceTypeRepository serviceTypeRepository;
        private readonly HttpClient httpClient;
        private readonly string[] _permittedExtensions = { ".txt", ".jpeg", ".jpg", ".png", ".tif", ".pdf" };
        private readonly string _targetFilePath;

        public ServiceTypeService(IServiceTypeRepository _serviceTypeRepository, HttpClient _httpClient)
        {
            serviceTypeRepository = _serviceTypeRepository;
            // To save physical files to a path provided by configuration:
            _targetFilePath = $"{AppContext.BaseDirectory}/file/";
            httpClient = _httpClient;
        }

        public async Task<string> AddServiceTypeAsync(ServiceTypeDto serviceType)
        {
            var serviceTypeId = string.Empty;
            var serviceTypeEntity = serviceType.ToEntity();
            serviceTypeId = await serviceTypeRepository.CreateServiceTypeAsync(serviceTypeEntity);
            return serviceTypeId;
        }

        public async Task<bool> DeleteServiceTypeAsync(string serviceTypeId)
        {
            if (string.IsNullOrEmpty(serviceTypeId))
            {
                return false;
            }

            return await serviceTypeRepository.DeleteServiceTypeAsync(new Guid(serviceTypeId));
        }

        public async Task<bool> EditServiceTypeAsync(ServiceTypeDto serviceType)
        {
            var serviceTypeEntity = serviceType.ToEntity();
            return await serviceTypeRepository.EditServiceTypeAsync(serviceTypeEntity);
        }

        public async Task<ServiceTypeDto> GetServiceTypeByIdAsync(string serviceTypeId)
        {
            if (string.IsNullOrEmpty(serviceTypeId))
            {
                return default;
            }

            var entity = await serviceTypeRepository.GetServiceTypeByIdAsync(new Guid(serviceTypeId));

            if (entity == null)
            {
                return default;
            }

            return entity.ToDto();
        }

        public async Task<PagedList<ServiceTypeDto>> GetPagedServiceTypeAsync(string keyword, int pageNumber, int pageSize)
        {
            var listEntity = await serviceTypeRepository.GetPagedServiceTypeAsync(keyword, pageNumber, pageSize);
            return listEntity.ToDto();
        }
    }
}
