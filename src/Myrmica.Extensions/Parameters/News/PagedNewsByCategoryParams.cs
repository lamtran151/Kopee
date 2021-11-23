using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myrmica.Extensions.Product.Parameters.News
{
    public class PagedNewsByCategoryParams
    {
        public string categoryRoute { get; set; }
        public int pageNumber{ get; set; }
        public int pageSize{ get; set; }
    }
}
