using AutoMapper;
using SchoolFaceRecognition.Core.DTOs.Auth;
using SchoolFaceRecognition.Core.DTOs.Entities;
using SchoolFaceRecognition.Core.Entities;
using SchoolFaceRecognition.Core.Entities.Auth;

namespace SchoolFaceRecognition.BL.AutoMappers
{
    public class DtoMappings : Profile
    {
        public DtoMappings()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Group, GroupDto>().ReverseMap();
            CreateMap<Speciality, SpecialityDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
