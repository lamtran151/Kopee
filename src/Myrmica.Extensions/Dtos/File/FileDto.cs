using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myrmica.Extensions.Dtos.File
{
    public class FileDto
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string TrustedFileNameForDisplay { get; set; }
        public string TrustedFileNameForFileStorage { get; set; }
        public string CheckSum { get; set; }
        public string ContentType { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public long Size { get; set; }
        public IFormFile FileContent { get; set; }
    }
}
