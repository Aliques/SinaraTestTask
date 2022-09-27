using AutoMapper;
using UserManagement.Common.Dtos;
using UserManagement.Domain;

namespace UserManagement.Infrastructure.Profiles
{
    public class UsersProfiles : Profile
    {
        public UsersProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
