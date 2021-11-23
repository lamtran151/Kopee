using Microsoft.EntityFrameworkCore;
using Myrmica.Data;
using Myrmica.Entity;
using Myrmica.Repository.Interfaces;
using System.Threading.Tasks;

namespace Myrmica.Repository
{
    public class ContactRepository : IContactRepository
    {
        protected readonly IRepository<CONTACT> _repo;

        public ContactRepository(IRepository<CONTACT> repo)
        {
            _repo = repo;
        }
        public async Task<bool> CreateContactAsync(CONTACT contact)
        {
            var result = false;
            if (!string.IsNullOrEmpty(contact.FULLNAME) && !string.IsNullOrEmpty(contact.PHONENUMBER) && !string.IsNullOrEmpty(contact.EMAIL) && !string.IsNullOrEmpty(contact.PHONENUMBER) && !string.IsNullOrEmpty(contact.LOCATION))
            {

                await _repo.AddAsync(contact);
                result = true;
            }
            return result;
        }
        public async Task<IPagedList<CONTACT>> GetPagedContactAsync(string keyword, int pageNumber, int pageSize)
        {

            var auditLogs = await _repo.Table
                .ToListAsync();

            return new PagedList<CONTACT>(auditLogs, pageNumber, pageSize);
        }
    }
}
