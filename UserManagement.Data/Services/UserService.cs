using AutoMapper;
using UserManagement.Application.Interfaces.Repositories;
using UserManagement.Application.Interfaces.Services;
using UserManagement.Common.Dtos;
using UserManagement.Common.Wrapper;
using UserManagement.Domain;

namespace UserManagement.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IResult<UserDto>> CreateAsync(UserCreateDto user)
        {
            // проверка в AD
            var item = _mapper.Map<User>(user);
            var result = await _repository.CreateAsync(item);
            if (!result.Succeeded)
            {
                return await Result<UserDto>.FailAsync(result.Messages.FirstOrDefault(), result);
            }
            var resultItem = _mapper.Map<UserDto>(result.Data);
            return await Result<UserDto>.SuccessAsync(resultItem);
        }

        public async Task<Result<List<UserDto>>> GetAll()
        {
            var data = await _repository.GetAllAsync();
            var result = _mapper.Map<List<UserDto>>(data);
            return await Result<List<UserDto>>.SuccessAsync(result);
        }

        public async Task<IResult> Update(UserUpdateDto user)
        {
            var userDto = _mapper.Map<User>(user);
            return await _repository.UpdateAsync(userDto);
        }

        public async Task<IResult> Delete(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);
            user.Data.UserStatus = Common.Enums.UserStatus.Disabled;
            return await _repository.UpdateAsync(user.Data);
        }
    }
}
