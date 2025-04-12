using AutoMapper;
using PersonalFinanceProjects.API.DTOs;
using PersonalFinanceProjects.API.Models;

namespace PersonalFinanceProjects.API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserModel, UserDTO>().ReverseMap();
        }
    }
}
