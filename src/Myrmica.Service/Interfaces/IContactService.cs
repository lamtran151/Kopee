using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;
using System.Threading.Tasks;

namespace Myrmica.Service.Interfaces
{
    public interface IContactService
    {
        public Task<bool> AddContactAsync(ContactDto contact);
        public Task<IPagedList<ContactDto>> GetPagedContactAsync(string keyword, int pageNumber, int pageSize);
    }
}
