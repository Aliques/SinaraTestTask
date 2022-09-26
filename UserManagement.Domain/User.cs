using UserManagement.Common.Enums;

namespace UserManagement.Domain
{
    public interface IEntity<T>
    {
        public T Id { get; set; }
    }
    public class User: IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string ADLogin { get; set; }
        public UserStatus UserStatus { get; set; }
    }
}