using Myrmica.Solution.Business.Dtos.File;
using Myrmica.Solution.Business.Dtos.Product;
using Myrmica.Solution.EntityFramework.Extensions.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Myrmica.Solution.Business.Services.Interface
{
    public interface IContactService
    {
        public Task<bool> AddContactAsync(ContactDto contact);
        public Task<PagedList<ContactDto>> GetPagedContactAsync(string keyword, int pageNumber, int pageSize);
    }
}
