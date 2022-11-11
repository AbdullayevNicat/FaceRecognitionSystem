using AutoMapper;
using SchoolFaceRecognition.Core.DTOs;
using SchoolFaceRecognition.Core.Entities;

namespace SchoolFaceRecognition.BusinessLayer.AutoMappers
{
    public class DTO_Mappings : Profile
    {
        public DTO_Mappings()
        {
            CreateMap<Student, StudentDTO>();
            CreateMap<Group, GroupDTO>();
            CreateMap<Speciality, SpecialityDTO>();
        }
    }
}
