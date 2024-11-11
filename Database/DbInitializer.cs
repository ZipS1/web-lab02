using lab02.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace lab02.Database
{
    public static class DbInitializer
    {
        public static async Task<bool> EnsureDbCreatedAndSeededAsync(DbContextOptions<AppDbContext> options)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>(options);

            using var context = new AppDbContext(builder.Options);
            if (await context.Database.EnsureCreatedAsync())
            {
                await SeedAsync(context);
                return true;
            }
            return false;
        }

        private static async Task SeedAsync(AppDbContext context)
        {
            var adminRole = new IdentityRole("Admin");
            var supplierAgentRole = new IdentityRole("SupplierAgent");
            await context.Roles.AddAsync(adminRole);
            await context.Roles.AddAsync(supplierAgentRole);

            var rootUser = new AppUser
            {
                UserName = "root@email.com",
                Email = "root@email.com",
                NormalizedEmail = "ROOT@EMAIL.COM",
                NormalizedUserName = "ROOT@EMAIL.COM"
            };

            var passwordHasher = new PasswordHasher<AppUser>();
            rootUser.PasswordHash = passwordHasher.HashPassword(rootUser, "root");

            await context.Users.AddAsync(rootUser);
            await context.SaveChangesAsync();

            await context.UserRoles.AddAsync(
                new IdentityUserRole<string>
                {
                    RoleId = adminRole.Id,
                    UserId = rootUser.Id
                }
            );

            await context.SaveChangesAsync();
        }
    }
}
