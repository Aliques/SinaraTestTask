using BlazorApp.Client.Infrastructure.Endpoints;
using System.Net.Http.Json;
using UserManagement.Common.Dtos;
using UserManagement.Common.Extensions;
using UserManagement.Common.Wrapper;

namespace BlazorApp.Client.Infrastructure.Managers
{
    public class UserServiceManager : IUserServiceManager
    {
        private readonly HttpClient _httpClient;

        public UserServiceManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<UserDto>> Create(UserCreateDto user)
        {
            var response = await _httpClient.PostAsJsonAsync(UserServiceEndpoints.RootPath, user);
            return await response.ToResult<UserDto>();
        }

        public async Task<IResult> Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync(UserServiceEndpoints.Delete(id));
            return await response.ToResult();
        }

        public async Task<IResult<IEnumerable<UserDto>>> GetAll()
        {
            var response = await _httpClient.GetAsync(UserServiceEndpoints.RootPath);
            return await response.ToResult<List<UserDto>>();
        }

        public async Task<IResult> Update(UserUpdateDto user)
        {
            var response = await _httpClient.PutAsJsonAsync(UserServiceEndpoints.RootPath, user);
            return await response.ToResult();
        }
    }
}
