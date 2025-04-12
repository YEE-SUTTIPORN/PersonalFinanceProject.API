using PersonalFinanceProjects.API.DTOs;

namespace PersonalFinanceProjects.API.Services
{
    public interface ICategoryService
    {
        Task<ResponseMessage> CreateAsync(CategoryDTO cate);
        Task<ResponseMessage> UpdateAsync(CategoryDTO cate);
        Task<ResponseMessage> DeleteAsync(int userId, int id);
        Task<ResponseMessage<CategoryDTO>> GetByIdAsync(int userId, int id);
        Task<List<CategoryDTO>> GetAllAsync(int userId);
    }
}
