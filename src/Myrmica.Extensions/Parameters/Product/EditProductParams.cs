using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Extensions.Product.Parameters.Product
{
    public class EditProductParams
    {
        public string id { get; set; }
        public string name { get; set; }
        public string route { get; set; }
        public string description { get; set; }
        public string content { get; set; }
        public string categoryId { get; set; }
        public double price { get; set; }
        public bool isHot { get; set; }
        public bool isNew { get; set; }
        public bool isSpecial { get; set; }
        public bool isDiscount { get; set; }
        public string createdUserId { get; set; }
        public List<IFormFile> slideImages { get; set; }
        public IFormFile categoryImage { get; set; }
        public IFormFile bannerImage { get; set; }
    }
}
