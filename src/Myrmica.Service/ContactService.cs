using Myrmica.Solution.Business.Dtos.File;
using Myrmica.Solution.Business.Dtos.Product;
using Myrmica.Solution.Business.Mappers;
using Myrmica.Solution.Business.Services.Interface;
using Myrmica.Solution.Business.Shared.Helpers.FileHelpers;
using Myrmica.Solution.EntityFramework.Extensions.Common;
using Myrmica.Solution.EntityFramework.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Myrmica.Solution.Business.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository contactRepository;
        private readonly HttpClient httpClient;

        public ContactService(IContactRepository _contactRepository, HttpClient _httpClient)
        {
            contactRepository = _contactRepository;
            httpClient = _httpClient;
        }

        public async Task<bool> AddContactAsync(ContactDto contact)
        {
            var result = false;
            if(!string.IsNullOrEmpty(contact.fullname) && !string.IsNullOrEmpty(contact.email) && !string.IsNullOrEmpty(contact.phonenumber) && !string.IsNullOrEmpty(contact.email) && !string.IsNullOrEmpty(contact.location))
            {
                var contactEntity = contact.ToEntity();
                result = await contactRepository.CreateContactAsync(contactEntity);
            }
            return result;
        }
        public async Task<PagedList<ContactDto>> GetPagedContactAsync(string keyword, int pageNumber, int pageSize)
        {
            var listEntity = await contactRepository.GetPagedContactAsync(keyword, pageNumber, pageSize);
            return listEntity.ToDto();
        }
    }
}
