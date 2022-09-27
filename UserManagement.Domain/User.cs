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

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        [Required]
        public string ADLogin { get; set; }
        public UserStatus UserStatus { get; set; } = UserStatus.Active;
    }
}