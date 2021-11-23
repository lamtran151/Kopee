using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Extensions.Product.Parameters.News
{
    public class TopNewsParams
    {
        public string categoryId { get; set; }
        public bool isGetSpecial { get; set; }
        public int sizeLimit{ get; set; }
    }
}
