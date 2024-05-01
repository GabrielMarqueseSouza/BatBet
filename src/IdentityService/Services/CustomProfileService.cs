using System.Security.Claims;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityService.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.Services
{
    public class CustomProfileService(UserManager<ApplicationUser> userManager) : IProfileService
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            ApplicationUser? user = await _userManager.GetUserAsync(context.Subject);
            IList<Claim>? existingClaims = await _userManager.GetClaimsAsync(user);

            IList<Claim> claims = [
                new(type: "username", value: user.UserName),
                new(type: "useraddress", value: user.Address),
                new(type: "userbalance", value: user.Balance.ToString()),
                new(type: "isblocked", value: user.IsBlocked.ToString()),
                new(type: "blockreason", value: user.IsBlocked ? user.BlockReason.ToString() : ""),
                new(type: "isauthenticated", value: context.Subject.Identity.IsAuthenticated.ToString())];

            context.IssuedClaims.AddRange(claims);

            //Collection expression that corresponds to existingClaims.ToList()
            context.IssuedClaims
                .AddRange([.. existingClaims]);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.CompletedTask;
        }
    }
}