using Myrmica.Solution.Business.Dtos.File;
using Myrmica.Solution.EntityFramework.Entities.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Myrmica.Solution.Business.Services.Interface
{
    public interface IFileService
    {
        public Task<FILE> Checksum(string checksum);
        public Task<FileDto> GetFileInfo(string id);
        public Task<List<FileDto>> CreateFilesAsync(List<FileDto> uploadedFiles,
                                                    string[] permittedExtensions,
                                                    long sizeLimit,
                                                    string _targetFilePath);
    }
}
