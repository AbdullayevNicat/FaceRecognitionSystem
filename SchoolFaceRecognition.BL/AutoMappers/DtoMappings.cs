using AutoMapper;
using SchoolFaceRecognition.Core.DTOs.Auths;
using SchoolFaceRecognition.Core.DTOs.Entities;
using SchoolFaceRecognition.Core.Entities;

namespace SchoolFaceRecognition.BL.AutoMappers
{
    public class DtoMappings : Profile
    {
        public DtoMappings()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Group, GroupDto>();
            CreateMap<Speciality, SpecialityDto>();
            CreateMap<AppUser, AppUserDto>();
            CreateMap<AppUser, AppUserInfoDto>().ReverseMap();
        }
    }
}
