using UserManagement.Common.Enums;

namespace UserManagement.Common.Dtos
{
    //public record UserDto(Guid Id, string Name, string Surname, string Patronymic, string ADLogin, UserStatus? UserStatus);
    //public record UserCreateDto(string Name, string Surname, string Patronymic, string ADLogin);
    //public record UserUpdateDto(Guid Id, string Name, string Surname, string Patronymic, string ADLogin);
    public class UserDto {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string ADLogin { get; set; }
    }

    public class UserCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string ADLogin { get; set; }
    }

    public class UserUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string ADLogin { get; set; }
    }
}
