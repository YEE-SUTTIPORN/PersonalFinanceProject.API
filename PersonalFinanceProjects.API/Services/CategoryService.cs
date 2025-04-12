using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceProjects.API.Database;
using PersonalFinanceProjects.API.DTOs;
using PersonalFinanceProjects.API.Models;

namespace PersonalFinanceProjects.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly PersonalFinanceDbContext _db;
        private readonly IMapper _mapper;

        public CategoryService(PersonalFinanceDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> CreateAsync(CategoryDTO cate)
        {
            try
            {
                var alreadyCreate = await _db.Categories.Where(x => x.UserId == cate.UserId).AnyAsync();
                if (alreadyCreate)
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Category name already exists."
                    };
                }

                var newCategory = _mapper.Map<CategoryModel>(cate);

                await _db.Categories.AddAsync(newCategory);
                await _db.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Created Successfully."
                };
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseMessage> DeleteAsync(int userId, int id)
        {
            try
            {
                var isExists = await _db.Categories.SingleAsync(x => x.UserId == userId && x.CategoryId == id);

                if (isExists != null)
                {
                    _db.Categories.Remove(isExists);
                    await _db.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Deleted Successfully."
                    };
                }

                return new ResponseMessage
                {
                    Success = false,
                    Message = "Not found."
                };

            }
            catch
            {
                throw;
            }
        }

        public Task<List<CategoryDTO>> GetAllAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseMessage<CategoryDTO>> GetByIdAsync(int userId, int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseMessage> UpdateAsync(CategoryDTO cate)
        {
            throw new NotImplementedException();
        }
    }
}
