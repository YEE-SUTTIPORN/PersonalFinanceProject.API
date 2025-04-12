using Microsoft.AspNetCore.Mvc;
using PersonalFinanceProjects.API.DTOs;
using PersonalFinanceProjects.API.Services;

namespace PersonalFinanceProjects.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] UserDTO userDTO)
        {
            var result = await _userService.CreateAsync(userDTO);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UserDTO userDTO)
        {
            var result = await _userService.UpdateAsync(userDTO);
            return Ok(result);
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] UserDTO userDTO)
        {
            var result = await _userService.ChangePasswordAsync(userDTO);
            return Ok(result);
        }

    }
}
