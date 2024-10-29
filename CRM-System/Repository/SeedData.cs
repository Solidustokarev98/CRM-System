using CRM_System.Db;
using CRM_System.Models;

namespace CRM_System.Repository
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (context.Managers.Any())
                {
                    return;
                }

                context.Managers.AddRange(
                    new Manager
                    {
                        Name = "Manager 1",
                        Role = "Manager"
                    },
                    new Manager
                    {
                        Name = "Manager 2",
                        Role = "Manager"
                    },
                    new Manager
                    {
                        Name = "Manager 3",
                        Role = "Manager"
                    },
                    new Manager
                    {
                        Name = "Manager 4",
                        Role = "Manager"
                    },
                    new Manager
                    {
                        Name = "Manager 5",
                        Role = "Manager"
                    },
                    new Manager
                    {
                        Name = "Manager 6",
                        Role = "Manager"
                    },
                    new Manager
                    {
                        Name = "Manager 7",
                        Role = "Manager"
                    },
                    new Manager
                    {
                        Name = "Manager 8",
                        Role = "Manager"
                    },
                    new Manager
                    {
                        Name = "Manager 9",
                        Role = "Manager"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
