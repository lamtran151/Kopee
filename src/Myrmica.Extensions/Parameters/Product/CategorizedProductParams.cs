using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Extensions.Product.Parameters.Product
{
    public class CategorizedProductParams
    {
        public string clientId { get; set; }
        public List<string> categoryIds { get; set; }
        public int sizeLimit{ get; set; }
    }
}
