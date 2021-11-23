namespace Myrmica.Extensions.Dtos.Product
{
    public class ProductDto
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        public string Route { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public double Price { get; set; }
        public bool IsHot { get; set; }
        public bool IsNew { get; set; }
        public bool IsSpecial { get; set; }
        public bool IsDiscount { get; set; }
        public string CreatedUserId { get; set; }
        public string SlideImageIds { get; set; }
        public string ThumbnailId { get; set; }
        public string BannerImageId { get; set; }
    }
}
