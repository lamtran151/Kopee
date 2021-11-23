using Myrmica.Entity;
using System.Threading.Tasks;

namespace Myrmica.Repository.Interfaces
{
    public interface IContactRepository
    {
        Task<bool> CreateContactAsync(CONTACT contact);
        Task<IPagedList<CONTACT>> GetPagedContactAsync(string keyword, int pageNumber, int pageSize);
    }
}
