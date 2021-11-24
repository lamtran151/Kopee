using AutoMapper;
using Myrmica.Entity;
using Myrmica.Extensions.Dtos.Product;
using System;

namespace Myrmica.Extensions.Mappers
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<ProductDto, PRODUCT>(MemberList.Destination)
                .ForMember(e => e.BANNER_ID, opt => opt.MapFrom(dto => string.IsNullOrEmpty(dto.BannerImageId) ? default : new Guid(dto.BannerImageId)))
                .ForMember(e => e.CATEGORY_ID, opt => opt.MapFrom(dto => new Guid(dto.CategoryId)))
                .ForMember(e => e.SLIDE_IMAGE_IDS, opt => opt.MapFrom(dto => dto.SlideImageIds))
                .ForMember(e => e.THUMBNAIL_ID, opt => opt.MapFrom(dto => string.IsNullOrEmpty(dto.ThumbnailId) ? default : new Guid(dto.ThumbnailId)))
                .ForMember(e => e.FULL_DESCRIPTION, opt => opt.MapFrom(dto => dto.Description))
                .ForMember(e => e.IS_HOT, opt => opt.MapFrom(dto => dto.IsHot))
                .ForMember(e => e.IS_NEW, opt => opt.MapFrom(dto => dto.IsNew))
                .ForMember(e => e.IS_SPECIAL, opt => opt.MapFrom(dto => dto.IsSpecial))
                .ForMember(e => e.IS_DISCOUNT, opt => opt.MapFrom(dto => dto.IsDiscount));

            CreateMap<PRODUCT, ProductDto>(MemberList.Destination)
                .ForMember(dto => dto.CategoryName, opt => opt.MapFrom(e => e.CATEGORY != null ? e.CATEGORY.NAME : string.Empty))
                .ForMember(dto => dto.BannerImageId, opt => opt.MapFrom(e => e.BANNER_ID.ToString()))
                .ForMember(dto => dto.CategoryId, opt => opt.MapFrom(e => e.CATEGORY_ID.ToString()))
                .ForMember(dto => dto.SlideImageIds, opt => opt.MapFrom(e => e.SLIDE_IMAGE_IDS))
                .ForMember(dto => dto.ThumbnailId, opt => opt.MapFrom(e => e.THUMBNAIL_ID.ToString()))
                .ForMember(dto => dto.Description, opt => opt.MapFrom(e => e.FULL_DESCRIPTION))
                .ForMember(dto => dto.IsHot, opt => opt.MapFrom(e => e.IS_HOT))
                .ForMember(dto => dto.IsNew, opt => opt.MapFrom(e => e.IS_NEW))
                .ForMember(dto => dto.IsSpecial, opt => opt.MapFrom(e => e.IS_SPECIAL))
                .ForMember(dto => dto.IsDiscount, opt => opt.MapFrom(e => e.IS_DISCOUNT));
				
            CreateMap<IPagedList<PRODUCT>, IPagedList<ProductDto>>(MemberList.Destination).ReverseMap();
        }
    }
}
