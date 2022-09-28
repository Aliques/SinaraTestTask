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
        private readonly ISyncDataService _syncDataService;
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository, IMapper mapper, ISyncDataService syncDataService)
        {
            _syncDataService = syncDataService;
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IResult<UserDto>> CreateAsync(UserCreateDto user)
        {
            var checkingNameResult = await _syncDataService.CheckingADName(user.ADLogin);
            if (checkingNameResult.Succeeded)
            {
                if (checkingNameResult.Data.Equals(user.ADLogin))
                {
                    return await Result<UserDto>.FailAsync($"User with {user.ADLogin} name already exist.");
                }
                var item = _mapper.Map<User>(user);
                var result = await _repository.CreateAsync(item);
                if (!result.Succeeded)
                {
                    return await Result<UserDto>.FailAsync(result.Messages.FirstOrDefault(), result);
                }
                var resultItem = _mapper.Map<UserDto>(result.Data);
                return await Result<UserDto>.SuccessAsync(resultItem);
            }
            return await Result<UserDto>.FailAsync("ADService connection error!");
        }

        public async Task<Result<List<UserDto>>> GetAll()
        {
            var data = await _repository.GetAllAsync();
            var result = _mapper.Map<List<UserDto>>(data);
            return await Result<List<UserDto>>.SuccessAsync(result);
        }

        public async Task<IResult> Update(UserUpdateDto user)
        {
            var checkingNameResult = await _syncDataService.CheckingADName(user.ADLogin);
            if (checkingNameResult.Succeeded)
            {
                if (checkingNameResult.Data.Name.Equals(user.ADLogin))
                {
                    return await Result.FailAsync($"User with {user.ADLogin} name already exist.");
                }
                var userDto = _mapper.Map<User>(user);
                return await _repository.UpdateAsync(userDto);
            }
            return await Result.FailAsync("ADService connection error!");
        }

        public async Task<IResult> Delete(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);
            user.Data.UserStatus = Common.Enums.UserStatus.Disabled;
            return await _repository.UpdateAsync(user.Data);
        }
    }
}
