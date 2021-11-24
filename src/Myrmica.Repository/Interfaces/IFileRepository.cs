using Myrmica.Entity.File;
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
