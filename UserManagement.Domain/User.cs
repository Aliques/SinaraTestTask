using System.ComponentModel.DataAnnotations;
using UserManagement.Common.Enums;

namespace UserManagement.Domain
{
    public interface IEntity<T>
    {
        public T Id { get; set; }
    }
    public class User: IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The Name must be a string with the exact length of 2.")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The Surname must be a string with the exact length of 2.")]
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "The Active Directory Login must be a string with the exact length of 2.")]
        public string ADLogin { get; set; }
        public UserStatus UserStatus { get; set; } = UserStatus.Active;
    }
}