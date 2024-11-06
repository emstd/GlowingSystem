using AutoMapper;
using GlowingSystem.Core.DataTransferObjects;
using GlowingSystem.Core.Models;

namespace GlowingSystem.MappingProfiles
{
    public class BusinessLogicMappingProfile : Profile
    {
        public BusinessLogicMappingProfile()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Project, ProjectForCreateDto>().ReverseMap();
            CreateMap<Project, ProjectForUpdateDto>().ReverseMap();

            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerForCreateDto>().ReverseMap();
            CreateMap<Customer, CustomerForUpdateDto>().ReverseMap();

            CreateMap<Contractor, ContractorDto>().ReverseMap();
            CreateMap<Contractor, ContractorForCreateDto>().ReverseMap();
            CreateMap<Contractor, ContractorForUpdateDto>().ReverseMap();

            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, EmployeeForCreateDto>().ReverseMap();
            CreateMap<Employee, EmployeeForUpdateDto>().ReverseMap();
        }
    }
}
