using BatBetDomain.Entities;
using BatBetInfrastructure.Data;
using Contracts;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace BatBetServiceAPI.Consumers
{
    public class BetPlacedConsumer(BatBetDbContext context) : IConsumer<BetPlaced>
    {
        private readonly BatBetDbContext _context = context;

        public async Task Consume(ConsumeContext<BetPlaced> context)
        {
            Console.WriteLine("--> Consuming bet placed");

            AvailableBet avBet = await _context.AvailableBets.FindAsync(context.Message.AvBetId);

            if (avBet.HighestBet == 0
                || context.Message.BetStatus == 1
                && context.Message.Amount > avBet.HighestBet)
            {
                avBet.HighestBet = context.Message.Amount;
                await _context.SaveChangesAsync();
            }
        }
    }
}
