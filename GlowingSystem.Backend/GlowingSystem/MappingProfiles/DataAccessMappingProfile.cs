using AutoMapper;
using GlowingSystem.Core.Models;
using GlowingSystem.DataAccess.Entities;

namespace GlowingSystem.MappingProfiles
{
    public class DataAccessMappingProfile : Profile
    {
        public DataAccessMappingProfile()
        {
            CreateMap<Project, ProjectEntity>().ReverseMap();
                //.ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees));
            CreateMap<ProjectEntity, Project>().ReverseMap();
                //.ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees));
            CreateMap<Contractor, ContractorEntity>().ReverseMap();
            CreateMap<Customer, CustomerEntity>().ReverseMap();
            CreateMap<Employee, EmployeeEntity>().ReverseMap();
        }
    }
}
