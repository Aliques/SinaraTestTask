using UserManagement.Domain;
using UserManagement.Infrastructure.Data;

namespace UserManagementService
{
    public static class PrepDb
    {
        public static void PrepUser(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                Console.WriteLine("--> Seeding data...");
                context.Users.AddRange(
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "FirstName_1",
                        Surname = "Surname_1",
                        Patronymic = "Patronymic_1",
                        ADLogin = @"domain\FirstName_1"
                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "FirstName_2",
                        Surname = "Surname_2",
                        Patronymic = "Patronymic_2",
                        ADLogin = @"domain\FirstName_2"
                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Name = "FirstName_3",
                        Surname = "Surname_3",
                        Patronymic = "Patronymic_3",
                        ADLogin = @"domain\FirstName_3"
                    }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data!");
            }
        }
    }
}
