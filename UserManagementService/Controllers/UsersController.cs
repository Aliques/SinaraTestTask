using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Common.Dtos;
using UserManagement.Data.Repositories;

namespace UserManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var items = await _userRepository.GetAllUsersAsync();

            return Ok(_mapper.Map<IEnumerable<UserDto>>(items));
        }
    }
}
