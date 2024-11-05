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
        }
    }
}
