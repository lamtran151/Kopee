using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Extensions.Product.Parameters.News
{
    public class EditNewsParams
    {
        public string id { get; set; }
        public string title { get; set; }
        public string route { get; set; }
        public string content { get; set; }
        public string shortDescription { get; set; }
        public string fullDescription { get; set; }
        public bool isSpecial { get; set; }
        public IFormFile bannerImage { get; set; }
        public IFormFile bannerSpecialImage { get; set; }
        public string categoryId { get; set; }
    }
}
