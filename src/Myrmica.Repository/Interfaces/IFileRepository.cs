using Myrmica.Repository.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myrmica.Repository.Interfaces
{
    public interface IFileRepository
    {
        public Task<FILE> ExistChecksum(string CHECK_SUM);
        public Task<FILE> GetFileById(string id);
        public Task<FILE> SaveMetadata(FILE file);

    }
}
