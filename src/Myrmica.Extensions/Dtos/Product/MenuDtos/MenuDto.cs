namespace Myrmica.Extensions.Dtos.Product.MenuDtos
{
    public class MenuDto
    {
        public string id { get; set; }
        public string title { get; set; }
        public string route { get; set; }
        public int order { get; set; }
        public string parentId { get; set; }
        public int menuTypeId { get; set; }
        public string clientId { get; set; }
    }
}
