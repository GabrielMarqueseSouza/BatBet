using System;
using System.Security.Claims;

namespace BatBetServiceAPI.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            ArgumentNullException.ThrowIfNull(principal);

            Claim userId = principal.FindFirst(ClaimTypes.NameIdentifier);

            return userId.Value.ToString() ?? "";
        }

        public static string GetUserBalance(this ClaimsPrincipal principal)
        {
            ArgumentNullException.ThrowIfNull(principal);

            string userBalance = principal.FindFirstValue("userbalance");

            return userBalance;
        }
    }
}
