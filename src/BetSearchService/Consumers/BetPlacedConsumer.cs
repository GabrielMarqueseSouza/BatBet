using System;
using System.Threading.Tasks;
using BetSearchServiceAPI.Models;
using Contracts;
using MassTransit;
using MongoDB.Entities;

namespace BetSearchServiceAPI.Consumers
{
    public class BetPlacedConsumer : IConsumer<BetPlaced>
    {
        public async Task Consume(ConsumeContext<BetPlaced> context)
        {
            Console.WriteLine($"--> Consuming bet placed at: {context.Message.BetTime:yyyy-MM-dd HH:mm:ss}");

            AvailableBets avBet = await DB.Find<AvailableBets>().OneAsync(context.Message.AvBetId);

            //1 = Active
            if (context.Message.BetStatus == 1
                && context.Message.Amount > avBet.HighestBet)
            {
                avBet.HighestBet = context.Message.Amount;
                avBet.LastBetPlaced = context.Message.BetTime;
                avBet.LastBetPlacedUserId = context.Message.Bettor;
            }

            await avBet.SaveAsync();
        }
    }
}
