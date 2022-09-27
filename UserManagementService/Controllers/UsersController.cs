using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Interfaces.Repositories;
using UserManagement.Application.Interfaces.Services;
using UserManagement.Common.Dtos;
using UserManagement.Infrastructure.Repositories;

namespace UserManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Create(UserCreateDto user)
        {
            return Ok(await _userService.CreateAsync(user));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            return Ok(await _userService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return Ok(await _userService.Delete(id));
        }

        [HttpPut]
        public async Task<ActionResult> Update(UserUpdateDto user)
        {
            return Ok(await _userService.Update(user));
        }
    }
}
