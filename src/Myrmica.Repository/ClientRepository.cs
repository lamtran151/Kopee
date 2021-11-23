using Microsoft.EntityFrameworkCore;
using Myrmica.Data;
using Myrmica.Entity;
using Myrmica.Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Repository
{
    public class ClientRepository : IClientRepository
    {
        protected readonly IRepository<CLIENT> _repo;

        public ClientRepository(IRepository<CLIENT> repo)
        {
            _repo = repo;
        }

        public async Task<string> CreateClientAsync(CLIENT Client)
        {
            await _repo.AddAsync(Client);

            return Client.ID.ToString();
        }

        public async Task<bool> DeleteClientAsync(Guid id)
        {
            var result = false;
            var menu = await _repo.FindAsync(id);

            if (menu != null)
            {
                menu.IS_DELETED = true;
                menu.DELETED_DATE= DateTime.Now;

                await _repo.DeleteAsync(menu);
                result = true;
            }

            return result;
        }

        public async Task<bool> EditClientAsync(CLIENT Client)
        {
            var result = false;
            var menu_old = await _repo.FindAsync(Client.ID);

            if (menu_old != null)
            {
                menu_old.ID = Client.ID;
                menu_old.NAME = Client.NAME;
                menu_old.UPDATED_DATE = DateTime.Now;
                await _repo.UpdateAsync(menu_old);
                result = true;
            }
            return result;
        }

        public async Task<CLIENT> GetClientByIdAsync(Guid id)
        {
            return await _repo.Table.Where(c => c.ID == id && !c.IS_DELETED)
                                           .FirstOrDefaultAsync();
        }

        public async Task<IPagedList<CLIENT>> GetPagedClientAsync(string keyword, int pageNumber, int pageSize)
        {
            var auditLogs = await _repo.Table
                .Where(x => !x.IS_DELETED && x.IS_ACTIVE).ToListAsync();

            return new PagedList<CLIENT>(auditLogs, pageNumber, pageSize);
        }
    }
}
