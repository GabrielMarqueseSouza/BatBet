using System;
using System.Threading.Tasks;
using AutoMapper;
using BetSearchServiceAPI.Models;
using Contracts;
using MassTransit;
using MongoDB.Entities;

namespace BetSearchServiceAPI.Consumers
{
    public class BetUpdatedConsumer(IMapper mapper) : IConsumer<BetUpdated>
    {
        private readonly IMapper _mapper = mapper;

        public async Task Consume(ConsumeContext<BetUpdated> context)
        {
            Console.WriteLine($"--> Consuming bet updated at: {context.Message.UpdatedAt:yyyy-MM-dd HH:mm:ss}");

            Bets item = _mapper.Map<Bets>(context.Message);

            var result = await DB.Update<Bets>().MatchID(context.Message.Id).ModifyOnly(x => new
            {
                x.UpdatedAt,
                x.Status
            }, item).ExecuteAsync();

            if (!result.IsAcknowledged)
                throw new MessageException(typeof(BetUpdated), "Problem updating MongoDb");

        }
    }
}