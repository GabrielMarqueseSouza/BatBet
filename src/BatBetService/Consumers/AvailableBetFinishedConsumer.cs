using BatBetDomain.Entities;
using BatBetInfrastructure.Data;
using Contracts;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatBetServiceAPI.Consumers
{
    public class AvailableBetFinishedConsumer(BatBetDbContext context) : IConsumer<AvailableBetFinished>
    {
        private readonly BatBetDbContext _context = context;

        public async Task Consume(ConsumeContext<AvailableBetFinished> context)
        {
            Console.WriteLine("--> Consuming bet finished");

            AvailableBet availableBet = await _context.AvailableBets
                .FindAsync(context.Message.AvBetId);

            IList<Bet> bets = await _context.Bets
                                    .Where(x => x.AvailableBetId == context.Message.AvBetId)
                                    .ToListAsync();

            if (context.Message.AvBetDueDateReached)
            {
                availableBet.Id = context.Message.AvBetId;
                availableBet.WinnerId = context.Message.WinnerId;
                availableBet.HighestBet = context.Message.Amount;
                availableBet.IsFinished = true;

                foreach (Bet bet in bets)
                {
                    //finished
                    bet.Status = 0;
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
