using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;
using Myrmica.Extensions.Mappers;
using Myrmica.Repository.Interfaces;
using Myrmica.Service.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Myrmica.Service
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
        public async Task<IPagedList<ContactDto>> GetPagedContactAsync(string keyword, int pageNumber, int pageSize)
        {
            var listEntity = await contactRepository.GetPagedContactAsync(keyword, pageNumber, pageSize);
            return listEntity.ToDto();
        }
    }
}
