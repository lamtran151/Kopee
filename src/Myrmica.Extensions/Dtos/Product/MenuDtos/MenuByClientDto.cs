using System.Collections.Generic;

namespace Myrmica.Extensions.Dtos.Product.MenuDtos
{
    public class MenuByClientDto
    {
        public string id { get; set; }
        public string title { get; set; }
        public string route { get; set; }
        public List<MenuByClientDto> childMenu { get; set; }
    }
}
