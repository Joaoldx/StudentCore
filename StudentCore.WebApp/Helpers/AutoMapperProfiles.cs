using AutoMapper;
using StudentCore.DomainModel.Entities;
using StudentCore.WebApp.Dtos;

namespace StudentCore.WebApp.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Teacher, TeacherDto>().ReverseMap();
            CreateMap<Group, GroupDto>().ReverseMap();
        }
    }
}