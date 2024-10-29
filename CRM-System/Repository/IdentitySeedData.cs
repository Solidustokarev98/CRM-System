using Microsoft.AspNetCore.Identity;

namespace CRM_System.Repository
{
    public class IdentitySeedData
    {
        private const string _adminLogin = "Admin";
        private const string _adminPassword = "Password123!";


        public static async Task EnsurePopulatedAsync(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                var user = await userManager.FindByIdAsync(_adminLogin);
                if (user is null)
                {
                    user = new IdentityUser("Admin");
                    var result = await userManager.CreateAsync(user, _adminPassword);
                }
            }
        }
    }
}
