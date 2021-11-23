using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myrmica.Extensions.Dtos.Product
{
    public class CategoryDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string route { get; set; }
        public string parentId { get; set; }
        public string clientId { get; set; }
        public string serviceTypeId { get; set; }
        public string bannerId { get; set; }
    }
}
