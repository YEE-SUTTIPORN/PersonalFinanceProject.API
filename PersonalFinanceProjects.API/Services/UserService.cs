using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceProjects.API.Database;
using PersonalFinanceProjects.API.DTOs;
using PersonalFinanceProjects.API.Models;

namespace PersonalFinanceProjects.API.Services
{
    public class UserService : IUserService
    {
        private readonly PersonalFinanceDbContext _db;
        private readonly IMapper _mapper;

        public UserService(PersonalFinanceDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> ChangePasswordAsync(UserDTO pUserDTO)
        {
            try
            {
                var isExists = await _db.Users.SingleOrDefaultAsync(x => x.UserId == pUserDTO.UserId);

                if (isExists == null)
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Not found."
                    };
                }

                isExists.PasswordHash = BCrypt.Net.BCrypt.HashPassword(pUserDTO.Password);
                isExists.UpdatedAt = DateTime.Now;

                _db.Entry(isExists).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Password changed successfully."
                };
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseMessage> CreateAsync(UserDTO pUserDTO)
        {
            try
            {
                var duplicateUsername = await _db.Users.SingleOrDefaultAsync(x => x.UserName == pUserDTO.UserName);
                if (duplicateUsername != null)
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Username already exists."
                    };
                }

                var newUser = _mapper.Map<UserModel>(pUserDTO);
                newUser.CreatedAt = DateTime.Now;
                newUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(pUserDTO.Password);

                await _db.Users.AddAsync(newUser);
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

        public async Task<ResponseMessage> DeleteAsync(int pId)
        {
            try
            {
                var user = await _db.Users.SingleOrDefaultAsync(x => x.UserId == pId);
                if (user == null)
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Not found."
                    };
                }

                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
                return new ResponseMessage
                {
                    Success = true,
                    Message = "Deleted Successfully."
                };
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            try
            {
                var mapper = _mapper.Map<List<UserDTO>>(await _db.Users.ToListAsync());
                return mapper;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseMessage<UserDTO>> GetByIdAsync(int pId)
        {
            try
            {
                var user = await _db.Users.SingleOrDefaultAsync(x => x.UserId == pId);
                if (user == null)
                {
                    return new ResponseMessage<UserDTO>()
                    {
                        Success = false,
                        Message = "Not found."
                    };
                }

                var mapper = _mapper.Map<UserDTO>(user);
                return new ResponseMessage<UserDTO>
                {
                    Success = true,
                    Message = "Success",
                    Data = mapper
                };
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResponseMessage> UpdateAsync(UserDTO pUserDTO)
        {
            try
            {
                var isExists = await _db.Users.SingleOrDefaultAsync(x => x.UserId == pUserDTO.UserId);
                if (isExists == null)
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Not found."
                    };
                }

                isExists.UpdatedAt = DateTime.Now;
                isExists.Email = pUserDTO.Email;
                isExists.FullName = pUserDTO.FullName;
                _db.Entry(isExists).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Updated successfully."
                };
            }
            catch
            {
                throw;
            }
        }
    }
}
