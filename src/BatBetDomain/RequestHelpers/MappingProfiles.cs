using AutoMapper;
using BatBetDomain.DTOs.Request;
using BatBetDomain.DTOs.Response;
using BatBetDomain.Entities;
using Contracts;

namespace BatBetDomain.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Bet, BetDto>();
            CreateMap<Game, BetDto>();
            CreateMap<PlaceBetDto, Bet>();
            CreateMap<PlaceBetDto, Game>();

            CreateMap<BetDto, BetCreated>()
                .ForMember(d => d.GameName, o => o.MapFrom(s => s.GameName));

            CreateMap<int, BetUpdated>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s));

            CreateMap<int, BetDeleted>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s));
        }
    }
}
