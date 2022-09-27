using UserManagement.Common.Dtos;
using UserManagement.Common.Wrapper;

namespace BlazorApp.Client.Infrastructure.Managers
{
    public interface IUserServiceManager
    {
        Task<IResult<IEnumerable<UserDto>>> GetAll();
        Task<IResult> Delete(Guid id);
        Task<IResult> Update(UserUpdateDto user);
        Task<IResult<UserDto>> Create(UserCreateDto user);
    }
}
