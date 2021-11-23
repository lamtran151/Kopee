using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myrmica.Extensions.Dtos.Product.News
{
    public class ListTopNewsDto
    {
        public string categoryId{ get; set; }
        public NewsDto specialNews { get; set; }
        public List<NewsDto> listNews { get; set; }
    }
}
