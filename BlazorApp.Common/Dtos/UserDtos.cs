using UserManagement.Common.Enums;

namespace UserManagement.Common.Dtos
{
    public record UserDto(Guid id, string Name, string Surname, string Patronymic, string ADLogin, UserStatus UserStatus);
    public record UserCreateDto(string Name, string Surname, string Patronymic, string ADLogin);
    public record UserUpdateDto(string Name, string Surname, string Patronymic, string ADLogin, UserStatus UserStatus);
}
