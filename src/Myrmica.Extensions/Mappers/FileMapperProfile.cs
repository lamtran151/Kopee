using AutoMapper;
using Myrmica.Entity.File;
using Myrmica.Extensions.Dtos.File;
using System;

namespace Myrmica.Extensions.Mappers
{
    public class FileMapperProfile : Profile
    {
        public FileMapperProfile()
        {
            CreateMap<FileDto, FILE>(MemberList.Destination)
                .ForMember(e => e.CHECK_SUM, opt => opt.MapFrom(dto => dto.CheckSum))
                .ForMember(e => e.SAVED_NAME, opt => opt.MapFrom(dto => dto.TrustedFileNameForFileStorage))
                .ForMember(e => e.REAL_NAME, opt => opt.MapFrom(dto => dto.TrustedFileNameForDisplay))
                .ForMember(e => e.FILETYPE, opt => opt.MapFrom(dto => dto.FileContent.ContentType))
                .ForMember(e => e.SIZE, opt => opt.MapFrom(dto => dto.FileContent.Length));

            CreateMap<FILE, FileDto>(MemberList.Destination)
                .ForMember(e => e.CheckSum, opt => opt.MapFrom(dto => dto.CHECK_SUM))
                .ForMember(e => e.TrustedFileNameForFileStorage, opt => opt.MapFrom(dto => dto.SAVED_NAME))
                .ForMember(e => e.TrustedFileNameForDisplay, opt => opt.MapFrom(dto => dto.REAL_NAME))
                .ForMember(e => e.ContentType, opt => opt.MapFrom(dto => dto.FILETYPE))
                .ForMember(e => e.LastModified, opt => opt.MapFrom(dto => DateTime.SpecifyKind(dto.CREATED_DATE, DateTimeKind.Utc)))
                .ForMember(e => e.Size, opt => opt.MapFrom(dto => dto.SIZE));
        }
    }
}
