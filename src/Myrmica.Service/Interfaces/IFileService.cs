using Myrmica.Entity.File;
using Myrmica.Extensions.Dtos.File;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Myrmica.Service.Interfaces
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
