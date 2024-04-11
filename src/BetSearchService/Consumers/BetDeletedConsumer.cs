using System;
using System.Threading.Tasks;
using AutoMapper;
using BetSearchServiceAPI.Models;
using Contracts;
using MassTransit;
using MongoDB.Entities;

namespace BetSearchServiceAPI.Consumers
{
    public class BetDeletedConsumer(IMapper mapper) : IConsumer<BetDeleted>
    {
        private readonly IMapper _mapper = mapper;

        public async Task Consume(ConsumeContext<BetDeleted> context)
        {
            Console.WriteLine($"--> Consuming bet deleted at: {context.Message.DeletedAt:yyyy-MM-dd HH:mm:ss}");

            Bets item = _mapper.Map<Bets>(context.Message);

            var result = await DB.DeleteAsync<Bets>(item.ID);

            if (!result.IsAcknowledged)
                throw new MessageException(typeof(BetDeleted), "Problem updating MongoDb");
        }
    }
}