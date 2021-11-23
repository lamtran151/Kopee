using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Extensions.Product.Parameters
{
    public class EditMenuParams
    {
        public string id { get; set; }
        public string title { get; set; }
        public string route { get; set; }
        public string parentId { get; set; }
        public int order { get; set; }
        public int menuTypeId { get; set; }
        public string clientId { get; set; }
    }
}
