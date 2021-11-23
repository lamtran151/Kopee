using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myrmica.Extensions.Dtos.Product.News
{
    public class TopNewsParamsDto
    {
        public string categoryId { get; set; }
        public bool isGetSpecial { get; set; }
        public int sizeLimit { get; set; }
    }
}
