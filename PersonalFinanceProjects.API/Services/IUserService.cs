using PersonalFinanceProjects.API.DTOs;

namespace PersonalFinanceProjects.API.Services
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllAsync();
        Task<ResponseMessage<UserDTO>> GetByIdAsync(int pId);
        Task<ResponseMessage> CreateAsync(UserDTO pUserDTO);
        Task<ResponseMessage> UpdateAsync(UserDTO pUserDTO);
        Task<ResponseMessage> ChangePasswordAsync(UserDTO pUserDTO);
        Task<ResponseMessage> DeleteAsync(int pId);
    }
}
