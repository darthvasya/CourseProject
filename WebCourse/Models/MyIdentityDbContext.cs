using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace WebCourse.Models {
    public class MyIdentityDbContext : IdentityDbContext<User> {

        public MyIdentityDbContext(DbContextOptions<MyIdentityDbContext> options)
            : base(options) { }

        public static async Task CreateAdminAcc(IServiceProvider serviceProvider, IConfiguration configuration) {
            UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string name = configuration["AdminUser:Name"];
            string email = configuration["AdminUser:Email"];
            string pass = configuration["AdminUser:Password"];
            string role = configuration["AdminUser:Role"];
            
            if(await userManager.FindByEmailAsync(email) == null) {
                if(await roleManager.FindByNameAsync(role) == null) {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                User user = new User {
                    Email = email,
                    UserName = email,
                    Name = name,
                    EmailConfirmed = true
                };

                IdentityResult result = await userManager.CreateAsync(user, pass);
                if (result.Succeeded) {
                    await userManager.AddToRoleAsync(user, role);
                }
            } 
        }
    }
}
