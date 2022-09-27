using UserManagement.Common.Dtos;
using UserManagement.Common.Wrapper;

namespace UserManagement.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<Result<List<UserDto>>> GetAll();
        Task<IResult<UserDto>> CreateAsync(UserCreateDto user);
        Task<IResult> Update(UserUpdateDto user);
        Task<IResult> Delete(Guid id);
    }
}
