using AutoMapper;
using BetSearchServiceAPI.Models;
using Contracts;

namespace BetSearchServiceAPI.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BetCreated, Bets>();
            CreateMap<BetUpdated, Bets>()
                    .ForMember(d => d.ID, o => o.MapFrom(s => s.Id.ToString()));

            CreateMap<BetDeleted, Bets>()
            .ForMember(d => d.ID, o => o.MapFrom(s => s.Id.ToString()));
        }
    }
}
