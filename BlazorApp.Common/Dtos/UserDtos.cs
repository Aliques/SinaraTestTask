using System.ComponentModel.DataAnnotations;
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
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The Surname must be a string with the exact length of 2.")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The Surname must be a string with the exact length of 2.")]
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        [Required]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "The Active Directory Login must be a string with the exact length of 2.")]
        public string ADLogin { get; set; }
    }

    public class UserUpdateDto
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The Name must be a string with the exact length of 2.")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The Surname must be a string with the exact length of 2.")]
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        [Required]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "The Active Directory Login must be a string with the exact length of 2.")]
        public string ADLogin { get; set; }
    }
}
