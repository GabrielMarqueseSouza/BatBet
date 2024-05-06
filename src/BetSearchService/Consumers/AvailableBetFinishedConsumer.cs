using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BetSearchServiceAPI.Models;
using Contracts;
using MassTransit;
using MongoDB.Entities;

namespace BetSearchServiceAPI.Consumers
{
    public class AvailableBetFinishedConsumer : IConsumer<AvailableBetFinished>
    {
        public async Task Consume(ConsumeContext<AvailableBetFinished> context)
        {
            Console.WriteLine($"--> Consuming available bet finished, Id: {context.Message.AvBetId}");

            AvailableBets avBet = await DB.Find<AvailableBets>().OneAsync(context.Message.AvBetId);

            if (!string.IsNullOrEmpty(context.Message.WinnerId)
                && context.Message.AvBetDueDateReached)
            {
                avBet.WinnerId = context.Message.WinnerId;
                avBet.HighestBet = context.Message.Amount;

                IList<Bets> bets = await DB.Find<Bets>()
                            .ManyAsync(x => x.AvailableBetId == context.Message.AvBetId);

                foreach (Bets bet in bets)
                {
                    bet.Status = Models.Status.Finished;
                    bet.UpdatedAt = DateTime.UtcNow;
                }

                await bets.SaveAsync();
            }

            await avBet.SaveAsync();
        }
    }
}
