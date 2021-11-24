using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Myrmica.Entity.File;
using Myrmica.Extensions.Dtos.File;
using Myrmica.Extensions.Helpers.EncrytoHelper;
using Myrmica.Extensions.Helpers.FileHelpers;
using Myrmica.Extensions.Mappers;
using Myrmica.Repository.Interfaces;
using Myrmica.Service.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Myrmica.Service
{
    public class FileService : IFileService
    {
        protected readonly IFileRepository fileRepository;
        private readonly ILogger<FileService> logger;
        public FileService(IFileRepository _fileRepository, ILogger<FileService> _logger)
        {
            fileRepository = _fileRepository;
            logger = _logger;
        }
        public async Task<FILE> Checksum(string checksum)
        {
            return await fileRepository.ExistChecksum(checksum);
        }

        public async Task<List<FileDto>> CreateFilesAsync(List<FileDto> uploadedFiles,
                                                          string[] permittedExtensions,
                                                          long sizeLimit,
                                                          string _targetFilePath)
        {
            foreach (var file in uploadedFiles)
            {
                //Từ IFormFile chuyển thành bytes[]
                var processedFile = await file.FileContent.ProcessFormFile<FileDto>(permittedExtensions, sizeLimit);
                file.TrustedFileNameForDisplay = processedFile.Item2;
                file.TrustedFileNameForFileStorage = Path.GetRandomFileName();

                //Lưu file vật lý
                file.CheckSum= await processedFile.Item1.Md5Hash();
                var fileExisted = await Checksum(file.CheckSum);
                logger.LogInformation($"Checksum: {file.CheckSum}, file existed: {fileExisted != null}");

                //Nếu file chưa tồn tại trong db
                //và chuỗi checksum khác rỗng
                //thì lưu file vật lý
                if (fileExisted == default && !string.IsNullOrEmpty(file.CheckSum))
                {
                    try
                    {
                        logger.LogInformation($"Save physical file");
                        file.Path = $"{file.CheckSum[0]}{file.CheckSum[1]}/{file.CheckSum[2]}{file.CheckSum[3]}";
                        var destinationPath = Path.Combine(_targetFilePath, file.Path);
                        if (!Directory.Exists(destinationPath))
                        {
                            Directory.CreateDirectory(destinationPath);
                        }
                        using var targetStream = File.Create(Path.Combine(destinationPath, file.TrustedFileNameForFileStorage));
                        await targetStream.WriteAsync(processedFile.Item1);
                    }
                    catch (System.Exception ex)
                    {
                        logger.LogInformation(ex.Message);
                        throw;
                    }
                }

                //Nếu file tồn tại thì lấy thông tin ở file cũ
                if (fileExisted != default)
                {
                    logger.LogInformation("Lấy thông tin ở file cũ");
                    file.Path = fileExisted.PATH;
                    file.TrustedFileNameForFileStorage = fileExisted.SAVED_NAME;
                }

                logger.LogInformation("Lưu vào database");
                //Lưu metadata của file xuống database
                var entity = file.ToEntity();
                await fileRepository.SaveMetadata(entity);

                logger.LogInformation($"Gán lại id: {entity.ID} vào file để trả ra");
                file.Id = entity.ID;
            }

            return uploadedFiles;
        }

        public async Task<FileDto> GetFileInfo(string id)
        {
            var entity = await fileRepository.GetFileById(id);
            return entity.ToDto();
        }
    }
}
