using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myrmica.Extensions.Dtos.Product.News
{
    public class NewsDto
    {
        public string id { get; set; }
        public string title { get; set; }
        public string route { get; set; }
        public string content { get; set; }
        public string shortDescription { get; set; }
        public string fullDescription { get; set; }
        public bool isSpecial { get; set; }
        public string bannerId { get; set; }
        public string bannerSpecialId { get; set; }
        public string categoryId { get; set; }
        public string categoryTitle { get; set; }
    }
}
