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

        public async Task<IPagedList<ServiceTypeDto>> GetPagedServiceTypeAsync(string keyword, int pageNumber, int pageSize)
        {
            var listEntity = await serviceTypeRepository.GetPagedServiceTypeAsync(keyword, pageNumber, pageSize);
            return listEntity.ToDto();
        }
    }
}
