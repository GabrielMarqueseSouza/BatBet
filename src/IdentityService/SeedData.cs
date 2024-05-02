using IdentityModel;
using IdentityService.Data;
using IdentityService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace IdentityService;

public class SeedData
{
    public static void EnsureSeedData(WebApplication app)
    {
        using IServiceScope scope = app.Services
                                .GetRequiredService<IServiceScopeFactory>()
                                .CreateScope();

        ApplicationDbContext context = scope.ServiceProvider
                                            .GetRequiredService<ApplicationDbContext>();

        context.Database.Migrate();

        UserManager<ApplicationUser> userMgr = scope.ServiceProvider
                                            .GetRequiredService<UserManager<ApplicationUser>>();

        if (userMgr.Users.Any()) return;

        ApplicationUser? user = userMgr.FindByNameAsync("Gabriel").Result;
        if (user == null)
        {
            user = new ApplicationUser
            {
                UserName = "Gabriel",
                LastName = "Marques",
                Email = "test@localhost.com",
                EmailConfirmed = true,
                DocumentNumber = "ABCXYZ0000",
                Age = 21,
                Address = "Test address street 123",
                Complement = "Apartment 01",
                State = "Non Defined",
                StateAcronym = "ND",
                Country = "ND",
                PhoneNumber = "000111222333",
                PhoneNumberConfirmed = true,
                Balance = 9000000,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsBlocked = false,
                BlockReason = ""
            };
            IdentityResult result = userMgr.CreateAsync(user, "Pass123$").Result;
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            result = userMgr.AddClaimsAsync(user, [
                            new(JwtClaimTypes.Name, "Gabriel Marques"),
                            new(JwtClaimTypes.ClientId, user.Id),
                            new(JwtClaimTypes.Email, user.Email)
                        ]).Result;
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }
            Log.Debug($"User {user.NormalizedUserName} created");
        }
        else
        {
            Log.Debug($"User {user.NormalizedUserName} already exists");
        }
    }
}
