using UserManagement.Common.Enums;

namespace UserManagement.Common.Dtos
{
    public record UserDto(Guid id, string Name, string Surname, string patronymic, string ADLogin, UserStatus UserStatus);
    public record CreateUserDto(string Name, string Surname, string patronymic, string ADLogin);
    public record UpdateUserDto(string Name, string Surname, string patronymic, string ADLogin, UserStatus UserStatus);
}
