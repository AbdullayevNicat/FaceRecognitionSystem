using AutoMapper;
using SchoolFaceRecognition.Core.DTOs;
using SchoolFaceRecognition.Core.Entities;

namespace SchoolFaceRecognition.BL.AutoMappers
{
    public class DtoMappings : Profile
    {
        public DtoMappings()
        {
            CreateMap<Student, StudentDTO>();
            CreateMap<Group, GroupDTO>();
            CreateMap<Speciality, SpecialityDTO>();
        }
    }
}
