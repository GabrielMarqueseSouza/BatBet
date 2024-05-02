using Contracts;
using IdentityService.Models;
using MassTransit;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.Consumers
{
    public class UpdatedUserBalanceConsumer(UserManager<ApplicationUser> userManager) : IConsumer<UserBalanceUpdated>
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        public async Task Consume(ConsumeContext<UserBalanceUpdated> context)
        {
            Console.WriteLine($"--> User {context.Message.UserId} balance updated at: {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}");

            ApplicationUser? user = await _userManager.FindByIdAsync(context.Message.UserId);

            user.Balance -= context.Message.BetAmount;
            user.UpdatedAt = DateTime.UtcNow;

            await _userManager.UpdateAsync(user);
        }
    }
}
