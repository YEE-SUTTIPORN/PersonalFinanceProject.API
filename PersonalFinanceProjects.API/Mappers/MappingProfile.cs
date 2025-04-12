using AutoMapper;
using PersonalFinanceProjects.API.DTOs;
using PersonalFinanceProjects.API.Models;

namespace PersonalFinanceProjects.API.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User
            CreateMap<UserModel, UserDTO>().ReverseMap();
            #endregion User

            #region Category
            CreateMap<CategoryModel, CategoryDTO>().ReverseMap();
            #endregion Category
        }
    }
}
