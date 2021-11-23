using Microsoft.EntityFrameworkCore;
using Myrmica.Repository.Entities.Product;
using Myrmica.Repository.Interfaces;
using Myrmica.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myrmica.Repository
{
    public class FileRepository<TDbContext> : IFileRepository
        where TDbContext : IFileDbContext
    {
        protected readonly TDbContext dbContext;

        public FileRepository(TDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<FILE> ExistChecksum(string CHECK_SUM)
        {
            return await dbContext.FILE.Where(f => f.CHECK_SUM == CHECK_SUM).OrderByDescending(f => f.CREATED_DATE).FirstOrDefaultAsync();
        }

        public async Task<FILE> GetFileById(string id)
        {
            return await dbContext.FILE.FindAsync(new Guid(id));
        }

        public async Task<FILE> SaveMetadata(FILE file)
        {
            await dbContext.FILE.AddAsync(file);
            await dbContext.SaveChangeAsync();
            return file;
        }
    }
}
