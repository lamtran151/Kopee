using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Extensions.Product.Parameters
{
    public class EditCategoryParams
    {
        public string id { get; set; }
        public string name { get; set; }
        public string route { get; set; }
        public string parentId { get; set; }
        public IFormFile bannerImage { get; set; }
        public string clientId { get; set; }
        public string serviceTypeId { get; set; }
    }
}
